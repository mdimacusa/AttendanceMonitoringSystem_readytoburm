Imports System.Data.SqlClient
Public Class DepartmentList

    Private Sub btnADD_Click(sender As Object, e As EventArgs) Handles btnADD.Click
        Try
            DepartmentMaintenance.txtID.Clear()
            DepartmentMaintenance.txtDepartment.Clear()
            DepartmentMaintenance.ShowDialog()
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub

    Private Sub tbnEDIT_Click(sender As Object, e As EventArgs) Handles tbnEDIT.Click
        Try
            If ListView1.SelectedItems.Count <> 0 Then
                DepartmentMaintenance.txtID.Text = ListView1.SelectedItems(0).Text
                DepartmentMaintenance.txtDepartment.Text = ListView1.SelectedItems(0).SubItems(1).Text
                DepartmentMaintenance.txtSubDepartment.Text = ListView1.SelectedItems(0).SubItems(1).Text
                DepartmentMaintenance.ShowDialog()

            ElseIf Me.ListView1.SelectedItems.Count < 1 Then
                msgerror("Please select item to update")
                ListView1.Enabled = True
                Exit Sub
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub

    Private Sub YearLevel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            list()
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub
    Sub list()
        Try
            con.Close()
            con.Open()
            ListView1.Items.Clear()
            cmd.Connection = con
            cmd.CommandText = "SELECT * FROM tblDepartment"
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
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub

    Private Sub tbnDELETE_Click(sender As Object, e As EventArgs) Handles tbnDELETE.Click
        Try
            If checkDepartmentSML() = True Then
                msgerror("Cannot removed this data, Department exists in student master list")
                txtDepartment.Text = ""
                ListView1.SelectedItems.Clear()
            ElseIf checkDepartmentATT() = True Then
                msgerror("Cannot removed this data, Department exists in Attendance Record")
                txtDepartment.Text = ""
                ListView1.SelectedItems.Clear()
            ElseIf checkDepartmentER() = True Then
                msgerror("Cannot removed this data, Department exists in Event Attendance Record")
                txtDepartment.Text = ""
                ListView1.SelectedItems.Clear()
            ElseIf Me.ListView1.SelectedItems.Count < 1 Then
                msgerror("Please Select Item to Remove")
            Else
                DeleteDepartment()
                Exit Sub
            End If
            If ListView1.SelectedItems.Count <> 0 Then
                CourseMaintenance.txtID.Text = ListView1.SelectedItems(0).Text
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub
    Public Sub DeleteDepartment()
        Try
            If ListView1.SelectedItems.Count <> 0 Then
                DepartmentMaintenance.txtID.Text = ListView1.SelectedItems(0).Text

                con.Close()
                con.Open()
                Dim ID As String
                ID = ListView1.SelectedItems(0).SubItems(0).Text
                If MsgBox("Are you sure to delete this data?", vbYesNo) = MsgBoxResult.Yes Then
                    cmd.Connection = con
                    cmd.CommandText = "DELETE tblDepartment WHERE ID='" & ID & "'"
                    Dim i As Integer = cmd.ExecuteNonQuery()
                    AuditTrail("Department Maintenace ", "Delete", "Department: " + ListView1.SelectedItems(0).SubItems(1).Text)
                    If i > 0 Then
                        txtDepartment.Text = ""
                        MsgBox("Department Removed.")
                        list()
                    End If
                ElseIf MsgBoxResult.No Then
                    DepartmentMaintenance.txtID.Clear()
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
    Public Function checkDepartmentSML()
        Try
            con.Close()
            con.Open()
            connect()
            Dim adp As New SqlDataAdapter
            Dim dt As New DataTable
            Dim query As String = "SELECT * FROM tblStudentMasterList WHERE Department = @DM"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@DM", txtDepartment.Text)
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
    Public Function checkDepartmentATT()
        Try
            con.Close()
            con.Open()
            connect()
            Dim adp As New SqlDataAdapter
            Dim dt As New DataTable
            Dim query As String = "SELECT * FROM tblAttendance WHERE Department = @DM"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@DM", txtDepartment.Text)
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
    Public Function checkDepartmentER()
        Try
            con.Close()
            con.Open()
            connect()
            Dim adp As New SqlDataAdapter
            Dim dt As New DataTable
            Dim query As String = "SELECT * FROM tblEventRecord WHERE Department = @DM"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@DM", txtDepartment.Text)
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try

            Beep()
            Me.Close()
            MainForm.Show()

        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub


    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count <> 0 Then
            txtDepartment.Text = ListView1.SelectedItems(0).SubItems(1).Text
        End If
    End Sub
End Class