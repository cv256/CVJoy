Imports AssettoCorsaSharedMemory

Public Class frmSetupAC
    Public _FrmCVJoy As frmCVJoy, Game As GameAC

    Public Sub Init(pOwner As frmCVJoy, pGame As GameAC)
        Me.Owner = pOwner
        _FrmCVJoy = pOwner
        Game = pGame

        ShowFromGameSettings()
        Me.Show(pOwner)
    End Sub

    Private Sub ShowFromGameSettings()
        txtWheelSensitivity.Text = (Game.WheelSensitivity * 100).ToString("+0000;-0000")

        txtSlip.Text = Game.SlipMax
        txtPitch.Text = Game.Pitch * 100
        txtRoll.Text = Game.Roll * 100

        txtWindMinSpeed.Text = Game.WindMinSpeed
        txtWindMaxSpeed.Text = Game.WindMaxSpeed
        txtWindMaxJump.Text = Game.WindMaxJump.ToString("+0.0;-0.0")
        txtWindMaxAccel.Text = Game.WindMaxAccel.ToString("+0.0;-0.0")

        txtShakeSpeedMinInput.Text = Game.ShakeSpeedMinSpeed
        txtShakeSpeedMaxSpeed.Text = Game.ShakeSpeedMaxSpeed
        txtShakeSpeedMaxJump.Text = Game.ShakeSpeedMaxJump.ToString("+0.0;-0.0")
        txtShakeSpeedMaxAccel.Text = Game.ShakeSpeedMaxAccel.ToString("+0.0;-0.0")

        txtShakePowerMaxJump.Text = Game.ShakePowerMaxJump.ToString("+0.0;-0.0")
        txtShakePowerMaxAccel.Text = Game.ShakePowerMaxAccel.ToString("+0.0;-0.0")

        txtAccel.Text = (Game.Accel * 57.3).ToString("00.0")
        txtTurn.Text = (Game.Turn * 57.3).ToString("00.0")

        UcButtons1.ShowFromGameSettings()
    End Sub

    Private Function txt_Validate(pShowMsg As Boolean) As String
        Dim res As String = ""
        res &= ValidateNumber(txtWheelSensitivity, -9999, 9999, "Wheel Sensitivity")
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

    Private Function StoreToGameSettings() As Boolean
        If txt_Validate(pShowMsg:=True) > "" Then Return False
        Game.WheelSensitivity = CInt(txtWheelSensitivity.Text) / 100

        Game.SlipMax = txtSlip.Text
        Game.Pitch = txtPitch.Text / 100
        Game.Roll = txtRoll.Text / 100

        Game.WindMinSpeed = txtWindMinSpeed.Text
        Game.WindMaxSpeed = txtWindMaxSpeed.Text
        Game.WindMaxJump = txtWindMaxJump.Text.Replace("G", "")
        Game.WindMaxAccel = txtWindMaxAccel.Text.Replace("G", "")

        Game.ShakeSpeedMinSpeed = txtShakeSpeedMinInput.Text
        Game.ShakeSpeedMaxSpeed = txtShakeSpeedMaxSpeed.Text
        Game.ShakeSpeedMaxJump = txtShakeSpeedMaxJump.Text.Replace("G", "")
        Game.ShakeSpeedMaxAccel = txtShakeSpeedMaxAccel.Text.Replace("G", "")

        Game.ShakePowerMaxJump = txtShakePowerMaxJump.Text.Replace("G", "")
        Game.ShakePowerMaxAccel = txtShakePowerMaxAccel.Text.Replace("G", "")

        Game.Accel = CDec(txtAccel.Text) / 10 / 57.3
        Game.Turn = CDec(txtTurn.Text) / 10 / 57.3

        UcButtons1.StoreToGameSettings()
        _FrmCVJoy.UcButtons1.ShowFromGameSettings()

        Return True
    End Function

    Private Sub btDefaults_Click(sender As Object, e As EventArgs) Handles btDefaults.Click
        Game = New GameAC(_FrmCVJoy)
        ShowFromGameSettings()
    End Sub

    Private Sub btApply_Click(sender As Object, e As EventArgs) Handles btApply.Click
        StoreToGameSettings()
    End Sub

    Private Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click
        If Not StoreToGameSettings() Then Return
        Game.SaveSettingstoFile()
    End Sub

    Private Sub btClose_Click(sender As Object, e As EventArgs) Handles btClose.Click
        Me.Close()
    End Sub

    Private Sub ckKeepVisible_CheckedChanged(sender As Object, e As EventArgs) Handles ckKeepVisible.CheckedChanged
        Me.TopMost = ckKeepVisible.Checked
    End Sub

    Public Sub UpdateACValues(acP As Physics)
        lbACSpeed.Text = acP.SpeedKmh
        lbACRPM.Text = acP.Rpms
        lbACSlipFront.Text = Math.Min(acP.WheelSlip(0), acP.WheelSlip(1))
        lbACSlipBack.Text = Math.Min(acP.WheelSlip(2), acP.WheelSlip(3))
        lbACDirt.Text = If(acP.TyreDirtyLevel Is Nothing, "", acP.TyreDirtyLevel(3))
        lbACWear.Text = If(acP.TyreWear Is Nothing, "", acP.TyreWear(3))
        lbACJump.Text = acP.AccG(1).ToString("0.0") & "G"
        lbACAccel.Text = acP.AccG(2).ToString("0.0") & "G"
        lbACTurn.Text = acP.AccG(0).ToString("0.0") & "G"
        lbACPitch.Text = (acP.Pitch * 57.29).ToString("0.0") & "º"
        lbACRoll.Text = (acP.Roll * 57.29).ToString("0.0") & "º"

        UcACGraph1.UpdateValues(acP)
    End Sub

End Class
