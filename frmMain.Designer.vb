<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCVJoy
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btArduinoStart = New System.Windows.Forms.Button()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.lbLedTop = New System.Windows.Forms.Label()
        Me.lbLedBottom = New System.Windows.Forms.Label()
        Me.lbLedRight = New System.Windows.Forms.Label()
        Me.lbLedLeft = New System.Windows.Forms.Label()
        Me.G1 = New System.Windows.Forms.Label()
        Me.G2 = New System.Windows.Forms.Label()
        Me.G3 = New System.Windows.Forms.Label()
        Me.G4 = New System.Windows.Forms.Label()
        Me.G5 = New System.Windows.Forms.Label()
        Me.G6 = New System.Windows.Forms.Label()
        Me.GR = New System.Windows.Forms.Label()
        Me.lbHandbrake = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lbAttitude = New System.Windows.Forms.Label()
        Me.btSetup = New System.Windows.Forms.Button()
        Me.txtErrors = New System.Windows.Forms.TextBox()
        Me.lbWheelPos = New System.Windows.Forms.Label()
        Me.btWheelCenter = New System.Windows.Forms.Button()
        Me.ckDontShow = New System.Windows.Forms.CheckBox()
        Me.lbAccel = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbBrake = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lbClutch = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.ckKeepVisible = New System.Windows.Forms.CheckBox()
        Me.chkNoWind = New System.Windows.Forms.CheckBox()
        Me.cbLog = New System.Windows.Forms.ComboBox()
        Me.chkFFConst = New System.Windows.Forms.CheckBox()
        Me.chkFFCond = New System.Windows.Forms.CheckBox()
        Me.btGameStart = New System.Windows.Forms.Button()
        Me.lbGameInfo = New System.Windows.Forms.Label()
        Me.btGameSetup = New System.Windows.Forms.Button()
        Me.UcButtons1 = New CVJoy.ucButtons()
        Me.cbGames = New System.Windows.Forms.ComboBox()
        Me.lbTemperature = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btArduinoStart
        '
        Me.btArduinoStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btArduinoStart.BackColor = System.Drawing.Color.Gold
        Me.btArduinoStart.Location = New System.Drawing.Point(411, 141)
        Me.btArduinoStart.Name = "btArduinoStart"
        Me.btArduinoStart.Size = New System.Drawing.Size(108, 22)
        Me.btArduinoStart.TabIndex = 0
        Me.btArduinoStart.Text = "Connect to Arduino"
        Me.btArduinoStart.UseVisualStyleBackColor = False
        '
        'SerialPort1
        '
        Me.SerialPort1.BaudRate = 115200
        Me.SerialPort1.ReadBufferSize = 128
        Me.SerialPort1.ReceivedBytesThreshold = 2
        Me.SerialPort1.WriteBufferSize = 128
        '
        'lbLedTop
        '
        Me.lbLedTop.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbLedTop.BackColor = System.Drawing.Color.Red
        Me.lbLedTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbLedTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLedTop.Location = New System.Drawing.Point(129, 18)
        Me.lbLedTop.Name = "lbLedTop"
        Me.lbLedTop.Size = New System.Drawing.Size(27, 20)
        Me.lbLedTop.TabIndex = 9
        Me.lbLedTop.Text = "Slip Front"
        Me.lbLedTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbLedBottom
        '
        Me.lbLedBottom.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbLedBottom.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.lbLedBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbLedBottom.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLedBottom.Location = New System.Drawing.Point(129, 60)
        Me.lbLedBottom.Name = "lbLedBottom"
        Me.lbLedBottom.Size = New System.Drawing.Size(27, 20)
        Me.lbLedBottom.TabIndex = 12
        Me.lbLedBottom.Text = "Slip Back"
        Me.lbLedBottom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbLedRight
        '
        Me.lbLedRight.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbLedRight.BackColor = System.Drawing.Color.Gold
        Me.lbLedRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbLedRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLedRight.Location = New System.Drawing.Point(143, 39)
        Me.lbLedRight.Name = "lbLedRight"
        Me.lbLedRight.Size = New System.Drawing.Size(27, 20)
        Me.lbLedRight.TabIndex = 11
        Me.lbLedRight.Text = "RPM >"
        Me.lbLedRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbLedLeft
        '
        Me.lbLedLeft.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbLedLeft.BackColor = System.Drawing.Color.LimeGreen
        Me.lbLedLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbLedLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLedLeft.Location = New System.Drawing.Point(115, 39)
        Me.lbLedLeft.Name = "lbLedLeft"
        Me.lbLedLeft.Size = New System.Drawing.Size(27, 20)
        Me.lbLedLeft.TabIndex = 10
        Me.lbLedLeft.Text = "RPM <"
        Me.lbLedLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'G1
        '
        Me.G1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.G1.BackColor = System.Drawing.Color.Gray
        Me.G1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.G1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.G1.Location = New System.Drawing.Point(98, 85)
        Me.G1.Name = "G1"
        Me.G1.Size = New System.Drawing.Size(11, 20)
        Me.G1.TabIndex = 13
        Me.G1.Text = "1"
        Me.G1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'G2
        '
        Me.G2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.G2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.G2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.G2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.G2.Location = New System.Drawing.Point(112, 85)
        Me.G2.Name = "G2"
        Me.G2.Size = New System.Drawing.Size(11, 20)
        Me.G2.TabIndex = 14
        Me.G2.Text = "2"
        Me.G2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'G3
        '
        Me.G3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.G3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.G3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.G3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.G3.Location = New System.Drawing.Point(126, 85)
        Me.G3.Name = "G3"
        Me.G3.Size = New System.Drawing.Size(11, 20)
        Me.G3.TabIndex = 15
        Me.G3.Text = "3"
        Me.G3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'G4
        '
        Me.G4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.G4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.G4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.G4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.G4.Location = New System.Drawing.Point(140, 85)
        Me.G4.Name = "G4"
        Me.G4.Size = New System.Drawing.Size(11, 20)
        Me.G4.TabIndex = 16
        Me.G4.Text = "4"
        Me.G4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'G5
        '
        Me.G5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.G5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.G5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.G5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.G5.Location = New System.Drawing.Point(154, 85)
        Me.G5.Name = "G5"
        Me.G5.Size = New System.Drawing.Size(11, 20)
        Me.G5.TabIndex = 17
        Me.G5.Text = "5"
        Me.G5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'G6
        '
        Me.G6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.G6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.G6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.G6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.G6.Location = New System.Drawing.Point(168, 85)
        Me.G6.Name = "G6"
        Me.G6.Size = New System.Drawing.Size(11, 20)
        Me.G6.TabIndex = 18
        Me.G6.Text = "6"
        Me.G6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GR
        '
        Me.GR.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GR.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GR.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GR.Location = New System.Drawing.Point(182, 85)
        Me.GR.Name = "GR"
        Me.GR.Size = New System.Drawing.Size(11, 20)
        Me.GR.TabIndex = 19
        Me.GR.Text = "R"
        Me.GR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbHandbrake
        '
        Me.lbHandbrake.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbHandbrake.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbHandbrake.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbHandbrake.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbHandbrake.Location = New System.Drawing.Point(196, 85)
        Me.lbHandbrake.Name = "lbHandbrake"
        Me.lbHandbrake.Size = New System.Drawing.Size(45, 20)
        Me.lbHandbrake.TabIndex = 20
        Me.lbHandbrake.Text = "Brake"
        Me.lbHandbrake.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        '
        'lbAttitude
        '
        Me.lbAttitude.BackColor = System.Drawing.Color.White
        Me.lbAttitude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbAttitude.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAttitude.Location = New System.Drawing.Point(319, 2)
        Me.lbAttitude.Name = "lbAttitude"
        Me.lbAttitude.Size = New System.Drawing.Size(201, 125)
        Me.lbAttitude.TabIndex = 81
        Me.lbAttitude.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btSetup
        '
        Me.btSetup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btSetup.BackColor = System.Drawing.Color.Gold
        Me.btSetup.Location = New System.Drawing.Point(349, 141)
        Me.btSetup.Name = "btSetup"
        Me.btSetup.Size = New System.Drawing.Size(59, 22)
        Me.btSetup.TabIndex = 82
        Me.btSetup.Text = "Setup"
        Me.btSetup.UseVisualStyleBackColor = False
        '
        'txtErrors
        '
        Me.txtErrors.AcceptsReturn = True
        Me.txtErrors.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtErrors.BackColor = System.Drawing.Color.Black
        Me.txtErrors.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtErrors.ForeColor = System.Drawing.Color.SpringGreen
        Me.txtErrors.Location = New System.Drawing.Point(0, 200)
        Me.txtErrors.Multiline = True
        Me.txtErrors.Name = "txtErrors"
        Me.txtErrors.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtErrors.Size = New System.Drawing.Size(521, 114)
        Me.txtErrors.TabIndex = 83
        Me.txtErrors.WordWrap = False
        '
        'lbWheelPos
        '
        Me.lbWheelPos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbWheelPos.BackColor = System.Drawing.Color.White
        Me.lbWheelPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbWheelPos.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lbWheelPos.Location = New System.Drawing.Point(0, 129)
        Me.lbWheelPos.Name = "lbWheelPos"
        Me.lbWheelPos.Size = New System.Drawing.Size(521, 9)
        Me.lbWheelPos.TabIndex = 86
        Me.lbWheelPos.UseMnemonic = False
        '
        'btWheelCenter
        '
        Me.btWheelCenter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btWheelCenter.BackColor = System.Drawing.Color.Gold
        Me.btWheelCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btWheelCenter.Location = New System.Drawing.Point(139, 109)
        Me.btWheelCenter.Name = "btWheelCenter"
        Me.btWheelCenter.Size = New System.Drawing.Size(59, 20)
        Me.btWheelCenter.TabIndex = 88
        Me.btWheelCenter.Text = "Set Center"
        Me.btWheelCenter.UseVisualStyleBackColor = False
        '
        'ckDontShow
        '
        Me.ckDontShow.AutoSize = True
        Me.ckDontShow.BackColor = System.Drawing.Color.Transparent
        Me.ckDontShow.Location = New System.Drawing.Point(21, 143)
        Me.ckDontShow.Name = "ckDontShow"
        Me.ckDontShow.Size = New System.Drawing.Size(79, 17)
        Me.ckDontShow.TabIndex = 93
        Me.ckDontShow.Text = "Dont Show"
        Me.ckDontShow.UseVisualStyleBackColor = False
        '
        'lbAccel
        '
        Me.lbAccel.Location = New System.Drawing.Point(42, 30)
        Me.lbAccel.Name = "lbAccel"
        Me.lbAccel.Size = New System.Drawing.Size(34, 13)
        Me.lbAccel.TabIndex = 100
        Me.lbAccel.Text = "1024"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 99
        Me.Label5.Text = "Accel:"
        '
        'lbBrake
        '
        Me.lbBrake.Location = New System.Drawing.Point(42, 47)
        Me.lbBrake.Name = "lbBrake"
        Me.lbBrake.Size = New System.Drawing.Size(34, 13)
        Me.lbBrake.TabIndex = 102
        Me.lbBrake.Text = "1024"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(1, 47)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(38, 13)
        Me.Label18.TabIndex = 101
        Me.Label18.Text = "Brake:"
        '
        'lbClutch
        '
        Me.lbClutch.Location = New System.Drawing.Point(42, 64)
        Me.lbClutch.Name = "lbClutch"
        Me.lbClutch.Size = New System.Drawing.Size(34, 13)
        Me.lbClutch.TabIndex = 104
        Me.lbClutch.Text = "1024"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(1, 64)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(40, 13)
        Me.Label27.TabIndex = 103
        Me.Label27.Text = "Clutch:"
        '
        'ckKeepVisible
        '
        Me.ckKeepVisible.AutoSize = True
        Me.ckKeepVisible.BackColor = System.Drawing.Color.Transparent
        Me.ckKeepVisible.Location = New System.Drawing.Point(21, 163)
        Me.ckKeepVisible.Name = "ckKeepVisible"
        Me.ckKeepVisible.Size = New System.Drawing.Size(84, 17)
        Me.ckKeepVisible.TabIndex = 105
        Me.ckKeepVisible.Text = "Keep Visible"
        Me.ckKeepVisible.UseVisualStyleBackColor = False
        '
        'chkNoWind
        '
        Me.chkNoWind.AutoSize = True
        Me.chkNoWind.BackColor = System.Drawing.Color.Transparent
        Me.chkNoWind.Location = New System.Drawing.Point(144, 143)
        Me.chkNoWind.Name = "chkNoWind"
        Me.chkNoWind.Size = New System.Drawing.Size(89, 17)
        Me.chkNoWind.TabIndex = 114
        Me.chkNoWind.Text = "Disable Wind"
        Me.chkNoWind.UseVisualStyleBackColor = False
        '
        'cbLog
        '
        Me.cbLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLog.Location = New System.Drawing.Point(383, 200)
        Me.cbLog.Name = "cbLog"
        Me.cbLog.Size = New System.Drawing.Size(121, 21)
        Me.cbLog.TabIndex = 125
        '
        'chkFFConst
        '
        Me.chkFFConst.BackColor = System.Drawing.Color.Transparent
        Me.chkFFConst.Checked = True
        Me.chkFFConst.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFFConst.ForeColor = System.Drawing.Color.Green
        Me.chkFFConst.Location = New System.Drawing.Point(58, 111)
        Me.chkFFConst.Margin = New System.Windows.Forms.Padding(0)
        Me.chkFFConst.Name = "chkFFConst"
        Me.chkFFConst.Size = New System.Drawing.Size(79, 17)
        Me.chkFFConst.TabIndex = 126
        Me.chkFFConst.Text = "FF Const"
        Me.chkFFConst.UseVisualStyleBackColor = False
        '
        'chkFFCond
        '
        Me.chkFFCond.BackColor = System.Drawing.Color.Transparent
        Me.chkFFCond.Checked = True
        Me.chkFFCond.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFFCond.ForeColor = System.Drawing.Color.DarkOrchid
        Me.chkFFCond.Location = New System.Drawing.Point(222, 111)
        Me.chkFFCond.Margin = New System.Windows.Forms.Padding(0)
        Me.chkFFCond.Name = "chkFFCond"
        Me.chkFFCond.Size = New System.Drawing.Size(79, 17)
        Me.chkFFCond.TabIndex = 127
        Me.chkFFCond.Text = "FF Cond"
        Me.chkFFCond.UseVisualStyleBackColor = False
        '
        'btGameStart
        '
        Me.btGameStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btGameStart.BackColor = System.Drawing.Color.Gold
        Me.btGameStart.Location = New System.Drawing.Point(413, 164)
        Me.btGameStart.Name = "btGameStart"
        Me.btGameStart.Size = New System.Drawing.Size(106, 22)
        Me.btGameStart.TabIndex = 129
        Me.btGameStart.Text = "Connect to game"
        Me.btGameStart.UseVisualStyleBackColor = False
        '
        'lbGameInfo
        '
        Me.lbGameInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbGameInfo.BackColor = System.Drawing.SystemColors.Info
        Me.lbGameInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbGameInfo.ForeColor = System.Drawing.SystemColors.InfoText
        Me.lbGameInfo.Location = New System.Drawing.Point(1, 185)
        Me.lbGameInfo.Name = "lbGameInfo"
        Me.lbGameInfo.Size = New System.Drawing.Size(520, 13)
        Me.lbGameInfo.TabIndex = 128
        Me.lbGameInfo.Text = "   connection to selected game..."
        '
        'btGameSetup
        '
        Me.btGameSetup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btGameSetup.BackColor = System.Drawing.Color.Gold
        Me.btGameSetup.Location = New System.Drawing.Point(349, 164)
        Me.btGameSetup.Name = "btGameSetup"
        Me.btGameSetup.Size = New System.Drawing.Size(59, 22)
        Me.btGameSetup.TabIndex = 130
        Me.btGameSetup.Text = "Setup"
        Me.btGameSetup.UseVisualStyleBackColor = False
        '
        'UcButtons1
        '
        Me.UcButtons1.Location = New System.Drawing.Point(1, 0)
        Me.UcButtons1.Name = "UcButtons1"
        Me.UcButtons1.ReadOnly = False
        Me.UcButtons1.Size = New System.Drawing.Size(282, 19)
        Me.UcButtons1.TabIndex = 131
        '
        'cbGames
        '
        Me.cbGames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGames.FormattingEnabled = True
        Me.cbGames.Location = New System.Drawing.Point(144, 165)
        Me.cbGames.Name = "cbGames"
        Me.cbGames.Size = New System.Drawing.Size(199, 21)
        Me.cbGames.TabIndex = 133
        '
        'lbTemperature
        '
        Me.lbTemperature.BackColor = System.Drawing.Color.Transparent
        Me.lbTemperature.Location = New System.Drawing.Point(279, 64)
        Me.lbTemperature.Name = "lbTemperature"
        Me.lbTemperature.Size = New System.Drawing.Size(23, 13)
        Me.lbTemperature.TabIndex = 135
        Me.lbTemperature.Text = "9.9"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(229, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 134
        Me.Label2.Text = "Overheat:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(298, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 136
        Me.Label3.Text = "mm"
        '
        'frmCVJoy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(521, 315)
        Me.Controls.Add(Me.lbAttitude)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbTemperature)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbGames)
        Me.Controls.Add(Me.UcButtons1)
        Me.Controls.Add(Me.btGameSetup)
        Me.Controls.Add(Me.btGameStart)
        Me.Controls.Add(Me.lbGameInfo)
        Me.Controls.Add(Me.chkFFCond)
        Me.Controls.Add(Me.chkFFConst)
        Me.Controls.Add(Me.cbLog)
        Me.Controls.Add(Me.chkNoWind)
        Me.Controls.Add(Me.lbClutch)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.lbBrake)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.lbAccel)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btWheelCenter)
        Me.Controls.Add(Me.lbWheelPos)
        Me.Controls.Add(Me.txtErrors)
        Me.Controls.Add(Me.btSetup)
        Me.Controls.Add(Me.lbHandbrake)
        Me.Controls.Add(Me.GR)
        Me.Controls.Add(Me.G6)
        Me.Controls.Add(Me.G5)
        Me.Controls.Add(Me.G4)
        Me.Controls.Add(Me.G3)
        Me.Controls.Add(Me.G2)
        Me.Controls.Add(Me.G1)
        Me.Controls.Add(Me.lbLedLeft)
        Me.Controls.Add(Me.lbLedRight)
        Me.Controls.Add(Me.lbLedBottom)
        Me.Controls.Add(Me.lbLedTop)
        Me.Controls.Add(Me.btArduinoStart)
        Me.Controls.Add(Me.ckKeepVisible)
        Me.Controls.Add(Me.ckDontShow)
        Me.Name = "frmCVJoy"
        Me.Text = "CV Joy"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btArduinoStart As Button
    Friend WithEvents lbLedTop As Label
    Friend WithEvents lbLedBottom As Label
    Friend WithEvents lbLedRight As Label
    Friend WithEvents lbLedLeft As Label
    Friend WithEvents G1 As Label
    Friend WithEvents G2 As Label
    Friend WithEvents G3 As Label
    Friend WithEvents G4 As Label
    Friend WithEvents G5 As Label
    Friend WithEvents G6 As Label
    Friend WithEvents GR As Label
    Friend WithEvents lbHandbrake As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lbAttitude As Label
    Friend WithEvents btSetup As Button
    Public WithEvents SerialPort1 As IO.Ports.SerialPort
    Public WithEvents txtErrors As TextBox
    Friend WithEvents lbWheelPos As Label
    Friend WithEvents btWheelCenter As Button
    Friend WithEvents ckDontShow As CheckBox
    Friend WithEvents lbAccel As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lbBrake As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents lbClutch As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents ckKeepVisible As CheckBox
    Friend WithEvents chkNoWind As CheckBox
    Friend WithEvents cbLog As ComboBox
    Friend WithEvents chkFFConst As CheckBox
    Friend WithEvents chkFFCond As CheckBox
    Friend WithEvents btGameStart As Button
    Friend WithEvents lbGameInfo As Label
    Friend WithEvents btGameSetup As Button
    Friend WithEvents UcButtons1 As ucButtons
    Friend WithEvents cbGames As ComboBox
    Friend WithEvents lbTemperature As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
