Imports AssettoCorsaSharedMemory

Public Class frmSetupAC
    Public _FrmCVJoy As frmCVJoy, Game As GameAC

    Public Sub Init(pOwner As frmCVJoy, pGame As GameAC)
        Me.Owner = pOwner
        _FrmCVJoy = pOwner
        Game = pGame

        ShowSettings(Game)
        Me.Show(pOwner)
    End Sub

    Private Sub ShowSettings(pGame As GameAC)
        txtRPM1.Text = pGame.Rpm1 * 100
        txtRPM2.Text = pGame.Rpm2 * 100
        txtSpeedMinInput.Text = pGame.MinSpeed
        txtSpeedMaxSpeed.Text = pGame.MaxSpeed
        txtSlip.Text = pGame.Slip
        txtPitch.Text = pGame.Pitch * 100
        txtRoll.Text = pGame.Roll * 100
        txtSpeedMaxJump.Text = pGame.SpeedMaxJump.ToString("+0.0;-0.0")
        txtShakeMaxJump.Text = pGame.ShakeMaxJump.ToString("+0.0;-0.0")
        txtShakeMinJump.Text = pGame.ShakeMinJump.ToString("+0.0;-0.0")
        txtAccel.Text = (pGame.Accel * 57.3).ToString("00.0")
        txtTurn.Text = (pGame.Turn * 57.3).ToString("00.0")
        UcButtons1.ShowSettings()
    End Sub

    Private Function txt_Validate(pShowMsg As Boolean) As String
        Dim res As String = ""
        res &= ValidateNumber(txtRPM1, 0, 100, "%maxRPM for turning led1 on")
        res &= ValidateNumber(txtRPM2, 0, 100, "%maxRPM for turning led2 on")
        res &= ValidateNumber(txtSpeedMaxSpeed, 0, 999, "Car Speed for max Simulator Wind")
        res &= ValidateNumber(txtSlip, 0, 200, "Slip for turning led on")
        res &= ValidateNumber(txtPitch, -300, 300, "Car Pitch effect on Simulator Pitch")
        res &= ValidateNumber(txtRoll, -300, 300, "Car Roll effect on Simulator Roll")
        res &= ValidateNumber(txtSpeedMaxJump, -9.9, 9.9, "Car Up/Down effect on Wind")
        res &= ValidateNumber(txtShakeMaxJump, -9.9, 9.9, "Car Up/Down effect on Shake")
        'res &= ValidateNumber(txtAccel, -90, 90, "Car Acceleration effect on Simulator Pitch")
        'res &= ValidateNumber(txtTurn, -90, 90, "Car Turning effect on Simulator Roll")
        If Not String.IsNullOrEmpty(res) Then
            MsgBox(res)
        End If
        Return res
    End Function

    Private Function UseSettings() As Boolean
        If txt_Validate(pShowMsg:=True) > "" Then Return False
        Game.Rpm1 = txtRPM1.Text / 100
        Game.Rpm2 = txtRPM2.Text / 100
        Game.MinSpeed = txtSpeedMinInput.Text
        Game.MaxSpeed = txtSpeedMaxSpeed.Text
        Game.Slip = txtSlip.Text
        Game.Pitch = txtPitch.Text / 100
        Game.Roll = txtRoll.Text / 100
        Game.SpeedMaxJump = txtSpeedMaxJump.Text.Replace("G", "")
        Game.ShakeMaxJump = txtShakeMaxJump.Text.Replace("G", "")
        Game.ShakeMinJump = txtShakeMinJump.Text.Replace("G", "")
        Game.Accel = CDec(txtAccel.Text) / 10 / 57.3
        Game.Turn = CDec(txtTurn.Text) / 10 / 57.3
        UcButtons1.UseSettings()
        _FrmCVJoy.UcButtons1.ShowSettings()
        Return True
    End Function

    Private Sub btDefaults_Click(sender As Object, e As EventArgs) Handles btDefaults.Click
        ShowSettings(New GameAC(_FrmCVJoy))
    End Sub

    Private Sub btApply_Click(sender As Object, e As EventArgs) Handles btApply.Click
        UseSettings()
    End Sub

    Private Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click
        If Not UseSettings() Then Return
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
        lbACJump.Text = acP.AccG(1).ToString("0.0") & "G"
        lbACAccel.Text = acP.AccG(2).ToString("0.0") & "G"
        lbACTurn.Text = acP.AccG(0).ToString("0.0") & "G"
        lbACPitch.Text = (acP.Pitch * 57.29).ToString("0.0") & "º"
        lbACRoll.Text = (acP.Roll * 57.29).ToString("0.0") & "º"
        UcACGraph1.UpdateValues(acP)
    End Sub

End Class
