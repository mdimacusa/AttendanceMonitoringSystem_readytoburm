Imports System.Data.SqlClient
Public Class EventRecord

    Sub listTransform()
        Try
            For Each item As ListViewItem In Me.ListView1.Items
                If (item.SubItems(6).Text) = "" Then
                    item.SubItems(6).Text = "N/A"
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
    Private Sub EventRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        list()
        DateTimePicker1.Value = Date.Today
        DateTimePicker2.Value = Date.Today
        loadDepartment()
        '  loadYearLevel()
        loadCourse()
        listTransform()
        '  txtID.Text = ""
        cbDepartment.SelectedIndex = -1
        cbYearLevel.SelectedIndex = -1
        cbCourse.SelectedIndex = -1
        txtStudentID.Text = ""
        lblProcessedBy.Text = MainForm.txtUserlevel.Text
        lblUserID.Text = MainForm.lblUserID.Text
    End Sub
    Sub loadDepartment()
        Try
            con.Close()
            con.Open()
            Dim Cmd As New SqlClient.SqlCommand("SELECT DISTINCT Department FROM tblEventRecord", con)
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
            Dim cmd As New SqlClient.SqlCommand("SELECT DISTINCT Yearlevel FROM tblEventRecord where Department = '" + cbDepartment.Text + "'", con)
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
            Dim Cmd As New SqlClient.SqlCommand("SELECT Course FROM tblEventRecord", con)
            Cmd.ExecuteNonQuery()
            Dim Datatable As New DataTable
            Dim DataAdapter As New SqlClient.SqlDataAdapter(Cmd)
            DataAdapter.Fill(Datatable)
            cbCourse.DataSource = Datatable
            cbCourse.ValueMember = "Course"
            cbCourse.DisplayMember = "Course"
        Catch ex As Exception
            msgerror(Err.Description)
            con.Close()
        End Try


    End Sub
    Sub list()
        Try

        con.Close()
        con.Open()
        ListView1.Items.Clear()
        cmd.Connection = con
            cmd.CommandText = "SELECT * FROM tblEventRecord"
        Dim dataread3 As SqlDataReader = cmd.ExecuteReader

        Dim DelID As Integer
        Dim DeliveryID As String
        Dim d2 As String
        Dim d3 As String
        Dim d4 As String
        Dim d5 As String
        Dim d6 As String
        Dim d7 As String
        Dim d8 As String
        Dim d9 As String
        Dim d10 As String
            Dim d11 As String
            Dim d12 As String
            Dim d13 As String
            Dim d14 As String
        While dataread3.Read()
            DelID = dataread3.GetValue(0)
            DeliveryID = dataread3.GetValue(1)
            d2 = dataread3.GetValue(2)
            d3 = dataread3.GetValue(3)
            d4 = dataread3.GetValue(4)
            d5 = dataread3.GetValue(5)
            d6 = dataread3.GetValue(6)
            d7 = dataread3.GetValue(7)
            d8 = dataread3.GetValue(8)
            d9 = dataread3.GetValue(9)
            d10 = dataread3.GetValue(10)
                d11 = dataread3.GetValue(11)
                d12 = dataread3.GetValue(12)
                d13 = dataread3.GetValue(13)
                d14 = dataread3.GetValue(14)

            Dim arr(15) As String
            Dim itm As ListViewItem

            arr(0) = "" & DelID & ""
            arr(1) = "" & DeliveryID & ""
            arr(2) = "" & d2 & ""
            arr(3) = "" & d3 & ""
            arr(4) = "" & d4 & ""
            arr(5) = "" & d5 & ""
            arr(6) = "" & d6 & ""
            arr(7) = "" & d7 & ""
            arr(8) = "" & d8 & ""
            arr(9) = "" & d9 & ""
            arr(10) = "" & d10 & ""
                arr(11) = "" & d11 & ""
                arr(12) = "" & d12 & ""
                arr(13) = "" & d13 & ""
                arr(14) = "" & d14 & ""

            itm = New ListViewItem(arr)
            ListView1.Items.Add(itm)

        End While
        con.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
       
                Beep()
                Me.Close()

        Catch ex As Exception
            msgerror(Err.Description)
        End Try

    End Sub
    Sub SortDate()
        Try
            Dim date1 As DateTime = DateTime.Parse(DateTimePicker1.Value)
            Dim date2 As DateTime = DateTime.Parse(DateTimePicker2.Value)

            con.Close()
            con.Open()
            ListView1.Items.Clear()
            cmd.Connection = con
            cmd.CommandText = "SELECT * FROM tblEventRecord WHERE Date >= '" & date1.Date & "' AND Date <= '" & date2.Date & "'"
            Dim dataread3 As SqlDataReader = cmd.ExecuteReader

            Dim DelID As Integer
            Dim DeliveryID As String
            Dim d2 As String
            Dim d3 As String
            Dim d4 As String
            Dim d5 As String
            Dim d6 As String
            Dim d7 As String
            Dim d8 As String
            Dim d9 As String
            Dim d10 As String
            Dim d11 As String
            Dim d12 As String
            Dim d13 As String
            Dim d14 As String
            While dataread3.Read()
                DelID = dataread3.GetValue(0)
                DeliveryID = dataread3.GetValue(1)
                d2 = dataread3.GetValue(2)
                d3 = dataread3.GetValue(3)
                d4 = dataread3.GetValue(4)
                d5 = dataread3.GetValue(5)
                d6 = dataread3.GetValue(6)
                d7 = dataread3.GetValue(7)
                d8 = dataread3.GetValue(8)
                d9 = dataread3.GetValue(9)
                d10 = dataread3.GetValue(10)
                d11 = dataread3.GetValue(11)
                d12 = dataread3.GetValue(12)
                d13 = dataread3.GetValue(13)
                d14 = dataread3.GetValue(14)
                Dim arr(15) As String
                Dim itm As ListViewItem

                arr(0) = "" & DelID & ""
                arr(1) = "" & DeliveryID & ""
                arr(2) = "" & d2 & ""
                arr(3) = "" & d3 & ""
                arr(4) = "" & d4 & ""
                arr(5) = "" & d5 & ""
                arr(6) = "" & d6 & ""
                arr(7) = "" & d7 & ""
                arr(8) = "" & d8 & ""
                arr(9) = "" & d9 & ""
                arr(10) = "" & d10 & ""
                arr(11) = "" & d11 & ""
                arr(12) = "" & d12 & ""
                arr(13) = "" & d13 & ""
                arr(14) = "" & d14 & ""
                itm = New ListViewItem(arr)
                ListView1.Items.Add(itm)

            End While
            con.Close()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If DateTimePicker1.Value > DateTimePicker2.Value Then
            ListView1.Items.Clear()
            msgerror("Please select proper date")
            list()
            listTransform()
        ElseIf DateCHECKER() = False Then
            msgerror("The date " + DateTimePicker1.Value + " cannot found in database")
        ElseIf DateCHECKER1() = False Then
            msgerror("The date " + DateTimePicker2.Value + " cannot found in database")
        ElseIf DateTimePicker1.Value < DateTimePicker2.Value Then
            If DateCHECKER() = True And DateCHECKER1() = True Then
                SortDate()
            ElseIf DateCHECKER() = False Or DateCHECKER1() = False Then
                ListView1.Items.Clear()
                msginfo("No Data Found")
                list()
                listTransform()
                Exit Sub
            ElseIf ListView1.Items.Count = 0 Then
                ListView1.Items.Clear()
                msginfo("No Data Found")
                list()
                listTransform()
                Exit Sub
            End If
        ElseIf ListView1.Items.Count = 0 Then
            ListView1.Items.Clear()
            msginfo("No Data Found")
            list()
            listTransform()
            Exit Sub
        ElseIf DateTimePicker1.Value = DateTimePicker2.Value Then
            If DateCHECKER() = True And DateCHECKER1() = True Then
                SortDate()
                listTransform()
            ElseIf DateCHECKER() = False Or DateCHECKER1() = False Then
                ListView1.Items.Clear()
                msginfo("No Data Found")
                list()
                listTransform()
                Exit Sub
            End If
        End If

    End Sub
    Public Function DateCHECKER()
        Try
            connect()
            Dim adp As New SqlDataAdapter
            Dim dt As New DataTable
            Dim query As String = "SELECT * FROM tblEventRecord WHERE Date = @DAT"

            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@DAT", DateTimePicker1.Text)


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
    Public Function DateCHECKER1()
        Try
            connect()
            Dim adp As New SqlDataAdapter
            Dim dt As New DataTable
            Dim query As String = "SELECT * FROM tblEventRecord WHERE Date = @DAT"

            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@DAT", DateTimePicker2.Text)


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

    Private Function insertRecord()
        connect()
        con.Close()
        con.Open()
        Try
            For Each x As ListViewItem In ListView1.Items
                connect()
                cmd.Connection = con
                cmd.CommandText = "INSERT INTO tblEventRecordCrystalReport (SubID,StudentID,Firstname,Lastname,YearLevel,Course,LogIN,LogOUT,Event,SMS,NoStudent,SMS1,Date)" & _
                "VALUES (@SUBID,@SI,@FN,@LN,@YL,@C,@LI,@LO,@EV,@SMS,@NS,@SMS1,@D)"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@SUBID", x.SubItems(1).Text)
                cmd.Parameters.AddWithValue("@SI", x.SubItems(2).Text)
                cmd.Parameters.AddWithValue("@FN", x.SubItems(3).Text)
                cmd.Parameters.AddWithValue("@LN", x.SubItems(4).Text)
                cmd.Parameters.AddWithValue("@YL", x.SubItems(5).Text)
                cmd.Parameters.AddWithValue("@C", x.SubItems(6).Text)
                cmd.Parameters.AddWithValue("@LI", x.SubItems(7).Text)
                cmd.Parameters.AddWithValue("@LO", x.SubItems(8).Text)
                cmd.Parameters.AddWithValue("@EV", x.SubItems(9).Text)
                cmd.Parameters.AddWithValue("@SMS", x.SubItems(10).Text)
                cmd.Parameters.AddWithValue("@NS", x.SubItems(11).Text)
                cmd.Parameters.AddWithValue("@SMS1", x.SubItems(12).Text)
                cmd.Parameters.AddWithValue("@D", x.SubItems(13).Text)
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
    Sub Deleteall()
        Try
            con.Close()
            con.Open()
            cmd.CommandText = "DELETE tblEventRecordCrystalReport"
            Dim i As Integer = cmd.ExecuteNonQuery()
            'list()
            con.Close()
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub
    Sub ViewReport()
        Try
            Dim comm As New SqlClient.SqlCommand
            Dim da As SqlClient.SqlDataAdapter
            Dim ds As New DataSet
            comm.CommandText = "Select * from tblEventRecordCrystalReport"
            comm.CommandType = CommandType.Text
            comm.Connection = con
            da = New SqlDataAdapter(comm)
            da.Fill(ds)
            da.Dispose()
            Dim report As New EventRecordReport
            report.SetDataSource(ds.Tables(0))
            'ds.WriteXmlSchema("C:\xml\EventAttendanceRecordCrystalReport.xml")
            '  report.SetParameterValue("Date", txtDate.Text)
            report.SetParameterValue("ProcessedBy", lblProcessedBy.Text)
            report.SetParameterValue("UserID", lblUserID.Text)
            EventRecordViewer.CrystalReportViewer1.ReportSource = report
            AuditTrail("Event Record", "Print", "#####-############-#####")
            EventRecordViewer.ShowDialog()
            Deleteall()
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        insertRecord()
        ViewReport()
    End Sub
    Sub Search()
        Try
            con.Close()
            con.Open()
            Dim cmd As SqlCommand
            Dim dr As SqlDataReader
            Dim sql As String


            sql = "Select * from tblEventRecord where StudentID Like '%" & txtStudentID.Text & "%' AND YearLevel Like '%" & cbYearLevel.Text & "%' AND Course Like '%" & cbCourse.Text & "%'AND Department Like '%" & cbDepartment.Text & "%'"

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
                list.SubItems.Add(dr(13))
                list.SubItems.Add(dr(14))
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
            listTransform()
        End Try


    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Search()
        If ListView1.Items.Count = 0 Then
            msginfo("No Data Found")     
            txtStudentID.Text = ""
            cbDepartment.SelectedIndex = -1
            cbYearLevel.SelectedIndex = -1
            cbCourse.SelectedIndex = -1
            list()
            listTransform()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        txtStudentID.Text = ""
        cbDepartment.SelectedIndex = -1
        cbYearLevel.SelectedIndex = -1
        cbCourse.SelectedIndex = -1
        list()
        listTransform()
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