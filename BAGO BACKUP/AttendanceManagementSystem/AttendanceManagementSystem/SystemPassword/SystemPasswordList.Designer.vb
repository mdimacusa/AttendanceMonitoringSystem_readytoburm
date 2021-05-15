<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SystemPasswordList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SystemPasswordList))
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.txtCount = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tbnDELETE = New System.Windows.Forms.Button()
        Me.tbnEDIT = New System.Windows.Forms.Button()
        Me.btnADD = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 0
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.White
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.ListView1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView1.Location = New System.Drawing.Point(3, 3)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(493, 287)
        Me.ListView1.TabIndex = 420
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "System Password"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader2.Width = 500
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Highlight
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Location = New System.Drawing.Point(-7, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(563, 25)
        Me.Panel1.TabIndex = 424
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(154, 19)
        Me.Label3.TabIndex = 431
        Me.Label3.Text = "System Password List"
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
        Me.Button4.Location = New System.Drawing.Point(528, 0)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(23, 22)
        Me.Button4.TabIndex = 415
        Me.Button4.UseVisualStyleBackColor = False
        '
        'txtCount
        '
        Me.txtCount.Location = New System.Drawing.Point(459, 31)
        Me.txtCount.Name = "txtCount"
        Me.txtCount.Size = New System.Drawing.Size(66, 20)
        Me.txtCount.TabIndex = 425
        Me.txtCount.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.ListView1)
        Me.Panel2.Location = New System.Drawing.Point(29, 72)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(501, 295)
        Me.Panel2.TabIndex = 426
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
        Me.tbnDELETE.Location = New System.Drawing.Point(437, 373)
        Me.tbnDELETE.Name = "tbnDELETE"
        Me.tbnDELETE.Size = New System.Drawing.Size(89, 51)
        Me.tbnDELETE.TabIndex = 423
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
        Me.tbnEDIT.Location = New System.Drawing.Point(344, 374)
        Me.tbnEDIT.Name = "tbnEDIT"
        Me.tbnEDIT.Size = New System.Drawing.Size(89, 51)
        Me.tbnEDIT.TabIndex = 422
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
        Me.btnADD.Location = New System.Drawing.Point(248, 374)
        Me.btnADD.Name = "btnADD"
        Me.btnADD.Size = New System.Drawing.Size(89, 51)
        Me.btnADD.TabIndex = 421
        Me.btnADD.UseVisualStyleBackColor = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(556, 439)
        Me.FlowLayoutPanel1.TabIndex = 427
        '
        'SystemPasswordList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(556, 439)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.txtCount)
        Me.Controls.Add(Me.tbnDELETE)
        Me.Controls.Add(Me.tbnEDIT)
        Me.Controls.Add(Me.btnADD)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SystemPasswordList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SystemPasswordList"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents tbnDELETE As System.Windows.Forms.Button
    Friend WithEvents tbnEDIT As System.Windows.Forms.Button
    Friend WithEvents btnADD As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCount As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
End Class
