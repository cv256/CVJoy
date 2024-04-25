Imports AssettoCorsaSharedMemory

Public Class GameAC
    Inherits clGame

    Private AC As AssettoCorsaSharedMemory.AssettoCorsa
    Private ACP As AssettoCorsaSharedMemory.Physics
    Private ACS As AssettoCorsaSharedMemory.StaticInfo
    Private ACG As AssettoCorsaSharedMemory.Graphics
    Private GameOutputs As clGameOutputs
    Private GameOutputsExtra As clGameOutputsExtra


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

    Public Overrides Function GetGameOutputs() As clGameOutputs
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
                If ACP.SpeedKmh = GameOutputs.Speed Then 'AndAlso Now.Subtract(GameOutputs.GameLastRead).TotalMilliseconds > 1000  ' more then 1 second with the same readings means AC is dead
                    State = "PAUSED"
                    ACstopped = True
                End If
            End If
        End If

        If ACstopped Then
            ACS.MaxRpm = 0 ' using  acS.MaxRpm=0  as a flag to indicate AC was not running
            Return clGameOutputs.PausedGameOutputs(fromArduino.AccelCorrected)  'If tmpFrm IsNot Nothing Then Integer.TryParse(tmpFrm.lbACSpeed.Text, ACP.SpeedKmh) ' if not connected to AC, user can input data to simulate AC
        End If

        If ACS.MaxRpm = 0 Then ' if AC just started or restarted:
            ACS = AC.ReadStaticInfo
            State = ACS.ACVersion & "   " & ACS.CarModel & "   " & ACS.Track & "   " & ACS.TrackConfiguration
        End If
        GameOutputs.SlipFL = Math.Min(ACP.WheelSlip(0) / SettingsMain.SlipMax * 82, 255)
            GameOutputs.SlipFR = Math.Min(ACP.WheelSlip(1) / SettingsMain.SlipMax * 82, 255)
            GameOutputs.SlipRL = Math.Min(ACP.WheelSlip(2) / SettingsMain.SlipMax * 82, 255)
            GameOutputs.SlipRR = Math.Min(ACP.WheelSlip(3) / SettingsMain.SlipMax * 82, 255)
            GameOutputs.Speed = ACP.SpeedKmh
            GameOutputs.RPM = ACP.Rpms
            GameOutputs.Gear = ACP.Gear + 1
            GameOutputs.GearAuto = ACP.AutoShifterOn > 0
            If (ACP.TyreDirtyLevel IsNot Nothing) Then
                GameOutputs.TyreDirtFL = Math.Min(ACP.TyreDirtyLevel(0) / SettingsMain.SlipMax * 255, 255)
                GameOutputs.TyreDirtFR = Math.Min(ACP.TyreDirtyLevel(1) / SettingsMain.SlipMax * 255, 255)
                GameOutputs.TyreDirtRL = Math.Min(ACP.TyreDirtyLevel(2) / SettingsMain.SlipMax * 255, 255)
                GameOutputs.TyreDirtRR = Math.Min(ACP.TyreDirtyLevel(3) / SettingsMain.SlipMax * 255, 255)
            End If
            GameOutputs.TurboBoost = ACP.TurboBoost * 100
            GameOutputs.GamePitch = ACP.Pitch
            GameOutputs.GameRoll = ACP.Roll
            GameOutputs.GameAccelZ = ACP.AccG(1)

        GameOutputs.Calculate()
        Return GameOutputs
    End Function


    Public Overrides Function GetGameOutputsExtra() As clGameOutputsExtra
        If AC Is Nothing OrElse Not AC.IsRunning Then
            Dim res As clGameOutputsExtra
            GameOutputsExtra = res
            Return res
        End If

        GameOutputsExtra.RpmMax = ACS.MaxRpm
        If (ACP.TyreWear IsNot Nothing) Then
            GameOutputsExtra.TyreWearFL = 255 - ACP.TyreWear(0) * 2.55
            GameOutputsExtra.TyreWearFR = 255 - ACP.TyreWear(1) * 2.55
            GameOutputsExtra.TyreWearRL = 255 - ACP.TyreWear(2) * 2.55
            GameOutputsExtra.TyreWearRR = 255 - ACP.TyreWear(3) * 2.55
        End If
        GameOutputsExtra.NumCars = ACS.NumCars
        GameOutputsExtra.MaxFuel = Math.Min(255, ACS.MaxFuel)
        GameOutputsExtra.Fuel = Math.Min(255, ACP.Fuel)
        '  acP.CarDamage(5)
        '  acP.PerformanceMeter
        '  acP.Abs
        '  acP.TC

        ACG = AC.ReadGraphics()
        GameOutputsExtra.DistanceTraveled = ACG.DistanceTraveled
        GameOutputsExtra.NumberOfLaps = ACG.NumberOfLaps
        GameOutputsExtra.CompletedLaps = ACG.CompletedLaps
        ' res.Position = ACG.Position ' ACG.NormalizedCarPosition 
        'ACP.PerformanceMeter
        ' res.CurrentTime = ACG.iCurrentTime
        ' res.LastTime = ACG.iLastTime
        ' res.BestTime = ACG.iBestTime

        Static oldFuel As Single
        If ACG.DistanceTraveled < 1 Then
            GameOutputsExtra.FuelAvg = 0
            oldFuel = ACP.Fuel
        Else
            GameOutputsExtra.FuelAvg = Math.Min(Math.Abs((oldFuel - ACP.Fuel) * 10000000 / ACG.DistanceTraveled), Integer.MaxValue)
        End If

        Return GameOutputsExtra
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

End Class


