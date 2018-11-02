<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucACGraph
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
        Me.chkCgHeight = New System.Windows.Forms.CheckBox()
        Me.chkSusTravel = New System.Windows.Forms.CheckBox()
        Me.chkRideHeight = New System.Windows.Forms.CheckBox()
        Me.chkWheelLoad = New System.Windows.Forms.CheckBox()
        Me.txtrangeCgHeight = New System.Windows.Forms.TextBox()
        Me.lbrangeCgHeight = New System.Windows.Forms.Label()
        Me.txtrangeRideHeight = New System.Windows.Forms.TextBox()
        Me.lbrangeRideHeight = New System.Windows.Forms.Label()
        Me.txtrangeSuspensionTravel = New System.Windows.Forms.TextBox()
        Me.lbrangeSuspensionTravel = New System.Windows.Forms.Label()
        Me.txtrangeWheelLoad = New System.Windows.Forms.TextBox()
        Me.lbrangeWheelLoad = New System.Windows.Forms.Label()
        Me.cbWheel = New System.Windows.Forms.ComboBox()
        Me.txtUp = New System.Windows.Forms.TextBox()
        Me.txtDn = New System.Windows.Forms.TextBox()
        Me.txtCenter = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btReset
        '
        Me.btReset.BackColor = System.Drawing.Color.Gold
        Me.btReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btReset.Location = New System.Drawing.Point(1, 112)
        Me.btReset.Name = "btReset"
        Me.btReset.Size = New System.Drawing.Size(44, 20)
        Me.btReset.TabIndex = 0
        Me.btReset.Text = "Reset"
        Me.btReset.UseVisualStyleBackColor = False
        '
        'chkPause
        '
        Me.chkPause.BackColor = System.Drawing.Color.Gold
        Me.chkPause.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPause.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.chkPause.Location = New System.Drawing.Point(51, 114)
        Me.chkPause.Name = "chkPause"
        Me.chkPause.Size = New System.Drawing.Size(52, 16)
        Me.chkPause.TabIndex = 1
        Me.chkPause.Text = "Pause"
        Me.chkPause.UseVisualStyleBackColor = False
        '
        'chkCgHeight
        '
        Me.chkCgHeight.BackColor = System.Drawing.Color.Green
        Me.chkCgHeight.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCgHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.chkCgHeight.Location = New System.Drawing.Point(2, 3)
        Me.chkCgHeight.Name = "chkCgHeight"
        Me.chkCgHeight.Size = New System.Drawing.Size(71, 16)
        Me.chkCgHeight.TabIndex = 2
        Me.chkCgHeight.Text = "CgHeight"
        Me.chkCgHeight.UseVisualStyleBackColor = False
        '
        'chkSusTravel
        '
        Me.chkSusTravel.BackColor = System.Drawing.Color.White
        Me.chkSusTravel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkSusTravel.Checked = True
        Me.chkSusTravel.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSusTravel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.chkSusTravel.Location = New System.Drawing.Point(2, 45)
        Me.chkSusTravel.Name = "chkSusTravel"
        Me.chkSusTravel.Size = New System.Drawing.Size(71, 16)
        Me.chkSusTravel.TabIndex = 4
        Me.chkSusTravel.Text = "SusTravel"
        Me.chkSusTravel.UseVisualStyleBackColor = False
        '
        'chkRideHeight
        '
        Me.chkRideHeight.BackColor = System.Drawing.Color.Orange
        Me.chkRideHeight.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkRideHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.chkRideHeight.Location = New System.Drawing.Point(2, 24)
        Me.chkRideHeight.Name = "chkRideHeight"
        Me.chkRideHeight.Size = New System.Drawing.Size(71, 16)
        Me.chkRideHeight.TabIndex = 3
        Me.chkRideHeight.Text = "RideHeight"
        Me.chkRideHeight.UseVisualStyleBackColor = False
        '
        'chkWheelLoad
        '
        Me.chkWheelLoad.BackColor = System.Drawing.Color.Magenta
        Me.chkWheelLoad.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkWheelLoad.Checked = True
        Me.chkWheelLoad.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkWheelLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.chkWheelLoad.Location = New System.Drawing.Point(2, 66)
        Me.chkWheelLoad.Name = "chkWheelLoad"
        Me.chkWheelLoad.Size = New System.Drawing.Size(71, 16)
        Me.chkWheelLoad.TabIndex = 10
        Me.chkWheelLoad.Text = "WheelLoad"
        Me.chkWheelLoad.UseVisualStyleBackColor = False
        '
        'txtrangeCgHeight
        '
        Me.txtrangeCgHeight.Location = New System.Drawing.Point(105, 0)
        Me.txtrangeCgHeight.Name = "txtrangeCgHeight"
        Me.txtrangeCgHeight.Size = New System.Drawing.Size(30, 20)
        Me.txtrangeCgHeight.TabIndex = 12
        Me.txtrangeCgHeight.Text = "470"
        '
        'lbrangeCgHeight
        '
        Me.lbrangeCgHeight.AutoSize = True
        Me.lbrangeCgHeight.BackColor = System.Drawing.Color.Transparent
        Me.lbrangeCgHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbrangeCgHeight.ForeColor = System.Drawing.Color.White
        Me.lbrangeCgHeight.Location = New System.Drawing.Point(74, 4)
        Me.lbrangeCgHeight.Name = "lbrangeCgHeight"
        Me.lbrangeCgHeight.Size = New System.Drawing.Size(81, 12)
        Me.lbrangeCgHeight.TabIndex = 13
        Me.lbrangeCgHeight.Text = "Range:               mm"
        '
        'txtrangeRideHeight
        '
        Me.txtrangeRideHeight.Location = New System.Drawing.Point(105, 21)
        Me.txtrangeRideHeight.Name = "txtrangeRideHeight"
        Me.txtrangeRideHeight.Size = New System.Drawing.Size(30, 20)
        Me.txtrangeRideHeight.TabIndex = 14
        Me.txtrangeRideHeight.Text = "210"
        '
        'lbrangeRideHeight
        '
        Me.lbrangeRideHeight.AutoSize = True
        Me.lbrangeRideHeight.BackColor = System.Drawing.Color.Transparent
        Me.lbrangeRideHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbrangeRideHeight.ForeColor = System.Drawing.Color.White
        Me.lbrangeRideHeight.Location = New System.Drawing.Point(74, 25)
        Me.lbrangeRideHeight.Name = "lbrangeRideHeight"
        Me.lbrangeRideHeight.Size = New System.Drawing.Size(81, 12)
        Me.lbrangeRideHeight.TabIndex = 15
        Me.lbrangeRideHeight.Text = "Range:               mm"
        '
        'txtrangeSuspensionTravel
        '
        Me.txtrangeSuspensionTravel.Location = New System.Drawing.Point(105, 42)
        Me.txtrangeSuspensionTravel.Name = "txtrangeSuspensionTravel"
        Me.txtrangeSuspensionTravel.Size = New System.Drawing.Size(30, 20)
        Me.txtrangeSuspensionTravel.TabIndex = 16
        Me.txtrangeSuspensionTravel.Text = "140"
        '
        'lbrangeSuspensionTravel
        '
        Me.lbrangeSuspensionTravel.AutoSize = True
        Me.lbrangeSuspensionTravel.BackColor = System.Drawing.Color.Transparent
        Me.lbrangeSuspensionTravel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbrangeSuspensionTravel.ForeColor = System.Drawing.Color.White
        Me.lbrangeSuspensionTravel.Location = New System.Drawing.Point(74, 46)
        Me.lbrangeSuspensionTravel.Name = "lbrangeSuspensionTravel"
        Me.lbrangeSuspensionTravel.Size = New System.Drawing.Size(81, 12)
        Me.lbrangeSuspensionTravel.TabIndex = 17
        Me.lbrangeSuspensionTravel.Text = "Range:               mm"
        '
        'txtrangeWheelLoad
        '
        Me.txtrangeWheelLoad.Location = New System.Drawing.Point(105, 63)
        Me.txtrangeWheelLoad.Name = "txtrangeWheelLoad"
        Me.txtrangeWheelLoad.Size = New System.Drawing.Size(30, 20)
        Me.txtrangeWheelLoad.TabIndex = 18
        Me.txtrangeWheelLoad.Text = "400"
        '
        'lbrangeWheelLoad
        '
        Me.lbrangeWheelLoad.AutoSize = True
        Me.lbrangeWheelLoad.BackColor = System.Drawing.Color.Transparent
        Me.lbrangeWheelLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbrangeWheelLoad.ForeColor = System.Drawing.Color.White
        Me.lbrangeWheelLoad.Location = New System.Drawing.Point(74, 67)
        Me.lbrangeWheelLoad.Name = "lbrangeWheelLoad"
        Me.lbrangeWheelLoad.Size = New System.Drawing.Size(76, 12)
        Me.lbrangeWheelLoad.TabIndex = 19
        Me.lbrangeWheelLoad.Text = "Range:               Kg"
        '
        'cbWheel
        '
        Me.cbWheel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbWheel.FormattingEnabled = True
        Me.cbWheel.Items.AddRange(New Object() {"0 - Front Left", "1 - Front Right", "2 - Rear Left", "3 - Rear Right"})
        Me.cbWheel.Location = New System.Drawing.Point(2, 87)
        Me.cbWheel.Name = "cbWheel"
        Me.cbWheel.Size = New System.Drawing.Size(133, 21)
        Me.cbWheel.TabIndex = 20
        '
        'txtUp
        '
        Me.txtUp.Location = New System.Drawing.Point(187, 42)
        Me.txtUp.Name = "txtUp"
        Me.txtUp.Size = New System.Drawing.Size(24, 20)
        Me.txtUp.TabIndex = 21
        Me.txtUp.Text = "35"
        '
        'txtDn
        '
        Me.txtDn.Location = New System.Drawing.Point(217, 42)
        Me.txtDn.Name = "txtDn"
        Me.txtDn.Size = New System.Drawing.Size(24, 20)
        Me.txtDn.TabIndex = 22
        Me.txtDn.Text = "80"
        '
        'txtCenter
        '
        Me.txtCenter.Location = New System.Drawing.Point(157, 42)
        Me.txtCenter.Name = "txtCenter"
        Me.txtCenter.Size = New System.Drawing.Size(24, 20)
        Me.txtCenter.TabIndex = 23
        Me.txtCenter.Text = "83"
        '
        'ucACGraph
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.txtCenter)
        Me.Controls.Add(Me.txtDn)
        Me.Controls.Add(Me.txtUp)
        Me.Controls.Add(Me.cbWheel)
        Me.Controls.Add(Me.txtrangeWheelLoad)
        Me.Controls.Add(Me.lbrangeWheelLoad)
        Me.Controls.Add(Me.txtrangeSuspensionTravel)
        Me.Controls.Add(Me.lbrangeSuspensionTravel)
        Me.Controls.Add(Me.txtrangeRideHeight)
        Me.Controls.Add(Me.lbrangeRideHeight)
        Me.Controls.Add(Me.txtrangeCgHeight)
        Me.Controls.Add(Me.chkWheelLoad)
        Me.Controls.Add(Me.chkRideHeight)
        Me.Controls.Add(Me.chkSusTravel)
        Me.Controls.Add(Me.chkCgHeight)
        Me.Controls.Add(Me.chkPause)
        Me.Controls.Add(Me.btReset)
        Me.Controls.Add(Me.lbrangeCgHeight)
        Me.Name = "ucACGraph"
        Me.Size = New System.Drawing.Size(736, 255)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btReset As Button
    Friend WithEvents chkPause As CheckBox
    Friend WithEvents chkCgHeight As CheckBox
    Friend WithEvents chkSusTravel As CheckBox
    Friend WithEvents chkRideHeight As CheckBox
    Friend WithEvents chkWheelLoad As CheckBox
    Friend WithEvents txtrangeCgHeight As TextBox
    Friend WithEvents lbrangeCgHeight As Label
    Friend WithEvents txtrangeRideHeight As TextBox
    Friend WithEvents lbrangeRideHeight As Label
    Friend WithEvents txtrangeSuspensionTravel As TextBox
    Friend WithEvents lbrangeSuspensionTravel As Label
    Friend WithEvents txtrangeWheelLoad As TextBox
    Friend WithEvents lbrangeWheelLoad As Label
    Friend WithEvents cbWheel As ComboBox
    Friend WithEvents txtUp As TextBox
    Friend WithEvents txtDn As TextBox
    Friend WithEvents txtCenter As TextBox
End Class
