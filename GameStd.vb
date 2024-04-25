Public Class GameStd
    Inherits clGame

    Public Sub New(pOwner As frmCVJoy)
        MyBase.New(pOwner)
    End Sub

    Public Overrides Function GameName() As String
        Return "Standard"
    End Function

    Public Overrides Function FileName() As String
        Return "SettingsStd.INI"
    End Function

    Public Overrides Sub Start()
        Try
            '            AC = New AssettoCorsa()
            '            AC.Start() ' Connect To Shared memory And start interval timers 
            State = "started"
        Catch ex As Exception
            MsgBox("btGameStart.Click " & ex.Message)
        End Try
    End Sub

    Public Overrides Sub [Stop]()
        '       If AC IsNot Nothing Then AC.Stop()
        '       AC = Nothing
        State = ""
    End Sub

    Public Overrides Function Started() As Boolean
        Return True ' AC IsNot Nothing
    End Function

    Public Overrides Function GetGameOutputs() As clGameOutputs
        Dim res As clGameOutputs
        'res.LedBottom = True
        Return res
    End Function

    Public Overrides Function GetGameOutputsExtra() As clGameOutputsExtra
        Dim res As clGameOutputsExtra
        'res.LedBottom = True
        Return res
    End Function

    Public Function SetupForm() As frmSetupStd
        If Owner.OwnedForms.Any(Function(f) TypeOf f Is frmSetupStd) Then
            Return Owner.OwnedForms.First(Function(f) TypeOf f Is frmSetupStd)
        End If
        Return Nothing
    End Function

    Public Overrides Sub ShowSetup()
        Dim tmpFrm As frmSetupStd = SetupForm()
        If tmpFrm IsNot Nothing Then
            tmpFrm.Show()
        Else
            tmpFrm = New frmSetupStd
            tmpFrm.Init(Owner, Me)
        End If
    End Sub

End Class


