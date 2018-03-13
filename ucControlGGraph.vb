Public Class ucControlGGraph

    Private X As Integer
    Private lastAccel As Integer, lastGyro As Integer, lastGyroUsage As Integer, lastFinal As Integer
    Private Const TopBottom = 30

    Public Sub UpdateValue(Accel As Single, Gyro As Single, GyroUsage As Single, Final As Single)
        Dim MainCenter As Integer = Me.Height / 2
        Using g As Graphics = Me.CreateGraphics
            If X Mod 8 = 0 Then ' draw reference dotted lines :
                g.DrawLine(Drawing.Pens.Gray, X, TopBottom, X + 1, TopBottom)
                g.DrawLine(Drawing.Pens.Gray, X, MainCenter, X + 1, MainCenter)
            End If
            ' GyroUsage:
            Dim y As Integer = TopBottom - GyroUsage * TopBottom
            g.DrawLine(Drawing.Pens.White, X - 1, lastGyroUsage, X, y)
            lastGyroUsage = y
            ' Accel:
            Dim degree2screen As Single = (My.Settings.MaxPitch * 1.3) / MainCenter
            If degree2screen = 0 Then Return
            y = MainCenter - Accel / degree2screen
            g.DrawLine(Drawing.Pens.Green, X - 1, lastAccel, X, y)
            lastAccel = y
            'Gryo:
            y = MainCenter - Gyro / degree2screen
            g.DrawLine(Drawing.Pens.Red, X - 1, lastGyro, X, y)
            lastGyro = y
            'Final:
            y = MainCenter - Final / degree2screen
            g.DrawLine(Drawing.Pens.White, X - 1, lastFinal, X, y)
            lastFinal = y
        End Using
        X += 1
        If X > Me.Width Then btReset.PerformClick()
    End Sub

    Private Sub btReset_Click(sender As Object, e As EventArgs) Handles btReset.Click
        Using g As Graphics = Me.CreateGraphics
            g.Clear(Me.BackColor)
        End Using
        X = 0
    End Sub

End Class
