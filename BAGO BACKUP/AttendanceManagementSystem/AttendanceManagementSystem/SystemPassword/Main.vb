Public Class Main

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            Dim dialog As DialogResult
            dialog = MessageBox.Show("Are you sure, you want to open UserAccount?", "", MessageBoxButtons.YesNo)
            If dialog = DialogResult.No Then
                Beep()
                MsgBox("Cancel!")
            Else
                UserAccount.ShowDialog()
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim dialog As DialogResult
            dialog = MessageBox.Show("Are you sure, you want to open SystemPasswordList?", "", MessageBoxButtons.YesNo)
            If dialog = DialogResult.No Then
                Beep()
                MsgBox("Cancel!")
            Else
                SystemPasswordList.ShowDialog()
            End If
        Catch ex As Exception
            msgerror(Err.Description)
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
                SystemPassword.Show()
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub
End Class