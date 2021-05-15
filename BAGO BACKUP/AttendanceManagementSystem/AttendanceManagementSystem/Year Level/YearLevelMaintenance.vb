Imports System.Data.SqlClient
Public Class YearLevelMaintenance
    Public Department As String
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim dialog As DialogResult
            dialog = MessageBox.Show("Do you want to Close this?", "", MessageBoxButtons.YesNo)
            If dialog = DialogResult.No Then
                Beep()
                MsgBox("Cancel!!")
            Else
                txtID.Text = ""
                YearLevel.txtID.Text = ""
                If YearLevel.ListView1.SelectedItems.Count <> 0 Then
                    YearLevel.ListView1.SelectedItems.Clear()
                    YearLevel.list()
                End If
                Beep()
                Me.Close()
                YearLevel.Show()
                '  YearLevel.txtID.Text = ""
            End If

        Catch ex As Exception
            msgerror(Err.Description)
        End Try

    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click
        If txtYearLevel.Text = "" Then
            msgerror("Invalid, Yearlevel is empty")
        ElseIf (txtYearLevel.Text.EndsWith(" ")) Then
            msgerror("Invalid format Year level " + txtYearLevel.Text + "''Space''")
        ElseIf txtYearLevel.TextLength < 5 Then
            msgerror("Invalid, Yearlevel must be 5 to 50 characters")
        ElseIf txtID.Text = "" Then
            InsertYearLevel()
        ElseIf txtID.Text <> "" Then
            UpdateYearLevel()
        End If
    End Sub
    Private Function InsertYearLevel()
        Try
            con.Close()
            con.Open()

            connect()

            Dim cmd As New SqlCommand("Select * from tblYearLevel where Yearlevel = @YL and Department = @DM ", con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@DM", cbDepartment.Text)
            cmd.Parameters.AddWithValue("@YL", txtYearLevel.Text)
            cmd.ExecuteNonQuery()
            dt = New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dt, "a")
            If dt.Tables("a").Rows.Count <> 0 Then
                msgerror("Department: " + cbDepartment.Text + " Yearlevel: " + txtYearLevel.Text + " is Already Exist")


            Else
                If MsgBox("Are you sure you want to add this data?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    connect()
                    cmd.CommandText = " Insert INTO tblYearLevel(Yearlevel,Department) VALUES (@YL,@DM)"
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@YL", txtYearLevel.Text)
                    cmd.Parameters.AddWithValue("@DM", cbDepartment.Text)
                    cmd.ExecuteNonQuery()
                    AuditTrail("Yearlevel Maintenace ", "Add", "Yearlevel: " + txtYearLevel.Text + "|Department: " + cbDepartment.Text)
                    msginfo("Successfully Added")
                    YearLevel.list()
                    cbDepartment.SelectedIndex = -1
                    txtYearLevel.Text = ""
                    txtID.Text = ""
                End If
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
        Return Nothing
    End Function
    Private Function UpdateYearLevel()
        Try

            con.Close()
            con.Open()

            connect()

            Dim cmd As New SqlCommand("Select * from tblYearLevel where Yearlevel = @YL and ID <> '" & txtID.Text & "'", con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@YL", txtYearLevel.Text)
            cmd.ExecuteNonQuery()
            dt = New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dt, "a")
            If dt.Tables("a").Rows.Count <> 0 Then
                msgerror(txtYearLevel.Text + " is Already Exist")


            Else

                Try
                    If MsgBox("Are you sure you want to update this data?", MsgBoxStyle.YesNo) = vbYes Then
                        con.Close()
                        con.Open()
                        connect()
                        With cmd
                            .Connection = con
                            .CommandText = "Update tblYearLevel SET  Yearlevel = @YL where Id = '" & txtID.Text & "'"
                            .Parameters.Clear()
                            .Parameters.AddWithValue("@YL", txtYearLevel.Text)



                        End With
                        AuditTrail("Yearlevel Maintenace ", "Update", "Yearlevel: " + txtYearLevel.Text + "|Department: " + cbDepartment.Text)

                        Dim a As Integer = cmd.ExecuteNonQuery()

                        If a > 0 Then
                            UpdateYearlevelSAR()
                            UpdateYearlevelSML()
                            UpdateYearlevelER()
                            UpdateYearlevelAR()
                            MsgBox("Updated Successfully.")
                            YearLevel.list()
                            cbDepartment.SelectedIndex = -1
                            txtYearLevel.Text = ""
                            txtID.Text = ""
                            Me.Close()
                            YearLevel.ListView1.SelectedItems.Clear()
                        Else
                            MsgBox("Failed to Update.")

                        End If
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
    Private Function UpdateYearlevelSAR()
        Try


            con.Close()
            con.Open()
            connect()
            With cmd
                .Connection = con
                .CommandText = "Update tblSmsAnnouncementRecord SET  Yearlevel = @YL where Yearlevel = '" & txtSubYearlevel.Text & "'"
                .Parameters.Clear()
                .Parameters.AddWithValue("@YL", txtYearLevel.Text)
            End With


            Dim a As Integer = cmd.ExecuteNonQuery()
            If a > 0 Then
                SmsAnnouncementRecord.list()
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
        Return Nothing
    End Function
    Private Function UpdateYearlevelSML()
        Try


            con.Close()
            con.Open()
            connect()
            With cmd
                .Connection = con
                .CommandText = "Update tblStudentMasterList SET  Yearlevel = @YL where Yearlevel = '" & txtSubYearlevel.Text & "'"
                .Parameters.Clear()
                .Parameters.AddWithValue("@YL", txtYearLevel.Text)
            End With


            Dim a As Integer = cmd.ExecuteNonQuery()
            If a > 0 Then
                StudentMasterList.list()
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
        Return Nothing
    End Function
    Private Function UpdateYearlevelER()
        Try


            con.Close()
            con.Open()
            connect()
            With cmd
                .Connection = con
                .CommandText = "Update tblEventRecord SET  Yearlevel = @YL where Yearlevel = '" & txtSubYearlevel.Text & "'"
                .Parameters.Clear()
                .Parameters.AddWithValue("@YL", txtYearLevel.Text)
            End With


            Dim a As Integer = cmd.ExecuteNonQuery()
            If a > 0 Then
                EventRecord.list()
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
        Return Nothing
    End Function
    Private Function UpdateYearlevelAR()
        Try


            con.Close()
            con.Open()
            connect()
            With cmd
                .Connection = con
                .CommandText = "Update tblAttendance SET  Yearlevel = @YL where Yearlevel = '" & txtSubYearlevel.Text & "'"
                .Parameters.Clear()
                .Parameters.AddWithValue("@YL", txtYearLevel.Text)
            End With


            Dim a As Integer = cmd.ExecuteNonQuery()
            If a > 0 Then
                AttendanceRecord.list()
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
        Return Nothing
    End Function

    Private Sub txtYearLevel_KeyDown(sender As Object, e As KeyEventArgs) Handles txtYearLevel.KeyDown
        If txtYearLevel.Text <> "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = False
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        ElseIf txtYearLevel.Text = "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        End If
    End Sub

    Private Sub txtYearLevel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtYearLevel.KeyPress
        If e.KeyChar = " " AndAlso txtYearLevel.Text.EndsWith(" ") Then
            e.KeyChar = Chr(0)
            e.Handled = True
            Exit Sub
        End If
        Select Case e.KeyChar
            Case Convert.ToChar(Keys.Enter)

            Case Convert.ToChar(Keys.Back)
                e.Handled = False

            Case Convert.ToChar(Keys.Capital Or Keys.RButton)
                e.Handled = Not Clipboard.GetText().All(Function(c) validchars2.Contains(c))
            Case Else
                e.Handled = Not validchars2.Contains(e.KeyChar)
        End Select

    End Sub

    Private Sub txtYearLevel_LostFocus(sender As Object, e As EventArgs) Handles txtYearLevel.LostFocus
        txtYearLevel.Text = StrConv(txtYearLevel.Text, vbProperCase)
    End Sub
    Public Sub loadDepartment()
        Try
            con.Close()
            con.Open()
            Dim Cmd As New SqlClient.SqlCommand("SELECT Department FROM tblDepartment", con)
            Cmd.ExecuteNonQuery()
            dt = New DataSet
            adp = New SqlDataAdapter(Cmd)
            adp.Fill(dt)

            For Each dr As DataRow In dt.Tables(0).Rows
                cbDepartment.Items.Add(dr("Department"))
            Next
        Catch ex As Exception
            msgerror(Err.Description)
            con.Close()
        End Try
    End Sub
    Private Sub YearLevelMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      loadDepartment()
        cbDepartment.SelectedIndex = -1
        If txtID.Text <> "" Then
            cbDepartment.Text = Department
        End If

    End Sub

    Private Sub cbDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDepartment.SelectedIndexChanged

    End Sub
End Class