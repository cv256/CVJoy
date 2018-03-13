Imports System.IO.Ports
Imports AssettoCorsaSharedMemory


Public Class frmCVJoy
    Public TimerProcessing As Boolean = False
    Public Joy As vJoyInterfaceWrap.vJoy ' http://vjoystick.sourceforge.net/site/includes/SDK_ReadMe.pdf
    Public AC As AssettoCorsaSharedMemory.AssettoCorsa
    Public acS As AssettoCorsaSharedMemory.StaticInfo
    Private ACSpeedKmhLast As Single, ACLastRead As DateTime
    Private WheelPosition As Single ' -16380 ~ 0 ~ 16380
    Private LastWheelDate As DateTime, LastWheelPosition As Integer
    Private FFGain As Single = 255 / 10000.0F ' 0 ~ 0.0255
    Public FFWheel_Type As FFBEType
    Public FFWheel_Cond As New vJoyInterfaceWrap.vJoy.FFB_EFF_COND
    Public FFWheel_Const As New vJoyInterfaceWrap.vJoy.FFB_EFF_CONSTANT

    Private _gyroPitch As Single, _gyroRoll As Single
    Private _realPitch As Single, _realRoll As Single ' isto devia ser processado no Arduino, escusava de vir ao PC e voltar. No VBJoy faço Serial.Write, e depois Serial.Read, o que não dá jeito nenhum para isto. Para estar no CVJoy isto devia estar na classe SerialRead.

    Public Enum Motor
        None
        Wheel
        Pitch
        Roll
        Wind
    End Enum
    Public TestMode As Motor, TestValue As Integer = 0


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text &= "  " & Application.ProductVersion
        cbLog.Items.Add("Don't Log")
        cbLog.Items.Add("Log")
        cbLog.Items.Add("Log + FF")
        cbLog.Items.Add("Log + FF Extra")
        cbLog.SelectedIndex = 1
        'My.Settings.Reload()
        If Not My.Settings.Edited Then
            My.Settings.Upgrade()
            My.Settings.Edited = True
            My.Settings.Save()
        End If
        txtRPM1.Text = My.Settings.ACRpm1 * 100
        txtRPM2.Text = My.Settings.ACRpm2 * 100
        txtMaxSpeed.Text = My.Settings.ACMaxSpeed
        txtSlip.Text = My.Settings.ACSlip
        txtPitch.Text = My.Settings.ACPitch * 100
        txtRoll.Text = My.Settings.ACRoll * 100
        txtJump.Text = My.Settings.ACJump.ToString("+0.0;-0.0")
        txtAccel.Text = My.Settings.ACAccel
        txtTurn.Text = My.Settings.ACTurn

        Timer1.Interval = 1000 / My.Settings.RefreshRate
        Timer1.Enabled = True

        MouseRaw.Register(Me.Handle)

        btVJoy_Click()
    End Sub


    Public Sub ArduinoStart(sender As Object, e As EventArgs) Handles btArduinoStart.Click
        If SerialPort1.IsOpen Then
            SerialPort1.DiscardInBuffer()
            SerialPort1.Close()
            btArduinoStart.Text = "Start"
        Else
            Try
                SerialPort1.PortName = My.Settings.ArduinoComPort
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


    Public Sub ACStart(sender As Object, e As EventArgs) Handles btACStart.Click
        If AC Is Nothing Then
            Try
                AC = New AssettoCorsa()
                AC.Start() ' Connect To Shared memory And start interval timers 
                btACStart.Text = "Stop"
            Catch ex As Exception
                MsgBox("btACStart.Click " & ex.Message)
            End Try
        Else
            AC.Stop()
            AC = Nothing
            btACStart.Text = "Start"
        End If
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'If Ggraph IsNot Nothing AndAlso Not Ggraph.chkPause.Checked Then Ggraph.UpdateValue(VBMath.Rnd * 30 - 15, VBMath.Rnd * 30 - 15, VBMath.Rnd, VBMath.Rnd * 30 - 15)
        If TimerProcessing Then
            ErrorAdd("Cant stand such hight Refresh Rate, lower it.")
            Return
        End If
        TimerProcessing = True
        'timeStart = Now

        Dim acP As Physics

        ' Get data from AC:
        Dim ACstopped As Boolean = False
        If AC Is Nothing Then
            lbACInfo.Text = ""
            ACstopped = True
        Else
            If Not AC.IsRunning Then
                lbACInfo.Text = "     connection to Assetto Corsa:    NOT RUNNING"
                ACstopped = True
            Else
                acP = AC.ReadPhysics()
                If acP.SpeedKmh <> ACSpeedKmhLast Then ACLastRead = Now
                ACSpeedKmhLast = acP.SpeedKmh
                If Now.Subtract(ACLastRead).TotalSeconds > 0 Then ' more then 1 second with the same readings means AC is dead
                    lbACInfo.Text = "     connection to Assetto Corsa:    DEAD"
                    ACstopped = True
                End If
            End If
        End If

        If ACstopped Then
            acS.MaxRpm = 0 ' using  acS.MaxRpm=0  as a flag to indicate AC was not running
            acP = New Physics ' to clear all acp
            Int32.TryParse(lbACSpeed.Text, acP.SpeedKmh) ' if not connected to AC, user can input data to simulate AC
            Dim AccG(2) As Single : acP.AccG = AccG
            Dim WheelSlip(3) As Single : acP.WheelSlip = WheelSlip
        ElseIf acS.MaxRpm = 0 Then ' if AC just started or restarted:
            acS = AC.ReadStaticInfo
            lbMaxRPM.Text = acS.MaxRpm
            lbACInfo.Text = "     connection to Assetto Corsa:    " & acS.ACVersion & "   " & acS.CarModel & "   " & acS.Track & "   " & acS.TrackConfiguration
        End If

        ' show raw AC data on screen:
        If Me.WindowState <> FormWindowState.Minimized AndAlso ckDontShow.Checked = False Then
            lbACSpeed.Text = acP.SpeedKmh
            lbACRPM.Text = acP.Rpms
            'lbACTC.Text = acP.TC
            'lbACABS.Text = acP.Abs
            lbACSlipFront.Text = Math.Min(acP.WheelSlip(0), acP.WheelSlip(1))
            lbACSlipBack.Text = Math.Min(acP.WheelSlip(2), acP.WheelSlip(3))
            lbACJump.Text = acP.AccG(1).ToString("0.0") & "G"
            lbACAccel.Text = acP.AccG(2).ToString("0.0") & "G"
            lbACTurn.Text = acP.AccG(0).ToString("0.0") & "G"
            lbACPitch.Text = (acP.Pitch * 57.29).ToString("0.0") & "º"
            lbACRoll.Text = (acP.Roll * 57.29).ToString("0.0") & "º"
        End If

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

            If TestMode = Motor.Pitch Then
                .leftPower = TestValue
                .rightPower = TestValue
            ElseIf TestMode = Motor.Roll Then
                .leftPower = TestValue
                .rightPower = -TestValue
            Else
                PowerFromAngle(_realPitch, _realRoll, acP.Pitch * 57.29 * My.Settings.ACPitch + acP.AccG(2) * My.Settings.ACAccel, acP.Roll * 57.29 * My.Settings.ACRoll + acP.AccG(0) * My.Settings.ACTurn, OUTLeftPower:= .leftPower, OUTRightPower:= .rightPower)
            End If
            If _realPitch > My.Settings.MaxPitch OrElse _realPitch < -My.Settings.MinPitch OrElse Math.Abs(_realRoll) > My.Settings.MaxRoll Then
                .leftPower = 0
                .rightPower = 0
                'ErrorAdd("DANGER !   ANGLE ERROR !")
            End If

            If TestMode = Motor.Wind Then
                .windPower = TestValue
            ElseIf Not chkNoWind.Checked Then
                .windPower = FFWind(SpeedKmh:=acP.SpeedKmh, Jump:=acP.AccG(1))
            Else
                .windPower = 0
            End If

            '.abs = acP.Abs >= 1
            '.tc = acP.TC >= 1
            .slipFront = Math.Min(acP.WheelSlip(0), acP.WheelSlip(1)) > My.Settings.ACSlip
            .slipBack = Math.Min(acP.WheelSlip(2), acP.WheelSlip(3)) > My.Settings.ACSlip
            .rpm1 = acP.Rpms < acS.MaxRpm * My.Settings.ACRpm1
            .rpm2 = acP.Rpms > acS.MaxRpm * My.Settings.ACRpm2
        End With

        Dim fromArduino As New SerialRead
        If SerialPort1.IsOpen Then
            ' SEND SERIAL DATA TO ARDUINO:
            SerialPort1.DiscardOutBuffer()
            'timeSent = Now
            SerialPort1.Write(toArduino.GetSerialData, 0, SerialSend.PacketLen)

            ' READ SERIAL DATA FROM ARDUINO:
            Do Until SerialPort1.BytesToRead >= SerialRead.PacketLen
                Threading.Thread.Sleep(10)
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
                    Return
                End If
                Dim buf(BytesToRead - 1) As Byte
                SerialPort1.Read(buf, 0, buf.Length)
                If buf(0) <> 170 AndAlso buf(0) <> 171 Then
                    ErrorAdd("UNEXPECTED SerialPort1.buf(0)=" & buf(0))
                    Return
                End If
                fromArduino.SetSerialData(buf, _gyroPitch, _gyroRoll, _realPitch, _realRoll)
            Catch ex As Exception
                ErrorAdd("SerialPort1.DataReceived  " & ex.Message)
            End Try
        End If

        With fromArduino

            ' send to VJoy:
            If Joy IsNot Nothing Then
                Dim j As New vJoyInterfaceWrap.vJoy.JoystickState
                j.AxisX = If(Math.Abs(WheelPosition) > My.Settings.WheelDead, Math.Max(0, Math.Min(32767, WheelPosition + 16384)), 16384)  ' 0-16384-32767
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
                Joy.UpdateVJD(My.Settings.vJoyId, j)
            End If
            ' buttons that emulate keystrokes:
            Static oldbutton1 As Boolean
            If .button1 = True AndAlso oldbutton1 = False Then SendKeys.Send("{ESC}")
            oldbutton1 = .button1
        End With

        ' show lights on screen:
        If Me.WindowState <> FormWindowState.Minimized AndAlso ckDontShow.Checked = False Then
            With toArduino
                lbRPM1.BackColor = If(.rpm1, Color.DodgerBlue, Color.White)
                lbRPM2.BackColor = If(.rpm2, Color.DodgerBlue, Color.White)
                'lbABS.BackColor = If(.abs, Color.Blue, Color.White)
                'lbTC.BackColor = If(.tc, Color.Blue, Color.White)
                lbSlipFront.BackColor = If(.slipFront, Color.Red, Color.White)
                lbSlipBack.BackColor = If(.slipBack, Color.Red, Color.White)
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
                bt1.BackColor = If(.button1, Color.Green, Color.White)
                bt2.BackColor = If(.button2, Color.Green, Color.White)
                bt3.BackColor = If(.button3, Color.Green, Color.White)
                bt4.BackColor = If(.button4, Color.Green, Color.White)
                bt5.BackColor = If(.button5, Color.Green, Color.White)
                bt6.BackColor = If(.button6, Color.Green, Color.White)
                bt7.BackColor = If(.button7, Color.Green, Color.White)
                bt8.BackColor = If(.button8, Color.Green, Color.White)
                bt9.BackColor = If(.button9, Color.Green, Color.White)
                lbGyroPitch.Text = _realPitch.ToString("0.0") & "º"
                lbGyroRoll.Text = _realRoll.ToString("0.0") & "º"
            End With
        End If

        If graph IsNot Nothing Then graph.UpdatePedals(fromArduino)

        'txtErrors.Text = Now.Subtract(timeStart).Ticks.ToString("0000000") & "    " & timeRead.Subtract(timeSent).Ticks.ToString("0000000")
        TimerProcessing = False
    End Sub




    Private Sub btWheelCenter_Click(sender As Object, e As EventArgs) Handles btWheelCenter.Click
        WheelPosition = 0 'My.Settings.WheelCenter = CInt(lbWheelPosNr.Text)
    End Sub



    Public Sub PowerFromAngle(pRealPitch As Single, pRealRoll As Single, pDesiredPitch As Single, pDesiredRoll As Single, ByRef OUTLeftPower As SByte, ByRef OUTRightPower As SByte)
        ' normalize Desires:
        If pDesiredPitch > My.Settings.MaxPitch Then pDesiredPitch = My.Settings.MaxPitch
        If pDesiredPitch < -My.Settings.MinPitch Then pDesiredPitch = -My.Settings.MinPitch
        If pDesiredRoll > My.Settings.MaxRoll Then pDesiredRoll = My.Settings.MaxRoll
        If pDesiredRoll < -My.Settings.MaxRoll Then pDesiredRoll = -My.Settings.MaxRoll

        ' draw realPitch:
        Dim backcolor As Color = If(pRealPitch > My.Settings.MaxPitch OrElse pRealPitch < -My.Settings.MinPitch, Color.Red, Color.White)
        Dim tmpAngle As Single = Math.Max(Math.Min(pRealPitch, My.Settings.MaxPitch), -My.Settings.MinPitch)
        If Me.WindowState <> FormWindowState.Minimized AndAlso ckDontShow.Checked = False Then
            Dim g As System.Drawing.Graphics = lbSimPitch.CreateGraphics()
            g.Clear(backcolor)
            Dim y As Integer = lbSimPitch.Height / 2 * tmpAngle / 45
            g.DrawLine(Pens.Blue, 0, CInt(lbSimPitch.Height / 2 + y), lbSimPitch.Width, CInt(lbSimPitch.Height / 2 - y))
            y = lbSimPitch.Height / 2 * _realPitch / 45
            g.DrawLine(Pens.Black, 0, CInt(lbSimPitch.Height / 2 + y), lbSimPitch.Width, CInt(lbSimPitch.Height / 2 - y))
        End If

        ' draw realRoll:
        backcolor = If(pRealRoll > My.Settings.MaxRoll OrElse pRealRoll < -My.Settings.MaxRoll, Color.Red, Color.White)
        tmpAngle = Math.Max(Math.Min(pRealRoll, My.Settings.MaxRoll), -My.Settings.MaxRoll)
        If Me.WindowState <> FormWindowState.Minimized AndAlso ckDontShow.Checked = False Then
            Dim g As System.Drawing.Graphics = lbSimRoll.CreateGraphics()
            g.Clear(backcolor)
            Dim y As Integer = lbSimRoll.Height / 2 * tmpAngle / 45
            g.DrawLine(Pens.Blue, 0, CInt(lbSimRoll.Height / 2 + y), lbSimRoll.Width, CInt(lbSimRoll.Height / 2 - y))
            y = lbSimRoll.Height / 2 * _realRoll / 45
            g.DrawLine(Pens.Black, 0, CInt(lbSimRoll.Height / 2 + y), lbSimRoll.Width, CInt(lbSimRoll.Height / 2 - y))
        End If

        ' com base no angulo actual e no pAngle calcular qual a força a aplicar nesse motor:
        Dim difPitch As Single = pDesiredPitch - pRealPitch
        Dim difRoll As Single = pDesiredRoll - pRealRoll
        Dim difLeft As Single = difPitch + difRoll
        Dim difRight As Single = difPitch - difRoll
        If difLeft > My.Settings.GHysteria Then
            OUTLeftPower = Math.Min(127, ScaleValue(difLeft, My.Settings.GHysteria, 0.8 * My.Settings.MaxPitch, My.Settings.GPowerForMin, My.Settings.GPowerForMax))
        ElseIf difLeft < -My.Settings.GHysteria Then
            OUTLeftPower = -Math.Min(127, ScaleValue(-difLeft, My.Settings.GHysteria, 0.8 * My.Settings.MaxPitch, My.Settings.GPowerForMin, My.Settings.GPowerForMax))
        Else
            OUTLeftPower = 0
        End If
        If difRight > My.Settings.GHysteria Then
            OUTRightPower = Math.Min(127, ScaleValue(difRight, My.Settings.GHysteria, 0.8 * My.Settings.MaxRoll, My.Settings.GPowerForMin, My.Settings.GPowerForMax))
        ElseIf difRight < -My.Settings.GHysteria Then
            OUTRightPower = -Math.Min(127, ScaleValue(-difRight, My.Settings.GHysteria, 0.8 * My.Settings.MaxRoll, My.Settings.GPowerForMin, My.Settings.GPowerForMax))
        Else
            OUTRightPower = 0
        End If
        Return
    End Sub





    Public Structure SerialSend
        Public wheelPower As Integer ' -255~255  0=no force
        Public leftPower As SByte  ' -127~127  0=no force
        Public rightPower As SByte ' -127~127  0=no force
        Public windPower As Byte
        Public rpm1 As Boolean
        Public rpm2 As Boolean
        Public slipFront As Boolean
        Public slipBack As Boolean

        Public Const PacketLen As Byte = 6

        Public Function GetSerialData() As Byte()
            Dim res(PacketLen - 1) As Byte
            res(0) = If(wheelPower < 0, 254, 255) ' checkdigit + wheelPowerDir
            res(1) = Math.Abs(wheelPower)
            res(2) = leftPower + 128
            res(3) = rightPower + 128
            res(4) = windPower
            If rpm1 Then res(5) += 1
            If rpm2 Then res(5) += 2
            If slipFront Then res(5) += 4
            If slipBack Then res(5) += 8
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

        Public Const PacketLen As Byte = 21

        Public Sub SetSerialData(pSerialData As Byte(), ByRef _gyroPitch As Single, ByRef _gyroRoll As Single, ByRef _realPitch As Single, ByRef _realRoll As Single)
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

            Dim accelX As Integer = pSerialData(9) * 256 + pSerialData(10) ' in Quids  
            Dim accelY As Integer = pSerialData(11) * 256 + pSerialData(12) ' in Quids  
            Dim accelZ As Integer = pSerialData(13) * 256 + pSerialData(14) ' in Quids 
            Dim gyroX As Integer = pSerialData(15) * 256 + pSerialData(16) ' in Quids  per second
            Dim gyroY As Integer = pSerialData(17) * 256 + pSerialData(18) ' in Quids  per second
            Dim gyroZ As Integer = pSerialData(19) * 256 + pSerialData(20) ' in Quids  per second

            ' pitch & roll from Accelerometer :
            Dim acc_total_vector As Single = Math.Sqrt(accelX ^ 2 + accelY ^ 2 + accelZ ^ 2)
            Dim accelPitch As Single = Math.Asin(accelY / acc_total_vector) * 57.296 + My.Settings.PitchOffset ' in degrees ' 57.296 = 180/PI
            Dim accelRoll As Single = Math.Asin(accelX / acc_total_vector) * -57.296 + My.Settings.RollOffset ' in degrees
            'Debug.Print(accelPitch.ToString("000.0") & "            " & accelRoll.ToString("000.0") & "                      " & accelX.ToString("000") & "            " & accelY.ToString("000") & "            " & accelZ.ToString("000"))

            ' pitch & roll from Gyroscope :
            _gyroPitch += gyroX * 0.0000611 ' 0.0000611 = 1 / (250Hz x 65.5)  Calculate the traveled pitch angle And add this to the angle_pitch variable
            _gyroRoll += gyroY * 0.0000611
            _gyroPitch += _gyroRoll * Math.Sin(gyroZ * 0.000001066) ' 0.000001066 = 0.0000611 * (PI / 180degr)  If the IMU has yawed transfer the roll angle To the pitch angel
            _gyroRoll -= _gyroPitch * Math.Sin(gyroZ * 0.000001066)

            Dim moved As Single = (Math.Abs(gyroX) + Math.Abs(gyroY) + Math.Abs(gyroZ)) / My.Settings.GyroMaxDegreesPerTimerClick
            If moved > 1 Then moved = 1
            _realPitch = accelPitch * (1 - moved) + _gyroPitch * moved
            _realRoll = accelRoll * (1 - moved) + _gyroRoll * moved

            If Ggraph IsNot Nothing AndAlso Not Ggraph.chkPause.Checked Then Ggraph.UpdateValue(accelPitch, _gyroPitch, moved, _realPitch)

            ' corrected analogic values:
            AccelCorrected = ScaleValue(pedalAccel, My.Settings.AccelMin, My.Settings.AccelMax, 0, 1023, My.Settings.AccelGama)
            BrakeCorrected = ScaleValue(pedalBreak, My.Settings.BrakeMin, My.Settings.BrakeMax, 0, 1023, My.Settings.BrakeGama)
            ClutchCorrected = ScaleValue(pedalClutch, My.Settings.ClutchMin, My.Settings.ClutchMax, 0, 1023, My.Settings.ClutchGama)
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
        txtErrors.Text &= vbCrLf & Now.ToLongTimeString & "  " & pNewErrorDescr
        txtErrors.SelectionStart = 32767 : txtErrors.ScrollToCaret()
    End Sub

    Private Sub SerialPort1_ErrorReceived(sender As Object, e As SerialErrorReceivedEventArgs) Handles SerialPort1.ErrorReceived
        MsgBox(e.ToString)
    End Sub

    Private Sub SerialPort1_PinChanged(sender As Object, e As SerialPinChangedEventArgs) Handles SerialPort1.PinChanged
        MsgBox(e.ToString)
    End Sub


    Private Function txt_Validate() As String
        Dim res As String = ""
        res &= ValidateNumber(txtRPM1, 0, 100, "%maxRPM for turning led1 on")
        res &= ValidateNumber(txtRPM2, 0, 100, "%maxRPM for turning led2 on")
        res &= ValidateNumber(txtMaxSpeed, 0, 999, "Car Speed for max Simulator Wind")
        res &= ValidateNumber(txtSlip, 0, 200, "Slip for turning led on")
        res &= ValidateNumber(txtPitch, -300, 300, "Car Pitch effect on Simulator Pitch")
        res &= ValidateNumber(txtRoll, -300, 300, "Car Roll effect on Simulator Roll")
        res &= ValidateNumber(txtJump, -9.9, 9.9, "Car Up/Down effect on Wind")
        res &= ValidateNumber(txtAccel, -90, 90, "Car Acceleration effect on Simulator Pitch")
        res &= ValidateNumber(txtTurn, -90, 90, "Car Turning effect on Simulator Roll")
        Return res
    End Function

    Private Sub ckKeepVisible_CheckedChanged(sender As Object, e As EventArgs) Handles ckKeepVisible.CheckedChanged
        Me.TopMost = ckKeepVisible.Checked
    End Sub

    Private Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click, btApply.Click
        Dim errors As String = txt_Validate()
        If Not String.IsNullOrEmpty(errors) Then
            MsgBox(errors)
            Return
        End If
        My.Settings.ACRpm1 = txtRPM1.Text / 100
        My.Settings.ACRpm2 = txtRPM2.Text / 100
        My.Settings.ACMaxSpeed = txtMaxSpeed.Text
        My.Settings.ACSlip = txtSlip.Text
        My.Settings.ACPitch = txtPitch.Text / 100
        My.Settings.ACRoll = txtRoll.Text / 100
        My.Settings.ACJump = txtJump.Text.Replace("G", "")
        My.Settings.ACAccel = txtAccel.Text
        My.Settings.ACTurn = txtTurn.Text
        If btSave.Equals(sender) Then My.Settings.Save()
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
                Dim tmp As VjdStat = Joy.GetVJDStatus(My.Settings.vJoyId)
                If tmp <> VjdStat.VJD_STAT_FREE Then
                    MsgBox("vJoy device  " & My.Settings.vJoyId & "  status is  " & tmp.ToString)
                    Joy = Nothing : Return
                End If
                Joy.AcquireVJD(My.Settings.vJoyId)
                'Joy.FfbStart(My.Settings.vJoyId)
                Joy.FfbRegisterGenCB(AddressOf FFBcallback, My.Settings.vJoyId)
            Catch ex As Exception
                MsgBox("btVJoy.Click " & ex.Message)
                Joy = Nothing
                Return
            End Try
            'btVJoy.Text = "Stop"
        Else
            Try
                'Joy.FfbStop(My.Settings.vJoyId)
                Joy.RelinquishVJD(My.Settings.vJoyId)
            Catch ex As Exception
            End Try
            Joy = Nothing
            'btVJoy.Text = "Start"
        End If
    End Sub




    Public Sub FFBcallback(pData As System.IntPtr, pUserdata As Object)
        ' https://github.com/shauleiz/vJoy/blob/master/SDK/src/vJoyClient.cpp
        ' https://msdn.microsoft.com/en-us/library/windows/desktop/ee416335%28v=vs.85%29.aspx?f=255&MSPPError=-2147217396
        'https://www.kaskus.co.id/thread/54c59a266208812a798b456b
        Dim devI As Integer
        Joy.Ffb_h_DeviceID(pData, devI)
        If devI <> My.Settings.vJoyId Then Return

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
                FFGain = tmpFFGain / 255.0F / 10000.0F

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
                If r.header.Device = My.Settings.MouseSteering Then
                    WheelPosition += r.data.LastX * My.Settings.WheelSensitivity
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
        If AC IsNot Nothing Then AC.Stop()
        AC = Nothing
        If SerialPort1.IsOpen Then
            SerialPort1.DiscardInBuffer()
            SerialPort1.Close()
        End If
        If Joy IsNot Nothing Then
            'Joy.FfbStop(My.Settings.vJoyId)
            Joy.RelinquishVJD(My.Settings.vJoyId)
            Joy = Nothing
        End If
        e.Cancel = False
    End Sub


    Private Function FFSteer(pWheelPosition As Integer) As Integer
        ' calculate steeringwheel ForceFeedback from -255 to 255:
        ' 
        Dim desiredTotalStrength As Single = 0 ' nominal = -10000 ~ 10000 (but can get to a lot more by summing up FF effects)
        If chkFFConst.Checked Then
            desiredTotalStrength = FFWheel_Const.Magnitude / 10000.0F ' -10000 ~ 10000 ' = Math.Abs(FFWheel_Const.Magnitude / 10000.0F) ^ (My.Settings.WheelPowerGama / 100.0F) * Math.Sign(FFWheel_Const.Magnitude) * 10000.0F * My.Settings.WheelPowerFactor ' -10000 ~ 10000
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
                If pWheelPosition > My.Settings.WheelDead Then
                    newPosition = pWheelPosition - My.Settings.WheelDead
                ElseIf pWheelPosition < -My.Settings.WheelDead Then
                    newPosition = pWheelPosition + My.Settings.WheelDead
                End If
                Dim timeElapsed As Single = Now.Subtract(LastWheelDate).Ticks
                'If Not ckDontShow.Checked Then lbTicks.Text = timeElapsed
                q = (newPosition - LastWheelPosition) * My.Settings.WheelDampFactor / timeElapsed 'q = (Math.Abs(pWheelPosition - LastWheelPosition) * My.Settings.WheelDampFactor / timeElapsed) ^ (My.Settings.WheelInertia / 100.0F) * Math.Sign(pWheelPosition - LastWheelPosition)
                LastWheelDate = Now : LastWheelPosition = newPosition
            ElseIf FFWheel_Type = FFBEType.ET_SPRNG Then
                If pWheelPosition > My.Settings.WheelDead Then
                    q = (pWheelPosition - My.Settings.WheelDead) / 1.637
                ElseIf pWheelPosition < -My.Settings.WheelDead Then
                    q = (pWheelPosition + My.Settings.WheelDead) / 1.637
                End If
            End If
            If q < 0 Then ' if Q is negative: I am not using FFWheel_Cond.CenterPointOffset - FFWheel_Cond.DeadBand  because they are allways zero, and their range would be -10000~10000 while Q range is -1~1 , and CVJoy has its own DeadZone
                desiredTotalStrength += FFWheel_Cond.NegCoeff * q '(q - (FFWheel_Cond.CenterPointOffset - FFWheel_Cond.DeadBand))
            ElseIf q > 0 Then ' if Q is positive:
                desiredTotalStrength += FFWheel_Cond.PosCoeff * q '(q - (FFWheel_Cond.CenterPointOffset + FFWheel_Cond.DeadBand))
            End If
        End If

        desiredTotalStrength *= FFGain
        If graph IsNot Nothing Then graph.UpdateFFWheel(Math.Abs(desiredTotalStrength))

        ' final output:
        Dim powerToApply As Integer = CalculateOutput(Math.Abs(desiredTotalStrength), 255, My.Settings.WheelMinInput, My.Settings.WheelPowerForMin, My.Settings.WheelPowerGama, My.Settings.WheelPowerFactor) * Math.Sign(desiredTotalStrength)
        'txtErrors.Text = "Res=" & res.ToString("000") & "      FFWheel=" & Math.Abs(FFWheel).ToString("000") & "   q=" & Math.Abs(q).ToString("00000") & "   PosCoeff=" & FFWheel_Cond.PosCoeff.ToString("00000") '& "     CenterPointOffset=" & FFWheel_Cond.CenterPointOffset.ToString("00000") & "     DeadBand=" & FFWheel_Cond.DeadBand.ToString("00000")
        Return powerToApply
    End Function

    Private Function FFWind(SpeedKmh As Integer, Jump As Single) As Integer
        Static lastJump As Byte
        Dim res As Single = (If(SpeedKmh > My.Settings.ACMinSpeed, SpeedKmh / My.Settings.ACMaxSpeed, 0) + (Jump - lastJump) / My.Settings.ACJump) * 255 ' typical 0~255, but can get to something like -2000~2000
        lastJump = Jump
        If graph IsNot Nothing Then graph.UpdateSpeed(res)
        Return CalculateOutput(res, 255, 0, My.Settings.SpeedMinPower, My.Settings.SpeedGama, 1)
    End Function

End Class
