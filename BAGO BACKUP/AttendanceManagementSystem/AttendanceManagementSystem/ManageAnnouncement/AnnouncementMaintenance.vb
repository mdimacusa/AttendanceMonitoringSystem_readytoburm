Imports System.Data.SqlClient
Public Class AnnouncementMaintenance
    ' Public Dates As String

    Private Sub AnnouncementMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim dialog As DialogResult
            dialog = MessageBox.Show("Do you want to Close this?", "", MessageBoxButtons.YesNo)
            If dialog = DialogResult.No Then
                Beep()
                MsgBox("Cancel!!")
            Else
                ManageAnnouncement.ListView1.SelectedItems.Clear()
                Beep()
                Me.Close()
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click
        If txtAnnouncementMsg.Text = "" Then
            msgerror("Invalid, Announcement is empty")
            ' ElseIf txtID.Text = "" Then
        ElseIf (txtTitle.Text.EndsWith(" ")) Then
            msgerror("Invalid format Title " + txtTitle.Text + "''Space''")
        ElseIf (txtAnnouncementMsg.Text.EndsWith(" ")) Then
            msgerror("Invalid format Announcement " + txtAnnouncementMsg.Text + "''Space''")
        ElseIf txtAnnouncementMsg.TextLength < 10 Then
            msgerror("Invalid, Announcement must be 10 to 155 characters")
        ElseIf txtID.Text = "" Then
            InsertAnnouncement()
        ElseIf txtID.Text <> "" Then
            UpdateAnnouncement()
        End If
    End Sub
    Private Function InsertAnnouncement()
        Try
            con.Close()
            con.Open()
            connect()
            Dim cmd As New SqlCommand("Select * from tblAnnouncement where Title = @TIT and ID <> '" & txtID.Text & "'", con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@TIT", txtTitle.Text)
            cmd.ExecuteNonQuery()
            dt = New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dt, "a")
            If dt.Tables("a").Rows.Count <> 0 Then
                msgerror("Title is Already Exist")
            Else
                If MsgBox("Are you sure you want to add this data?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    connect()
                    cmd.CommandText = " Insert INTO tblAnnouncement(Title,AnnouncementMsg,NoAnnouncement) VALUES (@TIT,@AMSG,@NA)"
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@TIT", txtTitle.Text)
                    cmd.Parameters.AddWithValue("@AMSG", txtAnnouncementMsg.Text)
                    cmd.Parameters.AddWithValue("@NA", txtNoAnnouncement.Text)
                    Dim a As Integer = cmd.ExecuteNonQuery()
                    If a > 0 Then
                        msginfo("Successfully Added")
                        ManageAnnouncement.list()
                        txtAnnouncementMsg.Text = ""
                        txtTitle.Text = ""
                        txtID.Text = ""
                        '  Dates = ""
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
        Return Nothing
    End Function
    Private Function UpdateAnnouncement()
        Try
            con.Close()
            con.Open()
            connect()
            Dim cmd As New SqlCommand("Select * from tblAnnouncement where Title = @ANN and ID <> '" & txtID.Text & "'", con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@ANN", txtTitle.Text)
            cmd.ExecuteNonQuery()
            dt = New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dt, "a")
            If dt.Tables("a").Rows.Count <> 0 Then
                msgerror("Title is Already Exist")
            Else
                Try
                    con.Close()
                    con.Open()
                    connect()
                    With cmd
                        .Connection = con
                        .CommandText = "Update tblAnnouncement SET Title = @TIT, AnnouncementMsg = @AMSG where Id = '" & txtID.Text & "'"
                        .Parameters.Clear()
                        .Parameters.AddWithValue("@TIT", txtTitle.Text)
                        .Parameters.AddWithValue("@AMSG", txtAnnouncementMsg.Text)
                    End With
                    Dim a As Integer = cmd.ExecuteNonQuery()
                    If a > 0 Then
                        MsgBox("Updated Successfully.")
                        ManageAnnouncement.list()
                        txtAnnouncementMsg.Text = ""
                        txtTitle.Text = ""
                        txtID.Text = ""
                        ' Dates = ""
                        Me.Close()
                        ManageAnnouncement.ListView1.SelectedItems.Clear()
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

    Private Sub txtAnnouncement_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAnnouncementMsg.KeyDown
        If txtAnnouncementMsg.Text <> "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = False
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        ElseIf txtAnnouncementMsg.Text = "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        End If
        If (e.Control AndAlso e.KeyCode = Keys.S) Then
            btnSAVE.PerformClick()
        End If
    End Sub

    Private Sub txtAnnouncement_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAnnouncementMsg.KeyPress
        If e.KeyChar = " " AndAlso txtAnnouncementMsg.Text.EndsWith(" ") Then
            e.KeyChar = Chr(0)
            e.Handled = True
            Exit Sub
        End If
        Select Case e.KeyChar
            Case Convert.ToChar(Keys.Enter)

            Case Convert.ToChar(Keys.Back)
                e.Handled = False

            Case Convert.ToChar(Keys.Capital Or Keys.RButton)
                e.Handled = Not Clipboard.GetText().All(Function(c) validchars6.Contains(c))
            Case Else
                e.Handled = Not validchars6.Contains(e.KeyChar)
        End Select
    End Sub

    Private Sub txtAnnouncement_LostFocus(sender As Object, e As EventArgs) Handles txtAnnouncementMsg.LostFocus
        txtAnnouncementMsg.Text = StrConv(txtAnnouncementMsg.Text, vbProperCase)
    End Sub


    Private Sub txtTitle_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTitle.KeyDown
        If txtTitle.Text <> "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = False
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        ElseIf txtTitle.Text = "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        End If
        If (e.Control AndAlso e.KeyCode = Keys.S) Then
            btnSAVE.PerformClick()
        End If
    End Sub

    Private Sub txtTitle_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTitle.KeyPress
        If e.KeyChar = " " AndAlso txtTitle.Text.EndsWith(" ") Then
            e.KeyChar = Chr(0)
            e.Handled = True
            Exit Sub
        End If
        Select Case e.KeyChar
            Case Convert.ToChar(Keys.Enter)

            Case Convert.ToChar(Keys.Back)
                e.Handled = False

            Case Convert.ToChar(Keys.Capital Or Keys.RButton)
                e.Handled = Not Clipboard.GetText().All(Function(c) validchars6.Contains(c))
            Case Else
                e.Handled = Not validchars6.Contains(e.KeyChar)
        End Select
    End Sub

    Private Sub txtTitle_TextChanged(sender As Object, e As EventArgs) Handles txtTitle.TextChanged

    End Sub
End Class