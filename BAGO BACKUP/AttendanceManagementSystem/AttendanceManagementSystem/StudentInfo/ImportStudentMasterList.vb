Imports System.Data.SqlClient
Imports System.Data.OleDb


Public Class ImportStudentMasterList

    Private Function saveData(sql As String)
        Dim mysqlCOn As SqlConnection = New SqlConnection("Data Source=MakMak\SQLEXPRESS;Initial Catalog=AttendanceManagementSystem;Integrated Security=True")
        Dim mysqlCmd As SqlCommand
        Dim resul As Boolean

        Try

            mysqlCOn.Open()
            mysqlCmd = New SqlCommand
            With mysqlCmd
                .Connection = mysqlCOn
                .CommandText = sql
                resul = .ExecuteNonQuery()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            mysqlCOn.Close()
        End Try
        Return resul
    End Function
    Private Sub ImportStudentMasterList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        list()
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
                StudentMasterList.Show()


            End If


        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub
    Sub list()
        con.Close()
        con.Open()
        ListView1.Items.Clear()
        cmd.Connection = con
        cmd.CommandText = "SELECT * FROM tblImportStudentMasterList"
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
        'Dim TotalPrice1 As String
        ' Dim quesid As String
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
            ' TotalPrice1 = dataread3.GetValue(12)
            ' quesid = dataread3.GetValue(13)
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
            ' arr(12) = "" & TotalPrice1 & ""
            ' arr(13) = "" & quesid & ""
            'arr(14) = "" & Ulevel & ""

            itm = New ListViewItem(arr)
            ListView1.Items.Add(itm)



        End While

        con.Close()
        MERGE1()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        With OpenFileDialog1
            .Filter = "Excel files(*.xlsx)|*.xlsx|All files (*.*)|*.*"
            .FilterIndex = 1
            .Title = "Import data from Excel file"
        End With

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            txtLocation.Text = OpenFileDialog1.FileName
        End If


        Dim OLEcon As OleDb.OleDbConnection = New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & txtLocation.Text & " ; " & "Extended Properties=Excel 8.0;")
        Dim OLEcmd As New OleDb.OleDbCommand
        Dim OLEda As New OleDb.OleDbDataAdapter
        Dim OLEdt As New DataTable
        Dim sql As String
        Dim resul As Boolean
        Try
            OLEcon.Open()
            With OLEcmd
                .Connection = OLEcon
                .CommandText = "select * from [Sheet1$]"
            End With
            OLEda.SelectCommand = OLEcmd
            OLEda.Fill(OLEdt)

            For Each r As DataRow In OLEdt.Rows

                sql = "INSERT INTO tblImportStudentMasterList (StudentID,Lastname,Firstname,MI,Birthdate,Gender,Yearlevel,Guardian,MobileNo,Address,Course,NoStudent) VALUES ('" & r(1).ToString & "','" & r(2).ToString & "','" & r(3).ToString & "','" & r(4).ToString & "','" & r(5).ToString & "','" & r(6).ToString & "','" & r(7).ToString & "','" & r(8).ToString & "','" & r(9).ToString & "','" & r(10).ToString & "','" & r(11).ToString & "','" & r(12).ToString & "')"
                resul = saveData(sql)
                If resul Then
                    Timer1.Start()


                End If

            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally

            OLEcon.Close()
        End Try
      
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Try

            Dim dialog As DialogResult
            dialog = MessageBox.Show("Are you sure you want Remove All Item? ", "", MessageBoxButtons.YesNo)

            If dialog = DialogResult.Yes Then


                con.Close()
                con.Open()
                cmd.CommandText = "DELETE tblImportStudentMasterList"
                Dim i As Integer = cmd.ExecuteNonQuery()


                list()

             
            End If
            con.Close()
        Catch ex As Exception
            msgerror(Err.Description)
        End Try

    End Sub
    Sub MERGE1()
        For r As Int32 = 0 To ListView1.Items.Count - 2
            For ra As Int32 = ListView1.Items.Count - 1 To r + 1 Step -1
                If ListView1.Items(r).ToString = ListView1.Items(ra).ToString Then
                    ListView1.Items.RemoveAt(ra)
                    MergeInsert()
                End If
            Next
        Next
    End Sub

    Private Function MergeInsert()
        Try
            connect()
            con.Close()
            con.Open()

            DeleteAll()

            For Each x As ListViewItem In ListView1.Items

                connect()
                cmd.Connection = con
                cmd.CommandText = "INSERT INTO tblImportStudentMasterList (StudentID,Lastname,Firstname,MI,Birthdate,Gender,Yearlevel,Guardian," & _
                    "MobileNo,Address,Course,NoStudent)" & _
                "VALUES (@SI,@LN,@FN,@M,@BD,@GEN,@YL,@GUAR,@MN,@ADD,@C,@NS)"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@SI", x.SubItems(0).Text)
                cmd.Parameters.AddWithValue("@LN", x.SubItems(1).Text)
                cmd.Parameters.AddWithValue("@FN", x.SubItems(2).Text)
                cmd.Parameters.AddWithValue("@M", x.SubItems(3).Text)
                cmd.Parameters.AddWithValue("@BD", x.SubItems(4).Text)
                cmd.Parameters.AddWithValue("@GEN", x.SubItems(5).Text)
                cmd.Parameters.AddWithValue("@YL", x.SubItems(6).Text)
                cmd.Parameters.AddWithValue("@GUAR", x.SubItems(7).Text)
                cmd.Parameters.AddWithValue("@MN", x.SubItems(8).Text)
                cmd.Parameters.AddWithValue("@ADD", x.SubItems(9).Text)
                cmd.Parameters.AddWithValue("@C", x.SubItems(10).Text)
                cmd.Parameters.AddWithValue("@NS", x.SubItems(11).Text)

                Dim a As Integer = cmd.ExecuteNonQuery()

                If a > 0 Then


                    list()
                Else


                End If



            Next

        Catch ex As Exception
            MsgBox(Err.Description)

        End Try
        con.Close()
        Return Nothing
    End Function
    Sub DeleteAll()
        Try
            con.Close()
            con.Open()

            cmd.CommandText = "DELETE tblImportStudentMasterList"
            Dim i As Integer = cmd.ExecuteNonQuery()





            con.Close()
        Catch ex As Exception
            msgerror(Err.Description)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If pg_load.Value = 100 Then
            Timer1.Stop()
            MsgBox("Successfully Imported")

            pg_load.Value = 0
            txtLocation.Text = ""
            list()
            MERGE1()
        Else
            pg_load.Value += 1
        End If
    End Sub

    
End Class
