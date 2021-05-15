'Imports System.Data.SqlClient
'Imports System.Data.OleDb

'Public Class site
'    ' Dim DGVuplaod1 As Object
'    ' Private Property DGVuplaod1 As Object





'    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
'        If MsgBox("Do you want to upload the file ", MsgBoxStyle.YesNo, "file upload") = MsgBoxResult.Yes Then
'            Dim fBrowse As New OpenFileDialog
'            With fBrowse                        'open file
'                .Filter = "Excel files(*.xlsx)|*.xlsx|All files (*.*)|*.*"
'                .FilterIndex = 1
'                .Title = "Import data from Excel file"
'            End With
'            If fBrowse.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
'                Dim fname As String
'                fname = fBrowse.FileName

'                Dim ExcelConnection As New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & fname & " ';Extended Properties=""Excel 12.0 Xml;HDR=Yes""")
'                ExcelConnection.Open()

'                Dim expr As String = "SELECT * FROM [Sheet1$]"
'                Dim objCmdSelect As OleDbCommand = New OleDbCommand(expr, ExcelConnection)

'                Dim objDR As OleDbDataReader

'                Dim SQLconn As New SqlConnection()
'                Dim ConnString As String = "Data Source=MakMak\SQLEXPRESS;Initial Catalog=AttendanceManagementSystem;Integrated Security=True"
'                SQLconn.ConnectionString = ConnString
'                SQLconn.Open()
'                Dim da As New OleDb.OleDbDataAdapter(objCmdSelect)
'                Dim dt As New DataTable
'                da.Fill(dt)
'                DataShitUpload.DataSource = dt



'                Using bulkCopy As SqlBulkCopy = New SqlBulkCopy(SQLconn)


'                    bulkCopy.DestinationTableName = "tblImportStudentMasterList"

'                    Try
'                        objDR = objCmdSelect.ExecuteReader

'                        bulkCopy.WriteToServer(objDR)
'                        objDR.Close()
'                        SQLconn.Close()

'                    Catch ex As Exception
'                        MsgBox(ex.ToString)
'                    End Try
'                End Using

'                MsgBox("The File Successfully Saved ")
'            End If
'        Else
'            Exit Sub
'        End If

'    End Sub


'    Private Sub site_Load(sender As Object, e As EventArgs) Handles MyBase.Load

'    End Sub



'End Class