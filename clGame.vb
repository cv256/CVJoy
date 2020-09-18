Public MustInherit Class clGame
    Inherits clSettings

    Friend Owner As frmCVJoy
    Public MustOverride Function GameName() As String

    Public Sub New(pOwner As frmCVJoy)
        Owner = pOwner
    End Sub

    Public MustOverride Sub Start()
    Public MustOverride Sub [Stop]()
    Public MustOverride Function Started() As Boolean
    Public MustOverride Function Update() As clGameOutputs
    Public MustOverride Sub ShowSetup()

    Public Event StateChanged()
    Private _State As String
    Public Property State() As String
        Get
            Return _State
        End Get
        Friend Set(value As String)
            _State = value
            RaiseEvent StateChanged()
        End Set
    End Property

    Public Bt(17) As String
    Public Property Bts() As String
        Get
            Return String.Join("£", Bt)
        End Get
        Friend Set(value As String)
            Dim tmp() As String = value.Split("£"c)
            For i As Integer = 0 To Bt.Length - 1
                If i >= tmp.Length Then Exit For
                Bt(i) = tmp(i)
            Next
        End Set
    End Property

End Class

Public Structure clGameOutputs
    Public Wind As Integer  ' nominal is 0~255
    Public Shake As Integer  ' nominal is 0~255
    Public Pitch As Single ' radians
    Public Roll As Single ' radians
    Public LedTop As Boolean
    Public LedBottom As Boolean
    Public LedLeft As Boolean
    Public LedRight As Boolean
End Structure
