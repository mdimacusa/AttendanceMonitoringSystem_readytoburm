Imports System.Data.SqlClient
Public Class EventList
    Private Sub EventList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        list()
        listdelete()
        listTransform()
    End Sub
    Sub listTransform()
        Try
            For Each item As ListViewItem In Me.ListView1.Items
                If (item.SubItems(5).Text) = "" Then
                    item.SubItems(5).Text = "N/A"
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
    Sub listdelete()
        Try
            For Each item As ListViewItem In Me.ListView1.Items
                If CDate(item.SubItems(3).Text) < Date.Today Then
                    Dim NewIt As New ListViewItem
                    NewIt.Text = item.Text

                    con.Close()
                    con.Open()
                    connect()
                    cmd.Connection = con
                    cmd.CommandText = "INSERT INTO tblEventHistory (EventName,FromDate,ToDate,Department,Yearlevel) VALUES (@EN,@FD,@TD,@DM,@YL)"
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@EN", item.SubItems(1).Text)
                    cmd.Parameters.AddWithValue("@FD", item.SubItems(2).Text)
                    cmd.Parameters.AddWithValue("@TD", item.SubItems(3).Text)
                    cmd.Parameters.AddWithValue("@DM", item.SubItems(4).Text)
                    cmd.Parameters.AddWithValue("@YL", item.SubItems(5).Text)
                    Dim a As Integer = cmd.ExecuteNonQuery()
                    If a > 0 Then
                        ListView1.Items.RemoveAt(item.Index)
                        NewIt.SubItems.Add(NewIt.Text)

                    End If
                End If
            Next
            InsertNonExpired()
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
            listTransform()

        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub
    Private Sub btnADD_Click(sender As Object, e As EventArgs) Handles btnADD.Click
        EventMaintenance.txtID.Clear()
        EventMaintenance.txtEventName.Text = ""
        EventMaintenance.cbDepartment.Text = ""
        EventMaintenance.ShowDialog()
    End Sub

    Private Sub tbnDELETE_Click(sender As Object, e As EventArgs) Handles tbnDELETE.Click
        Try
            If Me.ListView1.SelectedItems.Count < 1 Then
                msgerror("Please Select Item to Remove")
                txtdate1.Text = ""
                txtdate2.Text = ""
                ListView1.SelectedItems.Clear()
                Exit Sub
            End If

            ' If Me.ListView1.SelectedItems.Count <> 0 Then
            Dim Event1 As String
            EventMaintenance.txtID.Text = ListView1.SelectedItems(0).Text
            EventMaintenance.txtSubEventName.Text = ListView1.SelectedItems(0).SubItems(1).Text
            Event1 = ListView1.SelectedItems(0).SubItems(1).Text
            txtdate1.Text = ListView1.SelectedItems(0).SubItems(2).Text
            txtdate2.Text = ListView1.SelectedItems(0).SubItems(3).Text
            If (txtdate1.Text <= Date.Today And txtdate2.Text >= Date.Today) Or (txtdate1.Text = Date.Today And txtdate2.Text = Date.Today) Or (txtdate1.Text <= Date.Today And txtdate2.Text >= Date.Today) Or (txtdate1.Text <= Date.Today And Date.Today = txtdate2.Text) Then
                msgerror("Invalid to delete this Event " + Event1 + "  " + txtdate1.Text + " / " + txtdate2.Text)
                txtdate1.Text = ""
                txtdate2.Text = ""
                ListView1.SelectedItems.Clear()
                Exit Sub
            Else
                'Date.Today <= txtdate1.Text And Date.Today < txtdate2.Text Then
                If MsgBox("Are you sure to delete this data?", vbYesNo) = MsgBoxResult.Yes Then
                    con.Close()
                    con.Open()
                    connect()
                    Dim ID As String
                    ID = ListView1.SelectedItems(0).SubItems(0).Text
                    cmd.Connection = con
                    cmd.CommandText = "DELETE tblEvent WHERE ID='" & ID & "'"
                    Dim i As Integer = cmd.ExecuteNonQuery()
                    AuditTrail("Event Maintenace ", "Delete", "Event name: " + ListView1.SelectedItems(0).SubItems(1).Text + "|From Date: " + ListView1.SelectedItems(0).SubItems(2).Text + "|To Date: " + ListView1.SelectedItems(0).SubItems(3).Text + "|Department :" + ListView1.SelectedItems(0).SubItems(4).Text)
                    If i > 0 Then
                        MsgBox("Event Name Removed.")
                        txtdate1.Text = ""
                        txtdate2.Text = ""
                        list()
                        Exit Sub
                    End If
                    con.Close()
                ElseIf MsgBoxResult.No Then
                    EventMaintenance.txtID.Clear()
                    EventMaintenance.txtSubEventName.Clear()
                    ListView1.SelectedItems.Clear()
                    MsgBox("Canceled", MsgBoxStyle.Information)
                    Exit Sub
                End If

            End If


        Catch ex As Exception
            msgerror(Err.Description)
        End Try
        'If txtdate1.Text <= Date.Today And txtdate2.Text >= Date.Today Then
        '    msgerror("Invalid to delete this Event " + Event1 + "  " + txtdate1.Text + " / " + txtdate2.Text)

        'ElseIf txtdate1.Text = Date.Today And txtdate2.Text = Date.Today Then
        '    msgerror("Invalid to delete this Event " + Event1 + "  " + txtdate1.Text + " / " + txtdate2.Text)

        'ElseIf txtdate1.Text <= Date.Today And txtdate2.Text >= Date.Today Then
        '    msgerror("Invalid to delete this Event " + Event1 + "  " + txtdate1.Text + " / " + txtdate2.Text)

        'ElseIf txtdate1.Text <= Date.Today And Date.Today = txtdate2.Text Then
        '    msgerror("Invalid to delete this Event " + Event1 + "  " + txtdate1.Text + " / " + txtdate2.Text)
        '    Exit Sub

        'End If
        'If MsgBox("Are you sure to delete this data?", vbYesNo) = MsgBoxResult.Yes Then
        '      con.Close()
        '      con.Open()
        '      connect()
        '      Dim ID As String
        '      ID = ListView1.SelectedItems(0).SubItems(0).Text
        '      cmd.Connection = con
        '      cmd.CommandText = "DELETE tblEvent WHERE ID='" & ID & "'"
        '      Dim i As Integer = cmd.ExecuteNonQuery()
        '      If i > 0 Then
        '          MsgBox("Event Name Removed.")
        '          list()
        '          Exit Sub
        '      End If
        '      con.Close()
        '  ElseIf MsgBoxResult.No Then
        '      EventMaintenance.txtID.Clear()
        '      EventMaintenance.txtSubEventName.Clear()
        '      ListView1.SelectedItems.Clear()
        '      MsgBox("Canceled", MsgBoxStyle.Information)
        '  End If
    End Sub

    Private Sub tbnEDIT_Click(sender As Object, e As EventArgs) Handles tbnEDIT.Click
        Try
            If ListView1.SelectedItems.Count <> 0 Then
                txtdate1.Text = ListView1.SelectedItems(0).SubItems(2).Text
                txtdate2.Text = ListView1.SelectedItems(0).SubItems(3).Text
            End If
            If Me.ListView1.SelectedItems.Count < 1 Then
                msgerror("Please select item to update")
                txtdate1.Text = ""
                txtdate2.Text = ""
                ListView1.Enabled = True
                Exit Sub
            End If
            If txtdate1.Text <= Date.Today And txtdate2.Text >= Date.Today Then
                msgerror("Invalid, Cannot update this data due to current event is progress")
                txtdate1.Text = ""
                txtdate2.Text = ""
                Exit Sub
            Else
                If ListView1.SelectedItems.Count <> 0 Then
                    EventMaintenance.txtID.Text = ListView1.SelectedItems(0).Text
                    EventMaintenance.txtEventName.Text = ListView1.SelectedItems(0).SubItems(1).Text
                    EventMaintenance.txtEvent1.Text = ListView1.SelectedItems(0).SubItems(1).Text
                    EventMaintenance.txtSubEventName.Text = ListView1.SelectedItems(0).SubItems(1).Text
                    EventMaintenance.Date1 = ListView1.SelectedItems(0).SubItems(2).Text
                    EventMaintenance.Date2 = ListView1.SelectedItems(0).SubItems(3).Text
                    EventMaintenance.Department = ListView1.SelectedItems(0).SubItems(4).Text
                    EventMaintenance.txtDepart1.Text = ListView1.SelectedItems(0).SubItems(4).Text
                    EventMaintenance.txtSubDepartment.Text = ListView1.SelectedItems(0).SubItems(4).Text
                    EventMaintenance.txtYlevel1.Text = ListView1.SelectedItems(0).SubItems(5).Text
                    EventMaintenance.cbYearlevel.Text = ListView1.SelectedItems(0).SubItems(5).Text
                    EventMaintenance.txtSubYearlevel.Text = ListView1.SelectedItems(0).SubItems(5).Text
                    EventMaintenance.ShowDialog()
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Beep()
        Me.Close()
    End Sub

    Private Sub btnEventHistory_Click(sender As Object, e As EventArgs) Handles btnEventHistory.Click
        EventHistory.ShowDialog()
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class