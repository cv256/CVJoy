Public Class ucButtons

    Public Function UseSettings() As Boolean
        Game.Bt2 = bt2.Text
        Game.Bt3 = bt3.Text
        Game.Bt4 = bt4.Text
        Game.Bt5 = bt5.Text
        Game.Bt6 = bt6.Text
        Game.Bt7 = bt7.Text
        Game.Bt8 = bt8.Text
        Game.Bt9 = bt9.Text
        Return True
    End Function

    Public Function ShowSettings(pGame As GameAC) As Boolean
        bt2.Text = pGame.bt2
        bt3.Text = pGame.bt3
        bt4.Text = pGame.bt4
        bt5.Text = pGame.bt5
        bt6.Text = pGame.bt6
        bt7.Text = pGame.bt7
        bt8.Text = pGame.bt8
        bt9.Text = pGame.bt9
        Return True
    End Function

    Public Property [ReadOnly] As Boolean
        Get
            Return bt2.ReadOnly
        End Get
        Set(value As Boolean)
            bt2.ReadOnly = value
            bt3.ReadOnly = value
            bt4.ReadOnly = value
            bt5.ReadOnly = value
            bt6.ReadOnly = value
            bt7.ReadOnly = value
            bt8.ReadOnly = value
            bt9.ReadOnly = value
        End Set
    End Property

End Class
