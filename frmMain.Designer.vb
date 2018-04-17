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
        Me.btSave = New System.Windows.Forms.Button()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.lbSlipFront = New System.Windows.Forms.Label()
        Me.lbSlipBack = New System.Windows.Forms.Label()
        Me.lbRPM2 = New System.Windows.Forms.Label()
        Me.lbRPM1 = New System.Windows.Forms.Label()
        Me.G1 = New System.Windows.Forms.Label()
        Me.G2 = New System.Windows.Forms.Label()
        Me.G3 = New System.Windows.Forms.Label()
        Me.G4 = New System.Windows.Forms.Label()
        Me.G5 = New System.Windows.Forms.Label()
        Me.G6 = New System.Windows.Forms.Label()
        Me.GR = New System.Windows.Forms.Label()
        Me.lbHandbrake = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lbACInfo = New System.Windows.Forms.Label()
        Me.btACStart = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbACSpeed = New System.Windows.Forms.TextBox()
        Me.lbACRPM = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbACSlipBack = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lbACSlipFront = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMaxSpeed = New System.Windows.Forms.MaskedTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtRPM1 = New System.Windows.Forms.MaskedTextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtRPM2 = New System.Windows.Forms.MaskedTextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtSlip = New System.Windows.Forms.MaskedTextBox()
        Me.lbMaxRPM = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lbACAccel = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lbACPitch = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtPitch = New System.Windows.Forms.MaskedTextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtAccel = New System.Windows.Forms.MaskedTextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtTurn = New System.Windows.Forms.MaskedTextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtRoll = New System.Windows.Forms.MaskedTextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lbACTurn = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.lbACRoll = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.lbAttitude = New System.Windows.Forms.Label()
        Me.btSetup = New System.Windows.Forms.Button()
        Me.txtErrors = New System.Windows.Forms.TextBox()
        Me.btApply = New System.Windows.Forms.Button()
        Me.lbWheelPos = New System.Windows.Forms.Label()
        Me.btWheelCenter = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ckDontShow = New System.Windows.Forms.CheckBox()
        Me.lbAccel = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbBrake = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lbClutch = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.ckKeepVisible = New System.Windows.Forms.CheckBox()
        Me.bt1 = New System.Windows.Forms.Label()
        Me.bt2 = New System.Windows.Forms.TextBox()
        Me.bt3 = New System.Windows.Forms.TextBox()
        Me.bt4 = New System.Windows.Forms.TextBox()
        Me.bt5 = New System.Windows.Forms.TextBox()
        Me.bt6 = New System.Windows.Forms.TextBox()
        Me.bt7 = New System.Windows.Forms.TextBox()
        Me.bt8 = New System.Windows.Forms.TextBox()
        Me.bt9 = New System.Windows.Forms.TextBox()
        Me.chkNoWind = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbACJump = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtJump = New System.Windows.Forms.MaskedTextBox()
        Me.cbLog = New System.Windows.Forms.ComboBox()
        Me.chkFFConst = New System.Windows.Forms.CheckBox()
        Me.chkFFCond = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'btArduinoStart
        '
        Me.btArduinoStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btArduinoStart.BackColor = System.Drawing.Color.Gold
        Me.btArduinoStart.Location = New System.Drawing.Point(180, 142)
        Me.btArduinoStart.Name = "btArduinoStart"
        Me.btArduinoStart.Size = New System.Drawing.Size(108, 22)
        Me.btArduinoStart.TabIndex = 0
        Me.btArduinoStart.Text = "Connect to Arduino"
        Me.btArduinoStart.UseVisualStyleBackColor = False
        '
        'btSave
        '
        Me.btSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btSave.BackColor = System.Drawing.Color.Gold
        Me.btSave.Location = New System.Drawing.Point(412, 256)
        Me.btSave.Name = "btSave"
        Me.btSave.Size = New System.Drawing.Size(109, 22)
        Me.btSave.TabIndex = 3
        Me.btSave.Text = "Save this Settings"
        Me.btSave.UseVisualStyleBackColor = False
        '
        'SerialPort1
        '
        Me.SerialPort1.BaudRate = 115200
        Me.SerialPort1.ReadBufferSize = 128
        Me.SerialPort1.ReceivedBytesThreshold = 2
        Me.SerialPort1.WriteBufferSize = 128
        '
        'lbSlipFront
        '
        Me.lbSlipFront.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbSlipFront.BackColor = System.Drawing.Color.Red
        Me.lbSlipFront.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbSlipFront.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSlipFront.Location = New System.Drawing.Point(129, 18)
        Me.lbSlipFront.Name = "lbSlipFront"
        Me.lbSlipFront.Size = New System.Drawing.Size(27, 20)
        Me.lbSlipFront.TabIndex = 9
        Me.lbSlipFront.Text = "Slip Front"
        Me.lbSlipFront.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbSlipBack
        '
        Me.lbSlipBack.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbSlipBack.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.lbSlipBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbSlipBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSlipBack.Location = New System.Drawing.Point(129, 60)
        Me.lbSlipBack.Name = "lbSlipBack"
        Me.lbSlipBack.Size = New System.Drawing.Size(27, 20)
        Me.lbSlipBack.TabIndex = 12
        Me.lbSlipBack.Text = "Slip Back"
        Me.lbSlipBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbRPM2
        '
        Me.lbRPM2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbRPM2.BackColor = System.Drawing.Color.Gold
        Me.lbRPM2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbRPM2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbRPM2.Location = New System.Drawing.Point(143, 39)
        Me.lbRPM2.Name = "lbRPM2"
        Me.lbRPM2.Size = New System.Drawing.Size(27, 20)
        Me.lbRPM2.TabIndex = 11
        Me.lbRPM2.Text = "RPM >"
        Me.lbRPM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbRPM1
        '
        Me.lbRPM1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbRPM1.BackColor = System.Drawing.Color.LimeGreen
        Me.lbRPM1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbRPM1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbRPM1.Location = New System.Drawing.Point(115, 39)
        Me.lbRPM1.Name = "lbRPM1"
        Me.lbRPM1.Size = New System.Drawing.Size(27, 20)
        Me.lbRPM1.TabIndex = 10
        Me.lbRPM1.Text = "RPM <"
        Me.lbRPM1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'lbACInfo
        '
        Me.lbACInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbACInfo.BackColor = System.Drawing.SystemColors.Info
        Me.lbACInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbACInfo.ForeColor = System.Drawing.SystemColors.InfoText
        Me.lbACInfo.Location = New System.Drawing.Point(1, 176)
        Me.lbACInfo.Name = "lbACInfo"
        Me.lbACInfo.Size = New System.Drawing.Size(520, 13)
        Me.lbACInfo.TabIndex = 33
        Me.lbACInfo.Text = "   connection to  Assetto Corsa:"
        '
        'btACStart
        '
        Me.btACStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btACStart.BackColor = System.Drawing.Color.Gold
        Me.btACStart.Location = New System.Drawing.Point(412, 214)
        Me.btACStart.Name = "btACStart"
        Me.btACStart.Size = New System.Drawing.Size(108, 22)
        Me.btACStart.TabIndex = 34
        Me.btACStart.Text = "Connect to Assetto Corsa"
        Me.btACStart.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(0, 195)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "Speed:"
        '
        'lbACSpeed
        '
        Me.lbACSpeed.BackColor = System.Drawing.SystemColors.Info
        Me.lbACSpeed.Location = New System.Drawing.Point(47, 192)
        Me.lbACSpeed.Name = "lbACSpeed"
        Me.lbACSpeed.Size = New System.Drawing.Size(41, 20)
        Me.lbACSpeed.TabIndex = 36
        Me.lbACSpeed.Text = "?"
        Me.lbACSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbACRPM
        '
        Me.lbACRPM.BackColor = System.Drawing.SystemColors.Info
        Me.lbACRPM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbACRPM.Location = New System.Drawing.Point(47, 219)
        Me.lbACRPM.Name = "lbACRPM"
        Me.lbACRPM.Size = New System.Drawing.Size(41, 13)
        Me.lbACRPM.TabIndex = 38
        Me.lbACRPM.Text = "?"
        Me.lbACRPM.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(0, 219)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "RPM:"
        '
        'lbACSlipBack
        '
        Me.lbACSlipBack.BackColor = System.Drawing.SystemColors.Info
        Me.lbACSlipBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbACSlipBack.Location = New System.Drawing.Point(184, 243)
        Me.lbACSlipBack.Name = "lbACSlipBack"
        Me.lbACSlipBack.Size = New System.Drawing.Size(41, 13)
        Me.lbACSlipBack.TabIndex = 46
        Me.lbACSlipBack.Text = "?"
        Me.lbACSlipBack.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(124, 243)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 13)
        Me.Label11.TabIndex = 45
        Me.Label11.Text = "Slip Back:"
        '
        'lbACSlipFront
        '
        Me.lbACSlipFront.BackColor = System.Drawing.SystemColors.Info
        Me.lbACSlipFront.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbACSlipFront.Location = New System.Drawing.Point(61, 243)
        Me.lbACSlipFront.Name = "lbACSlipFront"
        Me.lbACSlipFront.Size = New System.Drawing.Size(41, 13)
        Me.lbACSlipFront.TabIndex = 44
        Me.lbACSlipFront.Text = "?"
        Me.lbACSlipFront.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(0, 243)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 13)
        Me.Label14.TabIndex = 43
        Me.Label14.Text = "Slip Front:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(113, 195)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(116, 13)
        Me.Label8.TabIndex = 47
        Me.Label8.Text = "Max.Wind     at Speed:"
        '
        'txtMaxSpeed
        '
        Me.txtMaxSpeed.AllowPromptAsInput = False
        Me.txtMaxSpeed.BeepOnError = True
        Me.txtMaxSpeed.HidePromptOnLeave = True
        Me.txtMaxSpeed.Location = New System.Drawing.Point(231, 192)
        Me.txtMaxSpeed.Mask = "000"
        Me.txtMaxSpeed.Name = "txtMaxSpeed"
        Me.txtMaxSpeed.Size = New System.Drawing.Size(28, 20)
        Me.txtMaxSpeed.TabIndex = 48
        Me.txtMaxSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(166, 219)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 13)
        Me.Label13.TabIndex = 49
        Me.Label13.Text = "Light if <"
        '
        'txtRPM1
        '
        Me.txtRPM1.AllowPromptAsInput = False
        Me.txtRPM1.BeepOnError = True
        Me.txtRPM1.HidePromptOnLeave = True
        Me.txtRPM1.Location = New System.Drawing.Point(217, 216)
        Me.txtRPM1.Mask = "00\%"
        Me.txtRPM1.Name = "txtRPM1"
        Me.txtRPM1.Size = New System.Drawing.Size(30, 20)
        Me.txtRPM1.TabIndex = 50
        Me.txtRPM1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRPM1.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(251, 219)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(33, 13)
        Me.Label15.TabIndex = 51
        Me.Label15.Text = "or if >"
        '
        'txtRPM2
        '
        Me.txtRPM2.AllowPromptAsInput = False
        Me.txtRPM2.BeepOnError = True
        Me.txtRPM2.HidePromptOnLeave = True
        Me.txtRPM2.Location = New System.Drawing.Point(288, 216)
        Me.txtRPM2.Mask = "00\%"
        Me.txtRPM2.Name = "txtRPM2"
        Me.txtRPM2.Size = New System.Drawing.Size(30, 20)
        Me.txtRPM2.TabIndex = 52
        Me.txtRPM2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRPM2.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(246, 243)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(42, 13)
        Me.Label17.TabIndex = 55
        Me.Label17.Text = "Red at:"
        '
        'txtSlip
        '
        Me.txtSlip.AllowPromptAsInput = False
        Me.txtSlip.BeepOnError = True
        Me.txtSlip.HidePromptOnLeave = True
        Me.txtSlip.Location = New System.Drawing.Point(292, 240)
        Me.txtSlip.Mask = "00"
        Me.txtSlip.Name = "txtSlip"
        Me.txtSlip.Size = New System.Drawing.Size(23, 20)
        Me.txtSlip.TabIndex = 56
        Me.txtSlip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbMaxRPM
        '
        Me.lbMaxRPM.BackColor = System.Drawing.SystemColors.Info
        Me.lbMaxRPM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbMaxRPM.Location = New System.Drawing.Point(108, 219)
        Me.lbMaxRPM.Name = "lbMaxRPM"
        Me.lbMaxRPM.Size = New System.Drawing.Size(41, 13)
        Me.lbMaxRPM.TabIndex = 57
        Me.lbMaxRPM.Text = "?"
        Me.lbMaxRPM.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(93, 219)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(12, 13)
        Me.Label19.TabIndex = 58
        Me.Label19.Text = "/"
        '
        'lbACAccel
        '
        Me.lbACAccel.BackColor = System.Drawing.SystemColors.Info
        Me.lbACAccel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbACAccel.Location = New System.Drawing.Point(184, 288)
        Me.lbACAccel.Name = "lbACAccel"
        Me.lbACAccel.Size = New System.Drawing.Size(41, 13)
        Me.lbACAccel.TabIndex = 63
        Me.lbACAccel.Text = "?"
        Me.lbACAccel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(124, 288)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(40, 13)
        Me.Label20.TabIndex = 62
        Me.Label20.Text = "Accel.:"
        '
        'lbACPitch
        '
        Me.lbACPitch.BackColor = System.Drawing.SystemColors.Info
        Me.lbACPitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbACPitch.Location = New System.Drawing.Point(47, 288)
        Me.lbACPitch.Name = "lbACPitch"
        Me.lbACPitch.Size = New System.Drawing.Size(41, 13)
        Me.lbACPitch.TabIndex = 61
        Me.lbACPitch.Text = "?"
        Me.lbACPitch.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(0, 288)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(34, 13)
        Me.Label22.TabIndex = 60
        Me.Label22.Text = "Pitch:"
        '
        'txtPitch
        '
        Me.txtPitch.AllowPromptAsInput = False
        Me.txtPitch.BeepOnError = True
        Me.txtPitch.HidePromptOnLeave = True
        Me.txtPitch.Location = New System.Drawing.Point(304, 285)
        Me.txtPitch.Mask = "000\%"
        Me.txtPitch.Name = "txtPitch"
        Me.txtPitch.Size = New System.Drawing.Size(30, 20)
        Me.txtPitch.TabIndex = 65
        Me.txtPitch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPitch.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(245, 288)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(56, 13)
        Me.Label23.TabIndex = 64
        Me.Label23.Text = "Use Pitch:"
        '
        'txtAccel
        '
        Me.txtAccel.AllowPromptAsInput = False
        Me.txtAccel.BeepOnError = True
        Me.txtAccel.HidePromptOnLeave = True
        Me.txtAccel.Location = New System.Drawing.Point(412, 285)
        Me.txtAccel.Mask = "00\º\/\G"
        Me.txtAccel.Name = "txtAccel"
        Me.txtAccel.Size = New System.Drawing.Size(39, 20)
        Me.txtAccel.TabIndex = 67
        Me.txtAccel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAccel.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(346, 288)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(62, 13)
        Me.Label24.TabIndex = 66
        Me.Label24.Text = "Use Accel.:"
        '
        'txtTurn
        '
        Me.txtTurn.AllowPromptAsInput = False
        Me.txtTurn.BeepOnError = True
        Me.txtTurn.HidePromptOnLeave = True
        Me.txtTurn.Location = New System.Drawing.Point(412, 308)
        Me.txtTurn.Mask = "00\º\/\G"
        Me.txtTurn.Name = "txtTurn"
        Me.txtTurn.Size = New System.Drawing.Size(39, 20)
        Me.txtTurn.TabIndex = 75
        Me.txtTurn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTurn.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(346, 311)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(54, 13)
        Me.Label25.TabIndex = 74
        Me.Label25.Text = "Use Turn:"
        '
        'txtRoll
        '
        Me.txtRoll.AllowPromptAsInput = False
        Me.txtRoll.BeepOnError = True
        Me.txtRoll.HidePromptOnLeave = True
        Me.txtRoll.Location = New System.Drawing.Point(304, 308)
        Me.txtRoll.Mask = "000\%"
        Me.txtRoll.Name = "txtRoll"
        Me.txtRoll.Size = New System.Drawing.Size(30, 20)
        Me.txtRoll.TabIndex = 73
        Me.txtRoll.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRoll.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(246, 311)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(50, 13)
        Me.Label26.TabIndex = 72
        Me.Label26.Text = "Use Roll:"
        '
        'lbACTurn
        '
        Me.lbACTurn.BackColor = System.Drawing.SystemColors.Info
        Me.lbACTurn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbACTurn.Location = New System.Drawing.Point(184, 311)
        Me.lbACTurn.Name = "lbACTurn"
        Me.lbACTurn.Size = New System.Drawing.Size(41, 13)
        Me.lbACTurn.TabIndex = 71
        Me.lbACTurn.Text = "?"
        Me.lbACTurn.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(124, 311)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(32, 13)
        Me.Label28.TabIndex = 70
        Me.Label28.Text = "Turn:"
        '
        'lbACRoll
        '
        Me.lbACRoll.BackColor = System.Drawing.SystemColors.Info
        Me.lbACRoll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbACRoll.Location = New System.Drawing.Point(47, 311)
        Me.lbACRoll.Name = "lbACRoll"
        Me.lbACRoll.Size = New System.Drawing.Size(41, 13)
        Me.lbACRoll.TabIndex = 69
        Me.lbACRoll.Text = "?"
        Me.lbACRoll.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(0, 311)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(28, 13)
        Me.Label30.TabIndex = 68
        Me.Label30.Text = "Roll:"
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
        Me.btSetup.Location = New System.Drawing.Point(117, 142)
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
        Me.txtErrors.Location = New System.Drawing.Point(0, 332)
        Me.txtErrors.Multiline = True
        Me.txtErrors.Name = "txtErrors"
        Me.txtErrors.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtErrors.Size = New System.Drawing.Size(521, 101)
        Me.txtErrors.TabIndex = 83
        Me.txtErrors.WordWrap = False
        '
        'btApply
        '
        Me.btApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btApply.BackColor = System.Drawing.Color.Gold
        Me.btApply.Location = New System.Drawing.Point(412, 235)
        Me.btApply.Name = "btApply"
        Me.btApply.Size = New System.Drawing.Size(109, 22)
        Me.btApply.TabIndex = 84
        Me.btApply.Text = "Use this Settings"
        Me.btApply.UseVisualStyleBackColor = False
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(262, 195)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 92
        Me.Label1.Text = "Km/h"
        '
        'ckDontShow
        '
        Me.ckDontShow.AutoSize = True
        Me.ckDontShow.BackColor = System.Drawing.Color.Transparent
        Me.ckDontShow.Location = New System.Drawing.Point(21, 138)
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
        Me.ckKeepVisible.Location = New System.Drawing.Point(21, 158)
        Me.ckKeepVisible.Name = "ckKeepVisible"
        Me.ckKeepVisible.Size = New System.Drawing.Size(84, 17)
        Me.ckKeepVisible.TabIndex = 105
        Me.ckKeepVisible.Text = "Keep Visible"
        Me.ckKeepVisible.UseVisualStyleBackColor = False
        '
        'bt1
        '
        Me.bt1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.bt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.bt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.bt1.Location = New System.Drawing.Point(3, 3)
        Me.bt1.Name = "bt1"
        Me.bt1.Size = New System.Drawing.Size(27, 17)
        Me.bt1.TabIndex = 0
        Me.bt1.Text = "Esc"
        Me.bt1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'bt2
        '
        Me.bt2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.bt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.bt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.bt2.Location = New System.Drawing.Point(31, 3)
        Me.bt2.MaxLength = 32000
        Me.bt2.Name = "bt2"
        Me.bt2.ShortcutsEnabled = False
        Me.bt2.Size = New System.Drawing.Size(27, 17)
        Me.bt2.TabIndex = 1
        Me.bt2.Text = "a"
        Me.bt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.bt2.WordWrap = False
        '
        'bt3
        '
        Me.bt3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.bt3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.bt3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.bt3.Location = New System.Drawing.Point(59, 3)
        Me.bt3.MaxLength = 32000
        Me.bt3.Name = "bt3"
        Me.bt3.ShortcutsEnabled = False
        Me.bt3.Size = New System.Drawing.Size(27, 17)
        Me.bt3.TabIndex = 2
        Me.bt3.Text = "a"
        Me.bt3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.bt3.WordWrap = False
        '
        'bt4
        '
        Me.bt4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.bt4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.bt4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.bt4.Location = New System.Drawing.Point(101, 3)
        Me.bt4.MaxLength = 32000
        Me.bt4.Name = "bt4"
        Me.bt4.ShortcutsEnabled = False
        Me.bt4.Size = New System.Drawing.Size(27, 17)
        Me.bt4.TabIndex = 3
        Me.bt4.Text = "a"
        Me.bt4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.bt4.WordWrap = False
        '
        'bt5
        '
        Me.bt5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.bt5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.bt5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.bt5.Location = New System.Drawing.Point(129, 3)
        Me.bt5.MaxLength = 32000
        Me.bt5.Name = "bt5"
        Me.bt5.ShortcutsEnabled = False
        Me.bt5.Size = New System.Drawing.Size(27, 17)
        Me.bt5.TabIndex = 4
        Me.bt5.Text = "a"
        Me.bt5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.bt5.WordWrap = False
        '
        'bt6
        '
        Me.bt6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.bt6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.bt6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.bt6.Location = New System.Drawing.Point(157, 3)
        Me.bt6.MaxLength = 32000
        Me.bt6.Name = "bt6"
        Me.bt6.ShortcutsEnabled = False
        Me.bt6.Size = New System.Drawing.Size(27, 17)
        Me.bt6.TabIndex = 5
        Me.bt6.Text = "a"
        Me.bt6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.bt6.WordWrap = False
        '
        'bt7
        '
        Me.bt7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.bt7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.bt7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.bt7.Location = New System.Drawing.Point(199, 3)
        Me.bt7.MaxLength = 32000
        Me.bt7.Name = "bt7"
        Me.bt7.ShortcutsEnabled = False
        Me.bt7.Size = New System.Drawing.Size(27, 17)
        Me.bt7.TabIndex = 6
        Me.bt7.Text = "a"
        Me.bt7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.bt7.WordWrap = False
        '
        'bt8
        '
        Me.bt8.BackColor = System.Drawing.Color.WhiteSmoke
        Me.bt8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.bt8.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.bt8.Location = New System.Drawing.Point(227, 3)
        Me.bt8.MaxLength = 32000
        Me.bt8.Name = "bt8"
        Me.bt8.ShortcutsEnabled = False
        Me.bt8.Size = New System.Drawing.Size(27, 17)
        Me.bt8.TabIndex = 7
        Me.bt8.Text = "a"
        Me.bt8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.bt8.WordWrap = False
        '
        'bt9
        '
        Me.bt9.BackColor = System.Drawing.Color.WhiteSmoke
        Me.bt9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.bt9.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.bt9.Location = New System.Drawing.Point(255, 3)
        Me.bt9.MaxLength = 32000
        Me.bt9.Name = "bt9"
        Me.bt9.ShortcutsEnabled = False
        Me.bt9.Size = New System.Drawing.Size(27, 17)
        Me.bt9.TabIndex = 8
        Me.bt9.Text = "a"
        Me.bt9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.bt9.WordWrap = False
        '
        'chkNoWind
        '
        Me.chkNoWind.AutoSize = True
        Me.chkNoWind.BackColor = System.Drawing.Color.Transparent
        Me.chkNoWind.Location = New System.Drawing.Point(432, 194)
        Me.chkNoWind.Name = "chkNoWind"
        Me.chkNoWind.Size = New System.Drawing.Size(89, 17)
        Me.chkNoWind.TabIndex = 114
        Me.chkNoWind.Text = "Disable Wind"
        Me.chkNoWind.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(304, 195)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 115
        Me.Label6.Text = "at Jumps:"
        '
        'lbACJump
        '
        Me.lbACJump.BackColor = System.Drawing.SystemColors.Info
        Me.lbACJump.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbACJump.Location = New System.Drawing.Point(184, 265)
        Me.lbACJump.Name = "lbACJump"
        Me.lbACJump.Size = New System.Drawing.Size(41, 13)
        Me.lbACJump.TabIndex = 118
        Me.lbACJump.Text = "?"
        Me.lbACJump.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(124, 265)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 117
        Me.Label10.Text = "Jumps:"
        '
        'txtJump
        '
        Me.txtJump.AsciiOnly = True
        Me.txtJump.BeepOnError = True
        Me.txtJump.HidePromptOnLeave = True
        Me.txtJump.Location = New System.Drawing.Point(358, 192)
        Me.txtJump.Mask = "#0.0\G"
        Me.txtJump.Name = "txtJump"
        Me.txtJump.Size = New System.Drawing.Size(37, 20)
        Me.txtJump.TabIndex = 123
        Me.txtJump.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbLog
        '
        Me.cbLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLog.Location = New System.Drawing.Point(383, 332)
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
        'frmCVJoy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(521, 431)
        Me.Controls.Add(Me.chkFFCond)
        Me.Controls.Add(Me.chkFFConst)
        Me.Controls.Add(Me.cbLog)
        Me.Controls.Add(Me.txtJump)
        Me.Controls.Add(Me.lbACJump)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.chkNoWind)
        Me.Controls.Add(Me.bt1)
        Me.Controls.Add(Me.bt2)
        Me.Controls.Add(Me.bt3)
        Me.Controls.Add(Me.bt4)
        Me.Controls.Add(Me.bt5)
        Me.Controls.Add(Me.bt6)
        Me.Controls.Add(Me.bt7)
        Me.Controls.Add(Me.bt8)
        Me.Controls.Add(Me.bt9)
        Me.Controls.Add(Me.lbClutch)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.lbBrake)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.lbAccel)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btWheelCenter)
        Me.Controls.Add(Me.lbWheelPos)
        Me.Controls.Add(Me.btApply)
        Me.Controls.Add(Me.txtErrors)
        Me.Controls.Add(Me.btSetup)
        Me.Controls.Add(Me.lbAttitude)
        Me.Controls.Add(Me.txtTurn)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.txtRoll)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.lbACTurn)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.lbACRoll)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.txtAccel)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txtPitch)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.lbACAccel)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.lbACPitch)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.lbMaxRPM)
        Me.Controls.Add(Me.txtSlip)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtRPM2)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtRPM1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtMaxSpeed)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lbACSlipBack)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lbACSlipFront)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.lbACRPM)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lbACSpeed)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btACStart)
        Me.Controls.Add(Me.lbACInfo)
        Me.Controls.Add(Me.lbHandbrake)
        Me.Controls.Add(Me.GR)
        Me.Controls.Add(Me.G6)
        Me.Controls.Add(Me.G5)
        Me.Controls.Add(Me.G4)
        Me.Controls.Add(Me.G3)
        Me.Controls.Add(Me.G2)
        Me.Controls.Add(Me.G1)
        Me.Controls.Add(Me.lbRPM1)
        Me.Controls.Add(Me.lbRPM2)
        Me.Controls.Add(Me.lbSlipBack)
        Me.Controls.Add(Me.lbSlipFront)
        Me.Controls.Add(Me.btSave)
        Me.Controls.Add(Me.btArduinoStart)
        Me.Controls.Add(Me.ckKeepVisible)
        Me.Controls.Add(Me.ckDontShow)
        Me.Name = "frmCVJoy"
        Me.Text = "CV Joy"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btArduinoStart As Button
    Friend WithEvents btSave As Button
    Friend WithEvents lbSlipFront As Label
    Friend WithEvents lbSlipBack As Label
    Friend WithEvents lbRPM2 As Label
    Friend WithEvents lbRPM1 As Label
    Friend WithEvents G1 As Label
    Friend WithEvents G2 As Label
    Friend WithEvents G3 As Label
    Friend WithEvents G4 As Label
    Friend WithEvents G5 As Label
    Friend WithEvents G6 As Label
    Friend WithEvents GR As Label
    Friend WithEvents lbHandbrake As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lbACInfo As Label
    Friend WithEvents btACStart As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents lbACSpeed As TextBox
    Friend WithEvents lbACRPM As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lbACSlipBack As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lbACSlipFront As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtMaxSpeed As MaskedTextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtRPM1 As MaskedTextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtRPM2 As MaskedTextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtSlip As MaskedTextBox
    Friend WithEvents lbMaxRPM As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents lbACAccel As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents lbACPitch As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents txtPitch As MaskedTextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents txtAccel As MaskedTextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents txtTurn As MaskedTextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents txtRoll As MaskedTextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents lbACTurn As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents lbACRoll As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents lbAttitude As Label
    Friend WithEvents btSetup As Button
    Public WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents btApply As Button
    Public WithEvents txtErrors As TextBox
    Friend WithEvents lbWheelPos As Label
    Friend WithEvents btWheelCenter As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ckDontShow As CheckBox
    Friend WithEvents lbAccel As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lbBrake As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents lbClutch As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents ckKeepVisible As CheckBox
    Friend WithEvents bt1 As Label
    Friend WithEvents bt2 As TextBox
    Friend WithEvents bt3 As TextBox
    Friend WithEvents bt4 As TextBox
    Friend WithEvents bt5 As TextBox
    Friend WithEvents bt6 As TextBox
    Friend WithEvents bt7 As TextBox
    Friend WithEvents bt8 As TextBox
    Friend WithEvents bt9 As TextBox
    Friend WithEvents chkNoWind As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents lbACJump As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtJump As MaskedTextBox
    Friend WithEvents cbLog As ComboBox
    Friend WithEvents chkFFConst As CheckBox
    Friend WithEvents chkFFCond As CheckBox
End Class
