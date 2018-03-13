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
        Me.SuspendLayout()
        '
        'btReset
        '
        Me.btReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btReset.BackColor = System.Drawing.Color.Gold
        Me.btReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btReset.Location = New System.Drawing.Point(307, 148)
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
        Me.chkPause.Location = New System.Drawing.Point(357, 150)
        Me.chkPause.Name = "chkPause"
        Me.chkPause.Size = New System.Drawing.Size(52, 16)
        Me.chkPause.TabIndex = 192
        Me.chkPause.Text = "Pause"
        Me.chkPause.UseVisualStyleBackColor = False
        '
        'ucControlGGraph
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.Controls.Add(Me.chkPause)
        Me.Controls.Add(Me.btReset)
        Me.Name = "ucControlGGraph"
        Me.Size = New System.Drawing.Size(736, 170)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btReset As Button
    Friend WithEvents chkPause As CheckBox
End Class
