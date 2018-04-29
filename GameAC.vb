Imports AssettoCorsaSharedMemory

Public Class GameAC
    Inherits clGame

    Private AC As AssettoCorsaSharedMemory.AssettoCorsa
    Private ACS As AssettoCorsaSharedMemory.StaticInfo

    Public Rpm1 As Single = 0.4
    Public Rpm2 As Single = 0.93
    Public Slip As Short = 1

    Public MinSpeed As Integer = 60
    Public MaxSpeed As Integer = 230
    Public SpeedMaxJump As Single = 0.7
    Public ShakeMaxJump As Single = 1.0
    Public ShakeMinJump As Single = 0.3

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
            AC.Start() ' Connect To Shared memory And start interval timers 
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
        Dim acP As Physics
        Dim ACLastRead As DateTime, ACLastSpeedKmh As Single, ACLastAccG1 As Single

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
                acP = AC.ReadPhysics()
                If acP.SpeedKmh <> ACLastSpeedKmh Then ACLastRead = Now
                ACLastSpeedKmh = acP.SpeedKmh
                If Now.Subtract(ACLastRead).TotalSeconds > 0 Then ' more then 1 second with the same readings means AC is dead
                    State = "DEAD"
                    ACstopped = True
                End If
            End If
        End If

        Dim tmpFrm As frmSetupAC = SetupForm()
        If ACstopped Then
            ACS.MaxRpm = 0 ' using  acS.MaxRpm=0  as a flag to indicate AC was not running
            acP = New Physics ' to clear all acp
            If tmpFrm IsNot Nothing Then Int32.TryParse(tmpFrm.lbACSpeed.Text, acP.SpeedKmh) ' if not connected to AC, user can input data to simulate AC
            Dim AccG(2) As Single : acP.AccG = AccG
            Dim WheelSlip(3) As Single : acP.WheelSlip = WheelSlip
        ElseIf ACS.MaxRpm = 0 Then ' if AC just started or restarted:
            ACS = AC.ReadStaticInfo
            State = ACS.ACVersion & "   " & ACS.CarModel & "   " & ACS.Track & "   " & ACS.TrackConfiguration
            If tmpFrm IsNot Nothing Then tmpFrm.lbMaxRPM.Text = ACS.MaxRpm
        End If

        ' Set Output :
        res.Pitch = acP.Pitch * Me.Pitch + acP.AccG(2) * Me.Accel ' (acP.AccG(2) ^ 2 * Math.Sign(acP.AccG(2)) + acP.AccG(2) * 0.4) / 2 * Me.Accel ' everything in Radians
        res.Roll = -acP.Roll * Me.Roll + acP.AccG(0) * Me.Turn ' (acP.AccG(0) ^ 2 * Math.Sign(acP.AccG(0)) + acP.AccG(0) * 0.4) / 2 * Me.Turn ' everything in Radians
        res.Wind = FFWind(SpeedKmh:=acP.SpeedKmh, pAccG1:=acP.AccG(1), pACLastAccG1:=ACLastAccG1)
        res.Shake = FFShake(pAccG1:=acP.AccG(1), pACLastAccG1:=ACLastAccG1)
        ACLastAccG1 = acP.AccG(1)
        res.LedTop = Math.Min(acP.WheelSlip(0), acP.WheelSlip(1)) > Me.Slip
        res.LedBottom = Math.Min(acP.WheelSlip(2), acP.WheelSlip(3)) > Me.Slip
        res.LedLeft = acP.Rpms < ACS.MaxRpm * Me.Rpm1
        res.LedRight = acP.Rpms > ACS.MaxRpm * Me.Rpm2
        ACLastAccG1 = acP.AccG(1)

        '' show raw AC data on screen:
        If tmpFrm IsNot Nothing AndAlso tmpFrm.WindowState <> FormWindowState.Minimized Then
            tmpFrm.lbACSpeed.Text = acP.SpeedKmh
            tmpFrm.lbACRPM.Text = acP.Rpms
            tmpFrm.lbACSlipFront.Text = Math.Min(acP.WheelSlip(0), acP.WheelSlip(1))
            tmpFrm.lbACSlipBack.Text = Math.Min(acP.WheelSlip(2), acP.WheelSlip(3))
            tmpFrm.lbACJump.Text = acP.AccG(1).ToString("0.0") & "G"
            tmpFrm.lbACAccel.Text = acP.AccG(2).ToString("0.0") & "G"
            tmpFrm.lbACTurn.Text = acP.AccG(0).ToString("0.0") & "G"
            tmpFrm.lbACPitch.Text = (acP.Pitch * 57.29).ToString("0.0") & "º"
            tmpFrm.lbACRoll.Text = (acP.Roll * 57.29).ToString("0.0") & "º"
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

    Private Function FFWind(SpeedKmh As Single, pAccG1 As Single, pACLastAccG1 As Single) As Integer
        Dim res As Integer = If(SpeedKmh > Me.MinSpeed, SpeedKmh / Me.MaxSpeed, 0) + (pAccG1 - pACLastAccG1) / Me.SpeedMaxJump * 255 ' typical 0~255, but can get to something like -2000~2000
        If graph IsNot Nothing Then graph.UpdateWind(res)
        Return res
    End Function

    Private Function FFShake(pAccG1 As Single, pACLastAccG1 As Single) As Integer
        Dim res As Integer = (pAccG1 - pACLastAccG1) ^ 2 * 10 ' here its still in Gs
        If res < ShakeMinJump Then
            res = 0
        Else
            res = res / Me.ShakeMaxJump * 255 ' typical 0~255, but can get to something like 0~1000
        End If
        If graph IsNot Nothing Then graph.UpdateShake(res)
        Return res
    End Function

End Class


