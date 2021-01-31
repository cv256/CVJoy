Imports System.IO.Ports
Imports System.Net


Public Class frmCVJoy
    Private WithEvents SerialPort1 As New IO.Ports.SerialPort
    Public WithEvents Timer1 As New System.Timers.Timer
    Private GameOutputs As clGameOutputs
    Public Joy As vJoyInterfaceWrap.vJoy ' http://vjoystick.sourceforge.net/site/includes/SDK_ReadMe.pdf
    Private FFGain As Single = 255
    Public FFWheel_Type As FFBEType
    Public FFWheel_Cond As New vJoyInterfaceWrap.vJoy.FFB_EFF_COND
    Public FFWheel_Const As New vJoyInterfaceWrap.vJoy.FFB_EFF_CONSTANT

    Private _realLeft As Single, _realRight As Single ' position now (from sensor) in milimeters, tipically from   minus GMaxScrewDown    to    Zero (center)    to    GMaxScrewUp
    Private _realOKLeft As Single, _realOKRight As Single ' position now (from sensor plus corrections) in milimeters, tipically from   minus GMaxScrewDown    to    Zero (center)    to    GMaxScrewUp
    Private _lastLeftMotorSpeed As Single, _lastRightMotorSpeed As Single ' -100~100 negative=bolt going down
    Private _motorOverHeat As Single
    Private ArduinoLastRead As Date = Now.AddSeconds(-1) ' time of last good reading
    Private WheelPosition As Integer, PreviousWheelPosition As Integer, PreviousArduinoLastRead As Date = Now.AddSeconds(-1), WheelPositionOffset As Boolean
    Private ButtonsLast(8) As Boolean, ButtonOther As Boolean
    Private TimerTickCounter As Integer = 0

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
        cbLogFF.Items.Add("Don't Log FF")
        cbLogFF.Items.Add("FF")
        cbLogFF.Items.Add("FF Extra")
        cbLogFF.SelectedIndex = 0

        cbGames.Items.Add("Assetto Corsa")
        cbGames.Items.Add("Standard")

        SettingsMain.LoadSettingsFromFile()
        cbGames.SelectedIndex = 0 ' TODO: SettingsMain should keep that last cbGames.SelectedIndex used, and here we should use that

        Timer1.Interval = 1000 / SettingsMain.RefreshRate
        Timer1.AutoReset = False

        btVJoy_Click()
    End Sub

    Private Sub cbGames_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGames.SelectedIndexChanged
        If Game IsNot Nothing Then Game.Stop()
        If cbGames.SelectedIndex = 1 Then
            Game = New GameStd(Me)
            btGameStart.Visible = False
            lbGameInfo.Text = ""
        Else
            Game = New GameAC(Me)
            btGameStart.Visible = True
            AddHandler Game.StateChanged, AddressOf GameStateChanged
        End If
        Game.LoadSettingsFromFile()
        UcButtons1.ShowSettings()
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
            Timer1.Enabled = False ' stop sending more data to Arduino
            System.Threading.Thread.Sleep(700) ' give time to finnish processing eventualy received data from arduino
            SerialPort1.Close()
            btArduinoStart.Text = "Start"
        Else
            Try
                SerialPort1.PortName = SettingsMain.ArduinoComPort
                SerialPort1.BaudRate = 115200
                SerialPort1.DataBits = 8
                SerialPort1.Parity = Parity.None
                SerialPort1.StopBits = StopBits.One
                SerialPort1.Handshake = Handshake.None
                SerialPort1.RtsEnable = False
                SerialPort1.ReceivedBytesThreshold = SerialRead.PacketLen
                ' SerialPort1.WriteBufferSize = SerialSend.PacketLen ' The WriteBufferSize property ignores any value smaller than 2048.
                SerialPort1.WriteTimeout = 1000
                SerialPort1.Open()
                btArduinoStart.Text = "Stop"
                Timer1.Enabled = True
            Catch ex As Exception
                MsgBox("btArduinoStart.Click " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub Timer1_Elapsed(sender As Object, e As EventArgs) Handles Timer1.Elapsed
        SendToArduino()
    End Sub

    Private Sub SendToArduino()
        TimerTickCounter += 1

        ' prepare data to send to the Arduino :
        Dim toArduino As New SerialSend
        With toArduino

            If WheelPositionOffset Then
                .WheelPositionOffset = True
                WheelPositionOffset = False
            End If

            If Game IsNot Nothing AndAlso Game.Started Then
                GameOutputs = Game.Update() ' get realtime data from the Game 
            End If

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


#Region "PowerFromAngle: calculates power to apply now, based on the previous position readings"

            ' convert Desired Angles into Desired Screw Positions:
            If GameOutputs.Pitch > 0 Then GameOutputs.Pitch = (GameOutputs.Pitch * 20) ^ SettingsMain.UltrasonicGama / 12
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
                AndAlso SerialPort1.IsOpen Then ' SHIIIT,  STOP everything ! dont even try to correct it, wires, relays or screws may be swaped or broken !
                ErrorAdd("NO POSITION DATA FROM ARDUINO !", $"   last read {(Now.Subtract(ArduinoLastRead).TotalMilliseconds / 1000).ToString("0.00")} seconds ago")
            ElseIf (_realOKLeft > (SettingsMain.GMaxScrewUp + SettingsMain.GMinDiff * 2) _
            OrElse _realOKLeft < -(SettingsMain.GMaxScrewDown + SettingsMain.GMinDiff * 2) _
            OrElse _realOKRight > (SettingsMain.GMaxScrewUp + SettingsMain.GMinDiff * 2) _
            OrElse _realOKRight < -(SettingsMain.GMaxScrewDown + SettingsMain.GMinDiff * 2)) _
            AndAlso SerialPort1.IsOpen Then ' SHIIIT, stop everything ! dont even try to correct it, wires, relays or screws may be swaped or broken !
                If Not chkNoMotors.Checked Then ErrorAdd("OUT OF BOUNDS !", $"   LeftPosition={CInt(_realOKLeft)}mm     RightPosition={CInt(_realOKRight)}mm")
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

        ' show stuff in screen :
        If Not ckDontShow.Checked AndAlso Me.WindowState <> FormWindowState.Minimized Then
            With toArduino
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
        End If

        ' SEND SERIAL DATA TO ARDUINO:
        SerialPort1.DiscardOutBuffer()
        SerialPort1.DiscardInBuffer()
        SerialPort1.Write(toArduino.GetSerialData, 0, SerialSend.PacketLen) ' example: 255 0 128 128 0 0 0

        ' FOR DEBUGGING :
        'ErrorAdd("Send " & String.Join(" ", toArduino.GetSerialData), "")

        ' NOW WE WAIT FOR RESPONSE FROM SERIAL....
    End Sub


    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        ' READ SERIAL DATA FROM ARDUINO:

        Dim fromArduino As New SerialRead

        ' FOR DEBUGGING :
        'Dim buf(512) As Byte ' maximum number of bytes to read. Only the number of bytes in the input buffer will be assigned to this array.
        'SerialPort1.Read(buf, 0, buf.Length)
        'ErrorAdd("Rcvd " & String.Join(" ", buf), "")

        Try
            If SerialPort1.BytesToRead < SerialRead.PacketLen Then ' !!! the DataReceived event is also raised if an Eof character is received, regardless of the number of bytes in the internal input buffer and the value of the ReceivedBytesThreshold property
                ErrorAdd("Only " & SerialPort1.BytesToRead, " bytes")
                Return ' will wait for more data
            End If

            Dim buf(120) As Byte ' maximum number of bytes to read. Only the number of bytes in the input buffer will be assigned to this array.
            SerialPort1.Read(buf, 0, buf.Length)

            If buf(0) < 192 Then
                ErrorAdd("SerialPort1  received BAD checkdigit  =" & buf(0), "discarding them")
                GoTo goReturn ' TODO: we should give some delay before we send data to arduino again...
            End If
            If (buf(0) And 2) <> 0 Then
                ErrorAdd("ARDUINO says he GOT INVALID DATA", "")
                GoTo goReturn ' TODO: we should give some delay before we send data to arduino again...
            End If

            Static _MainsPowerOK As Boolean
            If (buf(0) And 1) = 1 AndAlso _MainsPowerOK = True Then
                _MainsPowerOK = False
                lbMainsPower.Text = "Mains Power OFF"
                lbMainsPower.BackColor = Color.DeepSkyBlue
                ErrorAdd("No Mains power / MainsPower freq lower", "than 50Hz+5%")
            ElseIf (buf(0) And 1) = 0 AndAlso _MainsPowerOK = False Then
                _MainsPowerOK = True
                lbMainsPower.Text = "Mains Power ON"
                lbMainsPower.BackColor = Color.HotPink
                ErrorAdd("Mains power OK", "")
            End If

            ' this fills fromArduino with the data red from the Arduino !!
            fromArduino.SetSerialData(buf)

        Catch ex As Exception
            ErrorAdd("EXCEPTION SerialPort1", ".DataReceived  " & ex.Message)
            GoTo goReturn ' TODO: we should give some delay before we send data to arduino again...
        End Try


        If chkArduinoTime.Checked Then lbArduinoTime.Text = (1000 / Now.Subtract(ArduinoLastRead).TotalMilliseconds).ToString("0")
        'txtErrors.Text = Now.Subtract(timeStart).Ticks.ToString("0000000") & "    " & timeRead.Subtract(timeSent).Ticks.ToString("0000000")
        PreviousArduinoLastRead = ArduinoLastRead
        ArduinoLastRead = Now
        PreviousWheelPosition = WheelPosition
        WheelPosition = fromArduino.WheelPosition
        _realLeft = fromArduino.RealLeft - SettingsMain.GLeftScrewCenter
        _realRight = fromArduino.RealRight - SettingsMain.GRightScrewCenter

        With fromArduino
            Dim j As New vJoyInterfaceWrap.vJoy.JoystickState
#Region "buttons:  emulate keystrokes  or  send as joystick buttons"
            ' https://msdn.microsoft.com/en-us/library/system.windows.forms.sendkeys.send(v=vs.110).aspx
            Dim buttonBit As UInteger = 0

            If .buttons(0) Then ' if button0 is being pressed:      

                For i As Integer = 1 To 8
                    If Game.Bt(i + 9) > "" Then
                        If .buttons(i) Then
                            If ButtonsLast(i) Then Continue For
                            SendKeys.SendWait(Game.Bt(i + 9))
                            ButtonOther = True
                        End If
                    ElseIf .buttons(i) Then
                        buttonBit += 2 ^ (i + 16)
                        ButtonOther = True
                    End If
                Next i

            Else ' if button0 is not being pressed now :

                If ButtonsLast(0) Then ' if was pressed alone and we just released it:
                    If Not ButtonOther Then ' and no other button had been pressed
                        If Game.Bt(0) > "" Then
                            SendKeys.SendWait(Game.Bt(0))
                        Else
                            buttonBit = 1
                        End If
                    End If
                    ButtonOther = False
                Else
                    For i As Integer = 1 To 8
                        If Game.Bt(i) > "" Then
                            If .buttons(i) Then
                                If ButtonsLast(i) Then Continue For
                                SendKeys.SendWait(Game.Bt(i))
                            End If
                        ElseIf .buttons(i) Then
                            buttonBit += 2 ^ i
                        End If
                    Next i
                End If
            End If
            fromArduino.buttons.CopyTo(ButtonsLast, 0)
#End Region

            If Joy IsNot Nothing Then
                j.Buttons = buttonBit _
                        + If(.gear1, 1024, 0) _
                        + If(.gear2, 2048, 0) _
                        + If(.gear3, 4096, 0) _
                        + If(.gear4, 8192, 0) _
                        + If(.gear5, 16384, 0) _
                        + If(.gear6, 32768, 0) _
                        + If(.gearR, 65536, 0)
                j.AxisX = Math.Max(Math.Min(WheelPosition + 16384, 32767), 0)  ' 0-16384-32767
                j.AxisY = .AccelCorrected * 32 ' 0-32767
                j.AxisZ = .BrakeCorrected * 32 ' 0-32767
                j.AxisXRot = .ClutchCorrected * 32 ' 0-32767
                Joy.UpdateVJD(SettingsMain.vJoyId, j)
            End If

        End With

        ' send UDP:
        If chkUDP.Checked AndAlso Game IsNot Nothing AndAlso Game.Started Then
            Dim udpBytes As Byte()
            If TimerTickCounter Mod 3 = 0 Then
                If TimerTickCounter >= 30 Then
                    TimerTickCounter = 0
                    udpBytes = New Byte(33) {}
                    With Game.UpdateExtra()
                        udpBytes(18) = .TyreWearFL
                        udpBytes(19) = .TyreWearFR
                        udpBytes(20) = .TyreWearRL
                        udpBytes(21) = .TyreWearRR
                        udpBytes(22) = BitConverter.GetBytes(Math.Abs(.RpmMax))(0)
                        udpBytes(23) = BitConverter.GetBytes(Math.Abs(.RpmMax))(1)
                        udpBytes(24) = .MaxFuel
                        udpBytes(25) = .Fuel
                        udpBytes(26) = .NumCars
                        udpBytes(27) = .Position
                        udpBytes(28) = .NumberOfLaps
                        udpBytes(29) = .CompletedLaps
                        udpBytes(30) = BitConverter.GetBytes(Math.Abs(.DistanceTraveled))(0)
                        udpBytes(31) = BitConverter.GetBytes(Math.Abs(.DistanceTraveled))(1)
                        udpBytes(32) = BitConverter.GetBytes(.FuelAvg)(0)
                        udpBytes(33) = BitConverter.GetBytes(.FuelAvg)(1)
                        'ErrorAdd(String.Join(",", udpBytes), "")
                    End With
                Else
                    udpBytes = New Byte(17) {}
                End If
                udpBytes(0) = 255
                udpBytes(1) = BitConverter.GetBytes(Math.Abs(GameOutputs.Speed))(0)
                udpBytes(2) = BitConverter.GetBytes(Math.Abs(GameOutputs.Speed))(1)
                udpBytes(3) = BitConverter.GetBytes(Math.Abs(GameOutputs.RPM))(0)
                udpBytes(4) = BitConverter.GetBytes(Math.Abs(GameOutputs.RPM))(1)
                udpBytes(5) = BitConverter.GetBytes(Math.Abs(GameOutputs.Gear))(0)
                udpBytes(6) = GameOutputs.SlipFL
                udpBytes(7) = GameOutputs.SlipFR
                udpBytes(8) = GameOutputs.SlipRL
                udpBytes(9) = GameOutputs.SlipRR
                udpBytes(10) = If(GameOutputs.GearAuto, 1, 0)
                udpBytes(11) = GameOutputs.TyreDirtFL
                udpBytes(12) = GameOutputs.TyreDirtFR
                udpBytes(13) = GameOutputs.TyreDirtRL
                udpBytes(14) = GameOutputs.TyreDirtRR
                udpBytes(15) = CByte(Math.Min(fromArduino.AccelCorrected / 4, 255))
                udpBytes(16) = CByte(Math.Min(fromArduino.BrakeCorrected / 4, 255))
                udpBytes(17) = CByte(Math.Min(fromArduino.ClutchCorrected / 4, 255))
                Try
                    Dim udpClient As New Sockets.UdpClient
                    udpClient.SendAsync(udpBytes, udpBytes.Length, SettingsMain.UdpIp, 45000)
                Catch ex As Exception
                    ErrorAdd("UDP Send Error " & SettingsMain.UdpIp, ex.Message)
                End Try
            End If

        End If

        ' show lights on screen:
        If Not ckDontShow.Checked AndAlso Me.WindowState <> FormWindowState.Minimized Then
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
                UcButtons1.bt0.BackColor = If(.buttons(0), Color.DarkGreen, Color.LightGray)
                UcButtons1.bt1.BackColor = If(.buttons(0) = False AndAlso .buttons(1), Color.Green, Color.White)
                UcButtons1.bt2.BackColor = If(.buttons(0) = False AndAlso .buttons(2), Color.Green, Color.White)
                UcButtons1.bt3.BackColor = If(.buttons(0) = False AndAlso .buttons(3), Color.Green, Color.White)
                UcButtons1.bt4.BackColor = If(.buttons(0) = False AndAlso .buttons(4), Color.Green, Color.White)
                UcButtons1.bt5.BackColor = If(.buttons(0) = False AndAlso .buttons(5), Color.Green, Color.White)
                UcButtons1.bt6.BackColor = If(.buttons(0) = False AndAlso .buttons(6), Color.Green, Color.White)
                UcButtons1.bt7.BackColor = If(.buttons(0) = False AndAlso .buttons(7), Color.Green, Color.White)
                UcButtons1.bt8.BackColor = If(.buttons(0) = False AndAlso .buttons(8), Color.Green, Color.White)
                UcButtons1.bt10.BackColor = If(.buttons(0) AndAlso .buttons(1), Color.Green, Color.White)
                UcButtons1.bt11.BackColor = If(.buttons(0) AndAlso .buttons(2), Color.Green, Color.White)
                UcButtons1.bt12.BackColor = If(.buttons(0) AndAlso .buttons(3), Color.Green, Color.White)
                UcButtons1.bt13.BackColor = If(.buttons(0) AndAlso .buttons(4), Color.Green, Color.White)
                UcButtons1.bt14.BackColor = If(.buttons(0) AndAlso .buttons(5), Color.Green, Color.White)
                UcButtons1.bt15.BackColor = If(.buttons(0) AndAlso .buttons(6), Color.Green, Color.White)
                UcButtons1.bt16.BackColor = If(.buttons(0) AndAlso .buttons(7), Color.Green, Color.White)
                UcButtons1.bt17.BackColor = If(.buttons(0) AndAlso .buttons(8), Color.Green, Color.White)
            End With
        End If

        If graph IsNot Nothing Then graph.UpdatePedals(fromArduino)

goReturn:
        '  TODO: could have a counter of Sent/Received 
        Timer1.Enabled = True  ' SendToArduino()
    End Sub

    Private Sub SerialPort1_ErrorReceived(sender As Object, e As SerialErrorReceivedEventArgs)
        MsgBox(e.ToString)
    End Sub

    Private Sub SerialPort1_PinChanged(sender As Object, e As SerialPinChangedEventArgs)
        MsgBox(e.ToString)
    End Sub


    Public Sub ErrorAdd(pNewErrorDescr As String, pExtraInfo As String, Optional pFF As Boolean = False)
        If pFF = False AndAlso chkLogHideDups.Checked Then
            If txtErrors.Text.Contains(pNewErrorDescr) Then Return
            txtErrors.Text = Strings.Left(pNewErrorDescr & "  " & pExtraInfo & vbCrLf & txtErrors.Text, 1000)
        Else
            txtErrors.Text = Strings.Left(Now.ToLongTimeString & "  " & pNewErrorDescr & "  " & pExtraInfo & vbCrLf & txtErrors.Text, 5000)
        End If
        'txtErrors.SelectionStart = 32767 : txtErrors.ScrollToCaret()
    End Sub

    Private Sub btLogClear_Click(sender As Object, e As EventArgs) Handles btLogClear.Click
        txtErrors.Text = ""
    End Sub

    Private Sub btWheelCenter_Click(sender As Object, e As EventArgs) Handles btWheelCenter.Click
        WheelPositionOffset = True
    End Sub

    Private Sub btSetup_Click(sender As Object, e As EventArgs) Handles btSetup.Click
        If Me.OwnedForms.Any(Function(f) TypeOf f Is frmSetup) Then
            Me.OwnedForms.First(Function(f) TypeOf f Is frmSetup).Show()
        Else
            Dim tmpFrm As New frmSetup
            tmpFrm.Init(Me)
        End If
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
        If chkFFIgnore.Checked Then Return

        Dim devI As Integer
        Joy.Ffb_h_DeviceID(pData, devI)
        If devI <> SettingsMain.vJoyId Then Return

        Dim t As New FFBPType
        Joy.Ffb_h_Type(pData, t)

        Static FFCases As New List(Of String) ' TODO: DELETE THIS, it was just for debugging purposes
        Dim thisCase As String

        Select Case t
            Case FFBPType.PT_CTRLREP ' RESET
                Dim ct As New FFB_CTRL ' continue, pause, stopall
                Joy.Ffb_h_DevCtrl(pData, ct)
                thisCase = t.ToString & "  " & ct.ToString
                FFWheel_Cond = New vJoyInterfaceWrap.vJoy.FFB_EFF_COND
                FFWheel_Const = New vJoyInterfaceWrap.vJoy.FFB_EFF_CONSTANT

            Case FFBPType.PT_GAINREP ' SET GAIN
                Dim tmpFFGain As Byte
                Joy.Ffb_h_DevGain(pData, tmpFFGain) ' na documentação da MSDN dizem que é 0~10000 , mas este interface é byte só dá 0-255
                thisCase = t.ToString & "  " & tmpFFGain
                FFGain = tmpFFGain

            Case FFBPType.PT_NEWEFREP ' SET CURRENT EFFECT
                Dim tmp As FFBEType
                Joy.Ffb_h_EffNew(pData, tmp) ' Const, Damp, Inertia , Friction, Spring
                thisCase = t.ToString & "  " & tmp.ToString
                If tmp <> FFBEType.ET_CONST Then
                    FFWheel_Type = tmp
                    'chkFFCond.Text = FFWheel_Type.ToString  ' this is heavy ?
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
                If cbLogFF.SelectedIndex = 2 Then
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
                If cbLogFF.SelectedIndex = 2 Then
                    thisCase = t.ToString & "  " & FFWheel_Const.Magnitude
                Else
                    thisCase = t.ToString
                End If

            Case Else
                thisCase = "???  " & t.ToString
        End Select

        ' log :
        If cbLogFF.SelectedIndex >= 1 Then
            If Not String.IsNullOrEmpty(thisCase) Then
                If Not FFCases.Contains(thisCase) Then
                    FFCases.Add(thisCase)
                    ErrorAdd(thisCase, "")
                End If
            End If
        End If
    End Sub


    Private Sub frmCVJoy_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Game IsNot Nothing Then Game.Stop()
        Game = Nothing

        If SerialPort1.IsOpen Then ArduinoStart(Nothing, Nothing) ' this stops arduino 
        SerialPort1 = Nothing

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

        Dim q As Single = 0 ' aprox. -1~1
        Dim timeElapsed As Single = ArduinoLastRead.Subtract(PreviousArduinoLastRead).Ticks
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
            If FFWheel_Type = FFBEType.ET_DMPR OrElse FFWheel_Type = FFBEType.ET_FRCTN Then ' I have not underestand yet the difference between Damper and Friction
                'Dim newPosition As Integer = 0
                'If pWheelPosition > SettingsMain.WheelDead Then
                '    newPosition = pWheelPosition - SettingsMain.WheelDead
                'ElseIf pWheelPosition < -SettingsMain.WheelDead Then
                '    newPosition = pWheelPosition + SettingsMain.WheelDead
                'End If
                q = (pWheelPosition - PreviousWheelPosition) / timeElapsed * SettingsMain.WheelDampFactor 'q = (Math.Abs(pWheelPosition - LastWheelPosition) * SettingsMain.WheelDampFactor / timeElapsed) ^ (SettingsMain.WheelInertia / 100.0F) * Math.Sign(pWheelPosition - LastWheelPosition)
                'If pWheelPosition <> PreviousWheelPosition Then txtErrors.Text &= (pWheelPosition - PreviousWheelPosition) & "       " & timeElapsed & vbCrLf
            ElseIf FFWheel_Type = FFBEType.ET_SPRNG Then
                q = pWheelPosition / 1.637
                'If pWheelPosition > SettingsMain.WheelDead Then
                '    q = (pWheelPosition - SettingsMain.WheelDead) / 1.637
                'ElseIf pWheelPosition < -SettingsMain.WheelDead Then
                '    q = (pWheelPosition + SettingsMain.WheelDead) / 1.637
                'End If
            End If
            If q < 0 Then ' if Q is negative: I am not using FFWheel_Cond.CenterPointOffset - FFWheel_Cond.DeadBand  because they are allways zero, and their range would be -10000~10000 while Q range is -1~1 , and CVJoy has its own DeadZone
                desiredTotalStrength += FFWheel_Cond.NegCoeff * q '(q - (FFWheel_Cond.CenterPointOffset - FFWheel_Cond.DeadBand))
            ElseIf q > 0 Then ' if Q is positive:
                desiredTotalStrength += FFWheel_Cond.PosCoeff * q '(q - (FFWheel_Cond.CenterPointOffset + FFWheel_Cond.DeadBand))
            End If
        End If

        desiredTotalStrength = desiredTotalStrength / 10000 * FFGain '  now becomes  -255 ~ 255 (but can get to a lot more by summing up FF effects)
        If graph IsNot Nothing Then graph.UpdateFFWheel(Math.Abs(desiredTotalStrength))

        ' final output:
        Dim powerToApply As Integer = 0
        Try
            powerToApply = CalculateOutput(Math.Min(Math.Abs(desiredTotalStrength), 255), 255, SettingsMain.WheelMinInput, SettingsMain.WheelPowerForMin, SettingsMain.WheelPowerGama, SettingsMain.WheelPowerFactor) * Math.Sign(desiredTotalStrength)
        Catch ex As Exception
            txtErrors.Text = $"808 : desiredTotalStrength={desiredTotalStrength}   pWheelPosition={pWheelPosition}  timeElapsed={timeElapsed}  q={Math.Abs(q).ToString("00000")}  {ex.Message}" & vbCrLf & txtErrors.Text
        End Try
        Return powerToApply
    End Function

End Class
