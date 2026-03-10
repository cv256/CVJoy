Imports System.Net
Imports System.Text

Public Class clButtonBox
    Public Configuration As String
    Public Sub New()
        Configuration = "" ' Row {vbTab} Column {vbTab} Text {vbTab} Command {vbTab} Icon
        Configuration += $"|0{vbTab}0{vbTab}Belt{vbTab}{vbTab}belt.png"
        Configuration += $"|0{vbTab}1{vbTab}Engine{vbTab}{vbTab}engine.png"
        Configuration += $"|0{vbTab}2{vbTab}Break{vbTab}{vbTab}park.png"
        Configuration += $"|0{vbTab}3{vbTab}Hazard{vbTab}{vbTab}hazard.png"

        Configuration += $"|1{vbTab}0{vbTab}Lights{vbTab}{vbTab}lights.png"
        Configuration += $"|1{vbTab}1{vbTab}Horn{vbTab}{vbTab}horn.png"
        Configuration += $"|1{vbTab}2{vbTab}Wipers{vbTab}{vbTab}wiper.png"

        Configuration += $"|2{vbTab}0{vbTab}Camera{vbTab}{vbTab}"
        Configuration += $"|2{vbTab}1{vbTab}Map{vbTab}{vbTab}"
        Configuration += $"|2{vbTab}2{vbTab}GPS{vbTab}{vbTab}"

        Configuration += $"|0{vbTab}5{vbTab}Yes{vbTab}{vbTab}yes.png"
        Configuration += $"|0{vbTab}6{vbTab}Up{vbTab}{vbTab}"
        Configuration += $"|0{vbTab}7{vbTab}Menu{vbTab}{vbTab}"

        Configuration += $"|1{vbTab}4{vbTab}Calibrate{vbTab}reset{vbTab}steer.png"

        Configuration += $"|1{vbTab}5{vbTab}Left{vbTab}{vbTab}"
        Configuration += $"|1{vbTab}6{vbTab}Action{vbTab}{vbTab}fault.png"
        Configuration += $"|1{vbTab}7{vbTab}Right{vbTab}{vbTab}"

        Configuration += $"|2{vbTab}5{vbTab}No{vbTab}{vbTab}no.png"
        Configuration += $"|2{vbTab}6{vbTab}Down{vbTab}{vbTab}"
        Configuration += $"|2{vbTab}7{vbTab}Esc{vbTab}{vbTab}"
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
