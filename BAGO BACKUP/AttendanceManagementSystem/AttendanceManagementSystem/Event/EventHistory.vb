Imports System.Data.SqlClient
Public Class EventHistory
    Sub list()
        Try
            con.Close()
            con.Open()
            ListView1.Items.Clear()
            cmd.Connection = con
            cmd.CommandText = "SELECT * FROM tblEventHistory"
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

    Private Sub EventHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        list()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub
End Class