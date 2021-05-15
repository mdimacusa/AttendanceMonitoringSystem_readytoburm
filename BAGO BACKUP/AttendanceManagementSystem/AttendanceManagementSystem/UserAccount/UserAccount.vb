Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions
Public Class UserAccount

    Private Sub UserAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        list()
        CountItem()
        txtID.Text = MainForm.txtID.Text

        SumAdmin()
        SumStaff()
    End Sub
    'Sub SumAdmin()
    '    Dim totalAdmin As Integer = 0
    '    Dim total As ListViewItem
    '    For Each total In ListView1.Items
    '        totalAdmin += CDbl(total.SubItems.Item(13).Text)
    '    Next
    '    txtSumAdmin.Text = totalAdmin
    'End Sub
    Public Sub SumAdmin()

        con.Close()
        con.Open()

        Dim cmd As New SqlCommand("SELECT Sum(SumAdmin) from tblAdmin", con)

        Dim adpt As New SqlDataAdapter(cmd)
        Dim dt4 As New DataTable

        adpt.Fill(dt4)

        txtSumAdmin.Text = dt4.Rows(0)(0).ToString()
        con.Close()

    End Sub
    'Sub SumStaff()
    '    Dim totalStaff As Integer = 0
    '    Dim total As ListViewItem
    '    For Each total In ListView1.Items
    '        totalStaff += CDbl(total.SubItems.Item(14).Text)
    '    Next
    '    txtSumStaff.Text = totalStaff
    'End Sub
    Public Sub SumStaff()

        con.Close()
        con.Open()

        Dim cmd As New SqlCommand("SELECT Sum(SumStaff) from tblAdmin", con)

        Dim adpt As New SqlDataAdapter(cmd)
        Dim dt4 As New DataTable

        adpt.Fill(dt4)

        txtSumStaff.Text = dt4.Rows(0)(0).ToString()
        con.Close()

    End Sub
    Sub list()
        con.Close()
        con.Open()
        ListView1.Items.Clear()
        cmd.Connection = con
        cmd.CommandText = "SELECT id,Lastname,Firstname,MI,Age,Gender,Contact,Address,Username,Question,QiD,UserLevel,UserID,SumAdmin,SumStaff FROM tblAdmin"
        Dim dataread3 As SqlDataReader = cmd.ExecuteReader

        Dim DelID As Integer
        Dim DeliveryID As String
        Dim ProductName As String
        Dim Description As String
        Dim Original As String
        Dim Pieces As String
        Dim TotalPrice As String
        Dim DeliveryID1 As String
        Dim ProductName1 As String
        Dim Description1 As String
        Dim Original1 As String
        Dim Pieces1 As String
        Dim Pieces12 As String
        Dim TotalPrice1 As String
        Dim quesid As String
        'Dim Ulevel As String

        While dataread3.Read()
            DelID = dataread3.GetValue(0)
            DeliveryID = dataread3.GetValue(1)
            ProductName = dataread3.GetValue(2)
            Description = dataread3.GetValue(3)
            Original = dataread3.GetValue(4)
            Pieces = dataread3.GetValue(5)
            TotalPrice = dataread3.GetValue(6)
            DeliveryID1 = dataread3.GetValue(7)
            ProductName1 = dataread3.GetValue(8)
            Description1 = dataread3.GetValue(9)
            Original1 = dataread3.GetValue(10)
            Pieces1 = dataread3.GetValue(11)
            Pieces12 = dataread3.GetValue(12)
            TotalPrice1 = dataread3.GetValue(13)
            quesid = dataread3.GetValue(14)
            'Ulevel = dataread3.GetValue(14)

            Dim arr(15) As String
            Dim itm As ListViewItem

            arr(0) = "" & DelID & ""
            arr(1) = "" & DeliveryID & ""
            arr(2) = "" & ProductName & ""
            arr(3) = "" & Description & ""
            arr(4) = "" & Original & ""
            arr(5) = "" & Pieces & ""
            arr(6) = "" & TotalPrice & ""
            arr(7) = "" & DeliveryID1 & ""
            arr(8) = "" & ProductName1 & ""
            arr(9) = "" & Description1 & ""
            arr(10) = "" & Original1 & ""
            arr(11) = "" & Pieces1 & ""
            arr(12) = "" & Pieces12 & ""
            arr(13) = "" & TotalPrice1 & ""
            arr(14) = "" & quesid & ""
            'arr(14) = "" & Ulevel & ""

            itm = New ListViewItem(arr)
            ListView1.Items.Add(itm)
            CountItem()
        End While
        con.Close()
    End Sub
    Sub CountItem()
        txtCount.Text = ListView1.Items.Count
    End Sub
   
          

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        UserAccountMaintenance.clear()
        UserAccountMaintenance.txtSubUsername.Text = ""
        UserAccountMaintenance.txtSubContact.Text = ""
        UserAccountMaintenance.ShowDialog()

    End Sub
    Sub View()
        UserAccountMaintenance.txtId.Text = ListView1.SelectedItems(0).Text
        If UserAccountMaintenance.txtId.Text <> "" Then
            Dim cmd As New SqlCommand("Select * from tblUser where Id = '" & UserAccountMaintenance.txtId.Text & "'", con)
            Dim table As New DataTable
            Dim adpt As New SqlDataAdapter(cmd)

            adpt.Fill(table)
            Dim img() As Byte
            img = table.Rows(0)(14)
            Dim ms As New MemoryStream(img)
            UserAccountMaintenance.PictureBox2.Image = Image.FromStream(ms)


        ElseIf UserAccountMaintenance.txtId.Text = "" Then
            UserAccountMaintenance.PictureBox2.Image = Nothing
        End If
    End Sub
    Sub retrieveAdmin()
        Try

            If txtID.Text <> "" Then
                con.Close()
                con.Open()
                connect()
                Dim cmd As New SqlCommand("Select * from tblAdmin where id = '" & txtID.Text & "'", con)
                Dim table As New DataTable
                Dim adpt As New SqlDataAdapter(cmd)
                adpt.Fill(table)

                Dim img As Byte()
                img = table.Rows(0)(14)
                Dim ms As New MemoryStream(img)
                'Dim img As Byte() = TryCast(cmd.ExecuteScalar(), Byte())
                '   If ms IsNot Nothing Then
                '  If ms Is System.DBNull.Value Then
                '    UserAccountMaintenance.PictureBox2.Image = Nothing
                'Else
                UserAccountMaintenance.PictureBox2.Image = Image.FromStream(ms)
                UserAccountMaintenance.txtPass.Text = table.Rows(0)(9).ToString()
                UserAccountMaintenance.txtCpass.Text = table.Rows(0)(9).ToString()
                UserAccountMaintenance.txtAns.Text = table.Rows(0)(11).ToString()
                UserAccountMaintenance.txtQuesId.Text = table.Rows(0)(12).ToString()
                UserAccountMaintenance.TextBox1.Text = table.Rows(0)(13).ToString()
                '    End If
            ElseIf txtID.Text = "" Then
            UserAccountMaintenance.PictureBox2.Image = Nothing
            End If
        Catch ex As Exception
            ' msgerror(Err.Description)
            con.Close()
            con.Open()
            connect()
            Dim cmd As New SqlCommand("Select * from tblAdmin where id = '" & txtID.Text & "'", con)
            Dim table As New DataTable
            Dim adpt As New SqlDataAdapter(cmd)
            adpt.Fill(table)
            UserAccountMaintenance.PictureBox2.Image = Nothing
            UserAccountMaintenance.txtPass.Text = table.Rows(0)(9).ToString()
            UserAccountMaintenance.txtCpass.Text = table.Rows(0)(9).ToString()
            UserAccountMaintenance.txtAns.Text = table.Rows(0)(11).ToString()
            UserAccountMaintenance.txtQuesId.Text = table.Rows(0)(12).ToString()
            UserAccountMaintenance.TextBox1.Text = table.Rows(0)(13).ToString()
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Try
            If ListView1.SelectedItems.Count <> 0 Then

                txtID.Text = ListView1.SelectedItems(0).Text
                retrieveAdmin()
                UserAccountMaintenance.txtId.Text = ListView1.SelectedItems(0).Text
                UserAccountMaintenance.txtLname.Text = ListView1.SelectedItems(0).SubItems(1).Text
                UserAccountMaintenance.txtFname.Text = ListView1.SelectedItems(0).SubItems(2).Text
                UserAccountMaintenance.txtMI.Text = ListView1.SelectedItems(0).SubItems(3).Text
                UserAccountMaintenance.txtAge.Text = ListView1.SelectedItems(0).SubItems(4).Text
                UserAccountMaintenance.Gender = ListView1.SelectedItems(0).SubItems(5).Text
                UserAccountMaintenance.txtCont.Text = ListView1.SelectedItems(0).SubItems(6).Text
                UserAccountMaintenance.txtSubContact.Text = ListView1.SelectedItems(0).SubItems(6).Text
                UserAccountMaintenance.txtAdd.Text = ListView1.SelectedItems(0).SubItems(7).Text
                UserAccountMaintenance.txtUser.Text = ListView1.SelectedItems(0).SubItems(8).Text
                UserAccountMaintenance.txtUname2.Text = ListView1.SelectedItems(0).SubItems(8).Text
                UserAccountMaintenance.txtSubUsername.Text = ListView1.SelectedItems(0).SubItems(8).Text
                'txtPass.Text = ListView1.SelectedItems(0).SubItems(9).Text
                UserAccountMaintenance.Question = ListView1.SelectedItems(0).SubItems(9).Text
                ' txtAns.Text = ListView1.SelectedItems(0).SubItems(10).Text
                UserAccountMaintenance.UserLevel = ListView1.SelectedItems(0).SubItems(11).Text
                UserAccountMaintenance.TextBox1.Text = ListView1.SelectedItems(0).SubItems(11).Text
                UserAccountMaintenance.txtQuesId.Text = ListView1.SelectedItems(0).SubItems(10).Text

                UserAccountMaintenance.UserID = ListView1.SelectedItems(0).SubItems(12).Text
                UserAccountMaintenance.ShowDialog()
                View()

            ElseIf Me.ListView1.SelectedItems.Count < 1 Then
                msgerror("Please select item to update")
                ListView1.Enabled = True
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If ListView1.SelectedItems.Count <> 0 Then
                txtSubID.Text = ListView1.SelectedItems(0).Text

            End If
            If Me.ListView1.SelectedItems.Count < 1 Then
                msgerror("Please Select Item to Remove")
                ListView1.SelectedItems.Clear()
            ElseIf txtCount.Text <= 1 Then
                msgerror("Invalid to Remove")
                ListView1.SelectedItems.Clear()
            ElseIf txtID.Text = txtSubID.Text Then
                msgerror("Invalid to Remove this Account")
                txtSubID.Text = ""
                ListView1.SelectedItems.Clear()
            ElseIf txtUserlevel.Text = "Admin" And txtSumAdmin.Text = "1" Then
                msgerror("Invalid to remove")
                txtUserlevel.Text = ""
                ListView1.SelectedItems.Clear()
                'ElseIf txtUserlevel.Text = "Staff" And txtSumStaff.Text = "1" Then
                '    msgerror("Invalid to remove")
                '    txtUserlevel.Text = ""
                '    ListView1.SelectedItems.Clear()

            Else
                If ListView1.SelectedItems.Count <> 0 Then
                    UserAccountMaintenance.txtId.Text = ListView1.SelectedItems(0).Text
                    con.Close()
                    con.Open()
                    If MsgBox("Are you sure to delete this data?", vbYesNo) = MsgBoxResult.Yes Then
                        Dim ID As String
                        ID = ListView1.SelectedItems(0).SubItems(0).Text
                        cmd.Connection = con
                        cmd.CommandText = "DELETE tblAdmin WHERE ID='" & ID & "'"
                        Dim i As Integer = cmd.ExecuteNonQuery()
                        AuditTrail("User Account Maintenace ", "Delete", "User Info: " + ListView1.SelectedItems(0).SubItems(1).Text + "," + ListView1.SelectedItems(0).SubItems(2).Text + "," + ListView1.SelectedItems(0).SubItems(4).Text + "," + ListView1.SelectedItems(0).SubItems(5).Text + "," + ListView1.SelectedItems(0).SubItems(6).Text + "|Username : " + ListView1.SelectedItems(0).SubItems(8).Text)
                        If i > 0 Then
                            MsgBox("User Account Removed.")
                            txtUserlevel.Text = ""
                            SumStaff()
                            list()
                        End If
                    ElseIf MsgBoxResult.No Then
                        YearLevelMaintenance.txtID.Clear()
                        ListView1.SelectedItems.Clear()
                        txtUserlevel.Text = ""
                        MsgBox("Canceled", MsgBoxStyle.Information)
                    End If

                ElseIf Me.ListView1.SelectedItems.Count < 1 Then
                    msgerror("Please Select Item to Remove")

                    Exit Sub
                End If

            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Beep()
            Me.Close()
            MainForm.Show()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        'Try

        'If ListView1.SelectedItems.Count <> 0 Then
        '    txtUserlevel.Text = ListView1.SelectedItems(0).SubItems(11).Text
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub


    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            If ListView1.SelectedItems.Count <> 0 Then
                txtUserlevel.Text = ListView1.SelectedItems(0).SubItems(11).Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class