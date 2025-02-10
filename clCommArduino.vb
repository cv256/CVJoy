Public Structure SerialSend
    Public wheelPower As Integer ' -255~255  0=no force
    Public Reset As Boolean
    Public windPower As Byte
    Public shakePower As Byte
    Public shakeSpeed As Byte

    Public Const PacketLen As Byte = 6

    Public Function GetSerialData() As Byte()
        Dim res(PacketLen - 1) As Byte
        res(0) = If(Reset, 252, If(wheelPower < 0, 253, 254)) ' recordtype + wheelPowerDir
        res(2) = Math.Abs(wheelPower)
        res(3) = windPower
        res(4) = shakePower
        res(5) = shakeSpeed
        res(1) = CByte(255) - (res(2) Xor res(3) Xor res(4) Xor res(5)) ' checkdigit
        Return res
    End Function

End Structure


Public Structure SerialSend2
    Public BreakLed As Boolean
    Public leftPower As SByte  ' -127~127  0=no force
    Public rightPower As SByte ' -127~127  0=no force

    Public Const PacketLen As Byte = 4

    Public Function GetSerialData() As Byte()
        Dim res(PacketLen - 1) As Byte
        res(0) = 254 + If(BreakLed, 1, 0) ' recordtype 
        res(2) = leftPower + 128
        res(3) = rightPower + 128
        res(1) = CByte(255) - (res(2) Xor res(3)) ' checkdigit
        Return res
    End Function

End Structure

Public Class SerialRead2
    Public Const PacketLen As Byte = 6

    Public RealLeft As Single
    Public RealRight As Single
    Public Sub SetSerialData(pSerialData As List(Of Byte))
        'pSerialData(0) = recordType
        'pSerialData(1) = errors / ACpower

        Const soundSpeed As Single = 0.172922 ' 331300 + 606 * tempAirCelsius / 1000000 / 2   =   mm per microsecond , go and return  <=>  34cm =  0,002 seconds
        RealLeft = CSng(pSerialData(2) + pSerialData(3) * 256) * soundSpeed
        RealRight = CSng(pSerialData(4) + pSerialData(5) * 256) * soundSpeed
    End Sub
End Class


Public Class SerialRead
    Public Const PacketLen As Byte = 8

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
    Public buttons(clGame.BtCount - 1) As Boolean

    Public AccelCorrected As Byte
    Public BrakeCorrected As Byte
    Public ClutchCorrected As Byte

    Public Sub SetSerialData(pSerialData As List(Of Byte))
        'pSerialData(0) = recordType
        buttons(8) = (pSerialData(1) And 32) <> 0 ' bits 1 and 2 are reserved for errors
        buttons(9) = (pSerialData(1) And 16) <> 0
        buttons(0) = (pSerialData(2) And 1) <> 0
        buttons(1) = (pSerialData(2) And 2) <> 0
        buttons(2) = (pSerialData(2) And 4) <> 0
        buttons(3) = (pSerialData(2) And 8) <> 0
        buttons(4) = (pSerialData(2) And 16) <> 0
        buttons(5) = (pSerialData(2) And 32) <> 0
        buttons(6) = (pSerialData(2) And 64) <> 0
        buttons(7) = (pSerialData(2) And 128) <> 0

        gear1 = (pSerialData(3) And 1) <> 0
        gear2 = (pSerialData(3) And 2) <> 0
        gear3 = (pSerialData(3) And 4) <> 0
        gear4 = (pSerialData(3) And 8) <> 0
        gear5 = (pSerialData(3) And 16) <> 0
        gear6 = (pSerialData(3) And 32) <> 0
        gearR = (pSerialData(3) And 64) <> 0

        pedalAccel = pSerialData(4)
        pedalBreak = pSerialData(5)
        pedalClutch = pSerialData(6)

        ' pSerialData(7) = Checksum !

        ' corrected analogic values:
        AccelCorrected = ScaleValue(pedalAccel, SettingsMain.AccelMin, SettingsMain.AccelMax, 0, 255, SettingsMain.AccelGama)
        BrakeCorrected = ScaleValue(pedalBreak, SettingsMain.BrakeMin, SettingsMain.BrakeMax, 0, 255, SettingsMain.BrakeGama)
        ClutchCorrected = ScaleValue(pedalClutch, SettingsMain.ClutchMin, SettingsMain.ClutchMax, 0, 255, SettingsMain.ClutchGama)
    End Sub
End Class


