Imports System.Data.SqlClient
Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Imports System.Management
Public Class EventAttendance
    Public LOUTTT As String = "N/A"
    Public SMS111 As String = "N/A"
    Dim Date1 As Date
    Dim Date2 As Date
    Private serialPort As New IO.Ports.SerialPort
    Private TargetDT As DateTime
    Private CountDownFrom As TimeSpan = TimeSpan.FromSeconds(1)
    'Public Function StudIDCHECKERS()
    '    Try
    '        connect()
    '        Dim adp As New SqlDataAdapter
    '        Dim dt As New DataTable
    '        Dim query As String = "SELECT * FROM tblStudentMasterList WHERE StudentID = @StudentID "

    '        Dim cmd As New SqlCommand(query, con)
    '        cmd.Parameters.Clear()
    '        cmd.Parameters.AddWithValue("@StudentID", txtStudentID.Text)

    '        With adp
    '            .SelectCommand = cmd
    '            .Fill(dt)
    '        End With
    '        If dt.Rows.Count >= 1 Then

    '            Return True
    '            Exit Function
    '        End If


    '    Catch ex As Exception

    '    End Try
    '    Return Nothing
    'End Function
    Sub loadDepartment()
        Try
            con.Close()
            con.Open()
            Dim cmd As New SqlClient.SqlCommand("SELECT DISTINCT Department FROM tblEvent where EventName = '" + cbEvent.Text + "'", con)
            Dim reader As SqlClient.SqlDataReader
            reader = cmd.ExecuteReader
            cbDepartment.Items.Clear()
            While reader.Read
                cbDepartment.Items.Add(reader("Department"))
            End While

            'lblFrom.Text = "dd/mm/yyyy"
            'lblTo.Text = "dd/mm/yyyy"
            'txtStudentID.Text = ""
            'txtStudentID.Enabled = False

        Catch ex As Exception
            msgerror(Err.Description)
            con.Close()
        End Try
    End Sub
    Sub loadYearLevel()
        Try
            con.Close()
            con.Open()
            Dim cmd As New SqlClient.SqlCommand("SELECT DISTINCT Yearlevel FROM tblEvent where EventName = '" + cbEvent.Text + "'", con)
            Dim reader As SqlClient.SqlDataReader
            reader = cmd.ExecuteReader
            cbYearlevel.Items.Clear()
            While reader.Read
                cbYearlevel.Items.Add(reader("Yearlevel"))
            End While

            'lblFrom.Text = "dd/mm/yyyy"
            'lblTo.Text = "dd/mm/yyyy"
            'txtStudentID.Text = ""
            'txtStudentID.Enabled = False

        Catch ex As Exception
            msgerror(Err.Description)
            con.Close()
        End Try
    End Sub
    Sub DeleteAll()
        Try
            con.Close()
            con.Open()
            cmd.CommandText = "DELETE tblEvent"
            Dim i As Integer = cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub
    Sub listdelete()
        Try
            For Each item As ListViewItem In Me.ListView1.Items
                If CDate(item.SubItems(3).Text) < Date.Today Then
                    Dim NewIt As New ListViewItem
                    NewIt.Text = item.Text
                    ListView1.Items.RemoveAt(item.Index)
                    NewIt.SubItems.Add(NewIt.Text)
                End If
            Next
            InsertNonExpired()
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
            cmd.CommandText = "SELECT * FROM tblEvent"
            Dim dataread3 As SqlDataReader = cmd.ExecuteReader
            Dim DelID As Integer
            Dim DeliveryID As String
            Dim delv As String
            Dim delf As String
            Dim dept As String
            Dim year As String
            While dataread3.Read()
                DelID = dataread3.GetValue(0)
                DeliveryID = dataread3.GetValue(1)
                delv = dataread3.GetValue(2)
                delf = dataread3.GetValue(3)
                dept = dataread3.GetValue(4)
                year = dataread3.GetValue(5)
                Dim arr(15) As String
                Dim itm As ListViewItem
                arr(0) = "" & DelID & ""
                arr(1) = "" & DeliveryID & ""
                arr(2) = "" & delv & ""
                arr(3) = "" & delf & ""
                arr(4) = "" & dept & ""
                arr(5) = "" & year & ""
                itm = New ListViewItem(arr)
                ListView1.Items.Add(itm)
            End While
            con.Close()
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub
    Private Function InsertNonExpired()
        Try
            connect()
            con.Close()
            con.Open()
            DeleteAll()
            For Each x As ListViewItem In ListView1.Items
                connect()
                cmd.Connection = con
                cmd.CommandText = "INSERT INTO tblEvent (EventName,FromDate,ToDate,Department,Yearlevel) VALUES (@EN,@FD,@TD,@DM,@YL)"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@EN", x.SubItems(1).Text)
                cmd.Parameters.AddWithValue("@FD", x.SubItems(2).Text)
                cmd.Parameters.AddWithValue("@TD", x.SubItems(3).Text)
                cmd.Parameters.AddWithValue("@DM", x.SubItems(4).Text)
                cmd.Parameters.AddWithValue("@YL", x.SubItems(5).Text)
                Dim a As Integer = cmd.ExecuteNonQuery()
                If a > 0 Then
                    list()
                Else
                End If
            Next
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
        con.Close()
        Return Nothing
    End Function
    Sub Sendsms()
        Try
            serialPort.Open()
            If (serialPort.IsOpen) Then
                With serialPort
                    .WriteLine("AT" & vbCrLf)
                    Threading.Thread.Sleep(1000)
                    .WriteLine("AT+CMGF=1" & vbCrLf)
                    Threading.Thread.Sleep(1000)
                    .WriteLine("AT+CSCS=""GSM"" " & vbCrLf)
                    Threading.Thread.Sleep(1000)
                    .WriteLine("AT+CMGS=" & Chr(34) & txtPhoneNo.Text & Chr(34) & vbCrLf)
                    Threading.Thread.Sleep(1000)
                    .Write(SMS.Text & Chr(26))
                    Threading.Thread.Sleep(1000)
                End With
                serialPort.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub com()
        With serialPort
            .PortName = Label5.Text
            .Parity = Nothing
            .DataBits = 8
            .Handshake = IO.Ports.Handshake.XOnXOff
            .DtrEnable = True
            .RtsEnable = True
            .NewLine = Environment.NewLine
        End With
    End Sub
    Public Function ModemsConnected() As String
        Dim modems As String = ""
        Try
            Dim searcher As New ManagementObjectSearcher( _
          "root\CIMV2", _
          "SELECT * FROM  WIN32_POTSModem")

            For Each queryObj As ManagementObject In searcher.Get()
                If queryObj("Status") = "OK" Then
                    modems = modems & (queryObj("AttachedTo") & " - " & queryObj("Description") & "***")
                End If
            Next

        Catch ex As Exception
        End Try
        Return modems
    End Function
    Sub ports()
        Dim ports() As String
        ports = Split(ModemsConnected(), "***")
        For i As Integer = 0 To ports.Length - 2
            Label4.Text = (ports(i))
            Label5.Text = Label4.Text
            Label5.Text = Trim(Mid(Label4.Text, 1, 5))
        Next
    End Sub

    Private Sub EventAttendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' DELETESUB()
            SubID()
            list()
            listdelete()
            Timer1.Start()
            Timer1.Interval = 1000
            ports()
            com()
            loadEvent()

            Clear()
            txtStudentID.Enabled = False
            lblFrom.Text = "dd/mm/yyyy"
            lblTo.Text = "dd/mm/yyyy"
            SMS.Text = ""
            DateCheckers()

            If txtDateChecker.Text <> "" Then
                If txtDateChecker.Text < Date.Today Then
                    DELETESUBEVENT()
                End If
            
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub
    Sub DateCheckers()
        Try
            connect()
            con.Close()
            con.Open()
            Dim com As New SqlClient.SqlCommand
            com.Connection = con
            com.CommandText = "Select * from tblSubEventRecord"
            Dim adpt As New SqlDataAdapter(com)
            Dim dt As New DataTable
            adpt.Fill(dt)
            txtDateChecker.Text = dt.Rows(0)(13).ToString
        Catch ex As Exception
        End Try
    End Sub
    Private Function DELETESUBEVENT()
        Try
            con.Close()
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "DELETE tblSubEventRecord"
            Dim i As Integer = cmd.ExecuteNonQuery()
            If i > 0 Then
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
        Return Nothing
    End Function
    Public Function StudIDCHECKER()
        Try
            con.Close()
            con.Open()
            connect()
            Dim adp As New SqlDataAdapter
            Dim dt As New DataTable
            Dim query As String = "SELECT * FROM tblStudentMasterList WHERE StudentID = @SID"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@SID", txtStudentID.Text)
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
    Public Function SDCHECKER()
        Try
            connect()
            Dim adp As New SqlDataAdapter
            Dim dt As New DataTable
            Dim query As String = "SELECT * FROM tblStudentMasterList WHERE StudentID = @StudentID and Department = '" + cbDepartment.Text + "'"

            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@StudentID", txtStudentID.Text)

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
    Sub loadEvent()
        Try
            con.Close()
            con.Open()
            Dim Cmd As New SqlClient.SqlCommand("SELECT DISTINCT EventName FROM tblEvent", con)
            Cmd.ExecuteNonQuery()
            Dim Datatable As New DataTable
            Dim DataAdapter As New SqlClient.SqlDataAdapter(Cmd)
            DataAdapter.Fill(Datatable)
            cbEvent.DataSource = Datatable
            cbEvent.ValueMember = "EventName"
            cbEvent.DisplayMember = "EventName"
        Catch ex As Exception
            msgerror(Err.Description)
            con.Close()
        End Try
    End Sub
    'Sub loadDepartment()
    '    Try
    '        con.Close()
    '        con.Open()
    '        Dim Cmd As New SqlClient.SqlCommand("SELECT Department FROM tblDepartment", con)
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
    Sub SubID()
        connect()
        Try
            Dim i As Double
            Dim sql As String
            sql = "Select Max(SubID) from tblEventRecord"
            Dim com As New SqlClient.SqlCommand(sql, con)
            If IsDBNull(com.ExecuteScalar) Then
                i = "100"
                lblID.Text = i.ToString
            Else
                i = com.ExecuteScalar + 1
                lblID.Text = i.ToString
            End If
        Catch ex As Exception
        End Try
    End Sub
    'Sub SubID1()
    '    connect()
    '    Try
    '        Dim i As Double
    '        Dim sql As String
    '        sql = "Select Max(SubID) from tblEventRecord"
    '        Dim com As New SqlClient.SqlCommand(sql, con)
    '        If IsDBNull(com.ExecuteScalar) Then
    '            i = "1000"
    '            lblID.Text = i.ToString
    '        Else
    '            i = com.ExecuteScalar + 1
    '            lblID.Text = i.ToString
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub
    Sub IDString()
        Try
            connect()
            con.Close()
            con.Open()
            Dim com As New SqlClient.SqlCommand
            com.Connection = con
            com.CommandText = "Select * from tblEventRecord where StudentID = '" & txtStudentID.Text & "'"
            Dim adpt As New SqlDataAdapter(com)
            Dim dt As New DataTable
            adpt.Fill(dt)
            txtID.Text = dt.Rows(0)(0).ToString
        Catch ex As Exception
        End Try
    End Sub
    Sub SubStringID()
        Try
            connect()
            con.Close()
            con.Open()
            Dim com As New SqlClient.SqlCommand
            com.Connection = con
            com.CommandText = "Select * from tblSubEventRecord where StudentID = '" & txtStudentID.Text & "'"
            Dim adpt As New SqlDataAdapter(com)
            Dim dt As New DataTable
            adpt.Fill(dt)
            txtSubID.Text = dt.Rows(0)(1).ToString
        Catch ex As Exception
        End Try
    End Sub
    Sub clearFETCHTOEVENTRECORD()
        CSubID.Text = ""
        CStudentID.Text = ""
        CFname.Text = ""
        CLname.Text = ""
        CYearLevel.Text = ""
        CCourse.Text = ""
        CLogIN.Text = ""
        CLogOUT.Text = ""
        CEvent.Text = ""
        CSMS.Text = ""
        CNoStudent.Text = ""

    End Sub
    Sub Clear()
        cbEvent.SelectedIndex = -1
        cbDepartment.SelectedIndex = -1
    End Sub
    Sub Namestring()
        Try
            con.Close()
            con.Open()
            connect()
            Dim com As New SqlClient.SqlCommand
            com.Connection = con
            com.CommandText = "Select * from tblStudentMasterList where StudentID = '" & txtStudentID.Text & "'"
            Dim adpt As New SqlDataAdapter(com)
            Dim dt As New DataTable
            adpt.Fill(dt)
            txtLname.Text = dt.Rows(0)(2).ToString
            txtFname.Text = dt.Rows(0)(3).ToString
            txtYearLevel.Text = dt.Rows(0)(7).ToString
            txtPhoneNo.Text = dt.Rows(0)(9).ToString
            txtCourse.Text = dt.Rows(0)(11).ToString
            txtDepartment.Text = dt.Rows(0)(14).ToString

            Pic()

      
            InsertStudentss()
        Catch ex As Exception
        End Try
    End Sub
    Private Function InsertStudentss()
        Try
            con.Close()
            con.Open()
            connect()
            Dim cmd As New SqlCommand("Select * from tblSubEventRecord where StudentID = @SI and ID <> '" & txtID.Text & "'", con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@SI", txtStudentID.Text)
            cmd.ExecuteNonQuery()
            dt = New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dt, "a")
            If dt.Tables("a").Rows.Count <> 0 Then
                DELETENAaa()
                connect()
                cmd.CommandText = "Update tblSubEventRecord SET  LogOUT = @LOUT, SMS1 = @SMSOUT where SubID = '" & txtSubID.Text & "'"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@LOUT", Date.Now)
                SMS.Text = Date.Now + " " + txtLname.Text + ", " + txtFname.Text + " had attended " + cbEvent.Text
                ' cmd.Parameters.AddWithValue("@SMS", SMS.Text)
                cmd.Parameters.AddWithValue("@SMSOUT", SMS.Text)

                If Label4.Text <> "Label4" Then
                    Sendsms()
                End If

                Dim a As Integer = cmd.ExecuteNonQuery()
                If a > 0 Then
                    connect()
                    con.Close()
                    con.Open()
                    Dim com As New SqlClient.SqlCommand
                    com.Connection = con
                    com.CommandText = "Select * from tblSubEventRecord where StudentID = '" & txtStudentID.Text & "'"
                    Dim adpt As New SqlDataAdapter(com)
                    Dim dt As New DataTable
                    adpt.Fill(dt)
                    CSubID.Text = dt.Rows(0)(1).ToString
                    CStudentID.Text = dt.Rows(0)(2).ToString
                    CFname.Text = dt.Rows(0)(3).ToString
                    CLname.Text = dt.Rows(0)(4).ToString
                    CYearLevel.Text = dt.Rows(0)(5).ToString
                    CCourse.Text = dt.Rows(0)(6).ToString
                    CLogIN.Text = dt.Rows(0)(7).ToString
                    CLogOUT.Text = dt.Rows(0)(8).ToString
                    CEvent.Text = dt.Rows(0)(9).ToString
                    CSMS.Text = dt.Rows(0)(10).ToString
                    CNoStudent.Text = dt.Rows(0)(11).ToString
                    CSMS1.Text = dt.Rows(0)(12).ToString
                    CtxtDate.Text = dt.Rows(0)(13).ToString
                    CtxtDepartment.Text = dt.Rows(0)(14).ToString
                    FETCHTOEVENTRECORD()
                End If
            Else
                con.Close()
                con.Open()
                connect()
                cmd.Connection = con
                cmd.CommandText = "INSERT INTO tblSubEventRecord (StudentID,SubID,Firstname,Lastname,YearLevel,Course,LogIN,LogOUT,Event,SMS,NoStudent,SMS1,Date,Department) " & _
                            "VALUES (@SI,@SUBI,@FN,@LN,@YL,@C,@LIN,@LOUT,@E,@SMS,@NS,@SMS111,@DAT,@DM)"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@SI", txtStudentID.Text)
                cmd.Parameters.AddWithValue("@SUBI", lblID.Text)
                cmd.Parameters.AddWithValue("@FN", txtFname.Text)
                cmd.Parameters.AddWithValue("@LN", txtLname.Text)
                cmd.Parameters.AddWithValue("@YL", txtYearLevel.Text)
                cmd.Parameters.AddWithValue("@C", txtCourse.Text)
                cmd.Parameters.AddWithValue("@LIN", Date.Now)
                cmd.Parameters.AddWithValue("@LOUT", LOUTTT)
                cmd.Parameters.AddWithValue("@E", cbEvent.Text)
                SMS.Text = Date.Now + " " + txtLname.Text + ", " + txtFname.Text + " has arrived at the school campus during " + cbEvent.Text
                cmd.Parameters.AddWithValue("@SMS", SMS.Text)
                cmd.Parameters.AddWithValue("@SMS111", SMS111)
                cmd.Parameters.AddWithValue("@NS", txtNoStudent.Text)
                cmd.Parameters.AddWithValue("@DAT", txtDate.Text)
                cmd.Parameters.AddWithValue("@DM", txtDepartment.Text)
                If Label4.Text <> "Label4" Then
                    '  Sendsms()
                End If

                Dim a As Integer = cmd.ExecuteNonQuery()
                If a > 0 Then
                    InsertStudent()
                End If
            End If
        Catch ex As Exception
        End Try
        Return Nothing
    End Function
    Private Function InsertStudent()
        Try
            Timer2.Start()
            con.Close()
            con.Open()
            connect()
            With cmd
                .Connection = con
                .CommandText = "INSERT INTO tblEventRecord (StudentID,SubID,Firstname,Lastname,YearLevel,Course,LogIN,LogOUT,Event,SMS,NoStudent,SMS1,Date,Department) " & _
                                "VALUES (@SI,@SUBI,@FN,@LN,@YL,@C,@LIN,@LOUT,@E,@SMS,@NS,@SMS111,@DAT,@DM)"
                .Parameters.Clear()
                .Parameters.AddWithValue("@SI", txtStudentID.Text)
                .Parameters.AddWithValue("@SUBI", lblID.Text)
                .Parameters.AddWithValue("@FN", txtFname.Text)
                .Parameters.AddWithValue("@LN", txtLname.Text)
                .Parameters.AddWithValue("@YL", txtYearLevel.Text)
                .Parameters.AddWithValue("@C", txtCourse.Text)
                .Parameters.AddWithValue("@LIN", Date.Now)
                .Parameters.AddWithValue("@LOUT", LOUTTT)
                .Parameters.AddWithValue("@E", cbEvent.Text)
                SMS.Text = Date.Now + " " + txtLname.Text + ", " + txtFname.Text + " has arrived at the school campus during " + cbEvent.Text
                .Parameters.AddWithValue("@SMS", SMS.Text)
                .Parameters.AddWithValue("@SMS111", SMS111)
                .Parameters.AddWithValue("@NS", txtNoStudent.Text)
                .Parameters.AddWithValue("@DAT", txtDate.Text)
                .Parameters.AddWithValue("@DM", txtDepartment.Text)
                If Label4.Text <> "Label4" Then
                    Sendsms()
                End If

            End With
            Dim a As Integer = cmd.ExecuteNonQuery()
            If a > 0 Then

                Timer2.Interval = 100
                TargetDT = Date.Now.Add(CountDownFrom)
                SubID()
            Else
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
        Return Nothing
    End Function
    Private Function FETCHTOEVENTRECORD()
        Timer2.Start()
        con.Close()
        con.Open()
        connect()
        With cmd
            .Connection = con
            .CommandText = "INSERT INTO tblEventRecord (StudentID,SubID,Firstname,Lastname,YearLevel,Course,LogIN,LogOUT,Event,SMS,NoStudent,SMS1,Date,Department) " & _
                            "VALUES ('" & CStudentID.Text & "','" & CSubID.Text & "','" & CFname.Text & "','" & CLname.Text & "','" & CYearLevel.Text & "','" & CCourse.Text & "' ,'" & CLogIN.Text & "','" & CLogOUT.Text & "','" & CEvent.Text & "','" & CSMS.Text & "','" & CNoStudent.Text & "','" & CSMS1.Text & "','" & CtxtDate.Text & "','" & CtxtDepartment.Text & "')"
        End With
        Dim a As Integer = cmd.ExecuteNonQuery()
        If a > 0 Then
            DELETENA()
            Timer2.Interval = 100
            TargetDT = Date.Now.Add(CountDownFrom)
        End If
        Return Nothing
    End Function
 
    Private Function DELETENA()
        con.Close()
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "DELETE tblSubEventRecord WHERE SubID='" & txtSubID.Text & "'"
        Dim i As Integer = cmd.ExecuteNonQuery()
        If i > 0 Then
        End If
        Return Nothing
    End Function
    Private Function DELETENAaa()
        con.Close()
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "DELETE tblEventRecord WHERE SubID='" & txtSubID.Text & "'"
        Dim i As Integer = cmd.ExecuteNonQuery()
        If i > 0 Then
        End If
        Return Nothing
    End Function
    Sub Pic()
        Try
            If txtStudentID.Text <> "" Then
                Dim cmd As New SqlCommand("Select * from tblStudentMasterList where StudentID = '" & txtStudentID.Text & "'", con)
                Dim table As New DataTable
                Dim adpt As New SqlDataAdapter(cmd)
                adpt.Fill(table)
                Dim img() As Byte
                img = table.Rows(0)(13)
                Dim ms As New MemoryStream(img)
                PictureBox2.Image = Image.FromStream(ms)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim dialog As DialogResult
            dialog = MessageBox.Show("Do you want to close EventAttendance?", "", MessageBoxButtons.YesNo)
            If dialog = DialogResult.No Then
                Beep()
                MsgBox("Cancel!!")
            Else
                Beep()
                Me.Close()
                Login.Show()
                Login.txtUsername.Focus()
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub

    Private Sub txtStudentID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStudentID.KeyDown

    End Sub
    Public Function DepartChecker()
        Try
            con.Close()
            con.Open()
            connect()
            Dim adp As New SqlDataAdapter
            Dim dt As New DataTable
            Dim query As String = "SELECT * FROM tblStudentMasterList WHERE Department = @D AND StudentID = '" + txtStudentID.Text + "'"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@D", cbDepartment.Text)
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
    Public Function DepartYlevelChecker()
        Try
            con.Close()
            con.Open()
            connect()
            Dim adp As New SqlDataAdapter
            Dim dt As New DataTable
            Dim query As String = "SELECT * FROM tblStudentMasterList WHERE Department = @D AND Yearlevel = '" + cbYearlevel.Text + "'AND StudentID = '" + txtStudentID.Text + "'"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@D", cbDepartment.Text)
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
    Private Sub txtStudentID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStudentID.KeyPress
        If Char.IsDigit(e.KeyChar) = False And e.KeyChar <> ChrW(8) Then
            e.Handled = True
        End If
        If e.KeyChar = ChrW(13) Then
            If lblFrom.Text > Date.Today Then
                msgerror("Invalid to use this event")
                Exit Sub
            ElseIf txtStudentID.Text = "" Then
                msgerror("Please input student id")
            ElseIf cbDepartment.Text <> "All" And cbYearlevel.Text = "" Then
                msgerror("Please select yearlevel")
            ElseIf cbDepartment.Text = "All" Then
                If StudIDCHECKER() = True Then
                    IDString()
                    SubStringID()
                    Namestring()
                    txtStudentID.Enabled = False
                    Exit Sub
                Else
                    msgerror("Student ID is not registered on StudentMasterList")
                    txtStudentID.Text = ""
                End If
            ElseIf cbYearlevel.Text = "All" And cbDepartment.Text <> "" Then
                If DepartChecker() = False Then
                    msgerror("Invalid, You cannot use this event")
                ElseIf StudIDCHECKER() = True Then

                    IDString()
                    SubStringID()
                    Namestring()
                    txtStudentID.Enabled = False
                    Exit Sub
                Else
                    msgerror("Student ID is not registered on StudentMasterList")
                    txtStudentID.Text = ""
                End If
            ElseIf DepartYlevelChecker() = False Then
                msgerror("Invalid, You cannot use this event")

            Else
                If StudIDCHECKER() = True Then
                    IDString()
                    SubStringID()
                    Namestring()
                    txtStudentID.Enabled = False
                    Exit Sub
                Else
                    msgerror("Student ID is not registered on StudentMasterList123")
                    txtStudentID.Text = ""
                End If
            End If
        End If
    End Sub
    Sub GetDate()
        Try
            connect()
            con.Close()
            con.Open()
            Dim com As New SqlClient.SqlCommand
            com.Connection = con
            com.CommandText = "Select * from tblEvent where EventName = '" & cbEvent.Text & "' AND Department = '" + cbDepartment.Text + "' "
            Dim adpt As New SqlDataAdapter(com)
            Dim dt As New DataTable
            adpt.Fill(dt)
            Date1 = dt.Rows(0)(2).ToString
            Date2 = dt.Rows(0)(3).ToString
            lblFrom.Text = dt.Rows(0)(2).ToString
            lblTo.Text = dt.Rows(0)(3).ToString
            txtDateChecker.Text = Date.Today
            loadYearLevel()
            If lblFrom.Text <= txtDateChecker.Text Then
                lbl.ForeColor = Color.Green
                lbl.Text = "Valid Date"
            ElseIf lblFrom.Text >= txtDateChecker.Text Then
                lbl.ForeColor = Color.Red
                lbl.Text = "Invalid Date"
            ElseIf lblFrom.Text = "dd/mm/yyyy" And lblTo.Text = "dd/mm/yyyy" Then
                lbl.Text = ""
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cbEvent_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbEvent.SelectedValueChanged
        'GetDate()
       
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        txtDate.Text = Format(Now, "dd/MM/yyyy ")
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim ts As TimeSpan = TargetDT.Subtract(Date.Now)
        If ts.TotalMilliseconds > 0 Then
            Label14.Text = ts.ToString("ss")
        Else
            Label14.Text = "0"
            txtStudentID.Text = ""
            txtFname.Text = ""
            txtLname.Text = ""
            txtYearLevel.Text = ""
            txtDepartment.Text = ""
            txtCourse.Text = ""
            PictureBox2.Image = Nothing
            Timer2.Stop()
            Console.Beep()
            txtStudentID.Enabled = True
            txtStudentID.Focus()
        End If
    End Sub

    Private Sub cbEvent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEvent.SelectedIndexChanged
        lblFrom.Text = "dd/mm/yyyy"
        lblTo.Text = "dd/mm/yyyy"
        lbl.Text = ""
        txtStudentID.Text = ""
        txtStudentID.Enabled = False
        loadDepartment()
        loadYearLevel()
        If cbDepartment.Text = "All" Then
            cbYearlevel.Enabled = False
        Else
            cbYearlevel.Enabled = True
        End If

    End Sub

    Private Sub cbDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDepartment.SelectedIndexChanged
        GetDate()
        If cbDepartment.Text = "All" Then
            cbYearlevel.Enabled = False
        Else
            cbYearlevel.Enabled = True
        End If
    End Sub

    Private Sub cbDepartment_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbDepartment.SelectedValueChanged
        GetDate()
        If cbEvent.Text <> "" And cbDepartment.Text <> "" Then

            txtStudentID.Enabled = True
            txtStudentID.Focus()
        End If
    End Sub


    Private Sub cbYearlevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbYearlevel.SelectedIndexChanged

    End Sub

    Private Sub txtStudentID_TextChanged(sender As Object, e As EventArgs) Handles txtStudentID.TextChanged

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class
