Imports System.Data.SqlClient
Public Class SecurityQuestionMaintenance

    Private Sub SecurityQuestionMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Sub clear()
        txtID.Text = ""
        txtSecurityQuestion.Text = ""
    End Sub

    Private Function InsertSecurityQuestion()
        Try
            connect()
            con.Close()
            con.Open()
            If txtID.Text = "" Then
                Dim cmd As New SqlCommand("Select * from tblSecurityQuestion where SecurityQuestion = @SN and ID <> '" & txtID.Text & "'", con)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@SN", txtSecurityQuestion.Text)
                cmd.ExecuteNonQuery()
                dt = New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dt, "a")
                If dt.Tables("a").Rows.Count <> 0 Then
                    msgerror("Security Question Already Exist")

                Else
                    Try
                        If MsgBox("Are you sure you want to add this?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            connect()
                            cmd.Connection = con
                            cmd.CommandText = "INSERT INTO tblSecurityQuestion (SecurityQuestion) " & _
                                "VALUES (@EN)"

                            cmd.Parameters.Clear()
                            cmd.Parameters.AddWithValue("@EN", txtSecurityQuestion.Text)


                            Dim a As Integer = cmd.ExecuteNonQuery()
                            AuditTrail("Security Question Maintenance ", "Insert", "Security Question: " + txtSecurityQuestion.Text)
                            If a > 0 Then
                                SecurityQuestion.list()
                                msginfo("Saved!")
                                clear()
                            Else
                                MsgBox("Failed")

                            End If

                        End If
                    Catch ex As Exception
                        msgerror(Err.Description)
                    End Try
                End If
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
        con.Close()


        Return Nothing

    End Function
    Private Function UpdateSecurityQuestion()
        Try

            con.Close()
            con.Open()

            connect()

            Dim cmd As New SqlCommand("Select * from tblSecurityQuestion where SecurityQuestion = @SN and ID <> '" & txtID.Text & "'", con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@SN", txtSecurityQuestion.Text)
            cmd.ExecuteNonQuery()
            dt = New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dt, "a")
            If dt.Tables("a").Rows.Count <> 0 Then
                msgerror("Security Question Already Exist")


            Else

                Try
                    con.Close()
                    con.Open()
                    connect()
                    With cmd
                        .Connection = con
                        .CommandText = "Update tblSecurityQuestion SET  SecurityQuestion = @SN where Id = '" & txtID.Text & "'"
                        .Parameters.Clear()
                        .Parameters.AddWithValue("@SN", txtSecurityQuestion.Text)



                    End With


                    Dim a As Integer = cmd.ExecuteNonQuery()
                    AuditTrail("Security Question Maintenance ", "Update", "Security Question: " + txtSecurityQuestion.Text)
                    If a > 0 Then

                        MsgBox("Updated Successfully.")
                        SecurityQuestion.list()
                        clear()
                        Me.Close()
                    Else
                        MsgBox("Failed to Update.")

                    End If


                Catch ex As Exception
                    msgerror(Err.Description)
                End Try



            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try




        Return Nothing
    End Function

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click
        If txtSecurityQuestion.Text = "" Then
            msgerror("Invalid, Security Question is empty")
        ElseIf (txtSecurityQuestion.Text.EndsWith(" ")) Then
            msgerror("Invalid format Security Question " + txtSecurityQuestion.Text + "''Space''")
        ElseIf txtSecurityQuestion.TextLength < 5 Then
            msgerror("Invalid, Security Question must be 5 to 100 characters")
        ElseIf txtID.Text = "" Then
            InsertSecurityQuestion()
        ElseIf txtID.Text <> "" Then
            UpdateSecurityQuestion()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try



            Dim dialog As DialogResult
            dialog = MessageBox.Show("Do you want to Close this?", "", MessageBoxButtons.YesNo)
            If dialog = DialogResult.No Then

                Beep()
                MsgBox("Cancel!!")



            Else
                SecurityQuestion.ListView1.SelectedItems.Clear()

                Beep()

                Me.Close()


            End If


        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub

    Private Sub txtSecurityQuestion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSecurityQuestion.KeyDown
        If txtSecurityQuestion.Text <> "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = False
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        ElseIf txtSecurityQuestion.Text = "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        End If

    End Sub

    Private Sub txtSecurityQuestion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSecurityQuestion.KeyPress
        If e.KeyChar = " " AndAlso txtSecurityQuestion.Text.EndsWith(" ") Then
            e.KeyChar = Chr(0)
            e.Handled = True
            Exit Sub
        End If
        Select Case e.KeyChar
            Case Convert.ToChar(Keys.Enter)

            Case Convert.ToChar(Keys.Back)
                e.Handled = False

            Case Convert.ToChar(Keys.Capital Or Keys.RButton)
                e.Handled = Not Clipboard.GetText().All(Function(c) validchars4.Contains(c))
            Case Else
                e.Handled = Not validchars4.Contains(e.KeyChar)
        End Select
    End Sub

    Private Sub txtSecurityQuestion_LostFocus(sender As Object, e As EventArgs) Handles txtSecurityQuestion.LostFocus
        txtSecurityQuestion.Text = StrConv(txtSecurityQuestion.Text, vbProperCase)
    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub

    Private Sub txtSecurityQuestion_TextChanged(sender As Object, e As EventArgs) Handles txtSecurityQuestion.TextChanged

    End Sub
End Class