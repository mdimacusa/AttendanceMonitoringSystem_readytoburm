Imports System.Data.SqlClient
Public Class CourseMaintenance

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try



            Dim dialog As DialogResult
            dialog = MessageBox.Show("Do you want to Close this?", "", MessageBoxButtons.YesNo)
            If dialog = DialogResult.No Then

                Beep()
                MsgBox("Cancel!!")



            Else
                CourseList.ListView1.SelectedItems.Clear()

                Beep()

                Me.Close()


            End If


        Catch ex As Exception
            msgerror(Err.Description)
        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtCourseName.Text = "" Then
            msgerror("Invalid, Course name is empty")
        ElseIf (txtCourseName.Text.EndsWith(" ")) Then
            msgerror("Invalid format Course Name  " + txtCourseName.Text + "''Space''")
        ElseIf txtCourseName.TextLength < 5 Then
            msgerror("Invalid, Coursename must be 5 to 50 characters")
        ElseIf txtID.Text = "" Then
            InsertStudent()
        ElseIf txtID.Text <> "" Then
            UpdateStudent()
        End If
    End Sub

    Private Function InsertStudent()
        Try
            con.Close()
            con.Open()

            connect()

            Dim cmd As New SqlCommand("Select * from tblCourse where CourseName = @CN and ID <> '" & txtID.Text & "'", con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@CN", txtCourseName.Text)
            cmd.ExecuteNonQuery()
            dt = New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dt, "a")
            If dt.Tables("a").Rows.Count <> 0 Then
                msgerror("Course Name is Already Exist")


            Else
                If MsgBox("Are you sure you want to add this data?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    connect()
                    cmd.CommandText = " Insert INTO tblCourse(CourseName) VALUES (@CN)"
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@CN", txtCourseName.Text)

                    Dim a As Integer = cmd.ExecuteNonQuery()
                    AuditTrail("Course Maintenace ", "Add", "Course name: " + txtCourseName.Text)
                    If a > 0 Then

                        msginfo(" Successfully Added")
                        CourseList.list()
                        txtCourseName.Text = ""
                        txtID.Text = ""
                    End If


                End If



            End If

        Catch ex As Exception

        End Try



        Return Nothing
    End Function
    Private Function UpdateStudent()
        Try

            con.Close()
            con.Open()

            connect()

            Dim cmd As New SqlCommand("Select * from tblCourse where CourseName = @SN and ID <> '" & txtID.Text & "'", con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@SN", txtCourseName.Text)
            cmd.ExecuteNonQuery()
            dt = New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dt, "a")
            If dt.Tables("a").Rows.Count <> 0 Then
                msgerror("Course Name is Already Exist")


            Else

                Try
                    If MsgBox("Are you sure you want to update this data?", MsgBoxStyle.YesNo) = vbYes Then
                        con.Close()
                        con.Open()
                        connect()
                        With cmd
                            .Connection = con
                            .CommandText = "Update tblCourse SET  CourseName = @CN where Id = '" & txtID.Text & "'"
                            .Parameters.Clear()
                            .Parameters.AddWithValue("@CN", txtCourseName.Text)



                        End With


                        Dim a As Integer = cmd.ExecuteNonQuery()
                        AuditTrail("Course Maintenace ", "Update", "Course name: " + txtCourseName.Text)
                        If a > 0 Then
                            UpdateCourseSML()
                            UpdateCourseER()
                            UpdateCourseAR()
                            MsgBox("Updated Successfully.")
                            CourseList.list()

                            txtCourseName.Text = ""
                            txtID.Text = ""
                            Me.Close()
                            CourseList.ListView1.SelectedItems.Clear()
                        Else
                            MsgBox("Failed to Update.")

                        End If

                    End If
                Catch ex As Exception
                    msgerror(Err.Description)
                End Try



            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try


        Return Nothing
    End Function
    'Private Function UpdateCourselSAR()
    '    con.Close()
    '    con.Open()
    '    connect()
    '    With cmd
    '        .Connection = con
    '        .CommandText = "Update tblSmsAnnouncementRecord SET  Course = @C where Yearlevel = '" & txtSubCourse.Text & "'"
    '        .Parameters.Clear()
    '        .Parameters.AddWithValue("@YL", txtCourseName.Text)
    '    End With


    '    Dim a As Integer = cmd.ExecuteNonQuery()
    '    If a > 0 Then
    '        SmsAnnouncementRecord.list()
    '    End If
    '    Return Nothing
    'End Function
    Private Function UpdateCourseSML()
        con.Close()
        con.Open()
        connect()
        With cmd
            .Connection = con
            .CommandText = "Update tblStudentMasterList SET  Course = @C where Course = '" & txtSubCourse.Text & "'"
            .Parameters.Clear()
            .Parameters.AddWithValue("@C", txtCourseName.Text)
        End With


        Dim a As Integer = cmd.ExecuteNonQuery()
        If a > 0 Then
            StudentMasterList.list()
        End If
        Return Nothing
    End Function
    Private Function UpdateCourseER()
        con.Close()
        con.Open()
        connect()
        With cmd
            .Connection = con
            .CommandText = "Update tblEventRecord SET  Course = @C where Course = '" & txtSubCourse.Text & "'"
            .Parameters.Clear()
            .Parameters.AddWithValue("@C", txtCourseName.Text)
        End With


        Dim a As Integer = cmd.ExecuteNonQuery()
        If a > 0 Then
            EventRecord.list()
        End If
        Return Nothing
    End Function
    Private Function UpdateCourseAR()
        con.Close()
        con.Open()
        connect()
        With cmd
            .Connection = con
            .CommandText = "Update tblAttendance SET  Course = @C where Course = '" & txtSubCourse.Text & "'"
            .Parameters.Clear()
            .Parameters.AddWithValue("@C", txtCourseName.Text)
        End With


        Dim a As Integer = cmd.ExecuteNonQuery()
        If a > 0 Then
            AttendanceRecord.list()
        End If
        Return Nothing
    End Function

    Private Sub CourseMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtCourseName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCourseName.KeyDown
        If txtCourseName.Text <> "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = False
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        ElseIf txtCourseName.Text = "" Then
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

    Private Sub txtCourseName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCourseName.KeyPress
        If e.KeyChar = " " AndAlso txtCourseName.Text.EndsWith(" ") Then
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

    Private Sub txtCourseName_LostFocus(sender As Object, e As EventArgs) Handles txtCourseName.LostFocus
        txtCourseName.Text = StrConv(txtCourseName.Text, vbProperCase)
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub txtCourseName_TextChanged(sender As Object, e As EventArgs) Handles txtCourseName.TextChanged

    End Sub
End Class