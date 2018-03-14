<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucControlGGraph
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.btReset = New System.Windows.Forms.Button()
        Me.chkPause = New System.Windows.Forms.CheckBox()
        Me.chkDesired = New System.Windows.Forms.CheckBox()
        Me.chkMotor = New System.Windows.Forms.CheckBox()
        Me.chkReal = New System.Windows.Forms.CheckBox()
        Me.rdPitch = New System.Windows.Forms.RadioButton()
        Me.rdRoll = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'btReset
        '
        Me.btReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btReset.BackColor = System.Drawing.Color.Gold
        Me.btReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btReset.Location = New System.Drawing.Point(6, 148)
        Me.btReset.Name = "btReset"
        Me.btReset.Size = New System.Drawing.Size(44, 20)
        Me.btReset.TabIndex = 190
        Me.btReset.Text = "Reset"
        Me.btReset.UseVisualStyleBackColor = False
        '
        'chkPause
        '
        Me.chkPause.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPause.BackColor = System.Drawing.Color.Gold
        Me.chkPause.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPause.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.chkPause.Location = New System.Drawing.Point(56, 150)
        Me.chkPause.Name = "chkPause"
        Me.chkPause.Size = New System.Drawing.Size(52, 16)
        Me.chkPause.TabIndex = 192
        Me.chkPause.Text = "Pause"
        Me.chkPause.UseVisualStyleBackColor = False
        '
        'chkDesired
        '
        Me.chkDesired.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkDesired.BackColor = System.Drawing.Color.Green
        Me.chkDesired.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDesired.Checked = True
        Me.chkDesired.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDesired.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.chkDesired.Location = New System.Drawing.Point(182, 150)
        Me.chkDesired.Name = "chkDesired"
        Me.chkDesired.Size = New System.Drawing.Size(65, 16)
        Me.chkDesired.TabIndex = 193
        Me.chkDesired.Text = "Desired"
        Me.chkDesired.UseVisualStyleBackColor = False
        '
        'chkMotor
        '
        Me.chkMotor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkMotor.BackColor = System.Drawing.Color.Red
        Me.chkMotor.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkMotor.Checked = True
        Me.chkMotor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMotor.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.chkMotor.Location = New System.Drawing.Point(324, 150)
        Me.chkMotor.Name = "chkMotor"
        Me.chkMotor.Size = New System.Drawing.Size(65, 16)
        Me.chkMotor.TabIndex = 194
        Me.chkMotor.Text = "Motors"
        Me.chkMotor.UseVisualStyleBackColor = False
        '
        'chkReal
        '
        Me.chkReal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkReal.BackColor = System.Drawing.Color.White
        Me.chkReal.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkReal.Checked = True
        Me.chkReal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkReal.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.chkReal.Location = New System.Drawing.Point(253, 150)
        Me.chkReal.Name = "chkReal"
        Me.chkReal.Size = New System.Drawing.Size(65, 16)
        Me.chkReal.TabIndex = 195
        Me.chkReal.Text = "Real"
        Me.chkReal.UseVisualStyleBackColor = False
        '
        'rdPitch
        '
        Me.rdPitch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rdPitch.BackColor = System.Drawing.Color.Gold
        Me.rdPitch.Checked = True
        Me.rdPitch.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.rdPitch.Location = New System.Drawing.Point(483, 150)
        Me.rdPitch.Name = "rdPitch"
        Me.rdPitch.Size = New System.Drawing.Size(47, 16)
        Me.rdPitch.TabIndex = 196
        Me.rdPitch.TabStop = True
        Me.rdPitch.Text = "Pitch"
        Me.rdPitch.UseVisualStyleBackColor = False
        '
        'rdRoll
        '
        Me.rdRoll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rdRoll.BackColor = System.Drawing.Color.Gold
        Me.rdRoll.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.rdRoll.Location = New System.Drawing.Point(536, 150)
        Me.rdRoll.Name = "rdRoll"
        Me.rdRoll.Size = New System.Drawing.Size(47, 16)
        Me.rdRoll.TabIndex = 197
        Me.rdRoll.Text = "Roll"
        Me.rdRoll.UseVisualStyleBackColor = False
        '
        'ucControlGGraph
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.Controls.Add(Me.rdRoll)
        Me.Controls.Add(Me.rdPitch)
        Me.Controls.Add(Me.chkReal)
        Me.Controls.Add(Me.chkMotor)
        Me.Controls.Add(Me.chkDesired)
        Me.Controls.Add(Me.chkPause)
        Me.Controls.Add(Me.btReset)
        Me.Name = "ucControlGGraph"
        Me.Size = New System.Drawing.Size(736, 170)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btReset As Button
    Friend WithEvents chkPause As CheckBox
    Friend WithEvents chkDesired As CheckBox
    Friend WithEvents chkMotor As CheckBox
    Friend WithEvents chkReal As CheckBox
    Friend WithEvents rdPitch As RadioButton
    Friend WithEvents rdRoll As RadioButton
End Class
