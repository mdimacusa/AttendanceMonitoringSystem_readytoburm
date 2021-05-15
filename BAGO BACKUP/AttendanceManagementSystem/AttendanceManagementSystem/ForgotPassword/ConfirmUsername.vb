Imports System.Data.SqlClient
Public Class ConfirmUsername
    Sub ConfirmUsername()
        Try
            con.Close()
            con.Open()
            connect()
            Dim com As New SqlCommand
            com.Connection = con
            com.CommandText = "Select * from tblAdmin where Username = @user"
            com.Parameters.Clear()
            com.Parameters.AddWithValue("@user", txtUser.Text)
            Dim adpt As New SqlDataAdapter(com)
            Dim dt As New DataTable
            adpt.Fill(dt)
            ForgotPassword.Quest = dt.Rows(0)(10).ToString()
            ForgotPassword.txtDbAnswer.Text = dt.Rows(0)(11).ToString()
            ' txtUser.ReadOnly = True
            ForgotPassword.txtUser.Text = txtUser.Text
            ForgotPassword.txtAns.Focus()
            msginfo("Your answer must be the same way you input your answer upon registration")
            ForgotPassword.ShowDialog()         
            ForgotPassword.txtAns.Focus()
            con.Close()
        Catch ex As Exception
            msgerror(txtUser.Text + " is not registered in database")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtUser.Text = "" Then
            msgerror("Please insert your username")
        Else
            ConfirmUsername()
        End If
    End Sub

    Private Sub txtUser_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUser.KeyDown
        If txtUser.Text <> "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = False
            End If
        ElseIf txtUser.Text = "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = True
            End If
        End If
    End Sub
    Private Sub txtUser_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUser.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) = False And e.KeyChar <> ChrW(8) Then
            e.Handled = True
            Exit Sub
        End If
        If txtUser.Text.Length >= 0 Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
            Exit Sub
        End If
    End Sub
    Private Sub txtUser_TextChanged(sender As Object, e As EventArgs) Handles txtUser.TextChanged
        AcceptButton = Button1
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        txtUser.Text = ""
        Me.Close()
    End Sub

    Private Sub ConfirmUsername_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUser.Text = ""
    End Sub
End Class