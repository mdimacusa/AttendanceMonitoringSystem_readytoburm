Imports System.Data.SqlClient
Public Class SmsAnnouncementRecord

    Private Sub SmsAnnouncementRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        list()
    End Sub
    Sub list()
        Try
            con.Close()
            con.Open()
            ListView1.Items.Clear()
            cmd.Connection = con
            cmd.CommandText = "SELECT * FROM tblSmsAnnouncementRecord"
            Dim dataread3 As SqlDataReader = cmd.ExecuteReader
            Dim DelID As Integer
            Dim DeliveryID As String
            Dim delv As String
            Dim delf As String
            Dim dels As String
            Dim datesended As String
            Dim delss As String
            Dim datesendeds As String
            Dim total As String

            While dataread3.Read()
                DelID = dataread3.GetValue(0)
                DeliveryID = dataread3.GetValue(1)
                delv = dataread3.GetValue(2)
                delf = dataread3.GetValue(3)
                dels = dataread3.GetValue(4)
                datesended = dataread3.GetValue(5)
                delss = dataread3.GetValue(6)
                datesendeds = dataread3.GetValue(8)
                total = dataread3.GetValue(9)
                Dim arr(15) As String
                Dim itm As ListViewItem
                arr(0) = "" & DelID & ""
                arr(1) = "" & DeliveryID & ""
                arr(2) = "" & delv & ""
                arr(3) = "" & delf & ""
                arr(4) = "" & dels & ""
                arr(5) = "" & datesended & ""
                arr(6) = "" & delss & ""
                arr(7) = "" & datesendeds & ""
                arr(8) = "" & total & ""
                itm = New ListViewItem(arr)
                ListView1.Items.Add(itm)
            End While
            con.Close()
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
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

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class