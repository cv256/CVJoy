Public Class ucACGraph

    Private W As Integer = 0, rangeCgHeight As Integer, rangeRideHeight As Integer, rangeSuspensionTravel As Integer, rangeWheelLoad As Integer

    Private X As Integer
    Private lastCgHeight As Integer, lastRideHeight As Integer, lastSuspensionTravel As Integer, lastWheelLoad As Integer

    Private Sub ucACGraph_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbWheel.SelectedIndex = 0
    End Sub

    Public Sub UpdateValues(acP As AssettoCorsaSharedMemory.Physics)
        If chkPause.Checked Then Return
        If acP.RideHeight Is Nothing Then Return
        Dim screenYCenter As Integer = Me.Height / 2
        Dim temp1 As Integer
        Using g As Drawing.Graphics = Me.CreateGraphics
            ' clear a small column in front of x:
            g.DrawLine(New Drawing.Pen(Me.BackColor, 1), X, 0, X + 5, Me.Height)
            ' draw reference dotted lines :
            If X Mod 8 = 0 Then
                g.DrawLine(Drawing.Pens.Gray, X, screenYCenter, X + 1, screenYCenter)
            End If
            'CgHeight:
            lbrangeCgHeight.Text = CInt(acP.CgHeight * 1000)
            temp1 = Me.Height - acP.CgHeight * 1000 / rangeCgHeight * screenYCenter
            If chkCgHeight.Checked Then
                g.DrawLine(Drawing.Pens.Green, X - 1, lastCgHeight, X, temp1)
            End If
            lastCgHeight = temp1
            'RideHeight:
            lbrangeRideHeight.Text = CInt(acP.RideHeight(If(W >= 2, 1, 0)) * 1000)
            temp1 = Me.Height - acP.RideHeight(If(W >= 2, 1, 0)) * 1000 / rangeRideHeight * screenYCenter
            If chkRideHeight.Checked Then
                g.DrawLine(Drawing.Pens.Orange, X - 1, lastRideHeight, X, temp1)
            End If
            lastRideHeight = temp1
SuspensionTravel:
            lbrangeSuspensionTravel.Text = CInt(acP.SuspensionTravel(W) * 1000)
            temp1 = screenYCenter - (acP.SuspensionTravel(W) * 1000 - CInt(txtCenter.Text)) / rangeSuspensionTravel * screenYCenter
            If chkSusTravel.Checked Then
                If X Mod 8 = 0 Then
                    g.DrawLine(Drawing.Pens.White, X, CInt(screenYCenter - CInt(txtDn.Text) / rangeSuspensionTravel * screenYCenter), X + 1, CInt(screenYCenter - CInt(txtDn.Text) / rangeSuspensionTravel * screenYCenter))
                    g.DrawLine(Drawing.Pens.White, X, CInt(screenYCenter + CInt(txtUp.Text) / rangeSuspensionTravel * screenYCenter), X + 1, CInt(screenYCenter + CInt(txtUp.Text) / rangeSuspensionTravel * screenYCenter))
                End If
                g.DrawLine(Drawing.Pens.White, X - 1, lastSuspensionTravel, X, temp1)
            End If
            lastSuspensionTravel = temp1
            'WheelLoad:
            lbrangeWheelLoad.Text = CInt(acP.WheelLoad(W) / 10)
            temp1 = Me.Height - acP.WheelLoad(W) / 10 / rangeWheelLoad * screenYCenter
            If chkWheelLoad.Checked Then
                g.DrawLine(Drawing.Pens.Magenta, X - 1, lastWheelLoad, X, temp1)
            End If
            lastWheelLoad = temp1
        End Using
        X += 1
        If X > Me.Width Then X = 0
    End Sub

    Private Sub btReset_Click(sender As Object, e As EventArgs) Handles btReset.Click
        Using g As Graphics = Me.CreateGraphics
            g.Clear(Me.BackColor)
        End Using
        X = 0
    End Sub

    Private Sub txtrangeCgHeight_TextChanged(sender As Object, e As EventArgs) Handles txtrangeCgHeight.TextChanged
        Integer.TryParse(txtrangeCgHeight.Text, rangeCgHeight)
    End Sub
    Private Sub txtrangeRideHeight_TextChanged(sender As Object, e As EventArgs) Handles txtrangeRideHeight.TextChanged
        Integer.TryParse(txtrangeRideHeight.Text, rangeRideHeight)
    End Sub
    Private Sub txtrangeSuspensionTravel_TextChanged(sender As Object, e As EventArgs) Handles txtrangeSuspensionTravel.TextChanged
        Integer.TryParse(txtrangeSuspensionTravel.Text, rangeSuspensionTravel)
    End Sub
    Private Sub txtrangeWheelLoad_TextChanged(sender As Object, e As EventArgs) Handles txtrangeWheelLoad.TextChanged
        Integer.TryParse(txtrangeWheelLoad.Text, rangeWheelLoad)
    End Sub
    Private Sub cbWheel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbWheel.SelectedIndexChanged
        If cbWheel.SelectedItem Is Nothing Then Return
        W = CInt(CStr(CStr(cbWheel.SelectedItem)(0)))
    End Sub

End Class
