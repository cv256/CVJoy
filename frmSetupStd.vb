Public Class frmSetupStd
    Public _FrmCVJoy As frmCVJoy, Game As GameStd

    Public Sub Init(pOwner As frmCVJoy, pGame As GameStd)
        Me.Owner = pOwner
        _FrmCVJoy = pOwner
        Game = pGame

        ShowSettings(Game)
        Me.Show(pOwner)
    End Sub

    Private Sub ShowSettings(pGame As GameStd)
        txtWheelSensitivity.Text = (pGame.WheelSensitivity * 100).ToString("+0000;-0000")
        'txtRPM1.Text = pGame.Rpm1 * 100
        'txtSpeedMinInput.Text = pGame.MinSpeed
        'txtSpeedMaxJump.Text = pGame.SpeedMaxJump.ToString("+0.0;-0.0")
        'txtTurn.Text = (pGame.Turn * 57.3).ToString("00.0")

        UcButtons1.ShowSettings()
    End Sub

    Private Function txt_Validate(pShowMsg As Boolean) As String
        Dim res As String = ""
        res &= ValidateNumber(txtWheelSensitivity, -9999, 9999, "Wheel Sensitivity")
        'res &= ValidateNumber(txtRPM1, 0, 100, "%maxRPM for turning led1 on")
        'res &= ValidateNumber(txtSpeedMaxSpeed, 0, 999, "Car Speed for max Simulator Wind")
        'res &= ValidateNumber(txtSpeedMaxJump, -9.9, 9.9, "Car Up/Down effect on Wind")
        If Not String.IsNullOrEmpty(res) Then
            MsgBox(res)
        End If
        Return res
    End Function

    Private Function UseSettings() As Boolean
        If txt_Validate(pShowMsg:=True) > "" Then Return False
        'Game.Rpm1 = txtRPM1.Text / 100
        'Game.MinSpeed = txtSpeedMinInput.Text
        'Game.SpeedMaxJump = txtSpeedMaxJump.Text.Replace("G", "")
        'Game.Turn = CDec(txtTurn.Text) / 10 / 57.3
        Game.WheelSensitivity = CInt(txtWheelSensitivity.Text) / 100
        UcButtons1.UseSettings()
        _FrmCVJoy.UcButtons1.ShowSettings()
        Return True
    End Function

    Private Sub btDefaults_Click(sender As Object, e As EventArgs) Handles btDefaults.Click
        ShowSettings(New GameStd(_FrmCVJoy))
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

    Private Sub ckKeepVisible_CheckedChanged(sender As Object, e As EventArgs)
        Me.TopMost = ckKeepVisible.Checked
    End Sub

End Class
