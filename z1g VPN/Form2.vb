Imports System.Configuration
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
        Dim selectedServer As String = GetSelectedServer()

        Label4.Visible = False

        ' Display the selected server and its ping
        DisplaySelectedServer(selectedServer)
    End Sub

    Private Function GetSelectedServer() As String
        ' Get the selected server from the application settings
        Dim settings = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings.Settings
        Dim selectedServer As String = settings("SelectedServer").Value

        Return selectedServer
    End Function


    Public Sub DisplaySelectedServer(serverName As String)
        ' Update the label to display the selected server
        Label3.Text = "Selected Server: " & serverName

        ' Get the ping for the selected server
        Dim ping As Integer = GetServerPing(serverName)

        ' Update the label to display the ping
        Label3.Text = "Ping: " & ping & "ms"

        ' Update the image based on the ping range
        UpdateImage(ping)
    End Sub

    Private Sub UpdateImage(ping As Integer)
        ' Update the image based on the ping value
        If ping <= 19 Then
            PictureBox2.Image = My.Resources.internet_6
        ElseIf ping <= 39 Then
            PictureBox2.Image = My.Resources.internet_5
        ElseIf ping <= 59 Then
            PictureBox2.Image = My.Resources.internet_4
        ElseIf ping <= 79 Then
            PictureBox2.Image = My.Resources.internet_3
        ElseIf ping <= 99 Then
            PictureBox2.Image = My.Resources.internet_2
        ElseIf ping <= 100 Then
            PictureBox2.Image = My.Resources.internet_max
        End If
    End Sub

    Private Function GetServerPing(serverName As String) As Integer
        ' Perform the necessary steps to ping the server and retrieve the ping value
        ' Replace this with your actual code to ping the server and get the ping value
        ' You can use the serverName parameter to determine which server to ping

        ' For demonstration purposes, let's assume a random ping value between 0 and 200
        Dim random As New Random()
        Dim ping As Integer = random.Next(0, 201)

        Return ping
    End Function

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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub pictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        ' Set the VPN server details
        Dim vpnServer As String = "usny2-auto-udp.ptoserver.com"
        Dim usernamePath As String = "C:\z1g Apps\z1g VPN\username.txt"
        Dim passwordPath As String = "C:\z1g Apps\z1g VPN\password.txt"

        ' Read the username from the text file
        Dim username As String = ReadTextFile(usernamePath)

        ' Read the password from the text file
        Dim password As String = ReadTextFile(passwordPath)

        ' Connect to the VPN server (implementation depends on your VPN library or API)
        Dim isConnected As Boolean = ConnectToVpnServer(vpnServer, username, password)

        If isConnected Then
            ' VPN connection successful
            Label4.Visible = True
            ' Other actions you want to perform when connected
        Else
            ' VPN connection failed
            ' Handle the failure scenario (e.g., show an error message)
        End If
    End Sub

    Private Function ReadTextFile(filePath As String) As String
        ' Read the contents of a text file and return the content as a string
        ' Replace this with your actual implementation or use a file reading library of your choice
        ' Return the file contents as a string

        ' Example implementation:
        Dim fileContent As String = System.IO.File.ReadAllText(filePath)
        Return fileContent
    End Function

    Private Function ConnectToVpnServer(vpnServer As String, username As String, password As String) As Boolean
        ' Implementation of connecting to the VPN server using your VPN library or API
        ' Replace this with your actual implementation
        ' Return True if the connection is successful, False otherwise
        ' Example:
        ' YourVpnLibrary.Connect(vpnServer, username, password)
        ' Return YourVpnLibrary.IsConnected()
        ' Note: The actual implementation may vary depending on the VPN library or API you are using

        ' For testing purposes, assume the connection is successful
        Return True
    End Function
End Class