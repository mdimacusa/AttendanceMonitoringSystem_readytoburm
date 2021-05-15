Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions
Public Class StudentEntry
    Public Gender As String
    Public Department As String
    Public Yearlevel As String
    Public Kurso As String
    Public ContactNo As String
    Public StudentID As String

    Private Sub StudentEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadCourse()
        loadDepartment()


        BWESIT()

        cbDepartment.SelectedIndex = -1
        cbGender.SelectedIndex = -1
        cbYearLevel.SelectedIndex = -1
        cbCourse.SelectedIndex = -1

        txtBirthdate.MaxDate = Date.Today
        txtBirthdate.MaxDate = txtBirthdate.MaxDate.AddYears(-3)


        If txtID.Text <> "" Then

            cbGender.Text = Gender
            'cbYearLevel.Text = Yearlevel      para makuha ang data ni year level check mo sa loadYearlevel ganto nakasulat don "cbYearLevel.Text = Yearlevel "
            cbCourse.Text = Kurso
            txtStudID.Text = StudentID
            cbDepartment.Text = Department
        End If

      
    End Sub
    Sub BWESIT()
        Try
            connect()
            con.Close()
            con.Open()
            Dim com As New SqlClient.SqlCommand
            com.Connection = con
            com.CommandText = "Select * from tblStudentMasterList where id = '" & GID & "'"
            Dim adpt As New SqlDataAdapter(com)
            Dim dt As New DataTable
            adpt.Fill(dt)
            cbYearLevel.Text = dt.Rows(0)(7).ToString
            cbCourse.Text = dt.Rows(0)(11).ToString

        Catch ex As Exception
        End Try
    End Sub
    Sub loadCourse()
        Try
            con.Close()
            con.Open()
            Dim Cmd As New SqlClient.SqlCommand("SELECT CourseName FROM tblCourse", con)
            Cmd.ExecuteNonQuery()
            Dim Datatable As New DataTable
            Dim DataAdapter As New SqlClient.SqlDataAdapter(Cmd)
            DataAdapter.Fill(Datatable)
            cbCourse.DataSource = Datatable
            cbCourse.ValueMember = "CourseName"
            cbCourse.DisplayMember = "CourseName"
        Catch ex As Exception
            msgerror(Err.Description)
            con.Close()
        End Try


    End Sub
 
    Sub loadDepartment()
         Try
            con.Close()
            con.Open()
            Dim Cmd As New SqlClient.SqlCommand("SELECT DISTINCT Department FROM tblYearLevel ", con)
            Cmd.ExecuteNonQuery()
            Dim Datatable As New DataTable
            Dim DataAdapter As New SqlClient.SqlDataAdapter(Cmd)
            DataAdapter.Fill(Datatable)
            cbDepartment.DataSource = Datatable
            cbDepartment.ValueMember = "Department"
            cbDepartment.DisplayMember = "Department"
        Catch ex As Exception
            msgerror(Err.Description)
            con.Close()
        End Try

    End Sub
    Sub loadYearLevel()
        Try
            con.Close()
            con.Open()
            Dim cmd As New SqlClient.SqlCommand("SELECT Yearlevel FROM tblYearlevel where Department = '" + cbDepartment.Text + "'", con)
            Dim reader As SqlClient.SqlDataReader
            reader = cmd.ExecuteReader

            cbYearLevel.Items.Clear()
            While reader.Read

                cbYearLevel.Items.Add(reader("Yearlevel"))
            End While

            cbYearLevel.Text = Yearlevel

        Catch ex As Exception
            msgerror(Err.Description)
            con.Close()
        End Try


    End Sub
    'Sub loadDepartment1()
    '    Try
    '        con.Close()
    '        con.Open()
    '        Dim Cmd As New SqlClient.SqlCommand("SELECT DISTINCT Department FROM tblYearLevel ", con)
    '        Cmd.ExecuteNonQuery()
    '        Dim Datatable As New DataTable
    '        Dim DataAdapter As New SqlClient.SqlDataAdapter(Cmd)
    '        DataAdapter.Fill(Datatable)
    '        cbDepartment.DataSource = Datatable
    '        cbDepartment.ValueMember = "Department"
    '        cbDepartment.DisplayMember = "Department"
    '    Catch ex As Exception
    '        msgerror(Err.Description)
    '        con.Close()
    '    End Try


    'End Sub
    Sub clear1()
        Gender = ""
        Yearlevel = ""
        Kurso = ""
        ContactNo = ""
        StudentID = ""
    End Sub
    Sub clear()
        txtStudID.Text = ""
        txtLastname.Text = ""
        txtFirstname.Text = ""
        txtMI.Text = ""
        cbGender.SelectedIndex = -1
        cbDepartment.SelectedIndex = -1
        cbYearLevel.SelectedIndex = -1
        cbCourse.SelectedIndex = -1
        txtGuardian.Text = ""
        txtMobileNo.Text = ""
        txtAddress.Text = ""
        PictureBox2.Image = Nothing
    End Sub
    Private Function AddStudent()
        Try
            If checkUser() = True Then
                msgerror("Student ID already exist")
            Else

                con.Close()
                con.Open()
                connect()
                If PictureBox2.Image Is Nothing Then
                    If MsgBox("Are you sure yo want to add this data?", MsgBoxStyle.YesNo) = vbYes Then
                        connect()
                        cmd.Connection = con
                        cmd.CommandText = "INSERT INTO tblStudentMasterList(StudentID,Lastname,Firstname,MI,Birthdate,Gender,Yearlevel,Guardian,MobileNo,Address,Course,NoStudent,Photo,Department)" & _
                            "Values (@SI,@LN,@FN,@MI,@BD,@GEN,@YL,@G,@MN,@ADD,@C,@NS,@Img,@DM)"

                        cmd.Parameters.Clear()
                        cmd.Parameters.AddWithValue("@SI", txtStudID.Text)
                        cmd.Parameters.AddWithValue("@LN", txtLastname.Text)
                        cmd.Parameters.AddWithValue("@FN", txtFirstname.Text)
                        cmd.Parameters.AddWithValue("@MI", txtMI.Text)
                        cmd.Parameters.AddWithValue("@BD", txtBirthdate.Text)
                        cmd.Parameters.AddWithValue("@GEN", cbGender.Text)
                        cmd.Parameters.AddWithValue("@YL", cbYearLevel.Text)
                        cmd.Parameters.AddWithValue("@G", txtGuardian.Text)
                        cmd.Parameters.AddWithValue("@MN", txtMobileNo.Text)
                        cmd.Parameters.AddWithValue("@ADD", txtAddress.Text)
                        If cbCourse.Text = "" Then
                            cbCourse.Text = "N/A"
                        End If
                        cmd.Parameters.AddWithValue("@C", cbCourse.Text)
                        cmd.Parameters.AddWithValue("@NS", txtNoStudent.Text)

                        Dim photoparam As New SqlParameter("@Img", SqlDbType.Image)
                        photoparam.Value = DBNull.Value
                        cmd.Parameters.Add(photoparam)

                        cmd.Parameters.AddWithValue("@DM", cbDepartment.Text)
                        Dim a As Integer = cmd.ExecuteNonQuery()
                        AuditTrail("Student MasterList ", "Insert", "Student Info: " + txtStudID.Text + "," + txtLastname.Text + "," + txtFirstname.Text + "," + cbGender.Text + "," + txtMobileNo.Text + "|Birthdate :" + txtBirthdate.Text + "|Department : " + cbDepartment.Text + "|Yearlevel : " + cbYearLevel.Text)
                        If a > 0 Then

                            StudentMasterList.list()
                            msginfo("New Student has been added")
                            clear()
                            PictureBox2.Image = Nothing
                            MainForm.totalStudent()

                        Else
                            MsgBox("Failed")
                        End If
                    End If

                    con.Close()
                ElseIf PictureBox2.Image IsNot Nothing Then
                    Dim ms As New MemoryStream
                    PictureBox2.Image.Save(ms, PictureBox2.Image.RawFormat)
                    Dim arrimage() As Byte = ms.GetBuffer
                    ms.Close()

                    If MsgBox("Are you sure yo want to add this data?", MsgBoxStyle.YesNo) = vbYes Then
                        connect()
                        cmd.Connection = con
                        cmd.CommandText = "INSERT INTO tblStudentMasterList(StudentID,Lastname,Firstname,MI,Birthdate,Gender,Yearlevel,Guardian,MobileNo,Address,Course,NoStudent,Photo,Department)" & _
                            "Values (@SI,@LN,@FN,@MI,@BD,@GEN,@YL,@G,@MN,@ADD,@C,@NS,@Img,@DM)"

                        cmd.Parameters.Clear()
                        cmd.Parameters.AddWithValue("@SI", txtStudID.Text)
                        cmd.Parameters.AddWithValue("@LN", txtLastname.Text)
                        cmd.Parameters.AddWithValue("@FN", txtFirstname.Text)
                        cmd.Parameters.AddWithValue("@MI", txtMI.Text)
                        cmd.Parameters.AddWithValue("@BD", txtBirthdate.Text)
                        cmd.Parameters.AddWithValue("@GEN", cbGender.Text)
                        cmd.Parameters.AddWithValue("@YL", cbYearLevel.Text)
                        cmd.Parameters.AddWithValue("@G", txtGuardian.Text)
                        cmd.Parameters.AddWithValue("@MN", txtMobileNo.Text)
                        cmd.Parameters.AddWithValue("@ADD", txtAddress.Text)
                        If cbCourse.Text = "" Then
                            cbCourse.Text = "N/A"
                        End If
                        cmd.Parameters.AddWithValue("@C", cbCourse.Text)
                        cmd.Parameters.AddWithValue("@NS", txtNoStudent.Text)
                        cmd.Parameters.AddWithValue("@Img", arrimage)
                        cmd.Parameters.AddWithValue("@DM", cbDepartment.Text)
                        Dim a As Integer = cmd.ExecuteNonQuery()
                        AuditTrail("Student MasterList ", "Insert", "Student Info: " + txtStudID.Text + "," + txtLastname.Text + "," + txtFirstname.Text + "," + cbGender.Text + "," + txtMobileNo.Text + "|Birthdate :" + txtBirthdate.Text + "|Department : " + cbDepartment.Text + "|Yearlevel : " + cbYearLevel.Text)
                        If a > 0 Then

                            StudentMasterList.list()
                            msginfo("New Student has been added")
                            clear()
                            PictureBox2.Image = Nothing
                            MainForm.totalStudent()

                        Else
                            MsgBox("Failed")
                        End If
                    End If
                End If
                con.Close()
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
        con.Close()
        Return Nothing
    End Function
    Private Function SubUpdateAdmin()
        Try
            If checkUser() = True Then
                msgerror("Student ID already exist")
            Else
                If PictureBox2.Image Is Nothing Then
                    If MsgBox("Are you sure you want to update this data?", MsgBoxStyle.YesNo) = vbYes Then
                        con.Close()
                        con.Open()
                        connect()
                        With cmd
                            cmd.Connection = con
                            .CommandText = "UPDATE tblStudentMasterList SET  StudentID = @SI, Lastname = @LN, Firstname = @FN, MI = @MI, Birthdate = @BD, Gender = @GEN, Yearlevel = @YL, " & _
                            " Guardian = @GUAR, MobileNo = @MN, Address = @ADD, Course = @C,Photo = @Img, Department = @DM " & _
                            "where Id = '" & StudentMasterList.txtID.Text & "'"
                            .Parameters.Clear()
                            .Parameters.AddWithValue("@SI", txtStudID.Text)
                            .Parameters.AddWithValue("@LN", txtLastname.Text)
                            .Parameters.AddWithValue("@FN", txtFirstname.Text)
                            .Parameters.AddWithValue("@MI", txtMI.Text)
                            .Parameters.AddWithValue("@BD", txtBirthdate.Text)
                            .Parameters.AddWithValue("@GEN", cbGender.Text)
                            .Parameters.AddWithValue("@YL", cbYearLevel.Text)
                            .Parameters.AddWithValue("@GUAR", txtGuardian.Text)
                            .Parameters.AddWithValue("@MN", txtMobileNo.Text)
                            .Parameters.AddWithValue("@ADD", txtAddress.Text)
                            .Parameters.AddWithValue("@C", cbCourse.Text)
                            Dim photoparam As New SqlParameter("@Img", SqlDbType.Image)
                            photoparam.Value = DBNull.Value
                            .Parameters.Add(photoparam)
                            .Parameters.AddWithValue("@Img", photoparam)
                            .Parameters.AddWithValue("@DM", cbDepartment.Text)
                        End With
                        Dim a As Integer = cmd.ExecuteNonQuery()
                        AuditTrail("Student MasterList ", "Update", "User Info: " + txtStudID.Text + "," + txtLastname.Text + "," + txtFirstname.Text + "," + cbGender.Text + "," + txtMobileNo.Text + "|Birthdate :" + txtBirthdate.Text + "|Department : " + cbDepartment.Text + "|Yearlevel : " + cbYearLevel.Text)
                        If a > 0 Then
                            UpdateallAttendance()
                            UpdateallEventAttendance()
                            'UpdateSTUDIDAttendanceRecord()
                            'UpdateSTUDIDEventAttendanceRecord()

                            'UpdateFNAttendanceRecord()
                            'UpdateLNAttendanceRecord()

                            'UpdateLNEventAttendanceRecord()
                            'UpdateFNEventAttendanceRecord()

                            MsgBox("Updated Successfully.")
                            StudentMasterList.txtID.Text = ""
                            StudentMasterList.PictureBox2.Image = Nothing
                            StudentMasterList.list()
                            txtID.Text = ""
                            txtStudID.Text = ""
                            txtLastname.Text = ""
                            txtFirstname.Text = ""
                            txtMI.Text = ""
                            cbGender.SelectedIndex = -1
                            cbDepartment.SelectedIndex = -1
                            cbYearLevel.SelectedIndex = -1
                            cbCourse.SelectedIndex = -1
                            txtGuardian.Text = ""
                            txtMobileNo.Text = ""
                            txtAddress.Text = ""
                            clear1()
                            Me.Close()
                        Else
                            MsgBox("Failed to Update.")
                        End If
                    End If
                    con.Close()
                ElseIf PictureBox2.Image IsNot Nothing Then

                    Dim ms As New MemoryStream
                    PictureBox2.Image.Save(ms, PictureBox2.Image.RawFormat)
                    Dim arrimage() As Byte = ms.GetBuffer
                    ms.Close()

                    If MsgBox("Are you sure you want to update this data?", MsgBoxStyle.YesNo) = vbYes Then
                        con.Close()
                        con.Open()
                        connect()
                        With cmd
                            cmd.Connection = con
                            .CommandText = "UPDATE tblStudentMasterList SET  StudentID = @SI, Lastname = @LN, Firstname = @FN, MI = @MI, Birthdate = @BD, Gender = @GEN, Yearlevel = @YL, " & _
                            " Guardian = @GUAR, MobileNo = @MN, Address = @ADD, Course = @C,Photo = @Img, Department = @DM " & _
                            "where Id = '" & StudentMasterList.txtID.Text & "'"
                            .Parameters.Clear()
                            .Parameters.AddWithValue("@SI", txtStudID.Text)
                            .Parameters.AddWithValue("@LN", txtLastname.Text)
                            .Parameters.AddWithValue("@FN", txtFirstname.Text)
                            .Parameters.AddWithValue("@MI", txtMI.Text)
                            .Parameters.AddWithValue("@BD", txtBirthdate.Text)
                            .Parameters.AddWithValue("@GEN", cbGender.Text)
                            .Parameters.AddWithValue("@YL", cbYearLevel.Text)
                            .Parameters.AddWithValue("@GUAR", txtGuardian.Text)
                            .Parameters.AddWithValue("@MN", txtMobileNo.Text)
                            .Parameters.AddWithValue("@ADD", txtAddress.Text)
                            .Parameters.AddWithValue("@C", cbCourse.Text)
                            .Parameters.AddWithValue("@Img", arrimage)
                            .Parameters.AddWithValue("@DM", cbDepartment.Text)
                        End With
                        Dim a As Integer = cmd.ExecuteNonQuery()
                        AuditTrail("Student MasterList ", "Update", "User Info: " + txtStudID.Text + "," + txtLastname.Text + "," + txtFirstname.Text + "," + cbGender.Text + "," + txtMobileNo.Text + "|Birthdate :" + txtBirthdate.Text + "|Department : " + cbDepartment.Text + "|Yearlevel : " + cbYearLevel.Text)
                        If a > 0 Then
                            UpdateallAttendance()
                            UpdateallEventAttendance()
                            'UpdateSTUDIDAttendanceRecord()
                            'UpdateSTUDIDEventAttendanceRecord()

                            'UpdateFNAttendanceRecord()
                            'UpdateLNAttendanceRecord()

                            'UpdateLNEventAttendanceRecord()
                            'UpdateFNEventAttendanceRecord()

                            MsgBox("Updated Successfully.")
                            StudentMasterList.txtID.Text = ""
                            StudentMasterList.PictureBox2.Image = Nothing
                            StudentMasterList.list()
                            txtID.Text = ""
                            txtStudID.Text = ""
                            txtLastname.Text = ""
                            txtFirstname.Text = ""
                            txtMI.Text = ""
                            cbGender.SelectedIndex = -1
                            cbDepartment.SelectedIndex = -1
                            cbYearLevel.SelectedIndex = -1
                            cbCourse.SelectedIndex = -1
                            txtGuardian.Text = ""
                            txtMobileNo.Text = ""
                            txtAddress.Text = ""
                            clear1()
                            Me.Close()
                        Else
                            MsgBox("Failed to Update.")
                        End If
                    End If
                End If
            End If
            con.Close()
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
        Return Nothing
    End Function
        
    Private Function UpdateStudent()
        Try
       
                If PictureBox2.Image Is Nothing Then
                    If MsgBox("Are you sure you want to update this data?", MsgBoxStyle.YesNo) = vbYes Then
                        con.Close()
                        con.Open()
                        connect()
                        With cmd
                            cmd.Connection = con
                            .CommandText = "UPDATE tblStudentMasterList SET  StudentID = @SI, Lastname = @LN, Firstname = @FN, MI = @MI, Birthdate = @BD, Gender = @GEN, Yearlevel = @YL, " & _
                            " Guardian = @GUAR, MobileNo = @MN, Address = @ADD, Course = @C,Photo = @Img, Department = @DM " & _
                            "where Id = '" & StudentMasterList.txtID.Text & "'"
                            .Parameters.Clear()
                            .Parameters.AddWithValue("@SI", txtStudID.Text)
                            .Parameters.AddWithValue("@LN", txtLastname.Text)
                            .Parameters.AddWithValue("@FN", txtFirstname.Text)
                            .Parameters.AddWithValue("@MI", txtMI.Text)
                            .Parameters.AddWithValue("@BD", txtBirthdate.Text)
                            .Parameters.AddWithValue("@GEN", cbGender.Text)
                            .Parameters.AddWithValue("@YL", cbYearLevel.Text)
                            .Parameters.AddWithValue("@GUAR", txtGuardian.Text)
                            .Parameters.AddWithValue("@MN", txtMobileNo.Text)
                            .Parameters.AddWithValue("@ADD", txtAddress.Text)
                            .Parameters.AddWithValue("@C", cbCourse.Text)
                            Dim photoparam As New SqlParameter("@Img", SqlDbType.Image)
                            photoparam.Value = DBNull.Value
                            .Parameters.Add(photoparam)
                            .Parameters.AddWithValue("@DM", cbDepartment.Text)
                        End With
                        Dim a As Integer = cmd.ExecuteNonQuery()
                        AuditTrail("Student MasterList ", "Update", "User Info: " + txtStudID.Text + "," + txtLastname.Text + "," + txtFirstname.Text + "," + cbGender.Text + "," + txtMobileNo.Text + "|Birthdate :" + txtBirthdate.Text + "|Department : " + cbDepartment.Text + "|Yearlevel : " + cbYearLevel.Text)
                    If a > 0 Then
                        UpdateallAttendance()
                        UpdateallEventAttendance()
                        'UpdateSTUDIDAttendanceRecord()
                        'UpdateSTUDIDEventAttendanceRecord()

                        'UpdateFNAttendanceRecord()
                        'UpdateLNAttendanceRecord()

                        'UpdateLNEventAttendanceRecord()
                        'UpdateFNEventAttendanceRecord()

                        MsgBox("Updated Successfully.")
                        StudentMasterList.txtID.Text = ""
                        StudentMasterList.PictureBox2.Image = Nothing
                        StudentMasterList.list()
                        txtID.Text = ""
                        txtStudID.Text = ""
                        txtLastname.Text = ""
                        txtFirstname.Text = ""
                        txtMI.Text = ""
                        cbGender.SelectedIndex = -1
                        cbDepartment.SelectedIndex = -1
                        cbYearLevel.SelectedIndex = -1
                        cbCourse.SelectedIndex = -1
                        txtGuardian.Text = ""
                        txtMobileNo.Text = ""
                        txtAddress.Text = ""
                        clear1()
                        Me.Close()
                    Else
                        MsgBox("Failed to Update.")
                    End If
                    End If
                    con.Close()
                ElseIf PictureBox2.Image IsNot Nothing Then

                    Dim ms As New MemoryStream
                    PictureBox2.Image.Save(ms, PictureBox2.Image.RawFormat)
                    Dim arrimage() As Byte = ms.GetBuffer
                    ms.Close()

                    If MsgBox("Are you sure you want to update this data?", MsgBoxStyle.YesNo) = vbYes Then
                        con.Close()
                        con.Open()
                        connect()
                        With cmd
                            cmd.Connection = con
                            .CommandText = "UPDATE tblStudentMasterList SET  StudentID = @SI, Lastname = @LN, Firstname = @FN, MI = @MI, Birthdate = @BD, Gender = @GEN, Yearlevel = @YL, " & _
                            " Guardian = @GUAR, MobileNo = @MN, Address = @ADD, Course = @C,Photo = @Img, Department = @DM " & _
                            "where Id = '" & StudentMasterList.txtID.Text & "'"
                            .Parameters.Clear()
                            .Parameters.AddWithValue("@SI", txtStudID.Text)
                            .Parameters.AddWithValue("@LN", txtLastname.Text)
                            .Parameters.AddWithValue("@FN", txtFirstname.Text)
                            .Parameters.AddWithValue("@MI", txtMI.Text)
                            .Parameters.AddWithValue("@BD", txtBirthdate.Text)
                            .Parameters.AddWithValue("@GEN", cbGender.Text)
                            .Parameters.AddWithValue("@YL", cbYearLevel.Text)
                            .Parameters.AddWithValue("@GUAR", txtGuardian.Text)
                            .Parameters.AddWithValue("@MN", txtMobileNo.Text)
                            .Parameters.AddWithValue("@ADD", txtAddress.Text)
                            .Parameters.AddWithValue("@C", cbCourse.Text)
                            .Parameters.AddWithValue("@Img", arrimage)
                            .Parameters.AddWithValue("@DM", cbDepartment.Text)
                        End With
                        Dim a As Integer = cmd.ExecuteNonQuery()
                        AuditTrail("Student MasterList ", "Update", "User Info: " + txtStudID.Text + "," + txtLastname.Text + "," + txtFirstname.Text + "," + cbGender.Text + "," + txtMobileNo.Text + "|Birthdate :" + txtBirthdate.Text + "|Department : " + cbDepartment.Text + "|Yearlevel : " + cbYearLevel.Text)
                    If a > 0 Then
                        UpdateallAttendance()
                        UpdateallEventAttendance()
                        'UpdateSTUDIDAttendanceRecord()
                        'UpdateSTUDIDEventAttendanceRecord()

                        'UpdateFNAttendanceRecord()
                        'UpdateLNAttendanceRecord()

                        'UpdateLNEventAttendanceRecord()
                        'UpdateFNEventAttendanceRecord()

                        MsgBox("Updated Successfully.")
                        StudentMasterList.txtID.Text = ""
                        StudentMasterList.PictureBox2.Image = Nothing
                        StudentMasterList.list()
                        txtID.Text = ""
                        txtStudID.Text = ""
                        txtLastname.Text = ""
                        txtFirstname.Text = ""
                        txtMI.Text = ""
                        cbGender.SelectedIndex = -1
                        cbDepartment.SelectedIndex = -1
                        cbYearLevel.SelectedIndex = -1
                        cbCourse.SelectedIndex = -1
                        txtGuardian.Text = ""
                        txtMobileNo.Text = ""
                        txtAddress.Text = ""
                        clear1()
                        Me.Close()
                    Else
                        MsgBox("Failed to Update.")
                    End If
                    End If
                End If

            con.Close()
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
        Return Nothing
    End Function
    Private Function UpdateallAttendance()
        con.Close()
        con.Open()
        connect()
        With cmd
            .Connection = con
            .CommandText = "Update tblAttendance SET  StudentID = @STUDID, Firstname = @FN, Lastname = @LN, Yearlevel = @YL, Course = @C, Department = @DEPT where StudentID = '" & txtSID.Text & "'"
            .Parameters.Clear()
            .Parameters.AddWithValue("@STUDID", txtStudID.Text)
            .Parameters.AddWithValue("@FN", txtFirstname.Text)
            .Parameters.AddWithValue("@LN", txtLastname.Text)
            .Parameters.AddWithValue("@YL", cbYearLevel.Text)
            .Parameters.AddWithValue("@C", cbCourse.Text)
            .Parameters.AddWithValue("@DEPT", cbDepartment.Text)


        End With


        Dim a As Integer = cmd.ExecuteNonQuery()
        If a > 0 Then
            StudentMasterList.list()
            AttendanceRecord.list()
        End If
        Return Nothing
    End Function
    Private Function UpdateallEventAttendance()
        con.Close()
        con.Open()
        connect()
        With cmd
            .Connection = con
            .CommandText = "Update tblEventRecord SET  StudentID = @STUDID, Firstname = @FN, Lastname = @LN, Yearlevel = @YL, Course = @C, Department = @DEPT where StudentID = '" & txtSID.Text & "'"
            .Parameters.Clear()
            .Parameters.AddWithValue("@STUDID", txtStudID.Text)
            .Parameters.AddWithValue("@FN", txtFirstname.Text)
            .Parameters.AddWithValue("@LN", txtLastname.Text)
            .Parameters.AddWithValue("@YL", cbYearLevel.Text)
            .Parameters.AddWithValue("@C", cbCourse.Text)
            .Parameters.AddWithValue("@DEPT", cbDepartment.Text)


        End With


        Dim a As Integer = cmd.ExecuteNonQuery()
        If a > 0 Then
            StudentMasterList.list()
            EventAttendance.list()
        End If
        Return Nothing
    End Function
    Private Function UpdateSTUDIDAttendanceRecord()
        con.Close()
        con.Open()
        connect()
        With cmd
            .Connection = con
            .CommandText = "Update tblAttendance SET  StudentID = @STUDID where StudentID = '" & txtSID.Text & "'"
            .Parameters.Clear()
            .Parameters.AddWithValue("@STUDID", txtStudID.Text)

        End With


        Dim a As Integer = cmd.ExecuteNonQuery()
        If a > 0 Then
            StudentMasterList.list()
            AttendanceRecord.list()
        End If
        Return Nothing
    End Function
    Private Function UpdateSTUDIDEventAttendanceRecord()
        con.Close()
        con.Open()
        connect()
        With cmd
            .Connection = con
            .CommandText = "Update tblEventRecord SET  StudentID = @STUDID where StudentID = '" & txtSID.Text & "'"
            .Parameters.Clear()
            .Parameters.AddWithValue("@STUDID", txtStudID.Text)
        End With


        Dim a As Integer = cmd.ExecuteNonQuery()
        If a > 0 Then
            StudentMasterList.list()
            EventRecord.list()
        End If
        Return Nothing
    End Function
    Private Function UpdateFNAttendanceRecord()
        con.Close()
        con.Open()
        connect()
        With cmd
            .Connection = con
            .CommandText = "Update tblAttendance SET  Firstname = @FN where Firstname = '" & txtFname.Text & "'"
            .Parameters.Clear()
            .Parameters.AddWithValue("@FN", txtFirstname.Text)

        End With


        Dim a As Integer = cmd.ExecuteNonQuery()
        If a > 0 Then
            StudentMasterList.list()
            AttendanceRecord.list()
        End If
        Return Nothing
    End Function
    Private Function UpdateLNAttendanceRecord()
        con.Close()
        con.Open()
        connect()
        With cmd
            .Connection = con
            .CommandText = "Update tblAttendance SET  Lastname = @LN where Lastname = '" & txtLname.Text & "'"
            .Parameters.Clear()
            .Parameters.AddWithValue("@LN", txtLastname.Text)
        End With


        Dim a As Integer = cmd.ExecuteNonQuery()
        If a > 0 Then
            StudentMasterList.list()
            AttendanceRecord.list()
        End If
        Return Nothing
    End Function
    Private Function UpdateFNEventAttendanceRecord()
        con.Close()
        con.Open()
        connect()
        With cmd
            .Connection = con
            .CommandText = "Update tblEventRecord SET  Firstname = @FN where Firstname = '" & txtFname.Text & "'"
            .Parameters.Clear()
            .Parameters.AddWithValue("@FN", txtFirstname.Text)

        End With


        Dim a As Integer = cmd.ExecuteNonQuery()
        If a > 0 Then
            StudentMasterList.list()
            EventRecord.list()
        End If
        Return Nothing
    End Function
    Private Function UpdateLNEventAttendanceRecord()
        con.Close()
        con.Open()
        connect()
        With cmd
            .Connection = con
            .CommandText = "Update tblEventRecord SET  Lastname = @LN where Lastname = '" & txtLname.Text & "'"
            .Parameters.Clear()
            .Parameters.AddWithValue("@LN", txtLastname.Text)
        End With


        Dim a As Integer = cmd.ExecuteNonQuery()
        If a > 0 Then
            StudentMasterList.list()
            EventRecord.list()
        End If
        Return Nothing
    End Function
    Private Function SubUpdateStudent()
                Try
                    Dim ms As New MemoryStream
                    PictureBox2.Image.Save(ms, PictureBox2.Image.RawFormat)
                    Dim arrimage() As Byte = ms.GetBuffer
                    ms.Close()

                    con.Close()
                    con.Open()
                    connect()
                    With cmd
                        cmd.Connection = con
                        .CommandText = "UPDATE tblStudentMasterList SET  StudentID = @SI, Lastname = @LN, Firstname = @FN, MI = @MI, Birthdate = @BD, Gender = @GEN, Yearlevel = @YL, " & _
                        " Guardian = @GUAR, MobileNo = @MN, Address = @ADD, Course = @C,Photo = @Img " & _
                        "where Id = '" & StudentMasterList.txtID.Text & "'"
                        .Parameters.Clear()
                        .Parameters.AddWithValue("@SI", txtStudID.Text)
                        .Parameters.AddWithValue("@LN", txtLastname.Text)
                        .Parameters.AddWithValue("@FN", txtFirstname.Text)
                        .Parameters.AddWithValue("@MI", txtMI.Text)
                        .Parameters.AddWithValue("@BD", txtBirthdate.Text)
                        .Parameters.AddWithValue("@GEN", cbGender.Text)
                        .Parameters.AddWithValue("@YL", cbYearLevel.Text)
                        .Parameters.AddWithValue("@GUAR", txtGuardian.Text)
                        .Parameters.AddWithValue("@MN", txtMobileNo.Text)
                        .Parameters.AddWithValue("@ADD", txtAddress.Text)
                        .Parameters.AddWithValue("@C", cbCourse.Text)
                        .Parameters.AddWithValue("@Img", arrimage)
            End With
            Dim a As Integer = cmd.ExecuteNonQuery()
            AuditTrail("Student MasterList ", "Insert", "User Info: " + txtStudID.Text + "," + txtLastname.Text + "," + txtFirstname.Text + "," + cbGender.Text + "," + txtMobileNo.Text + "|Birthdate :" + txtBirthdate.Text + "|Department : " + cbDepartment.Text + "|Yearlevel : " + cbYearLevel.Text)
                    If a > 0 Then
                MsgBox("Updated Successfully.")
                StudentMasterList.txtID.Text = ""
                StudentMasterList.PictureBox2.Image = Nothing
                StudentMasterList.list()
                txtID.Text = ""
                txtStudID.Text = ""
                txtLastname.Text = ""
                txtFirstname.Text = ""
                txtMI.Text = ""
                cbGender.SelectedIndex = -1
                cbYearLevel.SelectedIndex = -1
                cbCourse.SelectedIndex = -1
                txtGuardian.Text = ""
                txtMobileNo.Text = ""
                txtAddress.Text = ""
                clear1()
                Me.Close()
                    Else
                        MsgBox("Failed to Update.")

                    End If


                Catch ex As Exception
                    msgerror(Err.Description)
                End Try
        Return Nothing
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtStudID.Text = "" Or txtLastname.Text = "" Or txtFirstname.Text = "" Or cbGender.SelectedIndex = -1 Or cbYearLevel.SelectedIndex = -1 Or txtGuardian.Text = "" Or txtMobileNo.Text = "" Or txtAddress.Text = "" Then
            msgerror("Complete all details")
            'ElseIf PictureBox2.Image Is Nothing Then
            '    msgerror("Please insert image")
        ElseIf txtMobileNo.TextLength <= 10 Then
            msgerror("Invalid Contact Number")
        ElseIf txtAddress.TextLength < 5 Then
            msgerror("Invalid Address ")
        ElseIf txtStudID.TextLength < 7 Then
            msgerror("Invalid, Student ID must be 7 to 15 characters")
        ElseIf txtLastname.TextLength <= 1 Then
            msgerror("Invalid, Lastname must be 2 to 30 characters")
        ElseIf txtAddress.TextLength < 5 Then
            msgerror("Invalid, Address must be 5 to 100 characters")
        ElseIf (txtLastname.Text.EndsWith(" ")) Then
            msgerror("Invalid format Last name " + txtLastname.Text + "''Space''")
        ElseIf (txtFirstname.Text.EndsWith(" ")) Then
            msgerror("Invalid format First name " + txtFirstname.Text + "''Space''")
        ElseIf (txtMI.Text.EndsWith(" ")) Then
            msgerror("Invalid format MI " + txtMI.Text + "''Space''")
        ElseIf (txtGuardian.Text.EndsWith(" ")) Then
            msgerror("Invalid format Guardian " + txtGuardian.Text + "''Space''")
        ElseIf (txtMobileNo.Text.EndsWith(" ")) Then
            msgerror("Invalid format Mobile number " + txtMobileNo.Text + "''Space''")
        ElseIf (txtAddress.Text.EndsWith(" ")) Then
            msgerror("Invalid format Address " + txtAddress.Text + "''Space''")
        ElseIf txtMobileNo.Text <> "" Then
            Dim digit3 As String = txtMobileNo.Text.Substring(0, 2)
            txtfrst3digits.Text = digit3
            If txtfrst3digits.Text <> "09" Then
                msgerror("First digit must be 09")
                txtfrst3digits.Text = ""
            ElseIf txtID.Text = "" Then
                AddStudent()
            ElseIf txtID.Text <> "" Then
                 UpdateStudent()
                Exit Sub
            End If
        ElseIf txtID.Text = "" Then
            AddStudent()
        ElseIf txtStudID.Text = txtSID.Text Then
            UpdateStudent()
        ElseIf txtID.Text <> "" Then
            SubUpdateAdmin()
        End If
    End Sub
    Public Function checkUser()
        Try
            con.Close()
            con.Open()

            connect()
            Dim adp As New SqlDataAdapter
            Dim dt As New DataTable
            Dim query As String = "SELECT * FROM tblStudentMasterList  WHERE StudentID = @STUID"

            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@STUID", txtStudID.Text)

            With adp
                .SelectCommand = cmd
                .Fill(dt)
            End With


            If dt.Rows.Count >= 1 Then

                Return True
                Exit Function
            End If
            con.Close()

        Catch ex As Exception
            msgerror(Err.Description)
        End Try
        Return Nothing
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try



            Dim dialog As DialogResult
            dialog = MessageBox.Show("Do you want to Close this?", "", MessageBoxButtons.YesNo)
            If dialog = DialogResult.No Then

                Beep()
                MsgBox("Cancel!!")



            Else
               
                clear()
                clear1()
                txtID.Text = ""

                'If StudentMasterList.ListView1.SelectedItems.Count <> 0 Then
                '    StudentMasterList.ListView1.Items.Clear()
                '    StudentMasterList.list()
                'End If

               
                StudentMasterList.Show()
                StudentMasterList.txtID.Text = ""
                StudentMasterList.PictureBox2.Image = Nothing
                StudentMasterList.ListView1.Items.Clear()
                StudentMasterList.list()
                Beep()
                Me.Close()
            End If


        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub



    Private Sub BunifuThinButton24_Click(sender As Object, e As EventArgs) Handles BunifuThinButton24.Click
        Try


            With OpenFileDialog1
                .InitialDirectory = "C:\Pictures\"
                '.Filter = "All Files|*.*|Bitmap|*.bmp|Gifs|*.gif|JPEGs|*.jpg"
                .Filter = "Bitmap|*.bmp|Gifs|*.gif|JPEGs|*.jpg|PNG|*.png"
                .FilterIndex = 1

            End With

            If OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                With PictureBox2
                    .Image = Image.FromFile(OpenFileDialog1.FileName)
                    .BorderStyle = BorderStyle.Fixed3D
                    .SizeMode = PictureBoxSizeMode.StretchImage
                End With


            End If
        Catch ex As Exception
            msgerror("Failed to upload")
        End Try
    End Sub
    Sub View()
        Try

      
        StudentMasterList.txtID.Text = StudentMasterList.ListView1.SelectedItems(0).Text
        If StudentMasterList.txtID.Text <> "" Then
            Dim cmd As New SqlCommand("Select * from tblStudentMasterList where Id = '" & StudentMasterList.txtID.Text & "'", con)
            Dim table As New DataTable
            Dim adpt As New SqlDataAdapter(cmd)

            adpt.Fill(table)
            Dim img() As Byte
            img = table.Rows(0)(13)
            Dim ms As New MemoryStream(img)
            PictureBox2.Image = Image.FromStream(ms)


        ElseIf StudentMasterList.txtID.Text = "" Then
            PictureBox2.Image = Nothing
            End If
        Catch ex As Exception
            PictureBox2.Image = Nothing
        End Try
    End Sub

    Private Sub txtLastname_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLastname.KeyDown
        If txtLastname.Text <> "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = False
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        ElseIf txtLastname.Text = "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        End If
        If (e.Control AndAlso e.KeyCode = Keys.S) Then
            Button1.PerformClick()
        End If
    End Sub

    Private Sub txtLastname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLastname.KeyPress
        Dim a As String = txtLastname.Text
        If a.Contains(" ") Then
            If e.KeyChar = " " Then
                e.Handled = True
                Exit Sub
            End If
        Else
            e.Handled = False
        End If
        If e.KeyChar = " " AndAlso txtLastname.Text.EndsWith(" ") Then
            e.KeyChar = Chr(0)
            e.Handled = True
            Exit Sub
        End If
        Select Case e.KeyChar
            Case Convert.ToChar(Keys.Enter)

            Case Convert.ToChar(Keys.Back)
                e.Handled = False

            Case Convert.ToChar(Keys.Capital Or Keys.RButton)
                e.Handled = Not Clipboard.GetText().All(Function(c) validchars2.Contains(c))
            Case Else
                e.Handled = Not validchars2.Contains(e.KeyChar)


        End Select
    End Sub

  

    Private Sub txtFirstname_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFirstname.KeyDown
        If txtFirstname.Text <> "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = False
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        ElseIf txtFirstname.Text = "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        End If
        If (e.Control AndAlso e.KeyCode = Keys.S) Then
            Button1.PerformClick()
        End If
    End Sub

    Private Sub txtFirstname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFirstname.KeyPress
        If e.KeyChar = " " AndAlso txtFirstname.Text.EndsWith(" ") Then
            e.KeyChar = Chr(0)
            e.Handled = True
            Exit Sub
        End If
        Select Case e.KeyChar
            Case Convert.ToChar(Keys.Enter)

            Case Convert.ToChar(Keys.Back)
                e.Handled = False

            Case Convert.ToChar(Keys.Capital Or Keys.RButton)
                e.Handled = Not Clipboard.GetText().All(Function(c) validchars2.Contains(c))
            Case Else
                e.Handled = Not validchars2.Contains(e.KeyChar)

        End Select
    End Sub

    Private Sub txtMI_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMI.KeyDown
        If txtMI.Text <> "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = False
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        ElseIf txtMI.Text = "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        End If
    End Sub

    Private Sub txtMI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMI.KeyPress
        Select Case e.KeyChar
            Case Convert.ToChar(Keys.Enter)

            Case Convert.ToChar(Keys.Back)
                e.Handled = False

            Case Convert.ToChar(Keys.Capital Or Keys.RButton)
                e.Handled = Not Clipboard.GetText().All(Function(c) validchars2.Contains(c))
            Case Else
                e.Handled = Not validchars2.Contains(e.KeyChar)
        End Select

        If Char.IsLetter(e.KeyChar) = False And e.KeyChar <> ChrW(8) Then
            e.Handled = True
            Exit Sub
        End If
        If txtMI.Text.Length >= 0 Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
            Exit Sub
        End If
    End Sub



    Private Sub txtGuardian_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGuardian.KeyDown
        If txtGuardian.Text <> "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = False
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        ElseIf txtGuardian.Text = "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        End If
        If (e.Control AndAlso e.KeyCode = Keys.S) Then
            Button1.PerformClick()
        End If
    End Sub


    Private Sub txtGuardian_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGuardian.KeyPress
        If e.KeyChar = " " AndAlso txtGuardian.Text.EndsWith(" ") Then
            e.KeyChar = Chr(0)
            e.Handled = True
            Exit Sub
        End If
        Select Case e.KeyChar
            Case Convert.ToChar(Keys.Enter)

            Case Convert.ToChar(Keys.Back)
                e.Handled = False

            Case Convert.ToChar(Keys.Capital Or Keys.RButton)
                e.Handled = Not Clipboard.GetText().All(Function(c) validchars2.Contains(c))
            Case Else
                e.Handled = Not validchars2.Contains(e.KeyChar)


        End Select
    End Sub

    Private Sub txtAddress_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAddress.KeyDown
        If txtAddress.Text <> "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = False
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        ElseIf txtAddress.Text = "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        End If
        If (e.Control AndAlso e.KeyCode = Keys.S) Then
            Button1.PerformClick()
        End If
    End Sub

    Private Sub txtAddress_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAddress.KeyPress
        If e.KeyChar = " " AndAlso txtAddress.Text.EndsWith(" ") Then
            e.KeyChar = Chr(0)
            e.Handled = True
            Exit Sub
        End If
        Select Case e.KeyChar
            Case Convert.ToChar(Keys.Enter)

            Case Convert.ToChar(Keys.Back)
                e.Handled = False

            Case Convert.ToChar(Keys.Capital Or Keys.RButton)
                e.Handled = Not Clipboard.GetText().All(Function(c) validchars6.Contains(c))
            Case Else
                e.Handled = Not validchars6.Contains(e.KeyChar)
        End Select
    End Sub


    Private Sub txtMobileNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMobileNo.KeyPress
        If Char.IsDigit(e.KeyChar) = False And e.KeyChar <> ChrW(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtStudID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStudID.KeyPress
        If Char.IsDigit(e.KeyChar) = False And e.KeyChar <> ChrW(8) Then
            e.Handled = True
        End If
    End Sub


    Private Sub txtID_TextChanged(sender As Object, e As EventArgs) Handles txtID.TextChanged
        Try
            If txtID.Text <> "" Then
                Dim cmd As New SqlCommand("Select * from tblStudentMasterList where Id = '" & txtID.Text & "'", con)
                Dim table As New DataTable
                Dim adpt As New SqlDataAdapter(cmd)

                adpt.Fill(table)

                'ComboBox1.DataSource = table
                'ComboBox1.ValueMember = "Department"
                'ComboBox1.DisplayMember = "Department"
                'ComboBox1.Text = table.Rows(0)(13).ToString

                Dim img() As Byte
                img = table.Rows(0)(13)
                Dim ms As New MemoryStream(img)
                PictureBox2.Image = Image.FromStream(ms)



            ElseIf txtID.Text = "" Then
                PictureBox2.Image = Nothing
            End If
        Catch ex As Exception
            PictureBox2.Image = Nothing
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cbCourse.SelectedIndex = -1
    End Sub

    Private Sub txtFirstname_LostFocus(sender As Object, e As EventArgs) Handles txtFirstname.LostFocus
        txtFirstname.Text = StrConv(txtFirstname.Text, vbProperCase)
    End Sub
    Private Sub txtLastname_LostFocus(sender As Object, e As EventArgs) Handles txtLastname.LostFocus
        txtLastname.Text = StrConv(txtLastname.Text, vbProperCase)
    End Sub

    Private Sub txtGuardian_LostFocus(sender As Object, e As EventArgs) Handles txtGuardian.LostFocus
        txtGuardian.Text = StrConv(txtGuardian.Text, vbProperCase)
    End Sub

    Private Sub txtAddress_LostFocus(sender As Object, e As EventArgs) Handles txtAddress.LostFocus
        txtAddress.Text = StrConv(txtAddress.Text, vbProperCase)
    End Sub


    Private Sub cbDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDepartment.SelectedIndexChanged
        loadYearLevel()
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        PictureBox2.Image = Nothing
    End Sub

    Private Sub cbYearLevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbYearLevel.SelectedIndexChanged

    End Sub
End Class