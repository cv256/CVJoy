Public Class ucControlGGraph

    Private X As Integer
    Private lastDesired As Integer, lastReal As Integer, lastMotorLeft As Integer, lastMotorRight As Integer

    Public Sub UpdateValue(pRealPitch As Single, pRealRoll As Single, pDesiredPitch As Single, pDesiredRoll As Single, pMotorLeft As SByte, pMotorRight As SByte)
        Dim MainCenter As Integer = Me.Height / 2
        Dim degree2screen As Single = My.Settings.MaxPitch * 1.3 / MainCenter
        If degree2screen = 0 Then Return
        Using g As Graphics = Me.CreateGraphics
            ' clear a small column in front of x:
            g.DrawLine(New Drawing.Pen(Me.BackColor, 1), X, 0, X + 5, Me.Height)
            If X Mod 8 = 0 Then ' draw reference dotted lines :
                g.DrawLine(Drawing.Pens.Gray, X, MainCenter, X + 1, MainCenter)
                g.DrawLine(Drawing.Pens.Gray, X, MainCenter - CInt(MainCenter / 1.3), X + 1, MainCenter - CInt(MainCenter / 1.3))
                g.DrawLine(Drawing.Pens.Gray, X, MainCenter + CInt(MainCenter / 1.3), X + 1, MainCenter + CInt(MainCenter / 1.3))
                g.DrawLine(Drawing.Pens.Gray, X, MainCenter - CInt(My.Settings.GHysteria / degree2screen), X + 1, MainCenter - CInt(My.Settings.GHysteria / degree2screen))
                g.DrawLine(Drawing.Pens.Gray, X, MainCenter + CInt(My.Settings.GHysteria / degree2screen), X + 1, MainCenter + CInt(My.Settings.GHysteria / degree2screen))
            End If
            Dim y As Integer
            'Motors:
            y = MainCenter - pMotorRight / 127 * MainCenter / 1.3
            If chkMotor.Checked Then g.DrawLine(Drawing.Pens.Red, X - 1, lastMotorRight, X, y)
            lastMotorRight = y
            y = MainCenter - pMotorLeft / 127 * MainCenter / 1.3
            If chkMotor.Checked Then g.DrawLine(Drawing.Pens.Red, X - 1, lastMotorLeft, X, y)
            lastMotorLeft = y
            'Real:
            y = MainCenter - If(rdRoll.Checked, pRealRoll, pRealPitch) / degree2screen
            If chkReal.Checked Then g.DrawLine(Drawing.Pens.White, X - 1, lastReal, X, y)
            lastReal = y
            'Desired:
            y = MainCenter - If(rdRoll.Checked, pDesiredRoll, pDesiredPitch) / degree2screen
            If chkDesired.Checked Then g.DrawLine(Drawing.Pens.Green, X - 1, lastDesired, X, y)
            lastDesired = y
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
