Module Module1

    Public SettingsMain As New clSettingsMain
    Public toArduino1 As New SerialSend, fromArduino1 As New SerialRead
    Public toArduino2 As New SerialSend2, fromArduino2 As New SerialRead2
    Public Game As clGame
    Public LogToFile As clLogToFile

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


    Public Function CalculateOutput(pInput As Single, Range As Integer, MinInput As Integer, MinOuput As Integer, Gama As Integer, Factor As Single) As Integer
        If pInput <= MinInput Then Return 0

        Dim output As Integer
        If MinInput > 0 Then pInput = (pInput - MinInput) / (Range - MinInput) * Range
        Dim tmpFactor As Single = Factor
        If MinOuput > 1 Then tmpFactor = Factor / Range * (Range - MinOuput)
        If Gama <> 100 Then
            output = MinOuput + (pInput / Range) ^ (Gama / 100) * Range * tmpFactor
        Else
            output = MinOuput + pInput * tmpFactor
        End If
        If output > Range Then output = Range
        Return output
    End Function

    Public Function CalculateOutput2(pInput As Single, MidIn As Integer, MidOut As Single, MaxOut As Single) As Integer
        If pInput <= MidIn Then
            Return pInput / MidIn * MidOut
        Else
            Return MidOut + (pInput - MidIn) / (255 - MidIn) * (MaxOut - MidOut)
        End If
    End Function

    Public Function ScaleValue(pValue As Single, pFromMin As Single, pFromMax As Single, pToMin As Single, pToMax As Single) As Single
        If pValue = 0 Then Return 0
        Return Math.Min(pToMax, Math.Max(pToMin, (pValue - pFromMin) * pToMax / (pFromMax - pFromMin) + pToMin))
    End Function
    Public Function ScaleValue(pValue As Single, pFromMin As Single, pFromMax As Single, pToMin As Single, pToMax As Single, pGama As Single) As Single
        If pValue = 0 Then Return 0
        Return (ScaleValue(pValue, pFromMin, pFromMax, pToMin, pToMax) / pToMax) ^ pGama * pToMax
    End Function

End Module
