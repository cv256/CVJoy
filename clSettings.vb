Public Class clSettingsMain
    Inherits clSettings

    Public ArduinoComPort As String = "COM3"
    Public RefreshRate As Byte = 55
    Public vJoyId As Byte = 1
    Public UdpIp As String = "255.255.255.255"

    Public AccelMin As Integer = 0
    Public AccelMax As Integer = 1020
    Public AccelGama As Single = 0.7
    Public BrakeMin As Integer = 0
    Public BrakeMax As Integer = 1020
    Public BrakeGama As Single = 0.7
    Public ClutchMin As Integer = 0
    Public ClutchMax As Integer = 1020
    Public ClutchGama As Single = 0.7

    Public WheelMinInput As Integer = 1

    Public WheelPowerGama As Single = 100
    Public WheelPowerForMin As Integer = 29
    Public WheelPowerFactor As Single = 1.0
    Public WheelDampFactor As Integer = 500
    Public WheelInertia As Single = 0

    Public WindMinPower As Integer = 32
    Public WindGama As Single = 150
    Public ShakeMinPower As Integer = 70
    Public ShakeGama As Single = 150

    Public UltrasonicGama As Single = 1
    Public GZDistance As Integer = 310
    Public GXDistance As Integer = 293
    Public GLeftScrewCenter As Integer = 100
    Public GRightScrewCenter As Integer = 107
    Public GMaxScrewUp As Integer = 35
    Public GMaxScrewDown As Integer = 31
    Public GPowerForMin As Byte = 40
    Public GMinDiff As Integer = 4
    Public GMaxDiff As Integer = 30
    Public UltrasonicDamper As Single = 0.92
    Public GMinMotorEfficiency As Single = 20
    Public GMaxMotorEfficiency As Single = 127

    Public Overrides Function FileName() As String
        Return "Settings.INI"
    End Function

    'Public Sub New()
    '    Calculate_GMotorEfficiencyOK()
    'End Sub

    'Public Property GMinMotorEfficiency As Single
    '    Get
    '        Return _gMinMotorEfficiency
    '    End Get
    '    Set(value As Single)
    '        _gMinMotorEfficiency = value
    '        Calculate_GMotorEfficiencyOK()
    '    End Set
    'End Property
    'Public Property GMaxMotorEfficiency As Single
    '    Get
    '        Return _gMaxMotorEfficiency
    '    End Get
    '    Set(value As Single)
    '        _gMaxMotorEfficiency = value
    '        Calculate_GMotorEfficiencyOK()
    '    End Set
    'End Property
    'Public Property UltrasonicDamper As Single
    '    Get
    '        Return _ultrasonicDamper
    '    End Get
    '    Set(value As Single)
    '        _ultrasonicDamper = value
    '        Calculate_GMotorEfficiencyOK()
    '    End Set
    'End Property

    'Private _gMinMotorEfficiencyOK As Single, _gMaxMotorEfficiencyOK As Single
    'Private Sub Calculate_GMotorEfficiencyOK()
    '    _gMinMotorEfficiencyOK = GMinMotorEfficiency * UltrasonicDamper / (1 - UltrasonicDamper)
    '    _gMaxMotorEfficiencyOK = GMaxMotorEfficiency * UltrasonicDamper / (1 - UltrasonicDamper)
    'End Sub
    'Public ReadOnly Property GMinMotorEfficiencyOK As Single
    '    Get
    '        Return _gMinMotorEfficiencyOK
    '    End Get
    'End Property
    'Public ReadOnly Property GMaxMotorEfficiencyOK As Single
    '    Get
    '        Return _gMaxMotorEfficiencyOK
    '    End Get
    'End Property

End Class


Public MustInherit Class clSettings
    Public Sub SaveSettingstoFile()
        Dim res As String = ""
        For Each p As Reflection.FieldInfo In Me.GetType.GetFields()
            If p.FieldType.BaseType.Name = "Array" Then Continue For ' we dont serialize arrays, you have to create a property that returns the array joined into a string
            res &= p.Name & "=" & p.GetValue(Me) & vbCrLf
        Next
        For Each p As Reflection.PropertyInfo In Me.GetType.GetProperties()
            If p.CanRead AndAlso p.CanWrite Then res &= p.Name & "=" & p.GetValue(Me) & vbCrLf
        Next
        If Not IO.Directory.Exists(Path) Then
            IO.Directory.CreateDirectory(Path)
        End If
        IO.File.WriteAllText(path:=Path() & FileName(), contents:=res)
    End Sub

    Public Sub LoadSettingsFromFile()
        Try
            If Not IO.Directory.Exists(Path) Then IO.Directory.CreateDirectory(Path)
            Dim res As String() = IO.File.ReadAllLines(Path() & FileName())
            For Each p As Reflection.FieldInfo In Me.GetType.GetFields()
                If p.FieldType.BaseType.Name = "Array" Then Continue For ' we dont serialize arrays, you have to create a property that returns the array joined into a string
                Dim v As String = res.Where(Function(f) f.ToUpper.StartsWith(p.Name.ToUpper & "=")).FirstOrDefault
                If v Is Nothing Then Continue For
                v = v.Substring(Len(p.Name) + 1)
                p.SetValue(Me, Convert.ChangeType(v, p.FieldType))
            Next
            For Each p As Reflection.PropertyInfo In Me.GetType.GetProperties()
                If p.CanRead AndAlso p.CanWrite Then
                    Dim v As String = res.Where(Function(f) f.ToUpper.StartsWith(p.Name.ToUpper & "=")).FirstOrDefault
                    If v Is Nothing Then Continue For
                    v = v.Substring(Len(p.Name) + 1)
                    p.SetValue(Me, Convert.ChangeType(v, p.PropertyType))
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Function Path() As String
        Return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\CVJoy\"
    End Function

    Public MustOverride Function FileName() As String
End Class


