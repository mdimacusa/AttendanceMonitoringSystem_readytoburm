Imports System.IO
Imports System.IO.Ports
Imports System.Management
Imports System.Data.SqlClient
Public Class SmsAnnouncement

    Dim SMS As New EJCSMS(allow_long_msg:=True, allow_empty_sms:=False) ' Configure your EJCSMS with these parameter
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
 
    Private Sub SmsAnnouncement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ports()
        SMS.InitSMS(Label5.Text)
        loadDepartment()
        'loadYearlevel()
        '  loadAnnouncement()
        loadTitle()
        ' loadCourse()
        cbDepartment.SelectedIndex = -1
        cbTitle.SelectedIndex = -1
        cbYearlevel.SelectedIndex = -1
        cbCourse.SelectedIndex = -1
        rbtnYES.Checked = False
        rbtnNO.Checked = False
        '  cbAnnouncement.SelectedIndex = -1
        cbAnnouncement.Text = ""
        ListView1.Items.Clear()
        lboxPhoneNumber.Items.Clear()
        ' autoID()
        lblProcessedBy.Text = MainForm.txtUserlevel.Text
        lblUserID.Text = MainForm.lblUserID.Text

    End Sub
    'Sub autoID()
    '    connect()
    '    Try

    '        Dim i As Double
    '        Dim sql As String
    '        sql = "Select Max(SmsID) from tblSmsAnnouncementRecord"
    '        Dim com As New SqlClient.SqlCommand(sql, con)
    '        If IsDBNull(com.ExecuteScalar) Then
    '            i = "1111111111"
    '            lblSMSID.Text = i.ToString
    '        Else
    '            i = com.ExecuteScalar + 1
    '            lblSMSID.Text = i.ToString
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub
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

    Sub loadTitle()
        Try
            con.Close()
            con.Open()
            Dim Cmd As New SqlClient.SqlCommand("SELECT Title FROM tblAnnouncement", con)
            Cmd.ExecuteNonQuery()
            Dim Datatable As New DataTable
            Dim DataAdapter As New SqlClient.SqlDataAdapter(Cmd)
            DataAdapter.Fill(Datatable)
            cbTitle.DataSource = Datatable
            cbTitle.ValueMember = "Title"
            cbTitle.DisplayMember = "Title"
        Catch ex As Exception
            msgerror(Err.Description)
            con.Close()
        End Try
    End Sub
    Sub loadCourse()
        Try
            con.Close()
            con.Open()
            Dim cmd As New SqlClient.SqlCommand("SELECT DISTINCT Course FROM tblStudentMasterList where Yearlevel = '" + cbYearlevel.Text + "'AND Department = '" + cbDepartment.Text + "'", con)
            Dim reader As SqlClient.SqlDataReader
            reader = cmd.ExecuteReader

            cbCourse.Items.Clear()
            While reader.Read

                cbCourse.Items.Add(reader("Course"))
            End While

            For i = cbCourse.Items.Count - 1 To 0 Step -1
                If String.IsNullOrEmpty(CStr(cbCourse.Items(i))) Then
                    cbCourse.Items.RemoveAt(i)
                End If
            Next

        Catch ex As Exception
            msgerror(Err.Description)
            con.Close()
        End Try
    End Sub

    Private Sub cbYearlevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbYearlevel.SelectedIndexChanged
        loadCourse()
        If cbYearlevel.Text <> "" And cbDepartment.Text <> "" Then
            rbtnNO.Checked = True
            lboxPhoneNumber.Items.Clear()
            fetch()
            removeduplicate()
            totalNo_Sended()
        Else
        End If

    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim dialog As DialogResult
            dialog = MessageBox.Show("Do you want to Close this?", "", MessageBoxButtons.YesNo)
            If dialog = DialogResult.No Then
                Beep()
                MsgBox("Cancel!!")
            Else
                ManageAnnouncement.ListView1.SelectedItems.Clear()
                Beep()
                Me.Close()
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'Intantiate the EJC SMS library to SMS as Object
    Private Sub bttnSend_Click(sender As Object, e As EventArgs) Handles bttnSend.Click
        Try
            If Label4.Text = "Label4" Or Label5.Text = "Label5" Then
                msgerror("Invalid, Please connect your modem")
                Exit Sub
            ElseIf cbAnnouncement.Text = "" Then
                msgerror("Invalid, Announcement is empty")
                Exit Sub
                'ElseIf cbAnnouncement.SelectedIndex = -1 Then
                '    msgerror("Invalid, Please Select Announcement")
                '    Exit Sub
                'ElseIf cbYearlevel.SelectedIndex = -1 Then
                '    msgerror("Invalid, Please Select Year Level")
                '    Exit Sub
            ElseIf lboxPhoneNumber.Items.Count = 0 Then
                msgerror("Invalid, No phone number")
                Exit Sub
            End If
            Dim recipient_number As New List(Of String) ' You need to declare this as List for you to able to send multiple recipient
            For Each numero As String In lboxPhoneNumber.Items ' For Each the lboxPhoneNumber ListBox 
                recipient_number.Add(numero) ' Add it on recipient_number list
            Next
            Dim tempStr As String
            'Dim countFail As Integer = SMS.SendMultipleSMS(recipient_number, cbAnnouncement.SelectedValue) ' Now you can send it to multiple recipient by doing this
            Dim countFail As Integer = SMS.SendMultipleSMS(recipient_number, cbTitle.SelectedValue + " " + cbAnnouncement.Text) ' Now you can send it to multiple recipient by doing this
            ' Check if there are number of fail to send
            If countFail > 0 Then
                tempStr = String.Format("There are {0} number of message that has been failed to deliver.", countFail)
                MessageBox.Show(tempStr, "Delivering Message has failed!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else ' If there were no fail then just show message normaly all message has been delivered.

                tempStr = String.Format("All mesages has been sent successfuly")

                MessageBox.Show(tempStr, "Message Delivery Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            ' Clear this shit.
            Insert_sms()


        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the EJC SMS with your existing GSM Modem Device Port
        'SMS.InitSMS(GSM_MODEM_PORT)
        ' SMS.InitSMS(Label5.Text)
    End Sub
    'Sub MERGE1()

    '    For r As Int32 = 0 To ListView1.Items.Count - 2
    '        For ra As Int32 = ListView1.Items.Count - 1 To r + 1 Step -1
    '            If ListView1.Items(r).ToString = ListView1.Items(ra).ToString Then
    '                ListView1.Items.RemoveAt(ra)

    '            End If
    '        Next
    '    Next

    'End Sub
    Private Sub removeduplicate()
        For row As Int16 = 0 To lboxPhoneNumber.Items.Count - 2
            For rowagain As Int16 = lboxPhoneNumber.Items.Count - 1 To row + 1 Step -1
                If lboxPhoneNumber.Items(row).ToString = lboxPhoneNumber.Items(rowagain).ToString Then
                    lboxPhoneNumber.Items.RemoveAt(rowagain)

                End If
            Next
        Next

    End Sub
    Sub fetch0()
        Try
            con.Close()
            con.Open()
            Dim cmd As SqlCommand
            Dim dr As SqlDataReader
            Dim sql As String
            sql = "Select * from tblStudentMasterList where Department  = '" + cbDepartment.Text + "' "
            cmd = New SqlCommand
            With cmd
                .Connection = con
                .CommandText = sql
                dr = .ExecuteReader()
            End With
            ListView1.Items.Clear()
            Do While dr.Read = True
                Dim list = ListView1.Items.Add(dr(0))
                list.SubItems.Add(dr(9))
            Loop
            If ListView1.Items.Count > 0 Then
                lboxPhoneNumber.Items.Clear()
                For Each item As ListViewItem In ListView1.Items
                    lboxPhoneNumber.Items.Add(item.SubItems(1).Text)
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Sub fetch()
        Try
            con.Close()
            con.Open()
            Dim cmd As SqlCommand
            Dim dr As SqlDataReader
            Dim sql As String
            sql = "Select * from tblStudentMasterList where Yearlevel  = '" & cbYearlevel.Text & "' AND Department = '" & cbDepartment.Text & "'"
            cmd = New SqlCommand
            With cmd
                .Connection = con
                .CommandText = sql
                dr = .ExecuteReader()
            End With
            ListView1.Items.Clear()
            Do While dr.Read = True
                Dim list = ListView1.Items.Add(dr(0))
                list.SubItems.Add(dr(9))
            Loop
            If ListView1.Items.Count > 0 Then
                lboxPhoneNumber.Items.Clear()
                For Each item As ListViewItem In ListView1.Items
                    lboxPhoneNumber.Items.Add(item.SubItems(1).Text)
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Sub fetch1()
        lboxPhoneNumber.Items.Clear()
        Try
            con.Close()
            con.Open()
            Dim cmd As SqlCommand
            Dim dr As SqlDataReader
            Dim sql As String
            sql = "Select * from tblStudentMasterList where Course  Like '%" & cbCourse.Text & "%' AND Yearlevel like '%" & cbYearlevel.Text & "%' AND Department like'%" & cbDepartment.Text & "%'"
            cmd = New SqlCommand
            With cmd
                .Connection = con
                .CommandText = sql
                dr = .ExecuteReader()
            End With
            ListView1.Items.Clear()
            Do While dr.Read = True
                Dim list = ListView1.Items.Add(dr(0))
                list.SubItems.Add(dr(9))
            Loop
            If ListView1.Items.Count > 0 Then
                lboxPhoneNumber.Items.Clear()
                For Each item As ListViewItem In ListView1.Items
                    lboxPhoneNumber.Items.Add(item.SubItems(1).Text)
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Sub fetch2()
        Try
            con.Close()
            con.Open()
            Dim cmd As SqlCommand
            Dim dr As SqlDataReader
            Dim sql As String
            sql = "Select * from tblStudentMasterList"
            cmd = New SqlCommand
            With cmd
                .Connection = con
                .CommandText = sql
                dr = .ExecuteReader()
            End With
            ListView1.Items.Clear()
            Do While dr.Read = True
                Dim list = ListView1.Items.Add(dr(0))
                list.SubItems.Add(dr(9))
            Loop
            If ListView1.Items.Count > 0 Then
                lboxPhoneNumber.Items.Clear()
                For Each item As ListViewItem In ListView1.Items
                    lboxPhoneNumber.Items.Add(item.SubItems(1).Text)
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Sub list()
        con.Close()
        con.Open()
        ListView1.Items.Clear()
        cmd.Connection = con
        cmd.CommandText = "Select * from tblStudentMasterList where Yearlevel  Like '%" & cbYearlevel.Text & "%' "
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

    Private Sub cbTitle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTitle.SelectedIndexChanged
        Try
            connect()
            con.Close()
            con.Open()
            Dim com As New SqlClient.SqlCommand
            com.Connection = con
            com.CommandText = "Select * from tblAnnouncement where Title = '" & cbTitle.Text & "'"
            Dim adpt As New SqlDataAdapter(com)
            Dim dt As New DataTable
            adpt.Fill(dt)
            cbAnnouncement.Text = dt.Rows(0)(2).ToString
        Catch ex As Exception
        End Try
    End Sub
    'Private Function InsertSMS()
    '    con.Close()
    '    con.Open()
    '    connect()
    '    cmd.Connection = con
    '    cmd.CommandText = " Insert INTO tblSmsAnnouncementRecord(Title,AnnouncementMsg,Yearlevel,Course,DateSended,ProcessedBy,UserID) " & _
    '        "VALUES (@TIT,@AN,@YL,@C,@DS,@PB,@UI)"
    '    cmd.Parameters.Clear()
    '    cmd.Parameters.AddWithValue("@TIT", cbTitle.Text)
    '    cmd.Parameters.AddWithValue("@AN", cbAnnouncement.Text)
    '    '' cmd.Parameters.AddWithValue("@ANN", cbAnnouncement.Text)
    '    cmd.Parameters.AddWithValue("@YL", cbYearlevel.Text)
    '    cmd.Parameters.AddWithValue("@C", cbCourse.Text)
    '    cmd.Parameters.AddWithValue("@DS", Date.Now)
    '    cmd.Parameters.AddWithValue("@PB", lblProcessedBy.Text)
    '    cmd.Parameters.AddWithValue("@UI", lblUserID.Text)
    '    Dim b As Integer = cmd.ExecuteNonQuery
    '    If b > 0 Then
    '        cbTitle.SelectedIndex = -1
    '        cbYearlevel.SelectedIndex = -1
    '        cbCourse.SelectedIndex = -1
    '        rbtnYES.Checked = False
    '        rbtnNO.Checked = False
    '        lboxPhoneNumber.Items.Clear()
    '        cbAnnouncement.Text = ""
    '        ''     MsgBox("hey")
    '    End If
    '    con.Close()
    '    Return Nothing
    'End Function
    Private Function Insert_sms()
        Try
        con.Close()
        con.Open()
        connect()
        With cmd
                .Connection = con
                .CommandText = "INSERT INTO tblSmsAnnouncementRecord (Title,AnnouncementMsg,Yearlevel,Course,DateSended,ProcessedBy,UserID,Department,TotalNoSended) " & _
                            "VALUES (@TIT,@AN,@YL,@C,@DS,@PB,@UI,@DM,@TNS)"
                .Parameters.Clear()
                .Parameters.AddWithValue("@TIT", cbTitle.Text)
                .Parameters.AddWithValue("@AN", cbAnnouncement.Text)
                .Parameters.AddWithValue("@YL", cbYearlevel.Text)
                .Parameters.AddWithValue("@C", cbCourse.Text)
                .Parameters.AddWithValue("@DS", Date.Now)
                .Parameters.AddWithValue("@PB", lblProcessedBy.Text)
                .Parameters.AddWithValue("@UI", lblUserID.Text)
                .Parameters.AddWithValue("@DM", cbDepartment.Text)
                .Parameters.AddWithValue("@TNS", Label16.Text)
      
        End With
        Dim a As Integer = cmd.ExecuteNonQuery()
        If a > 0 Then
                cbTitle.SelectedIndex = -1
                cbYearlevel.SelectedIndex = -1
                cbCourse.SelectedIndex = -1
                rbtnYES.Checked = False
                rbtnNO.Checked = False
                lboxPhoneNumber.Items.Clear()
                cbAnnouncement.Text = ""

        Else
            End If

        Catch ex As Exception
            msgerror(Err.Description)
        End Try
        Return Nothing
    End Function

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        cbDepartment.SelectedIndex = -1
        cbYearlevel.SelectedIndex = -1
        cbTitle.SelectedIndex = -1
        cbCourse.SelectedIndex = -1
        lboxPhoneNumber.Items.Clear()
        cbAnnouncement.Text = ""
        rbtnYES.Checked = False
        rbtnNO.Checked = False
    End Sub

    Private Sub cbCourse_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCourse.SelectedIndexChanged
        If cbCourse.Text <> "" Then
            rbtnNO.Checked = True
            lboxPhoneNumber.Items.Clear()
            fetch1()
            removeduplicate()
            totalNo_Sended()
        Else
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnYES.CheckedChanged
        If rbtnYES.Checked = True Then
            cbDepartment.SelectedIndex = -1
            cbYearlevel.SelectedIndex = -1
            cbCourse.SelectedIndex = -1
            lboxPhoneNumber.Items.Clear()
            fetch2()
            removeduplicate()
            totalNo_Sended()
        End If
    End Sub

    Private Sub rbtnNO_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnNO.CheckedChanged
        lboxPhoneNumber.Items.Clear()
        Label16.Text = ""
    End Sub

    Private Sub cbDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDepartment.SelectedIndexChanged
        loadYearLevel()
        If cbDepartment.Text <> "" Then
            rbtnNO.Checked = True
            cbCourse.SelectedIndex = -1
            lboxPhoneNumber.Items.Clear()
            fetch0()
            removeduplicate()
            totalNo_Sended()
        Else
        End If
    End Sub
    Private Sub totalNo_Sended()
        Dim i As Int16 = 0
        Dim test As String
        Try
            Do While 1 = 1
                test = lboxPhoneNumber.Items(i).ToString
                i = i + 1
            Loop
        Catch
            Label16.Text = i.ToString

        End Try
    End Sub
End Class

