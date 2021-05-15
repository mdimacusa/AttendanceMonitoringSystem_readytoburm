Imports System.Data.SqlClient
Public Class YearLevel

    Private Sub btnADD_Click(sender As Object, e As EventArgs) Handles btnADD.Click
        Try
            YearLevelMaintenance.txtID.Clear()
            YearLevelMaintenance.txtYearLevel.Clear()
            YearLevelMaintenance.ShowDialog()
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub

    Private Sub tbnEDIT_Click(sender As Object, e As EventArgs) Handles tbnEDIT.Click
        Try
            If ListView1.SelectedItems.Count <> 0 Then
                YearLevelMaintenance.txtID.Text = ListView1.SelectedItems(0).Text
                YearLevelMaintenance.txtYearLevel.Text = ListView1.SelectedItems(0).SubItems(1).Text
                YearLevelMaintenance.txtSubYearlevel.Text = ListView1.SelectedItems(0).SubItems(1).Text
                YearLevelMaintenance.Department = ListView1.SelectedItems(0).SubItems(2).Text
                YearLevelMaintenance.ShowDialog()

            ElseIf Me.ListView1.SelectedItems.Count < 1 Then
                msgerror("Please select item to update")
                ListView1.Enabled = True
                Exit Sub
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub

    Private Sub YearLevel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            list()
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub
    Sub list()
        Try
            con.Close()
            con.Open()
            ListView1.Items.Clear()
            cmd.Connection = con
            cmd.CommandText = "SELECT * FROM tblYearLevel"
            Dim dataread3 As SqlDataReader = cmd.ExecuteReader

            Dim DelID As Integer
            Dim DeliveryID As String
            Dim Depart As String


            While dataread3.Read()
                DelID = dataread3.GetValue(0)
                DeliveryID = dataread3.GetValue(1)
                Depart = dataread3.GetValue(2)

                Dim arr(15) As String
                Dim itm As ListViewItem

                arr(0) = "" & DelID & ""
                arr(1) = "" & DeliveryID & ""
                arr(2) = "" & Depart & ""


                itm = New ListViewItem(arr)
                ListView1.Items.Add(itm)

            End While
            con.Close()
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub

    Private Sub tbnDELETE_Click(sender As Object, e As EventArgs) Handles tbnDELETE.Click
        Try
            If ListView1.SelectedItems.Count <> 0 Then
                txtID.Text = ListView1.SelectedItems(0).Text
            ElseIf txtID.Text = "" Then
                msgerror("Please Select Item to Remove")
                Exit Sub
            End If
            If checkYearlevelSML() = True Then
                msgerror("Cannot removed this data, Yearlevel exists in student master list")
                txtYearlevel.Text = ""
                ListView1.SelectedItems.Clear()
            ElseIf checkYearlevelATT() = True Then
                msgerror("Cannot removed this data, Yearlevel exists in Attendance Record")
                txtYearlevel.Text = ""
                ListView1.SelectedItems.Clear()
            ElseIf checkYearlevelER() = True Then
                msgerror("Cannot removed this data, Yearlevel exists in Event Attendance Record")
                txtYearlevel.Text = ""
                ListView1.SelectedItems.Clear()
            ElseIf Me.ListView1.SelectedItems.Count < 1 Then
                msgerror("Please Select Item to Remove")
            Else
                DeleteYearlevel()
                Exit Sub
            End If
            If ListView1.SelectedItems.Count <> 0 Then
                CourseMaintenance.txtID.Text = ListView1.SelectedItems(0).Text
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub
    Public Sub DeleteYearlevel()
        Try
            If ListView1.SelectedItems.Count <> 0 Then
                YearLevelMaintenance.txtID.Text = ListView1.SelectedItems(0).Text

                con.Close()
                con.Open()
                Dim ID As String
                ID = ListView1.SelectedItems(0).SubItems(0).Text
                If MsgBox("Are you sure to delete this data?", vbYesNo) = MsgBoxResult.Yes Then
                    cmd.Connection = con
                    cmd.CommandText = "DELETE tblYearLevel WHERE ID='" & ID & "'"
                    Dim i As Integer = cmd.ExecuteNonQuery()
                    AuditTrail("Yearlevel Maintenace ", "Delete", "Yearlevel: " + ListView1.SelectedItems(0).SubItems(1).Text + "|Department: " + ListView1.SelectedItems(0).SubItems(2).Text)
                    If i > 0 Then
                        txtYearlevel.Text = ""
                        MsgBox("YearLevel Removed.")
                        txtID.Text = ""
                        list()
                    End If
                ElseIf MsgBoxResult.No Then
                    txtID.Text = ""
                    YearLevelMaintenance.txtID.Clear()
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
    Public Function checkYearlevelSML()
        Try
            con.Close()
            con.Open()
            connect()
            Dim adp As New SqlDataAdapter
            Dim dt As New DataTable
            Dim query As String = "SELECT * FROM tblStudentMasterList WHERE Yearlevel = @YR"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@YR", txtYearlevel.Text)
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
    Public Function checkYearlevelATT()
        Try
            con.Close()
            con.Open()
            connect()
            Dim adp As New SqlDataAdapter
            Dim dt As New DataTable
            Dim query As String = "SELECT * FROM tblAttendance WHERE YearLevel = @YR"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@YR", txtYearlevel.Text)
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
    Public Function checkYearlevelER()
        Try
            con.Close()
            con.Open()
            connect()
            Dim adp As New SqlDataAdapter
            Dim dt As New DataTable
            Dim query As String = "SELECT * FROM tblEventRecord WHERE YearLevel = @YR"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@YR", txtYearlevel.Text)
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try

            Beep()
                Me.Close()
                MainForm.Show()

        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub

 
    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        Try
            txtID.Text = ListView1.SelectedItems(0).Text         
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count <> 0 Then
            txtYearlevel.Text = ListView1.SelectedItems(0).SubItems(1).Text
        End If
    End Sub
End Class