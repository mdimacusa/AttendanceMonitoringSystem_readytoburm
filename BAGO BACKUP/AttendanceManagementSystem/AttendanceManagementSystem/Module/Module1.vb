Imports System.Data.SqlClient
Imports System.Windows.Forms
Module Module1
    Public ReadOnly validcharsnumberonly As String = "0123456789"
    Public ReadOnly validchars As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ñÑ "
    Public ReadOnly validchars2 As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZñÑ "
    Public ReadOnly validchars3 As String = "abcdefghijklmnopqrstuvwxyzABZDEFGIJKLMNOPQRSTUVWXYZ? "
    Public ReadOnly validchars4 As String = "abcdefghijklmnopqrstuvwxyzABZDEFGIJKLMNOPQRSTUVWXYZ?Ññ' "
    Public ReadOnly validchars5 As String = "1234567890."
    Public ReadOnly validchars6 As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ñÑ,.# "
    Public con As New SqlClient.SqlConnection("Data Source=MakMak\SQLEXPRESS;Initial Catalog=AttendanceManagementSystem;Integrated Security=True")
    Public con_shit As New SqlClient.SqlConnection("Data Source=MakMak\SQLEXPRESS;Initial Catalog=AttendanceManagementSystem;Integrated Security=True")
    Public adp As New SqlClient.SqlDataAdapter
    Public dt As New DataSet
    Public dtable As New DataTable
    Public cmd As New SqlClient.SqlCommand
    Public cmd_shit As New SqlClient.SqlCommand
    Public dataread As SqlDataReader
    Public que As String
    Public SAPI As Object
    Public nouse As Boolean
    Public kill As Boolean
    Public action As String
    Public GID As Integer
    Public str_user As String
    Public Function AuditTrail(ByVal fn As String, ByVal act As String, ByVal ts As String)
        Try
            con.Close()
            con.Open()
            connect()
            cmd.Connection = con
            cmd.CommandText = " Insert INTO tblAuditTrail(Username,Formname,Action,Transummary,Datetime) VALUES (@U,@FN,@AC,@TS,@DT)"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@U", SqlDbType.VarChar)
            If (str_user = Nothing) Then
                ' cmd.Parameters("@U").Value = DBNull.Value
                cmd.Parameters("@U").Value = "ALPHA PHI CHUPAPI"
            Else
                cmd.Parameters("@U").Value = str_user

            End If

            cmd.Parameters.AddWithValue("@FN", fn)
            cmd.Parameters.AddWithValue("@AC", act)
            cmd.Parameters.AddWithValue("@TS", ts)
            cmd.Parameters.AddWithValue("@DT", Date.Now)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Return Nothing
    End Function

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