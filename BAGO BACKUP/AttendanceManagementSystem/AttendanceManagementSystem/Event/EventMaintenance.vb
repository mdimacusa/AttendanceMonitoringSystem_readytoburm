Imports System.Data.SqlClient
Public Class EventMaintenance
    Public Date1 As String
    Public Date2 As String
    Public Department As String
    Public Yearlevel As String
    Public Sub loadDepartment()
        Try
            con.Close()
            con.Open()
            Dim Cmd As New SqlClient.SqlCommand("SELECT Department FROM tblDepartment", con)
            Cmd.ExecuteNonQuery()
            dt = New DataSet
            adp = New SqlDataAdapter(Cmd)
            adp.Fill(dt)
            cbDepartment.Items.Clear()
            cbDepartment.Items.Add("All")
            For Each dr As DataRow In dt.Tables(0).Rows
                cbDepartment.Items.Add(dr("Department"))
            Next
        Catch ex As Exception
            msgerror(Err.Description)
            con.Close()
        End Try
    End Sub
    Sub loadYearLevel()
        Try
            con.Close()
            con.Open()
            Dim cmd As New SqlClient.SqlCommand("SELECT DISTINCT Yearlevel FROM tblYearlevel where Department = '" + cbDepartment.Text + "'", con)
            Dim reader As SqlClient.SqlDataReader
            reader = cmd.ExecuteReader

            cbYearlevel.Items.Clear()
            cbYearlevel.Items.Add("All")
            While reader.Read
                cbYearlevel.Items.Add(reader("Yearlevel"))
            End While

        Catch ex As Exception
            msgerror(Err.Description)
            con.Close()
        End Try
    End Sub
    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        If txtEventName.Text = "" Then
            msgerror("Invalid, EventName is empty")
        ElseIf cbDepartment.SelectedIndex = -1 Then
            msgerror("Invalid, Yearlevel is empty")
        ElseIf (txtEventName.Text.EndsWith(" ")) Then
            msgerror("Invalid format EventName  " + txtEventName.Text + "''Space''")
        ElseIf txtEventName.TextLength < 5 Then
            msgerror("Invalid, Eventname must be 5 to 100 characters")
        ElseIf txtFromDate.Value > txtToDate.Value Then
            msgerror("Invalid, Please use proper date")
        ElseIf txtEventName.Text <> "" And cbDepartment.Text <> "All" And cbYearlevel.Text = "" Then
            msgerror("Invalid, Please select yearlevel")
        ElseIf txtEventName.Text <> "" And cbDepartment.Text = "All" And cbYearlevel.Text = "" Then
            InsertEvent()
        ElseIf txtFromDate.Value = Date.Today And txtToDate.Value = Date.Today Then
            InsertEvent()
        ElseIf (txtFromDate.Value > txtToDate.Value) Or (txtFromDate.Value < Date.Today) Or (txtToDate.Value <= Date.Today) Then
            msgerror("Invalid, Please use proper date")
        ElseIf txtID.Text = "" Then
            InsertEvent()

        End If
    End Sub
    Private Function InsertEvent()
        Try
            con.Close()
            con.Open()

            connect()

            Dim cmd As New SqlCommand("Select * from tblEvent where EventName = @EN and Department = '" + cbDepartment.Text + "'AND Yearlevel = '" + cbYearlevel.Text + "' ", con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@EN", txtEventName.Text)

            cmd.ExecuteNonQuery()
            dt = New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dt, "a")
            If dt.Tables("a").Rows.Count <> 0 Then
                msgerror("Eventname: " + txtEventName.Text + " Department: " + cbDepartment.Text + " Yearlevel: " + cbYearlevel.Text + " Already Exists")


            Else
                If MsgBox("Are you sure you want to add this data?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    connect()
                    cmd.CommandText = " Insert INTO tblEvent(EventName,FromDate,ToDate,Department,Yearlevel) VALUES (@EN,@FD,@TD,@DM,@YL)"
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@EN", txtEventName.Text)
                    cmd.Parameters.AddWithValue("@FD", txtFromDate.Text)
                    cmd.Parameters.AddWithValue("@TD", txtToDate.Text)
                    cmd.Parameters.AddWithValue("@DM", cbDepartment.Text)
                    cmd.Parameters.AddWithValue("@YL", cbYearlevel.Text)
                    Dim a As Integer = cmd.ExecuteNonQuery()
                    AuditTrail("Event Maintenace ", "Add", "Event name: " + txtEventName.Text + "|From Date: " + txtFromDate.Text + "|To Date: " + txtToDate.Text + "|Department :" + cbDepartment.Text + "|Yearlevel :" + cbYearlevel.Text)
                    If a > 0 Then

                        msginfo("Successfully Added")
                        EventList.list()    ''<-------------- ITO YUNG ERROR
                        txtEventName.Text = ""
                        ' txtNoDays.Text = ""
                        txtID.Text = ""
                        Date1 = ""
                        Date2 = ""
                        cbDepartment.SelectedIndex = -1
                    End If


                End If



            End If

        Catch ex As Exception
        End Try



        Return Nothing
    End Function
    Private Function UpdateEvent()
   

                Try
                    con.Close()
                    con.Open()
                    If MsgBox("Are you sure you want to update this data?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        connect()
                cmd.Connection = con
                cmd.CommandText = "Update tblEvent SET  EventName = @EN, FromDate = @FD, ToDate = @TD, Department = @DM, Yearlevel = @YL where Id = '" & txtID.Text & "'"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@EN", txtEventName.Text)
                cmd.Parameters.AddWithValue("@FD", txtFromDate.Text)
                cmd.Parameters.AddWithValue("@TD", txtToDate.Text)
                cmd.Parameters.AddWithValue("@DM", cbDepartment.Text)
                cmd.Parameters.AddWithValue("@YL", cbYearlevel.Text)
                Dim a As Integer = cmd.ExecuteNonQuery()
                AuditTrail("Event Maintenace ", "Update", "Event name: " + txtEventName.Text + "|From Date: " + txtFromDate.Text + "|To Date: " + txtToDate.Text + "|Department :" + cbDepartment.Text + "|Yearlevel :" + cbYearlevel.Text)
                If a > 0 Then
                    UpdateEventER()
                    MsgBox("Updated Successfully.")
                    EventList.list()

                    txtEventName.Text = ""
                    ' txtNoDays.Text = ""
                    txtID.Text = ""
                    Date1 = ""
                    Date2 = ""
                    Me.Close()
                    EventList.ListView1.SelectedItems.Clear()
                Else
                    MsgBox("Failed to Update.")

                End If
            End If

                Catch ex As Exception
                    msgerror(Err.Description)
                End Try
        Return Nothing
    End Function
    'Private Function ValEvDm()
    '    Try
    '        connect()
    '        Dim adp As New SqlDataAdapter
    '        Dim dt As New DataTable
    '        Dim query As String = "SELECT * FROM tblEvent WHERE Department = @DM AND EventName'" + txtEventName.Text + "'"

    '        Dim cmd As New SqlCommand(query, con)
    '        cmd.Parameters.Clear()
    '        cmd.Parameters.AddWithValue("@DM", cbDepartment.Text)

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
    Private Function UpdateEventER()
        con.Close()
        con.Open()
        connect()
        With cmd
            .Connection = con
            .CommandText = "Update tblEventRecord SET  Event = @E, Department = @DM where Event = '" & txtSubEventName.Text & "'AND Department = '" + txtSubDepartment.Text + "'"
            .Parameters.Clear()
            .Parameters.AddWithValue("@E", txtEventName.Text)
            .Parameters.AddWithValue("@DM", cbDepartment.Text)
        End With


        Dim a As Integer = cmd.ExecuteNonQuery()
        If a > 0 Then
            EventRecord.list()
        End If
        Return Nothing
    End Function
    Sub clear()
        txtEventName.Text = ""
        cbDepartment.SelectedIndex = -1
        cbYearlevel.SelectedIndex = -1
        Department = ""
        Yearlevel = ""

    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try

            Dim dialog As DialogResult
            dialog = MessageBox.Show("Do you want to Close this?", "", MessageBoxButtons.YesNo)
            If dialog = DialogResult.No Then
                Beep()
                MsgBox("Cancel!!")
            Else
                EventList.ListView1.SelectedItems.Clear()
                Date1 = ""
                Date2 = ""
                Beep()
                clear()
                Me.Close()
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub

    Private Sub EventMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'txtFromDate.Value = Date.Today
        'txtToDate.Value = Date.Today
        loadDepartment()
        cbDepartment.SelectedIndex = -1
        cbDepartment.Text = Department
        cbYearlevel.Text = Yearlevel

        If Date1 <> "" And Date2 <> "" Then
            txtFromDate.Text = Date1
            txtToDate.Text = Date2
        ElseIf Date1 = "" And Date2 = "" Then
            txtFromDate.Text = Date.Today
            txtToDate.Text = Date.Today
        End If

        If txtID.Text = "" Then
            btnSAVE.Visible = True
            btnUpdate.Visible = False
        ElseIf txtID.Text <> "" Then
            btnSAVE.Visible = False
            btnUpdate.Visible = True
        End If
    End Sub

    Private Sub txtEventName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEventName.KeyDown 
        If txtEventName.Text <> "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = False
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        ElseIf txtEventName.Text = "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        End If
    End Sub

    Private Sub txtEventName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEventName.KeyPress
        If e.KeyChar = " " AndAlso txtEventName.Text.EndsWith(" ") Then
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
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If txtEventName.Text = "" Then
            msgerror("Invalid, EventName is empty")
        ElseIf txtFromDate.Value = Date.Today And txtToDate.Value = Date.Today Then
            UpdateEvent()
        ElseIf (txtFromDate.Value > txtToDate.Value) Or (txtFromDate.Value < Date.Today) Or (txtToDate.Value <= Date.Today) Then
            msgerror("Invalid, Please use proper date")
        ElseIf txtEventName.Text <> "" And cbDepartment.Text <> "All" And cbYearlevel.Text = "" Then
            msgerror("Invalid, Please use proper date")
        ElseIf txtEventName.Text <> "" And cbDepartment.Text = "All" And cbYearlevel.Text = "" Then
            UpdateEvent()
        ElseIf txtEvent1.Text = txtEventName.Text And txtDepart1.Text = cbDepartment.Text And txtYlevel1.Text = cbYearlevel.Text Then
            UpdateEvent()
        ElseIf txtEvent1.Text <> txtEventName.Text And txtDepart1.Text = cbDepartment.Text And txtYlevel1.Text = cbYearlevel.Text Then
            If EVENTDMCHECKER() = True Then
                msgerror("Eventname: " + txtEventName.Text + " Department: " + cbDepartment.Text + " is already exist")
            ElseIf EVENTDMCHECKER() = False Then
                UpdateEvent()
            End If
            Exit Sub
        ElseIf txtEvent1.Text = txtEventName.Text And txtDepart1.Text <> cbDepartment.Text And txtYlevel1.Text = cbYearlevel.Text Then
            If EVENTDMCHECKER() = True Then
                msgerror("Eventname: " + txtEventName.Text + " Department: " + cbDepartment.Text + " is already exist")
            ElseIf EVENTDMCHECKER() = False Then
                UpdateEvent()
            End If
            Exit Sub
        ElseIf txtEvent1.Text = txtEventName.Text And txtDepart1.Text = cbDepartment.Text And txtYlevel1.Text <> cbYearlevel.Text Then
            If EVENTDMCHECKER() = True Then
                msgerror("Eventname: " + txtEventName.Text + " Department: " + cbDepartment.Text + " is already exist")
            ElseIf EVENTDMCHECKER() = False Then
                UpdateEvent()
            End If
            Exit Sub
        ElseIf txtID.Text <> "" Then
            UpdateEvent()
            'Else
            '    UpdateEvent()

        End If
    End Sub
    Public Function EVENTDMCHECKER()
        Try
            connect()
            Dim adp As New SqlDataAdapter
            Dim dt As New DataTable
            Dim query As String = "SELECT * FROM tblEvent WHERE EventName = @EN AND Department = @DM AND Yearlevel = @YL"

            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@EN", txtEventName.Text)
            cmd.Parameters.AddWithValue("@DM", cbDepartment.Text)
            cmd.Parameters.AddWithValue("@YL", cbYearlevel.Text)


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
    'Public Function DMCHECKER()
    '    Try
    '        connect()
    '        Dim adp As New SqlDataAdapter
    '        Dim dt As New DataTable
    '        Dim query As String = "SELECT * FROM tblEvent WHERE Department = @DM"

    '        Dim cmd As New SqlCommand(query, con)
    '        cmd.Parameters.Clear()
    '        cmd.Parameters.AddWithValue("@DM", cbDepartment.Text)

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
    Private Sub txtEventName_LostFocus(sender As Object, e As EventArgs) Handles txtEventName.LostFocus
        txtEventName.Text = StrConv(txtEventName.Text, vbProperCase)
    End Sub
 
    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub txtEventName_TextChanged(sender As Object, e As EventArgs) Handles txtEventName.TextChanged

    End Sub

    Private Sub cbDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDepartment.SelectedIndexChanged
        loadYearLevel()
        If cbDepartment.Text = "All" Then
            cbYearlevel.Enabled = False
        Else
            cbYearlevel.Enabled = True
        End If
    End Sub
End Class