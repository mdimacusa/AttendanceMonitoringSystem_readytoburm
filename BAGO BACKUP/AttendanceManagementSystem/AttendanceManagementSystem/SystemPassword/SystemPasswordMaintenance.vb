Imports System.Data.SqlClient
Public Class SystemPasswordMaintenance
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim dialog As DialogResult
            dialog = MessageBox.Show("Do you want to Close this?", "", MessageBoxButtons.YesNo)
            If dialog = DialogResult.No Then
                Beep()
                MsgBox("Cancel!!")
            Else
                SystemPasswordList.ListView1.SelectedItems.Clear()
                Beep()
                Me.Close()
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub

    Private Function InsertSystemPassword()
        Try
            con.Close()
            con.Open()
            connect()
            Dim cmd As New SqlCommand("Select * from tblSystemPassword where SystemPassword = @SP and ID <> '" & txtID.Text & "'", con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@SP", txtSystemPassword.Text)
            cmd.ExecuteNonQuery()
            dt = New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dt, "a")
            If dt.Tables("a").Rows.Count <> 0 Then
                msgerror("System Password is Already Exist")
            Else
                If MsgBox("Are you sure you want to add this data?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    connect()
                    cmd.CommandText = " Insert INTO tblSystemPassword(SystemPassword) VALUES (@SP)"
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@SP", txtSystemPassword.Text)
                    Dim a As Integer = cmd.ExecuteNonQuery()
                    If a > 0 Then
                        msginfo("Successfully Added")
                        SystemPasswordList.list()
                        txtSystemPassword.Text = ""
                        txtID.Text = ""
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
        Return Nothing
    End Function
    Private Function UpdateSystemPassword()
        Try

            con.Close()
            con.Open()

            connect()

            Dim cmd As New SqlCommand("Select * from tblSystemPassword where SystemPassword = @SP and ID <> '" & txtID.Text & "'", con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@SP", txtSystemPassword.Text)
            cmd.ExecuteNonQuery()
            dt = New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dt, "a")
            If dt.Tables("a").Rows.Count <> 0 Then
                msgerror("System Password is Already Exists")


            Else

                Try
                    con.Close()
                    con.Open()
                    connect()
                    With cmd
                        .Connection = con
                        .CommandText = "Update tblSystemPassword SET  SystemPassword = @SP where Id = '" & txtID.Text & "'"
                        .Parameters.Clear()
                        .Parameters.AddWithValue("@SP", txtSystemPassword.Text)



                    End With


                    Dim a As Integer = cmd.ExecuteNonQuery()

                    If a > 0 Then

                        MsgBox("Updated Successfully.")
                        SystemPasswordList.list()
                        txtSystemPassword.Text = ""
                        txtID.Text = ""
                        Me.Close()
                        SystemPasswordList.ListView1.SelectedItems.Clear()
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

    Private Sub txtSystemPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSystemPassword.KeyDown
        If txtSystemPassword.Text <> "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = False
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        ElseIf txtSystemPassword.Text = "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        End If
    End Sub

    Private Sub txtSystemPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSystemPassword.KeyPress
        If e.KeyChar = " " AndAlso txtSystemPassword.Text.EndsWith("") Then
            e.KeyChar = Chr(0)
            e.Handled = True
            Exit Sub
        End If
        If txtSystemPassword.Text.Length >= 0 Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
            Exit Sub
        End If
    End Sub
    Private Sub btnSAVE_Click_2(sender As Object, e As EventArgs) Handles btnSAVE.Click
        If txtSystemPassword.Text = "" Then
            msgerror("Invalid, System Password is empty")
        ElseIf (txtSystemPassword.Text.EndsWith(" ")) Then
            msgerror("Invalid format 'System Password' " + txtSystemPassword.Text + "''Space''")
        ElseIf txtSystemPassword.TextLength < 6 Then
            msgerror("Invalid, password must be 6 to 20 characters")    
        ElseIf txtID.Text = "" Then
            InsertSystemPassword()
        ElseIf txtID.Text <> "" Then
            UpdateSystemPassword()
        End If
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class