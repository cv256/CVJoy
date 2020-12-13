<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSetupStd
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
        Me.btApply = New System.Windows.Forms.Button()
        Me.btDefaults = New System.Windows.Forms.Button()
        Me.btSave = New System.Windows.Forms.Button()
        Me.btClose = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UcButtons1 = New CVJoy.ucButtons()
        Me.ckKeepVisible = New System.Windows.Forms.CheckBox()
        Me.txtWheelSensitivity = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btApply
        '
        Me.btApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btApply.BackColor = System.Drawing.Color.Gold
        Me.btApply.Location = New System.Drawing.Point(380, 113)
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
        Me.btDefaults.Location = New System.Drawing.Point(318, 113)
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
        Me.btSave.Location = New System.Drawing.Point(484, 113)
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
        Me.btClose.Location = New System.Drawing.Point(549, 113)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(59, 22)
        Me.btClose.TabIndex = 229
        Me.btClose.Text = "Close"
        Me.btClose.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(171, 13)
        Me.Label2.TabIndex = 231
        Me.Label2.Text = "Simulator buttons send keystrokes:"
        '
        'UcButtons1
        '
        Me.UcButtons1.Location = New System.Drawing.Point(177, 4)
        Me.UcButtons1.Name = "UcButtons1"
        Me.UcButtons1.ReadOnly = False
        Me.UcButtons1.Size = New System.Drawing.Size(366, 37)
        Me.UcButtons1.TabIndex = 230
        '
        'ckKeepVisible
        '
        Me.ckKeepVisible.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckKeepVisible.AutoSize = True
        Me.ckKeepVisible.BackColor = System.Drawing.Color.Transparent
        Me.ckKeepVisible.Location = New System.Drawing.Point(231, 116)
        Me.ckKeepVisible.Name = "ckKeepVisible"
        Me.ckKeepVisible.Size = New System.Drawing.Size(84, 17)
        Me.ckKeepVisible.TabIndex = 232
        Me.ckKeepVisible.Text = "Keep Visible"
        Me.ckKeepVisible.UseVisualStyleBackColor = False
        '
        'txtWheelSensitivity
        '
        Me.txtWheelSensitivity.AllowPromptAsInput = False
        Me.txtWheelSensitivity.BeepOnError = True
        Me.txtWheelSensitivity.HidePromptOnLeave = True
        Me.txtWheelSensitivity.Location = New System.Drawing.Point(181, 57)
        Me.txtWheelSensitivity.Mask = "#0000"
        Me.txtWheelSensitivity.Name = "txtWheelSensitivity"
        Me.txtWheelSensitivity.Size = New System.Drawing.Size(46, 20)
        Me.txtWheelSensitivity.TabIndex = 234
        Me.txtWheelSensitivity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(43, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 13)
        Me.Label4.TabIndex = 233
        Me.Label4.Text = "Steering Wheel Sensitivity:"
        '
        'frmSetupStd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(610, 134)
        Me.Controls.Add(Me.txtWheelSensitivity)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ckKeepVisible)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.UcButtons1)
        Me.Controls.Add(Me.btClose)
        Me.Controls.Add(Me.btSave)
        Me.Controls.Add(Me.btDefaults)
        Me.Controls.Add(Me.btApply)
        Me.Name = "frmSetupStd"
        Me.Text = "CV Joy - Setup Standard"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btApply As Button
    Friend WithEvents btDefaults As Button
    Friend WithEvents btSave As Button
    Friend WithEvents btClose As Button
    Friend WithEvents UcButtons1 As ucButtons
    Friend WithEvents Label2 As Label
    Friend WithEvents ckKeepVisible As CheckBox
    Friend WithEvents txtWheelSensitivity As MaskedTextBox
    Friend WithEvents Label4 As Label
End Class
