Public Class ucControlGraph

    Public ParentButton As Button


    Public Sub Init(pParentButton As Button)
        ParentButton = pParentButton
    End Sub

    Private Function GetValues() As structValues
        Dim res As structValues
        With res
            .MinInput = 1
            .MinPower = 0
            .Gama = 100
            .Factor = 1
            If ParentButton Is Nothing Then Return res
            Dim frmSetup As frmSetup = ParentButton.FindForm
            If frmSetup.txt_Validate(pShowMsg:=False) > "" Then Return res
            If ParentButton Is frmSetup.btAccelGraph Then
                .Range = 1023
                Integer.TryParse(frmSetup.txtAccelGama.Text, .Gama)
            ElseIf ParentButton Is frmSetup.btBrakeGraph Then
                .Range = 1023
                Integer.TryParse(frmSetup.txtBrakeGama.Text, .Gama)
            ElseIf ParentButton Is frmSetup.btClutchGraph Then
                .Range = 1023
                Integer.TryParse(frmSetup.txtClutchGama.Text, .Gama)
            ElseIf ParentButton Is frmSetup.btWheelGraph Then
                .Range = 255
                Integer.TryParse(frmSetup.txtWheelMinInput.Text, .MinInput)
                Integer.TryParse(frmSetup.txtWheelPowerForMin.Text, .MinPower)
                Integer.TryParse(frmSetup.txtWheelPowerGama.Text, .Gama)
                Single.TryParse(frmSetup.txtWheelPowerFactor.Text, .Factor)
            ElseIf ParentButton Is frmSetup.btWindGraph Then
                .Range = 255
                Integer.TryParse(1, .MinInput) ' Game.txtSpeedMinInput.Text
                Integer.TryParse(frmSetup.txtWindMin.Text, .MinPower)
                Integer.TryParse(frmSetup.txtWindGama.Text, .Gama)
            ElseIf ParentButton Is frmSetup.btShakeGraph Then
                .Range = 255
                Integer.TryParse(1, .MinInput) ' Game.txtSpeedMinInput.Text
                Integer.TryParse(frmSetup.txtShakeMin.Text, .MinPower)
                Integer.TryParse(frmSetup.txtShakeGama.Text, .Gama)
            End If
        End With
        Return res
    End Function

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
        e.Graphics.DrawLine(Drawing.Pens.Yellow, 0, Me.Height, Me.Width, 40) ' this is the linear reference line, gamma=100, factor=1
        Dim graphHeight As Integer = Me.Height - 40
        Dim screenLastY As Integer = Me.Height
        With GetValues()
            If .Range > 0 Then
                For x As Integer = 0 To .Range '  this is the used gama line:
                    Dim y As Integer = .CalculateOutput(x)
                    Dim screenX As Integer = x / .Range * Me.Width
                    Dim screenY As Integer = Me.Height - y / .Range * graphHeight
                    e.Graphics.DrawLine(Drawing.Pens.White, screenX - 1, screenLastY, screenX, screenY)
                    screenLastY = screenY
                Next
            End If
        End With
    End Sub

    Private Sub UpdateValue(x As Integer)
        With GetValues()
            x = x / .Range * Me.Width
            Using g As Graphics = Me.CreateGraphics
                g.FillRectangle(Drawing.Brushes.Black, 0, 12, Me.Width, 28 - 12) ' clear
                g.DrawLine(Drawing.Pens.White, x, 12, x + 1, 28) ' draw current position
            End Using
        End With
    End Sub


    Public Sub UpdatePedals(fromArduino As SerialRead)
        If ParentButton Is Nothing Then Return
        Dim x As Integer
        Select Case ParentButton.Name
            Case frmSetup.btAccelGraph.Name
                If fromArduino IsNot Nothing Then x = fromArduino.pedalAccel
            Case frmSetup.btBrakeGraph.Name
                If fromArduino IsNot Nothing Then x = fromArduino.pedalBreak
            Case frmSetup.btClutchGraph.Name
                If fromArduino IsNot Nothing Then x = fromArduino.pedalClutch
            Case Else
                Return
        End Select
        UpdateValue(x)
    End Sub

    Public Sub UpdateFFWheel(FFWheel As Integer)
        If ParentButton Is Nothing Then Return
        If ParentButton.Name <> frmSetup.btWheelGraph.Name Then Return
        UpdateValue(FFWheel)
    End Sub

    Public Sub UpdateWind(FFWind As Integer)
        If ParentButton Is Nothing Then Return
        If ParentButton.Name <> frmSetup.btWindGraph.Name Then Return
        UpdateValue(FFWind)
    End Sub

    Public Sub UpdateShake(FFShake As Integer)
        If ParentButton Is Nothing Then Return
        If ParentButton.Name <> frmSetup.btShakeGraph.Name Then Return
        UpdateValue(FFShake)
    End Sub


    Public Structure structValues
        Public Range As Integer
        Public MinInput As Integer
        Public MinPower As Integer
        Public Gama As Integer
        Public Factor As Single
        Public Function CalculateOutput(pInput As Integer) As Integer
            Return Module1.CalculateOutput(pInput, Range, MinInput, MinPower, Gama, Factor)
        End Function
    End Structure

End Class
