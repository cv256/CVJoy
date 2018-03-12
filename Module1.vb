Module Module1

    Public graph As ucControlGraph
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


    Public Function CalculateOutput(pInput As Integer, Range As Integer, MinInput As Integer, MinPower As Integer, Gama As Integer, Factor As Single) As Integer
        Dim output As Integer = 0
        If pInput >= MinInput Then
            If MinInput > 1 Then pInput = (pInput - MinInput) / (Range - MinInput) * Range
            Dim tmpFactor As Single = Factor
            If MinPower > 1 Then tmpFactor = Factor / Range * (Range - MinPower)
            If Gama <> 100 Then
                output = MinPower + (pInput / Range) ^ (Gama / 100) * Range * tmpFactor
            Else
                output = MinPower + pInput * tmpFactor
            End If
            If output > Range Then output = Range
        End If
        Return output
    End Function


    Public Function ScaleValue(pValue As Integer, pFromMin As Integer, pFromMax As Integer, pToMin As Integer, pToMax As Integer) As Integer
        Return Math.Min(pToMax, Math.Max(pToMin, (pValue - pFromMin) / (pFromMax - pFromMin) * pToMax + pToMin))
    End Function
    Public Function ScaleValue(pValue As Integer, pFromMin As Integer, pFromMax As Integer, pToMin As Integer, pToMax As Integer, pGama As Single) As Integer
        Return (ScaleValue(pValue, pFromMin, pFromMax, pToMin, pToMax) / pToMax) ^ pGama * pToMax
    End Function

End Module
