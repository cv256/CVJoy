<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSetupMotionSim
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UcButtons1 = New CVJoy.ucButtons()
        Me.txtUdpPort = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtWheelSensitivity = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ckKeepVisible
        '
        Me.ckKeepVisible.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ckKeepVisible.AutoSize = True
        Me.ckKeepVisible.BackColor = System.Drawing.Color.Transparent
        Me.ckKeepVisible.Location = New System.Drawing.Point(230, 99)
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
        Me.btApply.Location = New System.Drawing.Point(380, 96)
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
        Me.btDefaults.Location = New System.Drawing.Point(318, 96)
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
        Me.btSave.Location = New System.Drawing.Point(484, 96)
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
        Me.btClose.Location = New System.Drawing.Point(549, 96)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(59, 22)
        Me.btClose.TabIndex = 229
        Me.btClose.Text = "Close"
        Me.btClose.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(0, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(171, 13)
        Me.Label2.TabIndex = 231
        Me.Label2.Text = "Simulator buttons send keystrokes:"
        '
        'UcButtons1
        '
        Me.UcButtons1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UcButtons1.Location = New System.Drawing.Point(182, 7)
        Me.UcButtons1.Name = "UcButtons1"
        Me.UcButtons1.ReadOnly = False
        Me.UcButtons1.ShowDescriptions = False
        Me.UcButtons1.Size = New System.Drawing.Size(416, 37)
        Me.UcButtons1.TabIndex = 230
        '
        'txtUdpPort
        '
        Me.txtUdpPort.AllowPromptAsInput = False
        Me.txtUdpPort.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtUdpPort.BeepOnError = True
        Me.txtUdpPort.HidePromptOnLeave = True
        Me.txtUdpPort.Location = New System.Drawing.Point(93, 74)
        Me.txtUdpPort.Mask = "#00000"
        Me.txtUdpPort.Name = "txtUdpPort"
        Me.txtUdpPort.Size = New System.Drawing.Size(46, 20)
        Me.txtUdpPort.TabIndex = 341
        Me.txtUdpPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 340
        Me.Label1.Text = "UDP Port:"
        '
        'txtWheelSensitivity
        '
        Me.txtWheelSensitivity.AllowPromptAsInput = False
        Me.txtWheelSensitivity.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtWheelSensitivity.BeepOnError = True
        Me.txtWheelSensitivity.HidePromptOnLeave = True
        Me.txtWheelSensitivity.Location = New System.Drawing.Point(171, 50)
        Me.txtWheelSensitivity.Mask = "#0000"
        Me.txtWheelSensitivity.Name = "txtWheelSensitivity"
        Me.txtWheelSensitivity.Size = New System.Drawing.Size(46, 20)
        Me.txtWheelSensitivity.TabIndex = 329
        Me.txtWheelSensitivity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(133, 13)
        Me.Label5.TabIndex = 328
        Me.Label5.Text = "Steering Wheel Sensitivity:"
        '
        'frmSetupMotionSim
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(610, 117)
        Me.Controls.Add(Me.txtUdpPort)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtWheelSensitivity)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.UcButtons1)
        Me.Controls.Add(Me.ckKeepVisible)
        Me.Controls.Add(Me.btClose)
        Me.Controls.Add(Me.btSave)
        Me.Controls.Add(Me.btDefaults)
        Me.Controls.Add(Me.btApply)
        Me.Name = "frmSetupMotionSim"
        Me.Text = "CV Joy - Setup MotionSim"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ckKeepVisible As CheckBox
    Friend WithEvents btApply As Button
    Friend WithEvents btDefaults As Button
    Friend WithEvents btSave As Button
    Friend WithEvents btClose As Button
    Friend WithEvents UcButtons1 As ucButtons
    Friend WithEvents Label2 As Label
    Friend WithEvents txtUdpPort As MaskedTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtWheelSensitivity As MaskedTextBox
    Friend WithEvents Label5 As Label
End Class
