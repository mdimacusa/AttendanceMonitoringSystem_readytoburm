Imports System.Data.SqlClient
Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Imports System.Management

Public Class Attendance
    Public LOUTT As String = "N/A"
    Public SMS11 As String = "N/A"
    Private serialPort As New IO.Ports.SerialPort()
    Private TargetDT As DateTime
    Private CountDownFrom As TimeSpan = TimeSpan.FromSeconds(1)

    Private Sub txtStudentID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStudentID.KeyPress
         If Char.IsDigit(e.KeyChar) = False And e.KeyChar <> ChrW(8) Then
            e.Handled = True
        End If
        If e.KeyChar = ChrW(13) Then
            If StudIDCHECKER() = True Then
                IDString()
                SubStringID()
                Namestring()
                txtStudentID.Enabled = False
                Exit Sub
            Else
                msgerror("Student ID is not registered")
                txtStudentID.Text = ""
            End If
        End If
    End Sub
    Private Sub txtStudentID_TextChanged(sender As Object, e As EventArgs) Handles txtStudentID.TextChanged

    End Sub

    Private Sub Attendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Timer1.Start()
            Timer1.Interval = 1000
            ports()
            SubID()
            com()
            txtStudentID.Focus()
            SMS.Text = ""
            DateChecker()
            If txtDateChecker.Text <> "" Then
                If txtDateChecker.Text < Date.Today Then
                    DELETESUB()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        txtDate.Text = Format(Now, "dd/MM/yyyy ")
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim ts As TimeSpan = TargetDT.Subtract(Date.Now)
        If ts.TotalMilliseconds > 0 Then
            Label11.Text = ts.ToString("ss")
        Else
            Label11.Text = "0"
            txtStudentID.Text = ""
            txtFname.Text = ""
            txtLname.Text = ""
            txtYearLevel.Text = ""
            txtCourse.Text = ""
            txtDateChecker1.Text = ""
            txtDepartment.Text = ""
            PictureBox2.Image = Nothing
            Timer2.Stop()
            Console.Beep()
            txtStudentID.Enabled = True
            txtStudentID.Focus()
        End If

    End Sub
    Public Function StudIDCHECKER()
        Try
            connect()
            Dim adp As New SqlDataAdapter
            Dim dt As New DataTable
            Dim query As String = "SELECT * FROM tblStudentMasterList WHERE StudentID = @StudentID"

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
            Else
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
    Sub SubID()
        connect()
        Try
            Dim i As Double
            Dim sql As String
            sql = "Select Max(SubID) from tblAttendance"
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
    Sub DateChecker()
        Try
            connect()
            con.Close()
            con.Open()
            Dim com As New SqlClient.SqlCommand
            com.Connection = con
            com.CommandText = "Select * from tblSubAttendance"
            Dim adpt As New SqlDataAdapter(com)
            Dim dt As New DataTable
            adpt.Fill(dt)
            txtDateChecker.Text = dt.Rows(0)(12).ToString
        Catch ex As Exception
        End Try
    End Sub
    Sub IDString()
        Try
            connect()
            con.Close()
            con.Open()
            Dim com As New SqlClient.SqlCommand
            com.Connection = con
            com.CommandText = "Select * from tblAttendance where StudentID = '" & txtStudentID.Text & "'"
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
            com.CommandText = "Select * from tblSubAttendance where StudentID = '" & txtStudentID.Text & "'"
            Dim adpt As New SqlDataAdapter(com)
            Dim dt As New DataTable
            adpt.Fill(dt)
            txtSubID.Text = dt.Rows(0)(1).ToString
        Catch ex As Exception
        End Try
    End Sub
    'Sub DateChecker1()
    '    Try
    '        connect()
    '        con.Close()
    '        con.Open()
    '        Dim com As New SqlClient.SqlCommand
    '        com.Connection = con
    '        com.CommandText = "Select * from tblSubAttendance where StudentID = '" & txtStudentID.Text & "'"
    '        Dim adpt As New SqlDataAdapter(com)
    '        Dim dt As New DataTable
    '        adpt.Fill(dt)
    '        txtDateChecker1.Text = dt.Rows(0)(12).ToString
    '    Catch ex As Exception
    '    End Try
    'End Sub
    Sub clearFETCHTOEVENTRECORD()
        CSubID.Text = ""
        CStudentID.Text = ""
        CFname.Text = ""
        CYearLevel.Text = ""
        CCourse.Text = ""
        CLogIN.Text = ""
        CLogOUT.Text = ""
        '  CEvent.Text = ""
        CSMS.Text = ""
        CNoStudent.Text = ""

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


            'If txtDateChecker1.Text < Date.Today Then
            '    DELETESUB()
            'Else
            Pic()
            InsertStudentss()
            'End If
        Catch ex As Exception
        End Try
    End Sub
    Private Function InsertStudentss()
        Try
            con.Close()
            con.Open()
            connect()
            Dim cmd As New SqlCommand("Select * from tblSubAttendance where StudentID = '" & txtStudentID.Text & "'", con)
            cmd.Parameters.Clear()
            '  cmd.Parameters.AddWithValue("@SI", txtStudentID.Text)
            ' MsgBox("READ")
            cmd.ExecuteNonQuery()
            dt = New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dt, "a")
            If dt.Tables("a").Rows.Count <> 0 Then
                DELETENAaa()
                connect()
                cmd.CommandText = "Update tblSubAttendance SET  LogOUT = @LOUT, SMS1 = @SMSOUT where SubID = '" & txtSubID.Text & "'"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@LOUT", Date.Now)
                SMS.Text = Date.Now + " " + txtLname.Text + ", " + txtFname.Text + " has left at the school campus. "
                cmd.Parameters.AddWithValue("@SMSOUT", SMS.Text)
                If Label4.Text <> "Label4" Then
                    Sendsms()
                End If
                ' MsgBox("qweqwe")
                Dim a As Integer = cmd.ExecuteNonQuery()
                If a > 0 Then
                    connect()
                    con.Close()
                    con.Open()
                    Dim com As New SqlClient.SqlCommand
                    com.Connection = con
                    com.CommandText = "Select * from tblSubAttendance where StudentID = '" & txtStudentID.Text & "'"
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
                    CSMS.Text = dt.Rows(0)(9).ToString
                    CNoStudent.Text = dt.Rows(0)(10).ToString
                    CSMS1.Text = dt.Rows(0)(11).ToString
                    CCDate.Text = dt.Rows(0)(12).ToString
                    CtxtDepartment.Text = dt.Rows(0)(13).ToString
                    FETCHTOEVENTRECORD()


                End If
            Else
                con.Close()
                con.Open()
                connect()
                cmd.Connection = con
                cmd.CommandText = "INSERT INTO tblSubAttendance (StudentID,SubID,Firstname,Lastname,YearLevel,Course,LogIN,LogOUT,SMS,NoStudent,SMS1,Date,Department) " & _
                            "VALUES (@SI,@SUBI,@FN,@LN,@YL,@C,@LIN,@LOUT,@SMS,@NS,@SMS111,@D,@DM)"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@SI", txtStudentID.Text)
                cmd.Parameters.AddWithValue("@SUBI", lblID.Text)
                cmd.Parameters.AddWithValue("@FN", txtFname.Text)
                cmd.Parameters.AddWithValue("@LN", txtLname.Text)
                cmd.Parameters.AddWithValue("@YL", txtYearLevel.Text)
                cmd.Parameters.AddWithValue("@C", txtCourse.Text)
                cmd.Parameters.AddWithValue("@LIN", Date.Now)
                cmd.Parameters.AddWithValue("@LOUT", LOUTT)
                SMS.Text = Date.Now + " " + txtLname.Text + ", " + txtFname.Text + " has arrived at the school campus. "
                cmd.Parameters.AddWithValue("@SMS", SMS.Text)
                cmd.Parameters.AddWithValue("@NS", txtNoStudent.Text)
                cmd.Parameters.AddWithValue("@SMS111", SMS11)
                cmd.Parameters.AddWithValue("@D", txtDate.Text)
                cmd.Parameters.AddWithValue("@DM", txtDepartment.Text)
                If Label4.Text <> "Label4" Then
                    'Sendsms()
                End If
                Dim a As Integer = cmd.ExecuteNonQuery()
                If a > 0 Then
                    DateChecker()
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
                .CommandText = "INSERT INTO tblAttendance (StudentID,SubID,Firstname,Lastname,YearLevel,Course,LogIN,LogOUT,SMS,NoStudent,SMS1,Date,Department) " & _
                                "VALUES (@SI,@SUBI,@FN,@LN,@YL,@C,@LIN,@LOUT,@SMS,@NS,@SMS111,@D,@DM)"
                .Parameters.Clear()
                .Parameters.AddWithValue("@SI", txtStudentID.Text)
                .Parameters.AddWithValue("@SUBI", lblID.Text)
                .Parameters.AddWithValue("@FN", txtFname.Text)
                .Parameters.AddWithValue("@LN", txtLname.Text)
                .Parameters.AddWithValue("@YL", txtYearLevel.Text)
                .Parameters.AddWithValue("@C", txtCourse.Text)
                .Parameters.AddWithValue("@LIN", Date.Now)
                .Parameters.AddWithValue("@LOUT", LOUTT)
                SMS.Text = Date.Now + " " + txtLname.Text + ", " + txtFname.Text + " has arrived at the school campus. "
                .Parameters.AddWithValue("@SMS", SMS.Text)
                .Parameters.AddWithValue("@NS", txtNoStudent.Text)
                .Parameters.AddWithValue("@SMS111", SMS11)
                .Parameters.AddWithValue("@D", txtDate.Text)
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
        Try


            Timer2.Start()
            con.Close()
            con.Open()
            connect()

            With cmd
                .Connection = con
                .CommandText = "INSERT INTO tblAttendance (StudentID,SubID,Firstname,Lastname,YearLevel,Course,LogIN,LogOUT,SMS,NoStudent,SMS1,Date,Department) " & _
                                "VALUES ('" & CStudentID.Text & "','" & CSubID.Text & "','" & CFname.Text & "','" & CLname.Text & "','" & CYearLevel.Text & "','" & CCourse.Text & "' ,'" & CLogIN.Text & "','" & CLogOUT.Text & "','" & CSMS.Text & "','" & CNoStudent.Text & "','" & CSMS1.Text & "','" & CCDate.Text & "','" & CtxtDepartment.Text & "')"
            End With
            Dim a As Integer = cmd.ExecuteNonQuery()
            If a > 0 Then

                DELETENA()
                Timer2.Interval = 100
                TargetDT = Date.Now.Add(CountDownFrom)
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
        Return Nothing
    End Function
    'Private Function CheckDate()
    '    con.Open()
    '    connect()
    '    Dim cmd As New SqlCommand("Select * from tblSubAttendance where Date <= '" & Date.Today & "'", con)
    '    cmd.Parameters.Clear()
    '    '  cmd.Parameters.AddWithValue("@SI", txtStudentID.Text)
    '    cmd.ExecuteNonQuery()
    '    dt = New DataSet
    '    adp = New SqlDataAdapter(cmd)
    '    adp.Fill(dt, "a")
    '    If dt.Tables("a").Rows.Count <> 0 Then
    '    End If
    '    con.Close()
    '    Return Nothing
    'End Function
    Private Function DELETESUB()
        Try
            con.Close()
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "DELETE tblSubAttendance"
            Dim i As Integer = cmd.ExecuteNonQuery()
            If i > 0 Then
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
        Return Nothing
    End Function
    Private Function DELETENA()
        Try
            con.Close()
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "DELETE tblSubAttendance WHERE SubID='" & txtSubID.Text & "'"
            Dim i As Integer = cmd.ExecuteNonQuery()
            If i > 0 Then
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
        Return Nothing
    End Function
    Private Function DELETENAaa()
        Try
            con.Close()
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "DELETE tblAttendance WHERE SubID='" & txtSubID.Text & "'"
            Dim i As Integer = cmd.ExecuteNonQuery()
            If i > 0 Then
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
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
            dialog = MessageBox.Show("Do you want to close Daily Attendance?", "", MessageBoxButtons.YesNo)
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


    Private Sub txtDate_TextChanged(sender As Object, e As EventArgs) Handles txtDate.TextChanged
        If txtDate.Text <> "" Then
            txtStudentID.Enabled = True
            txtStudentID.Focus()
        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub txtDateChecker_TextChanged(sender As Object, e As EventArgs) Handles txtDateChecker.TextChanged

    End Sub
End Class