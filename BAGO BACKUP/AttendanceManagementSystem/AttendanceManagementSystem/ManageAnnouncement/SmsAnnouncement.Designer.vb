<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SmsAnnouncement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SmsAnnouncement))
        Me.cbYearlevel = New System.Windows.Forms.ComboBox()
        Me.lboxPhoneNumber = New System.Windows.Forms.ListBox()
        Me.bttnSend = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cbDepartment = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.rbtnNO = New System.Windows.Forms.RadioButton()
        Me.rbtnYES = New System.Windows.Forms.RadioButton()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbCourse = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblUserID = New System.Windows.Forms.Label()
        Me.lblProcessedBy = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbTitle = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbAnnouncement = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbYearlevel
        '
        Me.cbYearlevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbYearlevel.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbYearlevel.FormattingEnabled = True
        Me.cbYearlevel.Location = New System.Drawing.Point(214, 234)
        Me.cbYearlevel.Name = "cbYearlevel"
        Me.cbYearlevel.Size = New System.Drawing.Size(471, 31)
        Me.cbYearlevel.TabIndex = 429
        '
        'lboxPhoneNumber
        '
        Me.lboxPhoneNumber.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lboxPhoneNumber.FormattingEnabled = True
        Me.lboxPhoneNumber.ItemHeight = 18
        Me.lboxPhoneNumber.Location = New System.Drawing.Point(214, 358)
        Me.lboxPhoneNumber.Name = "lboxPhoneNumber"
        Me.lboxPhoneNumber.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lboxPhoneNumber.Size = New System.Drawing.Size(471, 184)
        Me.lboxPhoneNumber.TabIndex = 430
        '
        'bttnSend
        '
        Me.bttnSend.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnSend.Location = New System.Drawing.Point(266, 566)
        Me.bttnSend.Name = "bttnSend"
        Me.bttnSend.Size = New System.Drawing.Size(150, 54)
        Me.bttnSend.TabIndex = 431
        Me.bttnSend.Text = "Send Message"
        Me.bttnSend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.bttnSend.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(181, 19)
        Me.Label2.TabIndex = 432
        Me.Label2.Text = "Announcement Message:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(130, 240)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 19)
        Me.Label1.TabIndex = 433
        Me.Label1.Text = "Year level:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Highlight
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Location = New System.Drawing.Point(-1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(768, 25)
        Me.Panel1.TabIndex = 434
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(149, 19)
        Me.Label3.TabIndex = 439
        Me.Label3.Text = "SMS Announcement"
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Highlight
        Me.Button4.BackgroundImage = CType(resources.GetObject("Button4.BackgroundImage"), System.Drawing.Image)
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Black
        Me.Button4.Location = New System.Drawing.Point(732, 0)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(23, 22)
        Me.Button4.TabIndex = 415
        Me.Button4.UseVisualStyleBackColor = False
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.LightBlue
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.ListView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(28, 554)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(46, 64)
        Me.ListView1.TabIndex = 438
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        Me.ListView1.Visible = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Mobile No"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader2.Width = 300
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(35, 641)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 440
        Me.Label4.Text = "Label4"
        Me.Label4.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(35, 671)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 441
        Me.Label5.Text = "Label5"
        Me.Label5.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.cbDepartment)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.rbtnNO)
        Me.Panel2.Controls.Add(Me.rbtnYES)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.cbCourse)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.btnReset)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.lblUserID)
        Me.Panel2.Controls.Add(Me.lblProcessedBy)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.cbYearlevel)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.cbTitle)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.cbAnnouncement)
        Me.Panel2.Controls.Add(Me.lboxPhoneNumber)
        Me.Panel2.Controls.Add(Me.bttnSend)
        Me.Panel2.Controls.Add(Me.ListView1)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(766, 722)
        Me.Panel2.TabIndex = 442
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(35, 697)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(45, 13)
        Me.Label16.TabIndex = 465
        Me.Label16.Text = "Label16"
        Me.Label16.Visible = False
        '
        'cbDepartment
        '
        Me.cbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDepartment.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDepartment.FormattingEnabled = True
        Me.cbDepartment.Location = New System.Drawing.Point(214, 192)
        Me.cbDepartment.Name = "cbDepartment"
        Me.cbDepartment.Size = New System.Drawing.Size(471, 31)
        Me.cbDepartment.TabIndex = 463
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(109, 198)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(96, 19)
        Me.Label12.TabIndex = 464
        Me.Label12.Text = "Department:"
        '
        'rbtnNO
        '
        Me.rbtnNO.AutoSize = True
        Me.rbtnNO.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnNO.Location = New System.Drawing.Point(264, 324)
        Me.rbtnNO.Name = "rbtnNO"
        Me.rbtnNO.Size = New System.Drawing.Size(43, 19)
        Me.rbtnNO.TabIndex = 462
        Me.rbtnNO.TabStop = True
        Me.rbtnNO.Text = "NO"
        Me.rbtnNO.UseVisualStyleBackColor = True
        '
        'rbtnYES
        '
        Me.rbtnYES.AutoSize = True
        Me.rbtnYES.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnYES.Location = New System.Drawing.Point(214, 324)
        Me.rbtnYES.Name = "rbtnYES"
        Me.rbtnYES.Size = New System.Drawing.Size(44, 19)
        Me.rbtnYES.TabIndex = 461
        Me.rbtnYES.TabStop = True
        Me.rbtnYES.Text = "YES"
        Me.rbtnYES.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(62, 321)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(143, 19)
        Me.Label15.TabIndex = 458
        Me.Label15.Text = "Send to all student:"
        '
        'cbCourse
        '
        Me.cbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCourse.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCourse.FormattingEnabled = True
        Me.cbCourse.Location = New System.Drawing.Point(214, 275)
        Me.cbCourse.Name = "cbCourse"
        Me.cbCourse.Size = New System.Drawing.Size(471, 31)
        Me.cbCourse.TabIndex = 456
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(147, 281)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 19)
        Me.Label9.TabIndex = 457
        Me.Label9.Text = "Course:"
        '
        'btnReset
        '
        Me.btnReset.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Location = New System.Drawing.Point(422, 566)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(150, 54)
        Me.btnReset.TabIndex = 455
        Me.btnReset.Text = "Reset"
        Me.btnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Red
        Me.Label14.Location = New System.Drawing.Point(691, 358)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(15, 18)
        Me.Label14.TabIndex = 454
        Me.Label14.Text = "*"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(691, 131)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(15, 18)
        Me.Label13.TabIndex = 453
        Me.Label13.Text = "*"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(691, 44)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(15, 18)
        Me.Label11.TabIndex = 451
        Me.Label11.Text = "*"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(359, 693)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 19)
        Me.Label10.TabIndex = 450
        Me.Label10.Text = "UserID:"
        Me.Label10.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(311, 646)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 19)
        Me.Label8.TabIndex = 449
        Me.Label8.Text = "ProccessedBy:"
        '
        'lblUserID
        '
        Me.lblUserID.AutoSize = True
        Me.lblUserID.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserID.Location = New System.Drawing.Point(418, 693)
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(53, 19)
        Me.lblUserID.TabIndex = 448
        Me.lblUserID.Text = "UserID"
        Me.lblUserID.Visible = False
        '
        'lblProcessedBy
        '
        Me.lblProcessedBy.AutoSize = True
        Me.lblProcessedBy.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessedBy.Location = New System.Drawing.Point(418, 646)
        Me.lblProcessedBy.Name = "lblProcessedBy"
        Me.lblProcessedBy.Size = New System.Drawing.Size(101, 19)
        Me.lblProcessedBy.TabIndex = 447
        Me.lblProcessedBy.Text = "ProccessedBy"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(45, 358)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(162, 19)
        Me.Label7.TabIndex = 444
        Me.Label7.Text = "Guardian's Mobile No:"
        '
        'cbTitle
        '
        Me.cbTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTitle.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTitle.FormattingEnabled = True
        Me.cbTitle.Location = New System.Drawing.Point(214, 44)
        Me.cbTitle.Name = "cbTitle"
        Me.cbTitle.Size = New System.Drawing.Size(471, 31)
        Me.cbTitle.TabIndex = 443
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(163, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 19)
        Me.Label6.TabIndex = 443
        Me.Label6.Text = "Title:"
        '
        'cbAnnouncement
        '
        Me.cbAnnouncement.Location = New System.Drawing.Point(214, 87)
        Me.cbAnnouncement.Multiline = True
        Me.cbAnnouncement.Name = "cbAnnouncement"
        Me.cbAnnouncement.ReadOnly = True
        Me.cbAnnouncement.ShortcutsEnabled = False
        Me.cbAnnouncement.Size = New System.Drawing.Size(471, 94)
        Me.cbAnnouncement.TabIndex = 1
        '
        'SmsAnnouncement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(766, 722)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SmsAnnouncement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SmsAnnouncement"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cbYearlevel As System.Windows.Forms.ComboBox
    Private WithEvents lboxPhoneNumber As System.Windows.Forms.ListBox
    Private WithEvents bttnSend As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cbAnnouncement As System.Windows.Forms.TextBox
    Friend WithEvents cbTitle As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblProcessedBy As System.Windows.Forms.Label
    Friend WithEvents lblUserID As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Private WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents cbCourse As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents rbtnNO As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnYES As System.Windows.Forms.RadioButton
    Friend WithEvents cbDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
