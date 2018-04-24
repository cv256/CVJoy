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
        txtMaxSpeed.Text = pGame.MaxSpeed
        txtSlip.Text = pGame.Slip
        txtPitch.Text = pGame.Pitch * 100
        txtRoll.Text = pGame.Roll * 100
        txtJump.Text = pGame.Jump.ToString("+0.0;-0.0")
        txtAccel.Text = (pGame.Accel * 57.3).ToString("00.0")
        txtTurn.Text = (pGame.Turn * 57.3).ToString("00.0")
        UcButtons1.ShowSettings(pGame)
    End Sub

    Private Function txt_Validate(pShowMsg As Boolean) As String
        Dim res As String = ""
        res &= ValidateNumber(txtRPM1, 0, 100, "%maxRPM for turning led1 on")
        res &= ValidateNumber(txtRPM2, 0, 100, "%maxRPM for turning led2 on")
        res &= ValidateNumber(txtMaxSpeed, 0, 999, "Car Speed for max Simulator Wind")
        res &= ValidateNumber(txtSlip, 0, 200, "Slip for turning led on")
        res &= ValidateNumber(txtPitch, -300, 300, "Car Pitch effect on Simulator Pitch")
        res &= ValidateNumber(txtRoll, -300, 300, "Car Roll effect on Simulator Roll")
        res &= ValidateNumber(txtJump, -9.9, 9.9, "Car Up/Down effect on Wind")
        res &= ValidateNumber(txtAccel, -90, 90, "Car Acceleration effect on Simulator Pitch")
        res &= ValidateNumber(txtTurn, -90, 90, "Car Turning effect on Simulator Roll")
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
        Game.MaxSpeed = txtMaxSpeed.Text
        Game.Slip = txtSlip.Text
        Game.Pitch = txtPitch.Text / 100
        Game.Roll = txtRoll.Text / 100
        Game.Jump = txtJump.Text.Replace("G", "")
        Game.Accel = CDec(txtAccel.Text) / 10 / 57.3
        Game.Turn = CDec(txtTurn.Text) / 10 / 57.3
        UcButtons1.UseSettings()
        Return True
    End Function

    Private Sub btDefaults_Click(sender As Object, e As EventArgs) Handles btDefaults.Click
        ShowSettings(New GameAC(_FrmCVJoy))
    End Sub

    Private Sub btApply_Click(sender As Object, e As EventArgs) Handles btApply.Click
        UseSettings()
    End Sub

    Private Sub btSave_Click(sender As Object, e As EventArgs) Handles btsave.click
        If Not UseSettings() Then Return
        Game.SaveSettingstoFile()
    End Sub

    Private Sub btClose_Click(sender As Object, e As EventArgs) Handles btClose.Click
        Me.Close()
    End Sub

    Private Sub ckKeepVisible_CheckedChanged(sender As Object, e As EventArgs) Handles ckKeepVisible.CheckedChanged
        Me.TopMost = ckKeepVisible.Checked
    End Sub

End Class
