Public Class frmSetup
    Public _FrmCVJoy As frmCVJoy

    Public Sub Init(pOwner As frmCVJoy)
        Me.Owner = pOwner
        _FrmCVJoy = pOwner

        cbComPort.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames())
        cbComPort.SelectedIndex = cbComPort.Items.IndexOf(SettingsMain.ArduinoComPort)
        If cbComPort.SelectedIndex = -1 AndAlso cbComPort.Items.Count = 1 Then cbComPort.SelectedIndex = 0

        cbComPort2.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames())
        cbComPort2.SelectedIndex = cbComPort2.Items.IndexOf(SettingsMain.ArduinoComPort2)

        For n As Integer = 1 To 16 : cbVjoy.Items.Add(n) : Next
        cbVjoy.SelectedIndex = SettingsMain.vJoyId - 1
        If cbVjoy.SelectedIndex = -1 Then cbVjoy.SelectedIndex = 0

        For Each ct As Control In Me.Controls ' to automaticaly refresh the graphs when textboxes change values
            If Not TypeOf ct Is MaskedTextBox Then Continue For
            AddHandler CType(ct, MaskedTextBox).Validating, AddressOf frmSetup_Validated
        Next

        ShowSettings()

        Me.Show(pOwner)
    End Sub

    Private Sub ShowSettings()
        txtFreq.Text = SettingsMain.RefreshRate
        txtUdpIp.Text = SettingsMain.UdpIp

        txtComBaud.Text = SettingsMain.ComBaud
        txtComBaud2.Text = SettingsMain.ComBaud2

        txtWheelMidIn.Text = SettingsMain.WheelMidIn
        txtWheelMidOut.Text = SettingsMain.WheelMidOut
        txtWheelMaxOut.Text = SettingsMain.WheelMaxOut
        txtWheelDampFactor.Text = SettingsMain.WheelDampFactor.ToString("+0000;-0000")
        txtWheelInertia.Text = SettingsMain.WheelInertia * 100

        txtAccelMin.Text = SettingsMain.AccelMin
        txtAccelMax.Text = SettingsMain.AccelMax
        txtAccelGama.Text = SettingsMain.AccelGama * 100
        txtBrakeMin.Text = SettingsMain.BrakeMin
        txtBrakeMax.Text = SettingsMain.BrakeMax
        txtBrakeGama.Text = SettingsMain.BrakeGama * 100
        txtClutchMin.Text = SettingsMain.ClutchMin
        txtClutchMax.Text = SettingsMain.ClutchMax
        txtClutchGama.Text = SettingsMain.ClutchGama * 100

        txtWindMin.Text = SettingsMain.WindMinPower
        txtWindGama.Text = SettingsMain.WindGama
        txtShakeMin.Text = SettingsMain.ShakePowerNominal
        txtShakeGama.Text = SettingsMain.ShakeGama

        txtUltrasonicGama.Text = SettingsMain.UltrasonicGama * 100
        txtLeftScrewCenter.Text = SettingsMain.GLeftScrewCenter
        txtRightScrewCenter.Text = SettingsMain.GRightScrewCenter
        txtMaxScrewUp.Text = SettingsMain.GMaxScrewUp
        txtMaxScrewDown.Text = SettingsMain.GMaxScrewDown
        txtGMinDiff.Text = SettingsMain.GMinDiff
        txtGMaxDiff.Text = SettingsMain.GMaxDiff
        txtGPowerForMin.Text = SettingsMain.GPowerForMin
        txtGZDistance.Text = SettingsMain.GZDistance
        txtGXDistance.Text = SettingsMain.GXDistance
        txtUltrasonicDamper.Text = SettingsMain.UltrasonicDamper * 100
        txtGMinMotorEfficiency.Text = SettingsMain.GMinMotorEfficiency
        txtGMaxMotorEfficiency.Text = SettingsMain.GMaxMotorEfficiency
        txtPowerInertia.Text = SettingsMain.PowerInertia * 100

        CalculateMaxAngleDown(Me, Nothing)
        CalculateMaxAngleUp(Me, Nothing)

        txtWindMinSpeed.Text = SettingsMain.WindMinSpeed
        txtWindMaxSpeed.Text = SettingsMain.WindMaxSpeed
        txtWindMaxJump.Text = SettingsMain.WindMaxJump.ToString("+0.0;-0.0")
        txtWindMaxAccel.Text = SettingsMain.WindMaxAccel.ToString("+0.0;-0.0")

        txtShakeSpeedMinInput.Text = SettingsMain.ShakeSpeedMinSpeed
        txtShakeSpeedMaxSpeed.Text = SettingsMain.ShakeSpeedMaxSpeed
        txtShakeSpeedMaxJump.Text = SettingsMain.ShakeSpeedMaxJump.ToString("+0.0;-0.0")
        txtShakeSpeedMaxAccel.Text = SettingsMain.ShakeSpeedMaxAccel.ToString("+0.0;-0.0")

        txtShakePowerMaxJump.Text = SettingsMain.ShakePowerMaxJump.ToString("+0.0;-0.0")
        txtShakePowerMaxAccel.Text = SettingsMain.ShakePowerMaxAccel.ToString("+0.0;-0.0")

        txtSlip.Text = SettingsMain.SlipMax
        txtAccel.Text = (SettingsMain.Accel * 57.3).ToString("00.0")
        txtTurn.Text = (SettingsMain.Turn * 57.3).ToString("00.0")
        txtPitch.Text = SettingsMain.Pitch * 100
        txtRoll.Text = SettingsMain.Roll * 100

    End Sub

    Public Function txt_Validate(pShowMsg As Boolean) As String
        Dim res As String = ""
        res &= ValidateNumber(txtFreq, 11, 999, "Refresh Rate")

        res &= ValidateNumber(txtWheelMidIn, 0, 255, "Wheel FF Mid Input")
        res &= ValidateNumber(txtWheelMidOut, 0, 255, "Wheel FF Mid Output")
        res &= ValidateNumber(txtWheelMaxOut, 0, 512, "Wheel FF Max Output")
        res &= ValidateNumber(txtWheelDampFactor, -9999, 9999, "Wheel FF Damp Factor")
        res &= ValidateNumber(txtWheelInertia, -100, 100, "Wheel Inertia Compensation")

        res &= ValidateNumber(txtAccelMin, 0, 1023, "Accelerator Min")
        res &= ValidateNumber(txtAccelMax, 0, 1023, "Accelerator Max")
        res &= ValidateNumber(txtAccelGama, 1, 999, "Accelerator Gama")
        res &= ValidateNumber(txtBrakeMin, 0, 1023, "Brake Min")
        res &= ValidateNumber(txtBrakeMax, 0, 1023, "Brake Max")
        res &= ValidateNumber(txtBrakeGama, 1, 999, "Brake Gama")
        res &= ValidateNumber(txtClutchMin, 0, 1023, "Clutch Min")
        res &= ValidateNumber(txtClutchMax, 0, 1023, "Clutch Max")
        res &= ValidateNumber(txtClutchGama, 1, 999, "Clutch Gama")

        res &= ValidateNumber(txtWindGama, 0, 800, "Speed Power Gama")
        res &= ValidateNumber(txtWindMin, 0, 255, "Speed Power For Min")
        res &= ValidateNumber(txtShakeGama, 0, 800, "Shake Power Gama")
        res &= ValidateNumber(txtShakeMin, 0, 255, "Shake Power For Min")

        res &= ValidateNumber(txtLeftScrewCenter, 1, 999, "Left screw distance from ground to Center position")
        res &= ValidateNumber(txtRightScrewCenter, 1, 999, "Right screw distance from ground to Center position")
        res &= ValidateNumber(txtMaxScrewUp, 1, 999, "Max Screw Up")
        res &= ValidateNumber(txtMaxScrewDown, 1, 999, "Max Screw Down")
        res &= ValidateNumber(txtGMinDiff, 1, 999, "Min.Milimeters of Difference for moving with Minimum power")
        res &= ValidateNumber(txtGMaxDiff, 1, 999, "Min.Milimeters of Difference for moving with Maximum power")
        res &= ValidateNumber(txtGPowerForMin, 0, 126, "Power For Min")
        res &= ValidateNumber(txtGZDistance, 1, 999, "Z Distance between motor and pivot, in milimeters")
        res &= ValidateNumber(txtGXDistance, 1, 999, "Half X Distance between left and right motors, in milimeters")

        If String.IsNullOrEmpty(res) Then
            If CInt(txtLeftScrewCenter.Text) <= CInt(txtMaxScrewDown.Text) Then res &= "Left screw distance from ground to Center position cant be less than Max Screw Down" & vbCrLf
            If CInt(txtRightScrewCenter.Text) <= CInt(txtMaxScrewDown.Text) Then res &= "Left screw distance from ground to Center position cant be less than Max Screw Down" & vbCrLf
            If CInt(txtGMaxDiff.Text) <= CInt(txtGMinDiff.Text) Then res &= "Difference for Power Max cant be less than Difference for Power Min" & vbCrLf
            If CInt(txtAccelMax.Text) <= CInt(txtAccelMin.Text) Then res &= "Accelerator Max cant be less than Min" & vbCrLf
            If CInt(txtBrakeMax.Text) <= CInt(txtBrakeMin.Text) Then res &= "Brake Max cant be less than Min" & vbCrLf
            If CInt(txtClutchMax.Text) <= CInt(txtClutchMin.Text) Then res &= "Clutch Max cant be less than Min" & vbCrLf
        End If

        res &= ValidateNumber(txtSlip, 0, 200, "Slip for turning led on")
        res &= ValidateNumber(txtPitch, -300, 300, "Car Pitch effect on Simulator Pitch")
        res &= ValidateNumber(txtRoll, -300, 300, "Car Roll effect on Simulator Roll")

        res &= ValidateNumber(txtWindMaxSpeed, 0, 999, "Car Speed for max Simulator Wind")
        res &= ValidateNumber(txtWindMaxJump, -9.9, 9.9, "Car Up/Down effect on Wind")

        res &= ValidateNumber(txtShakeSpeedMaxSpeed, 0, 999, "Car Speed for max Simulator Shake")
        res &= ValidateNumber(txtShakeSpeedMaxJump, -9.9, 9.9, "Car Up/Down effect on Shake")

        'res &= ValidateNumber(txtAccel, -90, 90, "Car Acceleration effect on Simulator Pitch")
        'res &= ValidateNumber(txtTurn, -90, 90, "Car Turning effect on Simulator Roll")

        If Not String.IsNullOrEmpty(res) Then
            MsgBox(res)
        End If
        Return res
    End Function

    Private Function SaveSettings() As Boolean
        If txt_Validate(pShowMsg:=True) > "" Then Return False
        If cbComPort.SelectedIndex >= 0 Then SettingsMain.ArduinoComPort = cbComPort.SelectedItem
        If cbComPort2.SelectedIndex >= 0 Then SettingsMain.ArduinoComPort2 = cbComPort2.SelectedItem
        If cbVjoy.SelectedIndex >= 0 Then SettingsMain.vJoyId = cbVjoy.SelectedItem
        SettingsMain.RefreshRate = txtFreq.Text
        SettingsMain.UdpIp = txtUdpIp.Text.Replace(",", ".")
        SettingsMain.ComBaud = txtComBaud.Text
        SettingsMain.ComBaud2 = txtComBaud2.Text

        SettingsMain.WheelMidIn = txtWheelMidIn.Text
        SettingsMain.WheelMidOut = txtWheelMidOut.Text
        SettingsMain.WheelMaxOut = txtWheelMaxOut.Text
        SettingsMain.WheelDampFactor = txtWheelDampFactor.Text
        SettingsMain.WheelInertia = CInt(txtWheelInertia.Text) / 100

        SettingsMain.AccelMin = txtAccelMin.Text
        SettingsMain.AccelMax = txtAccelMax.Text
        SettingsMain.AccelGama = CInt(txtAccelGama.Text) / 100
        SettingsMain.BrakeMin = txtBrakeMin.Text
        SettingsMain.BrakeMax = txtBrakeMax.Text
        SettingsMain.BrakeGama = CInt(txtBrakeGama.Text) / 100
        SettingsMain.ClutchMin = txtClutchMin.Text
        SettingsMain.ClutchMax = txtClutchMax.Text
        SettingsMain.ClutchGama = CInt(txtClutchGama.Text) / 100

        SettingsMain.WindGama = txtWindGama.Text
        SettingsMain.WindMinPower = txtWindMin.Text
        SettingsMain.ShakeGama = txtShakeGama.Text
        SettingsMain.ShakePowerNominal = txtShakeMin.Text

        SettingsMain.UltrasonicGama = CInt(txtUltrasonicGama.Text) / 100
        SettingsMain.GLeftScrewCenter = txtLeftScrewCenter.Text
        SettingsMain.GRightScrewCenter = txtRightScrewCenter.Text
        SettingsMain.GMaxScrewUp = txtMaxScrewUp.Text
        SettingsMain.GMaxScrewDown = txtMaxScrewDown.Text
        SettingsMain.GMinDiff = txtGMinDiff.Text
        SettingsMain.GMaxDiff = txtGMaxDiff.Text
        SettingsMain.GPowerForMin = txtGPowerForMin.Text
        SettingsMain.GZDistance = txtGZDistance.Text
        SettingsMain.GXDistance = txtGXDistance.Text
        SettingsMain.UltrasonicDamper = CInt(txtUltrasonicDamper.Text) / 100
        SettingsMain.GMaxMotorEfficiency = CInt(txtGMaxMotorEfficiency.Text)
        SettingsMain.GMinMotorEfficiency = CInt(txtGMinMotorEfficiency.Text)
        SettingsMain.PowerInertia = CInt(txtPowerInertia.text) / 100
        SettingsMain.SlipMax = txtSlip.Text
        SettingsMain.Pitch = txtPitch.Text / 100
        SettingsMain.Roll = txtRoll.Text / 100

        SettingsMain.WindMinSpeed = txtWindMinSpeed.Text
        SettingsMain.WindMaxSpeed = txtWindMaxSpeed.Text
        SettingsMain.WindMaxJump = txtWindMaxJump.Text.Replace("G", "")
        SettingsMain.WindMaxAccel = txtWindMaxAccel.Text.Replace("G", "")

        SettingsMain.ShakeSpeedMinSpeed = txtShakeSpeedMinInput.Text
        SettingsMain.ShakeSpeedMaxSpeed = txtShakeSpeedMaxSpeed.Text
        SettingsMain.ShakeSpeedMaxJump = txtShakeSpeedMaxJump.Text.Replace("G", "")
        SettingsMain.ShakeSpeedMaxAccel = txtShakeSpeedMaxAccel.Text.Replace("G", "")

        SettingsMain.ShakePowerMaxJump = txtShakePowerMaxJump.Text.Replace("G", "")
        SettingsMain.ShakePowerMaxAccel = txtShakePowerMaxAccel.Text.Replace("G", "")

        SettingsMain.Accel = CDec(txtAccel.Text) / 10 / 57.3
        SettingsMain.Turn = CDec(txtTurn.Text) / 10 / 57.3

        SettingsMain.SaveSettingstoFile()

        '_FrmCVJoy.TimerSendToArduino.Interval = 1000 / SettingsMain.RefreshRate '  the accuracy of the System.Timers.Timer is only 30Hz
        Return True
    End Function

    Private Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click
        If Not SaveSettings() Then Return
    End Sub

    Private Sub btClose_Click(sender As Object, e As EventArgs) Handles btClose.Click
        Me.Close()
    End Sub



    Private Sub btTest_MouseDown(sender As Object, e As MouseEventArgs) Handles _
            btTestWheelLeft.MouseDown, btTestWheelRight.MouseDown, btTestWheelCenter.MouseDown, btTestWind.MouseDown, btTestShake.MouseDown
        If txt_Validate(pShowMsg:=True) > "" Then Return
        With CType(Me.Owner, frmCVJoy)
            If sender.Equals(btTestWheelLeft) OrElse sender.Equals(btTestWheelRight) OrElse sender.Equals(btTestWheelCenter) Then
                .TestValue = CInt(txtWheelMidIn.Text) * If(sender.Equals(btTestWheelRight), -1, 1)
                .TestMode = If(sender.Equals(btTestWheelCenter), frmCVJoy.enumTestMode.WheelCenter, frmCVJoy.enumTestMode.Wheel)
            ElseIf sender.Equals(btTestWind) Then
                .TestValue = CInt(txtWindMin.Text)
                .TestMode = frmCVJoy.enumTestMode.Wind
            ElseIf sender.Equals(btTestShake) Then
                .TestValue = CInt(txtShakeMin.Text)
                .TestMode = frmCVJoy.enumTestMode.Shake
            End If
        End With
    End Sub
    Private Sub btGTest_MouseDown(sender As Object, e As MouseEventArgs) Handles _
             btTestGDown.MouseDown, btTestGUp.MouseDown, btTestGLeft.MouseDown, btTestGRight.MouseDown _
            , btTestGLeftDown.MouseDown, btTestGLeftUp.MouseDown, btTestGRightDown.MouseDown, btTestGRightUp.MouseDown
        If txt_Validate(pShowMsg:=True) > "" Then Return
        Dim msg As String = ValidateNumber(txtGTestDiff, 0, 99, "if you want to test, enter a difference in millimeters")
        If Not String.IsNullOrEmpty(msg) Then
            MsgBox(msg)
            Return
        End If

        With CType(Me.Owner, frmCVJoy)
            If sender.Equals(btTestGDown) OrElse sender.Equals(btTestGUp) Then
                .TestValue = CInt(txtGTestDiff.Text) * If(sender.Equals(btTestGDown), 1, -1)
                .TestMode = frmCVJoy.enumTestMode.Pitch
            ElseIf sender.Equals(btTestGLeft) OrElse sender.Equals(btTestGRight) Then
                .TestValue = CInt(txtGTestDiff.Text) * If(sender.Equals(btTestGLeft), -1, 1)
                .TestMode = frmCVJoy.enumTestMode.Roll
            ElseIf sender.Equals(btTestGLeftDown) OrElse sender.Equals(btTestGLeftUp) Then
                .TestValue = CInt(txtGTestDiff.Text) * If(sender.Equals(btTestGLeftDown), 1, -1)
                .TestMode = frmCVJoy.enumTestMode.Left
            ElseIf sender.Equals(btTestGRightDown) OrElse sender.Equals(btTestGRightUp) Then
                .TestValue = CInt(txtGTestDiff.Text) * If(sender.Equals(btTestGRightDown), 1, -1)
                .TestMode = frmCVJoy.enumTestMode.Right
            End If
        End With
    End Sub
    Private Sub btTest_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp, Me.MouseMove, UcControlGGraph1.MouseMove, UcControlGraph1.MouseMove _
        , btTestWheelLeft.MouseUp, btTestWheelRight.MouseUp, btTestWheelCenter.MouseUp _
        , btTestGDown.MouseUp, btTestGUp.MouseUp, btTestGLeft.MouseUp, btTestGRight.MouseUp _
        , btTestGLeftDown.MouseUp, btTestGLeftUp.MouseUp, btTestGRightDown.MouseUp, btTestGRightUp.MouseUp _
        , btTestWind.MouseUp, btTestShake.MouseUp
        CType(Me.Owner, frmCVJoy).TestMode = frmCVJoy.enumTestMode.None
    End Sub

    Private Sub btDefaults_Click(sender As Object, e As EventArgs) Handles btDefaults.Click
        SettingsMain = New clSettingsMain
        ShowSettings()
    End Sub

    Private Sub btGraph_Click(sender As Object, e As EventArgs) Handles btAccelGraph.Click, btBrakeGraph.Click, btClutchGraph.Click, btWheelGraph.Click, btWindGraph.Click, btShakeSpeedGraph.Click, btShakePowerGraph.Click, btGGraph.Click
        If graph IsNot Nothing OrElse Ggraph IsNot Nothing Then
            graph = Nothing ' stop updating graph data from frmMain
            Ggraph = Nothing ' stop updating graph data from frmMain
            UcControlGGraph1.Visible = False
            UcControlGraph1.Visible = False
        Else
            If sender.Equals(btGGraph) Then
                UcControlGGraph1.Height = txtGTestDiff.Top
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


    Private Sub CalculateMaxAngleDown(sender As Object, e As EventArgs) Handles txtGZDistance.Leave, txtMaxScrewUp.Leave
        Try
            lbMaxScrewUp.Text = $"mm {(90 - Math.Atan2(CInt(txtGZDistance.Text), CInt(txtMaxScrewUp.Text)) * 57.296).ToString("0")}ºDown"
        Catch ex As Exception
            lbMaxScrewUp.Text = "mm"
        End Try
    End Sub
    Private Sub CalculateMaxAngleUp(sender As Object, e As EventArgs) Handles txtGZDistance.Leave, txtMaxScrewDown.Leave
        Try
            lbMaxScrewDown.Text = $"mm {(90 - Math.Atan2(CInt(txtGZDistance.Text), CInt(txtMaxScrewDown.Text)) * 57.296).ToString("0")}ºUp"
        Catch ex As Exception
            lbMaxScrewDown.Text = "mm"
        End Try
    End Sub

    'Private Sub CalculateSTOP(sender As Object, e As EventArgs) Handles txtMaxScrewUp.Leave, txtMaxScrewDown.Leave, txtGMinDiff.Leave
    '    Try
    '        lbAlarm.Text = $"mm   STOP! at  {(CInt(txtMaxScrewUp.Text) + CInt(txtGMinDiff.Text)).ToString("0")}mm Up  /  {(CInt(txtMaxScrewDown.Text) + CInt(txtGMinDiff.Text)).ToString("0")}mm Down"
    '    Catch ex As Exception
    '        lbMaxScrewDown.Text = "mm"
    '    End Try
    'End Sub



    Public Sub ShowGameValues(GameOutputs As clGameOutputs, GameOutputsExtra As clGameOutputsExtra)
        lbMaxRPM.Text = GameOutputsExtra.RpmMax
        lbACSpeed.Text = GameOutputs.Speed
        lbACRPM.Text = GameOutputs.RPM
        lbACSlipFront.Text = Math.Min(GameOutputs.SlipFR, GameOutputs.SlipFL)
        lbACSlipBack.Text = Math.Min(GameOutputs.SlipRR, GameOutputs.SlipRL)
        'lbACDirt.Text = GameOutputs.TyreDirtFR  If(acP.TyreDirtyLevel Is Nothing, "", acP.TyreDirtyLevel(3))
        'lbACWear.Text = If(acP.TyreWear Is Nothing, "", acP.TyreWear(3))
        lbACJump.Text = GameOutputs.GameAccelZ.ToString("0.0") & "G"
        lbACAccel.Text = GameOutputs.Acceleration.ToString("0.0")
        lbACTurn.Text = GameOutputs.Rotation.ToString("0.0")
        lbACPitch.Text = (GameOutputs.GamePitch * 57.29).ToString("0.0") & "º"
        lbACRoll.Text = (GameOutputs.GameRoll * 57.29).ToString("0.0") & "º"
        ' TODO: podia mostrar tambem o RigPitch, RigRoll, Rig...

        'UcACGraph1.UpdateValues(acP)
    End Sub

End Class