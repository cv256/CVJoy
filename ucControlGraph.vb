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
            .MaxOut = 255
            .Range = 255
            If ParentButton Is Nothing Then Return res
            Dim frmSetup As frmSetup = ParentButton.FindForm

            If frmSetup.txt_Validate(pShowMsg:=False) > "" Then Return res
            If ParentButton Is frmSetup.btAccelGraph Then
                Integer.TryParse(frmSetup.txtAccelMin.Text, .MinInput)
                Integer.TryParse(frmSetup.txtAccelMax.Text, .Range)
                Integer.TryParse(frmSetup.txtAccelGama.Text, .Gama)
            ElseIf ParentButton Is frmSetup.btBrakeGraph Then
                Integer.TryParse(frmSetup.txtBrakeMin.Text, .MinInput)
                Integer.TryParse(frmSetup.txtBrakeMax.Text, .Range)
                Integer.TryParse(frmSetup.txtBrakeGama.Text, .Gama)
            ElseIf ParentButton Is frmSetup.btClutchGraph Then
                Integer.TryParse(frmSetup.txtClutchMin.Text, .MinInput)
                Integer.TryParse(frmSetup.txtClutchMax.Text, .Range)
                Integer.TryParse(frmSetup.txtClutchGama.Text, .Gama)
            ElseIf ParentButton Is frmSetup.btWheelGraph Then
                Integer.TryParse(frmSetup.txtWheelMidIn.Text, .MinInput)
                Integer.TryParse(frmSetup.txtWheelMidOut.Text, .Gama)
                Integer.TryParse(frmSetup.txtWheelMaxOut.Text, .MaxOut)
            ElseIf ParentButton Is frmSetup.btWindGraph Then
                'Integer.TryParse(Game.txtSpeedMinInput.Text, .MinInput)
                Integer.TryParse(frmSetup.txtWindMin.Text, .MinPower)
                Integer.TryParse(frmSetup.txtWindGama.Text, .Gama)
            ElseIf ParentButton Is frmSetup.btShakeSpeedGraph Then
            ElseIf ParentButton Is frmSetup.btShakePowerGraph Then
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

        If ParentButton Is Nothing Then Return

        Dim graphHeight As Integer = Me.Height - 40
        Dim screenLastY As Integer = Me.Height
        With GetValues()
            If .Range > 0 Then
                Dim frmSetup As frmSetup = ParentButton.FindForm
                Dim y As Integer
                For x As Integer = 0 To .Range '  this is the used gama line:
                    If (ParentButton Is frmSetup.btWheelGraph) Then
                        y = Module1.CalculateOutput2(x, .MinInput, .Gama, .MaxOut)
                    Else
                        y = Module1.CalculateOutput(x, .Range, .MinInput, .MinPower, .Gama, 1)
                    End If
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
                g.DrawLine(Drawing.Pens.White, x, 12, x, 28) ' draw current position
            End Using
        End With
    End Sub


    Public Sub UpdatePedals()
        If ParentButton Is Nothing Then Return
        Dim x As Integer
        Select Case ParentButton.Name
            Case frmSetup.btAccelGraph.Name
                If fromArduino1 IsNot Nothing Then x = fromArduino1.pedalAccel
            Case frmSetup.btBrakeGraph.Name
                If fromArduino1 IsNot Nothing Then x = fromArduino1.pedalBreak
            Case frmSetup.btClutchGraph.Name
                If fromArduino1 IsNot Nothing Then x = fromArduino1.pedalClutch
            Case Else
                Return
        End Select
        UpdateValue(x)
    End Sub

    Public Sub UpdateFFWheel(FFWheel As Integer)
        If ParentButton Is Nothing OrElse ParentButton.Name <> frmSetup.btWheelGraph.Name Then Return
        UpdateValue(FFWheel)
    End Sub

    Public Sub UpdateWind(FFWind As Integer)
        If ParentButton Is Nothing OrElse ParentButton.Name <> frmSetup.btWindGraph.Name Then Return
        UpdateValue(FFWind)
    End Sub

    Public Sub UpdateShakeSpeed(FFShakeSpeed As Integer)
        If ParentButton Is Nothing OrElse ParentButton.Name <> frmSetup.btShakeSpeedGraph.Name Then Return
        UpdateValue(FFShakeSpeed)
    End Sub

    Public Sub UpdateShakePower(FFShakePower As Integer)
        If ParentButton Is Nothing OrElse ParentButton.Name <> frmSetup.btShakePowerGraph.Name Then Return
        UpdateValue(FFShakePower)
    End Sub


    Public Structure structValues
        Public Range As Integer
        Public MinInput As Integer
        Public MinPower As Integer
        Public Gama As Integer
        Public MaxOut As Integer
    End Structure

End Class
