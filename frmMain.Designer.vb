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
        Me.btArduinoStart = New System.Windows.Forms.Button()
        Me.G1 = New System.Windows.Forms.Label()
        Me.G2 = New System.Windows.Forms.Label()
        Me.G3 = New System.Windows.Forms.Label()
        Me.G4 = New System.Windows.Forms.Label()
        Me.G5 = New System.Windows.Forms.Label()
        Me.G6 = New System.Windows.Forms.Label()
        Me.GR = New System.Windows.Forms.Label()
        Me.lbHandbrake = New System.Windows.Forms.Label()
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
        Me.cbLogFF = New System.Windows.Forms.ComboBox()
        Me.chkFFConst = New System.Windows.Forms.CheckBox()
        Me.chkFFCond = New System.Windows.Forms.CheckBox()
        Me.btGameStart = New System.Windows.Forms.Button()
        Me.lbGameInfo = New System.Windows.Forms.Label()
        Me.btGameSetup = New System.Windows.Forms.Button()
        Me.cbGames = New System.Windows.Forms.ComboBox()
        Me.lbTemperature = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkNoMotors = New System.Windows.Forms.CheckBox()
        Me.lbMainsPower = New System.Windows.Forms.Label()
        Me.chkFFIgnore = New System.Windows.Forms.CheckBox()
        Me.chkLogHideDups = New System.Windows.Forms.CheckBox()
        Me.btLogClear = New System.Windows.Forms.Button()
        Me.chkUDP = New System.Windows.Forms.CheckBox()
        Me.UcButtons1 = New CVJoy.ucButtons()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbReadPedalsHz = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lbReadFFBHz = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lbToArduinoHz = New System.Windows.Forms.Label()
        Me.btCountersReset = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btArduinoStart
        '
        Me.btArduinoStart.BackColor = System.Drawing.Color.Gold
        Me.btArduinoStart.Location = New System.Drawing.Point(459, 184)
        Me.btArduinoStart.Name = "btArduinoStart"
        Me.btArduinoStart.Size = New System.Drawing.Size(108, 22)
        Me.btArduinoStart.TabIndex = 0
        Me.btArduinoStart.Text = "Connect to Arduino"
        Me.btArduinoStart.UseVisualStyleBackColor = False
        '
        'G1
        '
        Me.G1.BackColor = System.Drawing.Color.Gray
        Me.G1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.G1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.G1.Location = New System.Drawing.Point(100, 122)
        Me.G1.Name = "G1"
        Me.G1.Size = New System.Drawing.Size(11, 20)
        Me.G1.TabIndex = 13
        Me.G1.Text = "1"
        Me.G1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'G2
        '
        Me.G2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.G2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.G2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.G2.Location = New System.Drawing.Point(114, 122)
        Me.G2.Name = "G2"
        Me.G2.Size = New System.Drawing.Size(11, 20)
        Me.G2.TabIndex = 14
        Me.G2.Text = "2"
        Me.G2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'G3
        '
        Me.G3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.G3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.G3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.G3.Location = New System.Drawing.Point(128, 122)
        Me.G3.Name = "G3"
        Me.G3.Size = New System.Drawing.Size(11, 20)
        Me.G3.TabIndex = 15
        Me.G3.Text = "3"
        Me.G3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'G4
        '
        Me.G4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.G4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.G4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.G4.Location = New System.Drawing.Point(142, 122)
        Me.G4.Name = "G4"
        Me.G4.Size = New System.Drawing.Size(11, 20)
        Me.G4.TabIndex = 16
        Me.G4.Text = "4"
        Me.G4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'G5
        '
        Me.G5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.G5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.G5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.G5.Location = New System.Drawing.Point(156, 122)
        Me.G5.Name = "G5"
        Me.G5.Size = New System.Drawing.Size(11, 20)
        Me.G5.TabIndex = 17
        Me.G5.Text = "5"
        Me.G5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'G6
        '
        Me.G6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.G6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.G6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.G6.Location = New System.Drawing.Point(170, 122)
        Me.G6.Name = "G6"
        Me.G6.Size = New System.Drawing.Size(11, 20)
        Me.G6.TabIndex = 18
        Me.G6.Text = "6"
        Me.G6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GR
        '
        Me.GR.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GR.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GR.Location = New System.Drawing.Point(184, 122)
        Me.GR.Name = "GR"
        Me.GR.Size = New System.Drawing.Size(11, 20)
        Me.GR.TabIndex = 19
        Me.GR.Text = "R"
        Me.GR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbHandbrake
        '
        Me.lbHandbrake.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbHandbrake.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbHandbrake.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbHandbrake.Location = New System.Drawing.Point(198, 122)
        Me.lbHandbrake.Name = "lbHandbrake"
        Me.lbHandbrake.Size = New System.Drawing.Size(45, 20)
        Me.lbHandbrake.TabIndex = 20
        Me.lbHandbrake.Text = "Brake"
        Me.lbHandbrake.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbAttitude
        '
        Me.lbAttitude.BackColor = System.Drawing.Color.White
        Me.lbAttitude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbAttitude.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAttitude.Location = New System.Drawing.Point(397, 0)
        Me.lbAttitude.Name = "lbAttitude"
        Me.lbAttitude.Size = New System.Drawing.Size(170, 170)
        Me.lbAttitude.TabIndex = 81
        Me.lbAttitude.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btSetup
        '
        Me.btSetup.BackColor = System.Drawing.Color.Gold
        Me.btSetup.Location = New System.Drawing.Point(396, 184)
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
        Me.txtErrors.Location = New System.Drawing.Point(0, 243)
        Me.txtErrors.Multiline = True
        Me.txtErrors.Name = "txtErrors"
        Me.txtErrors.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtErrors.Size = New System.Drawing.Size(567, 142)
        Me.txtErrors.TabIndex = 83
        Me.txtErrors.WordWrap = False
        '
        'lbWheelPos
        '
        Me.lbWheelPos.BackColor = System.Drawing.Color.White
        Me.lbWheelPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbWheelPos.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lbWheelPos.Location = New System.Drawing.Point(0, 172)
        Me.lbWheelPos.Name = "lbWheelPos"
        Me.lbWheelPos.Size = New System.Drawing.Size(567, 9)
        Me.lbWheelPos.TabIndex = 86
        Me.lbWheelPos.UseMnemonic = False
        '
        'btWheelCenter
        '
        Me.btWheelCenter.BackColor = System.Drawing.Color.Gold
        Me.btWheelCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btWheelCenter.Location = New System.Drawing.Point(254, 152)
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
        Me.ckDontShow.Location = New System.Drawing.Point(4, 46)
        Me.ckDontShow.Name = "ckDontShow"
        Me.ckDontShow.Size = New System.Drawing.Size(79, 17)
        Me.ckDontShow.TabIndex = 93
        Me.ckDontShow.Text = "Dont Show"
        Me.ckDontShow.UseVisualStyleBackColor = False
        '
        'lbAccel
        '
        Me.lbAccel.Location = New System.Drawing.Point(42, 73)
        Me.lbAccel.Name = "lbAccel"
        Me.lbAccel.Size = New System.Drawing.Size(34, 13)
        Me.lbAccel.TabIndex = 100
        Me.lbAccel.Text = "1024"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 99
        Me.Label5.Text = "Accel:"
        '
        'lbBrake
        '
        Me.lbBrake.Location = New System.Drawing.Point(42, 90)
        Me.lbBrake.Name = "lbBrake"
        Me.lbBrake.Size = New System.Drawing.Size(34, 13)
        Me.lbBrake.TabIndex = 102
        Me.lbBrake.Text = "1024"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(1, 90)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(38, 13)
        Me.Label18.TabIndex = 101
        Me.Label18.Text = "Brake:"
        '
        'lbClutch
        '
        Me.lbClutch.Location = New System.Drawing.Point(42, 107)
        Me.lbClutch.Name = "lbClutch"
        Me.lbClutch.Size = New System.Drawing.Size(34, 13)
        Me.lbClutch.TabIndex = 104
        Me.lbClutch.Text = "1024"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(1, 107)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(40, 13)
        Me.Label27.TabIndex = 103
        Me.Label27.Text = "Clutch:"
        '
        'ckKeepVisible
        '
        Me.ckKeepVisible.AutoSize = True
        Me.ckKeepVisible.BackColor = System.Drawing.Color.Transparent
        Me.ckKeepVisible.Location = New System.Drawing.Point(136, 46)
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
        Me.chkNoWind.Location = New System.Drawing.Point(87, 187)
        Me.chkNoWind.Name = "chkNoWind"
        Me.chkNoWind.Size = New System.Drawing.Size(89, 17)
        Me.chkNoWind.TabIndex = 114
        Me.chkNoWind.Text = "Disable Wind"
        Me.chkNoWind.UseVisualStyleBackColor = False
        '
        'cbLogFF
        '
        Me.cbLogFF.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbLogFF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLogFF.Location = New System.Drawing.Point(458, 328)
        Me.cbLogFF.Name = "cbLogFF"
        Me.cbLogFF.Size = New System.Drawing.Size(92, 21)
        Me.cbLogFF.TabIndex = 125
        '
        'chkFFConst
        '
        Me.chkFFConst.BackColor = System.Drawing.Color.Transparent
        Me.chkFFConst.Checked = True
        Me.chkFFConst.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFFConst.ForeColor = System.Drawing.Color.Green
        Me.chkFFConst.Location = New System.Drawing.Point(87, 154)
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
        Me.chkFFCond.Location = New System.Drawing.Point(167, 154)
        Me.chkFFCond.Margin = New System.Windows.Forms.Padding(0)
        Me.chkFFCond.Name = "chkFFCond"
        Me.chkFFCond.Size = New System.Drawing.Size(79, 17)
        Me.chkFFCond.TabIndex = 127
        Me.chkFFCond.Text = "FF Cond"
        Me.chkFFCond.UseVisualStyleBackColor = False
        '
        'btGameStart
        '
        Me.btGameStart.BackColor = System.Drawing.Color.Gold
        Me.btGameStart.Location = New System.Drawing.Point(459, 207)
        Me.btGameStart.Name = "btGameStart"
        Me.btGameStart.Size = New System.Drawing.Size(108, 22)
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
        Me.lbGameInfo.Location = New System.Drawing.Point(1, 228)
        Me.lbGameInfo.Name = "lbGameInfo"
        Me.lbGameInfo.Size = New System.Drawing.Size(566, 13)
        Me.lbGameInfo.TabIndex = 128
        Me.lbGameInfo.Text = "   connection to selected game..."
        '
        'btGameSetup
        '
        Me.btGameSetup.BackColor = System.Drawing.Color.Gold
        Me.btGameSetup.Location = New System.Drawing.Point(396, 207)
        Me.btGameSetup.Name = "btGameSetup"
        Me.btGameSetup.Size = New System.Drawing.Size(59, 22)
        Me.btGameSetup.TabIndex = 130
        Me.btGameSetup.Text = "Setup"
        Me.btGameSetup.UseVisualStyleBackColor = False
        '
        'cbGames
        '
        Me.cbGames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGames.FormattingEnabled = True
        Me.cbGames.Location = New System.Drawing.Point(188, 208)
        Me.cbGames.Name = "cbGames"
        Me.cbGames.Size = New System.Drawing.Size(203, 21)
        Me.cbGames.TabIndex = 133
        '
        'lbTemperature
        '
        Me.lbTemperature.BackColor = System.Drawing.Color.Transparent
        Me.lbTemperature.Location = New System.Drawing.Point(338, 129)
        Me.lbTemperature.Name = "lbTemperature"
        Me.lbTemperature.Size = New System.Drawing.Size(23, 13)
        Me.lbTemperature.TabIndex = 135
        Me.lbTemperature.Text = "9.9"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(274, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 134
        Me.Label2.Text = "Overheat:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(365, 129)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 136
        Me.Label3.Text = "mm"
        '
        'chkNoMotors
        '
        Me.chkNoMotors.AutoSize = True
        Me.chkNoMotors.BackColor = System.Drawing.Color.Transparent
        Me.chkNoMotors.Location = New System.Drawing.Point(211, 187)
        Me.chkNoMotors.Name = "chkNoMotors"
        Me.chkNoMotors.Size = New System.Drawing.Size(112, 17)
        Me.chkNoMotors.TabIndex = 137
        Me.chkNoMotors.Text = "Disable Pitch&Roll"
        Me.chkNoMotors.UseMnemonic = False
        Me.chkNoMotors.UseVisualStyleBackColor = False
        '
        'lbMainsPower
        '
        Me.lbMainsPower.BackColor = System.Drawing.Color.Transparent
        Me.lbMainsPower.Location = New System.Drawing.Point(274, 111)
        Me.lbMainsPower.Name = "lbMainsPower"
        Me.lbMainsPower.Size = New System.Drawing.Size(93, 13)
        Me.lbMainsPower.TabIndex = 138
        Me.lbMainsPower.Text = "Mains Power OFF"
        '
        'chkFFIgnore
        '
        Me.chkFFIgnore.AutoSize = True
        Me.chkFFIgnore.BackColor = System.Drawing.Color.Transparent
        Me.chkFFIgnore.Location = New System.Drawing.Point(3, 154)
        Me.chkFFIgnore.Name = "chkFFIgnore"
        Me.chkFFIgnore.Size = New System.Drawing.Size(71, 17)
        Me.chkFFIgnore.TabIndex = 139
        Me.chkFFIgnore.Text = "Ignore FF"
        Me.chkFFIgnore.UseMnemonic = False
        Me.chkFFIgnore.UseVisualStyleBackColor = False
        '
        'chkLogHideDups
        '
        Me.chkLogHideDups.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkLogHideDups.BackColor = System.Drawing.Color.Transparent
        Me.chkLogHideDups.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkLogHideDups.Checked = True
        Me.chkLogHideDups.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkLogHideDups.Location = New System.Drawing.Point(458, 310)
        Me.chkLogHideDups.Name = "chkLogHideDups"
        Me.chkLogHideDups.Size = New System.Drawing.Size(92, 17)
        Me.chkLogHideDups.TabIndex = 142
        Me.chkLogHideDups.Text = "Hide dups"
        Me.chkLogHideDups.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkLogHideDups.UseMnemonic = False
        Me.chkLogHideDups.UseVisualStyleBackColor = False
        '
        'btLogClear
        '
        Me.btLogClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btLogClear.BackColor = System.Drawing.Color.Gold
        Me.btLogClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btLogClear.Location = New System.Drawing.Point(458, 350)
        Me.btLogClear.Name = "btLogClear"
        Me.btLogClear.Size = New System.Drawing.Size(92, 20)
        Me.btLogClear.TabIndex = 143
        Me.btLogClear.Text = "Clear"
        Me.btLogClear.UseVisualStyleBackColor = False
        '
        'chkUDP
        '
        Me.chkUDP.AutoSize = True
        Me.chkUDP.BackColor = System.Drawing.Color.Transparent
        Me.chkUDP.Checked = True
        Me.chkUDP.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUDP.Location = New System.Drawing.Point(2, 187)
        Me.chkUDP.Name = "chkUDP"
        Me.chkUDP.Size = New System.Drawing.Size(49, 17)
        Me.chkUDP.TabIndex = 145
        Me.chkUDP.Text = "UDP"
        Me.chkUDP.UseVisualStyleBackColor = False
        '
        'UcButtons1
        '
        Me.UcButtons1.Location = New System.Drawing.Point(2, 0)
        Me.UcButtons1.Name = "UcButtons1"
        Me.UcButtons1.ReadOnly = False
        Me.UcButtons1.ShowDescriptions = False
        Me.UcButtons1.Size = New System.Drawing.Size(391, 37)
        Me.UcButtons1.TabIndex = 144
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(286, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 12)
        Me.Label6.TabIndex = 150
        Me.Label6.Text = "read FFB"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(365, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(26, 12)
        Me.Label7.TabIndex = 149
        Me.Label7.Text = "Hz"
        '
        'lbReadPedalsHz
        '
        Me.lbReadPedalsHz.BackColor = System.Drawing.Color.Transparent
        Me.lbReadPedalsHz.Location = New System.Drawing.Point(336, 48)
        Me.lbReadPedalsHz.Name = "lbReadPedalsHz"
        Me.lbReadPedalsHz.Size = New System.Drawing.Size(33, 12)
        Me.lbReadPedalsHz.TabIndex = 148
        Me.lbReadPedalsHz.Text = "0000"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(286, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 12)
        Me.Label9.TabIndex = 153
        Me.Label9.Text = "Pedals -> Joy"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(365, 66)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(26, 12)
        Me.Label10.TabIndex = 152
        Me.Label10.Text = "Hz"
        '
        'lbReadFFBHz
        '
        Me.lbReadFFBHz.BackColor = System.Drawing.Color.Transparent
        Me.lbReadFFBHz.Location = New System.Drawing.Point(336, 66)
        Me.lbReadFFBHz.Name = "lbReadFFBHz"
        Me.lbReadFFBHz.Size = New System.Drawing.Size(33, 12)
        Me.lbReadFFBHz.TabIndex = 151
        Me.lbReadFFBHz.Text = "0000"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(229, 83)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(108, 12)
        Me.Label12.TabIndex = 156
        Me.Label12.Text = "FFB+Game -> Motors"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(365, 83)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(26, 12)
        Me.Label13.TabIndex = 155
        Me.Label13.Text = "Hz"
        '
        'lbToArduinoHz
        '
        Me.lbToArduinoHz.BackColor = System.Drawing.Color.Transparent
        Me.lbToArduinoHz.Location = New System.Drawing.Point(336, 84)
        Me.lbToArduinoHz.Name = "lbToArduinoHz"
        Me.lbToArduinoHz.Size = New System.Drawing.Size(33, 12)
        Me.lbToArduinoHz.TabIndex = 154
        Me.lbToArduinoHz.Text = "0000"
        '
        'btCountersReset
        '
        Me.btCountersReset.BackColor = System.Drawing.Color.Gold
        Me.btCountersReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCountersReset.Location = New System.Drawing.Point(241, 62)
        Me.btCountersReset.Name = "btCountersReset"
        Me.btCountersReset.Size = New System.Drawing.Size(37, 20)
        Me.btCountersReset.TabIndex = 157
        Me.btCountersReset.Text = "reset"
        Me.btCountersReset.UseVisualStyleBackColor = False
        '
        'frmCVJoy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(567, 386)
        Me.Controls.Add(Me.btCountersReset)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lbToArduinoHz)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lbReadFFBHz)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lbReadPedalsHz)
        Me.Controls.Add(Me.chkUDP)
        Me.Controls.Add(Me.UcButtons1)
        Me.Controls.Add(Me.btLogClear)
        Me.Controls.Add(Me.chkLogHideDups)
        Me.Controls.Add(Me.chkFFIgnore)
        Me.Controls.Add(Me.chkNoMotors)
        Me.Controls.Add(Me.lbAttitude)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbTemperature)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbGames)
        Me.Controls.Add(Me.btGameSetup)
        Me.Controls.Add(Me.btGameStart)
        Me.Controls.Add(Me.lbGameInfo)
        Me.Controls.Add(Me.chkFFCond)
        Me.Controls.Add(Me.chkFFConst)
        Me.Controls.Add(Me.cbLogFF)
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
        Me.Controls.Add(Me.btArduinoStart)
        Me.Controls.Add(Me.ckKeepVisible)
        Me.Controls.Add(Me.ckDontShow)
        Me.Controls.Add(Me.lbMainsPower)
        Me.Name = "frmCVJoy"
        Me.Text = "CV Joy"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btArduinoStart As Button
    Friend WithEvents G1 As Label
    Friend WithEvents G2 As Label
    Friend WithEvents G3 As Label
    Friend WithEvents G4 As Label
    Friend WithEvents G5 As Label
    Friend WithEvents G6 As Label
    Friend WithEvents GR As Label
    Friend WithEvents lbHandbrake As Label
    Friend WithEvents lbAttitude As Label
    Friend WithEvents btSetup As Button
    Public WithEvents txtErrors As TextBox
    Friend WithEvents lbWheelPos As Label
    Friend WithEvents btWheelCenter As Button
    Friend WithEvents ckDontShow As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents lbBrake As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents lbClutch As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents ckKeepVisible As CheckBox
    Friend WithEvents chkNoWind As CheckBox
    Friend WithEvents cbLogFF As ComboBox
    Friend WithEvents chkFFConst As CheckBox
    Friend WithEvents chkFFCond As CheckBox
    Friend WithEvents btGameStart As Button
    Friend WithEvents lbGameInfo As Label
    Friend WithEvents btGameSetup As Button
    Friend WithEvents cbGames As ComboBox
    Friend WithEvents lbTemperature As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents chkNoMotors As CheckBox
    Friend WithEvents lbMainsPower As Label
    Friend WithEvents chkFFIgnore As CheckBox
    Friend WithEvents chkLogHideDups As CheckBox
    Friend WithEvents btLogClear As Button
    Friend WithEvents UcButtons1 As ucButtons
    Friend WithEvents chkUDP As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lbReadPedalsHz As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lbReadFFBHz As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lbToArduinoHz As Label
    Friend WithEvents lbAccel As Label
    Friend WithEvents btCountersReset As Button
End Class
