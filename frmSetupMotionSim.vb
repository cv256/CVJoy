Public Class frmSetupMotionSim
    Public _FrmCVJoy As frmCVJoy, Game As GameMotionSim

    Public Sub Init(pOwner As frmCVJoy, pGame As GameMotionSim)
        Me.Owner = pOwner
        _FrmCVJoy = pOwner
        Game = pGame

        ShowFromGameSettings()
        Me.Show(pOwner)
    End Sub

    Private Sub ShowFromGameSettings()
        txtWheelSensitivity.Text = (Game.WheelSensitivity * 100).ToString("+0000;-0000")
        txtUdpPort.Text = Game.UdpPort
        UcButtons1.ShowFromGameSettings()
    End Sub

    Private Function txt_Validate(pShowMsg As Boolean) As String
        Dim res As String = ""
        res &= ValidateNumber(txtWheelSensitivity, -9999, 9999, "Wheel Sensitivity")
        res &= ValidateNumber(txtUdpPort, 0, 65535, "UDP Port")

        If Not String.IsNullOrEmpty(res) Then
            MsgBox(res)
        End If

        Return res
    End Function

    Private Function StoreToGameSettings() As Boolean
        If txt_Validate(pShowMsg:=True) > "" Then Return False
        Game.WheelSensitivity = CInt(txtWheelSensitivity.Text) / 100
        Game.UdpPort = CInt(txtUdpPort.Text)
        UcButtons1.StoreToGameSettings()
        _FrmCVJoy.UcButtons1.ShowFromGameSettings()

        Return True
    End Function

    Private Sub btDefaults_Click(sender As Object, e As EventArgs) Handles btDefaults.Click
        Game = New GameMotionSim(_FrmCVJoy)
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

End Class
