Imports AssettoCorsaSharedMemory

Public Class frmSetupAC
    Public Game As GameAC

    Public Sub Init(pGame As GameAC)
        Me.Owner = Module1.FrmMain
        Game = pGame

        ShowFromGameSettings()
        Me.Show(Owner)
    End Sub

    Private Sub ShowFromGameSettings()
        txtWheelSensitivity.Text = (Game.WheelSensitivity * 100).ToString("+0000;-0000")
        UcButtons1.ShowFromGameSettings()
    End Sub

    Private Function txt_Validate(pShowMsg As Boolean) As String
        Dim res As String = ""
        res &= ValidateNumber(txtWheelSensitivity, -9999, 9999, "Wheel Sensitivity")

        If Not String.IsNullOrEmpty(res) Then
            MsgBox(res)
        End If

        Return res
    End Function

    Private Function StoreToGameSettings() As Boolean
        If txt_Validate(pShowMsg:=True) > "" Then Return False
        Game.WheelSensitivity = CInt(txtWheelSensitivity.Text) / 100
        UcButtons1.StoreToGameSettings()
        Module1.FrmMain.UcButtons1.ShowFromGameSettings()

        Return True
    End Function

    Private Sub btDefaults_Click(sender As Object, e As EventArgs) Handles btDefaults.Click
        Game = New GameAC()
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

    'Public Sub ShowGameValues()
    '    lbACSpeed.Text = acP.SpeedKmh
    '    lbACRPM.Text = acP.Rpms
    '    lbACSlipFront.Text = Math.Min(acP.WheelSlip(0), acP.WheelSlip(1))
    '    lbACSlipBack.Text = Math.Min(acP.WheelSlip(2), acP.WheelSlip(3))
    '    lbACDirt.Text = If(acP.TyreDirtyLevel Is Nothing, "", acP.TyreDirtyLevel(3))
    '    lbACWear.Text = If(acP.TyreWear Is Nothing, "", acP.TyreWear(3))
    '    lbACJump.Text = acP.AccG(1).ToString("0.0") & "G"
    '    lbACAccel.Text = acP.AccG(2).ToString("0.0") & "G"
    '    lbACTurn.Text = acP.AccG(0).ToString("0.0") & "G"
    '    lbACPitch.Text = (acP.Pitch * 57.29).ToString("0.0") & "º"
    '    lbACRoll.Text = (acP.Roll * 57.29).ToString("0.0") & "º"

    '    UcACGraph1.UpdateValues(acP)
    'End Sub

End Class
