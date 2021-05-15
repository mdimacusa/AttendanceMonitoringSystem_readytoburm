Imports System.Data.SqlClient

Public Class ForgotPassword
    Public Quest As String
    Sub clear()
        txtUser.Text = ""
        txtDbAnswer.Text = ""
        txtAns.Text = ""
        txtPass.Text = ""
        txtQues.Text = ""
        txtCpass.Text = ""
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            Dim dialog As DialogResult
            dialog = MessageBox.Show("Do you want to cancel this?", "", MessageBoxButtons.YesNo)
            If dialog = DialogResult.No Then
                Beep()

            Else
                Beep()
                clear()
                Me.Close()
                ConfirmUsername.Close()
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
     
    End Sub

    Private Sub ForgotPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadSecurityQuestion()
        Button1.Visible = True
        Button2.Visible = False
        cbQuestion.SelectedIndex = -1
        txtPass.Enabled = False
        txtCpass.Enabled = False
        cbQuestion.Enabled = False
        If cbQuestion.Text = "" Then
            txtQues.Text = Quest
        End If
        txtAns.Focus()
    End Sub
    Sub loadSecurityQuestion()
        Try
            con.Close()
            con.Open()
            Dim Cmd As New SqlClient.SqlCommand("SELECT SecurityQuestion FROM tblSecurityQuestion", con)
            Cmd.ExecuteNonQuery()
            Dim Datatable As New DataTable
            Dim DataAdapter As New SqlClient.SqlDataAdapter(Cmd)
            DataAdapter.Fill(Datatable)
            cbQuestion.DataSource = Datatable
            cbQuestion.ValueMember = "SecurityQuestion"
            cbQuestion.DisplayMember = "SecurityQuestion"
        Catch ex As Exception
            msgerror(Err.Description)
            con.Close()
        End Try


    End Sub
    Private Function Upd()
        Try
            con.Close()
            con.Open()
            connect()
            cmd.Connection = con
            cmd.CommandText = "Update tblAdmin SET Password = @Pass, Question = @Ques, Answer = @Ans" & _
            " WHERE Username = '" & txtUser.Text & "'"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Pass", txtPass.Text)
            cmd.Parameters.AddWithValue("@Ques", txtQues.Text)
            cmd.Parameters.AddWithValue("@Ans", txtAns.Text)
            Dim a As Integer = cmd.ExecuteNonQuery()
            If a > 0 Then
                msginfo("Reset Info Complete, Login with your new password")
                clear()
                Me.Dispose()
                ConfirmUsername.Close()
            Else
                msgerror("Failed to Reset password")
            End If
            con.Close()
        Catch ex As Exception
            msgerror(Err.Description)
        End Try

        Return Nothing
    End Function


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtAns.Text = "" Then
            msgerror("Invalid, Answer is empty") 
            txtAns.Focus()
        ElseIf txtAns.Text <> txtDbAnswer.Text Then
            msgerror("Incorrect Answer")
            txtAns.Clear()
            txtAns.Focus()
        ElseIf (txtAns.Text.EndsWith(" ")) Then
            msgerror("Invalid format Answer " + txtAns.Text + "''Space''")
        Else
            msginfo("Now you can change your Security Question and Password")
            cbQuestion.Enabled = True
            txtPass.Enabled = True
            txtCpass.Enabled = True
            Button1.Visible = False
            Button2.Visible = True

        End If
    End Sub

    Private Sub txtAns_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAns.KeyDown
        If txtAns.Text <> "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = False
            End If
        ElseIf txtAns.Text = "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = True
            End If
        End If
    End Sub

    Private Sub txtAns_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAns.KeyPress
        If e.KeyChar = " " AndAlso txtAns.Text.EndsWith("") Then
            e.KeyChar = Chr(0)
            e.Handled = True
            Exit Sub
        End If
        If txtAns.Text.Length >= 0 Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
            Exit Sub
        End If
    End Sub
    Private Sub txtPass_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPass.KeyDown
        If txtPass.Text <> "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = False
            End If
        ElseIf txtPass.Text = "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = True
            End If
        End If
    End Sub
    Private Sub txtPass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPass.KeyPress
        If e.KeyChar = " " AndAlso txtPass.Text.EndsWith("") Then
            e.KeyChar = Chr(0)
            e.Handled = True
            Exit Sub
        End If
        If txtPass.Text.Length >= 0 Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
            Exit Sub
        End If
    End Sub

    Private Sub txtPass_TextChanged(sender As Object, e As EventArgs) Handles txtPass.TextChanged

    End Sub

    Private Sub txtCpass_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCpass.KeyDown
        If txtCpass.Text <> "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = False
            End If
        ElseIf txtCpass.Text = "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = True
            End If
        End If
    End Sub

    Private Sub txtCpass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCpass.KeyPress
        If e.KeyChar = " " AndAlso txtPass.Text.EndsWith("") Then
            e.KeyChar = Chr(0)
            e.Handled = True
            Exit Sub
        End If
        If txtPass.Text.Length >= 0 Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
            Exit Sub
        End If
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtUser.Text = "" Or txtQues.Text = "" Or txtAns.Text = "" Or txtCpass.Text = "" Or txtDbAnswer.Text = "" Then
            msgerror("Complete all details")
        ElseIf txtAns.Text = "" Then
            msgerror("No answer")
            txtAns.Focus()
            'ElseIf txtAns.Text <> txtDbAnswer.Text Then
            '    msgerror("Incorrect Answer")
            '    txtAns.Clear()
            '    txtAns.Focus()
        ElseIf txtPass.Text = "" Then
            msgerror("New Password is empty")
            txtPass.Focus()
        ElseIf (txtAns.Text.EndsWith(" ")) Then
            msgerror("Invalid format Answer " + txtAns.Text + "''Space''")
        ElseIf (txtPass.Text.EndsWith(" ")) Then
            msgerror("Invalid format Password " + txtPass.Text + "''Space''")
        ElseIf (txtCpass.Text.EndsWith(" ")) Then
            msgerror("Invalid format Confirm Password " + txtCpass.Text + "''Space''")
            'ElseIf txtPass.TextLength < 8 Then
            '    msgerror("Invalid New Password, New password must be 8 to 15 characters")
            '    txtPass.Focus()
        ElseIf txtCpass.Text <> txtPass.Text Then
            msgerror("Confirm Password and New Password doesn't match")
        Else
            Upd()

        End If
    End Sub

    Private Sub cbQuestion_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbQuestion.SelectedIndexChanged
        If cbQuestion.Text <> "" Then
            txtQues.Text = cbQuestion.Text
            txtAns.Text = ""
        End If
    End Sub
End Class