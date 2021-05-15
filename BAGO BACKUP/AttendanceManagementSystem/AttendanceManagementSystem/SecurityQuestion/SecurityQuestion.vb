Imports System.Data.SqlClient
Public Class SecurityQuestion
    Private Sub SecurityQuestion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        list()
    End Sub
    Sub list()
        con.Close()
        con.Open()
        ListView1.Items.Clear()
        cmd.Connection = con
        cmd.CommandText = "SELECT * FROM tblSecurityQuestion"
        Dim dataread3 As SqlDataReader = cmd.ExecuteReader
        Dim DelID As Integer
        Dim DeliveryID As String
        While dataread3.Read()
            DelID = dataread3.GetValue(0)
            DeliveryID = dataread3.GetValue(1)
            Dim arr(10) As String
            Dim itm As ListViewItem
            arr(0) = "" & DelID & ""
            arr(1) = "" & DeliveryID & ""
            itm = New ListViewItem(arr)
            ListView1.Items.Add(itm)
        End While
        con.Close()
    End Sub

    Private Sub tbnDELETE_Click(sender As Object, e As EventArgs) Handles tbnDELETE.Click
        Try
            If checkSecurityQuestionADMIN() = True Then
                msgerror("Cannot removed this data, Security Question exists in user account")
            ElseIf Me.ListView1.SelectedItems.Count < 1 Then
                msgerror("Please Select Item to Remove")
            Else
                DeleteSecurityQuestion()
                Exit Sub
            End If
            If ListView1.SelectedItems.Count <> 0 Then
                SecurityQuestionMaintenance.txtID.Text = ListView1.SelectedItems(0).Text
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try

    End Sub
    Public Sub DeleteSecurityQuestion()
        Try
            If ListView1.SelectedItems.Count <> 0 Then
                SecurityQuestionMaintenance.txtID.Text = ListView1.SelectedItems(0).Text

                con.Close()
                con.Open()
                Dim ID As String
                ID = ListView1.SelectedItems(0).SubItems(0).Text
                If MsgBox("Are you sure to delete this data?", vbYesNo) = MsgBoxResult.Yes Then
                    cmd.Connection = con
                    cmd.CommandText = "DELETE tblSecurityQuestion WHERE ID='" & ID & "'"

                    Dim i As Integer = cmd.ExecuteNonQuery()
                    AuditTrail("Security Question Maintenance ", "Delete", "Security Question: " + ListView1.SelectedItems(0).SubItems(1).Text)
                    If i > 0 Then
                        MsgBox("Security Question Removed.")
                        SecurityQuestionMaintenance.clear()
                        list()
                    End If
                ElseIf MsgBoxResult.No Then
                    SecurityQuestionMaintenance.txtID.Clear()
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
    Public Function checkSecurityQuestionADMIN()
        Try
            con.Close()
            con.Open()
            connect()
            Dim adp As New SqlDataAdapter
            Dim dt As New DataTable
            Dim query As String = "SELECT * FROM tblAdmin WHERE Question = @SQ"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@SQ", txtSecQues.Text)
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

    Private Sub tbnEDIT_Click(sender As Object, e As EventArgs) Handles tbnEDIT.Click
        Try

            If Me.ListView1.SelectedItems.Count < 1 Then
                msgerror("Please select item to update")
                Exit Sub
            End If
            con.Close()
            con.Open()


            Dim ID As String
            ID = ListView1.SelectedItems(0).SubItems(0).Text
            que = "select * from tblAdmin where Qid = '" & ID & "'"
            adp = New SqlDataAdapter(que, con)
            dt = New DataSet
            adp.Fill(dt, "a")
            If dt.Tables("a").Rows.Count <> 0 Then
                SecurityQuestionMaintenance.txtID.Clear()
                ListView1.SelectedItems.Clear()
                msgerror("Cannot Update This Data Security Question Exist in User Account")
                SecurityQuestionMaintenance.txtID.Clear()
                ListView1.SelectedItems.Clear()
            Else
                If ListView1.SelectedItems.Count <> 0 Then
                    SecurityQuestionMaintenance.txtID.Text = ListView1.SelectedItems(0).Text
                    SecurityQuestionMaintenance.txtSecurityQuestion.Text = ListView1.SelectedItems(0).SubItems(1).Text
                    SecurityQuestionMaintenance.ShowDialog()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnADD_Click(sender As Object, e As EventArgs) Handles btnADD.Click
        SecurityQuestionMaintenance.txtID.Clear()
        SecurityQuestionMaintenance.txtSecurityQuestion.Clear()
        SecurityQuestionMaintenance.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try



            ManageAnnouncement.ListView1.SelectedItems.Clear()

            Beep()

            Me.Close()
            MainForm.Show()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count <> 0 Then
            txtSecQues.Text = ListView1.SelectedItems(0).SubItems(1).Text
        End If
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class