Imports System.Net
Imports System.Runtime.Remoting.Messaging
Imports System.Text

Public Class GameMotionSim
    Inherits clGame

    Public UdpIP As String = "127.0.0.1"
    Public UdpPort As Integer = 4444

    Private UdpClient As Net.Sockets.UdpClient
    Private LastUDPReceived As Date
    Private GameOutputs As clGameOutputs
    Private GameOutputsExtra As clGameOutputsExtra

    Public Sub New(pOwner As frmCVJoy)
        MyBase.New(pOwner)
    End Sub
    Public Overrides Function GameName() As String
        Return "MotionSim"
    End Function
    Public Overrides Function FileName() As String
        Return "SettingsMotionSim.INI"
    End Function

    Public Overrides Sub Start()
        Try
            If UdpClient IsNot Nothing Then Me.[Stop]()
            Dim RemoteIpEndPoint As IPEndPoint = New IPEndPoint(IPAddress.Parse(UdpIP), UdpPort)
            UdpClient = New Net.Sockets.UdpClient(RemoteIpEndPoint)
            UdpClient.BeginReceive(AddressOf ReceivedUdp, Nothing)
            State = "listening udp"
        Catch ex As Exception
            Me.[Stop]()
            MsgBox("btGameStart.Click " & ex.Message)
        End Try
    End Sub
    Public Overrides Sub [Stop]()
        If UdpClient IsNot Nothing Then
            UdpClient.Close()
        End If
        UdpClient = Nothing
        State = ""
    End Sub

    Public Overrides Function Started() As Boolean
        Return UdpClient IsNot Nothing
    End Function

    Public Sub ReceivedUdp(pIAsyncResult As IAsyncResult)
        Dim RemoteIpEndPoint As IPEndPoint = New IPEndPoint(IPAddress.Parse(UdpIP), UdpPort)
        If UdpClient Is Nothing Then Return
        Dim bytesReceived As Byte() = UdpClient.EndReceive(pIAsyncResult, RemoteIpEndPoint)

        If bytesReceived.Count >= 96 AndAlso bytesReceived(0) = 0 AndAlso bytesReceived(1) = 0 AndAlso bytesReceived(2) = 0 AndAlso bytesReceived(3) = 0 Then
            ' OutGauge protocol:
            LastUDPReceived = Now
            'Dim flags1 As UInt16 = BitConverter.ToUInt16(bytesReceived, 8)
            GameOutputs.Gear = bytesReceived(10) + 1
            ' (11)=0
            GameOutputs.Speed = BitConverter.ToSingle(bytesReceived, 12) * 3.6 ' m/s
            GameOutputs.RPM = BitConverter.ToSingle(bytesReceived, 16)
            GameOutputs.TurboBoost = BitConverter.ToSingle(bytesReceived, 20) ' bar  ' TODO:
            'Dim engTemp As Single = BitConverter.ToSingle(bytesReceived, 24) ' C
            GameOutputsExtra.MaxFuel = 55
            GameOutputsExtra.Fuel = BitConverter.ToSingle(bytesReceived, 28) * GameOutputsExtra.MaxFuel ' %

        ElseIf bytesReceived.Count >= 88 AndAlso bytesReceived(0) = 66 AndAlso bytesReceived(1) = 78 AndAlso bytesReceived(2) = 71 Then
            ' MotionSim protocol:
            'Dim posX As Single = BitConverter.ToSingle(bytesReceived, 4)
            'Dim posY As Single = BitConverter.ToSingle(bytesReceived, 8)
            'Dim posZ As Single = BitConverter.ToSingle(bytesReceived, 12)
            'Dim velX As Single = BitConverter.ToSingle(bytesReceived, 16)
            'Dim velY As Single = BitConverter.ToSingle(bytesReceived, 20)
            'Dim velZ As Single = BitConverter.ToSingle(bytesReceived, 24)
            'Dim accX As Single = BitConverter.ToSingle(bytesReceived, 28)
            'Dim accY As Single = BitConverter.ToSingle(bytesReceived, 32)
            GameOutputs.GameAccelZ = BitConverter.ToSingle(bytesReceived, 36)
            'Dim upX As Single = BitConverter.ToSingle(bytesReceived, 40)
            'Dim upY As Single = BitConverter.ToSingle(bytesReceived, 44)
            'Dim upZ As Single = BitConverter.ToSingle(bytesReceived, 48)
            GameOutputs.GameRoll = BitConverter.ToSingle(bytesReceived, 52)
            GameOutputs.GamePitch = BitConverter.ToSingle(bytesReceived, 56)
            'Dim yawpos As Single = BitConverter.ToSingle(bytesReceived, 60)
            'Dim rollvel As Single = BitConverter.ToSingle(bytesReceived, 64)
            'Dim pitchvel As Single = BitConverter.ToSingle(bytesReceived, 68)
            'Dim yawvel As Single = BitConverter.ToSingle(bytesReceived, 72)
            'Dim rollacc As Single = BitConverter.ToSingle(bytesReceived, 76)
            'Dim pitchacc As Single = BitConverter.ToSingle(bytesReceived, 80)
            'Dim yawacc As Single = BitConverter.ToSingle(bytesReceived, 84)

        End If

        If UdpClient Is Nothing Then
            Me.Stop()
        Else
            UdpClient.BeginReceive(AddressOf ReceivedUdp, Nothing)
        End If
    End Sub

    Public Overrides Function GetGameOutputs() As clGameOutputs
        If Now.Subtract(LastUDPReceived).TotalMilliseconds > 1000 Then
            State = "PAUSED"
            Return clGameOutputs.PausedGameOutputs(fromArduino.AccelCorrected)  'If tmpFrm IsNot Nothing Then Integer.TryParse(tmpFrm.lbACSpeed.Text, ACP.SpeedKmh) ' if not connected to AC, user can input data to simulate AC
        End If
        State = "RUNNING"
        GameOutputs.Calculate()
        Return GameOutputs
    End Function

    Public Overrides Function GetGameOutputsExtra() As clGameOutputsExtra
        Return GameOutputsExtra
    End Function



    Public Function SetupForm() As frmSetupMotionSim
        If Owner.OwnedForms.Any(Function(f) TypeOf f Is frmSetupMotionSim) Then
            Return Owner.OwnedForms.First(Function(f) TypeOf f Is frmSetupMotionSim)
        End If
        Return Nothing
    End Function

    Public Overrides Sub ShowSetup()
        Dim tmpFrm As frmSetupMotionSim = SetupForm()
        If tmpFrm IsNot Nothing Then
            tmpFrm.Show()
        Else
            tmpFrm = New frmSetupMotionSim
            tmpFrm.Init(Owner, Me)
        End If
    End Sub


End Class


