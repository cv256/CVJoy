Public Class ucControlGGraph

    Private X As Integer
    Private lastDesiredLeft As Integer, lastDesiredRight As Integer
    Private lastRealLeft As Integer, lastRealRight As Integer
    Private lastMotorLeft As Integer, lastMotorRight As Integer

    Public Sub UpdateValue(pRealLeft As Single, pRealRight As Single, pDesiredLeft As Single, pDesiredRight As Single, pMotorLeft As SByte, pMotorRight As SByte)
        Dim mm2screen As Single = Me.Height / (Math.Max(My.Settings.GMaxScrewUp, My.Settings.GMaxScrewDown) * 2 * 1.1)
        If mm2screen = 0 Then Return
        Dim mainCenter As Integer = Me.Height / 2
        Dim nowLeft As Integer, nowRight As Integer
        Using g As Graphics = Me.CreateGraphics
            ' clear a small column in front of x:
            g.DrawLine(New Drawing.Pen(Me.BackColor, 1), X, 0, X + 5, Me.Height)
            ' draw reference dotted lines :
            If X Mod 8 = 0 Then
                g.DrawLine(Drawing.Pens.Gray, X, mainCenter, X + 1, mainCenter)
                g.DrawLine(Drawing.Pens.Gray, X, mainCenter - My.Settings.GMaxScrewUp * mm2screen, X + 1, mainCenter - My.Settings.GMaxScrewUp * mm2screen)
                g.DrawLine(Drawing.Pens.Gray, X, mainCenter + My.Settings.GMaxScrewDown * mm2screen, X + 1, mainCenter + My.Settings.GMaxScrewDown * mm2screen)
                g.DrawLine(Drawing.Pens.DarkBlue, X, mainCenter - CInt(My.Settings.GMinDiff * mm2screen), X + 1, mainCenter - CInt(My.Settings.GMinDiff * mm2screen))
                g.DrawLine(Drawing.Pens.DarkBlue, X, mainCenter + CInt(My.Settings.GMinDiff * mm2screen), X + 1, mainCenter + CInt(My.Settings.GMinDiff * mm2screen))
                g.DrawLine(Drawing.Pens.DarkBlue, X, mainCenter - CInt(My.Settings.GMaxDiff * mm2screen), X + 1, mainCenter - CInt(My.Settings.GMaxDiff * mm2screen))
                g.DrawLine(Drawing.Pens.DarkBlue, X, mainCenter + CInt(My.Settings.GMaxDiff * mm2screen), X + 1, mainCenter + CInt(My.Settings.GMaxDiff * mm2screen))
            End If
            'Motors:
            nowLeft = mainCenter - pMotorLeft / 127 * mainCenter / 1.1
            nowRight = mainCenter - pMotorRight / 127 * mainCenter / 1.1
            If chkMotor.Checked Then
                If Not rdRight.Checked Then g.DrawLine(Drawing.Pens.DarkRed, X - 1, lastMotorLeft, X, nowLeft)
                If Not rdLeft.Checked Then g.DrawLine(Drawing.Pens.DarkRed, X - 1, lastMotorRight, X, nowRight)
            End If
            lastMotorLeft = nowLeft
            lastMotorRight = nowRight
            'Real:
            nowLeft = mainCenter - pRealLeft * mm2screen
            nowRight = mainCenter - pRealRight * mm2screen
            If chkReal.Checked Then
                If Not rdRight.Checked Then g.DrawLine(Drawing.Pens.White, X - 1, lastRealLeft, X, nowLeft)
                If Not rdLeft.Checked Then g.DrawLine(Drawing.Pens.White, X - 1, lastRealRight, X, nowRight)
            End If
            lastRealLeft = nowLeft
            lastRealRight = nowRight
            'Desired:
            nowLeft = mainCenter - pDesiredLeft * mm2screen
            nowRight = mainCenter - pDesiredRight * mm2screen
            If chkDesired.Checked Then
                If Not rdRight.Checked Then g.DrawLine(Drawing.Pens.Green, X - 1, lastDesiredLeft, X, nowLeft)
                If Not rdLeft.Checked Then g.DrawLine(Drawing.Pens.Green, X - 1, lastDesiredRight, X, nowRight)
            End If
            lastDesiredLeft = nowLeft
            lastDesiredRight = nowRight
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

End Class
