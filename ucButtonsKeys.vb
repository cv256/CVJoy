
Public Class ucButtonsKeys

    Public MyTextBox As TextBox
    Private initializing As Boolean = True

    Public Sub New()

        ' This call is required by the designer
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If Not DesignMode Then
            ComboBox1.Items.Clear()
            ComboBox1.Items.AddRange(Module1.KeysDict.Values.ToArray)

            ComboBox2.Items.Clear()
            ComboBox2.Items.AddRange(Module1.KeysDict.Values.ToArray)
        End If

    End Sub

    Public Sub SetTextBox(pTextBox As TextBox)
        initializing = True
        MyTextBox = pTextBox
        Dim texts As String() = MyTextBox.Text.Split("+"c)
        Dim i As Integer = -1
        If texts.Length > 0 Then i = Array.FindIndex(Of String)(Module1.KeysDict.Values.ToArray, Function(s) s.ToUpper = texts(0).ToUpper)
        ComboBox1.SelectedIndex = i
        i = -1
        If texts.Length > 1 Then i = Array.FindIndex(Of String)(Module1.KeysDict.Values.ToArray, Function(s) s.ToUpper = texts(1).ToUpper)
        ComboBox2.SelectedIndex = i
        initializing = False
    End Sub


    Public Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged, ComboBox2.SelectedIndexChanged
        If initializing Then Return
        Dim res As String = ""
        If ComboBox1.SelectedIndex >= 0 Then res = ComboBox1.SelectedItem
        If ComboBox2.SelectedIndex >= 0 Then res &= If(res > "", "+", "") & ComboBox2.SelectedItem
        MyTextBox.Text = res
    End Sub

End Class
