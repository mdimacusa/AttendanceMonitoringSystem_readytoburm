Imports System.Data.SqlClient
Public Class CourseList

    Private Sub btnADD_Click(sender As Object, e As EventArgs) Handles btnADD.Click
        CourseMaintenance.txtID.Clear()
        CourseMaintenance.txtCourseName.Clear()
        CourseMaintenance.ShowDialog()
    End Sub

    Private Sub btnEDIT_Click(sender As Object, e As EventArgs) Handles btnEDIT.Click


        Try
            If ListView1.SelectedItems.Count <> 0 Then
                CourseMaintenance.txtID.Text = ListView1.SelectedItems(0).Text
                CourseMaintenance.txtCourseName.Text = ListView1.SelectedItems(0).SubItems(1).Text
                CourseMaintenance.txtSubCourse.Text = ListView1.SelectedItems(0).SubItems(1).Text
                CourseMaintenance.ShowDialog()

            ElseIf Me.ListView1.SelectedItems.Count < 1 Then
                msgerror("Please Select item to update")
                ListView1.Enabled = True
                Exit Sub
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try


            Beep()
            Me.Close()
            MainForm.Show()

       

        Catch ex As Exception

        End Try

    End Sub

    Private Sub CourseList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        list()

    End Sub
    Sub list()
        con.Close()
        con.Open()
        ListView1.Items.Clear()
        cmd.Connection = con
        cmd.CommandText = "SELECT * FROM tblCourse"
        Dim dataread3 As SqlDataReader = cmd.ExecuteReader

        Dim DelID As Integer
        Dim DeliveryID As String
        

        While dataread3.Read()
            DelID = dataread3.GetValue(0)
            DeliveryID = dataread3.GetValue(1)


            Dim arr(15) As String
            Dim itm As ListViewItem

            arr(0) = "" & DelID & ""
            arr(1) = "" & DeliveryID & ""
           

            itm = New ListViewItem(arr)
            ListView1.Items.Add(itm)

        End While
        con.Close()

    End Sub

    Private Sub btnDELETE_Click(sender As Object, e As EventArgs) Handles btnDELETE.Click

        Try

            If checkCourseSML() = True Then
                msgerror("Cannot removed this data, Course name exists in student master list")
                txtCourse.Text = ""
                ListView1.SelectedItems.Clear()
            ElseIf checkCourseATT() = True Then
                msgerror("Cannot removed this data, Course name exists in Attendance Record")
                txtCourse.Text = ""
                ListView1.SelectedItems.Clear()
            ElseIf checkCourseER() = True Then
                msgerror("Cannot removed this data, Course name exists in Event Attendance Record")
                txtCourse.Text = ""
                ListView1.SelectedItems.Clear()
            ElseIf Me.ListView1.SelectedItems.Count < 1 Then
                msgerror("Please Select Item to Remove")
            Else
                DeleteCourse()
                Exit Sub
            End If
            If ListView1.SelectedItems.Count <> 0 Then
                CourseMaintenance.txtID.Text = ListView1.SelectedItems(0).Text
            End If
       
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
        '    If ListView1.SelectedItems.Count <> 0 Then
        '        Dim Course As String
        '        CourseMaintenance.txtID.Text = ListView1.SelectedItems(0).Text

        '        Course = ListView1.SelectedItems(0).SubItems(1).Text
        '        con.Close()
        '        con.Open()
        '        que = "select * from tblStudentMasterList where Course = '" & Course & "'"
        '        adp = New SqlDataAdapter(que, con)
        '        dt = New DataSet
        '        adp.Fill(dt, "a")
        '        If dt.Tables("a").Rows.Count <> 0 Then
        '            msgerror(" Cannot Remove This Data, Course Exist in StudentMasterList")
        '            ListView1.SelectedItems.Clear()
        '        Else
        '            If MsgBox("Are you sure to delete this data?", vbYesNo) = MsgBoxResult.Yes Then


        '                Dim ID As String
        '                ID = ListView1.SelectedItems(0).SubItems(0).Text
        '                cmd.Connection = con
        '                cmd.CommandText = "DELETE tblCourse WHERE ID='" & ID & "'"
        '                Dim i As Integer = cmd.ExecuteNonQuery()
        '                If i > 0 Then
        '                    MsgBox("Course Name Removed.")
        '                    list()
        '                End If


        '            ElseIf MsgBoxResult.No Then
        '                CourseMaintenance.txtID.Clear()
        '                ListView1.SelectedItems.Clear()
        '                MsgBox("Canceled", MsgBoxStyle.Information)
        '            End If

        '        End If
        '    ElseIf Me.ListView1.SelectedItems.Count < 1 Then
        '        msgerror("Please Select Item to Remove")
        '        Exit Sub
        '    End If

    End Sub
    Public Sub DeleteCourse()
        Try
            If ListView1.SelectedItems.Count <> 0 Then
                CourseMaintenance.txtID.Text = ListView1.SelectedItems(0).Text

                con.Close()
                con.Open()
                Dim ID As String
                ID = ListView1.SelectedItems(0).SubItems(0).Text
                If MsgBox("Are you sure to delete this data?", vbYesNo) = MsgBoxResult.Yes Then
                    cmd.Connection = con
                    cmd.CommandText = "DELETE tblCourse WHERE ID='" & ID & "'"
                    Dim i As Integer = cmd.ExecuteNonQuery()
                    AuditTrail("Course Maintenace ", "Delete", "Course: " + ListView1.SelectedItems(0).SubItems(1).Text)
                    If i > 0 Then
                        MsgBox("Course Name Removed.")
                        list()
                    End If
                ElseIf MsgBoxResult.No Then
                    CourseMaintenance.txtID.Clear()
                    ListView1.SelectedItems.Clear()
                    MsgBox("Canceled", MsgBoxStyle.Information)
                End If
            ElseIf Me.ListView1.SelectedItems.Count < 1 Then
                msgerror("Please Select Item to Remove")
                Exit Sub
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub
    Public Function checkCourseSML()
        Try
            con.Close()
            con.Open()
            connect()
            Dim adp As New SqlDataAdapter
            Dim dt As New DataTable
            Dim query As String = "SELECT * FROM tblStudentMasterList WHERE Course = @C"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@C", txtCourse.Text)
            With adp
                .SelectCommand = cmd
                .Fill(dt)
            End With
            If dt.Rows.Count >= 1 Then
                Return True
                Exit Function
            End If
        Catch ex As Exception
        End Try
        Return Nothing
    End Function
    Public Function checkCourseATT()
        Try
            con.Close()
            con.Open()
            connect()
            Dim adp As New SqlDataAdapter
            Dim dt As New DataTable
            Dim query As String = "SELECT * FROM tblAttendance WHERE Course = @C"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@C", txtCourse.Text)
            With adp
                .SelectCommand = cmd
                .Fill(dt)
            End With
            If dt.Rows.Count >= 1 Then
                Return True
                Exit Function
            End If
        Catch ex As Exception
        End Try
        Return Nothing
    End Function
    Public Function checkCourseER()
        Try
            con.Close()
            con.Open()
            connect()
            Dim adp As New SqlDataAdapter
            Dim dt As New DataTable
            Dim query As String = "SELECT * FROM tblEventRecord WHERE Course = @C"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@C", txtCourse.Text)
            With adp
                .SelectCommand = cmd
                .Fill(dt)
            End With
            If dt.Rows.Count >= 1 Then
                Return True
                Exit Function
            End If
        Catch ex As Exception
        End Try
        Return Nothing
    End Function
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count <> 0 Then
            txtCourse.Text = ListView1.SelectedItems(0).SubItems(1).Text
        End If
    End Sub
End Class