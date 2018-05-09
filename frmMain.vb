Imports System.IO.Ports


Public Class frmCVJoy
    Public TimerProcessing As Boolean = False
    Public Joy As vJoyInterfaceWrap.vJoy ' http://vjoystick.sourceforge.net/site/includes/SDK_ReadMe.pdf
    Private WheelPosition As Single ' -16380 ~ 0 ~ 16380
    Private LastWheelDate As DateTime, LastWheelPosition As Integer
    Private FFGain As Single = 255
    Public FFWheel_Type As FFBEType
    Public FFWheel_Cond As New vJoyInterfaceWrap.vJoy.FFB_EFF_COND
    Public FFWheel_Const As New vJoyInterfaceWrap.vJoy.FFB_EFF_CONSTANT

    Private _realLeft As Single, _realRight As Single ' position now (from sensor) in milimeters, tipically from   minus GMaxScrewDown    to    Zero (center)    to    GMaxScrewUp
    Private _realOKLeft As Single, _realOKRight As Single ' position now (from sensor plus corrections) in milimeters, tipically from   minus GMaxScrewDown    to    Zero (center)    to    GMaxScrewUp
    Private _lastLeftMotorSpeed As Single, _lastRightMotorSpeed As Single ' -100~100 negative=bolt going down
    Private _motorOverHeat As Single
    Private ArduinoLastRead As DateTime = Now.AddSeconds(-1) ' time of last good reading

    Public Enum Motor
        None
        Wheel
        Pitch
        Roll
        Left
        Right
        Wind
        Shake
    End Enum
    Public TestMode As Motor, TestValue As Integer = 0


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text &= "  " & Application.ProductVersion
        cbLog.Items.Add("Don't Log")
        cbLog.Items.Add("Log")
        cbLog.Items.Add("Log + FF")
        cbLog.Items.Add("Log + FF Extra")
        cbLog.SelectedIndex = 1

        cbGames.Items.Add("Assetto Corsa")

        SettingsMain.LoadSettingsFromFile()
        cbGames.SelectedIndex = 0 ' TODO: SettingsMain should keep that last cbGames.SelectedIndex used, and here we should use that

        Timer1.Interval = 1000 / SettingsMain.RefreshRate
        Timer1.Enabled = True

        MouseRaw.Register(Me.Handle)

        btVJoy_Click()
    End Sub


    Private Sub cbGames_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGames.SelectedIndexChanged
        If Game IsNot Nothing Then Game.Stop()
        Game = New GameAC(Me) ' TODO: use cbGames.Selecteditem
        AddHandler Game.StateChanged, AddressOf GameStateChanged
        Game.LoadSettingsFromFile()
        UcButtons1.ShowSettings(Game)
        UcButtons1.ReadOnly = True
    End Sub

    Private Sub GameStateChanged() ' Handles Game.StateChanged
        btGameStart.Text = If(Game.Started, "Disconnect from", "Connect to")
        lbGameInfo.Text = "    " & Game.GameName & ": " & Game.State
    End Sub

    Public Sub GameStart(sender As Object, e As EventArgs) Handles btGameStart.Click
        If Game Is Nothing Then Exit Sub
        If Game.Started Then Game.Stop() Else Game.Start()
    End Sub

    Public Sub GameSetup(sender As Object, e As EventArgs) Handles btGameSetup.Click
        Game.ShowSetup()
    End Sub


    Public Sub ArduinoStart(sender As Object, e As EventArgs) Handles btArduinoStart.Click
        If SerialPort1.IsOpen Then
            SerialPort1.DiscardInBuffer()
            SerialPort1.Close()
            btArduinoStart.Text = "Start"
        Else
            Try
                SerialPort1.PortName = SettingsMain.ArduinoComPort
                SerialPort1.ReceivedBytesThreshold = SerialRead.PacketLen
                ' SerialPort1.WriteBufferSize = SerialSend.PacketLen
                SerialPort1.Open()
                SerialPort1.DiscardInBuffer()
                btArduinoStart.Text = "Stop"
            Catch ex As Exception
                MsgBox("btArduinoStart.Click " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If TimerProcessing Then
            ErrorAdd("Cant stand such hight Refresh Rate, lower it.")
            Return
        End If
        TimerProcessing = True ' NEVER use RETURN   ,  use  GoTo goReturn  !!!!!
        'timeStart = Now

        ' get realtime data from the Game :
        Dim GameOutputs As clGameOutputs
        If Game IsNot Nothing Then GameOutputs = Game.Update()

        ' prepare data to send to the Arduino :
        Dim toArduino As New SerialSend
        With toArduino
            If TestMode = Motor.Wheel Then
                .wheelPower = TestValue
            Else
                If WheelPosition <= -16380 Then
                    .wheelPower = -255
                ElseIf WheelPosition >= 16380 Then
                    .wheelPower = 255
                Else
                    .wheelPower = FFSteer(WheelPosition)
                End If
            End If

            If TestMode = Motor.Wind Then
                .windPower = TestValue
            ElseIf Not chkNoWind.Checked Then
                .windPower = CalculateOutput(GameOutputs.Wind, 255, 1, SettingsMain.WindMinPower, SettingsMain.WindGama, 1)
            Else
                .windPower = 0
            End If

            If TestMode = Motor.Shake Then
                .shakePower = TestValue
            ElseIf Not chkNoWind.Checked Then
                .shakePower = CalculateOutput(GameOutputs.Shake, 255, 1, SettingsMain.ShakeMinPower, SettingsMain.ShakeGama, 1)
            Else
                .shakePower = 0
            End If

            .LedTop = GameOutputs.LedTop
            .LedBottom = GameOutputs.LedBottom
            .LedLeft = GameOutputs.LedLeft
            .LedRight = GameOutputs.LedRight

#Region "PowerFromAngle: calculates power to apply now, based on the previous position readings"

            ' convert Desired Angles into Desired Screw Positions:
            Dim DesiredLeftScrew As Integer = -SettingsMain.GZDistance * Math.Sin(GameOutputs.Pitch) + SettingsMain.GXDistance * Math.Sin(GameOutputs.Roll) ' in mm
            Dim DesiredRightScrew As Integer = -SettingsMain.GZDistance * Math.Sin(GameOutputs.Pitch) - SettingsMain.GXDistance * Math.Sin(GameOutputs.Roll) ' in mm
            If DesiredLeftScrew > SettingsMain.GMaxScrewUp Then DesiredLeftScrew = SettingsMain.GMaxScrewUp
            If DesiredLeftScrew < -SettingsMain.GMaxScrewDown Then DesiredLeftScrew = -SettingsMain.GMaxScrewDown
            If DesiredRightScrew > SettingsMain.GMaxScrewUp Then DesiredRightScrew = SettingsMain.GMaxScrewUp
            If DesiredRightScrew < -SettingsMain.GMaxScrewDown Then DesiredRightScrew = -SettingsMain.GMaxScrewDown

            Const PowerInertia As Single = 0.86
            Dim leftMotorSpeed As Single = _lastLeftMotorSpeed * PowerInertia
            Dim rightMotorSpeed As Single = _lastRightMotorSpeed * PowerInertia
            ' calculate power to apply on Left and Right Motors:
            .leftPower = 0
            .rightPower = 0
            Dim GMinDiffProtected As Integer = SettingsMain.GMinDiff
            If Now.Subtract(ArduinoLastRead).TotalMilliseconds > 200 _
            AndAlso SerialPort1.IsOpen Then ' SHIIIT, stop everything ! dont even try to correct it, wires, relays or screws may be swaped or broken !
                ErrorAdd($"NO POSITION DATA FROM ARDUINO !   last read {(Now.Subtract(ArduinoLastRead).TotalMilliseconds / 1000).ToString("0.00")} seconds ago")
            ElseIf (_realOKLeft > (SettingsMain.GMaxScrewUp + SettingsMain.GMinDiff * 2) _
            OrElse _realOKLeft < -(SettingsMain.GMaxScrewDown + SettingsMain.GMinDiff * 2) _
            OrElse _realOKRight > (SettingsMain.GMaxScrewUp + SettingsMain.GMinDiff * 2) _
            OrElse _realOKRight < -(SettingsMain.GMaxScrewDown + SettingsMain.GMinDiff * 2)) _
            AndAlso SerialPort1.IsOpen Then ' SHIIIT, stop everything ! dont even try to correct it, wires, relays or screws may be swaped or broken !
                ErrorAdd($"OUT OF BOUNDS !   LeftPosition={CInt(_realOKLeft)}mm     RightPosition={CInt(_realOKRight)}mm")
            Else ' No shit, normal :
                Dim leftDiff As Integer = 0 ' positive = bolt is downer than what we want (car attitude is too up)
                Dim rightDiff As Integer = 0
                If TestMode = Motor.Pitch Then
                    leftDiff = TestValue
                    rightDiff = TestValue
                ElseIf TestMode = Motor.Roll Then
                    leftDiff = TestValue
                    rightDiff = -TestValue
                ElseIf TestMode = Motor.Left Then
                    leftDiff = TestValue
                ElseIf TestMode = Motor.Right Then
                    rightDiff = TestValue
                ElseIf Not chkNoMotors.Checked Then
                    leftDiff = DesiredLeftScrew - _realOKLeft
                    rightDiff = DesiredRightScrew - _realOKRight
                    GMinDiffProtected = SettingsMain.GMinDiff + _motorOverHeat  '  if motors's temperature is getting to hight, widen deadzone, avoid details, do just the most important moves
                End If
                If leftDiff >= If(_lastLeftMotorSpeed >= SettingsMain.GMinMotorEfficiency, 1, GMinDiffProtected) Then
                    If _realOKLeft >= SettingsMain.GMaxScrewUp Then ' no more power up here, we are at the upper limit
                    Else ' push the bolt up:
                        .leftPower = Math.Min(127, ScaleValue(leftDiff, 0, SettingsMain.GMaxDiff, SettingsMain.GPowerForMin, 127))
                        leftMotorSpeed += ScaleValue(.leftPower, SettingsMain.GPowerForMin, 127, SettingsMain.GMinMotorEfficiency, SettingsMain.GMaxMotorEfficiency) * (1 - PowerInertia)
                    End If
                ElseIf leftDiff <= -If(_lastLeftMotorSpeed <= -SettingsMain.GMinMotorEfficiency, 1, GMinDiffProtected) Then
                    If _realOKLeft <= -SettingsMain.GMaxScrewDown Then ' no more power down here, we are at the lower limit
                    Else ' push the bolt down:
                        .leftPower = -Math.Min(127, ScaleValue(-leftDiff, 0, SettingsMain.GMaxDiff, SettingsMain.GPowerForMin, 127))
                        leftMotorSpeed += -ScaleValue(- .leftPower, SettingsMain.GPowerForMin, 127, SettingsMain.GMinMotorEfficiency, SettingsMain.GMaxMotorEfficiency) * (1 - PowerInertia)
                    End If
                End If
                If rightDiff >= If(_lastRightMotorSpeed >= SettingsMain.GMinMotorEfficiency, 1, GMinDiffProtected) Then
                    If _realOKRight >= SettingsMain.GMaxScrewUp Then ' no more power up here, we are at the upper limit
                    Else ' push the bolt up:
                        .rightPower = Math.Min(127, ScaleValue(rightDiff, 0, SettingsMain.GMaxDiff, SettingsMain.GPowerForMin, 127))
                        rightMotorSpeed += ScaleValue(.rightPower, SettingsMain.GPowerForMin, 127, SettingsMain.GMinMotorEfficiency, SettingsMain.GMaxMotorEfficiency) * (1 - PowerInertia)
                    End If
                ElseIf rightDiff <= -If(_lastRightMotorSpeed <= -SettingsMain.GMinMotorEfficiency, 1, GMinDiffProtected) Then
                    If _realOKRight <= -SettingsMain.GMaxScrewDown Then ' no more power down here, we are at the lower limit
                    Else ' push the bolt down:
                        .rightPower = -Math.Min(127, ScaleValue(-rightDiff, 0, SettingsMain.GMaxDiff, SettingsMain.GPowerForMin, 127))
                        rightMotorSpeed += -ScaleValue(- .rightPower, SettingsMain.GPowerForMin, 127, SettingsMain.GMinMotorEfficiency, SettingsMain.GMaxMotorEfficiency) * (1 - PowerInertia)
                    End If
                End If
            End If

            ' guess motors's temperature: TODO: we should compare LastPower versus Power, not LastSpeed against Power ?
            If Math.Sign(_lastLeftMotorSpeed) <> Math.Sign(.leftPower) AndAlso _lastLeftMotorSpeed <> 0 AndAlso .leftPower <> 0 Then _motorOverHeat += Math.Abs(_lastLeftMotorSpeed - .leftPower) / 8000
            If Math.Sign(_lastRightMotorSpeed) <> Math.Sign(.rightPower) AndAlso _lastRightMotorSpeed <> 0 AndAlso .rightPower <> 0 Then _motorOverHeat += Math.Abs(_lastRightMotorSpeed - .rightPower) / 8000
            _motorOverHeat *= 0.9975
            _lastLeftMotorSpeed = leftMotorSpeed
            _lastRightMotorSpeed = rightMotorSpeed

            ' this is the real reading, damped, plus the compensation for the lag introduced by the damping of the real data... (we have to guess the actual position)
            _realOKLeft = _realOKLeft * SettingsMain.UltrasonicDamper + _realLeft * (1 - SettingsMain.UltrasonicDamper) + leftMotorSpeed / 40 * SettingsMain.UltrasonicDamper
            _realOKRight = _realOKRight * SettingsMain.UltrasonicDamper + _realRight * (1 - SettingsMain.UltrasonicDamper) + rightMotorSpeed / 40 * SettingsMain.UltrasonicDamper

            ' graph:
            If Ggraph IsNot Nothing Then Ggraph.UpdateValue(GMinDiffProtected, _realLeft, _realRight, _realOKLeft, _realOKRight, DesiredLeftScrew, DesiredRightScrew, .leftPower, .rightPower, leftMotorSpeed, rightMotorSpeed)

            ' draw Attitude:
            If Me.WindowState <> FormWindowState.Minimized AndAlso ckDontShow.Checked = False Then
                lbTemperature.Text = _motorOverHeat.ToString("0.0")
                With lbAttitude.CreateGraphics()
                    Dim centerX As Integer = lbAttitude.Width / 2, centerY As Integer = lbAttitude.Height / 2
                    Dim backcolor As Color = Color.White ' If(_realPitch > SettingsMain.MaxPitch OrElse _realPitch < -SettingsMain.MinPitch, Color.Red, Color.White)
                    .Clear(backcolor)
                    ' paint red squares if overflowing:
                    If DesiredLeftScrew >= SettingsMain.GMaxScrewUp Then .FillRectangle(New SolidBrush(Color.Red), 0, 0, centerX, centerY)
                    If DesiredLeftScrew <= -SettingsMain.GMaxScrewDown Then .FillRectangle(New SolidBrush(Color.Red), 0, centerY, centerX, centerY)
                    If DesiredRightScrew >= SettingsMain.GMaxScrewUp Then .FillRectangle(New SolidBrush(Color.Red), centerX, 0, centerX, centerY)
                    If DesiredRightScrew <= -SettingsMain.GMaxScrewDown Then .FillRectangle(New SolidBrush(Color.Red), centerX, centerY, centerX, centerY)
                    ' draw center cross:
                    .DrawLine(Pens.Green, centerX - 8, centerY, centerX + 8, centerY) : .DrawLine(Pens.Green, centerX, centerY - 8, centerX, centerY + 8)
                    Dim racioY As Single = centerY / Math.Max(SettingsMain.GMaxScrewUp, SettingsMain.GMaxScrewDown)
                    ' draw desired position line:
                    .DrawLine(Pens.Green, 0, centerY - CInt(DesiredLeftScrew * racioY), lbAttitude.Width, centerY - CInt(DesiredRightScrew * racioY))
                    ' draw real position line:
                    .DrawLine(Pens.Black, 0, centerY - CInt(_realOKLeft * racioY), lbAttitude.Width, centerY - CInt(_realOKRight * racioY))
                End With
            End If
#End Region

        End With

        Dim fromArduino As New SerialRead
        If SerialPort1.IsOpen Then
            ' SEND SERIAL DATA TO ARDUINO:
            SerialPort1.DiscardOutBuffer()
            'timeSent = Now
            SerialPort1.Write(toArduino.GetSerialData, 0, SerialSend.PacketLen)

            ' READ SERIAL DATA FROM ARDUINO:
            Dim timeRead As Date = Now
            Do Until SerialPort1.BytesToRead >= SerialRead.PacketLen
                Threading.Thread.Sleep(10)
                If Now.Subtract(timeRead).TotalMilliseconds > 500 Then
                    ErrorAdd("NORESPONSE SerialPort1.BytesToRead=" & SerialPort1.BytesToRead)
                    GoTo goReturn
                End If
            Loop
            'timeRead = Now
            Try
                Dim BytesToRead As Integer = SerialPort1.BytesToRead
                If BytesToRead <> SerialRead.PacketLen Then
                    ErrorAdd("UNEXPECTED SerialPort1.BytesToRead=" & BytesToRead)
                    If BytesToRead > 0 Then ' discard this lost bytes
                        Dim xbuf(BytesToRead - 1) As Byte
                        SerialPort1.Read(xbuf, 0, xbuf.Length)
                    End If
                    GoTo goReturn
                End If
                Dim buf(BytesToRead - 1) As Byte
                SerialPort1.Read(buf, 0, buf.Length)
                If buf(0) <> 170 AndAlso buf(0) <> 171 Then
                    ErrorAdd("UNEXPECTED SerialPort1.buf(0)=" & buf(0))
                    GoTo goReturn
                End If
                fromArduino.SetSerialData(buf) ' this fills fromArduino with the data red from the Arduino !!
            Catch ex As Exception
                ErrorAdd("SerialPort1.DataReceived  " & ex.Message)
                GoTo goReturn
            End Try

            ArduinoLastRead = Now
            _realLeft = fromArduino.RealLeft - SettingsMain.GLeftScrewCenter
            _realRight = fromArduino.RealRight - SettingsMain.GRightScrewCenter
        End If

#Region "buttons:  emulate keystrokes  or  send as joystick buttons"
        Static oldbutton1 As Boolean, oldbutton2 As TriState  ' button being pressed
        With fromArduino
            If .button1 Then ' if button1 is being pressed:      https://msdn.microsoft.com/en-us/library/system.windows.forms.sendkeys.send(v=vs.110).aspx
                If oldbutton1 = False Then ' if we just started pressing button1:
                    oldbutton1 = True
                    oldbutton2 = TriState.UseDefault
                End If
                If .button2 Then
                    If oldbutton2 <> TriState.True Then
                        If Game.bt2 > "" Then SendKeys.Send(Game.bt2)
                        oldbutton2 = TriState.True
                    End If
                ElseIf .button3 Then
                    If oldbutton2 <> TriState.True Then
                        If Game.bt3 > "" Then SendKeys.Send(Game.bt3)
                        oldbutton2 = TriState.True
                    End If
                ElseIf .button4 Then
                    If oldbutton2 <> TriState.True Then
                        If Game.bt4 > "" Then SendKeys.Send(Game.bt4)
                        oldbutton2 = TriState.True
                    End If
                ElseIf .button5 Then
                    If oldbutton2 <> TriState.True Then
                        If Game.bt5 > "" Then SendKeys.Send(Game.bt5)
                        oldbutton2 = TriState.True
                    End If
                ElseIf .button6 Then
                    If oldbutton2 <> TriState.True Then
                        If Game.bt6 > "" Then SendKeys.Send(Game.bt6)
                        oldbutton2 = TriState.True
                    End If
                ElseIf .button7 Then
                    If oldbutton2 <> TriState.True Then
                        If Game.bt7 > "" Then SendKeys.Send(Game.bt7)
                        oldbutton2 = TriState.True
                    End If
                ElseIf .button8 Then
                    If oldbutton2 <> TriState.True Then
                        If Game.bt8 > "" Then SendKeys.Send(Game.bt8)
                        oldbutton2 = TriState.True
                    End If
                ElseIf .button9 Then
                    If oldbutton2 <> TriState.True Then
                        If Game.bt9 > "" Then SendKeys.Send(Game.bt9)
                        oldbutton2 = TriState.True
                    End If
                Else
                    If oldbutton2 = TriState.True Then oldbutton2 = TriState.False
                End If
            Else ' if button1 is not being pressed now:
                If oldbutton1 = True Then ' if we just released it:
                    oldbutton1 = False
                    If oldbutton2 = TriState.UseDefault Then SendKeys.Send("{ESC}") ' if we simply press and depress button1 (no other buttons) send ESC
                Else ' normal, send buttons as joystick buttons:
                    ' send to VJoy:
                    If Joy IsNot Nothing Then
                        Dim j As New vJoyInterfaceWrap.vJoy.JoystickState
                        j.AxisX = If(Math.Abs(WheelPosition) > SettingsMain.WheelDead, Math.Max(0, Math.Min(32767, WheelPosition + 16384)), 16384)  ' 0-16384-32767
                        j.AxisY = .AccelCorrected * 32 ' 0-32767
                        j.AxisZ = .BrakeCorrected * 32 ' 0-32767
                        j.AxisXRot = .ClutchCorrected * 32 ' 0-32767
                        j.Buttons = If(.button1, 1, 0) _
                            + If(.button2, 2, 0) _
                            + If(.button3, 4, 0) _
                            + If(.button4, 8, 0) _
                            + If(.button5, 16, 0) _
                            + If(.button6, 32, 0) _
                            + If(.button7, 64, 0) _
                            + If(.button8, 128, 0) _
                            + If(.button9, 256, 0) _
                            + If(.gear1, 1024, 0) _
                            + If(.gear2, 2048, 0) _
                            + If(.gear3, 4096, 0) _
                            + If(.gear4, 8192, 0) _
                            + If(.gear5, 16384, 0) _
                            + If(.gear6, 32768, 0) _
                            + If(.gearR, 65536, 0) _
                            + If(.handbrake, 131072, 0)
                        Joy.UpdateVJD(SettingsMain.vJoyId, j)
                    End If
                End If
            End If
        End With
#End Region

        ' show lights on screen:
        If Me.WindowState <> FormWindowState.Minimized AndAlso ckDontShow.Checked = False Then
            With toArduino
                lbLedLeft.BackColor = If(.LedLeft, Color.Green, Color.White)
                lbLedRight.BackColor = If(.LedRight, Color.Orange, Color.White)
                lbLedTop.BackColor = If(.LedTop, Color.Red, Color.White)
                lbLedBottom.BackColor = If(.LedBottom, Color.SkyBlue, Color.White)
                Dim g As System.Drawing.Graphics = lbWheelPos.CreateGraphics()
                g.Clear(Color.White)
                Dim xHalf As Integer = CInt(lbWheelPos.Width / 2)
                g.DrawLine(If(Math.Abs(WheelPosition) >= 16380, Pens.Red, Pens.Blue), xHalf, 1, CInt(xHalf * (1 + WheelPosition / 16384)), 1)
                g.DrawLine(If(Math.Abs(.wheelPower) >= 235, If(Math.Abs(.wheelPower) >= 235, Pens.Red, Pens.Orange), Pens.Blue), xHalf, 7, CInt(xHalf * (1 - .wheelPower / 255)), 7)
                g.DrawLine(Pens.Green, xHalf, 3, CInt(xHalf * (1 - FFWheel_Const.Magnitude / 10000)), 3)
                Dim xCP As Integer = CInt(xHalf * (1 - FFWheel_Cond.CenterPointOffset / 10000))
                g.DrawLine(Pens.DarkOrchid, xCP - 1, 5, xCP - CInt(xHalf * FFWheel_Cond.NegCoeff / 10000), 5)
                g.DrawLine(Pens.DarkOrchid, xCP + 1, 5, xCP + CInt(xHalf * FFWheel_Cond.PosCoeff / 10000), 5)
                lbWheelPos.ResumeLayout()
            End With
            With fromArduino
                lbAccel.Text = .pedalAccel
                lbBrake.Text = .pedalBreak
                lbClutch.Text = .pedalClutch
                G1.BackColor = If(.gear1, Color.Green, Color.White)
                G2.BackColor = If(.gear2, Color.Green, Color.White)
                G3.BackColor = If(.gear3, Color.Green, Color.White)
                G4.BackColor = If(.gear4, Color.Green, Color.White)
                G5.BackColor = If(.gear5, Color.Green, Color.White)
                G6.BackColor = If(.gear6, Color.Green, Color.White)
                GR.BackColor = If(.gearR, Color.Green, Color.White)
                lbHandbrake.BackColor = If(.handbrake, Color.Green, Color.White)
                UcButtons1.bt1.BackColor = If(.button1, Color.Green, Color.White)
                UcButtons1.bt2.BackColor = If(.button2, Color.Green, Color.White)
                UcButtons1.bt3.BackColor = If(.button3, Color.Green, Color.White)
                UcButtons1.bt4.BackColor = If(.button4, Color.Green, Color.White)
                UcButtons1.bt5.BackColor = If(.button5, Color.Green, Color.White)
                UcButtons1.bt6.BackColor = If(.button6, Color.Green, Color.White)
                UcButtons1.bt7.BackColor = If(.button7, Color.Green, Color.White)
                UcButtons1.bt8.BackColor = If(.button8, Color.Green, Color.White)
                UcButtons1.bt9.BackColor = If(.button9, Color.Green, Color.White)
            End With
        End If

        If graph IsNot Nothing Then graph.UpdatePedals(fromArduino)

goReturn:
        'txtErrors.Text = Now.Subtract(timeStart).Ticks.ToString("0000000") & "    " & timeRead.Subtract(timeSent).Ticks.ToString("0000000")
        TimerProcessing = False
    End Sub




    Private Sub btWheelCenter_Click(sender As Object, e As EventArgs) Handles btWheelCenter.Click
        WheelPosition = 0 'SettingsMain.WheelCenter = CInt(lbWheelPosNr.Text)
    End Sub






    Public Structure SerialSend
        Public wheelPower As Integer ' -255~255  0=no force
        Public leftPower As SByte  ' -127~127  0=no force
        Public rightPower As SByte ' -127~127  0=no force
        Public windPower As Byte
        Public shakePower As Byte
        Public LedLeft As Boolean
        Public LedRight As Boolean
        Public LedTop As Boolean
        Public LedBottom As Boolean

        Public Const PacketLen As Byte = 7

        Public Function GetSerialData() As Byte()
            Dim res(PacketLen - 1) As Byte
            res(0) = If(wheelPower < 0, 254, 255) ' checkdigit + wheelPowerDir
            res(1) = Math.Abs(wheelPower)
            res(2) = leftPower + 128
            res(3) = rightPower + 128
            res(4) = windPower
            res(5) = shakePower
            If LedLeft Then res(6) += 1
            If LedRight Then res(6) += 2
            If LedTop Then res(6) += 4
            If LedBottom Then res(6) += 8
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
        Public button1 As Boolean
        Public button2 As Boolean
        Public button3 As Boolean
        Public button4 As Boolean
        Public button5 As Boolean
        Public button6 As Boolean
        Public button7 As Boolean
        Public button8 As Boolean
        Public button9 As Boolean

        Public AccelCorrected As Integer
        Public BrakeCorrected As Integer
        Public ClutchCorrected As Integer

        Public RealLeft As Single
        Public RealRight As Single


        Public Const PacketLen As Byte = 13

        Public Sub SetSerialData(pSerialData As Byte())
            button9 = (pSerialData(0) And 1) <> 0
            button1 = (pSerialData(1) And 1) <> 0
            button2 = (pSerialData(1) And 2) <> 0
            button3 = (pSerialData(1) And 4) <> 0
            button4 = (pSerialData(1) And 8) <> 0
            button5 = (pSerialData(1) And 16) <> 0
            button6 = (pSerialData(1) And 32) <> 0
            button7 = (pSerialData(1) And 64) <> 0
            button8 = (pSerialData(1) And 128) <> 0
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

            Const soundSpeed As Single = 0.172922 ' 331300 + 606 * tempAirCelsius / 1000000 / 2   =   mm per microsecond , go and return  <=>  34cm =  0,002 seconds
            RealLeft = CSng(pSerialData(9) + pSerialData(10) * 256) * soundSpeed
            RealRight = CSng(pSerialData(11) + pSerialData(12) * 256) * soundSpeed

            ' corrected analogic values:
            AccelCorrected = ScaleValue(pedalAccel, SettingsMain.AccelMin, SettingsMain.AccelMax, 0, 1023, SettingsMain.AccelGama)
            BrakeCorrected = ScaleValue(pedalBreak, SettingsMain.BrakeMin, SettingsMain.BrakeMax, 0, 1023, SettingsMain.BrakeGama)
            ClutchCorrected = ScaleValue(pedalClutch, SettingsMain.ClutchMin, SettingsMain.ClutchMax, 0, 1023, SettingsMain.ClutchGama)
        End Sub
    End Class



    Private Sub btSetup_Click(sender As Object, e As EventArgs) Handles btSetup.Click
        If Me.OwnedForms.Any(Function(f) TypeOf f Is frmSetup) Then
            Me.OwnedForms.First(Function(f) TypeOf f Is frmSetup).Show()
        Else
            Dim tmpFrm As New frmSetup
            tmpFrm.Init(Me)
        End If
    End Sub

    Public Sub ErrorAdd(pNewErrorDescr As String)
        If cbLog.SelectedIndex < 1 Then Return
        txtErrors.Text = Strings.Left(Now.ToLongTimeString & "  " & pNewErrorDescr & vbCrLf & txtErrors.Text, 1000)
        'txtErrors.SelectionStart = 32767 : txtErrors.ScrollToCaret()
    End Sub

    Private Sub SerialPort1_ErrorReceived(sender As Object, e As SerialErrorReceivedEventArgs) Handles SerialPort1.ErrorReceived
        MsgBox(e.ToString)
    End Sub

    Private Sub SerialPort1_PinChanged(sender As Object, e As SerialPinChangedEventArgs) Handles SerialPort1.PinChanged
        MsgBox(e.ToString)
    End Sub



    Private Sub ckKeepVisible_CheckedChanged(sender As Object, e As EventArgs) Handles ckKeepVisible.CheckedChanged
        Me.TopMost = ckKeepVisible.Checked
    End Sub

    Private Sub btVJoy_Click()
        If Joy Is Nothing Then
            Try
                Joy = New vJoyInterfaceWrap.vJoy
                If Not Joy.vJoyEnabled Then
                    MsgBox("vJoy not enabled")
                    Joy = Nothing : Return
                Else
                    Dim verReference As UInteger, verDriver As UInteger
                    If Not Joy.DriverMatch(verReference, verDriver) Then
                        MsgBox("CV Joy expects vJoy version " & verReference & vbCrLf & "Installed vJoy version on this computer is " & verDriver)
                    End If
                End If
                Dim tmp As VjdStat = Joy.GetVJDStatus(SettingsMain.vJoyId)
                If tmp <> VjdStat.VJD_STAT_FREE Then
                    MsgBox("vJoy device  " & SettingsMain.vJoyId & "  status is  " & tmp.ToString)
                    Joy = Nothing : Return
                End If
                Joy.AcquireVJD(SettingsMain.vJoyId)
                'Joy.FfbStart(SettingsMain.vJoyId)
                Joy.FfbRegisterGenCB(AddressOf FFBcallback, SettingsMain.vJoyId)
            Catch ex As Exception
                MsgBox("btVJoy.Click " & ex.Message)
                Joy = Nothing
                Return
            End Try
            'btVJoy.Text = "Stop"
        Else
            Try
                'Joy.FfbStop(SettingsMain.vJoyId)
                Joy.RelinquishVJD(SettingsMain.vJoyId)
            Catch ex As Exception
            End Try
            Joy = Nothing
            'btVJoy.Text = "Start"
        End If
    End Sub

    Private Sub btSetupGame_Click(sender As Object, e As EventArgs) Handles btGameSetup.Click
        If Game IsNot Nothing Then Game.ShowSetup()
    End Sub

    Public Sub FFBcallback(pData As System.IntPtr, pUserdata As Object)
        ' https://github.com/shauleiz/vJoy/blob/master/SDK/src/vJoyClient.cpp
        ' https://msdn.microsoft.com/en-us/library/windows/desktop/ee416335%28v=vs.85%29.aspx?f=255&MSPPError=-2147217396
        'https://www.kaskus.co.id/thread/54c59a266208812a798b456b
        Dim devI As Integer
        Joy.Ffb_h_DeviceID(pData, devI)
        If devI <> SettingsMain.vJoyId Then Return

        Dim t As New FFBPType
        Joy.Ffb_h_Type(pData, t)
        Static FFCases As New List(Of String) ' TODO: DELETE THIS, it was just for debugging purposes
        Dim thisCase As String

        Select Case t
            Case FFBPType.PT_CTRLREP
                Dim ct As New FFB_CTRL ' continue, pause, stopall
                Joy.Ffb_h_DevCtrl(pData, ct)
                thisCase = t.ToString & "  " & ct.ToString
                FFWheel_Cond = New vJoyInterfaceWrap.vJoy.FFB_EFF_COND
                FFWheel_Const = New vJoyInterfaceWrap.vJoy.FFB_EFF_CONSTANT

            Case FFBPType.PT_GAINREP
                Dim tmpFFGain As Byte
                Joy.Ffb_h_DevGain(pData, tmpFFGain) ' na documentação da MSDN dizem que é 0~10000 , mas este interface é byte só dá 0-255
                thisCase = t.ToString & "  " & tmpFFGain
                FFGain = tmpFFGain

            Case FFBPType.PT_NEWEFREP
                Dim tmp As FFBEType
                Joy.Ffb_h_EffNew(pData, tmp) ' Const, Damp, Inertia , Friction, Spring
                thisCase = t.ToString & "  " & tmp.ToString
                If tmp <> FFBEType.ET_CONST Then
                    FFWheel_Type = tmp
                    chkFFCond.Text = FFWheel_Type.ToString
                End If

            'Case FFBPType.PT_EFFREP
            '    Dim et As New FFBEType
            '    Joy.Ffb_h_Eff(pData, et)
            '    thisCase = t.ToString & "  " & et.ToString
            '    '    TODO
            '    handled = True

            Case FFBPType.PT_EFOPREP ' start / stop
                Dim op As New vJoyInterfaceWrap.vJoy.FFB_EFF_OP
                Joy.Ffb_h_EffOp(pData, op)
                thisCase = t.ToString & "  " & op.LoopCount & "x " & op.EffectOp.ToString
                'TODO

            Case FFBPType.PT_CONDREP
                Joy.Ffb_h_Eff_Cond(pData, FFWheel_Cond)
                'PosCoeff = NegCoeff = -10000~10000 (but they are never negative, both are positive)
                'PosSatur = PosSatur = 10000 
                'CenterPointOffset =0
                If cbLog.SelectedIndex = 3 Then
                    thisCase = t.ToString & "  " & FFWheel_Cond.PosCoeff & "  " & FFWheel_Cond.PosSatur & "  " & FFWheel_Cond.CenterPointOffset & "  " & FFWheel_Cond.NegCoeff & "  " & FFWheel_Cond.NegSatur  ' 10000 , 10000 , 0, ?, ?
                Else
                    thisCase = t.ToString
                End If
                If Not FFWheel_Cond.isY Then
                    'If the metric Is less than CP Offset - Dead Band, Then the resulting force Is given by the following formula:
                    '   force = Negative Coefficient * (q - (CP Offset – Dead Band))
                    'If the metric Is greater than CP Offset + Dead Band, then the resulting force Is given by the following formula:
                    '  force = Positive Coefficient * (q - (CP Offset + Dead Band))
                    'where q Is a type-dependent metric: 
                    '  - spring = axis position as the metric
                    '  - damper = axis velocity as the metric
                    '  - inertia = axis acceleration as the metric
                    '  - friction = when the axis is moved and depends on the defined friction coefficient
                    'TODO
                End If

            Case FFBPType.PT_CONSTREP
                Joy.Ffb_h_Eff_Constant(pData, FFWheel_Const)
                If cbLog.SelectedIndex = 3 Then
                    thisCase = t.ToString & "  " & FFWheel_Const.Magnitude
                Else
                    thisCase = t.ToString
                End If

            Case Else
                thisCase = "???  " & t.ToString
        End Select

        ' log :
        If cbLog.SelectedIndex >= 2 Then
            If Not String.IsNullOrEmpty(thisCase) Then
                If Not FFCases.Contains(thisCase) Then
                    FFCases.Add(thisCase)
                    ErrorAdd(thisCase)
                End If
            End If
        End If
    End Sub



    <System.Runtime.ExceptionServices.HandleProcessCorruptedStateExceptions>
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Const WM_INPUT As Integer = &HFF
        Select Case m.Msg
            Case WM_INPUT
                Dim r As MouseRaw.RAWINPUT = MouseRaw.GetMove(m.LParam)
                If r.header.Device = SettingsMain.MouseSteering Then
                    WheelPosition += r.data.LastX * SettingsMain.WheelSensitivity
                    'Debug.Print(WheelPosition & "                " & r.header.Device.ToString & "   x=" & r.data.LastX & "   y=" & r.data.LastY)
                    'Cursor.Position = New Point(0, 0)
                    Return ' dont want this to be processed by windows
                End If
        End Select

        Try
            MyBase.WndProc(m)
        Catch ave As AccessViolationException
        End Try
    End Sub

    Private Sub frmCVJoy_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Timer1.Interval = 60000
        Timer1.Enabled = False
        System.Threading.Thread.Sleep(700) ' give time for sub Timer1_Tick to finnish
        If Game IsNot Nothing Then Game.Stop()
        Game = Nothing
        If SerialPort1.IsOpen Then
            SerialPort1.DiscardInBuffer()
            SerialPort1.Close()
        End If
        If Joy IsNot Nothing Then
            'Joy.FfbStop(SettingsMain.vJoyId)
            Joy.RelinquishVJD(SettingsMain.vJoyId)
            Joy = Nothing
        End If
        e.Cancel = False
    End Sub


    Private Function FFSteer(pWheelPosition As Integer) As Integer
        ' calculate steeringwheel ForceFeedback from -255 to 255:
        ' 
        Dim desiredTotalStrength As Single = 0 ' nominal = -10000 ~ 10000 (but can get to a lot more by summing up FF effects)
        If chkFFConst.Checked Then
            desiredTotalStrength = FFWheel_Const.Magnitude  ' -10000 ~ 10000 ' = Math.Abs(FFWheel_Const.Magnitude / 10000.0F) ^ (SettingsMain.WheelPowerGama / 100.0F) * Math.Sign(FFWheel_Const.Magnitude) * 10000.0F * SettingsMain.WheelPowerFactor ' -10000 ~ 10000
        End If
        'txtErrors.Text = FFWheel_Const.Magnitude.ToString("00000") & "       " & FFWheel_Cond.PosCoeff.ToString("00000") & "       " & FFWheel_Cond.CenterPointOffset.ToString("00000")

        If chkFFCond.Checked Then
            'If the metric Is less than CP Offset - Dead Band, Then the resulting force Is given by the following formula:
            '   FFWheel += Negative Coefficient * (q - (CP Offset – Dead Band))
            'If the metric Is greater than CP Offset + Dead Band, then the resulting force Is given by the following formula:
            '  FFWheel += Positive Coefficient * (q - (CP Offset + Dead Band))
            'where q Is a type-dependent metric: 
            '  - spring = axis position as the metric
            '  - damper = axis velocity as the metric
            '  - inertia = axis acceleration as the metric
            '  - friction = when the axis is moved and depends on the defined friction coefficient
            Dim q As Single = 0 ' aprox. -1~1
            If FFWheel_Type = FFBEType.ET_DMPR OrElse FFWheel_Type = FFBEType.ET_FRCTN Then ' I have not underestand yet the difference between Damper and Friction
                Dim newPosition As Integer
                If pWheelPosition > SettingsMain.WheelDead Then
                    newPosition = pWheelPosition - SettingsMain.WheelDead
                ElseIf pWheelPosition < -SettingsMain.WheelDead Then
                    newPosition = pWheelPosition + SettingsMain.WheelDead
                End If
                Dim timeElapsed As Single = Now.Subtract(LastWheelDate).Ticks
                'If Not ckDontShow.Checked Then lbTicks.Text = timeElapsed
                q = (newPosition - LastWheelPosition) * SettingsMain.WheelDampFactor / timeElapsed 'q = (Math.Abs(pWheelPosition - LastWheelPosition) * SettingsMain.WheelDampFactor / timeElapsed) ^ (SettingsMain.WheelInertia / 100.0F) * Math.Sign(pWheelPosition - LastWheelPosition)
                LastWheelDate = Now : LastWheelPosition = newPosition
            ElseIf FFWheel_Type = FFBEType.ET_SPRNG Then
                If pWheelPosition > SettingsMain.WheelDead Then
                    q = (pWheelPosition - SettingsMain.WheelDead) / 1.637
                ElseIf pWheelPosition < -SettingsMain.WheelDead Then
                    q = (pWheelPosition + SettingsMain.WheelDead) / 1.637
                End If
            End If
            If q < 0 Then ' if Q is negative: I am not using FFWheel_Cond.CenterPointOffset - FFWheel_Cond.DeadBand  because they are allways zero, and their range would be -10000~10000 while Q range is -1~1 , and CVJoy has its own DeadZone
                desiredTotalStrength += FFWheel_Cond.NegCoeff * q '(q - (FFWheel_Cond.CenterPointOffset - FFWheel_Cond.DeadBand))
            ElseIf q > 0 Then ' if Q is positive:
                desiredTotalStrength += FFWheel_Cond.PosCoeff * q '(q - (FFWheel_Cond.CenterPointOffset + FFWheel_Cond.DeadBand))
            End If
        End If

        desiredTotalStrength = desiredTotalStrength / 10000 * FFGain
        If graph IsNot Nothing Then graph.UpdateFFWheel(Math.Abs(desiredTotalStrength))

        ' final output:
        Dim powerToApply As Integer = CalculateOutput(Math.Abs(desiredTotalStrength), 255, SettingsMain.WheelMinInput, SettingsMain.WheelPowerForMin, SettingsMain.WheelPowerGama, SettingsMain.WheelPowerFactor) * Math.Sign(desiredTotalStrength)
        'txtErrors.Text = "Res=" & res.ToString("000") & "      FFWheel=" & Math.Abs(FFWheel).ToString("000") & "   q=" & Math.Abs(q).ToString("00000") & "   PosCoeff=" & FFWheel_Cond.PosCoeff.ToString("00000") '& "     CenterPointOffset=" & FFWheel_Cond.CenterPointOffset.ToString("00000") & "     DeadBand=" & FFWheel_Cond.DeadBand.ToString("00000")
        Return powerToApply
    End Function

End Class
