Public Class clSettingsMain
    Inherits clSettings

    Public ArduinoComPort As String = "COM3"
    Public RefreshRate As Byte = 35
    Public vJoyId As Byte = 1

    Public AccelMin As Integer = 290
    Public AccelMax As Integer = 880
    Public AccelGama As Single = 1.6
    Public BrakeMin As Integer = 140
    Public BrakeMax As Integer = 656
    Public BrakeGama As Single = 1
    Public ClutchMin As Integer = 150
    Public ClutchMax As Integer = 810
    Public ClutchGama As Single = 1

    Public MouseSteering As Integer = 0
    Public WheelMinInput As Integer = 3
    Public WheelSensitivity As Single = 8.5
    Public WheelDead As Integer = 0

    Public WheelPowerGama As Single = 40
    Public WheelPowerForMin As Integer = 88
    Public WheelPowerFactor As Single = 1.08
    Public WheelDampFactor As Integer = 500

    Public WindMinPower As Integer = 32
    Public WindGama As Single = 150
    Public ShakeMinPower As Integer = 70
    Public ShakeGama As Single = 150

    Public GZDistance As Integer = 310
    Public GXDistance As Integer = 293
    Public GLeftScrewCenter As Integer = 100
    Public GRightScrewCenter As Integer = 107
    Public GMaxScrewUp As Integer = 35
    Public GMaxScrewDown As Integer = 31
    Public GPowerForMin As Byte = 40
    Public GMinDiff As Integer = 4
    Public GMaxDiff As Integer = 30
    Private _ultrasonicDamper As Single = 0.92
    Private _gLeftMotorEfficiency As Single = 0.022
    Private _gRightMotorEfficiency As Single = 0.022

    Public Overrides Function FileName() As String
        Return "Settings.INI"
    End Function

    Public Sub New()
        Calculate_GMotorEfficiencyOK()
    End Sub

    Public Property GLeftMotorEfficiency As Single
        Get
            Return _gLeftMotorEfficiency
        End Get
        Set(value As Single)
            _gLeftMotorEfficiency = value
            Calculate_GMotorEfficiencyOK()
        End Set
    End Property
    Public Property GRightMotorEfficiency As Single
        Get
            Return _gRightMotorEfficiency
        End Get
        Set(value As Single)
            _gRightMotorEfficiency = value
            Calculate_GMotorEfficiencyOK()
        End Set
    End Property
    Public Property UltrasonicDamper As Single
        Get
            Return _ultrasonicDamper
        End Get
        Set(value As Single)
            _ultrasonicDamper = value
            Calculate_GMotorEfficiencyOK()
        End Set
    End Property

    Private _gLeftMotorEfficiencyOK As Single, _gRightMotorEfficiencyOK As Single
    Private Sub Calculate_GMotorEfficiencyOK()
        _gLeftMotorEfficiencyOK = GLeftMotorEfficiency * UltrasonicDamper / (1 - UltrasonicDamper)
        _gRightMotorEfficiencyOK = GRightMotorEfficiency * UltrasonicDamper / (1 - UltrasonicDamper)
    End Sub
    Public ReadOnly Property GLeftMotorEfficiencyOK As Single
        Get
            Return _gLeftMotorEfficiencyOK
        End Get
    End Property
    Public ReadOnly Property GRightMotorEfficiencyOK As Single
        Get
            Return _gRightMotorEfficiencyOK
        End Get
    End Property

End Class


Public MustInherit Class clSettings
    Public Sub SaveSettingstoFile()
        Dim res As String = ""
        For Each p As Reflection.FieldInfo In Me.GetType.GetFields()
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



Public MustInherit Class clGame
    Inherits clSettings
    Friend Owner As frmCVJoy
    Public MustOverride Function GameName() As String
    Public bt2 As String = ""
    Public bt3 As String = ""
    Public bt4 As String = ""
    Public bt5 As String = ""
    Public bt6 As String = ""
    Public bt7 As String = ""
    Public bt8 As String = ""
    Public bt9 As String = ""
    Public Sub New(pOwner As frmCVJoy)
        Owner = pOwner
    End Sub
    Public MustOverride Sub Start()
    Public MustOverride Sub [Stop]()
    Public MustOverride Function Started() As Boolean
    Public MustOverride Function Update() As clGameOutputs
    Private _State As String
    Public Property State() As String
        Get
            Return _State
        End Get
        Friend Set(value As String)
            _State = value
            RaiseEvent StateChanged()
        End Set
    End Property
    Public Event StateChanged()
    Public MustOverride Sub ShowSetup()
End Class

Public Structure clGameOutputs
    Public Wind As Integer ' nominal is 0~255
    Public Shake As Integer ' nominal is 0~255
    Public Pitch As Single ' radians
    Public Roll As Single ' radians
    Public LedTop As Boolean
    Public LedBottom As Boolean
    Public LedLeft As Boolean
    Public LedRight As Boolean
End Structure
