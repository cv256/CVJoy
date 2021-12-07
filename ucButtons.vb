Public Class ucButtons

    Private _descriptions As Boolean

    Public Function UseSettings() As Boolean
        For Each c As Control In Me.Controls
            If Not c.Name.StartsWith("bt") Then Continue For
            Dim i As Integer = CInt(c.Name.Substring(2))
            If _descriptions Then
                Game.BtDescr(i) = c.Text
            Else
                Game.Bt(i) = c.Text
            End If
        Next
        Return True
    End Function

    Public Function ShowSettings() As Boolean
        For Each c As Control In Me.Controls
            If Not c.Name.StartsWith("bt") Then Continue For
            Dim i As Integer = CInt(c.Name.Substring(2))
            If _descriptions Then
                c.Text = Game.BtDescr(i)
            Else
                c.Text = Game.Bt(i)
            End If
        Next
        Return True
    End Function

    Public Sub BorderStyle(pStyle As BorderStyle)
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

    Public Property [Descriptions] As Boolean
        Get
            Return _descriptions
        End Get
        Set(value As Boolean)
            UseSettings()
            _descriptions = value
            ShowSettings()
            BorderStyle(If(value, Windows.Forms.BorderStyle.Fixed3D, Windows.Forms.BorderStyle.FixedSingle))
        End Set
    End Property

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click, Label2.Click
        Descriptions = Not Descriptions
    End Sub

End Class
