Imports System.Data.SqlClient
Public Class Login
    Private iprogressbarvalue As Integer = 0
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
   
  
    Public Function login()
        Try

   
        connect()
        Dim adp As New SqlDataAdapter
        Dim dt As New DataTable
        Dim query As String = "SELECT * FROM tblAdmin WHERE Username =@username and Password =@password"

        Dim cmd As New SqlCommand(query, con)
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@username", txtUsername.Text)
        cmd.Parameters.AddWithValue("@password", txtPassword.Text)
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

                Dim cmd As New SqlCommand("SELECT * from tblAdmin where Username = '" & txtUsername.Text & "' ", con)
                Dim adpt As New SqlDataAdapter(cmd)
                Dim dt1 As New DataTable

                adpt.Fill(dt1)
                MainForm.txtID.Text = dt1.Rows(0)(0).ToString()
                MainForm.txtUserlevel.Text = dt1.Rows(0)(13).ToString()
                MainForm.lblUserID.Text = dt1.Rows(0)(15).ToString()
                msginfo("Welcome " + MainForm.txtUserlevel.Text)
                str_user = dt1.Rows(0)(8).ToString()
                ' MainForm.Label1.Text = txtLogID.Text
                MainForm.txtusername.Text = txtUsername.Text
                MainForm.txtDateIn.Text = Date.Now
                ' txtLogID.Text = ""
                Me.Hide()
                MainForm.Show()
            Else
                msgerror("Invalid Username or Password")
                txtUsername.Text = ""
                txtPassword.Text = ""
                txtUsername.Text = ""


            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
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
  
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        'ProgressBar1.Minimum = 0
        'ProgressBar1.Maximum = 1000
        'ProgressBar1.Value = 0

        'Timer2.Enabled = True
        'Timer2.Interval = 300
        'Timer2.Start()
        Me.Hide()
        Attendance.ShowDialog()
    End Sub

    Private Sub txtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown
        If txtUsername.Text <> "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = False
            End If
        ElseIf txtUsername.Text = "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = True
            End If
        End If
    End Sub

    Private Sub txtUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsername.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) = False And e.KeyChar <> ChrW(8) Then
            e.Handled = True
            Exit Sub
        End If
        If txtUsername.Text.Length >= 0 Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
            Exit Sub
        End If
    End Sub

    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged
        AcceptButton = btnLogin
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

    'Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
    '    ProgressBar1.Minimum = 0
    '    ProgressBar1.Maximum = 1000
    '    ProgressBar1.Value = 0

    '    Timer1.Enabled = True
    '    Timer1.Interval = 300
    '    Timer1.Start()

    'End Sub

    'Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    '    iprogressbarvalue += 1
    '    Select Case iprogressbarvalue
    '        Case 1, 2, 5, 7, 9
    '            ProgressBar1.ForeColor = Color.White
    '            ProgressBar1.Value = (iprogressbarvalue * 100)
    '        Case 2, 4, 6, 8, 10
    '            ProgressBar1.Value = (iprogressbarvalue * 100)
    '        Case 13
    '            Timer1.Stop()
    '            Timer1.Enabled = False
    '            EventAttendance.ShowDialog()
    '            Me.Refresh()
    '    End Select
    'End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Me.Hide()
        EventAttendance.ShowDialog()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        ConfirmUsername.ShowDialog()
    End Sub

    'Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
    '    iprogressbarvalue += 1
    '    Select Case iprogressbarvalue
    '        Case 1, 2, 5, 7, 9
    '            ProgressBar1.ForeColor = Color.White
    '            ProgressBar1.Value = (iprogressbarvalue * 100)
    '        Case 2, 4, 6, 8, 10
    '            ProgressBar1.Value = (iprogressbarvalue * 100)
    '        Case 13
    '            Timer1.Stop()
    '            Timer1.Enabled = False
    '            Attendance.ShowDialog()
    '            ' Me.Close()
    '    End Select
    'End Sub
End Class
