Public MustInherit Class clGame
    Inherits clSettings


    Public WheelSensitivity As Single = 8.5
    Public Const BtCount = 10
    Public Bt(2 * BtCount - 1) As String ' 0~9 & 10~19
    Public BtDescr(2 * BtCount - 1) As String ' 0~9 & 10~19


    Friend Owner As frmCVJoy
    Public MustOverride Function GameName() As String

    Public Sub New(pOwner As frmCVJoy)
        Owner = pOwner
    End Sub

    Public MustOverride Sub Start()
    Public MustOverride Sub [Stop]()
    Public MustOverride Function Started() As Boolean
    Public MustOverride Function GetGameOutputs(pDoWind As Boolean, pDoShakeSpeed As Boolean, pDoShakeAccel As Boolean, pDoShakeJump As Boolean) As clGameOutputs
    Public MustOverride Function GetGameOutputsExtra() As clGameOutputsExtra
    Public MustOverride Sub ShowSetup()

    Public Event StateChanged()

    Private _State As String
    Public Property State() As String
        Get
            Return _State
        End Get
        Friend Set(value As String)
            _State = value
            RaiseEvent StateChanged()
        End Set
    End Property


    ' these PP are used by Reflection in clSettings.SaveSettingstoFile() and LoadSettingsFromFile() !!!!
    Public Property Bts() As String
        Get
            Return String.Join("£", Bt)
        End Get
        Friend Set(value As String)
            Dim tmp() As String = value.Split("£"c)
            For i As Integer = 0 To Bt.Length - 1
                If i >= tmp.Length Then Exit For
                Bt(i) = tmp(i)
            Next
        End Set
    End Property

    Public Property BtDescrs() As String
        Get
            Return String.Join("£", BtDescr)
        End Get
        Friend Set(value As String)
            Dim tmp() As String = value.Split("£"c)
            For i As Integer = 0 To BtDescr.Length - 1
                If i >= tmp.Length Then Exit For
                BtDescr(i) = tmp(i)
            Next
        End Set
    End Property

End Class


Public Structure clGameOutputs ' info that needs updating very frequently
    Public RigWind As Byte ' 0~255  calculated wind to apply to motion rig
    Public RigShakePower As Byte  ' 0~255 calculated shake to apply to motion rig
    Public RigShakeSpeed As Byte  ' 0~255 calculated shake to apply to motion rig
    Public RigPitch As Single ' radians calculated pitch to apply to motion rig
    Public RigRoll As Single ' radians calculated roll to apply to motion rig

    Public GamePitch As Single, GameRoll As Single, GameAccelZ As Single
    Public SlipFL As Byte
    Public SlipFR As Byte
    Public SlipRL As Byte
    Public SlipRR As Byte
    Public Speed As Single ' Km/h ' has to be Single so that GameAC can check if is EXACTLY the same as last time
    Public RPM As Integer
    Public Gear As Byte ' 0=" "  1="R"   2="N"  3="1"  4="2"...
    Public GearAuto As Boolean
    Public TyreDirtFL As Byte
    Public TyreDirtFR As Byte
    Public TyreDirtRL As Byte
    Public TyreDirtRR As Byte
    Public TurboBoost As Integer '   x100
    Public Acceleration As Single '  calculated  delta Km/h / delta milliseconds * 15
    Public Rotation As Single '  calculated ?...
    Public GameLastRead As Date

    Private GameLastSpeed As Single

    Public Shared Function PausedGameOutputs(pSpeedTest As Single) As clGameOutputs
        Dim res As clGameOutputs
        res.Speed = pSpeedTest
        res.Calculate(IsPaused:=True, pDoWind:=False, pDoShakeSpeed:=False, pDoShakeAccel:=False, pDoShakeJump:=False)
        Return res
    End Function

    Public Sub Calculate(IsPaused As Boolean, pDoWind As Boolean, pDoShakeSpeed As Boolean, pDoShakeAccel As Boolean, pDoShakeJump As Boolean)
        If IsPaused Then
            Acceleration = 0
            Rotation = 0
            Me.RigPitch = 0
            Me.RigRoll = 0
            Me.RigWind = FFWind(SpeedKmh:=Speed, pJump:=0, pAcceleration:=0)
            Me.RigShakePower = FFShakePower(pJump:=0, pAcceleration:=0, SpeedKmh:=0)
            Me.RigShakeSpeed = FFShakeSpeed(pJump:=0, pAcceleration:=0, SpeedKmh:=0)
            Return
        End If

        Const damping As Single = 0.7
        Acceleration = Acceleration * damping + (Speed - GameLastSpeed) / Now.Subtract(GameLastRead).TotalMilliseconds * 15 * (1 - damping)
        GameLastSpeed = Speed
        GameLastRead = Now
        ' TODO: calculate Rotation
        Me.RigPitch = GamePitch * SettingsMain.Pitch + Acceleration * SettingsMain.Accel ' everything in Radians (me.accel has allready been converted) ' acP.AccG(2) has lots of noise, unusable!
        Me.RigRoll = -GameRoll * SettingsMain.Roll + Rotation * SettingsMain.Turn '' everything in Radians (me.turn has allready been converted)
        Dim Jump As Single = Math.Abs(GameAccelZ) ^ 2 * Math.Sign(GameAccelZ) * 10
        Me.RigWind = If(pDoWind, FFWind(SpeedKmh:=Speed, pJump:=Jump, pAcceleration:=Acceleration), 0)
        Me.RigShakePower = FFShakePower(pJump:=If(pDoShakeJump, Jump, 0), pAcceleration:=If(pDoShakeAccel, Acceleration, 0), SpeedKmh:=If(pDoShakeSpeed, Speed, 0))
        Me.RigShakeSpeed = FFShakeSpeed(pJump:=If(pDoShakeJump, Jump, 0), pAcceleration:=If(pDoShakeAccel, Acceleration, 0), SpeedKmh:=If(pDoShakeSpeed, Speed, 0))
    End Sub

    Private Function FFWind(SpeedKmh As Single, pJump As Single, pAcceleration As Single) As Byte
        Dim res As Integer = 0  ' typical 0~255, but can get to something like -2000~2000

        If SettingsMain.WindMaxSpeed > SettingsMain.WindMinSpeed AndAlso SpeedKmh > SettingsMain.WindMinSpeed Then
            res += (SpeedKmh - SettingsMain.WindMinSpeed) * 255 / (SettingsMain.WindMaxSpeed - SettingsMain.WindMinSpeed)
        End If

        If SettingsMain.WindMaxJump > 0 Then
            res += pJump / SettingsMain.WindMaxJump * 255
        End If

        If SettingsMain.WindMaxAccel > 0 Then
            res += pAcceleration / SettingsMain.WindMaxAccel * 255
        End If

        res = CalculateOutput(res, 255, 1, SettingsMain.WindMinPower, SettingsMain.WindGama, 1)
        If graph IsNot Nothing Then graph.UpdateWind(res)
        Return res
    End Function


    Private Function FFShakeSpeed(pJump As Single, pAcceleration As Single, SpeedKmh As Single) As Byte
        Dim res As Integer = 0

        If SettingsMain.ShakeSpeedMaxSpeed > SettingsMain.ShakeSpeedMinSpeed AndAlso SpeedKmh > SettingsMain.ShakeSpeedMinSpeed Then
            res = (CSng(SpeedKmh - SettingsMain.ShakeSpeedMinSpeed) / CSng(SettingsMain.ShakeSpeedMaxSpeed - SettingsMain.ShakeSpeedMinSpeed)) ^ (SettingsMain.ShakeGama / 100) * 255
        End If

        If SettingsMain.ShakeSpeedMaxJump <> 0 AndAlso Math.Abs(pJump) > 0.01 Then
            res += pJump * 255 / SettingsMain.ShakeSpeedMaxJump
        End If

        If SettingsMain.ShakeSpeedMaxAccel <> 0 Then
            res += pAcceleration * 255 / SettingsMain.ShakeSpeedMaxAccel
        End If

        res = Math.Max(Math.Min(res, 255), 0)
        If graph IsNot Nothing Then graph.UpdateShakeSpeed(res)
        Return res
    End Function

    Private Function FFShakePower(pJump As Single, pAcceleration As Single, SpeedKmh As Single) As Byte
        Dim res As Integer = SettingsMain.ShakePowerNominal - SpeedKmh / CSng(6)     ' typical 0~255, but can get to something like -2000~2000

        If SettingsMain.ShakePowerMaxJump <> 0 Then
            res += pJump * 255 / SettingsMain.ShakePowerMaxJump
        End If

        If SettingsMain.ShakePowerMaxAccel <> 0 Then
            res += Math.Abs(pAcceleration) * 255 / SettingsMain.ShakePowerMaxAccel
        End If

        res = Math.Max(Math.Min(res, 255), 0)
        If graph IsNot Nothing Then graph.UpdateShakePower(res)
        Return res
    End Function

End Structure


Public Structure clGameOutputsExtra ' info that needs updating 1 time per second
    Public RpmMax As Integer
    Public MaxFuel As Byte
    Public Fuel As Byte
    Public FuelAvg As Integer
    Public TyreWearFL As Byte
    Public TyreWearFR As Byte
    Public TyreWearRL As Byte
    Public TyreWearRR As Byte
    Public NumCars As Byte
    Public Position As Byte
    Public NumberOfLaps As Byte
    Public CompletedLaps As Byte
    Public DistanceTraveled As Integer
End Structure
