Public Class ucControlGGraph

    Private X As Integer
    Private lastDesiredLeft As Integer, lastDesiredRight As Integer
    Private lastRealLeft As Integer, lastRealRight As Integer
    Private lastOKLeft As Integer, lastOKRight As Integer
    Private lastMotorLeft As Integer, lastMotorRight As Integer

    Public Sub UpdateValue(pRealLeft As Single, pRealRight As Single, pOKLeft As Single, pOKRight As Single, pDesiredLeft As Single, pDesiredRight As Single, pMotorLeft As SByte, pMotorRight As SByte)
        If chkPause.Checked Then Return
        Dim mm2screen As Single = Me.Height / (Math.Max(SettingsMain.GMaxScrewUp, SettingsMain.GMaxScrewDown) * 2 * 1.1)
        If mm2screen = 0 Then Return
        Dim screenYCenter As Integer = Me.Height / 2
        Dim tmpLeft As Integer, tmpRight As Integer
        Using g As Graphics = Me.CreateGraphics
            ' clear a small column in front of x:
            g.DrawLine(New Drawing.Pen(Me.BackColor, 1), X, 0, X + 5, Me.Height)
            ' draw reference dotted lines :
            If X Mod 8 = 0 Then
                g.DrawLine(Drawing.Pens.Gray, X, screenYCenter, X + 1, screenYCenter)
                g.DrawLine(Drawing.Pens.Gray, X, screenYCenter - SettingsMain.GMaxScrewUp * mm2screen, X + 1, screenYCenter - SettingsMain.GMaxScrewUp * mm2screen)
                g.DrawLine(Drawing.Pens.Gray, X, screenYCenter + SettingsMain.GMaxScrewDown * mm2screen, X + 1, screenYCenter + SettingsMain.GMaxScrewDown * mm2screen)
                g.DrawLine(Drawing.Pens.Blue, X, screenYCenter - CInt(SettingsMain.GMinDiff * mm2screen), X + 1, screenYCenter - CInt(SettingsMain.GMinDiff * mm2screen))
                g.DrawLine(Drawing.Pens.Blue, X, screenYCenter + CInt(SettingsMain.GMinDiff * mm2screen), X + 1, screenYCenter + CInt(SettingsMain.GMinDiff * mm2screen))
            End If
            'Motors:
            tmpLeft = screenYCenter - pMotorLeft / 127 * screenYCenter / 1.1
            tmpRight = screenYCenter - pMotorRight / 127 * screenYCenter / 1.1
            If chkMotor.Checked Then
                If Not rdRight.Checked Then g.DrawLine(Drawing.Pens.DarkRed, X - 1, lastMotorLeft, X, tmpLeft)
                If Not rdLeft.Checked Then g.DrawLine(Drawing.Pens.DarkRed, X - 1, lastMotorRight, X, tmpRight)
            End If
            lastMotorLeft = tmpLeft
            lastMotorRight = tmpRight
            'Real:
            tmpLeft = screenYCenter - pRealLeft * mm2screen
            tmpRight = screenYCenter - pRealRight * mm2screen
            If chkReal.Checked Then
                If Not rdRight.Checked Then g.DrawLine(Drawing.Pens.White, X - 1, lastRealLeft, X, tmpLeft)
                If Not rdLeft.Checked Then g.DrawLine(Drawing.Pens.White, X - 1, lastRealRight, X, tmpRight)
            End If
            lastRealLeft = tmpLeft
            lastRealRight = tmpRight
            'Real plus Inertia:
            tmpLeft = screenYCenter - pOKLeft * mm2screen
            tmpRight = screenYCenter - pOKRight * mm2screen
            If chkCorrected.Checked Then
                If Not rdRight.Checked Then g.DrawLine(Drawing.Pens.DeepSkyBlue, X - 1, lastOKLeft, X, tmpLeft)
                If Not rdLeft.Checked Then g.DrawLine(Drawing.Pens.DeepSkyBlue, X - 1, lastOKRight, X, tmpRight)
            End If
            lastOKLeft = tmpLeft
            lastOKRight = tmpRight
            'Desired:
            tmpLeft = screenYCenter - pDesiredLeft * mm2screen
            tmpRight = screenYCenter - pDesiredRight * mm2screen
            If chkDesired.Checked Then
                If Not rdRight.Checked Then g.DrawLine(Drawing.Pens.Green, X - 1, lastDesiredLeft, X, tmpLeft)
                If Not rdLeft.Checked Then g.DrawLine(Drawing.Pens.Green, X - 1, lastDesiredRight, X, tmpRight)
            End If
            lastDesiredLeft = tmpLeft
            lastDesiredRight = tmpRight
        End Using
        lbInfo.Text = $"{CInt(pRealLeft + SettingsMain.GLeftScrewCenter) } mm  /  {CInt(pRealRight + SettingsMain.GRightScrewCenter) } mm"
        X += 1
        If X > Me.Width Then X = 0
    End Sub

    Private Sub btReset_Click(sender As Object, e As EventArgs) Handles btReset.Click
        Using g As Graphics = Me.CreateGraphics
            g.Clear(Me.BackColor)
        End Using
        X = 0
    End Sub

End Class
