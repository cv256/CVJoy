Public Class ucControlGraph

    Public Enum eMode
        Accel
        Brake
        Clutch
    End Enum
    Public Mode As eMode

    Public Gama As Integer

    Private Sub ControlGraph_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.Clear(Me.BackColor)
        ' print tick marks:
        For n As Integer = 0 To 30
            e.Graphics.DrawLine(Drawing.Pens.Yellow, CInt(Me.Width / 30 * n), 6, CInt(Me.Width / 30 * n), 34)
        Next
        For n As Integer = 0 To 6
            e.Graphics.DrawLine(Drawing.Pens.White, CInt(Me.Width / 6 * n), 0, CInt(Me.Width / 6 * n), 40)
        Next
        ' draw gama graph:
        e.Graphics.DrawLine(Drawing.Pens.Yellow, 0, Me.Height, Me.Width, 40)
        Dim graphHeight As Integer = Me.Height - 40
        Dim lastY As Integer
        For x As Integer = 0 To Me.Width
            Dim thisY As Integer = Me.Height - (x / Me.Width) ^ (Gama / 100) * graphHeight
            e.Graphics.DrawLine(Drawing.Pens.White, x - 1, lastY, x, thisY)
            lastY = thisY
        Next
    End Sub

    Public Sub UpdateValues(AccelCorrected As Integer, BrakeCorrected As Integer, ClutchCorrected As Integer)
        Dim x As Integer
        Select Case Mode
            Case eMode.Accel
                x = AccelCorrected / 1023 * Me.Width
            Case eMode.Brake
                x = BrakeCorrected / 1023 * Me.Width
            Case eMode.Clutch
                x = ClutchCorrected / 1023 * Me.Width
        End Select
        Using g As Graphics = Me.CreateGraphics
            g.FillRectangle(Drawing.Brushes.Black, 0, 12, Me.Width, 28 - 12)
            g.DrawLine(Drawing.Pens.White, x, 12, x, 28)
        End Using
    End Sub

End Class
