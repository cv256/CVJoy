Imports System.ComponentModel

Public Class frmSetup
    Public _FrmCVJoy As frmCVJoy
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
        cbComPort.SelectedValue = My.Settings.ArduinoComPort
        If cbComPort.SelectedIndex = -1 AndAlso cbComPort.Items.Count = 1 Then cbComPort.SelectedIndex = 0

        For n As Integer = 1 To 16 : cbVjoy.Items.Add(n) : Next
        cbVjoy.SelectedIndex = My.Settings.vJoyId - 1
        If cbVjoy.SelectedIndex = -1 Then cbVjoy.SelectedIndex = 0

        For Each ct As Control In Me.Controls ' to automaticaly refresh the graphs when textboxes change values
            If Not TypeOf ct Is MaskedTextBox Then Continue For
            AddHandler CType(ct, MaskedTextBox).Validating, AddressOf frmSetup_Validated
        Next

        ShowSettings()

        'Me.TopMost = True
        Me.Show(pOwner)
    End Sub

    Private Sub ShowSettings()
        txtFreq.Text = My.Settings.RefreshRate

        txtWheelSensitivity.Text = (My.Settings.WheelSensitivity * 100).ToString("+0000;-0000")
        txtWheelDead.Text = My.Settings.WheelDead

        txtWheelMinInput.Text = My.Settings.WheelMinInput
        txtWheelPowerForMin.Text = My.Settings.WheelPowerForMin
        txtWheelPowerGama.Text = My.Settings.WheelPowerGama
        txtWheelPowerFactor.Text = My.Settings.WheelPowerFactor.ToString("0.00")
        txtWheelDampFactor.Text = My.Settings.WheelDampFactor.ToString("+0000;-0000")

        txtAccelMin.Text = My.Settings.AccelMin
        txtAccelMax.Text = My.Settings.AccelMax
        txtAccelGama.Text = My.Settings.AccelGama * 100
        txtBrakeMin.Text = My.Settings.BrakeMin
        txtBrakeMax.Text = My.Settings.BrakeMax
        txtBrakeGama.Text = My.Settings.BrakeGama * 100
        txtClutchMin.Text = My.Settings.ClutchMin
        txtClutchMax.Text = My.Settings.ClutchMax
        txtClutchGama.Text = My.Settings.ClutchGama * 100

        txtSpeedMinInput.Text = My.Settings.ACMinSpeed
        txtSpeedMin.Text = My.Settings.SpeedMinPower
        txtSpeedGama.Text = My.Settings.SpeedGama

        txtGyroMaxDegrees.Text = My.Settings.GyroMaxDegreesPerTimerClick.ToString("0.0")
        txtPitchOffset.Text = My.Settings.PitchOffset.ToString("+00.0;-00.0")
        txtRollOffset.Text = My.Settings.RollOffset.ToString("+00.0;-00.0")
        txtMinPitch.Text = My.Settings.MinPitch
        txtMaxPitch.Text = My.Settings.MaxPitch
        txtMaxRoll.Text = My.Settings.MaxRoll
        txtGHysteria.Text = My.Settings.GHysteria.ToString("0.0")
        txtGPowerForMin.Text = My.Settings.GPowerForMin
        txtGPowerForMax.Text = My.Settings.GPowerForMax
        txtGZDistance.Text = My.Settings.GZDistance
        txtGXDistance.Text = My.Settings.GXDistance

    End Sub

    Public Function txt_Validate(pShowMsg As Boolean) As String
        Dim res As String = ""
        res &= ValidateNumber(txtFreq, 11, 80, "Refresh Rate")

        res &= ValidateNumber(txtWheelSensitivity, -9999, 9999, "Wheel Sensitivity (when using mouse)")
        res &= ValidateNumber(txtWheelDead, 0, 9999, "Wheel Dead Band")

        res &= ValidateNumber(txtWheelMinInput, 0, 1023, "Wheel FF Min Input")
        res &= ValidateNumber(txtWheelPowerForMin, 0, 255, "Wheel FF Power For Min")
        res &= ValidateNumber(txtWheelPowerGama, 0, 800, "Wheel FF Power Gama")
        res &= ValidateNumber(txtWheelPowerFactor, 0.5, 3, "Wheel FF Power Factor")
        res &= ValidateNumber(txtWheelDampFactor, -9999, 9999, "Wheel FF Damp Factor")

        res &= ValidateNumber(txtAccelMin, 0, 1023, "Accelerator Min")
        res &= ValidateNumber(txtAccelMax, 0, 1023, "Accelerator Max")
        res &= ValidateNumber(txtAccelGama, 1, 999, "Accelerator Gama")
        res &= ValidateNumber(txtBrakeMin, 0, 1023, "Brake Min")
        res &= ValidateNumber(txtBrakeMax, 0, 1023, "Brake Max")
        res &= ValidateNumber(txtBrakeGama, 1, 999, "Brake Gama")
        res &= ValidateNumber(txtClutchMin, 0, 1023, "Clutch Min")
        res &= ValidateNumber(txtClutchMax, 0, 1023, "Clutch Max")
        res &= ValidateNumber(txtClutchGama, 1, 999, "Clutch Gama")

        res &= ValidateNumber(txtSpeedMinInput, 0, 255, "Speed Min Input")
        res &= ValidateNumber(txtSpeedGama, 0, 800, "Speed Power Gama")
        res &= ValidateNumber(txtSpeedMin, 0, 255, "Speed Power For Min")

        res &= ValidateNumber(txtGyroMaxDegrees, 0.1, 9, "Gyroscope Min Degrees per Second")
        res &= ValidateNumber(txtPitchOffset, -90, 90, "Pitch Offfset")
        res &= ValidateNumber(txtRollOffset, -90, 90, "Roll Offfset")
        res &= ValidateNumber(txtMinPitch, 0, 90, "Max Down Pitch")
        res &= ValidateNumber(txtMaxPitch, 0, 90, "Max Up Pitch")
        res &= ValidateNumber(txtMaxRoll, 0, 90, "Max Roll")
        res &= ValidateNumber(txtGHysteria, 0, 10, "Hysteria")
        res &= ValidateNumber(txtGPowerForMin, 0, 255, "Power For Min")
        res &= ValidateNumber(txtGPowerForMax, 0, 255, "Power For Max")
        res &= ValidateNumber(txtGZDistance, 1, 999, "Z Distance")
        res &= ValidateNumber(txtGXDistance, 1, 999, "X Distance")

        If String.IsNullOrEmpty(res) Then
            If Math.Abs(CInt(txtGPowerForMax.Text)) <= Math.Abs(CInt(txtGPowerForMin.Text)) Then res &= "Power Max cant be less than Power Min" & vbCrLf
            If CInt(txtAccelMax.Text) <= CInt(txtAccelMin.Text) Then res &= "Accelerator Max cant be less than Min" & vbCrLf
            If CInt(txtBrakeMax.Text) <= CInt(txtBrakeMin.Text) Then res &= "Brake Max cant be less than Min" & vbCrLf
            If CInt(txtClutchMax.Text) <= CInt(txtClutchMin.Text) Then res &= "Clutch Max cant be less than Min" & vbCrLf
        End If

        If Not String.IsNullOrEmpty(res) Then
            MsgBox(res)
        End If
        Return res
    End Function

    Private Function SaveSettings() As Boolean
        If txt_Validate(pShowMsg:=True) > "" Then Return False
        If cbComPort.SelectedIndex >= 0 Then My.Settings.ArduinoComPort = cbComPort.SelectedItem
        If cbVjoy.SelectedIndex >= 0 Then My.Settings.vJoyId = cbVjoy.SelectedItem
        If cbMouse.SelectedIndex >= 0 Then
            My.Settings.MouseSteering = mouses(cbMouse.SelectedIndex)
        Else
            My.Settings.MouseSteering = 0
        End If
        My.Settings.RefreshRate = txtFreq.Text

        My.Settings.WheelSensitivity = CInt(txtWheelSensitivity.Text) / 100
        My.Settings.WheelDead = txtWheelDead.Text

        My.Settings.WheelMinInput = txtWheelMinInput.Text
        My.Settings.WheelPowerForMin = txtWheelPowerForMin.Text
        My.Settings.WheelPowerGama = txtWheelPowerGama.Text
        My.Settings.WheelPowerFactor = txtWheelPowerFactor.Text
        My.Settings.WheelDampFactor = txtWheelDampFactor.Text

        My.Settings.AccelMin = txtAccelMin.Text
        My.Settings.AccelMax = txtAccelMax.Text
        My.Settings.AccelGama = CInt(txtAccelGama.Text) / 100
        My.Settings.BrakeMin = txtBrakeMin.Text
        My.Settings.BrakeMax = txtBrakeMax.Text
        My.Settings.BrakeGama = CInt(txtBrakeGama.Text) / 100
        My.Settings.ClutchMin = txtClutchMin.Text
        My.Settings.ClutchMax = txtClutchMax.Text
        My.Settings.ClutchGama = CInt(txtClutchGama.Text) / 100

        My.Settings.ACMinSpeed = txtSpeedMinInput.Text
        My.Settings.SpeedGama = txtSpeedGama.Text
        My.Settings.SpeedMinPower = txtSpeedMin.Text

        My.Settings.GyroMaxDegreesPerTimerClick = txtGyroMaxDegrees.Text.Replace("º", "")
        My.Settings.PitchOffset = txtPitchOffset.Text.Replace("º", "")
        My.Settings.RollOffset = txtRollOffset.Text.Replace("º", "")
        My.Settings.MinPitch = txtMinPitch.Text.Replace("º", "")
        My.Settings.MaxPitch = txtMaxPitch.Text.Replace("º", "")
        My.Settings.MaxRoll = txtMaxRoll.Text.Replace("º", "")
        My.Settings.GHysteria = txtGHysteria.Text.Replace("º", "")
        My.Settings.GPowerForMin = txtGPowerForMin.Text
        My.Settings.GPowerForMax = txtGPowerForMax.Text
        My.Settings.GZDistance = txtGZDistance.Text
        My.Settings.GZDistance = txtGXDistance.Text

        My.Settings.Save()

        _FrmCVJoy.Timer1.Interval = 1000 / My.Settings.RefreshRate
        Return True
    End Function

    Private Sub btClose_Click(sender As Object, e As EventArgs) Handles btClose.Click
        If Not SaveSettings() Then Return
        Me.Close()
    End Sub


    Private Sub btTest_MouseDown(sender As Object, e As MouseEventArgs) Handles btTestWheelLeft.MouseDown, btTestWheelRight.MouseDown, btTestGDown.MouseDown, btTestGUp.MouseDown, btTestGLeft.MouseDown, btTestGRight.MouseDown, btTestSpeed.MouseDown
        If txt_Validate(pShowMsg:=True) > "" Then Return
        With CType(Me.Owner, frmCVJoy)
            If sender.Equals(btTestWheelLeft) OrElse sender.Equals(btTestWheelRight) Then
                .TestValue = CInt(txtWheelPowerForMin.Text) * If(sender.Equals(btTestWheelLeft), 1, -1)
                .TestMode = frmCVJoy.Motor.Wheel
            ElseIf sender.Equals(btTestGDown) OrElse sender.Equals(btTestGUp) Then
                .TestValue = CInt(txtGPowerForMin.Text) * If(sender.Equals(btTestGDown), -1, 1)
                .TestMode = frmCVJoy.Motor.Pitch
            ElseIf sender.Equals(btTestGLeft) OrElse sender.Equals(btTestGRight) Then
                .TestValue = CInt(txtGPowerForMin.Text) * If(sender.Equals(btTestGLeft), -1, 1)
                .TestMode = frmCVJoy.Motor.Roll
            ElseIf sender.Equals(btTestSpeed) Then
                .TestValue = CInt(txtSpeedMin.Text)
                .TestMode = frmCVJoy.Motor.Wind
            End If
        End With
    End Sub
    Private Sub btTest_MouseUp(sender As Object, e As MouseEventArgs) Handles btTestWheelLeft.MouseUp, btTestWheelRight.MouseUp, btTestGDown.MouseUp, btTestGUp.MouseUp, btTestGLeft.MouseUp, btTestGRight.MouseUp, Me.MouseUp, btTestSpeed.MouseUp
        CType(Me.Owner, frmCVJoy).TestMode = frmCVJoy.Motor.None
    End Sub

    Private Sub btDefaults_Click(sender As Object, e As EventArgs) Handles btDefaults.Click
        My.Settings.Reset()
        ShowSettings()
    End Sub

    Private Sub btGraph_Click(sender As Object, e As EventArgs) Handles btAccelGraph.Click, btBrakeGraph.Click, btClutchGraph.Click, btWheelGraph.Click, btSpeedGraph.Click, btGGraph.Click
        If graph IsNot Nothing OrElse Ggraph IsNot Nothing Then
            graph = Nothing ' stop updating graph data from frmMain
            Ggraph = Nothing ' stop updating graph data from frmMain
            UcControlGGraph1.Visible = False
            UcControlGraph1.Visible = False
        Else
            If sender.Equals(btGGraph) Then
                UcControlGGraph1.Height = sender.top
                UcControlGGraph1.Visible = True
                Ggraph = UcControlGGraph1 ' start updating graph data from frmMain
            Else
                UcControlGraph1.Init(sender)
                UcControlGraph1.Height = Me.ClientSize.Height - sender.Bottom
                UcControlGraph1.Visible = True
                graph = UcControlGraph1 ' start updating graph data from frmMain
            End If
        End If
    End Sub

    Private Sub frmSetup_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        graph = Nothing ' stop updating graph data from frmMain
        Ggraph = Nothing ' stop updating graph data from frmMain
    End Sub

    Private Sub frmSetup_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If UcControlGraph1.Visible Then ' on resize of this form recalculate the top of  UcControlGraph1 and redraw it:
            UcControlGraph1.Visible = False
            UcControlGraph1.Height = Me.ClientSize.Height - UcControlGraph1.ParentButton.Bottom
            UcControlGraph1.Visible = True
        End If
    End Sub

    Private Sub frmSetup_Validated(sender As Object, e As EventArgs) Handles Me.Validated
        If graph IsNot Nothing Then
            graph.Invalidate()
        ElseIf Ggraph IsNot Nothing Then
            Ggraph.Invalidate()
        End If
    End Sub
End Class