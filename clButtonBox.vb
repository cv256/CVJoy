Imports System.Net
Imports System.Text

Public Class clButtonBox
    Public Configuration As String

    Private UdpClient45001 As Sockets.UdpClient
    Private FrmMain As frmCVJoy

    Public Sub New()
        Configuration = "" ' Row {vbTab} Column {vbTab} Text {vbTab} Command {vbTab} Icon
        Configuration += $"|0{vbTab}0{vbTab}Belt{vbTab}{vbTab}belt.png"
        Configuration += $"|0{vbTab}1{vbTab}Engine{vbTab}e{vbTab}engine.png" ' engine start
        Configuration += $"|0{vbTab}2{vbTab}Break{vbTab}b{vbTab}park.png" ' handbreak
        Configuration += $"|0{vbTab}3{vbTab}Hazard{vbTab}x{vbTab}hazard.png" '' hazard lights

        Configuration += $"|1{vbTab}0{vbTab}Lights{vbTab}l{vbTab}lights.png" ' lights
        Configuration += $"|1{vbTab}1{vbTab}Horn{vbTab}h{vbTab}horn.png" ' horn
        Configuration += $"|1{vbTab}2{vbTab}Wipers{vbTab}w{vbTab}wiper.png" ' wipers speed up

        Configuration += $"|2{vbTab}0{vbTab}Gears{vbTab}^g{vbTab}" ' auto gears
        Configuration += $"|2{vbTab}1{vbTab}Map{vbTab}{vbTab}"
        Configuration += $"|2{vbTab}2{vbTab}GPS{vbTab}{vbTab}"

        Configuration += $"|0{vbTab}5{vbTab}Yes{vbTab}y{vbTab}yes.png"
        Configuration += $"|0{vbTab}6{vbTab}Up{vbTab}{{UP}}{vbTab}"
        Configuration += $"|0{vbTab}7{vbTab}Menu{vbTab}{{HOME}}{vbTab}"

        Configuration += $"|1{vbTab}4{vbTab}Calibrate{vbTab}reset{vbTab}steer.png" ' reset wheel and ff

        Configuration += $"|1{vbTab}5{vbTab}Left{vbTab}{{LEFT}}{vbTab}" ' look left
        Configuration += $"|1{vbTab}6{vbTab}Action{vbTab}^j{vbTab}fault.png" ' ^g = toggle damage display  '  ^j = show damage display
        Configuration += $"|1{vbTab}7{vbTab}Right{vbTab}{{RIGHT}}{vbTab}" ' look right

        Configuration += $"|2{vbTab}5{vbTab}No{vbTab}n{vbTab}no.png"
        Configuration += $"|2{vbTab}6{vbTab}Down{vbTab}{{DOWN}}{vbTab}" ' look back
        Configuration += $"|2{vbTab}7{vbTab}Esc{vbTab}{{ESC}}{vbTab}" ' esc
    End Sub

    Public Sub StartListening(pFrmMain As frmCVJoy)
        FrmMain = pFrmMain
        Dim RemoteIpEndPoint As IPEndPoint = New IPEndPoint(IPAddress.Any, 45001)
        UdpClient45001 = New Net.Sockets.UdpClient(RemoteIpEndPoint)
        UdpClient45001.BeginReceive(AddressOf ReceivedUdp, Nothing)
    End Sub

    Public Sub ReceivedUdp(pIAsyncResult As IAsyncResult)
        If UdpClient45001 Is Nothing Then Return
        Dim RemoteIpEndPoint As IPEndPoint = New IPEndPoint(IPAddress.Parse(SettingsMain.UdpIp), 45001)
        Dim bytesReceived As Byte() = UdpClient45001.EndReceive(pIAsyncResult, RemoteIpEndPoint)

        If bytesReceived(0) = 253 Then
            Dim s As String = System.Text.Encoding.ASCII.GetString(bytesReceived, 1, bytesReceived.Length - 1)
            Dim c As String = GetAction(s)
            FrmMain.MySendKeys(c)
        Else
            FrmMain.ErrorAdd($"Unexpected UDP received on {RemoteIpEndPoint.ToString}", $"header={bytesReceived(0)}")
        End If

        If Not UdpClient45001 Is Nothing Then UdpClient45001.BeginReceive(AddressOf ReceivedUdp, Nothing)
    End Sub

    Public Function GetAction(pText As String) As String
        Dim confs() As String = Configuration.Split("|"c)
        Dim conf = confs.FirstOrDefault(Function(c) Not String.IsNullOrEmpty(c) AndAlso c.Split(vbTab)(2) = pText)
        If conf Is Nothing Then Return ""
        Dim Parts() As String = conf.Split(vbTab)
        If Parts.Length >= 3 Then Return Parts(3) ' Command
        Return ""
    End Function

    ''' <summary>
    ''' Send ButtonBox configuation to the CVJoyMAUI apps.
    ''' Throws Errors !
    ''' </summary>
    Public Sub SendConfiguration()
        Dim udpBytes As Byte() = Encoding.ASCII.GetBytes("?" & Configuration)
        udpBytes(0) = 254
        Dim udpClient As New Sockets.UdpClient(SettingsMain.UdpIp, 45000)
        udpClient.SendAsync(udpBytes, udpBytes.Length)
    End Sub

End Class
