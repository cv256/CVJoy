Module Module1

    Public graph As ucControlGraph
    'Public timeStart As DateTime, timeSent As DateTime, timeRead As DateTime
    Public kSpeedGama As Single ' everytime My.Settings.SpeedGama  changes we must call Sub SetKSpeedGama. This is a mathematic optimization

    Public Function ValidateNumber(pTextbox As Control, pMin As Single, pMax As Single, FieldDescr As String) As String
        Dim res As Single, ok As Boolean
        ok = Single.TryParse(pTextbox.Text.Replace("º", "").Replace(" ", "").Replace("G", ""), res)
        If Not ok OrElse res < pMin OrElse res > pMax Then
            pTextbox.BackColor = Color.Red
            Return FieldDescr & " must be between " & pMin & " and " & pMax & vbCrLf
        Else
            pTextbox.BackColor = SystemColors.Window
            Return ""
        End If
    End Function


    Public Function ScaleValue(pValue As Integer, pFromMin As Integer, pFromMax As Integer, pToMin As Integer, pToMax As Integer) As Integer
        Return Math.Min(pToMax, Math.Max(pToMin, (pValue - pFromMin) / (pFromMax - pFromMin) * pToMax + pToMin))
    End Function
    Public Function ScaleValue(pValue As Integer, pFromMin As Integer, pFromMax As Integer, pToMin As Integer, pToMax As Integer, pGama As Single) As Integer
        Return (ScaleValue(pValue, pFromMin, pFromMax, pToMin, pToMax) / pToMax) ^ pGama * pToMax
    End Function

    Public Sub SetKSpeedGama()
        kSpeedGama = (255 - My.Settings.SpeedMin) ^ (My.Settings.SpeedGama / 100) / (255 - My.Settings.SpeedMin)
    End Sub

End Module
