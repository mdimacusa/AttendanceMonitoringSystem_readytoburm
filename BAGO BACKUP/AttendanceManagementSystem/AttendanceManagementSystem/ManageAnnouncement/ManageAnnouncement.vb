Imports System.Data.SqlClient
Public Class ManageAnnouncement

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
                Beep()
                Me.Close()
                MainForm.Show()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ManageAnnouncement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        list()
    End Sub
    Sub list()
        con.Close()
        con.Open()
        ListView1.Items.Clear()
        cmd.Connection = con
        cmd.CommandText = "SELECT * FROM tblAnnouncement"
        Dim dataread3 As SqlDataReader = cmd.ExecuteReader

        Dim DelID As Integer
        Dim DeliveryID As String
        Dim DAT As String

        While dataread3.Read()
            DelID = dataread3.GetValue(0)
            DeliveryID = dataread3.GetValue(1)
            DAT = dataread3.GetValue(2)

            Dim arr(15) As String
            Dim itm As ListViewItem

            arr(0) = "" & DelID & ""
            arr(1) = "" & DeliveryID & ""
            arr(2) = "" & DAT & ""

            itm = New ListViewItem(arr)
            ListView1.Items.Add(itm)

        End While
        con.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AnnouncementMaintenance.txtID.Clear()
        AnnouncementMaintenance.txtAnnouncementMsg.Clear()
        AnnouncementMaintenance.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If ListView1.SelectedItems.Count <> 0 Then
                AnnouncementMaintenance.txtID.Text = ListView1.SelectedItems(0).Text
                '  AnnouncementMaintenance.Dates = ListView1.SelectedItems(0).SubItems(2).Text
                AnnouncementMaintenance.txtTitle.Text = ListView1.SelectedItems(0).SubItems(1).Text
                AnnouncementMaintenance.txtAnnouncementMsg.Text = ListView1.SelectedItems(0).SubItems(2).Text
                AnnouncementMaintenance.ShowDialog()

            ElseIf Me.ListView1.SelectedItems.Count < 1 Then
                msgerror("Please select item to update")
                ListView1.Enabled = True
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If ListView1.SelectedItems.Count <> 0 Then
                AnnouncementMaintenance.txtID.Text = ListView1.SelectedItems(0).Text

                con.Close()
                con.Open()
                If MsgBox("Are you sure to delete this data?", vbYesNo) = MsgBoxResult.Yes Then

                    Dim ID As String
                    ID = ListView1.SelectedItems(0).SubItems(0).Text

                    cmd.Connection = con
                    cmd.CommandText = "DELETE tblAnnouncement WHERE ID='" & ID & "'"

                    Dim i As Integer = cmd.ExecuteNonQuery()

                    If i > 0 Then
                        MsgBox("Announcement Removed.")


                        list()
                    End If
                ElseIf MsgBoxResult.No Then
                    AnnouncementMaintenance.txtID.Clear()
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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        SmsAnnouncement.ShowDialog()
    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        SmsAnnouncementRecord.ShowDialog()
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class