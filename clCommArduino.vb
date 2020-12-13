Public Structure SerialSend
    Public wheelPower As Integer ' -255~255  0=no force
    Public leftPower As SByte  ' -127~127  0=no force
    Public rightPower As SByte ' -127~127  0=no force
    Public windPower As Byte
    Public shakePower As Byte
    Public WheelPositionOffset As Boolean

    Public Const PacketLen As Byte = 7

    Public Function GetSerialData() As Byte()
        Dim res(PacketLen - 1) As Byte
        res(0) = If(WheelPositionOffset, 253, If(wheelPower < 0, 254, 255)) ' checkdigit + wheelPowerDir
        res(1) = Math.Abs(wheelPower)
        res(2) = leftPower + 128
        res(3) = rightPower + 128
        res(4) = windPower
        res(5) = shakePower
        Return res
    End Function

    Public Overrides Function ToString() As String
        Dim res As String = ""
        For Each b As Byte In GetSerialData()
            res &= b & "  "
        Next
        Return res
    End Function

End Structure



Public Class SerialRead
    Public pedalAccel As Integer
    Public pedalBreak As Integer
    Public pedalClutch As Integer
    Public gear1 As Boolean
    Public gear2 As Boolean
    Public gear3 As Boolean
    Public gear4 As Boolean
    Public gear5 As Boolean
    Public gear6 As Boolean
    Public gearR As Boolean
    Public handbrake As Boolean
    Public buttons(8) As Boolean

    Public AccelCorrected As Integer
    Public BrakeCorrected As Integer
    Public ClutchCorrected As Integer
    Public WheelPosition As Integer ' -16380 ~ 0 ~ 16380

    Public RealLeft As Single
    Public RealRight As Single


    Public Const PacketLen As Byte = 15

    Public Sub SetSerialData(pSerialData As Byte())
        buttons(8) = (pSerialData(0) And 32) <> 0
        buttons(0) = (pSerialData(1) And 1) <> 0
        buttons(1) = (pSerialData(1) And 2) <> 0
        buttons(2) = (pSerialData(1) And 4) <> 0
        buttons(3) = (pSerialData(1) And 8) <> 0
        buttons(4) = (pSerialData(1) And 16) <> 0
        buttons(5) = (pSerialData(1) And 32) <> 0
        buttons(6) = (pSerialData(1) And 64) <> 0
        buttons(7) = (pSerialData(1) And 128) <> 0

        gear1 = (pSerialData(2) And 1) <> 0
        gear2 = (pSerialData(2) And 2) <> 0
        gear3 = (pSerialData(2) And 4) <> 0
        gear4 = (pSerialData(2) And 8) <> 0
        gear5 = (pSerialData(2) And 16) <> 0
        gear6 = (pSerialData(2) And 32) <> 0
        gearR = (pSerialData(2) And 64) <> 0
        handbrake = (pSerialData(2) And 128) <> 0

        pedalAccel = pSerialData(3) + pSerialData(4) * 256
        pedalBreak = pSerialData(5) + pSerialData(6) * 256
        pedalClutch = pSerialData(7) + pSerialData(8) * 256

        WheelPosition = (pSerialData(9) + pSerialData(10) * 256 - 32768) * Game.WheelSensitivity

        Const soundSpeed As Single = 0.172922 ' 331300 + 606 * tempAirCelsius / 1000000 / 2   =   mm per microsecond , go and return  <=>  34cm =  0,002 seconds
        RealLeft = CSng(pSerialData(11) + pSerialData(12) * 256) * soundSpeed
        RealRight = CSng(pSerialData(13) + pSerialData(14) * 256) * soundSpeed

        ' corrected analogic values:
        AccelCorrected = ScaleValue(pedalAccel, SettingsMain.AccelMin, SettingsMain.AccelMax, 0, 1023, SettingsMain.AccelGama)
        BrakeCorrected = ScaleValue(pedalBreak, SettingsMain.BrakeMin, SettingsMain.BrakeMax, 0, 1023, SettingsMain.BrakeGama)
        ClutchCorrected = ScaleValue(pedalClutch, SettingsMain.ClutchMin, SettingsMain.ClutchMax, 0, 1023, SettingsMain.ClutchGama)
    End Sub
End Class


