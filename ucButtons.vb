Public Class ucButtons

    Public Function UseSettings() As Boolean
        For Each c As Control In Me.Controls
            If Not c.Name.StartsWith("bt") Then Continue For
            Dim i As Integer = CInt(c.Name.Substring(2))
            Game.Bt(i) = c.Text
        Next
        Return True
    End Function

    Public Function ShowSettings() As Boolean
        For Each c As Control In Me.Controls
            If Not c.Name.StartsWith("bt") Then Continue For
            Dim i As Integer = CInt(c.Name.Substring(2))
            c.Text = Game.Bt(i)
        Next
        Return True
    End Function

    Public Property [ReadOnly] As Boolean
        Get
            Return bt1.ReadOnly
        End Get
        Set(value As Boolean)
            Label1.Text = ""
            For Each c As Control In Me.Controls
                If Not c.Name.StartsWith("bt") Then Continue For
                Dim i As Integer = CInt(c.Name.Substring(2))
                DirectCast(c, TextBox).ReadOnly = value
            Next
        End Set
    End Property

End Class
