Imports System.Data.SqlClient
Public Class AuditTrailHistory
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try

            Dim dialog As DialogResult
            dialog = MessageBox.Show("Do you want to Close this?", "", MessageBoxButtons.YesNo)
            If dialog = DialogResult.No Then

                Beep()
                MsgBox("Cancel!!")



            Else
                Beep()

                Me.Close()


            End If

        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub
    Sub list()
        con.Close()
        con.Open()
        ListView1.Items.Clear()
        cmd.Connection = con
        cmd.CommandText = "SELECT * FROM tblAuditTrail"
        Dim dataread3 As SqlDataReader = cmd.ExecuteReader

        Dim DelID As Integer
        Dim DeliveryID As String
        Dim delb As String
        Dim delc As String
        Dim deld As String
        Dim dele As String
        Dim dele1 As String

        While dataread3.Read()
            DelID = dataread3.GetValue(0)
            DeliveryID = dataread3.GetValue(1)
            delb = dataread3.GetValue(2)
            delc = dataread3.GetValue(3)
            deld = dataread3.GetValue(4)
            dele = dataread3.GetValue(5)
        
            Dim arr(15) As String
            Dim itm As ListViewItem

            arr(0) = "" & DelID & ""
            arr(1) = "" & DeliveryID & ""
            arr(2) = "" & delb & ""
            arr(3) = "" & delc & ""
            arr(4) = "" & deld & ""
            arr(5) = "" & dele & ""



            itm = New ListViewItem(arr)
            ListView1.Items.Add(itm)

        End While
        con.Close()

    End Sub

    Private Sub AuditTrail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        list()
    End Sub
End Class