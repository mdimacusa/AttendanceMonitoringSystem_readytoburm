Imports System.Data.SqlClient
Public Class LogHistory

    Private Sub LogHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        list()
    End Sub
    Sub list()
        con.Close()
        con.Open()
        ListView1.Items.Clear()
        cmd.Connection = con
        cmd.CommandText = "SELECT id,LogId,UserID,Username,Usertype,Datein,Dateout FROM tblLogHistory"
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
            delb = dataread3.GetValue(6)
            delc = dataread3.GetValue(2)
            deld = dataread3.GetValue(3)
            dele = dataread3.GetValue(4)
            dele1 = dataread3.GetValue(5)

            Dim arr(15) As String
            Dim itm As ListViewItem

            arr(0) = "" & DelID & ""
            arr(1) = "" & DeliveryID & ""
            arr(6) = "" & delb & ""
            arr(2) = "" & delc & ""
            arr(3) = "" & deld & ""
            arr(4) = "" & dele & ""
            arr(5) = "" & dele1 & ""


            itm = New ListViewItem(arr)
            ListView1.Items.Add(itm)

        End While
        con.Close()

    End Sub

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

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub
End Class