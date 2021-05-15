<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EventList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EventList))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtdate1 = New System.Windows.Forms.TextBox()
        Me.txtdate2 = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnEventHistory = New System.Windows.Forms.Button()
        Me.tbnDELETE = New System.Windows.Forms.Button()
        Me.tbnEDIT = New System.Windows.Forms.Button()
        Me.btnADD = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Highlight
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(-1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(586, 25)
        Me.Panel1.TabIndex = 424
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
        Me.Button4.Location = New System.Drawing.Point(549, 1)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(23, 22)
        Me.Button4.TabIndex = 436
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 19)
        Me.Label3.TabIndex = 427
        Me.Label3.Text = "Event list"
        '
        'txtdate1
        '
        Me.txtdate1.Location = New System.Drawing.Point(26, 30)
        Me.txtdate1.Name = "txtdate1"
        Me.txtdate1.Size = New System.Drawing.Size(61, 20)
        Me.txtdate1.TabIndex = 425
        Me.txtdate1.Visible = False
        '
        'txtdate2
        '
        Me.txtdate2.Location = New System.Drawing.Point(93, 30)
        Me.txtdate2.Name = "txtdate2"
        Me.txtdate2.Size = New System.Drawing.Size(62, 20)
        Me.txtdate2.TabIndex = 426
        Me.txtdate2.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.ListView1)
        Me.Panel2.Location = New System.Drawing.Point(30, 86)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(524, 295)
        Me.Panel2.TabIndex = 435
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.White
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.ListView1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView1.Location = New System.Drawing.Point(3, 3)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(516, 287)
        Me.ListView1.TabIndex = 436
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Event Name"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader2.Width = 540
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "From Date"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader3.Width = 300
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "To Date"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader4.Width = 300
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Department"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader5.Width = 300
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Yearlevel"
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader6.Width = 250
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.btnEventHistory)
        Me.Panel3.Controls.Add(Me.txtdate2)
        Me.Panel3.Controls.Add(Me.txtdate1)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(582, 469)
        Me.Panel3.TabIndex = 437
        '
        'btnEventHistory
        '
        Me.btnEventHistory.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEventHistory.Location = New System.Drawing.Point(395, 47)
        Me.btnEventHistory.Name = "btnEventHistory"
        Me.btnEventHistory.Size = New System.Drawing.Size(158, 32)
        Me.btnEventHistory.TabIndex = 437
        Me.btnEventHistory.Text = "Event History"
        Me.btnEventHistory.UseVisualStyleBackColor = True
        '
        'tbnDELETE
        '
        Me.tbnDELETE.BackColor = System.Drawing.Color.White
        Me.tbnDELETE.BackgroundImage = CType(resources.GetObject("tbnDELETE.BackgroundImage"), System.Drawing.Image)
        Me.tbnDELETE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbnDELETE.FlatAppearance.BorderSize = 0
        Me.tbnDELETE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.tbnDELETE.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbnDELETE.ForeColor = System.Drawing.Color.White
        Me.tbnDELETE.Location = New System.Drawing.Point(465, 398)
        Me.tbnDELETE.Name = "tbnDELETE"
        Me.tbnDELETE.Size = New System.Drawing.Size(89, 51)
        Me.tbnDELETE.TabIndex = 438
        Me.tbnDELETE.UseVisualStyleBackColor = False
        '
        'tbnEDIT
        '
        Me.tbnEDIT.BackColor = System.Drawing.Color.White
        Me.tbnEDIT.BackgroundImage = CType(resources.GetObject("tbnEDIT.BackgroundImage"), System.Drawing.Image)
        Me.tbnEDIT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbnEDIT.FlatAppearance.BorderSize = 0
        Me.tbnEDIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.tbnEDIT.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbnEDIT.ForeColor = System.Drawing.Color.White
        Me.tbnEDIT.Location = New System.Drawing.Point(371, 399)
        Me.tbnEDIT.Name = "tbnEDIT"
        Me.tbnEDIT.Size = New System.Drawing.Size(89, 51)
        Me.tbnEDIT.TabIndex = 437
        Me.tbnEDIT.UseVisualStyleBackColor = False
        '
        'btnADD
        '
        Me.btnADD.BackColor = System.Drawing.Color.White
        Me.btnADD.BackgroundImage = CType(resources.GetObject("btnADD.BackgroundImage"), System.Drawing.Image)
        Me.btnADD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnADD.FlatAppearance.BorderSize = 0
        Me.btnADD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnADD.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnADD.ForeColor = System.Drawing.Color.White
        Me.btnADD.Location = New System.Drawing.Point(276, 399)
        Me.btnADD.Name = "btnADD"
        Me.btnADD.Size = New System.Drawing.Size(89, 51)
        Me.btnADD.TabIndex = 436
        Me.btnADD.UseVisualStyleBackColor = False
        '
        'EventList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(582, 469)
        Me.Controls.Add(Me.tbnDELETE)
        Me.Controls.Add(Me.tbnEDIT)
        Me.Controls.Add(Me.btnADD)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "EventList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EventList"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtdate1 As System.Windows.Forms.TextBox
    Friend WithEvents txtdate2 As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents tbnDELETE As System.Windows.Forms.Button
    Friend WithEvents tbnEDIT As System.Windows.Forms.Button
    Friend WithEvents btnADD As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnEventHistory As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
End Class
