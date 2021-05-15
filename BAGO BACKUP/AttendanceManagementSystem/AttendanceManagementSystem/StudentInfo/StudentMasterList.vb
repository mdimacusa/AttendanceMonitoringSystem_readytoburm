Imports System.Data.SqlClient
'Imports System.Net.Mime.MediaTypeNames
'Imports System.Windows.Forms
Imports System.IO
'Imports System.Data.OleDb
'Imports System.Net.Mime
'Imports Microsoft.Office.Interop.Excel
Imports System.Text.RegularExpressions

Public Class StudentMasterList

 
    Dim conn As SqlConnection
    Dim dta As SqlDataAdapter
    Dim dts As DataSet
    Dim excel As String
    Dim OpenFileDialog As New OpenFileDialog

    Sub studentClear()
        StudentEntry.txtStudID.Text = ""
        StudentEntry.txtLastname.Text = ""
        StudentEntry.txtFirstname.Text = ""
        StudentEntry.txtMI.Text = ""
        StudentEntry.cbGender.SelectedIndex = -1
        StudentEntry.cbYearLevel.SelectedIndex = -1
        StudentEntry.cbCourse.SelectedIndex = -1
        StudentEntry.txtGuardian.Text = ""
        StudentEntry.txtMobileNo.Text = ""
        StudentEntry.txtAddress.Text = ""
        StudentEntry.PictureBox2.Image = Nothing
    End Sub
    Sub loadDepartment()
        Try
            con.Close()
            con.Open()
            Dim Cmd As New SqlClient.SqlCommand("SELECT DISTINCT Department FROM tblStudentMasterList", con)
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        studentClear()
        If txtID.Text <> "" Then
            msgerror("Please Remove Image from PictureBox")
        ElseIf txtID.Text = "" Then
            StudentEntry.ShowDialog()
            studentClear()
            StudentEntry.clear()
            StudentEntry.clear1()
        End If

    End Sub
    Sub loadYearLevel()
        Try
            con.Close()
            con.Open()
            Dim cmd As New SqlClient.SqlCommand("SELECT DISTINCT Yearlevel FROM tblStudentMasterList where Department = '" + cbDepartment.Text + "'", con)
            Dim reader As SqlClient.SqlDataReader
            reader = cmd.ExecuteReader

            cbYearLevel.Items.Clear()
            While reader.Read

                cbYearLevel.Items.Add(reader("Yearlevel"))
            End While



        Catch ex As Exception
            msgerror(Err.Description)
            con.Close()
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
    Private Sub StudentMasterList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        list()
        MainForm.totalStudent()
        loadDepartment()
        loadYearLevel()
        loadCourse()
        txtID.Text = ""
        cbDepartment.SelectedIndex = -1
        cbYearLevel.SelectedIndex = -1
        cbCourse.SelectedIndex = -1
        txtStudentID.Text = ""
        PictureBox2.Image = Nothing
        listTransform()
    End Sub
    Sub listTransform()
        Try
            For Each item As ListViewItem In Me.ListView1.Items
                If (item.SubItems(11).Text) = "" Then
                    item.SubItems(11).Text = "N/A"
                    Dim NewIt As New ListViewItem
                    NewIt.Text = item.Text
                    ' ListView1.Items.RemoveAt(item.Index)
                    NewIt.SubItems.Add(NewIt.Text)
                End If
            Next

        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub
    Sub list()
        con.Close()
        con.Open()
        ListView1.Items.Clear()
        cmd.Connection = con
        cmd.CommandText = "SELECT * FROM tblStudentMasterList ORDER BY Lastname ASC"
        Dim dataread3 As SqlDataReader = cmd.ExecuteReader

        Dim DelID As Integer
        Dim DeliveryID As String
        Dim ProductName As String
        Dim Description As String
        Dim Original As String
        Dim Pieces As String
        Dim TotalPrice As String
        Dim DeliveryID1 As String
        Dim ProductName1 As String
        Dim Description1 As String
        Dim Original1 As String
        Dim Pieces1 As String
        Dim TotalPrice1 As String
        Dim Depart As String
        'Dim quesid As String
        'Dim Ulevel As String
        ''''DATABASE COLUMN''''''''
        While dataread3.Read()
            DelID = dataread3.GetValue(0)
            DeliveryID = dataread3.GetValue(1)
            ProductName = dataread3.GetValue(2)
            Description = dataread3.GetValue(3)
            Original = dataread3.GetValue(4)
            Pieces = dataread3.GetValue(5)
            TotalPrice = dataread3.GetValue(6)
            DeliveryID1 = dataread3.GetValue(7)
            ProductName1 = dataread3.GetValue(8)
            Description1 = dataread3.GetValue(9)
            Original1 = dataread3.GetValue(10)
            Pieces1 = dataread3.GetValue(11)
            TotalPrice1 = dataread3.GetValue(12)
            Depart = dataread3.GetValue(14)
            'Ulevel = dataread3.GetValue(14)
            '''''''LISTVIEW COLUMN''''''''
            Dim arr(15) As String
            Dim itm As ListViewItem

            arr(0) = "" & DelID & ""
            arr(1) = "" & DeliveryID & ""
            arr(2) = "" & ProductName & ""
            arr(3) = "" & Description & ""
            arr(4) = "" & Original & ""
            arr(5) = "" & Pieces & ""
            arr(6) = "" & TotalPrice & ""
            arr(7) = "" & DeliveryID1 & ""
            arr(8) = "" & ProductName1 & ""
            arr(9) = "" & Description1 & ""
            arr(10) = "" & Original1 & ""
            arr(11) = "" & Pieces1 & ""
            arr(12) = "" & TotalPrice1 & ""
            arr(13) = "" & Depart & ""
            'arr(14) = "" & Ulevel & ""

            itm = New ListViewItem(arr)
            ListView1.Items.Add(itm)

        End While
        con.Close()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            'Dim dialog As DialogResult
            'dialog = MessageBox.Show("Do you want to Close this?", "", MessageBoxButtons.YesNo)
            'If dialog = DialogResult.No Then
            '    Beep()
            '    MsgBox("Cancel!!")
            'Else
            Beep()
            Me.Close()
            MainForm.Show()
            '   End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim ExcelApp As Object, ExcelBook As Object
            Dim ExcelSheet As Object
            Dim i As Integer
            Dim j As Integer
            'create object of excel
            ExcelApp = CreateObject("Excel.Application")
            ExcelBook = ExcelApp.WorkBooks.Add
            ExcelSheet = ExcelBook.WorkSheets(1)
            With ExcelSheet
                For i = 1 To Me.ListView1.Items.Count
                    .cells(i, 1) = Me.ListView1.Items(i - 1).Text
                    For j = 1 To ListView1.Columns.Count - 1
                        .cells(i, j + 1) = Me.ListView1.Items(i - 1).SubItems(j).Text
                    Next
                Next
            End With
            ExcelApp.Visible = True
            ExcelSheet = Nothing
            ExcelBook = Nothing
            ExcelApp = Nothing
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub



    Private Sub Execute_Local(p1 As String)
        Throw New NotImplementedException
    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try

            ImportStudentMasterList.ShowDialog()
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub

    Private Sub txtID_TextChanged(sender As Object, e As EventArgs) Handles txtID.TextChanged
        Try
            con.Close()
            con.Open()
            If txtID.Text <> "" And PictureBox2.Image IsNot Nothing Then
                Dim cmd As New SqlCommand("Select * from tblStudentMasterList where Id = '" & txtID.Text & "'", con)
                Dim table As New DataTable
                Dim adpt As New SqlDataAdapter(cmd)
                adpt.Fill(table)
                Dim img() As Byte
                img = table.Rows(0)(13)
                Dim ms As New MemoryStream(img)
                StudentEntry.PictureBox2.Image = Image.FromStream(ms)
              
            ElseIf txtID.Text = "" Then
                StudentEntry.PictureBox2.Image = Nothing
            End If
            con.Close()
        Catch ex As Exception
            'msgerror(Err.Description)
            StudentEntry.PictureBox2.Image = Nothing
        End Try
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        Try
            con.Close()
            con.Open()
            txtID.Text = ListView1.SelectedItems(0).Text
            If txtID.Text <> "" Then

                Dim cmd As New SqlCommand("Select * from tblStudentMasterList where Id = '" & txtID.Text & "'", con)
                Dim table As New DataTable
                Dim adpt As New SqlDataAdapter(cmd)
                adpt.Fill(table)
                'If table("Photo") IsNot System.DBNull Then
                Dim img() As Byte
                img = table.Rows(0)(13)
                Dim ms As New MemoryStream(img)
                PictureBox2.Image = Image.FromStream(ms)
                'End If


            ElseIf txtID.Text = "" Then
                PictureBox2.Image = Nothing
            End If
            con.Close()
        Catch ex As Exception
            PictureBox2.Image = Nothing
        End Try
    End Sub
    Sub View()
        Try
            con.Close()
            con.Open()
            txtID.Text = ListView1.SelectedItems(0).Text
            If txtID.Text <> "" Then
                Dim cmd As New SqlCommand("Select * from tblStudentMasterList where Id = '" & txtID.Text & "'", con)
                Dim table As New DataTable
                Dim adpt As New SqlDataAdapter(cmd)

                adpt.Fill(table)
                Dim img() As Byte
                img = table.Rows(0)(13)
                Dim ms As New MemoryStream(img)
                PictureBox2.Image = Image.FromStream(ms)

                
            ElseIf txtID.Text = "" Then
                PictureBox2.Image = Nothing
            End If
            con.Close()
        Catch ex As Exception
            PictureBox2.Image = Nothing
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If ListView1.SelectedItems.Count <> 0 Then
                txtID.Text = ListView1.SelectedItems(0).Text
            ElseIf txtID.Text = "" Then
                msgerror("Please Select Item to Remove")
                Exit Sub
            End If
            Try
                Try
                    con.Close()
                    con.Open()
                    If MsgBox("Are you sure to delete this data?", vbYesNo) = MsgBoxResult.Yes Then

                        Dim ID As String
                        ID = ListView1.SelectedItems(0).SubItems(0).Text

                        cmd.Connection = con
                        cmd.CommandText = "DELETE tblStudentMasterList WHERE ID='" & ID & "'"

                        Dim i As Integer = cmd.ExecuteNonQuery()
                        AuditTrail("Student MasterList ", "Delete", "User Info: " + ListView1.SelectedItems(0).SubItems(1).Text + "," + ListView1.SelectedItems(0).SubItems(2).Text + "," + ListView1.SelectedItems(0).SubItems(3).Text + "," + ListView1.SelectedItems(0).SubItems(6).Text + "," + ListView1.SelectedItems(0).SubItems(9).Text + "|Birthdate :" + ListView1.SelectedItems(0).SubItems(5).Text + "|Department : " + ListView1.SelectedItems(0).SubItems(13).Text + "|Yearlevel : " + ListView1.SelectedItems(0).SubItems(7).Text)
                        If i > 0 Then
                            MsgBox("Student Removed.")


                            list()
                            txtID.Text = ""
                        End If
                    ElseIf MsgBoxResult.No Then
                        txtID.Clear()
                        PictureBox2.Image = Nothing
                        MsgBox("Canceled", MsgBoxStyle.Information)
                    End If
                Catch ex As Exception
                    msgerror(Err.Description)
                End Try

            Catch ex As Exception
                msgerror(Err.Description)
            End Try
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub


    Sub Search()
        Try
            con.Close()
            con.Open()
            Dim cmd As SqlCommand
            Dim dr As SqlDataReader
            Dim sql As String


            sql = "Select * from tblStudentMasterList where StudentID Like '%" & txtStudentID.Text & "%' AND YearLevel Like '%" & cbYearLevel.Text & "%' AND Course Like '%" & cbCourse.Text & "%'AND Department Like '%" & cbDepartment.Text & "%'"

            cmd = New SqlCommand


            With cmd
                .Connection = con
                .CommandText = sql
                dr = .ExecuteReader()
            End With
            ListView1.Items.Clear()
            Do While dr.Read = True
                Dim list = ListView1.Items.Add(dr(0))
                list.SubItems.Add(dr(1))
                list.SubItems.Add(dr(2))
                list.SubItems.Add(dr(3))
                list.SubItems.Add(dr(4))
                list.SubItems.Add(dr(5))
                list.SubItems.Add(dr(6))
                list.SubItems.Add(dr(7))
                list.SubItems.Add(dr(8))
                list.SubItems.Add(dr(9))
                list.SubItems.Add(dr(10))
                list.SubItems.Add(dr(11))
                list.SubItems.Add(dr(12))
                list.SubItems.Add(dr(14))
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try


    End Sub
    'Sub SearchYearLevel()
    '    Try
    '        con.Close()
    '        con.Open()
    '        Dim cmd As SqlCommand
    '        Dim dr As SqlDataReader
    '        Dim sql As String


    '        sql = "Select * from tblStudentMasterList where Yearlevel Like '%" & cbYearLevel.Text & "%'"
    '        'sql = "SELECT * FROM tblStudentMasterList WHERE [Lastname] like '%{2}%' AND [Yearlevel] like '%{7}%' AND [Course] like '%{11}%'", Me.txtLastname.text, Me.cbYearLevel.text,me.cbCourse.text
    '        cmd = New SqlCommand


    '        With cmd
    '            .Connection = con
    '            .CommandText = sql
    '            dr = .ExecuteReader()
    '        End With
    '        ListView1.Items.Clear()
    '        Do While dr.Read = True
    '            Dim list = ListView1.Items.Add(dr(0))
    '            list.SubItems.Add(dr(1))
    '            list.SubItems.Add(dr(2))
    '            list.SubItems.Add(dr(3))
    '            list.SubItems.Add(dr(4))
    '            list.SubItems.Add(dr(5))
    '            list.SubItems.Add(dr(6))
    '            list.SubItems.Add(dr(7))
    '            list.SubItems.Add(dr(8))
    '            list.SubItems.Add(dr(9))
    '            list.SubItems.Add(dr(10))
    '            list.SubItems.Add(dr(11))
    '            list.SubItems.Add(dr(12))
    '        Loop
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        con.Close()
    '    End Try


    'End Sub
    'Sub SearchCourse()
    '    Try
    '        con.Close()
    '        con.Open()
    '        Dim cmd As SqlCommand
    '        Dim dr As SqlDataReader
    '        Dim sql As String


    '        sql = "Select * from tblStudentMasterList where Course Like '%" & cbCourse.Text & "%'"
    '        'sql = "SELECT * FROM tblStudentMasterList WHERE [Lastname] like '%{2}%' AND [Yearlevel] like '%{7}%' AND [Course] like '%{11}%'", Me.txtLastname.text, Me.cbYearLevel.text,me.cbCourse.text
    '        cmd = New SqlCommand


    '        With cmd
    '            .Connection = con
    '            .CommandText = sql
    '            dr = .ExecuteReader()
    '        End With
    '        ListView1.Items.Clear()
    '        Do While dr.Read = True
    '            Dim list = ListView1.Items.Add(dr(0))
    '            list.SubItems.Add(dr(1))
    '            list.SubItems.Add(dr(2))
    '            list.SubItems.Add(dr(3))
    '            list.SubItems.Add(dr(4))
    '            list.SubItems.Add(dr(5))
    '            list.SubItems.Add(dr(6))
    '            list.SubItems.Add(dr(7))
    '            list.SubItems.Add(dr(8))
    '            list.SubItems.Add(dr(9))
    '            list.SubItems.Add(dr(10))
    '            list.SubItems.Add(dr(11))
    '            list.SubItems.Add(dr(12))
    '        Loop
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        con.Close()
    '    End Try


    'End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            '  If txtLastname.Text <> "" Then
            ' Search()
            'ElseIf cbYearLevel.Text <> "" Then
            '    SearchYearLevel()
            'ElseIf cbCourse.Text <> "" Then
            '    SearchCourse()
            '  End If

            Search()
            If ListView1.Items.Count = 0 Then
                msginfo("No Data Found")
                txtID.Text = ""
                PictureBox2.Image = Nothing
                txtStudentID.Text = ""
                cbDepartment.SelectedIndex =-1
                cbYearLevel.SelectedIndex = -1
                cbCourse.SelectedIndex = -1
                list()
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            txtID.Text = ""
            PictureBox2.Image = Nothing
            txtStudentID.Text = ""
            cbDepartment.SelectedIndex = -1
            cbYearLevel.SelectedIndex = -1
            cbCourse.SelectedIndex = -1
            list()
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub
    Private Function insertreport()
        connect()
        con.Close()
        con.Open()


        Try
            For Each x As ListViewItem In ListView1.Items

                connect()
                cmd.Connection = con
                cmd.CommandText = "INSERT INTO tblStudentMasterListCystalReport (StudentID,Lastname,Firstname,MI,Birthdate,Gender,Yearlevel,Course)" & _
                "VALUES (@SI,@LN,@FN,@M,@BIRTH,@GEN,@YL,@C)"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@SI", x.SubItems(1).Text)
                cmd.Parameters.AddWithValue("@LN", x.SubItems(2).Text)
                cmd.Parameters.AddWithValue("@FN", x.SubItems(3).Text)
                cmd.Parameters.AddWithValue("@M", x.SubItems(4).Text)
                cmd.Parameters.AddWithValue("@BIRTH", x.SubItems(5).Text)
                cmd.Parameters.AddWithValue("@GEN", x.SubItems(6).Text)
                cmd.Parameters.AddWithValue("@YL", x.SubItems(7).Text)
                cmd.Parameters.AddWithValue("@C", x.SubItems(11).Text)

                Dim a As Integer = cmd.ExecuteNonQuery()

                If a > 0 Then

                Else
                    MsgBox("failed")

                End If



            Next

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
        con.Close()
        Return Nothing
    End Function
    Sub ViewReport()
        Try


            Dim comm As New SqlClient.SqlCommand
            Dim da As SqlClient.SqlDataAdapter
            Dim ds As New DataSet

            comm.CommandText = "Select * from tblStudentMasterListCystalReport"
            comm.CommandType = CommandType.Text
            comm.Connection = con
            da = New SqlDataAdapter(comm)
            da.Fill(ds)
            da.Dispose()


            Dim report As New StudentMasterListReport

            report.SetDataSource(ds.Tables(0))
            '  report.SetParameterValue("Date", txtDate.Text)
            'report.SetParameterValue("Date1", DateTimePicker1.Text)
            'report.SetParameterValue("Date2", DateTimePicker2.Text)



            StudentMasterListViewer.CrystalReportViewer1.ReportSource = report
            AuditTrail("Student MasterList", "Print", "#####-############-#####")
            StudentMasterListViewer.ShowDialog()
            Deleteall()
        Catch ex As Exception
            msgerror(Err.Description)
        End Try

    End Sub
    Sub Deleteall()
        Try


            con.Close()
            con.Open()
            cmd.CommandText = "DELETE tblStudentMasterListCystalReport"
            Dim i As Integer = cmd.ExecuteNonQuery()


            'list()



            con.Close()
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub
    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click
        Try
        insertreport()
        ViewReport()
           Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Try
            If ListView1.SelectedItems.Count <> 0 Then
                txtID.Text = ListView1.SelectedItems(0).Text
                StudentEntry.txtID.Text = ListView1.SelectedItems(0).Text
                GID = ListView1.SelectedItems(0).Text
                StudentEntry.txtStudID.Text = ListView1.SelectedItems(0).SubItems(1).Text
                StudentEntry.StudentID = ListView1.SelectedItems(0).SubItems(1).Text
                StudentEntry.txtSID.Text = ListView1.SelectedItems(0).SubItems(1).Text
                StudentEntry.txtLastname.Text = ListView1.SelectedItems(0).SubItems(2).Text
                StudentEntry.txtLname.Text = ListView1.SelectedItems(0).SubItems(2).Text
                StudentEntry.txtFirstname.Text = ListView1.SelectedItems(0).SubItems(3).Text
                StudentEntry.txtFname.Text = ListView1.SelectedItems(0).SubItems(3).Text
                StudentEntry.txtMI.Text = ListView1.SelectedItems(0).SubItems(4).Text
                StudentEntry.txtBirthdate.Text = ListView1.SelectedItems(0).SubItems(5).Text
                StudentEntry.cbGender.Text = ListView1.SelectedItems(0).SubItems(6).Text
                StudentEntry.cbYearLevel.Text = ListView1.SelectedItems(0).SubItems(7).Text
                StudentEntry.Yearlevel = ListView1.SelectedItems(0).SubItems(7).Text
                StudentEntry.txtGuardian.Text = ListView1.SelectedItems(0).SubItems(8).Text
                StudentEntry.txtMobileNo.Text = ListView1.SelectedItems(0).SubItems(9).Text
                StudentEntry.ContactNo = ListView1.SelectedItems(0).SubItems(9).Text
                StudentEntry.txtAddress.Text = ListView1.SelectedItems(0).SubItems(10).Text
                StudentEntry.cbCourse.Text = ListView1.SelectedItems(0).SubItems(11).Text
                StudentEntry.Kurso = ListView1.SelectedItems(0).SubItems(11).Text
                StudentEntry.Gender = ListView1.SelectedItems(0).SubItems(6).Text
                StudentEntry.cbDepartment.Text = ListView1.SelectedItems(0).SubItems(13).Text
                StudentEntry.Department = ListView1.SelectedItems(0).SubItems(13).Text
                StudentEntry.ShowDialog()
            ElseIf txtID.Text = "" Then
                msgerror("Please Select item to update")
                ListView1.Enabled = True
                Exit Sub
            End If
        Catch ex As Exception
            PictureBox2.Image = Nothing
            StudentEntry.PictureBox2.Image = Nothing
        End Try

    End Sub


    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
      
    End Sub

    Private Sub txtStudentID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStudentID.KeyDown
        If txtStudentID.Text <> "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = False
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        ElseIf txtStudentID.Text = "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        End If
    End Sub

    Private Sub txtStudentID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStudentID.KeyPress
        If Char.IsDigit(e.KeyChar) = False And e.KeyChar <> ChrW(8) Then
            e.Handled = True
        End If
    End Sub
    Private Sub cbDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDepartment.SelectedIndexChanged
        loadYearLevel()
    End Sub
End Class