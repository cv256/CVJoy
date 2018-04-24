Module Module1

    Public SettingsMain As New clSettingsMain
    Public Game As clGame

    Public graph As ucControlGraph, Ggraph As ucControlGGraph
    'Public timeStart As DateTime, timeSent As DateTime, timeRead As DateTime

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



    Public Function CalculateOutput(pInput As Integer, Range As Integer, MinInput As Integer, MinOuput As Integer, Gama As Integer, Factor As Single) As Integer
        Dim output As Integer = 0
        If pInput > MinInput Then
            If MinInput > 0 Then pInput = (pInput - MinInput) / (Range - MinInput) * Range
            Dim tmpFactor As Single = Factor
            If MinOuput > 1 Then tmpFactor = Factor / Range * (Range - MinOuput)
            If Gama <> 100 Then
                output = MinOuput + (pInput / Range) ^ (Gama / 100) * Range * tmpFactor
            Else
                output = MinOuput + pInput * tmpFactor
            End If
            If output > Range Then output = Range
        End If
        Return output
    End Function


    Public Function ScaleValue(pValue As Single, pFromMin As Integer, pFromMax As Integer, pToMin As Integer, pToMax As Integer) As Integer
        Return Math.Min(pToMax, Math.Max(pToMin, (pValue - pFromMin) * pToMax / (pFromMax - pFromMin) + pToMin))
    End Function
    Public Function ScaleValue(pValue As Single, pFromMin As Integer, pFromMax As Integer, pToMin As Integer, pToMax As Integer, pGama As Single) As Integer
        Return (ScaleValue(pValue, pFromMin, pFromMax, pToMin, pToMax) / pToMax) ^ pGama * pToMax
    End Function

End Module
