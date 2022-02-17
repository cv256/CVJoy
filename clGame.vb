Public MustInherit Class clGame
    Inherits clSettings

    Friend Owner As frmCVJoy
    Public MustOverride Function GameName() As String

    Public Sub New(pOwner As frmCVJoy)
        Owner = pOwner
    End Sub

    Public MustOverride Sub Start()
    Public MustOverride Sub [Stop]()
    Public MustOverride Function Started() As Boolean
    Public MustOverride Function Update() As clGameOutputs
    Public MustOverride Function UpdateExtra() As clGameOutputsExtra
    Public MustOverride Sub ShowSetup()
    Public WheelSensitivity As Single = 8.5

    Public Event StateChanged()
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


    Public Bt(17) As String
    Public BtDescr(17) As String

    ' these PP are used by Reflection in clSettings.SaveSettingstoFile() and LoadSettingsFromFile() !!!!
    Public Property Bts() As String
        Get
            Return String.Join("£", Bt)
        End Get
        Friend Set(value As String)
            Dim tmp() As String = value.Split("£"c)
            For i As Integer = 0 To Bt.Length - 1
                If i >= tmp.Length Then Exit For
                Bt(i) = tmp(i)
            Next
        End Set
    End Property

    Public Property BtDescrs() As String
        Get
            Return String.Join("£", BtDescr)
        End Get
        Friend Set(value As String)
            Dim tmp() As String = value.Split("£"c)
            For i As Integer = 0 To BtDescr.Length - 1
                If i >= tmp.Length Then Exit For
                BtDescr(i) = tmp(i)
            Next
        End Set
    End Property

End Class


Public Structure clGameOutputs ' info that needs updating very frequently
    Public Wind As Byte ' 0~255
    Public ShakePower As Byte  ' 0~255
    Public Pitch As Single ' radians
    Public Roll As Single ' radians

    Public SlipFL As Byte
    Public SlipFR As Byte
    Public SlipRL As Byte
    Public SlipRR As Byte
    Public Speed As Integer
    Public RPM As Integer
    Public Gear As Integer ' 0=" "  1="R"   2="N"  3="1"  4="2"...
    Public GearAuto As Boolean
    Public TyreDirtFL As Byte
    Public TyreDirtFR As Byte
    Public TyreDirtRL As Byte
    Public TyreDirtRR As Byte
End Structure


Public Structure clGameOutputsExtra ' info that needs updating 1 time per second
    Public RpmMax As Integer
    Public MaxFuel As Byte
    Public Fuel As Byte
    Public FuelAvg As Integer
    Public TyreWearFL As Byte
    Public TyreWearFR As Byte
    Public TyreWearRL As Byte
    Public TyreWearRR As Byte
    Public NumCars As Byte
    Public Position As Byte
    Public NumberOfLaps As Byte
    Public CompletedLaps As Byte
    Public DistanceTraveled As Integer
End Structure
