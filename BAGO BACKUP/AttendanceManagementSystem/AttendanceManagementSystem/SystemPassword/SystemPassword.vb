Imports System.Data.SqlClient
Public Class SystemPassword

    Private Sub SystemPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Function login()
        Try


            connect()
            Dim adp As New SqlDataAdapter
            Dim dt As New DataTable
            Dim query As String = "SELECT * FROM tblSystemPassword WHERE SystemPassword =@SysPassword"

            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.Clear()

            cmd.Parameters.AddWithValue("@SysPassword", txtPassword.Text)
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

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            If login() = True Then

                Dim cmd As New SqlCommand("SELECT * from tblSystemPassword where SystemPassword = '" & txtPassword.Text & "' ", con)

                Dim adpt As New SqlDataAdapter(cmd)
                Dim dt1 As New DataTable

                adpt.Fill(dt1)
               
                AuditTrail("System Password", "Access", "#####-############-#####")
                msginfo("Welcome " + MainForm.txtUserlevel.Text)
                txtPassword.Text = ""
                Main.Show()



            Else
                msgerror("Invalid to login")

                txtPassword.Text = ""



            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Beep()
            txtPassword.Text = ""
            Me.Close()
            MainForm.Show()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtPassword.Text = ""
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown

        If txtPassword.Text <> "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = False
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        ElseIf txtPassword.Text = "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        End If
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = " " AndAlso txtPassword.Text.EndsWith("") Then
            e.KeyChar = Chr(0)
            e.Handled = True
            Exit Sub
        End If
        If txtPassword.Text.Length >= 0 Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
            Exit Sub
        End If
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        AcceptButton = btnLogin
    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint
        txtPassword.Focus()
    End Sub
End Class