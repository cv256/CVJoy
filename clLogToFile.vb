Public Class clLogToFile
    Private StartTime As Date
    Private LogToFile As System.Text.StringBuilder

    Public Sub New()
        LogToFile = New System.Text.StringBuilder
        StartTime = Now
    End Sub

    Public Sub LogWheelFFBIn(pConstMagnitude As Short)
        LogToFile.AppendLine(CInt(Now.Subtract(StartTime).TotalMilliseconds).ToString & vbTab & pConstMagnitude.ToString())
    End Sub
    Public Sub LogWheelPosInOut(pPos As Integer)
        LogToFile.AppendLine(CInt(Now.Subtract(StartTime).TotalMilliseconds).ToString & vbTab & vbTab & pPos.ToString())
    End Sub
    Public Sub LogWheelMotorOut(pPower As Integer)
        LogToFile.AppendLine(CInt(Now.Subtract(StartTime).TotalMilliseconds).ToString & vbTab & vbTab & vbTab & pPower.ToString())
    End Sub

    Public Sub SaveToFile()
retr:
        Try
            IO.File.WriteAllText("CVJoyLog-Wheel.csv", "Millisec" & vbTab & "FfbIn" & vbTab & "PosInOut" & vbTab & "MotorOut" & vbCrLf & LogToFile.ToString())
        Catch ex As Exception
            If MsgBox(ex.Message, MsgBoxStyle.RetryCancel) = MsgBoxResult.Retry Then GoTo retr
        End Try
    End Sub
End Class
