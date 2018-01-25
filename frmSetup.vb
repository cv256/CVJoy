Public Class frmSetup
    Private _FrmCVJoy As frmCVJoy
    Private mouses As List(Of Integer)

    Public Sub Init(pOwner As frmCVJoy)
        Me.Owner = pOwner
        _FrmCVJoy = pOwner

        mouses = MouseRaw.GetMouses
        For n As Integer = 0 To mouses.Count - 1
            cbMouse.Items.Add($"Mouse {n + 1}   ({mouses(n)})")
            If mouses(n) = My.Settings.MouseSteering Then cbMouse.SelectedIndex = n
        Next

        cbComPort.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames())
        cbComPort.SelectedValue = My.Settings.ComPort
        If cbComPort.SelectedIndex = -1 AndAlso cbComPort.Items.Count = 1 Then cbComPort.SelectedIndex = 0

        For n As Integer = 1 To 16 : cbVjoy.Items.Add(n) : Next
        cbVjoy.SelectedIndex = My.Settings.vJoyId - 1
        If cbVjoy.SelectedIndex = -1 Then cbVjoy.SelectedIndex = 0

        ShowSettings()

        'Me.TopMost = True
        Me.Show(pOwner)
    End Sub

    Private Sub ShowSettings()
        txtFreq.Text = My.Settings.RefreshRate
        txtGyroMaxDegrees.Text = My.Settings.GyroMaxDegreesPerTimerClick.ToString("0.0")
        txtMaxPitch.Text = My.Settings.MaxPitch
        txtMaxRoll.Text = My.Settings.MaxRoll
        txtPitchHysteria.Text = My.Settings.PitchHysteria.ToString("0.0")
        txtRollHysteria.Text = My.Settings.RollHysteria.ToString("0.0")
        txtPitchOffset.Text = My.Settings.PitchOffset.ToString("+00.0;-00.0")
        txtRollOffset.Text = My.Settings.RollOffset.ToString("+00.0;-00.0")
        txtPitchPowerForMin.Text = My.Settings.PitchPowerForMin
        txtPitchPowerForMax.Text = My.Settings.PitchPowerForMax
        txtRollPowerForMin.Text = My.Settings.RollPowerForMin
        txtRollPowerForMax.Text = My.Settings.RollPowerForMax
        txtAccelMin.Text = My.Settings.AccelMin
        txtAccelMax.Text = My.Settings.AccelMax
        txtBrakeMin.Text = My.Settings.BrakeMin
        txtBrakeMax.Text = My.Settings.BrakeMax
        txtClutchMin.Text = My.Settings.ClutchMin
        txtClutchMax.Text = My.Settings.ClutchMax
        txtWheelFriction.Text = My.Settings.WheelFriction
        txtWheelInertia.Text = My.Settings.WheelInertia
        txtSpeedGama.Text = My.Settings.SpeedGama
        txtWheelPowerGama.Text = My.Settings.WheelPowerGama
        txtSpeedMin.Text = My.Settings.SpeedMin
        txtWheelPowerForMin.Text = My.Settings.WheelPowerForMin
        txtWheelPowerFactor.Text = My.Settings.WheelPowerFactor.ToString("0.00")
        txtWheelDampFactor.Text = My.Settings.WheelDampFactor.ToString("+0000;-0000")
        txtWheelSensitivity.Text = (My.Settings.WheelSensitivity * 100).ToString("+0000;-0000")
        txtWheelDead.Text = My.Settings.WheelDead
    End Sub

    Private Function txt_Validate() As String
        Dim res As String = ""
        res &= ValidateNumber(txtFreq, 11, 80, "Refresh Rate")
        res &= ValidateNumber(txtGyroMaxDegrees, 0.1, 2, "Gyroscope Max Degrees per Timer click:")
        res &= ValidateNumber(txtMaxPitch, 0, 90, "Max Pitch")
        res &= ValidateNumber(txtMaxRoll, 0, 90, "Max Roll")
        res &= ValidateNumber(txtPitchHysteria, 0, 10, "Pitch Hysteria")
        res &= ValidateNumber(txtRollHysteria, 0, 10, "Roll Hysteria")
        res &= ValidateNumber(txtPitchOffset, -90, 90, "Pitch Offfset")
        res &= ValidateNumber(txtRollOffset, -90, 90, "Roll Offfset")
        res &= ValidateNumber(txtPitchPowerForMin, 0, 127, "Pitch Power For Min")
        res &= ValidateNumber(txtPitchPowerForMax, 0, 600, "Pitch Power For Max")
        res &= ValidateNumber(txtRollPowerForMin, 0, 127, "Roll Power For Min")
        res &= ValidateNumber(txtRollPowerForMax, 0, 600, "Roll Power For Max")
        res &= ValidateNumber(txtAccelMin, 0, 1023, "Accelerator Min")
        res &= ValidateNumber(txtAccelMax, 0, 1023, "Accelerator Max")
        res &= ValidateNumber(txtBrakeMin, 0, 1023, "Brake Min")
        res &= ValidateNumber(txtBrakeMax, 0, 1023, "Brake Max")
        res &= ValidateNumber(txtClutchMin, 0, 1023, "Clutch Min")
        res &= ValidateNumber(txtClutchMax, 0, 1023, "Clutch Max")
        res &= ValidateNumber(txtWheelSensitivity, -9999, 9999, "Wheel Sensitivity (when using mouse)")
        res &= ValidateNumber(txtWheelDead, 0, 9999, "Wheel Dead Band")
        res &= ValidateNumber(txtWheelDampFactor, -9999, 9999, "Wheel FF Damp Factor")
        res &= ValidateNumber(txtWheelFriction, 0, 9999, "Wheel Friction")
        res &= ValidateNumber(txtWheelInertia, 0, 500, "Wheel Inertia")
        res &= ValidateNumber(txtSpeedGama, 0, 800, "Speed (wind) Power Gama")
        res &= ValidateNumber(txtWheelPowerGama, 0, 800, "Wheel FF Power Gama")
        res &= ValidateNumber(txtWheelPowerFactor, 0.5, 3, "Wheel FF Power Factor")
        res &= ValidateNumber(txtSpeedMin, 0, 255, "Speed Power For Min")
        res &= ValidateNumber(txtWheelPowerForMin, 0, 255, "Wheel FF Power For Min")

        If Math.Abs(CInt(txtPitchPowerForMax.Text)) <= Math.Abs(CInt(txtPitchPowerForMin.Text)) Then res &= "Pitch Max cant be less than Min" & vbCrLf
        If Math.Abs(CInt(txtRollPowerForMax.Text)) <= Math.Abs(CInt(txtRollPowerForMin.Text)) Then res &= "Roll Max cant be less than Min" & vbCrLf
        If CInt(txtAccelMax.Text) <= CInt(txtAccelMin.Text) Then res &= "Accelerator Max cant be less than Min" & vbCrLf
        If CInt(txtBrakeMax.Text) <= CInt(txtBrakeMin.Text) Then res &= "Brake Max cant be less than Min" & vbCrLf
        If CInt(txtClutchMax.Text) <= CInt(txtClutchMin.Text) Then res &= "Clutch Max cant be less than Min" & vbCrLf

        If Not String.IsNullOrEmpty(res) Then
            MsgBox(res)
        End If
        Return res
    End Function

    Private Sub btClose_Click(sender As Object, e As EventArgs) Handles btClose.Click
        If txt_Validate() > "" Then Return
        If cbComPort.SelectedIndex >= 0 Then My.Settings.ComPort = cbComPort.SelectedItem
        If cbVjoy.SelectedIndex >= 0 Then My.Settings.vJoyId = cbVjoy.SelectedItem
        My.Settings.RefreshRate = txtFreq.Text
        My.Settings.PitchPowerForMin = txtPitchPowerForMin.Text
        My.Settings.PitchPowerForMax = txtPitchPowerForMax.Text
        My.Settings.RollPowerForMin = txtRollPowerForMin.Text
        My.Settings.RollPowerForMax = txtRollPowerForMax.Text
        My.Settings.AccelMin = txtAccelMin.Text
        My.Settings.AccelMax = txtAccelMax.Text
        My.Settings.BrakeMin = txtBrakeMin.Text
        My.Settings.BrakeMax = txtBrakeMax.Text
        My.Settings.ClutchMin = txtClutchMin.Text
        My.Settings.ClutchMax = txtClutchMax.Text
        My.Settings.WheelSensitivity = CInt(txtWheelSensitivity.Text) / 100
        My.Settings.WheelDead = txtWheelDead.Text
        My.Settings.WheelDampFactor = txtWheelDampFactor.Text
        My.Settings.WheelFriction = txtWheelFriction.Text
        My.Settings.WheelInertia = txtWheelInertia.Text
        My.Settings.SpeedGama = txtSpeedGama.Text
        My.Settings.WheelPowerGama = txtWheelPowerGama.Text
        My.Settings.WheelPowerFactor = txtWheelPowerFactor.Text
        My.Settings.SpeedMin = txtSpeedMin.Text
        My.Settings.WheelPowerForMin = txtWheelPowerForMin.Text
        My.Settings.GyroMaxDegreesPerTimerClick = txtGyroMaxDegrees.Text.Replace("º", "")
        My.Settings.MaxPitch = txtMaxPitch.Text.Replace("º", "")
        My.Settings.MaxRoll = txtMaxRoll.Text.Replace("º", "")
        My.Settings.PitchHysteria = txtPitchHysteria.Text.Replace("º", "")
        My.Settings.RollHysteria = txtRollHysteria.Text.Replace("º", "")
        My.Settings.PitchOffset = txtPitchOffset.Text.Replace("º", "")
        My.Settings.RollOffset = txtRollOffset.Text.Replace("º", "")
        If cbMouse.SelectedIndex >= 0 Then
            My.Settings.MouseSteering = mouses(cbMouse.SelectedIndex)
        Else
            My.Settings.MouseSteering = 0
        End If
        My.Settings.Save()
        SetKSpeedGama() ' everytime My.Settings.SpeedGama  changes we must call Sub SetKSpeedGama. This is a mathematic optimization

        _FrmCVJoy.Timer1.Interval = 1000 / My.Settings.RefreshRate

        Me.Close()
    End Sub


    Private Sub btTest_MouseDown(sender As Object, e As MouseEventArgs) Handles btTest1.MouseDown, btTest2.MouseDown, btTest3.MouseDown, btTest4.MouseDown, btTest5.MouseDown, btTest6.MouseDown, btTestSpeed.MouseDown
        If txt_Validate() > "" Then Return
        With CType(Me.Owner, frmCVJoy)
            If sender.Equals(btTest1) OrElse sender.Equals(btTest2) Then
                .TestValue = CInt(txtWheelPowerForMin.Text) * If(sender.Equals(btTest1), -1, 1)
                .TestMode = frmCVJoy.Motor.Wheel
            ElseIf sender.Equals(btTest3) OrElse sender.Equals(btTest4) Then
                .TestValue = CInt(txtPitchPowerForMin.Text) * If(sender.Equals(btTest3), -1, 1)
                .TestMode = frmCVJoy.Motor.Pitch
            ElseIf sender.Equals(btTest5) OrElse sender.Equals(btTest6) Then
                .TestValue = CInt(txtRollPowerForMin.Text) * If(sender.Equals(btTest5), -1, 1)
                .TestMode = frmCVJoy.Motor.Roll
            ElseIf sender.Equals(btTestspeed) Then
                .TestValue = CInt(txtSpeedMin.Text)
                .TestMode = frmCVJoy.Motor.Wind
            End If
        End With
    End Sub
    Private Sub btTest_MouseUp(sender As Object, e As MouseEventArgs) Handles btTest1.MouseUp, btTest2.MouseUp, btTest3.MouseUp, btTest4.MouseUp, btTest5.MouseUp, btTest6.MouseUp, Me.MouseUp, btTestSpeed.MouseUp
        CType(Me.Owner, frmCVJoy).TestMode = frmCVJoy.Motor.None
    End Sub

    Private Sub btDefaults_Click(sender As Object, e As EventArgs) Handles btDefaults.Click
        My.Settings.Reset()
        SetKSpeedGama() ' everytime My.Settings.SpeedGama  changes we must call Sub SetKSpeedGama. This is a mathematic optimization
        ShowSettings()
    End Sub


    'Private Sub txtFFConst_Scroll(sender As Object, e As EventArgs)
    '    _FrmCVJoy.FFWheel_Const.Magnitude = txtFFConst.Value
    'End Sub

End Class