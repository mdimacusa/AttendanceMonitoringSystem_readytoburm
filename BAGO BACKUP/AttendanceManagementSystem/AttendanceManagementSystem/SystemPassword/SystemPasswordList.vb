Imports System.Data.SqlClient
Public Class SystemPasswordList

    Private Sub SystemPasswordList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        list()
        CountItem()
    End Sub
    Sub list()
        con.Close()
        con.Open()
        ListView1.Items.Clear()
        cmd.Connection = con
        cmd.CommandText = "SELECT * FROM tblSystemPassword"
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

            CountItem()
        End While
        con.Close()

    End Sub
    Sub CountItem()
        txtCount.Text = ListView1.Items.Count
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Beep()
            Me.Close()
            Main.Show()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnADD_Click(sender As Object, e As EventArgs) Handles btnADD.Click
        SystemPasswordMaintenance.txtID.Clear()
        SystemPasswordMaintenance.txtSystemPassword.Clear()
        SystemPasswordMaintenance.ShowDialog()
    End Sub

    Private Sub tbnEDIT_Click(sender As Object, e As EventArgs) Handles tbnEDIT.Click
        Try
            If ListView1.SelectedItems.Count <> 0 Then
                SystemPasswordMaintenance.txtID.Text = ListView1.SelectedItems(0).Text
                SystemPasswordMaintenance.txtSystemPassword.Text = ListView1.SelectedItems(0).SubItems(1).Text
                SystemPasswordMaintenance.ShowDialog()

            ElseIf Me.ListView1.SelectedItems.Count < 1 Then
                msgerror("Please select item to update")
                ListView1.Enabled = True
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tbnDELETE_Click(sender As Object, e As EventArgs) Handles tbnDELETE.Click
        Try
            If txtCount.Text <= 1 Then
                msgerror("Invalid to Remove")
                ListView1.SelectedItems.Clear()
                Exit Sub
            End If
            If ListView1.SelectedItems.Count <> 0 Then
                SystemPasswordMaintenance.txtID.Text = ListView1.SelectedItems(0).Text

                con.Close()
                con.Open()
                If MsgBox("Are you sure to delete this data?", vbYesNo) = MsgBoxResult.Yes Then

                    Dim ID As String
                    ID = ListView1.SelectedItems(0).SubItems(0).Text

                    cmd.Connection = con
                    cmd.CommandText = "DELETE tblSystemPassword WHERE ID='" & ID & "'"

                    Dim i As Integer = cmd.ExecuteNonQuery()

                    If i > 0 Then
                        MsgBox("System Password Removed.")


                        list()
                    End If
                ElseIf MsgBoxResult.No Then
                    SystemPasswordMaintenance.txtID.Clear()
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
End Class