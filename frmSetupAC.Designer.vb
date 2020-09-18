<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSetupAC
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
        Me.ckKeepVisible = New System.Windows.Forms.CheckBox()
        Me.btApply = New System.Windows.Forms.Button()
        Me.btDefaults = New System.Windows.Forms.Button()
        Me.btSave = New System.Windows.Forms.Button()
        Me.btClose = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbACSpeed = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbACRPM = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lbACSlipFront = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lbACSlipBack = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSpeedMaxSpeed = New System.Windows.Forms.MaskedTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtRPM1 = New System.Windows.Forms.MaskedTextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtRPM2 = New System.Windows.Forms.MaskedTextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtSlip = New System.Windows.Forms.MaskedTextBox()
        Me.lbMaxRPM = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lbACPitch = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lbACAccel = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtPitch = New System.Windows.Forms.MaskedTextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtAccel = New System.Windows.Forms.MaskedTextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.lbACRoll = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.lbACTurn = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtRoll = New System.Windows.Forms.MaskedTextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtTurn = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lbACJump = New System.Windows.Forms.Label()
        Me.txtSpeedMaxJump = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txtSpeedMinInput = New System.Windows.Forms.MaskedTextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtShakeMaxJump = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtShakeMinJump = New System.Windows.Forms.MaskedTextBox()
        Me.UcACGraph1 = New CVJoy.ucACGraph()
        Me.UcButtons1 = New CVJoy.ucButtons()
        Me.SuspendLayout()
        '
        'ckKeepVisible
        '
        Me.ckKeepVisible.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ckKeepVisible.AutoSize = True
        Me.ckKeepVisible.BackColor = System.Drawing.Color.Transparent
        Me.ckKeepVisible.Location = New System.Drawing.Point(4, 234)
        Me.ckKeepVisible.Name = "ckKeepVisible"
        Me.ckKeepVisible.Size = New System.Drawing.Size(84, 17)
        Me.ckKeepVisible.TabIndex = 105
        Me.ckKeepVisible.Text = "Keep Visible"
        Me.ckKeepVisible.UseVisualStyleBackColor = False
        '
        'btApply
        '
        Me.btApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btApply.BackColor = System.Drawing.Color.Gold
        Me.btApply.Location = New System.Drawing.Point(380, 477)
        Me.btApply.Name = "btApply"
        Me.btApply.Size = New System.Drawing.Size(98, 22)
        Me.btApply.TabIndex = 84
        Me.btApply.Text = "Use this Settings"
        Me.btApply.UseVisualStyleBackColor = False
        '
        'btDefaults
        '
        Me.btDefaults.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btDefaults.BackColor = System.Drawing.Color.Gold
        Me.btDefaults.Location = New System.Drawing.Point(318, 477)
        Me.btDefaults.Name = "btDefaults"
        Me.btDefaults.Size = New System.Drawing.Size(59, 22)
        Me.btDefaults.TabIndex = 228
        Me.btDefaults.Text = "defaults"
        Me.btDefaults.UseVisualStyleBackColor = False
        '
        'btSave
        '
        Me.btSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btSave.BackColor = System.Drawing.Color.Gold
        Me.btSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSave.Location = New System.Drawing.Point(484, 477)
        Me.btSave.Name = "btSave"
        Me.btSave.Size = New System.Drawing.Size(59, 22)
        Me.btSave.TabIndex = 227
        Me.btSave.Text = "Save"
        Me.btSave.UseVisualStyleBackColor = False
        '
        'btClose
        '
        Me.btClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btClose.BackColor = System.Drawing.Color.Gold
        Me.btClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btClose.Location = New System.Drawing.Point(549, 477)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(59, 22)
        Me.btClose.TabIndex = 229
        Me.btClose.Text = "Close"
        Me.btClose.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(0, 260)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "Speed:"
        '
        'lbACSpeed
        '
        Me.lbACSpeed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbACSpeed.BackColor = System.Drawing.SystemColors.Info
        Me.lbACSpeed.Location = New System.Drawing.Point(47, 257)
        Me.lbACSpeed.Name = "lbACSpeed"
        Me.lbACSpeed.Size = New System.Drawing.Size(41, 20)
        Me.lbACSpeed.TabIndex = 36
        Me.lbACSpeed.Text = "?"
        Me.lbACSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(0, 315)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "RPM:"
        '
        'lbACRPM
        '
        Me.lbACRPM.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbACRPM.BackColor = System.Drawing.SystemColors.Info
        Me.lbACRPM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbACRPM.Location = New System.Drawing.Point(47, 315)
        Me.lbACRPM.Name = "lbACRPM"
        Me.lbACRPM.Size = New System.Drawing.Size(41, 13)
        Me.lbACRPM.TabIndex = 38
        Me.lbACRPM.Text = "?"
        Me.lbACRPM.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(0, 353)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 13)
        Me.Label14.TabIndex = 43
        Me.Label14.Text = "Slip Front:"
        '
        'lbACSlipFront
        '
        Me.lbACSlipFront.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbACSlipFront.BackColor = System.Drawing.SystemColors.Info
        Me.lbACSlipFront.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbACSlipFront.Location = New System.Drawing.Point(61, 353)
        Me.lbACSlipFront.Name = "lbACSlipFront"
        Me.lbACSlipFront.Size = New System.Drawing.Size(41, 13)
        Me.lbACSlipFront.TabIndex = 44
        Me.lbACSlipFront.Text = "?"
        Me.lbACSlipFront.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(124, 353)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 13)
        Me.Label11.TabIndex = 45
        Me.Label11.Text = "Slip Rear:"
        '
        'lbACSlipBack
        '
        Me.lbACSlipBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbACSlipBack.BackColor = System.Drawing.SystemColors.Info
        Me.lbACSlipBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbACSlipBack.Location = New System.Drawing.Point(184, 353)
        Me.lbACSlipBack.Name = "lbACSlipBack"
        Me.lbACSlipBack.Size = New System.Drawing.Size(41, 13)
        Me.lbACSlipBack.TabIndex = 46
        Me.lbACSlipBack.Text = "?"
        Me.lbACSlipBack.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(378, 260)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 47
        Me.Label8.Text = "Max.Wind at:"
        '
        'txtSpeedMaxSpeed
        '
        Me.txtSpeedMaxSpeed.AllowPromptAsInput = False
        Me.txtSpeedMaxSpeed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSpeedMaxSpeed.BeepOnError = True
        Me.txtSpeedMaxSpeed.HidePromptOnLeave = True
        Me.txtSpeedMaxSpeed.Location = New System.Drawing.Point(451, 257)
        Me.txtSpeedMaxSpeed.Mask = "000"
        Me.txtSpeedMaxSpeed.Name = "txtSpeedMaxSpeed"
        Me.txtSpeedMaxSpeed.Size = New System.Drawing.Size(28, 20)
        Me.txtSpeedMaxSpeed.TabIndex = 48
        Me.txtSpeedMaxSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(456, 315)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 13)
        Me.Label13.TabIndex = 49
        Me.Label13.Text = "Light if <"
        '
        'txtRPM1
        '
        Me.txtRPM1.AllowPromptAsInput = False
        Me.txtRPM1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRPM1.BeepOnError = True
        Me.txtRPM1.HidePromptOnLeave = True
        Me.txtRPM1.Location = New System.Drawing.Point(507, 312)
        Me.txtRPM1.Mask = "00\%"
        Me.txtRPM1.Name = "txtRPM1"
        Me.txtRPM1.Size = New System.Drawing.Size(30, 20)
        Me.txtRPM1.TabIndex = 50
        Me.txtRPM1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRPM1.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(541, 315)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(33, 13)
        Me.Label15.TabIndex = 51
        Me.Label15.Text = "or if >"
        '
        'txtRPM2
        '
        Me.txtRPM2.AllowPromptAsInput = False
        Me.txtRPM2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRPM2.BeepOnError = True
        Me.txtRPM2.HidePromptOnLeave = True
        Me.txtRPM2.Location = New System.Drawing.Point(578, 312)
        Me.txtRPM2.Mask = "00\%"
        Me.txtRPM2.Name = "txtRPM2"
        Me.txtRPM2.Size = New System.Drawing.Size(30, 20)
        Me.txtRPM2.TabIndex = 52
        Me.txtRPM2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRPM2.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(461, 353)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(42, 13)
        Me.Label17.TabIndex = 55
        Me.Label17.Text = "Red at:"
        '
        'txtSlip
        '
        Me.txtSlip.AllowPromptAsInput = False
        Me.txtSlip.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSlip.BeepOnError = True
        Me.txtSlip.HidePromptOnLeave = True
        Me.txtSlip.Location = New System.Drawing.Point(507, 350)
        Me.txtSlip.Mask = "00"
        Me.txtSlip.Name = "txtSlip"
        Me.txtSlip.Size = New System.Drawing.Size(23, 20)
        Me.txtSlip.TabIndex = 56
        Me.txtSlip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbMaxRPM
        '
        Me.lbMaxRPM.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbMaxRPM.BackColor = System.Drawing.SystemColors.Info
        Me.lbMaxRPM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbMaxRPM.Location = New System.Drawing.Point(108, 315)
        Me.lbMaxRPM.Name = "lbMaxRPM"
        Me.lbMaxRPM.Size = New System.Drawing.Size(41, 13)
        Me.lbMaxRPM.TabIndex = 57
        Me.lbMaxRPM.Text = "?"
        Me.lbMaxRPM.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(93, 315)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(12, 13)
        Me.Label19.TabIndex = 58
        Me.Label19.Text = "/"
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(0, 394)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(34, 13)
        Me.Label22.TabIndex = 60
        Me.Label22.Text = "Pitch:"
        '
        'lbACPitch
        '
        Me.lbACPitch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbACPitch.BackColor = System.Drawing.SystemColors.Info
        Me.lbACPitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbACPitch.Location = New System.Drawing.Point(47, 394)
        Me.lbACPitch.Name = "lbACPitch"
        Me.lbACPitch.Size = New System.Drawing.Size(41, 13)
        Me.lbACPitch.TabIndex = 61
        Me.lbACPitch.Text = "?"
        Me.lbACPitch.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(124, 394)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(40, 13)
        Me.Label20.TabIndex = 62
        Me.Label20.Text = "Accel.:"
        '
        'lbACAccel
        '
        Me.lbACAccel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbACAccel.BackColor = System.Drawing.SystemColors.Info
        Me.lbACAccel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbACAccel.Location = New System.Drawing.Point(184, 394)
        Me.lbACAccel.Name = "lbACAccel"
        Me.lbACAccel.Size = New System.Drawing.Size(41, 13)
        Me.lbACAccel.TabIndex = 63
        Me.lbACAccel.Text = "?"
        Me.lbACAccel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(383, 394)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(56, 13)
        Me.Label23.TabIndex = 64
        Me.Label23.Text = "Use Pitch:"
        '
        'txtPitch
        '
        Me.txtPitch.AllowPromptAsInput = False
        Me.txtPitch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPitch.BeepOnError = True
        Me.txtPitch.HidePromptOnLeave = True
        Me.txtPitch.Location = New System.Drawing.Point(442, 391)
        Me.txtPitch.Mask = "000\%"
        Me.txtPitch.Name = "txtPitch"
        Me.txtPitch.Size = New System.Drawing.Size(30, 20)
        Me.txtPitch.TabIndex = 65
        Me.txtPitch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPitch.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label24
        '
        Me.Label24.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(484, 394)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(62, 13)
        Me.Label24.TabIndex = 66
        Me.Label24.Text = "Use Accel.:"
        '
        'txtAccel
        '
        Me.txtAccel.AllowPromptAsInput = False
        Me.txtAccel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAccel.BeepOnError = True
        Me.txtAccel.HidePromptOnLeave = True
        Me.txtAccel.Location = New System.Drawing.Point(550, 391)
        Me.txtAccel.Mask = "00.0\º\/\G"
        Me.txtAccel.Name = "txtAccel"
        Me.txtAccel.Size = New System.Drawing.Size(56, 20)
        Me.txtAccel.TabIndex = 67
        Me.txtAccel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAccel.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label30
        '
        Me.Label30.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(0, 417)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(28, 13)
        Me.Label30.TabIndex = 68
        Me.Label30.Text = "Roll:"
        '
        'lbACRoll
        '
        Me.lbACRoll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbACRoll.BackColor = System.Drawing.SystemColors.Info
        Me.lbACRoll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbACRoll.Location = New System.Drawing.Point(47, 417)
        Me.lbACRoll.Name = "lbACRoll"
        Me.lbACRoll.Size = New System.Drawing.Size(41, 13)
        Me.lbACRoll.TabIndex = 69
        Me.lbACRoll.Text = "?"
        Me.lbACRoll.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label28
        '
        Me.Label28.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(124, 417)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(32, 13)
        Me.Label28.TabIndex = 70
        Me.Label28.Text = "Turn:"
        '
        'lbACTurn
        '
        Me.lbACTurn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbACTurn.BackColor = System.Drawing.SystemColors.Info
        Me.lbACTurn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbACTurn.Location = New System.Drawing.Point(184, 417)
        Me.lbACTurn.Name = "lbACTurn"
        Me.lbACTurn.Size = New System.Drawing.Size(41, 13)
        Me.lbACTurn.TabIndex = 71
        Me.lbACTurn.Text = "?"
        Me.lbACTurn.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label26
        '
        Me.Label26.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(384, 417)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(50, 13)
        Me.Label26.TabIndex = 72
        Me.Label26.Text = "Use Roll:"
        '
        'txtRoll
        '
        Me.txtRoll.AllowPromptAsInput = False
        Me.txtRoll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRoll.BeepOnError = True
        Me.txtRoll.HidePromptOnLeave = True
        Me.txtRoll.Location = New System.Drawing.Point(442, 414)
        Me.txtRoll.Mask = "000\%"
        Me.txtRoll.Name = "txtRoll"
        Me.txtRoll.Size = New System.Drawing.Size(30, 20)
        Me.txtRoll.TabIndex = 73
        Me.txtRoll.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRoll.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label25
        '
        Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(484, 417)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(54, 13)
        Me.Label25.TabIndex = 74
        Me.Label25.Text = "Use Turn:"
        '
        'txtTurn
        '
        Me.txtTurn.AllowPromptAsInput = False
        Me.txtTurn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTurn.BeepOnError = True
        Me.txtTurn.HidePromptOnLeave = True
        Me.txtTurn.Location = New System.Drawing.Point(550, 414)
        Me.txtTurn.Mask = "00.0\º\/\G"
        Me.txtTurn.Name = "txtTurn"
        Me.txtTurn.Size = New System.Drawing.Size(56, 20)
        Me.txtTurn.TabIndex = 75
        Me.txtTurn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTurn.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(482, 260)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 92
        Me.Label1.Text = "Km/h"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(517, 260)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 115
        Me.Label6.Text = "at Jumps:"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(1, 280)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 117
        Me.Label10.Text = "Jumps:"
        '
        'lbACJump
        '
        Me.lbACJump.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbACJump.BackColor = System.Drawing.SystemColors.Info
        Me.lbACJump.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbACJump.Location = New System.Drawing.Point(47, 280)
        Me.lbACJump.Name = "lbACJump"
        Me.lbACJump.Size = New System.Drawing.Size(41, 13)
        Me.lbACJump.TabIndex = 118
        Me.lbACJump.Text = "?"
        Me.lbACJump.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtSpeedMaxJump
        '
        Me.txtSpeedMaxJump.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSpeedMaxJump.AsciiOnly = True
        Me.txtSpeedMaxJump.BeepOnError = True
        Me.txtSpeedMaxJump.HidePromptOnLeave = True
        Me.txtSpeedMaxJump.Location = New System.Drawing.Point(571, 257)
        Me.txtSpeedMaxJump.Mask = "#0.0\G"
        Me.txtSpeedMaxJump.Name = "txtSpeedMaxJump"
        Me.txtSpeedMaxJump.Size = New System.Drawing.Size(37, 20)
        Me.txtSpeedMaxJump.TabIndex = 123
        Me.txtSpeedMaxJump.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1, 447)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(171, 13)
        Me.Label2.TabIndex = 231
        Me.Label2.Text = "Simulator buttons send keystrokes:"
        '
        'Label43
        '
        Me.Label43.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(232, 260)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(75, 13)
        Me.Label43.TabIndex = 232
        Me.Label43.Text = "Wind starts at:"
        '
        'txtSpeedMinInput
        '
        Me.txtSpeedMinInput.AllowPromptAsInput = False
        Me.txtSpeedMinInput.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSpeedMinInput.BeepOnError = True
        Me.txtSpeedMinInput.HidePromptOnLeave = True
        Me.txtSpeedMinInput.Location = New System.Drawing.Point(313, 257)
        Me.txtSpeedMinInput.Mask = "#990"
        Me.txtSpeedMinInput.Name = "txtSpeedMinInput"
        Me.txtSpeedMinInput.Size = New System.Drawing.Size(25, 20)
        Me.txtSpeedMinInput.TabIndex = 233
        Me.txtSpeedMinInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label42
        '
        Me.Label42.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(341, 260)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(27, 12)
        Me.Label42.TabIndex = 234
        Me.Label42.Text = "Km/h"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(232, 280)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 235
        Me.Label3.Text = "Shake starts at:"
        '
        'txtShakeMaxJump
        '
        Me.txtShakeMaxJump.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtShakeMaxJump.AsciiOnly = True
        Me.txtShakeMaxJump.BeepOnError = True
        Me.txtShakeMaxJump.HidePromptOnLeave = True
        Me.txtShakeMaxJump.Location = New System.Drawing.Point(571, 277)
        Me.txtShakeMaxJump.Mask = "#0.0\G"
        Me.txtShakeMaxJump.Name = "txtShakeMaxJump"
        Me.txtShakeMaxJump.Size = New System.Drawing.Size(37, 20)
        Me.txtShakeMaxJump.TabIndex = 237
        Me.txtShakeMaxJump.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(493, 280)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 236
        Me.Label4.Text = "Max Shake at:"
        '
        'txtShakeMinJump
        '
        Me.txtShakeMinJump.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtShakeMinJump.AsciiOnly = True
        Me.txtShakeMinJump.BeepOnError = True
        Me.txtShakeMinJump.HidePromptOnLeave = True
        Me.txtShakeMinJump.Location = New System.Drawing.Point(313, 278)
        Me.txtShakeMinJump.Mask = "#0.0\G"
        Me.txtShakeMinJump.Name = "txtShakeMinJump"
        Me.txtShakeMinJump.Size = New System.Drawing.Size(37, 20)
        Me.txtShakeMinJump.TabIndex = 238
        Me.txtShakeMinJump.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'UcACGraph1
        '
        Me.UcACGraph1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UcACGraph1.BackColor = System.Drawing.Color.Black
        Me.UcACGraph1.Location = New System.Drawing.Point(0, 0)
        Me.UcACGraph1.Name = "UcACGraph1"
        Me.UcACGraph1.Size = New System.Drawing.Size(610, 254)
        Me.UcACGraph1.TabIndex = 256
        '
        'UcButtons1
        '
        Me.UcButtons1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UcButtons1.Location = New System.Drawing.Point(173, 440)
        Me.UcButtons1.Name = "UcButtons1"
        Me.UcButtons1.ReadOnly = False
        Me.UcButtons1.Size = New System.Drawing.Size(366, 37)
        Me.UcButtons1.TabIndex = 230
        '
        'frmSetupAC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(610, 498)
        Me.Controls.Add(Me.ckKeepVisible)
        Me.Controls.Add(Me.UcACGraph1)
        Me.Controls.Add(Me.txtShakeMinJump)
        Me.Controls.Add(Me.txtShakeMaxJump)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.txtSpeedMinInput)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.UcButtons1)
        Me.Controls.Add(Me.btClose)
        Me.Controls.Add(Me.btSave)
        Me.Controls.Add(Me.btDefaults)
        Me.Controls.Add(Me.txtSpeedMaxJump)
        Me.Controls.Add(Me.lbACJump)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btApply)
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
        Me.Controls.Add(Me.txtSpeedMaxSpeed)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lbACSlipBack)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lbACSlipFront)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.lbACRPM)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lbACSpeed)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label43)
        Me.Name = "frmSetupAC"
        Me.Text = "CV Joy - Setup Asseto Corsa"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ckKeepVisible As CheckBox
    Friend WithEvents btApply As Button
    Friend WithEvents btDefaults As Button
    Friend WithEvents btSave As Button
    Friend WithEvents btClose As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents lbACSpeed As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents lbACRPM As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents lbACSlipFront As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lbACSlipBack As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtSpeedMaxSpeed As MaskedTextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtRPM1 As MaskedTextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtRPM2 As MaskedTextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtSlip As MaskedTextBox
    Friend WithEvents lbMaxRPM As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents lbACPitch As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents lbACAccel As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents txtPitch As MaskedTextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents txtAccel As MaskedTextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents lbACRoll As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents lbACTurn As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents txtRoll As MaskedTextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents txtTurn As MaskedTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lbACJump As Label
    Friend WithEvents txtSpeedMaxJump As MaskedTextBox
    Friend WithEvents UcButtons1 As ucButtons
    Friend WithEvents Label2 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents txtSpeedMinInput As MaskedTextBox
    Friend WithEvents Label42 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtShakeMaxJump As MaskedTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtShakeMinJump As MaskedTextBox
    Friend WithEvents UcACGraph1 As ucACGraph
End Class
