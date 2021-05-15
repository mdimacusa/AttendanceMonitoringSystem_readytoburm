Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions
Public Class MainForm

    Private Sub btnStudentMasterList_Click(sender As Object, e As EventArgs) Handles btnStudentMasterList.Click
        panelDashboard.Visible = False
        StudentMasterList.ShowDialog()

        '   PanelStudentMasterList.BringToFront()
        ' list()
    End Sub

    Private Sub btnCourseList_Click(sender As Object, e As EventArgs) Handles btnCourseList.Click
        panelDashboard.Visible = False
        CourseList.ShowDialog()


    End Sub

    Private Sub btnAttendanceRecord_Click(sender As Object, e As EventArgs) Handles btnAttendanceRecord.Click
        panelDashboard.Visible = False
        AttendanceRecord.ShowDialog()
        ' PanelAttendanceRecord.BringToFront()

    End Sub
    Sub autoID()
        connect()
        Try

            Dim i As Double
            Dim sql As String
            sql = "Select Max(LogId) from tblLogHistory"
            Dim com As New SqlClient.SqlCommand(sql, con)
            If IsDBNull(com.ExecuteScalar) Then
                i = "100000000"
                Label1.Text = i.ToString
            Else
                i = com.ExecuteScalar + 1
                Label1.Text = i.ToString
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        Timer1.Interval = 1000
        totalStudent()
        totalAnnouncement()
        totalAttendance()
        autoID()
        'totalEvent()
        ' btnDashBoard.Focus()
        If txtUserlevel.Text = "Staff" Then
            Button2.Enabled = False
            Button3.Enabled = False
            AuditTrailToolStripMenuItem.Enabled = False
            'CourseList.btnADD.Visible = False
            'CourseList.btnEDIT.Visible = False
            'CourseList.btnDELETE.Visible = False
            'CourseList.btnADD.Visible = False
            'YearLevel.btnADD.Visible = False
            'YearLevel.tbnEDIT.Visible = False
            'YearLevel.tbnDELETE.Visible = False
            'EventList.btnADD.Visible = False
            'EventList.tbnEDIT.Visible = False
            'EventList.tbnDELETE.Visible = False
            'ManageAnnouncement.Button1.Visible = False
            'ManageAnnouncement.Button2.Visible = False
            'ManageAnnouncement.Button3.Visible = False
        Else
            Button2.Enabled = True
            Button3.Enabled = True
            AuditTrailToolStripMenuItem.Enabled = True
            'CourseList.btnADD.Visible = True
            'CourseList.btnEDIT.Visible = True
            'CourseList.btnDELETE.Visible = True
            'YearLevel.btnADD.Visible = True
            'YearLevel.tbnEDIT.Visible = True
            'YearLevel.tbnDELETE.Visible = True
            'EventList.btnADD.Visible = True
            'EventList.tbnEDIT.Visible = True
            'EventList.tbnDELETE.Visible = True
            'ManageAnnouncement.Button1.Visible = True
            'ManageAnnouncement.Button2.Visible = True
            'ManageAnnouncement.Button3.Visible = True
        End If
    End Sub
  
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        DateTime.Text = Format(Now, "dddd, MMMM d, yyyy " + vbNewLine + "hh:mm:ss tt")
    End Sub

    Private Sub btnAnnouncement_Click(sender As Object, e As EventArgs) Handles btnAnnouncement.Click
        panelDashboard.Visible = False
        ManageAnnouncement.ShowDialog()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Public Sub totalStudent()

        con.Close()
        con.Open()

        Dim cmd As New SqlCommand("SELECT Sum(NoStudent) from tblStudentMasterList", con)

        Dim adpt As New SqlDataAdapter(cmd)
        Dim dt4 As New DataTable

        adpt.Fill(dt4)

        lblNoStudent.Text = dt4.Rows(0)(0).ToString()
        con.Close()

    End Sub
    Public Sub totalAttendance()

        con.Close()
        con.Open()

        Dim cmd As New SqlCommand("SELECT Sum(NoStudent) from tblAttendance", con)

        Dim adpt As New SqlDataAdapter(cmd)
        Dim dt4 As New DataTable

        adpt.Fill(dt4)

        lblAttendance.Text = dt4.Rows(0)(0).ToString()
        con.Close()

    End Sub
    Public Sub totalAnnouncement()

        con.Close()
        con.Open()

        Dim cmd As New SqlCommand("SELECT Sum(NoAnnouncement) from tblAnnouncement", con)

        Dim adpt As New SqlDataAdapter(cmd)
        Dim dt4 As New DataTable

        adpt.Fill(dt4)

        lblNoAnnouncement.Text = dt4.Rows(0)(0).ToString()
        con.Close()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        panelDashboard.Visible = False
        YearLevel.ShowDialog()
    End Sub



    Private Sub btnDashBoard_Click(sender As Object, e As EventArgs) Handles btnDashBoard.Click
        panelDashboard.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim dialog As DialogResult
            dialog = MessageBox.Show("Are you sure, you want to open UserAccount?", "", MessageBoxButtons.YesNo)
            If dialog = DialogResult.No Then
                Beep()
                MsgBox("Cancel!")
            Else
               
                panelDashboard.Visible = False
                UserAccount.ShowDialog()
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try

      
    End Sub
    Private Sub btnLoginLogout_Click(sender As Object, e As EventArgs) Handles btnLoginLogout.Click
        If MsgBox("Are you sure you want to log out?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                connect()
                con.Close()
                con.Open()
                cmd.Connection = con
                cmd.CommandText = "INSERT INTO tblLogHistory (LogId,Username,Usertype,Datein,Dateout,UserID) VALUES (@Lid,@User,@Utype,@Date,@Date1,@UID)"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@User", str_user)
                cmd.Parameters.AddWithValue("@Lid", Label1.Text)
                cmd.Parameters.AddWithValue("@Utype", txtUserLevel.Text)
                cmd.Parameters.AddWithValue("@Date", txtdatein.Text)
                cmd.Parameters.AddWithValue("@Date1", Date.Now)
                cmd.Parameters.AddWithValue("@UID", lblUserID.Text)
                Dim a As Integer = cmd.ExecuteNonQuery()
                If a > 0 Then
                    msginfo("Goodbye " + txtUserlevel.Text)
                    Me.Dispose()
                    Login.Show()
                    Login.txtUsername.Text = ""
                    Login.txtPassword.Text = ""
                    Login.txtUsername.Focus()
                Else
                    MsgBox("Failed")
                End If
                con.Close()
            Catch ex As Exception
                msgerror(Err.Description)
            End Try
        End If
    End Sub

    Private Sub txtID_TextChanged(sender As Object, e As EventArgs) Handles txtID.TextChanged
        Try

        If txtID.Text <> "" Then
            Dim cmd As New SqlCommand("Select * from tblAdmin where Id = '" & txtID.Text & "'", con)
            Dim table As New DataTable
            Dim adpt As New SqlDataAdapter(cmd)

            adpt.Fill(table)
            Dim img() As Byte
            img = table.Rows(0)(14)
            Dim ms As New MemoryStream(img)
            PictureBox2.Image = Image.FromStream(ms)

            'ElseIf txtID.Text = "" Then
            '    PictureBox2.Image = Nothing
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim dialog As DialogResult
            dialog = MessageBox.Show("Are you sure, you want to open SecurityQuestion?", "", MessageBoxButtons.YesNo)
            If dialog = DialogResult.No Then
                Beep()
                MsgBox("Cancel!")
            Else

                panelDashboard.Visible = False
                SecurityQuestion.ShowDialog()
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try

      
    End Sub
    Private Sub LinkLabel4_Click(sender As Object, e As EventArgs) Handles LinkLabel4.Click
        'panelDashboard.Visible = False
        ManageAnnouncement.ShowDialog()
    End Sub

    Private Sub LinkLabel2_Click(sender As Object, e As EventArgs) Handles LinkLabel2.Click
        '  panelDashboard.Visible = False
        AttendanceRecord.ShowDialog()
    End Sub


    Private Sub LinkLabel1_Click(sender As Object, e As EventArgs) Handles LinkLabel1.Click
        ' panelDashboard.Visible = False
        StudentMasterList.ShowDialog()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        panelDashboard.Visible = False
        EventList.ShowDialog()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        EventRecord.ShowDialog()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        ContextMenuStrip1.Show(583, 58)
    End Sub

    Private Sub SystemPasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SystemPasswordToolStripMenuItem.Click
        panelDashboard.Visible = False
        SystemPassword.ShowDialog()
    End Sub

    Private Sub LogHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogHistoryToolStripMenuItem.Click
        panelDashboard.Visible = False
        LogHistory.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        panelDashboard.Visible = False
        DepartmentList.ShowDialog()
    End Sub

    Private Sub AuditTrailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AuditTrailToolStripMenuItem.Click
        panelDashboard.Visible = False
        AuditTrailHistory.ShowDialog()
    End Sub
End Class