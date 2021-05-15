Imports System.Data.SqlClient
Public Class DepartmentMaintenance
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim dialog As DialogResult
            dialog = MessageBox.Show("Do you want to Close this?", "", MessageBoxButtons.YesNo)
            If dialog = DialogResult.No Then
                Beep()
                MsgBox("Cancel!!")
            Else
                DepartmentList.ListView1.SelectedItems.Clear()
                Beep()
                Me.Close()
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub
    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click
        If txtDepartment.Text = "" Then
            msgerror("Invalid, Department is empty")
        ElseIf (txtDepartment.Text.EndsWith(" ")) Then
            msgerror("Invalid format Department " + txtDepartment.Text + "''Space''")
        ElseIf txtDepartment.TextLength < 3 Then
            msgerror("Invalid, Department must be 5 to 50 characters")
        ElseIf txtID.Text = "" Then
            InsertStudent()
        ElseIf txtID.Text <> "" Then
            UpdateStudent()
        End If
    End Sub
    Private Function InsertStudent()
        Try
            If txtDepartment.Text = "All" Then
                msgerror("Invalid to add " + "'" + txtDepartment.Text + "'")
            Else
                con.Close()
                con.Open()
                connect()
                Dim cmd As New SqlCommand("Select * from tblDepartment where Department = @DM and ID <> '" & txtID.Text & "'", con)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@DM", txtDepartment.Text)
                cmd.ExecuteNonQuery()
                dt = New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dt, "a")
                If dt.Tables("a").Rows.Count <> 0 Then
                    msgerror("Department is Already Exist")
                Else
                    If MsgBox("Are you sure you want to add this data?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                        connect()
                        cmd.CommandText = " Insert INTO tblDepartment(Department) VALUES (@DM)"
                        cmd.Parameters.Clear()
                        cmd.Parameters.AddWithValue("@DM", txtDepartment.Text)
                        cmd.ExecuteNonQuery()
                        AuditTrail("Department Maintenace ", "Add", "Department: " + txtDepartment.Text)
                        msginfo(" Successfully Added")
                        DepartmentList.list()
                        txtDepartment.Text = ""
                        txtID.Text = ""
                        con.Close()
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
        Return Nothing
    End Function
    Private Function UpdateStudent()
        Try
            If txtAll.Text = txtDepartment.Text Then
                msgerror("Invalid to update " + txtSubDepartment.Text + " to " + txtDepartment.Text)
            Else
                con.Close()
                con.Open()
                connect()
                Dim cmd As New SqlCommand("Select * from tblDepartment where Department = @DM and ID <> '" & txtID.Text & "'", con)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@DM", txtDepartment.Text)
                cmd.ExecuteNonQuery()
                dt = New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dt, "a")
                If dt.Tables("a").Rows.Count <> 0 Then
                    msgerror("Department is Already Exist")
                Else
                    If MsgBox("Are you sure you want to update this data?", MsgBoxStyle.YesNo) = vbYes Then
                        con.Close()
                        con.Open()
                        connect()
                        With cmd
                            .Connection = con
                            .CommandText = "Update tblDepartment SET  Department = @DM where Id = '" & txtID.Text & "'"
                            .Parameters.Clear()
                            .Parameters.AddWithValue("@DM", txtDepartment.Text)
                            .ExecuteNonQuery()
                        End With
                        AuditTrail("Department Maintenace ", "Update", "Department: " + txtDepartment.Text)
                        UpdateDepartmentSML()
                        UpdateDepartmentER()
                        UpdateDepartmentAR()
                        UpdateDepartmentYL()
                        UpdateDepartEvent()
                        MsgBox("Updated Successfully.")
                        DepartmentList.list()
                        EventList.list()
                        AttendanceRecord.list()
                        EventRecord.list()
                        StudentMasterList.list()
                        YearLevel.list()
                        txtDepartment.Text = ""
                        txtID.Text = ""
                        Me.Close()
                        DepartmentList.ListView1.SelectedItems.Clear()
                    Else
                        MsgBox("Failed to Update.")
                    End If
                End If
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
    'Private Function UpdateDepartER()
    '    con.Close()
    '    con.Open()
    '    connect()
    '    With cmd
    '        .Connection = con
    '        .CommandText = "Update tblEventRecord SET  Department = @DM where Department = '" & txtSubDepartment.Text & "'"
    '        .Parameters.Clear()
    '        .Parameters.AddWithValue("@DM", txtDepartment.Text)
    '    End With


    '    Dim a As Integer = cmd.ExecuteNonQuery()
    '    If a > 0 Then
    '        EventRecord.list()
    '    End If
    '    Return Nothing
    'End Function
    Private Function UpdateDepartEvent()
        con.Close()
        con.Open()
        connect()
        With cmd
            .Connection = con
            .CommandText = "Update tblEvent SET  Department = @DM where Department = '" & txtSubDepartment.Text & "'"
            .Parameters.Clear()
            .Parameters.AddWithValue("@DM", txtDepartment.Text)
        End With


        Dim a As Integer = cmd.ExecuteNonQuery()
        If a > 0 Then
            EventRecord.list()
        End If
        Return Nothing
    End Function
    Private Function UpdateDepartmentSML()
        con.Close()
        con.Open()
        connect()
        With cmd
            .Connection = con
            .CommandText = "Update tblStudentMasterList SET  Department = @DM where Department = '" & txtSubDepartment.Text & "'"
            .Parameters.Clear()
            .Parameters.AddWithValue("@DM", txtDepartment.Text)
        End With


        Dim a As Integer = cmd.ExecuteNonQuery()
        If a > 0 Then
            StudentMasterList.list()
        End If
        Return Nothing
    End Function
    Private Function UpdateDepartmentER()
        con.Close()
        con.Open()
        connect()
        With cmd
            .Connection = con
            .CommandText = "Update tblEventRecord SET  Department = @DM where Department = '" & txtSubDepartment.Text & "'"
            .Parameters.Clear()
            .Parameters.AddWithValue("@DM", txtDepartment.Text)
        End With


        Dim a As Integer = cmd.ExecuteNonQuery()
        If a > 0 Then
            EventRecord.list()
        End If
        Return Nothing
    End Function
    Private Function UpdateDepartmentAR()
        con.Close()
        con.Open()
        connect()
        With cmd
            .Connection = con
            .CommandText = "Update tblAttendance SET  Department = @DM where Department = '" & txtSubDepartment.Text & "'"
            .Parameters.Clear()
            .Parameters.AddWithValue("@DM", txtDepartment.Text)
        End With


        Dim a As Integer = cmd.ExecuteNonQuery()
        If a > 0 Then
            AttendanceRecord.list()
        End If
        Return Nothing
    End Function
    Private Function UpdateDepartmentYL()
        con.Close()
        con.Open()
        connect()
        With cmd
            .Connection = con
            .CommandText = "Update tblYearlevel SET  Department = @DM where Department = '" & txtSubDepartment.Text & "'"
            .Parameters.Clear()
            .Parameters.AddWithValue("@DM", txtDepartment.Text)
        End With


        Dim a As Integer = cmd.ExecuteNonQuery()
        If a > 0 Then
            AttendanceRecord.list()
        End If
        Return Nothing
    End Function



    Private Sub txtDepartment_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDepartment.KeyDown
        If txtDepartment.Text <> "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = False
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        ElseIf txtDepartment.Text = "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        End If
        If (e.Control AndAlso e.KeyCode = Keys.S) Then
            btnSAVE.PerformClick()
        End If

    End Sub

    Private Sub txtDepartment_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDepartment.KeyPress
        If e.KeyChar = " " AndAlso txtDepartment.Text.EndsWith(" ") Then
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

    Private Sub txtDepartment_LostFocus(sender As Object, e As EventArgs) Handles txtDepartment.LostFocus
        txtDepartment.Text = StrConv(txtDepartment.Text, vbProperCase)
    End Sub


End Class