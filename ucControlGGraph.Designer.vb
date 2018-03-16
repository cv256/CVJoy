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
        Me.rdBoth = New System.Windows.Forms.RadioButton()
        Me.rdLeft = New System.Windows.Forms.RadioButton()
        Me.rdRight = New System.Windows.Forms.RadioButton()
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
        Me.btReset.TabIndex = 0
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
        Me.chkPause.TabIndex = 1
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
        Me.chkDesired.TabIndex = 2
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
        Me.chkMotor.TabIndex = 4
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
        Me.chkReal.TabIndex = 3
        Me.chkReal.Text = "Real"
        Me.chkReal.UseVisualStyleBackColor = False
        '
        'rdBoth
        '
        Me.rdBoth.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rdBoth.BackColor = System.Drawing.Color.Gold
        Me.rdBoth.Checked = True
        Me.rdBoth.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.rdBoth.Location = New System.Drawing.Point(483, 150)
        Me.rdBoth.Name = "rdBoth"
        Me.rdBoth.Size = New System.Drawing.Size(47, 16)
        Me.rdBoth.TabIndex = 5
        Me.rdBoth.TabStop = True
        Me.rdBoth.Text = "Both"
        Me.rdBoth.UseVisualStyleBackColor = False
        '
        'rdLeft
        '
        Me.rdLeft.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rdLeft.BackColor = System.Drawing.Color.Gold
        Me.rdLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.rdLeft.Location = New System.Drawing.Point(536, 150)
        Me.rdLeft.Name = "rdLeft"
        Me.rdLeft.Size = New System.Drawing.Size(47, 16)
        Me.rdLeft.TabIndex = 6
        Me.rdLeft.Text = "Left"
        Me.rdLeft.UseVisualStyleBackColor = False
        '
        'rdRight
        '
        Me.rdRight.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rdRight.BackColor = System.Drawing.Color.Gold
        Me.rdRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.rdRight.Location = New System.Drawing.Point(589, 150)
        Me.rdRight.Name = "rdRight"
        Me.rdRight.Size = New System.Drawing.Size(47, 16)
        Me.rdRight.TabIndex = 7
        Me.rdRight.Text = "Right"
        Me.rdRight.UseVisualStyleBackColor = False
        '
        'ucControlGGraph
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.Controls.Add(Me.rdRight)
        Me.Controls.Add(Me.rdLeft)
        Me.Controls.Add(Me.rdBoth)
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
    Friend WithEvents rdBoth As RadioButton
    Friend WithEvents rdLeft As RadioButton
    Friend WithEvents rdRight As RadioButton
End Class
