Imports AssettoCorsaSharedMemory

Public Class GameAC
    Inherits clGame

    Private AC As AssettoCorsaSharedMemory.AssettoCorsa
    Private ACP As AssettoCorsaSharedMemory.Physics
    Private ACS As AssettoCorsaSharedMemory.StaticInfo
    Private ACG As AssettoCorsaSharedMemory.Graphics
    Private ACLastRead As Date, ACLastSpeedKmh As Single, Acceleration As Single, Rotation As Single

    ' Public Rpm1 As Single = 0.4
    ' Public Rpm2 As Single = 0.93
    Public Slip As Short = 1

    Public MinSpeed As Integer = 60
    Public MaxSpeed As Integer = 230
    Public SpeedMaxJump As Single = 0.7
    Public ShakeMaxJump As Single = 3.5
    Public ShakeMinJump As Single = 0.5

    Public Pitch As Single = 0.26
    Public Roll As Single = 0.65
    Public Accel As Single = 0.07155323
    Public Turn As Single = 0.05235602

    Public Sub New(pOwner As frmCVJoy)
        MyBase.New(pOwner)
    End Sub
    Public Overrides Function GameName() As String
        Return "Assetto Corsa"
    End Function
    Public Overrides Function FileName() As String
        Return "SettingsAC.INI"
    End Function

    Public Overrides Sub Start()
        Try
            AC = New AssettoCorsa()
            AC.Start()
            State = "communication exists"
        Catch ex As Exception
            MsgBox("btGameStart.Click " & ex.Message)
        End Try
    End Sub
    Public Overrides Sub [Stop]()
        If AC IsNot Nothing Then AC.Stop()
        AC = Nothing
        State = ""
    End Sub

    Public Overrides Function Started() As Boolean
        Return AC IsNot Nothing
    End Function

    Public Overrides Function Update() As clGameOutputs
        Dim res As clGameOutputs

        ' Get data from AC:
        Dim ACstopped As Boolean = False
        If AC Is Nothing Then
            State = ""
            ACstopped = True
        Else
            If Not AC.IsRunning Then
                State = "NOT RUNNING"
                ACstopped = True
            Else
                ACP = AC.ReadPhysics()

                If ACP.SpeedKmh <> ACLastSpeedKmh Then
                    Const damping As Single = 0.7
                    Acceleration = Acceleration * damping + (ACP.SpeedKmh - ACLastSpeedKmh) / Now.Subtract(ACLastRead).TotalMilliseconds * 15 * (1 - damping)
                    Rotation = Rotation * damping + ACP.AccG(0) * (1 - damping)
                    ACLastRead = Now
                    ACLastSpeedKmh = ACP.SpeedKmh
                End If
                If Now.Subtract(ACLastRead).TotalSeconds > 0 Then ' more then 1 second with the same readings means AC is dead
                    State = "DEAD"
                    ACstopped = True
                End If
            End If
        End If

        Dim tmpFrm As frmSetupAC = SetupForm()
        If ACstopped Then
            ACS.MaxRpm = 0 ' using  acS.MaxRpm=0  as a flag to indicate AC was not running
            ACP = New Physics ' to clear all acp
            If tmpFrm IsNot Nothing Then Integer.TryParse(tmpFrm.lbACSpeed.Text, ACP.SpeedKmh) ' if not connected to AC, user can input data to simulate AC
            Dim dummyAccG(2) As Single : ACP.AccG = dummyAccG
            Dim dummyWheelSlip(3) As Single : ACP.WheelSlip = dummyWheelSlip
        Else
            If ACS.MaxRpm = 0 Then ' if AC just started or restarted:
                ACS = AC.ReadStaticInfo
                State = ACS.ACVersion & "   " & ACS.CarModel & "   " & ACS.Track & "   " & ACS.TrackConfiguration
                If tmpFrm IsNot Nothing Then tmpFrm.lbMaxRPM.Text = ACS.MaxRpm
            End If
            res.SlipFL = Math.Min(ACP.WheelSlip(0) / Me.Slip * 255, 255)
            res.SlipFR = Math.Min(ACP.WheelSlip(1) / Me.Slip * 255, 255)
            res.SlipRL = Math.Min(ACP.WheelSlip(2) / Me.Slip * 255, 255)
            res.SlipRR = Math.Min(ACP.WheelSlip(3) / Me.Slip * 255, 255)
            res.Speed = ACP.SpeedKmh
            res.RPM = ACP.Rpms
            res.Gear = ACP.Gear + 1
            res.GearAuto = ACP.AutoShifterOn > 0
            If (ACP.TyreDirtyLevel IsNot Nothing) Then
                res.TyreDirtFL = Math.Min(ACP.TyreDirtyLevel(0) / Me.Slip * 255, 255)
                res.TyreDirtFR = Math.Min(ACP.TyreDirtyLevel(1) / Me.Slip * 255, 255)
                res.TyreDirtRL = Math.Min(ACP.TyreDirtyLevel(2) / Me.Slip * 255, 255)
                res.TyreDirtRR = Math.Min(ACP.TyreDirtyLevel(3) / Me.Slip * 255, 255)
            End If

        End If

        ' Set Output :
        res.Pitch = ACP.Pitch * Me.Pitch + Acceleration * Me.Accel ' everything in Radians (me.accel has allready been converted) ' acP.AccG(2) has lots of noise, unusable!
        res.Roll = -ACP.Roll * Me.Roll + Rotation * Me.Turn '' everything in Radians (me.turn has allready been converted)
        res.Wind = FFWind(SpeedKmh:=ACP.SpeedKmh, pAccG1:=ACP.AccG(1))
        res.Shake = FFShake(pAccG1:=ACP.AccG(1))

        '' show raw AC data on screen:
        If tmpFrm IsNot Nothing AndAlso tmpFrm.WindowState <> FormWindowState.Minimized Then
            tmpFrm.UpdateACValues(ACP)
        End If

        Return res
    End Function


    Public Overrides Function UpdateExtra() As clGameOutputsExtra
        Dim res As clGameOutputsExtra
        If AC Is Nothing OrElse Not AC.IsRunning Then Return res

        res.RpmMax = ACS.MaxRpm
        If (ACP.TyreWear IsNot Nothing) Then
            res.TyreWearFL = 255 - ACP.TyreWear(0) * 2.55
            res.TyreWearFR = 255 - ACP.TyreWear(1) * 2.55
            res.TyreWearRL = 255 - ACP.TyreWear(2) * 2.55
            res.TyreWearRR = 255 - ACP.TyreWear(3) * 2.55
        End If
        res.NumCars = ACS.NumCars
        res.MaxFuel = ACS.MaxFuel
        res.Fuel = ACP.Fuel
        '  acP.CarDamage(5)
        '  acP.PerformanceMeter
        '  acP.Abs
        '  acP.TC

        ACG = AC.ReadGraphics()
        res.DistanceTraveled = ACG.DistanceTraveled
        res.NumberOfLaps = ACG.NumberOfLaps
        res.CompletedLaps = ACG.CompletedLaps
        ' res.Position = ACG.Position ' ACG.NormalizedCarPosition 
        'ACP.PerformanceMeter
        ' res.CurrentTime = ACG.iCurrentTime
        ' res.LastTime = ACG.iLastTime
        ' res.BestTime = ACG.iBestTime

        Static oldFuel As Single
        If ACG.DistanceTraveled < 1 Then
            res.FuelAvg = 0
            oldFuel = ACP.Fuel
        Else
            res.FuelAvg = Math.Min(Math.Abs((oldFuel - ACP.Fuel) * 10000000 / ACG.DistanceTraveled), Integer.MaxValue)
        End If

        Return res
    End Function



    Public Function SetupForm() As frmSetupAC
        If Owner.OwnedForms.Any(Function(f) TypeOf f Is frmSetupAC) Then
            Return Owner.OwnedForms.First(Function(f) TypeOf f Is frmSetupAC)
        End If
        Return Nothing
    End Function

    Public Overrides Sub ShowSetup()
        Dim tmpFrm As frmSetupAC = SetupForm()
        If tmpFrm IsNot Nothing Then
            tmpFrm.Show()
        Else
            tmpFrm = New frmSetupAC
            tmpFrm.Init(Owner, Me)
        End If
    End Sub

    Private Function FFWind(SpeedKmh As Single, pAccG1 As Single) As Integer
        Dim res As Integer = (If(SpeedKmh > Me.MinSpeed, (SpeedKmh - Me.MinSpeed) / (Me.MaxSpeed - Me.MinSpeed), 0) + pAccG1 / Me.SpeedMaxJump) * 255 ' typical 0~255, but can get to something like -2000~2000
        If graph IsNot Nothing Then graph.UpdateWind(res)
        Return res
    End Function

    Private Function FFShake(pAccG1 As Single) As Integer
        Dim res As Single = pAccG1 ^ 2 * 20 ' percentage of ShakeMaxJump
        If res < ShakeMinJump Then
            res = 0
        Else
            res = ScaleValue(res, ShakeMinJump, ShakeMaxJump, 0, 255)
        End If
        If graph IsNot Nothing Then graph.UpdateShake(res)
        Return res
    End Function

End Class


