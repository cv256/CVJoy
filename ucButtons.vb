Public Class ucButtons

    Private _showDescriptions As Boolean
    Private _inited As Boolean = False

    Public Sub StoreToGameSettings()
        If Not _inited Then Return ' this is to avoid erasing Game when form loads and the designer.vb calls ShowDescriptions
        For Each c As Control In Me.Controls
            If Not c.Name.StartsWith("bt") Then Continue For
            Dim i As Integer = CInt(c.Name.Substring(2))
            If _showDescriptions Then
                Game.BtDescr(i) = c.Text
            Else
                Game.Bt(i) = c.Text
            End If
        Next
    End Sub

    Public Sub ShowFromGameSettings()
        For Each c As Control In Me.Controls
            If Not c.Name.StartsWith("bt") Then Continue For
            Dim i As Integer = CInt(c.Name.Substring(2))
            If _showDescriptions Then
                c.Text = Game.BtDescr(i)
            Else
                c.Text = Game.Bt(i)
            End If
        Next
        _inited = True
    End Sub

    Public Shadows Sub BorderStyle(pStyle As BorderStyle)
        For Each c As Control In Me.Controls
            If Not c.Name.StartsWith("bt") Then Continue For
            DirectCast(c, TextBox).BorderStyle = pStyle
        Next
    End Sub

    Public Property [ReadOnly] As Boolean
        Get
            Return bt1.ReadOnly
        End Get
        Set(value As Boolean)
            If value Then Label1.Text = ""
            For Each c As Control In Me.Controls
                If Not c.Name.StartsWith("bt") Then Continue For
                Dim i As Integer = CInt(c.Name.Substring(2))
                DirectCast(c, TextBox).ReadOnly = value
            Next
        End Set
    End Property

    Public Property ShowDescriptions As Boolean
        Get
            Return _showDescriptions
        End Get
        Set(value As Boolean)
            If Not IsNothing(Game) Then StoreToGameSettings()
            _showDescriptions = value
            If Not IsNothing(Game) Then ShowFromGameSettings()
            BorderStyle(If(value, Windows.Forms.BorderStyle.Fixed3D, Windows.Forms.BorderStyle.FixedSingle))
        End Set
    End Property

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click, Label2.Click
        ShowDescriptions = Not ShowDescriptions
    End Sub

End Class
