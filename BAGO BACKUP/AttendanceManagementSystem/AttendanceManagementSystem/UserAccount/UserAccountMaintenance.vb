Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions
Public Class UserAccountMaintenance
    Public Gender As String
    Public Question As String
    Public UserLevel As String
    Public UserID As String
    Public cont_checker As String
    Sub loadQues()

        Try
            con.Close()
            con.Open()
            Dim Cmd As New SqlClient.SqlCommand("SELECT SecurityQuestion FROM tblSecurityQuestion", con)
            Cmd.ExecuteNonQuery()
            Dim Datatable As New DataTable
            Dim DataAdapter As New SqlClient.SqlDataAdapter(Cmd)
            DataAdapter.Fill(Datatable)
            cbQues.DataSource = Datatable
            cbQues.ValueMember = "SecurityQuestion"
            cbQues.DisplayMember = "SecurityQuestion"
        Catch ex As Exception
            msgerror(Err.Description)
            con.Close()
        End Try


    End Sub
    Sub autoID()
        connect()
        Try

            Dim i As Double
            Dim sql As String
            sql = "Select Max(UserID) from tblAdmin"
            Dim com As New SqlClient.SqlCommand(sql, con)
            If IsDBNull(com.ExecuteScalar) Then
                i = "1111111111"
                lblUserID.Text = i.ToString
            Else
                i = com.ExecuteScalar + 1
                lblUserID.Text = i.ToString
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub
    Private Sub UserAccountMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

        
        loadQues()
        autoID()
            'cbQues.SelectedIndex = -1
        cbgen.SelectedIndex = -1

            cbULevel.Text = "Staff"
            cont_checker = ""
        ' cbULevel.SelectedIndex = -1
        If Question <> "" And Gender <> "" And UserLevel <> "" And UserID <> "" Then
            cbQues.Text = Question
            cbgen.Text = Gender
            cbULevel.Text = UserLevel
            lblUserID.Text = UserID
        ElseIf Question = "" Then
            cbQues.SelectedIndex = -1
            cbgen.SelectedIndex = -1
            '  cbULevel.SelectedIndex = -1

            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub
   
    Private Function SubInsertAdmin()
        Try

            connect()
            con.Close()
            con.Open()


            If PictureBox2.Image Is Nothing Then
                If MsgBox("Are you sure yo want to add this data?", MsgBoxStyle.YesNo) = vbYes Then
                    connect()
                    cmd.Connection = con
                    cmd.CommandText = "INSERT INTO tblAdmin(Lastname,Firstname,MI,Age,Gender,Contact,Address,Username,Password,Question,Answer,QiD,UserLevel,Photo,UserID,SumAdmin,SumStaff)" & _
                        "Values (@Ln,@Fn,@Mn,@Age,@Gen,@Cont,@AD,@Use,@Pass,@Que,@Ans,@QueID,@UL,@Img,@UI,@SA,@SS)"
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@Ln", txtLname.Text)
                    cmd.Parameters.AddWithValue("@Fn", txtFname.Text)
                    cmd.Parameters.AddWithValue("@Mn", txtMI.Text)
                    cmd.Parameters.AddWithValue("@Age", txtAge.Text)
                    cmd.Parameters.AddWithValue("@Gen", cbgen.Text)
                    cmd.Parameters.AddWithValue("@Cont", txtCont.Text)
                    cmd.Parameters.AddWithValue("@AD", txtAdd.Text)
                    cmd.Parameters.AddWithValue("@Use", txtUser.Text)
                    cmd.Parameters.AddWithValue("@Pass", txtPass.Text)
                    cmd.Parameters.AddWithValue("@Que", cbQues.Text)
                    cmd.Parameters.AddWithValue("@Ans", txtAns.Text)
                    cmd.Parameters.AddWithValue("@QueID", txtQuesId.Text)
                    cmd.Parameters.AddWithValue("@UL", cbULevel.Text)

                    Dim photoparam As New SqlParameter("@Img", SqlDbType.Image)
                    photoparam.Value = DBNull.Value
                    cmd.Parameters.Add(photoparam)

                    cmd.Parameters.AddWithValue("@UI", lblUserID.Text)
                    cmd.Parameters.AddWithValue("@SA", txtSumAdmin.Text)
                    cmd.Parameters.AddWithValue("@SS", txtSumStaff.Text)

                    Dim a As Integer = cmd.ExecuteNonQuery()
                    AuditTrail("User Account Maintenace ", "Insert", "User Info: " + txtLname.Text + "," + txtFname.Text + "," + txtAge.Text + "," + cbgen.Text + "|Username : " + txtUser.Text + "|UserLevel : " + cbULevel.Text)
                    If a > 0 Then

                        UserAccount.list()
                        UserAccount.SumStaff()
                        autoID()
                        msginfo("New User has been added")
                        clear()

                    Else
                        MsgBox("Failed")
                    End If
                End If
            ElseIf PictureBox2.Image IsNot Nothing Then
                Dim ms As New MemoryStream
                PictureBox2.Image.Save(ms, PictureBox2.Image.RawFormat)
                Dim arrimage() As Byte = ms.GetBuffer
                ms.Close()

                If MsgBox("Are you sure yo want to add this data?", MsgBoxStyle.YesNo) = vbYes Then
                    connect()
                    cmd.Connection = con
                    cmd.CommandText = "INSERT INTO tblAdmin(Lastname,Firstname,MI,Age,Gender,Contact,Address,Username,Password,Question,Answer,QiD,UserLevel,Photo,UserID,SumAdmin,SumStaff)" & _
                        "Values (@Ln,@Fn,@Mn,@Age,@Gen,@Cont,@AD,@Use,@Pass,@Que,@Ans,@QueID,@UL,@Img,@UI,@SA,@SS)"
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@Ln", txtLname.Text)
                    cmd.Parameters.AddWithValue("@Fn", txtFname.Text)
                    cmd.Parameters.AddWithValue("@Mn", txtMI.Text)
                    cmd.Parameters.AddWithValue("@Age", txtAge.Text)
                    cmd.Parameters.AddWithValue("@Gen", cbgen.Text)
                    cmd.Parameters.AddWithValue("@Cont", txtCont.Text)
                    cmd.Parameters.AddWithValue("@AD", txtAdd.Text)
                    cmd.Parameters.AddWithValue("@Use", txtUser.Text)
                    cmd.Parameters.AddWithValue("@Pass", txtPass.Text)
                    cmd.Parameters.AddWithValue("@Que", cbQues.Text)
                    cmd.Parameters.AddWithValue("@Ans", txtAns.Text)
                    cmd.Parameters.AddWithValue("@QueID", txtQuesId.Text)
                    cmd.Parameters.AddWithValue("@UL", cbULevel.Text)
                    cmd.Parameters.AddWithValue("@Img", arrimage)
                    cmd.Parameters.AddWithValue("@UI", lblUserID.Text)
                    cmd.Parameters.AddWithValue("@SA", txtSumAdmin.Text)
                    cmd.Parameters.AddWithValue("@SS", txtSumStaff.Text)
                    Dim a As Integer = cmd.ExecuteNonQuery()
                    AuditTrail("User Account Maintenace ", "Insert", "User Info: " + txtLname.Text + "," + txtFname.Text + "," + txtAge.Text + "," + cbgen.Text + "|Username : " + txtUser.Text + "|UserLevel : " + cbULevel.Text)
                    If a > 0 Then

                        UserAccount.list()
                        UserAccount.SumStaff()
                        autoID()
                        msginfo("New User has been added")
                        clear()

                    Else
                        MsgBox("Failed")
                    End If
                End If

            End If

        Catch ex As Exception
            msgerror(Err.Description)
        End Try
        con.Close()
        Return Nothing
    End Function
    Sub ContactCheckerUpd()
        Try
            Dim digit3 As String = txtCont.Text.Substring(0, 2)
            cont_checker = digit3
            If txtCont.Text = txtSubContact.Text Then
                SubUpdateAdmin()
            ElseIf txtCont.Text <> "" And txtCont.TextLength <= 10 Then
                msgerror("Invalid Contact Number")
                Exit Sub
            ElseIf txtCont.Text <> "" And cont_checker <> ("09") Then
                msgerror("First two digit must be 09")
                Exit Sub
            ElseIf checkContact() = True Then
                msgerror("Invalid, contact number already exist")
            Else
                SubUpdateAdmin()
            End If
        Catch ex As Exception
            msgerror("Invalid Contact Number")
        End Try
    End Sub
    Sub ContactChecker()
        Try
        Dim digit3 As String = txtCont.Text.Substring(0, 2)
        cont_checker = digit3
            If txtCont.Text = txtSubContact.Text Then
                SubInsertAdmin()
            ElseIf txtCont.Text <> "" And txtCont.TextLength <= 10 Then
                msgerror("Invalid Contact Number")
                Exit Sub
            ElseIf txtCont.Text <> "" And cont_checker <> ("09") Then
                msgerror("First two digit must be 09")
                Exit Sub
            ElseIf checkContact() = True Then
                msgerror("Invalid, contact number already exist")
            Else
                SubInsertAdmin()
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub
    Private Function GetImageData(image As Image) As Byte()
        Dim data As Byte()
        Using streem As New IO.MemoryStream
            image.Save(streem, Imaging.ImageFormat.Jpeg)
            data = streem.GetBuffer()
        End Using

        Return data
    End Function
    Private Function SubUpdateAdmin()
        Try



            If PictureBox2.Image Is Nothing Then

             
                ' Dim value As Object = If(PictureBox2.Image Is Nothing, CObj(DBNull.Value), GetImageData(PictureBox2.Image))

                con.Close()
                con.Open()
                connect()
                With cmd
                    cmd.Connection = con
                    .CommandText = "UPDATE tblAdmin SET  Lastname = @LN, Firstname = @FN, MI = @MN, Age = @AGE, Gender = @GEN, Contact = @CONT, Address = @ADD, " & _
                    " Username = @USER, Password = @PASS, Question = @QUES, Answer = @ANS, QiD = @QID, UserLevel = @UL,Photo = @Img, UserID = @UI " & _
                    "where Id = '" & txtId.Text & "'"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@LN", txtLname.Text)
                    .Parameters.AddWithValue("@FN", txtFname.Text)
                    .Parameters.AddWithValue("@MN", txtMI.Text)
                    .Parameters.AddWithValue("@AGE", txtAge.Text)
                    .Parameters.AddWithValue("@GEN", cbgen.Text)
                    .Parameters.AddWithValue("@CONT", txtCont.Text)
                    .Parameters.AddWithValue("@ADD", txtAdd.Text)
                    .Parameters.AddWithValue("@USER", txtUser.Text)
                    .Parameters.AddWithValue("@PASS", txtPass.Text)
                    .Parameters.AddWithValue("@QUES", cbQues.Text)
                    .Parameters.AddWithValue("@ANS", txtAns.Text)
                    .Parameters.AddWithValue("@QID", txtQuesId.Text)
                    .Parameters.AddWithValue("@UL", cbULevel.Text)

                    Dim photoparam As New SqlParameter("@Img", SqlDbType.Image)
                    photoparam.Value = DBNull.Value
                    .Parameters.Add(photoparam)

                    .Parameters.AddWithValue("@UI", lblUserID.Text)
                End With
                Dim a As Integer = cmd.ExecuteNonQuery()
                AuditTrail("User Account Maintenace ", "Update", "User Info: " + txtLname.Text + "," + txtFname.Text + "," + txtAge.Text + "," + cbgen.Text + "|Username : " + txtUser.Text + "|UserLevel : " + cbULevel.Text)
                If a > 0 Then
                    UpdateUsernameAuditTrail()
                    UpdateUsernameLoghistory()
                    UserAccount.list()
                    autoID()
                    MsgBox("Updated Successfully.")
                    clear()
                    Me.Close()
                End If
            ElseIf PictureBox2.Image IsNot Nothing Then

                Dim ms As New MemoryStream
                PictureBox2.Image.Save(ms, PictureBox2.Image.RawFormat)
                Dim arrimage() As Byte = ms.GetBuffer
                ms.Close()

                con.Close()
                con.Open()
                connect()
                With cmd
                    cmd.Connection = con
                    .CommandText = "UPDATE tblAdmin SET  Lastname = @LN, Firstname = @FN, MI = @MN, Age = @AGE, Gender = @GEN, Contact = @CONT, Address = @ADD, " & _
                    " Username = @USER, Password = @PASS, Question = @QUES, Answer = @ANS, QiD = @QID, UserLevel = @UL, Photo = @Img, UserID = @UI " & _
                    "where Id = '" & txtId.Text & "'"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@LN", txtLname.Text)
                    .Parameters.AddWithValue("@FN", txtFname.Text)
                    .Parameters.AddWithValue("@MN", txtMI.Text)
                    .Parameters.AddWithValue("@AGE", txtAge.Text)
                    .Parameters.AddWithValue("@GEN", cbgen.Text)
                    .Parameters.AddWithValue("@CONT", txtCont.Text)
                    .Parameters.AddWithValue("@ADD", txtAdd.Text)
                    .Parameters.AddWithValue("@USER", txtUser.Text)
                    .Parameters.AddWithValue("@PASS", txtPass.Text)
                    .Parameters.AddWithValue("@QUES", cbQues.Text)
                    .Parameters.AddWithValue("@ANS", txtAns.Text)
                    .Parameters.AddWithValue("@QID", txtQuesId.Text)
                    .Parameters.AddWithValue("@UL", cbULevel.Text)
                    .Parameters.AddWithValue("@Img", arrimage)
                    .Parameters.AddWithValue("@UI", lblUserID.Text)
                End With
                Dim a As Integer = cmd.ExecuteNonQuery()
                AuditTrail("User Account Maintenace ", "Update", "User Info: " + txtLname.Text + "," + txtFname.Text + "," + txtAge.Text + "," + cbgen.Text + "|Username : " + txtUser.Text + "|UserLevel : " + cbULevel.Text)
                If a > 0 Then
                    UpdateUsernameAuditTrail()
                    UpdateUsernameLoghistory()
                    UserAccount.list()
                    autoID()
                    MsgBox("Updated Successfully.")
                    clear()
                    Me.Close()
                Else
                    MsgBox("Failed to Update.")
                End If
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try


        Return Nothing
    End Function
  
    Private Function UpdateUsernameAuditTrail()
        con.Close()
        con.Open()
        connect()
        With cmd
            .Connection = con
            .CommandText = "Update tblAuditTrail SET  Username = @USER where Username = '" & txtSubUsername.Text & "'"
            .Parameters.Clear()
            .Parameters.AddWithValue("@USER", txtUser.Text)
        End With


        Dim a As Integer = cmd.ExecuteNonQuery()
        If a > 0 Then
            AuditTrailHistory.list()
        End If
        Return Nothing
    End Function
    Private Function UpdateUsernameLoghistory()
        con.Close()
        con.Open()
        connect()
        With cmd
            .Connection = con
            .CommandText = "Update tblLogHistory SET  Username = @USER where Username = '" & txtSubUsername.Text & "'"
            .Parameters.Clear()
            .Parameters.AddWithValue("@USER", txtUser.Text)
        End With


        Dim a As Integer = cmd.ExecuteNonQuery()
        If a > 0 Then
            LogHistory.list()
        End If
        Return Nothing
    End Function
    Sub clear()
        txtLname.Text = ""
        txtFname.Text = ""
        txtMI.Text = ""
        txtAge.Text = ""
        cbgen.SelectedIndex = -1
        txtCont.Text = ""
        ' cbULevel.SelectedIndex = -1
        ' cbULevel.SelectedIndex = -1
        txtAdd.Text = ""
        txtUser.Text = ""
        txtPass.Text = ""
        txtCpass.Text = ""
        txtAns.Text = ""
        txtQuesId.Text = ""
        txtUname2.Text = ""
        txtUserlevel.Text = ""
        txtId.Text = ""
        cbQues.SelectedIndex = -1
        '   cbULevel.SelectedIndex = -1
        PictureBox2.Image = Nothing
        ' txtPass.UseSystemPasswordChar = True
        'txtCpass.UseSystemPasswordChar = True
        'txtAns.UseSystemPasswordChar = True
        'txtShow.Visible = True
        'txtHide.Visible = False
        'txtShow1.Visible = True
        'txtHide1.Visible = False
        'txtShow2.Visible = True
        'txtHide2.Visible = False
    End Sub



    Private Sub txtId_TextChanged(sender As Object, e As EventArgs) Handles txtId.TextChanged
        'Try
        '    If txtId.Text <> "" Then
        '        Dim cmd As New SqlCommand("Select * from tblAdmin where Id = '" & txtId.Text & "'", con)
        '        Dim table As New DataTable
        '        Dim adpt As New SqlDataAdapter(cmd)
        '        adpt.Fill(table)
        '        Dim img() As Byte
        '        img = table.Rows(0)(14)
        '        Dim ms As New MemoryStream(img)
        '        'If Image.FromStream(ms) Is System.DBNull.Value Then
        '        '    PictureBox2.Image = Nothing
        '        'Else
        '        PictureBox2.Image = Image.FromStream(ms)
        '        txtPass.Text = table.Rows(0)(9).ToString()
        '        txtCpass.Text = table.Rows(0)(9).ToString()
        '        txtAns.Text = table.Rows(0)(11).ToString()
        '        txtQuesId.Text = table.Rows(0)(12).ToString()
        '        TextBox1.Text = table.Rows(0)(13).ToString()
        '        '  End If
        '    ElseIf txtId.Text = "" Then
        '        PictureBox2.Image = Nothing
        '    End If
        'Catch ex As Exception
        '    '  msgerror(Err.Description)
        '    PictureBox2.Image = Nothing
        'End Try
    End Sub

    Private Sub BunifuThinButton24_Click(sender As Object, e As EventArgs) Handles BunifuThinButton24.Click
        With OpenFileDialog1
            .InitialDirectory = "C:\Pictures\"
            .Filter = "All Files|*.*|Bitmap|*.bmp|Gifs|*.gif|JPEGs|*.jpg"
            .FilterIndex = 1
        End With
        If OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            With PictureBox2
                .Image = Image.FromFile(OpenFileDialog1.FileName)
                .BorderStyle = BorderStyle.Fixed3D
                .SizeMode = PictureBoxSizeMode.StretchImage
            End With
        End If
    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click
        If txtId.Text = "" Then
            InsertValidation()
        ElseIf txtId.Text <> "" Then
            UpdateValidation()
        End If
       
    End Sub
    Sub InsertValidation()
        If txtUser.Text = "" Or txtPass.Text = "" Or txtCpass.Text = "" Or txtLname.Text = "" Or txtFname.Text = "" Or txtAge.Text = "" Or cbgen.SelectedIndex = -1 Or cbULevel.Text = "" Or txtAns.Text = "" Then
            msgerror("Complete all details")
        ElseIf txtUser.Text = "" Then
            msgerror("Username is Empty")
        ElseIf txtPass.Text = "" Then
            msgerror("Password is Empty")
        ElseIf txtPass.Text <> txtCpass.Text Then
            msgerror("Password and Confirm Password doesn't match")
        ElseIf cbgen.Text = "" Then
            msgerror("Please select gender")
        ElseIf cbQues.SelectedIndex = -1 Then
            msgerror("Please select a security question")
        ElseIf txtAns.Text = "" Then
            msgerror("Please answer the question")
        ElseIf txtLname.TextLength <= 1 Then
            msgerror("Invalid, Lastname must be 2 to 30 characters")
        ElseIf txtUser.TextLength < 6 Then
            msgerror("Invalid, Username must be 6  to 20 characters")
        ElseIf txtPass.TextLength < 6 Then
            msgerror("Invalid, Password must be 6 to 20 characters")
        ElseIf txtAge.Text < 18 Then
            msgerror("Unacceptable Age")
        ElseIf txtAdd.Text <> "" And txtAdd.TextLength < 5 Then
            msgerror("Invalid, Address must be 6 to 100 characters")
        ElseIf (txtLname.Text.EndsWith(" ")) Then
            msgerror("Invalid format Last Name " + txtLname.Text + "''Space''")
        ElseIf (txtFname.Text.EndsWith(" ")) Then
            msgerror("Invalid format First Name " + txtFname.Text + "''Space''")
        ElseIf (txtUser.Text.EndsWith(" ")) Then
            msgerror("Invalid format User Name " + txtUser.Text + "''Space''")
        ElseIf (txtPass.Text.EndsWith(" ")) Then
            msgerror("Invalid format Password " + txtPass.Text + "''Space''")
        ElseIf (txtCpass.Text.EndsWith(" ")) Then
            msgerror("Invalid format Confirm Password " + txtCpass.Text + "''Space''")
        ElseIf (txtAdd.Text.EndsWith(" ")) Then
            msgerror("Invalid format Address " + txtAdd.Text + "''Space''")
        ElseIf (txtAns.Text.EndsWith(" ")) Then
            msgerror("Invalid format Answer " + txtAns.Text + "''Space''")
        ElseIf txtCont.Text <> "" Then
            ContactChecker()
        ElseIf txtId.Text = "" Then
            If txtMI.Text = "" And txtCont.Text = "" And txtAdd.Text = "" And PictureBox2.Image Is Nothing Then
                If checkUser() = True Then
                    msgerror("Username already Exists")
                    Exit Sub
                ElseIf txtCont.Text = "" Then
                    SubInsertAdmin()
                    Exit Sub
                ElseIf checkContact() = True Then
                    msgerror("Contact already Exists")
                    Exit Sub
                Else
                    SubInsertAdmin()
                End If
            ElseIf txtCont.Text = "" And txtAdd.Text = "" And PictureBox2.Image Is Nothing Then
                If checkUser() = True Then
                    msgerror("Username already Exists")
                    Exit Sub
                ElseIf txtCont.Text = "" Then
                    SubInsertAdmin()
                    Exit Sub
                ElseIf checkContact() = True Then
                    msgerror("Contact already Exists")
                    Exit Sub
                Else
                    SubInsertAdmin()
                End If
            ElseIf txtMI.Text = "" And txtAdd.Text = "" And PictureBox2.Image Is Nothing Then
                If checkUser() = True Then
                    msgerror("Username already Exists")
                    Exit Sub
                ElseIf checkContact() = True Then
                    msgerror("Contact already Exists")
                    Exit Sub
                Else
                    SubInsertAdmin()
                End If
            ElseIf txtMI.Text = "" And txtCont.Text = "" And PictureBox2.Image Is Nothing Then
                If checkUser() = True Then
                    msgerror("Username already Exists")
                    Exit Sub
                ElseIf txtCont.Text = "" Then
                    SubInsertAdmin()
                    Exit Sub
                ElseIf checkContact() = True Then
                    msgerror("Contact already Exists")
                    Exit Sub
                Else
                    SubInsertAdmin()
                End If
            ElseIf txtMI.Text = "" And txtCont.Text = "" And txtAdd.Text = "" Then
                If checkUser() = True Then
                    msgerror("Username already Exists")
                    Exit Sub
                ElseIf txtCont.Text = "" Then
                    SubInsertAdmin()
                    Exit Sub
                ElseIf checkContact() = True Then
                    msgerror("Contact already Exists")
                    Exit Sub
                Else
                    SubInsertAdmin()
                End If
            ElseIf txtMI.Text = "" And txtCont.Text = "" Then
                If checkUser() = True Then
                    msgerror("Username already Exists")
                    Exit Sub
                ElseIf txtCont.Text = "" Then
                    SubInsertAdmin()
                    Exit Sub
                ElseIf checkContact() = True Then
                    msgerror("Contact already Exists")
                    Exit Sub
                Else
                    SubInsertAdmin()
                End If
            ElseIf txtMI.Text = "" And txtAdd.Text = "" Then
                If checkUser() = True Then
                    msgerror("Username already Exists")
                    Exit Sub
                ElseIf checkContact() = True Then
                    msgerror("Contact already Exists")
                    Exit Sub
                Else
                    SubInsertAdmin()
                End If
            ElseIf txtMI.Text = "" And PictureBox2.Image Is Nothing Then
                If checkUser() = True Then
                    msgerror("Username already Exists")
                    Exit Sub
                ElseIf checkContact() = True Then
                    msgerror("Contact already Exists")
                    Exit Sub
                Else
                    SubInsertAdmin()
                End If
            ElseIf txtCont.Text = "" And txtAdd.Text = "" Then
                If checkUser() = True Then
                    msgerror("Username already Exists")
                    Exit Sub
                ElseIf txtCont.Text = "" Then
                    SubInsertAdmin()
                    Exit Sub
                ElseIf checkContact() = True Then
                    msgerror("Contact already Exists")
                    Exit Sub
                Else
                    SubInsertAdmin()
                End If
            ElseIf txtCont.Text = "" And PictureBox2.Image Is Nothing Then
                If checkUser() = True Then
                    msgerror("Username already Exists")
                    Exit Sub
                ElseIf txtCont.Text = "" Then
                    SubInsertAdmin()
                    Exit Sub
                ElseIf checkContact() = True Then
                    msgerror("Contact already Exists")
                    Exit Sub
                Else
                    SubInsertAdmin()
                End If
            ElseIf txtAdd.Text = "" And PictureBox2.Image Is Nothing Then
                If checkUser() = True Then
                    msgerror("Username already Exists")
                    Exit Sub
                ElseIf checkContact() = True Then
                    msgerror("Contact already Exists")
                    Exit Sub
                Else
                    SubInsertAdmin()
                End If
            ElseIf PictureBox2.Image Is Nothing Then
                If checkUser() = True Then
                    msgerror("Username already Exists")
                    Exit Sub
                ElseIf checkContact() = True Then
                    msgerror("Contact already Exists")
                    Exit Sub
                Else
                    SubInsertAdmin()
                End If
            ElseIf txtAdd.Text = "" Then
                If checkUser() = True Then
                    msgerror("Username already Exists")
                    Exit Sub
                ElseIf checkContact() = True Then
                    msgerror("Contact already Exists")
                    Exit Sub
                Else
                    SubInsertAdmin()
                End If
            ElseIf txtCont.Text = "" Then
                If checkUser() = True Then
                    msgerror("Username already Exists")
                    Exit Sub
                ElseIf txtCont.Text = "" Then
                    SubInsertAdmin()
                    Exit Sub
                ElseIf txtCont.Text = "" Then
                    SubInsertAdmin()
                    Exit Sub
                ElseIf checkContact() = True Then
                    msgerror("Contact already Exists")
                    Exit Sub
                Else
                    SubInsertAdmin()
                End If
            ElseIf txtMI.Text = "" Then
                If checkUser() = True Then
                    msgerror("Username already Exists")
                    Exit Sub
                ElseIf checkContact() = True Then
                    msgerror("Contact already Exists")
                    Exit Sub
                Else
                    SubInsertAdmin()
                End If
            ElseIf checkUser() = True Then
                msgerror("Username already Exists")
                Exit Sub
            ElseIf checkContact() = True Then
                msgerror("Contact already Exists")
                Exit Sub  
            End If     
        Else
            SubInsertAdmin()
        End If
    End Sub
    Sub UpdateValidation()
        If txtUser.Text = "" Or txtPass.Text = "" Or txtCpass.Text = "" Or txtLname.Text = "" Or txtFname.Text = "" Or txtAge.Text = "" Or cbgen.SelectedIndex = -1 Or cbULevel.Text = "" Or txtAns.Text = "" Then
            msgerror("Complete all details")
        ElseIf txtUser.Text = "" Then
            msgerror("Username is Empty")
        ElseIf txtPass.Text = "" Then
            msgerror("Password is Empty")
        ElseIf txtPass.Text <> txtCpass.Text Then
            msgerror("Password and Confirm Password doesn't match")
        ElseIf cbgen.Text = "" Then
            msgerror("Please select gender")
        ElseIf cbQues.SelectedIndex = -1 Then
            msgerror("Please select a security question")
        ElseIf txtAns.Text = "" Then
            msgerror("Please answer the question")
        ElseIf txtLname.TextLength <= 1 Then
            msgerror("Invalid, Lastname must be 2 to 30 characters")
        ElseIf txtUser.TextLength < 6 Then
            msgerror("Invalid, Username must be 6  to 20 characters")
        ElseIf txtPass.TextLength < 6 Then
            msgerror("Invalid, Password must be 6 to 20 characters")
        ElseIf txtAge.Text < 18 Then
            msgerror("Unacceptable Age")
        ElseIf txtAdd.Text <> "" And txtAdd.TextLength < 5 Then
            msgerror("Invalid, Address must be 6 to 100 characters") 
        ElseIf (txtLname.Text.EndsWith(" ")) Then
            msgerror("Invalid format Last Name " + txtLname.Text + "''Space''")
        ElseIf (txtFname.Text.EndsWith(" ")) Then
            msgerror("Invalid format First Name " + txtFname.Text + "''Space''")
        ElseIf (txtUser.Text.EndsWith(" ")) Then
            msgerror("Invalid format User Name " + txtUser.Text + "''Space''")
        ElseIf (txtPass.Text.EndsWith(" ")) Then
            msgerror("Invalid format Password " + txtPass.Text + "''Space''")
        ElseIf (txtCpass.Text.EndsWith(" ")) Then
            msgerror("Invalid format Confirm Password " + txtCpass.Text + "''Space''")
        ElseIf (txtAdd.Text.EndsWith(" ")) Then
            msgerror("Invalid format Address " + txtAdd.Text + "''Space''")
        ElseIf (txtAns.Text.EndsWith(" ")) Then
            msgerror("Invalid format Answer " + txtAns.Text + "''Space''")
        ElseIf txtCont.Text <> ("") Then
            ContactCheckerUpd()
            Exit Sub
        ElseIf txtUser.Text = txtSubUsername.Text Then
            If txtCont.Text <> txtSubContact.Text Then
                If txtCont.Text = ("") Then
                    SubUpdateAdmin()
                ElseIf checkContact() = True Then
                    msgerror("Contact number already Exists")
                Else
                    SubUpdateAdmin()
                End If
            Else
                SubUpdateAdmin()
            End If
        ElseIf txtCont.Text = txtSubContact.Text Then
            If txtUser.Text <> txtSubUsername.Text Then
                If txtCont.Text = ("") Then
                    SubUpdateAdmin()
                ElseIf checkUser() = True Then
                    msgerror("Username already Exists")
                Else
                    SubUpdateAdmin()
                End If
            Else
                SubUpdateAdmin()
            End If
        ElseIf txtUser.Text <> ("") Then
            If checkUser() = True Then
                msgerror("Username already Exists")
            ElseIf txtCont.Text <> ("") Then
                If checkContact() = True Then
                    msgerror("Contact number already Exists")
                Else
                    SubUpdateAdmin()
                End If
            End If
        Else
            SubUpdateAdmin()
        End If
    End Sub
    Public Function checkUser()
        Try
            connect()
            Dim adp As New SqlDataAdapter
            Dim dt As New DataTable
            Dim query As String = "SELECT * FROM tblAdmin  WHERE Username = @USER"

            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@USER", txtUser.Text)

            With adp
                .SelectCommand = cmd
                .Fill(dt)
            End With
          

                If dt.Rows.Count >= 1 Then

                    Return True
                    Exit Function
                End If


        Catch ex As Exception
            msgerror(Err.Description)
        End Try
        Return Nothing
    End Function
    Public Function checkContact()
        Try
            connect()


            Dim adp As New SqlDataAdapter
            Dim dt As New DataTable
            Dim query As String = "SELECT * FROM tblAdmin  WHERE Contact = @CON"

            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@CON", txtCont.Text)

            With adp
                .SelectCommand = cmd
                .Fill(dt)
            End With
       
                If dt.Rows.Count >= 1 Then

                    Return True
                    Exit Function
                End If


        Catch ex As Exception
            msgerror(Err.Description)
        End Try
        Return Nothing
    End Function
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim dialog As DialogResult
            dialog = MessageBox.Show("Do you want to Close this?", "", MessageBoxButtons.YesNo)
            If dialog = DialogResult.No Then
                Beep()
                MsgBox("Cancel!!")
            Else
                UserAccount.ListView1.SelectedItems.Clear()
                UserAccount.txtID.Text = MainForm.txtID.Text
                Question = ""
                Gender = ""
                UserLevel = ""

                Beep()
                Me.Close()
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        clear()
    End Sub

    Private Sub cbQues_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbQues.SelectedIndexChanged

        Try
            If cbQues.SelectedIndex = -1 Then
                txtQuesId.Text = ""

            Else

                connect()
                con.Close()
                con.Open()
                Dim com As New SqlClient.SqlCommand

                com.Connection = con

                com.CommandText = "Select id From tblSecurityQuestion Where SecurityQuestion = @D"
                com.Parameters.AddWithValue("@D", cbQues.Text)
                txtQuesId.Text = com.ExecuteScalar

                con.Close()
            End If
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub

    Private Sub txtCont_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCont.KeyPress
        If Char.IsDigit(e.KeyChar) = False And e.KeyChar <> ChrW(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtLname_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLname.KeyDown
        If txtLname.Text <> "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = False
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        ElseIf txtLname.Text = "" Then
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

    Private Sub txtLname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLname.KeyPress
        Dim a As String = txtLname.Text
        If a.Contains(" ") Then
            If e.KeyChar = " " Then
                e.Handled = True
                Exit Sub
            End If
        Else
            e.Handled = False
        End If
        If e.KeyChar = " " AndAlso txtLname.Text.EndsWith(" ") Then
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

    Private Sub txtFname_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFname.KeyDown
        If txtFname.Text <> "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = False
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        ElseIf txtFname.Text = "" Then
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

    Private Sub txtFname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFname.KeyPress
        If e.KeyChar = " "c AndAlso txtFname.Text.EndsWith(" ") Then
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
    Private Sub txtMI_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMI.KeyDown
        If txtMI.Text <> "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = False
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        ElseIf txtMI.Text = "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        End If
    End Sub

    Private Sub txtMI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMI.KeyPress
        Select Case e.KeyChar
            Case Convert.ToChar(Keys.Enter)

            Case Convert.ToChar(Keys.Back)
                e.Handled = False

            Case Convert.ToChar(Keys.Capital Or Keys.RButton)
                e.Handled = Not Clipboard.GetText().All(Function(c) validchars2.Contains(c))
            Case Else
                e.Handled = Not validchars2.Contains(e.KeyChar)
        End Select

        If Char.IsLetter(e.KeyChar) = False And e.KeyChar <> ChrW(8) Then
            e.Handled = True
            Exit Sub
        End If
        If txtMI.Text.Length >= 0 Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
            Exit Sub
        End If


    End Sub

    Private Sub txtUser_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUser.KeyDown

        If txtUser.Text <> "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = False
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        ElseIf txtUser.Text = "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
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

    Private Sub txtPass_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPass.KeyDown

        If txtPass.Text <> "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = False
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        ElseIf txtPass.Text = "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
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

    Private Sub txtCpass_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCpass.KeyDown
        If txtCpass.Text <> "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = False
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

            End If
        ElseIf txtCpass.Text = "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

            End If
        End If
    End Sub

    Private Sub txtCpass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCpass.KeyPress
        If e.KeyChar = " " AndAlso txtCpass.Text.EndsWith("") Then
            e.KeyChar = Chr(0)
            e.Handled = True
            Exit Sub
        End If
        If txtCpass.Text.Length >= 0 Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
            Exit Sub
        End If

    End Sub

    Private Sub txtAge_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAge.KeyDown
        If (e.Control AndAlso e.KeyCode = Keys.S) Then
            btnSAVE.PerformClick()
        End If

        If txtAge.Text = "" Then
            If e.KeyCode = Keys.D0 Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.NumPad0 Then
                e.SuppressKeyPress = True
            End If
        End If
    End Sub

    Private Sub txtAge_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAge.KeyPress
        If Char.IsDigit(e.KeyChar) = False And e.KeyChar <> ChrW(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtAge_TextChanged(sender As Object, e As EventArgs) Handles txtAge.TextChanged

    End Sub

    Private Sub txtAns_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAns.KeyDown

        If txtAns.Text <> "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = False
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        ElseIf txtAns.Text = "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
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

    Private Sub txtAdd_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAdd.KeyDown
        If txtAdd.Text <> "" Then
            If e.KeyCode = Keys.Space Then
                e.SuppressKeyPress = False
            ElseIf e.KeyCode = Keys.Alt Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        ElseIf txtAdd.Text = "" Then
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

    Private Sub txtAdd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAdd.KeyPress
        If e.KeyChar = " " AndAlso txtAdd.Text.EndsWith(" ") Then
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
    Private Sub txtLname_LostFocus(sender As Object, e As EventArgs) Handles txtLname.LostFocus
        txtLname.Text = StrConv(txtLname.Text, vbProperCase)
    End Sub
    Private Sub txtFname_LostFocus(sender As Object, e As EventArgs) Handles txtFname.LostFocus
        txtFname.Text = StrConv(txtFname.Text, vbProperCase)
    End Sub
    Private Sub txtAdd_LostFocus(sender As Object, e As EventArgs) Handles txtAdd.LostFocus
        txtAdd.Text = StrConv(txtAdd.Text, vbProperCase)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PictureBox2.Image = Nothing
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class