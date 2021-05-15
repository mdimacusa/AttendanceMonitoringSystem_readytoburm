Imports System.Management
Imports System.IO.Ports
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading
Public Class EJCSMS
    Private serialPort As New IO.Ports.SerialPort
    'EJC SMS Configuration

    ' System Configuration
    Private Const MAX_SMS_CHARACTERS = 155
    Private Const THREAD_SLEEP = 100
    Private Const DELAY_SEND = 1000
    Private LISTS_PHILIPPINES_SIM_PREFIXES() As String =
            {"0817", "0973", "0904", "0916", "0935", "0956", "0975", "0979", "0905", "0917", "0936",
                "0965", "0976", "0994", "0906", "0926", "0937", "0966", "0977", "0995", "0915", "0927", "0945", "0967", "0978",
                "0997", "09173", "09178", "09256", "09175", "09253", "09257", "09176", "09255", "09258", "0907", "0912", "0946",
                "0909", "0930", "0948", "0910", "0938", "0950", "0813", "0913", "0919", "0928", "0947", "0970", "0998",
                "0908", "0914", "0920", "0929", "0949", "0981", "0999", "0911", "0918", "0921", "0939", "0961", "0989",
                "0922", "0931", "0941", "0923", "0932", "0942", "0924", "0933", "0943", "0925", "0934", "0944"}
    Private ReadOnly SMS_DIRECTORY As String = String.Format("{0}\\EJC_SMS", Application.StartupPath())
    'User Config
    Private ENABLE_EXCEED_MAXIMUM_CHARACTER_SMS As Boolean = False
    Private ENABLE_EMPTY_SMS_MESSAGE As Boolean = False
    Public Sub New(ByVal allow_long_msg As Boolean, ByVal allow_empty_sms As Boolean)
        Dim IsDirectoryExist As Boolean = Directory.Exists(SMS_DIRECTORY)
        If Not IsDirectoryExist Then
            Dim dir = Directory.CreateDirectory(SMS_DIRECTORY)
            dir.Create()
        End If
        ENABLE_EXCEED_MAXIMUM_CHARACTER_SMS = allow_long_msg
        ENABLE_EMPTY_SMS_MESSAGE = allow_empty_sms
    End Sub
    Public Sub InitSMS(ByVal port_name As String)
        With serialPort
            .PortName = port_name
            .Parity = Nothing
            .DataBits = 8
            .Handshake = IO.Ports.Handshake.XOnXOff
            .DtrEnable = True
            .RtsEnable = True
            .NewLine = Environment.NewLine
        End With
    End Sub
    Private Sub createMessage(ByVal recipient_number As String, ByVal recipient_message As String)
        Try
            serialPort.Open()
            If (serialPort.IsOpen) Then
                With serialPort
                    .WriteLine("AT" & vbCrLf)
                    Thread.Sleep(THREAD_SLEEP)
                    .WriteLine("AT+CMGF=1" & vbCrLf)
                    Thread.Sleep(THREAD_SLEEP)
                    .WriteLine("AT+CSCS=""GSM"" " & vbCrLf)
                    Thread.Sleep(THREAD_SLEEP)
                    .WriteLine("AT+CMGS=" & Chr(34) & recipient_number & Chr(34) & vbCrLf)
                    Thread.Sleep(THREAD_SLEEP)
                    .Write(recipient_message & Chr(26))
                    Thread.Sleep(THREAD_SLEEP)
                End With
                serialPort.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Function SendMultipleSMS(ByVal number As List(Of String), ByVal recipient_message As String) As Integer
        For Each recipient_number In number
            If ENABLE_EXCEED_MAXIMUM_CHARACTER_SMS = True And recipient_message.Length > MAX_SMS_CHARACTERS Then
                Dim recipient_messageLength As Integer = recipient_message.Length
                Dim lowp As Integer = 0
                Dim value As Double = Convert.ToDouble(recipient_messageLength / MAX_SMS_CHARACTERS)
                Dim maxcount As Double = value
                For index As Integer = 0 To maxcount
                    lowp += 1
                Next
                createMessage(recipient_number, recipient_message.Substring(0, MAX_SMS_CHARACTERS))
                Console.WriteLine(recipient_message.Substring(0, MAX_SMS_CHARACTERS))
                Dim getLastCut As Integer = MAX_SMS_CHARACTERS
                For index As Integer = 0 To lowp
                    If getLastCut > recipient_messageLength Then
                        Exit For
                    End If
                    recipient_messageLength -= MAX_SMS_CHARACTERS
                    Dim getLastCutEx As Integer = IIf(recipient_messageLength > MAX_SMS_CHARACTERS, MAX_SMS_CHARACTERS, recipient_messageLength)
                    createMessage(recipient_number, recipient_message.Substring(getLastCut, getLastCutEx))
                    Console.WriteLine(recipient_message.Substring(getLastCut, getLastCutEx))
                    getLastCut += MAX_SMS_CHARACTERS
                Next
            Else
                createMessage(recipient_number, recipient_message)
            End If
        Next
        Return Nothing
    End Function
End Class


