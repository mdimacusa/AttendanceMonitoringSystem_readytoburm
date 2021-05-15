Imports System.Data.SqlClient
Imports System.Windows.Forms
Module Module1
    Public ReadOnly validcharsnumberonly As String = "0123456789"
    Public ReadOnly validchars As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ñÑ "
    Public ReadOnly validchars2 As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZñÑ "
    Public ReadOnly validchars3 As String = "abcdefghijklmnopqrstuvwxyzABZDEFGIJKLMNOPQRSTUVWXYZ?' "
    Public ReadOnly validchars4 As String = "abcdefghijklmnopqrstuvwxyzABZDEFGIJKLMNOPQRSTUVWXYZ?'Ññ"
    Public ReadOnly validchars5 As String = "1234567890."
    Public ReadOnly validchars6 As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ñÑ,.# "
    Public con As New SqlClient.SqlConnection("Data Source=MakMak\SQLEXPRESS;Initial Catalog=AttendanceManagementSystem;Integrated Security=True")
 
    Public adp As New SqlClient.SqlDataAdapter
    Public dt As New DataSet
    Public dtable As New DataTable
    Public cmd As New SqlClient.SqlCommand
   
    Public dataread As SqlDataReader
    Public que As String
    Public SAPI As Object
    Public nouse As Boolean
    Public kill As Boolean
    Public action As String

    Public Sub connect()
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        'Dim mResult
        'mResult = MetroFramework.MetroMessageBox.Show(Me, "", "", vbYesNo, MessageBoxIcon.Question)
        'If mResult = vbNo Then
    End Sub
    Public Sub msgerror(ByVal a As String)
        'SAPI = CreateObject(SAPI, ".spvoice")
        'SAPI.speak(a)
        MessageBox.Show(a, " ", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
    Public Sub msginfo(ByVal a As String)
        'SAPI = CreateObject (SAPI".spvoice")
        'SAPI.speak(a)
        MessageBox.Show(a, " ", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Public userlevel As String = ""
    Public Sub runcom(ByVal a As String)
        adp = New SqlClient.SqlDataAdapter(a, con)
        dt = New DataSet
        adp.Fill(dt, "a")
    End Sub
    Public Sub make_propercase(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim n As Integer = sender.SelectionStart
        sender.Text = StrConv(sender.text, VbStrConv.ProperCase)
        sender.SelectionStart = n
    End Sub
End Module
