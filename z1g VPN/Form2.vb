Imports System.Net.NetworkInformation
Imports System.Reflection.Emit
Imports System.Runtime.InteropServices

Public Class Form2
    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HT_CAPTION As Integer = &H2

    <DllImport("user32.dll")>
    Private Shared Function SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As Integer
    End Function

    <DllImport("user32.dll")>
    Private Shared Function ReleaseCapture() As Boolean
    End Function

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.Hide()
        PerformPing("usny2-auto-udp.ptoserver.com")
    End Sub

    Private Sub PerformPing(targetHost As String)
        Try
            ' Create a new Ping object
            Using pingSender As New Ping()
                ' Ping the target host
                Dim reply As PingReply = pingSender.Send(targetHost)

                ' Check if the ping was successful
                If reply.Status = IPStatus.Success Then
                    ' Get the round-trip time (ping time) in milliseconds
                    Dim pingTime As Long = reply.RoundtripTime

                    ' Update Label6 with the ping value
                    Label3.Text = "Ping: " & pingTime & "ms"

                    ' Load the appropriate image based on the ping range
                    If pingTime >= 0 AndAlso pingTime <= 49 Then
                        PictureBox2.Image = My.Resources.internet_6
                    ElseIf pingTime >= 50 AndAlso pingTime <= 79 Then
                        PictureBox2.Image = My.Resources.internet_5
                    ElseIf pingTime >= 80 AndAlso pingTime <= 100 Then
                        PictureBox2.Image = My.Resources.internet_4
                    ElseIf pingTime >= 100 AndAlso pingTime <= 119 Then
                        PictureBox2.Image = My.Resources.internet_3
                    ElseIf pingTime >= 120 AndAlso pingTime <= 149 Then
                        PictureBox2.Image = My.Resources.internet_2
                    ElseIf pingTime = 150 Then
                        PictureBox2.Image = My.Resources.internet_max
                    End If
                Else
                    ' If ping failed, display an error message
                    Label3.Text = "Ping Failed"
                    PictureBox2.Image = My.Resources.internet_none ' Clear the image
                End If
            End Using
        Catch ex As PingException
            ' If an exception occurs during the ping, display the error message
            Label3.Text = "Ping Exception: " & ex.Message
            PictureBox2.Image = My.Resources.internet_none ' Clear the image
        End Try
    End Sub

    Private Sub panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        server_selector.Show()
    End Sub
End Class