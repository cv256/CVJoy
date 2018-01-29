<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSetup
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFreq = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMaxRoll = New System.Windows.Forms.MaskedTextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtMaxPitch = New System.Windows.Forms.MaskedTextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtWheelPowerForMin = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPitchPowerForMax = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPitchPowerForMin = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtRollPowerForMax = New System.Windows.Forms.MaskedTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtRollPowerForMin = New System.Windows.Forms.MaskedTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btClose = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cbComPort = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cbVjoy = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btTest1 = New System.Windows.Forms.Button()
        Me.btTest2 = New System.Windows.Forms.Button()
        Me.btTest3 = New System.Windows.Forms.Button()
        Me.btTest4 = New System.Windows.Forms.Button()
        Me.btTest5 = New System.Windows.Forms.Button()
        Me.btTest6 = New System.Windows.Forms.Button()
        Me.txtPitchHysteria = New System.Windows.Forms.MaskedTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtRollHysteria = New System.Windows.Forms.MaskedTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtRollOffset = New System.Windows.Forms.MaskedTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtPitchOffset = New System.Windows.Forms.MaskedTextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtGyroMaxDegrees = New System.Windows.Forms.MaskedTextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtAccelMax = New System.Windows.Forms.MaskedTextBox()
        Me.txtAccelMin = New System.Windows.Forms.MaskedTextBox()
        Me.txtBrakeMax = New System.Windows.Forms.MaskedTextBox()
        Me.txtBrakeMin = New System.Windows.Forms.MaskedTextBox()
        Me.txtClutchMax = New System.Windows.Forms.MaskedTextBox()
        Me.txtClutchMin = New System.Windows.Forms.MaskedTextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cbMouse = New System.Windows.Forms.ComboBox()
        Me.txtWheelDampFactor = New System.Windows.Forms.MaskedTextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtWheelSensitivity = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtWheelDead = New System.Windows.Forms.MaskedTextBox()
        Me.btDefaults = New System.Windows.Forms.Button()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtWheelPowerGama = New System.Windows.Forms.MaskedTextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtWheelPowerFactor = New System.Windows.Forms.MaskedTextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtWheelFriction = New System.Windows.Forms.MaskedTextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtWheelInertia = New System.Windows.Forms.MaskedTextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtSpeedGama = New System.Windows.Forms.MaskedTextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txtSpeedMin = New System.Windows.Forms.MaskedTextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.btTestSpeed = New System.Windows.Forms.Button()
        Me.txtClutchGama = New System.Windows.Forms.MaskedTextBox()
        Me.txtBrakeGama = New System.Windows.Forms.MaskedTextBox()
        Me.txtAccelGama = New System.Windows.Forms.MaskedTextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.btAccelGraph = New System.Windows.Forms.Button()
        Me.btBrakeGraph = New System.Windows.Forms.Button()
        Me.btClutchGraph = New System.Windows.Forms.Button()
        Me.UcControlGraph1 = New CVJoy.ucControlGraph()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(105, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(263, 12)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Hz (fps) between Arduino <-> CVJoy <-> vJoy + Assetto Corsa"
        '
        'txtFreq
        '
        Me.txtFreq.AllowPromptAsInput = False
        Me.txtFreq.BeepOnError = True
        Me.txtFreq.HidePromptOnLeave = True
        Me.txtFreq.Location = New System.Drawing.Point(81, 3)
        Me.txtFreq.Mask = "00"
        Me.txtFreq.Name = "txtFreq"
        Me.txtFreq.Size = New System.Drawing.Size(20, 20)
        Me.txtFreq.TabIndex = 9
        Me.txtFreq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFreq.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Refresh Rate:"
        '
        'txtMaxRoll
        '
        Me.txtMaxRoll.AsciiOnly = True
        Me.txtMaxRoll.BeepOnError = True
        Me.txtMaxRoll.HidePromptOnLeave = True
        Me.txtMaxRoll.Location = New System.Drawing.Point(140, 262)
        Me.txtMaxRoll.Mask = "99\º"
        Me.txtMaxRoll.Name = "txtMaxRoll"
        Me.txtMaxRoll.Size = New System.Drawing.Size(25, 20)
        Me.txtMaxRoll.TabIndex = 85
        Me.txtMaxRoll.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(4, 266)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(118, 13)
        Me.Label21.TabIndex = 84
        Me.Label21.Text = "Roll Limit Max Rotation:"
        '
        'txtMaxPitch
        '
        Me.txtMaxPitch.AsciiOnly = True
        Me.txtMaxPitch.BeepOnError = True
        Me.txtMaxPitch.HidePromptOnLeave = True
        Me.txtMaxPitch.Location = New System.Drawing.Point(140, 236)
        Me.txtMaxPitch.Mask = "99\º"
        Me.txtMaxPitch.Name = "txtMaxPitch"
        Me.txtMaxPitch.Size = New System.Drawing.Size(25, 20)
        Me.txtMaxPitch.TabIndex = 83
        Me.txtMaxPitch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(4, 240)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(124, 13)
        Me.Label18.TabIndex = 82
        Me.Label18.Text = "Pitch Limit Max Rotation:"
        '
        'txtWheelPowerForMin
        '
        Me.txtWheelPowerForMin.AllowPromptAsInput = False
        Me.txtWheelPowerForMin.BeepOnError = True
        Me.txtWheelPowerForMin.HidePromptOnLeave = True
        Me.txtWheelPowerForMin.Location = New System.Drawing.Point(567, 136)
        Me.txtWheelPowerForMin.Mask = "#990"
        Me.txtWheelPowerForMin.Name = "txtWheelPowerForMin"
        Me.txtWheelPowerForMin.Size = New System.Drawing.Size(25, 20)
        Me.txtWheelPowerForMin.TabIndex = 87
        Me.txtWheelPowerForMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(476, 140)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "Motor min power:"
        '
        'txtPitchPowerForMax
        '
        Me.txtPitchPowerForMax.AllowPromptAsInput = False
        Me.txtPitchPowerForMax.BeepOnError = True
        Me.txtPitchPowerForMax.HidePromptOnLeave = True
        Me.txtPitchPowerForMax.Location = New System.Drawing.Point(591, 236)
        Me.txtPitchPowerForMax.Mask = "#990"
        Me.txtPitchPowerForMax.Name = "txtPitchPowerForMax"
        Me.txtPitchPowerForMax.Size = New System.Drawing.Size(25, 20)
        Me.txtPitchPowerForMax.TabIndex = 93
        Me.txtPitchPowerForMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(542, 240)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 92
        Me.Label6.Text = "for Max:"
        '
        'txtPitchPowerForMin
        '
        Me.txtPitchPowerForMin.AllowPromptAsInput = False
        Me.txtPitchPowerForMin.BeepOnError = True
        Me.txtPitchPowerForMin.HidePromptOnLeave = True
        Me.txtPitchPowerForMin.Location = New System.Drawing.Point(514, 236)
        Me.txtPitchPowerForMin.Mask = "#990"
        Me.txtPitchPowerForMin.Name = "txtPitchPowerForMin"
        Me.txtPitchPowerForMin.Size = New System.Drawing.Size(25, 20)
        Me.txtPitchPowerForMin.TabIndex = 91
        Me.txtPitchPowerForMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(404, 240)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 13)
        Me.Label7.TabIndex = 90
        Me.Label7.Text = "Motor power for Min.:"
        '
        'txtRollPowerForMax
        '
        Me.txtRollPowerForMax.AllowPromptAsInput = False
        Me.txtRollPowerForMax.BeepOnError = True
        Me.txtRollPowerForMax.HidePromptOnLeave = True
        Me.txtRollPowerForMax.Location = New System.Drawing.Point(591, 262)
        Me.txtRollPowerForMax.Mask = "#990"
        Me.txtRollPowerForMax.Name = "txtRollPowerForMax"
        Me.txtRollPowerForMax.Size = New System.Drawing.Size(25, 20)
        Me.txtRollPowerForMax.TabIndex = 97
        Me.txtRollPowerForMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(542, 266)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 96
        Me.Label8.Text = "for Max:"
        '
        'txtRollPowerForMin
        '
        Me.txtRollPowerForMin.AllowPromptAsInput = False
        Me.txtRollPowerForMin.BeepOnError = True
        Me.txtRollPowerForMin.HidePromptOnLeave = True
        Me.txtRollPowerForMin.Location = New System.Drawing.Point(514, 262)
        Me.txtRollPowerForMin.Mask = "#990"
        Me.txtRollPowerForMin.Name = "txtRollPowerForMin"
        Me.txtRollPowerForMin.Size = New System.Drawing.Size(25, 20)
        Me.txtRollPowerForMin.TabIndex = 95
        Me.txtRollPowerForMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(404, 266)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(107, 13)
        Me.Label9.TabIndex = 94
        Me.Label9.Text = "Motor power for Min.:"
        '
        'btClose
        '
        Me.btClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btClose.BackColor = System.Drawing.Color.Gold
        Me.btClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btClose.Location = New System.Drawing.Point(706, 310)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(59, 22)
        Me.btClose.TabIndex = 103
        Me.btClose.Text = "Save"
        Me.btClose.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(451, 6)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(92, 13)
        Me.Label13.TabIndex = 105
        Me.Label13.Text = "Arduino Com Port:"
        '
        'cbComPort
        '
        Me.cbComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbComPort.FormattingEnabled = True
        Me.cbComPort.Location = New System.Drawing.Point(546, 3)
        Me.cbComPort.Name = "cbComPort"
        Me.cbComPort.Size = New System.Drawing.Size(73, 21)
        Me.cbComPort.TabIndex = 104
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(645, 7)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(69, 13)
        Me.Label14.TabIndex = 107
        Me.Label14.Text = "vJoy Device:"
        '
        'cbVjoy
        '
        Me.cbVjoy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVjoy.FormattingEnabled = True
        Me.cbVjoy.Location = New System.Drawing.Point(717, 3)
        Me.cbVjoy.Name = "cbVjoy"
        Me.cbVjoy.Size = New System.Drawing.Size(47, 21)
        Me.cbVjoy.TabIndex = 106
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(619, 240)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(28, 12)
        Me.Label17.TabIndex = 112
        Me.Label17.Text = "0-127"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(619, 267)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(28, 12)
        Me.Label19.TabIndex = 113
        Me.Label19.Text = "0-127"
        '
        'btTest1
        '
        Me.btTest1.BackColor = System.Drawing.Color.Gold
        Me.btTest1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btTest1.Location = New System.Drawing.Point(648, 136)
        Me.btTest1.Name = "btTest1"
        Me.btTest1.Size = New System.Drawing.Size(59, 20)
        Me.btTest1.TabIndex = 116
        Me.btTest1.Text = "Test Left"
        Me.btTest1.UseVisualStyleBackColor = False
        '
        'btTest2
        '
        Me.btTest2.BackColor = System.Drawing.Color.Gold
        Me.btTest2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btTest2.Location = New System.Drawing.Point(706, 136)
        Me.btTest2.Name = "btTest2"
        Me.btTest2.Size = New System.Drawing.Size(59, 20)
        Me.btTest2.TabIndex = 115
        Me.btTest2.Text = "Test Right"
        Me.btTest2.UseVisualStyleBackColor = False
        '
        'btTest3
        '
        Me.btTest3.BackColor = System.Drawing.Color.Gold
        Me.btTest3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btTest3.Location = New System.Drawing.Point(648, 237)
        Me.btTest3.Name = "btTest3"
        Me.btTest3.Size = New System.Drawing.Size(59, 20)
        Me.btTest3.TabIndex = 118
        Me.btTest3.Text = "Test Down"
        Me.btTest3.UseVisualStyleBackColor = False
        '
        'btTest4
        '
        Me.btTest4.BackColor = System.Drawing.Color.Gold
        Me.btTest4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btTest4.Location = New System.Drawing.Point(706, 237)
        Me.btTest4.Name = "btTest4"
        Me.btTest4.Size = New System.Drawing.Size(59, 20)
        Me.btTest4.TabIndex = 117
        Me.btTest4.Text = "Test Up"
        Me.btTest4.UseVisualStyleBackColor = False
        '
        'btTest5
        '
        Me.btTest5.BackColor = System.Drawing.Color.Gold
        Me.btTest5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btTest5.Location = New System.Drawing.Point(648, 262)
        Me.btTest5.Name = "btTest5"
        Me.btTest5.Size = New System.Drawing.Size(59, 20)
        Me.btTest5.TabIndex = 120
        Me.btTest5.Text = "Test Left"
        Me.btTest5.UseVisualStyleBackColor = False
        '
        'btTest6
        '
        Me.btTest6.BackColor = System.Drawing.Color.Gold
        Me.btTest6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btTest6.Location = New System.Drawing.Point(706, 262)
        Me.btTest6.Name = "btTest6"
        Me.btTest6.Size = New System.Drawing.Size(59, 20)
        Me.btTest6.TabIndex = 119
        Me.btTest6.Text = "Test Right"
        Me.btTest6.UseVisualStyleBackColor = False
        '
        'txtPitchHysteria
        '
        Me.txtPitchHysteria.AsciiOnly = True
        Me.txtPitchHysteria.BeepOnError = True
        Me.txtPitchHysteria.HidePromptOnLeave = True
        Me.txtPitchHysteria.Location = New System.Drawing.Point(253, 235)
        Me.txtPitchHysteria.Mask = "0.0\º"
        Me.txtPitchHysteria.Name = "txtPitchHysteria"
        Me.txtPitchHysteria.Size = New System.Drawing.Size(27, 20)
        Me.txtPitchHysteria.TabIndex = 122
        Me.txtPitchHysteria.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(192, 239)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 13)
        Me.Label10.TabIndex = 121
        Me.Label10.Text = "Deadband:"
        '
        'txtRollHysteria
        '
        Me.txtRollHysteria.AsciiOnly = True
        Me.txtRollHysteria.BeepOnError = True
        Me.txtRollHysteria.HidePromptOnLeave = True
        Me.txtRollHysteria.Location = New System.Drawing.Point(253, 262)
        Me.txtRollHysteria.Mask = "0.0\º"
        Me.txtRollHysteria.Name = "txtRollHysteria"
        Me.txtRollHysteria.Size = New System.Drawing.Size(27, 20)
        Me.txtRollHysteria.TabIndex = 124
        Me.txtRollHysteria.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(192, 266)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 13)
        Me.Label11.TabIndex = 123
        Me.Label11.Text = "Deadband:"
        '
        'txtRollOffset
        '
        Me.txtRollOffset.AsciiOnly = True
        Me.txtRollOffset.BeepOnError = True
        Me.txtRollOffset.HidePromptOnLeave = True
        Me.txtRollOffset.Location = New System.Drawing.Point(336, 262)
        Me.txtRollOffset.Mask = "#00.0\º"
        Me.txtRollOffset.Name = "txtRollOffset"
        Me.txtRollOffset.Size = New System.Drawing.Size(40, 20)
        Me.txtRollOffset.TabIndex = 128
        Me.txtRollOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(298, 266)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(38, 13)
        Me.Label12.TabIndex = 127
        Me.Label12.Text = "Offset:"
        '
        'txtPitchOffset
        '
        Me.txtPitchOffset.AsciiOnly = True
        Me.txtPitchOffset.BeepOnError = True
        Me.txtPitchOffset.HidePromptOnLeave = True
        Me.txtPitchOffset.Location = New System.Drawing.Point(336, 235)
        Me.txtPitchOffset.Mask = "#00.0\º"
        Me.txtPitchOffset.Name = "txtPitchOffset"
        Me.txtPitchOffset.Size = New System.Drawing.Size(40, 20)
        Me.txtPitchOffset.TabIndex = 126
        Me.txtPitchOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(298, 239)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(38, 13)
        Me.Label20.TabIndex = 125
        Me.Label20.Text = "Offset:"
        '
        'txtGyroMaxDegrees
        '
        Me.txtGyroMaxDegrees.AsciiOnly = True
        Me.txtGyroMaxDegrees.BeepOnError = True
        Me.txtGyroMaxDegrees.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.txtGyroMaxDegrees.HidePromptOnLeave = True
        Me.txtGyroMaxDegrees.Location = New System.Drawing.Point(202, 209)
        Me.txtGyroMaxDegrees.Mask = "0.0\º"
        Me.txtGyroMaxDegrees.Name = "txtGyroMaxDegrees"
        Me.txtGyroMaxDegrees.Size = New System.Drawing.Size(27, 20)
        Me.txtGyroMaxDegrees.TabIndex = 130
        Me.txtGyroMaxDegrees.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(4, 213)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(199, 13)
        Me.Label22.TabIndex = 129
        Me.Label22.Text = "Gyroscope Max Degrees per Timer click:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 13)
        Me.Label4.TabIndex = 131
        Me.Label4.Text = "Steering Wheel Sensitivity:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(4, 104)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(70, 13)
        Me.Label15.TabIndex = 132
        Me.Label15.Text = "Clutch Pedal:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(4, 78)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(68, 13)
        Me.Label23.TabIndex = 133
        Me.Label23.Text = "Brake Pedal:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(4, 52)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(94, 13)
        Me.Label24.TabIndex = 134
        Me.Label24.Text = "Accelerator Pedal:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(156, 33)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(30, 13)
        Me.Label25.TabIndex = 135
        Me.Label25.Text = "MIN:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(209, 33)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(33, 13)
        Me.Label26.TabIndex = 136
        Me.Label26.Text = "MAX:"
        '
        'txtAccelMax
        '
        Me.txtAccelMax.AllowPromptAsInput = False
        Me.txtAccelMax.BeepOnError = True
        Me.txtAccelMax.HidePromptOnLeave = True
        Me.txtAccelMax.Location = New System.Drawing.Point(201, 49)
        Me.txtAccelMax.Mask = "9999"
        Me.txtAccelMax.Name = "txtAccelMax"
        Me.txtAccelMax.Size = New System.Drawing.Size(40, 20)
        Me.txtAccelMax.TabIndex = 138
        Me.txtAccelMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAccelMax.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txtAccelMin
        '
        Me.txtAccelMin.AllowPromptAsInput = False
        Me.txtAccelMin.BeepOnError = True
        Me.txtAccelMin.HidePromptOnLeave = True
        Me.txtAccelMin.Location = New System.Drawing.Point(147, 49)
        Me.txtAccelMin.Mask = "9999"
        Me.txtAccelMin.Name = "txtAccelMin"
        Me.txtAccelMin.Size = New System.Drawing.Size(40, 20)
        Me.txtAccelMin.TabIndex = 137
        Me.txtAccelMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAccelMin.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txtBrakeMax
        '
        Me.txtBrakeMax.AllowPromptAsInput = False
        Me.txtBrakeMax.BeepOnError = True
        Me.txtBrakeMax.HidePromptOnLeave = True
        Me.txtBrakeMax.Location = New System.Drawing.Point(201, 75)
        Me.txtBrakeMax.Mask = "9999"
        Me.txtBrakeMax.Name = "txtBrakeMax"
        Me.txtBrakeMax.Size = New System.Drawing.Size(40, 20)
        Me.txtBrakeMax.TabIndex = 140
        Me.txtBrakeMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtBrakeMax.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txtBrakeMin
        '
        Me.txtBrakeMin.AllowPromptAsInput = False
        Me.txtBrakeMin.BeepOnError = True
        Me.txtBrakeMin.HidePromptOnLeave = True
        Me.txtBrakeMin.Location = New System.Drawing.Point(147, 75)
        Me.txtBrakeMin.Mask = "9999"
        Me.txtBrakeMin.Name = "txtBrakeMin"
        Me.txtBrakeMin.Size = New System.Drawing.Size(40, 20)
        Me.txtBrakeMin.TabIndex = 139
        Me.txtBrakeMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtBrakeMin.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txtClutchMax
        '
        Me.txtClutchMax.AllowPromptAsInput = False
        Me.txtClutchMax.BeepOnError = True
        Me.txtClutchMax.HidePromptOnLeave = True
        Me.txtClutchMax.Location = New System.Drawing.Point(201, 101)
        Me.txtClutchMax.Mask = "9999"
        Me.txtClutchMax.Name = "txtClutchMax"
        Me.txtClutchMax.Size = New System.Drawing.Size(40, 20)
        Me.txtClutchMax.TabIndex = 142
        Me.txtClutchMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtClutchMax.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txtClutchMin
        '
        Me.txtClutchMin.AllowPromptAsInput = False
        Me.txtClutchMin.BeepOnError = True
        Me.txtClutchMin.HidePromptOnLeave = True
        Me.txtClutchMin.Location = New System.Drawing.Point(147, 101)
        Me.txtClutchMin.Mask = "9999"
        Me.txtClutchMin.Name = "txtClutchMin"
        Me.txtClutchMin.Size = New System.Drawing.Size(40, 20)
        Me.txtClutchMin.TabIndex = 141
        Me.txtClutchMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtClutchMin.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(415, 32)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(128, 13)
        Me.Label27.TabIndex = 146
        Me.Label27.Text = "Mouse for steering wheel:"
        '
        'cbMouse
        '
        Me.cbMouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMouse.FormattingEnabled = True
        Me.cbMouse.Location = New System.Drawing.Point(546, 29)
        Me.cbMouse.Name = "cbMouse"
        Me.cbMouse.Size = New System.Drawing.Size(219, 21)
        Me.cbMouse.TabIndex = 145
        '
        'txtWheelDampFactor
        '
        Me.txtWheelDampFactor.AllowPromptAsInput = False
        Me.txtWheelDampFactor.BackColor = System.Drawing.SystemColors.Control
        Me.txtWheelDampFactor.BeepOnError = True
        Me.txtWheelDampFactor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtWheelDampFactor.HidePromptOnLeave = True
        Me.txtWheelDampFactor.Location = New System.Drawing.Point(342, 174)
        Me.txtWheelDampFactor.Mask = "#0000"
        Me.txtWheelDampFactor.Name = "txtWheelDampFactor"
        Me.txtWheelDampFactor.Size = New System.Drawing.Size(40, 20)
        Me.txtWheelDampFactor.TabIndex = 147
        Me.txtWheelDampFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.SystemColors.Control
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(259, 177)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(80, 13)
        Me.Label28.TabIndex = 148
        Me.Label28.Text = "FFDamp factor:"
        '
        'txtWheelSensitivity
        '
        Me.txtWheelSensitivity.AllowPromptAsInput = False
        Me.txtWheelSensitivity.BeepOnError = True
        Me.txtWheelSensitivity.HidePromptOnLeave = True
        Me.txtWheelSensitivity.Location = New System.Drawing.Point(140, 148)
        Me.txtWheelSensitivity.Mask = "#0000"
        Me.txtWheelSensitivity.Name = "txtWheelSensitivity"
        Me.txtWheelSensitivity.Size = New System.Drawing.Size(46, 20)
        Me.txtWheelSensitivity.TabIndex = 149
        Me.txtWheelSensitivity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(595, 141)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 12)
        Me.Label5.TabIndex = 150
        Me.Label5.Text = "0-255"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(77, 171)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 13)
        Me.Label16.TabIndex = 152
        Me.Label16.Text = "Deadband:"
        '
        'txtWheelDead
        '
        Me.txtWheelDead.AllowPromptAsInput = False
        Me.txtWheelDead.BeepOnError = True
        Me.txtWheelDead.HidePromptOnLeave = True
        Me.txtWheelDead.Location = New System.Drawing.Point(140, 168)
        Me.txtWheelDead.Mask = "9999"
        Me.txtWheelDead.Name = "txtWheelDead"
        Me.txtWheelDead.Size = New System.Drawing.Size(40, 20)
        Me.txtWheelDead.TabIndex = 151
        Me.txtWheelDead.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btDefaults
        '
        Me.btDefaults.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btDefaults.BackColor = System.Drawing.Color.Gold
        Me.btDefaults.Location = New System.Drawing.Point(621, 310)
        Me.btDefaults.Name = "btDefaults"
        Me.btDefaults.Size = New System.Drawing.Size(59, 22)
        Me.btDefaults.TabIndex = 155
        Me.btDefaults.Text = "defaults"
        Me.btDefaults.UseVisualStyleBackColor = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(595, 160)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(51, 12)
        Me.Label30.TabIndex = 159
        Me.Label30.Text = "0-800 (100)"
        '
        'txtWheelPowerGama
        '
        Me.txtWheelPowerGama.AllowPromptAsInput = False
        Me.txtWheelPowerGama.BeepOnError = True
        Me.txtWheelPowerGama.HidePromptOnLeave = True
        Me.txtWheelPowerGama.Location = New System.Drawing.Point(567, 155)
        Me.txtWheelPowerGama.Mask = "#990"
        Me.txtWheelPowerGama.Name = "txtWheelPowerGama"
        Me.txtWheelPowerGama.Size = New System.Drawing.Size(25, 20)
        Me.txtWheelPowerGama.TabIndex = 158
        Me.txtWheelPowerGama.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(471, 159)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(93, 13)
        Me.Label31.TabIndex = 157
        Me.Label31.Text = "FFConstant gama:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(595, 179)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(34, 12)
        Me.Label29.TabIndex = 162
        Me.Label29.Text = "0.5-3.0"
        '
        'txtWheelPowerFactor
        '
        Me.txtWheelPowerFactor.AllowPromptAsInput = False
        Me.txtWheelPowerFactor.BeepOnError = True
        Me.txtWheelPowerFactor.HidePromptOnLeave = True
        Me.txtWheelPowerFactor.Location = New System.Drawing.Point(567, 174)
        Me.txtWheelPowerFactor.Mask = "0.00"
        Me.txtWheelPowerFactor.Name = "txtWheelPowerFactor"
        Me.txtWheelPowerFactor.Size = New System.Drawing.Size(25, 20)
        Me.txtWheelPowerFactor.TabIndex = 161
        Me.txtWheelPowerFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(470, 178)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(94, 13)
        Me.Label32.TabIndex = 160
        Me.Label32.Text = "FFConstant factor:"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.SystemColors.Control
        Me.Label33.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label33.Location = New System.Drawing.Point(258, 140)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(82, 13)
        Me.Label33.TabIndex = 164
        Me.Label33.Text = "Minimum Damp:"
        '
        'txtWheelFriction
        '
        Me.txtWheelFriction.AllowPromptAsInput = False
        Me.txtWheelFriction.BackColor = System.Drawing.SystemColors.Control
        Me.txtWheelFriction.BeepOnError = True
        Me.txtWheelFriction.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtWheelFriction.HidePromptOnLeave = True
        Me.txtWheelFriction.Location = New System.Drawing.Point(342, 136)
        Me.txtWheelFriction.Mask = "0000"
        Me.txtWheelFriction.Name = "txtWheelFriction"
        Me.txtWheelFriction.Size = New System.Drawing.Size(40, 20)
        Me.txtWheelFriction.TabIndex = 163
        Me.txtWheelFriction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.ForeColor = System.Drawing.Color.DimGray
        Me.Label34.Location = New System.Drawing.Point(252, 159)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(87, 13)
        Me.Label34.TabIndex = 166
        Me.Label34.Text = "FFDamp gamma:"
        '
        'txtWheelInertia
        '
        Me.txtWheelInertia.AllowPromptAsInput = False
        Me.txtWheelInertia.BackColor = System.Drawing.SystemColors.Control
        Me.txtWheelInertia.BeepOnError = True
        Me.txtWheelInertia.ForeColor = System.Drawing.Color.DimGray
        Me.txtWheelInertia.HidePromptOnLeave = True
        Me.txtWheelInertia.Location = New System.Drawing.Point(342, 155)
        Me.txtWheelInertia.Mask = "000"
        Me.txtWheelInertia.Name = "txtWheelInertia"
        Me.txtWheelInertia.Size = New System.Drawing.Size(40, 20)
        Me.txtWheelInertia.TabIndex = 165
        Me.txtWheelInertia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.BackColor = System.Drawing.SystemColors.Control
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label36.Location = New System.Drawing.Point(385, 140)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(33, 12)
        Me.Label36.TabIndex = 168
        Me.Label36.Text = "0-9999"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.DimGray
        Me.Label35.Location = New System.Drawing.Point(385, 160)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(51, 12)
        Me.Label35.TabIndex = 169
        Me.Label35.Text = "0-800 (100)"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(595, 94)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(51, 12)
        Me.Label37.TabIndex = 172
        Me.Label37.Text = "0-800 (100)"
        '
        'txtSpeedGama
        '
        Me.txtSpeedGama.AllowPromptAsInput = False
        Me.txtSpeedGama.BeepOnError = True
        Me.txtSpeedGama.HidePromptOnLeave = True
        Me.txtSpeedGama.Location = New System.Drawing.Point(567, 89)
        Me.txtSpeedGama.Mask = "#990"
        Me.txtSpeedGama.Name = "txtSpeedGama"
        Me.txtSpeedGama.Size = New System.Drawing.Size(25, 20)
        Me.txtSpeedGama.TabIndex = 171
        Me.txtSpeedGama.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(494, 93)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(70, 13)
        Me.Label38.TabIndex = 170
        Me.Label38.Text = "Speed gama:"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(595, 76)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(28, 12)
        Me.Label39.TabIndex = 175
        Me.Label39.Text = "0-255"
        '
        'txtSpeedMin
        '
        Me.txtSpeedMin.AllowPromptAsInput = False
        Me.txtSpeedMin.BeepOnError = True
        Me.txtSpeedMin.HidePromptOnLeave = True
        Me.txtSpeedMin.Location = New System.Drawing.Point(567, 71)
        Me.txtSpeedMin.Mask = "#990"
        Me.txtSpeedMin.Name = "txtSpeedMin"
        Me.txtSpeedMin.Size = New System.Drawing.Size(25, 20)
        Me.txtSpeedMin.TabIndex = 174
        Me.txtSpeedMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(473, 75)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(92, 13)
        Me.Label40.TabIndex = 173
        Me.Label40.Text = "Speed min power:"
        '
        'btTestSpeed
        '
        Me.btTestSpeed.BackColor = System.Drawing.Color.Gold
        Me.btTestSpeed.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btTestSpeed.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btTestSpeed.Location = New System.Drawing.Point(648, 71)
        Me.btTestSpeed.Name = "btTestSpeed"
        Me.btTestSpeed.Size = New System.Drawing.Size(91, 20)
        Me.btTestSpeed.TabIndex = 176
        Me.btTestSpeed.Text = "Test Wind&Shake"
        Me.btTestSpeed.UseMnemonic = False
        Me.btTestSpeed.UseVisualStyleBackColor = False
        '
        'txtClutchGama
        '
        Me.txtClutchGama.AllowPromptAsInput = False
        Me.txtClutchGama.BeepOnError = True
        Me.txtClutchGama.HidePromptOnLeave = True
        Me.txtClutchGama.Location = New System.Drawing.Point(254, 101)
        Me.txtClutchGama.Mask = "9999"
        Me.txtClutchGama.Name = "txtClutchGama"
        Me.txtClutchGama.Size = New System.Drawing.Size(40, 20)
        Me.txtClutchGama.TabIndex = 180
        Me.txtClutchGama.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtClutchGama.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txtBrakeGama
        '
        Me.txtBrakeGama.AllowPromptAsInput = False
        Me.txtBrakeGama.BeepOnError = True
        Me.txtBrakeGama.HidePromptOnLeave = True
        Me.txtBrakeGama.Location = New System.Drawing.Point(254, 75)
        Me.txtBrakeGama.Mask = "9999"
        Me.txtBrakeGama.Name = "txtBrakeGama"
        Me.txtBrakeGama.Size = New System.Drawing.Size(40, 20)
        Me.txtBrakeGama.TabIndex = 179
        Me.txtBrakeGama.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtBrakeGama.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txtAccelGama
        '
        Me.txtAccelGama.AllowPromptAsInput = False
        Me.txtAccelGama.BeepOnError = True
        Me.txtAccelGama.HidePromptOnLeave = True
        Me.txtAccelGama.Location = New System.Drawing.Point(254, 49)
        Me.txtAccelGama.Mask = "9999"
        Me.txtAccelGama.Name = "txtAccelGama"
        Me.txtAccelGama.Size = New System.Drawing.Size(40, 20)
        Me.txtAccelGama.TabIndex = 178
        Me.txtAccelGama.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAccelGama.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(262, 33)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(36, 13)
        Me.Label41.TabIndex = 177
        Me.Label41.Text = "gama:"
        '
        'btAccelGraph
        '
        Me.btAccelGraph.BackColor = System.Drawing.Color.Gold
        Me.btAccelGraph.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btAccelGraph.Location = New System.Drawing.Point(300, 49)
        Me.btAccelGraph.Name = "btAccelGraph"
        Me.btAccelGraph.Size = New System.Drawing.Size(59, 20)
        Me.btAccelGraph.TabIndex = 181
        Me.btAccelGraph.Text = "Graph"
        Me.btAccelGraph.UseVisualStyleBackColor = False
        '
        'btBrakeGraph
        '
        Me.btBrakeGraph.BackColor = System.Drawing.Color.Gold
        Me.btBrakeGraph.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btBrakeGraph.Location = New System.Drawing.Point(300, 75)
        Me.btBrakeGraph.Name = "btBrakeGraph"
        Me.btBrakeGraph.Size = New System.Drawing.Size(59, 20)
        Me.btBrakeGraph.TabIndex = 182
        Me.btBrakeGraph.Text = "Graph"
        Me.btBrakeGraph.UseVisualStyleBackColor = False
        '
        'btClutchGraph
        '
        Me.btClutchGraph.BackColor = System.Drawing.Color.Gold
        Me.btClutchGraph.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btClutchGraph.Location = New System.Drawing.Point(300, 101)
        Me.btClutchGraph.Name = "btClutchGraph"
        Me.btClutchGraph.Size = New System.Drawing.Size(59, 20)
        Me.btClutchGraph.TabIndex = 183
        Me.btClutchGraph.Text = "Graph"
        Me.btClutchGraph.UseVisualStyleBackColor = False
        '
        'UcControlGraph1
        '
        Me.UcControlGraph1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UcControlGraph1.Location = New System.Drawing.Point(0, 324)
        Me.UcControlGraph1.Margin = New System.Windows.Forms.Padding(0)
        Me.UcControlGraph1.Name = "UcControlGraph1"
        Me.UcControlGraph1.Size = New System.Drawing.Size(770, 11)
        Me.UcControlGraph1.TabIndex = 184
        Me.UcControlGraph1.TabStop = False
        Me.UcControlGraph1.Visible = False
        '
        'frmSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(770, 335)
        Me.Controls.Add(Me.UcControlGraph1)
        Me.Controls.Add(Me.btClutchGraph)
        Me.Controls.Add(Me.btBrakeGraph)
        Me.Controls.Add(Me.btAccelGraph)
        Me.Controls.Add(Me.txtClutchGama)
        Me.Controls.Add(Me.txtBrakeGama)
        Me.Controls.Add(Me.txtAccelGama)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.btTestSpeed)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.txtSpeedMin)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.txtSpeedGama)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.txtWheelInertia)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.txtWheelFriction)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.txtWheelPowerFactor)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.txtWheelPowerGama)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.btDefaults)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtWheelDead)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtWheelSensitivity)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.txtWheelDampFactor)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.cbMouse)
        Me.Controls.Add(Me.txtClutchMax)
        Me.Controls.Add(Me.txtClutchMin)
        Me.Controls.Add(Me.txtBrakeMax)
        Me.Controls.Add(Me.txtBrakeMin)
        Me.Controls.Add(Me.txtAccelMax)
        Me.Controls.Add(Me.txtAccelMin)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtGyroMaxDegrees)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtRollOffset)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtPitchOffset)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtRollHysteria)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtPitchHysteria)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btTest5)
        Me.Controls.Add(Me.btTest6)
        Me.Controls.Add(Me.btTest3)
        Me.Controls.Add(Me.btTest4)
        Me.Controls.Add(Me.btTest1)
        Me.Controls.Add(Me.btTest2)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.cbVjoy)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cbComPort)
        Me.Controls.Add(Me.btClose)
        Me.Controls.Add(Me.txtRollPowerForMax)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtRollPowerForMin)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtPitchPowerForMax)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtPitchPowerForMin)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtWheelPowerForMin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtMaxRoll)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtMaxPitch)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtFreq)
        Me.Controls.Add(Me.Label2)
        Me.Name = "frmSetup"
        Me.Text = "frmSetup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents txtFreq As MaskedTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtMaxRoll As MaskedTextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtMaxPitch As MaskedTextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtWheelPowerForMin As MaskedTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtPitchPowerForMax As MaskedTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtPitchPowerForMin As MaskedTextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtRollPowerForMax As MaskedTextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtRollPowerForMin As MaskedTextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents btClose As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents cbComPort As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents cbVjoy As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents btTest1 As Button
    Friend WithEvents btTest2 As Button
    Friend WithEvents btTest3 As Button
    Friend WithEvents btTest4 As Button
    Friend WithEvents btTest5 As Button
    Friend WithEvents btTest6 As Button
    Friend WithEvents txtPitchHysteria As MaskedTextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtRollHysteria As MaskedTextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtRollOffset As MaskedTextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtPitchOffset As MaskedTextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents txtGyroMaxDegrees As MaskedTextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents txtAccelMax As MaskedTextBox
    Friend WithEvents txtAccelMin As MaskedTextBox
    Friend WithEvents txtBrakeMax As MaskedTextBox
    Friend WithEvents txtBrakeMin As MaskedTextBox
    Friend WithEvents txtClutchMax As MaskedTextBox
    Friend WithEvents txtClutchMin As MaskedTextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents cbMouse As ComboBox
    Friend WithEvents txtWheelDampFactor As MaskedTextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents txtWheelSensitivity As MaskedTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtWheelDead As MaskedTextBox
    Friend WithEvents btDefaults As Button
    Friend WithEvents Label30 As Label
    Friend WithEvents txtWheelPowerGama As MaskedTextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents txtWheelPowerFactor As MaskedTextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents txtWheelFriction As MaskedTextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents txtWheelInertia As MaskedTextBox
    Friend WithEvents Label36 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents txtSpeedGama As MaskedTextBox
    Friend WithEvents Label38 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents txtSpeedMin As MaskedTextBox
    Friend WithEvents Label40 As Label
    Friend WithEvents btTestSpeed As Button
    Friend WithEvents txtClutchGama As MaskedTextBox
    Friend WithEvents txtBrakeGama As MaskedTextBox
    Friend WithEvents txtAccelGama As MaskedTextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents btAccelGraph As Button
    Friend WithEvents btBrakeGraph As Button
    Friend WithEvents btClutchGraph As Button
    Friend WithEvents UcControlGraph1 As ucControlGraph
End Class
