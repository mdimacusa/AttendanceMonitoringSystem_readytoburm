<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EventMaintenance
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EventMaintenance))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEventName = New System.Windows.Forms.TextBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFromDate = New System.Windows.Forms.DateTimePicker()
        Me.txtToDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSubEventName = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtSubDepartment = New System.Windows.Forms.TextBox()
        Me.txtDepart1 = New System.Windows.Forms.TextBox()
        Me.txtEvent1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbDepartment = New System.Windows.Forms.ComboBox()
        Me.btnSAVE = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbYearlevel = New System.Windows.Forms.ComboBox()
        Me.txtSubYearlevel = New System.Windows.Forms.TextBox()
        Me.txtYlevel1 = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(45, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 20)
        Me.Label2.TabIndex = 424
        Me.Label2.Text = "Event Name:"
        '
        'txtEventName
        '
        Me.txtEventName.Location = New System.Drawing.Point(138, 56)
        Me.txtEventName.Multiline = True
        Me.txtEventName.Name = "txtEventName"
        Me.txtEventName.ShortcutsEnabled = False
        Me.txtEventName.Size = New System.Drawing.Size(287, 64)
        Me.txtEventName.TabIndex = 423
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(12, 31)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(34, 20)
        Me.txtID.TabIndex = 427
        Me.txtID.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Highlight
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(459, 25)
        Me.Panel1.TabIndex = 426
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 20)
        Me.Label4.TabIndex = 433
        Me.Label4.Text = "Event Maintenance"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.Highlight
        Me.Button3.BackgroundImage = CType(resources.GetObject("Button3.BackgroundImage"), System.Drawing.Image)
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Black
        Me.Button3.Location = New System.Drawing.Point(421, 1)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(23, 22)
        Me.Button3.TabIndex = 415
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(55, 203)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 20)
        Me.Label1.TabIndex = 429
        Me.Label1.Text = "From Date:"
        '
        'txtFromDate
        '
        Me.txtFromDate.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFromDate.Location = New System.Drawing.Point(138, 202)
        Me.txtFromDate.Name = "txtFromDate"
        Me.txtFromDate.Size = New System.Drawing.Size(287, 26)
        Me.txtFromDate.TabIndex = 430
        Me.txtFromDate.Value = New Date(2020, 11, 7, 0, 0, 0, 0)
        '
        'txtToDate
        '
        Me.txtToDate.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtToDate.Location = New System.Drawing.Point(138, 234)
        Me.txtToDate.Name = "txtToDate"
        Me.txtToDate.Size = New System.Drawing.Size(287, 26)
        Me.txtToDate.TabIndex = 431
        Me.txtToDate.Value = New Date(2020, 11, 7, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(72, 234)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 20)
        Me.Label3.TabIndex = 432
        Me.Label3.Text = "To Date:"
        '
        'txtSubEventName
        '
        Me.txtSubEventName.Location = New System.Drawing.Point(52, 31)
        Me.txtSubEventName.Name = "txtSubEventName"
        Me.txtSubEventName.Size = New System.Drawing.Size(113, 20)
        Me.txtSubEventName.TabIndex = 434
        Me.txtSubEventName.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.txtYlevel1)
        Me.Panel2.Controls.Add(Me.txtSubYearlevel)
        Me.Panel2.Controls.Add(Me.cbDepartment)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.cbYearlevel)
        Me.Panel2.Controls.Add(Me.txtSubDepartment)
        Me.Panel2.Controls.Add(Me.txtDepart1)
        Me.Panel2.Controls.Add(Me.txtEvent1)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.btnSAVE)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.txtEventName)
        Me.Panel2.Controls.Add(Me.btnUpdate)
        Me.Panel2.Controls.Add(Me.txtToDate)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.txtFromDate)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(459, 341)
        Me.Panel2.TabIndex = 435
        '
        'txtSubDepartment
        '
        Me.txtSubDepartment.Location = New System.Drawing.Point(170, 30)
        Me.txtSubDepartment.Name = "txtSubDepartment"
        Me.txtSubDepartment.Size = New System.Drawing.Size(113, 20)
        Me.txtSubDepartment.TabIndex = 436
        Me.txtSubDepartment.Visible = False
        '
        'txtDepart1
        '
        Me.txtDepart1.Location = New System.Drawing.Point(312, 293)
        Me.txtDepart1.Name = "txtDepart1"
        Me.txtDepart1.Size = New System.Drawing.Size(34, 20)
        Me.txtDepart1.TabIndex = 468
        Me.txtDepart1.Visible = False
        '
        'txtEvent1
        '
        Me.txtEvent1.Location = New System.Drawing.Point(272, 293)
        Me.txtEvent1.Name = "txtEvent1"
        Me.txtEvent1.Size = New System.Drawing.Size(34, 20)
        Me.txtEvent1.TabIndex = 436
        Me.txtEvent1.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(36, 132)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 19)
        Me.Label8.TabIndex = 467
        Me.Label8.Text = "Department:"
        '
        'cbDepartment
        '
        Me.cbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDepartment.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDepartment.FormattingEnabled = True
        Me.cbDepartment.Location = New System.Drawing.Point(138, 126)
        Me.cbDepartment.Name = "cbDepartment"
        Me.cbDepartment.Size = New System.Drawing.Size(287, 31)
        Me.cbDepartment.TabIndex = 466
        '
        'btnSAVE
        '
        Me.btnSAVE.BackColor = System.Drawing.Color.White
        Me.btnSAVE.BackgroundImage = CType(resources.GetObject("btnSAVE.BackgroundImage"), System.Drawing.Image)
        Me.btnSAVE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSAVE.FlatAppearance.BorderSize = 0
        Me.btnSAVE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSAVE.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSAVE.ForeColor = System.Drawing.Color.White
        Me.btnSAVE.Location = New System.Drawing.Point(138, 276)
        Me.btnSAVE.Name = "btnSAVE"
        Me.btnSAVE.Size = New System.Drawing.Size(89, 51)
        Me.btnSAVE.TabIndex = 462
        Me.btnSAVE.UseVisualStyleBackColor = False
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.White
        Me.btnUpdate.BackgroundImage = CType(resources.GetObject("btnUpdate.BackgroundImage"), System.Drawing.Image)
        Me.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUpdate.FlatAppearance.BorderSize = 0
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Location = New System.Drawing.Point(138, 276)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(89, 51)
        Me.btnUpdate.TabIndex = 461
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(431, 234)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(15, 18)
        Me.Label6.TabIndex = 455
        Me.Label6.Text = "*"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(431, 205)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 18)
        Me.Label5.TabIndex = 454
        Me.Label5.Text = "*"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(431, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 18)
        Me.Label7.TabIndex = 453
        Me.Label7.Text = "*"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(55, 169)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 19)
        Me.Label9.TabIndex = 470
        Me.Label9.Text = "Yearlevel:"
        '
        'cbYearlevel
        '
        Me.cbYearlevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbYearlevel.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbYearlevel.FormattingEnabled = True
        Me.cbYearlevel.Location = New System.Drawing.Point(138, 163)
        Me.cbYearlevel.Name = "cbYearlevel"
        Me.cbYearlevel.Size = New System.Drawing.Size(287, 31)
        Me.cbYearlevel.TabIndex = 469
        '
        'txtSubYearlevel
        '
        Me.txtSubYearlevel.Location = New System.Drawing.Point(289, 30)
        Me.txtSubYearlevel.Name = "txtSubYearlevel"
        Me.txtSubYearlevel.Size = New System.Drawing.Size(113, 20)
        Me.txtSubYearlevel.TabIndex = 471
        Me.txtSubYearlevel.Visible = False
        '
        'txtYlevel1
        '
        Me.txtYlevel1.Location = New System.Drawing.Point(352, 293)
        Me.txtYlevel1.Name = "txtYlevel1"
        Me.txtYlevel1.Size = New System.Drawing.Size(34, 20)
        Me.txtYlevel1.TabIndex = 472
        Me.txtYlevel1.Visible = False
        '
        'EventMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(459, 342)
        Me.Controls.Add(Me.txtSubEventName)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "EventMaintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EventMaintenance"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEventName As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSubEventName As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnSAVE As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents txtDepart1 As System.Windows.Forms.TextBox
    Friend WithEvents txtEvent1 As System.Windows.Forms.TextBox
    Friend WithEvents txtSubDepartment As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbYearlevel As System.Windows.Forms.ComboBox
    Friend WithEvents txtSubYearlevel As System.Windows.Forms.TextBox
    Friend WithEvents txtYlevel1 As System.Windows.Forms.TextBox
End Class
