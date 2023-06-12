Imports System.Configuration
Imports System.IO
Imports System.Net.NetworkInformation
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class server_selector
    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HT_CAPTION As Integer = &H2

    <DllImport("user32.dll")>
    Private Shared Function SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As Integer
    End Function

    <DllImport("user32.dll")>
    Private Shared Function ReleaseCapture() As Boolean
    End Function

    Private Sub ServerSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load the image in PictureBox3 from resources
        PictureBox3.Image = My.Resources.internet_6

        Form2.WindowState = FormWindowState.Minimized

        ' Perform the ping and update the label
        PerformPing("usny2-auto-udp.ptoserver.com")
        PerformPing2("usca2-auto-udp.ptoserver.com")
        PerformPing3("usfl2-auto-tcp.ptoserver.com")
        PerformPing4("mx2-auto-tcp.ptoserver.com")
        PerformPing5("ca2-auto-tcp.ptoserver.com")
        PerformPing6("vancouver.ca")
        PerformPing7("ukl2-auto-tcp.ptoserver.com")
    End Sub

    Private Sub panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
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
                    Label6.Text = "Ping: " & pingTime & "ms"
                    Label3.Text = "Ping: " & pingTime & "ms"

                    ' Load the appropriate image based on the ping range
                    If pingTime >= 0 AndAlso pingTime <= 49 Then
                        PictureBox3.Image = My.Resources.internet_6
                        PictureBox2.Image = My.Resources.internet_6
                    ElseIf pingTime >= 50 AndAlso pingTime <= 79 Then
                        PictureBox3.Image = My.Resources.internet_5
                        PictureBox2.Image = My.Resources.internet_5
                    ElseIf pingTime >= 80 AndAlso pingTime <= 100 Then
                        PictureBox3.Image = My.Resources.internet_4
                        PictureBox2.Image = My.Resources.internet_4
                    ElseIf pingTime >= 100 AndAlso pingTime <= 119 Then
                        PictureBox3.Image = My.Resources.internet_3
                        PictureBox2.Image = My.Resources.internet_3
                    ElseIf pingTime >= 120 AndAlso pingTime <= 149 Then
                        PictureBox3.Image = My.Resources.internet_2
                        PictureBox2.Image = My.Resources.internet_2
                    ElseIf pingTime = 150 Then
                        PictureBox3.Image = My.Resources.internet_max
                        PictureBox2.Image = My.Resources.internet_max
                    End If
                Else
                    ' If ping failed, display an error message
                    Label6.Text = "Ping Failed"
                    PictureBox3.Image = My.Resources.internet_none ' Clear the image
                    PictureBox2.Image = My.Resources.internet_none
                End If
            End Using
        Catch ex As PingException
            ' If an exception occurs during the ping, display the error message
            Label6.Text = "Ping Exception: " & ex.Message
            PictureBox3.Image = My.Resources.internet_none ' Clear the image
            PictureBox2.Image = My.Resources.internet_none
        End Try
    End Sub

    Private Sub PerformPing2(targetHost As String)
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
                    Label8.Text = "Ping: " & pingTime & "ms"

                    ' Load the appropriate image based on the ping range
                    If pingTime >= 0 AndAlso pingTime <= 49 Then
                        PictureBox4.Image = My.Resources.internet_6
                    ElseIf pingTime >= 50 AndAlso pingTime <= 79 Then
                        PictureBox4.Image = My.Resources.internet_5
                    ElseIf pingTime >= 80 AndAlso pingTime <= 100 Then
                        PictureBox4.Image = My.Resources.internet_4
                    ElseIf pingTime >= 100 AndAlso pingTime <= 119 Then
                        PictureBox4.Image = My.Resources.internet_3
                    ElseIf pingTime >= 120 AndAlso pingTime <= 149 Then
                        PictureBox4.Image = My.Resources.internet_2
                    ElseIf pingTime = 150 Then
                        PictureBox4.Image = My.Resources.internet_max
                    End If
                Else
                    ' If ping failed, display an error message
                    Label8.Text = "Ping Failed"
                    PictureBox4.Image = My.Resources.internet_none ' Clear the image
                End If
            End Using
        Catch ex As PingException
            ' If an exception occurs during the ping, display the error message
            Label8.Text = "Ping Exception: " & ex.Message
            PictureBox4.Image = My.Resources.internet_none ' Clear the image
        End Try
    End Sub

    Private Sub PerformPing3(targetHost As String)
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
                    Label11.Text = "Ping: " & pingTime & "ms"

                    ' Load the appropriate image based on the ping range
                    If pingTime >= 0 AndAlso pingTime <= 49 Then
                        PictureBox5.Image = My.Resources.internet_6
                    ElseIf pingTime >= 50 AndAlso pingTime <= 79 Then
                        PictureBox5.Image = My.Resources.internet_5
                    ElseIf pingTime >= 80 AndAlso pingTime <= 100 Then
                        PictureBox5.Image = My.Resources.internet_4
                    ElseIf pingTime >= 100 AndAlso pingTime <= 119 Then
                        PictureBox5.Image = My.Resources.internet_3
                    ElseIf pingTime >= 120 AndAlso pingTime <= 149 Then
                        PictureBox5.Image = My.Resources.internet_2
                    ElseIf pingTime = 150 Then
                        PictureBox5.Image = My.Resources.internet_max
                    End If
                Else
                    ' If ping failed, display an error message
                    Label11.Text = "Ping Failed"
                    PictureBox5.Image = My.Resources.internet_none ' Clear the image
                End If
            End Using
        Catch ex As PingException
            ' If an exception occurs during the ping, display the error message
            Label11.Text = "Ping Exception: " & ex.Message
            PictureBox5.Image = My.Resources.internet_none ' Clear the image
        End Try
    End Sub

    Private Sub PerformPing4(targetHost As String)
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
                    Label13.Text = "Ping: " & pingTime & "ms"

                    ' Load the appropriate image based on the ping range
                    If pingTime >= 0 AndAlso pingTime <= 49 Then
                        PictureBox6.Image = My.Resources.internet_6
                    ElseIf pingTime >= 50 AndAlso pingTime <= 79 Then
                        PictureBox6.Image = My.Resources.internet_5
                    ElseIf pingTime >= 80 AndAlso pingTime <= 100 Then
                        PictureBox6.Image = My.Resources.internet_4
                    ElseIf pingTime >= 100 AndAlso pingTime <= 119 Then
                        PictureBox6.Image = My.Resources.internet_3
                    ElseIf pingTime >= 120 AndAlso pingTime <= 149 Then
                        PictureBox6.Image = My.Resources.internet_2
                    ElseIf pingTime = 150 Then
                        PictureBox6.Image = My.Resources.internet_max
                    End If
                Else
                    ' If ping failed, display an error message
                    Label13.Text = "Ping Failed"
                    PictureBox6.Image = My.Resources.internet_none ' Clear the image
                End If
            End Using
        Catch ex As PingException
            ' If an exception occurs during the ping, display the error message
            Label13.Text = "Ping Exception: " & ex.Message
            PictureBox5.Image = My.Resources.internet_none ' Clear the image
        End Try
    End Sub

    Private Sub PerformPing5(targetHost As String)
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
                    Label15.Text = "Ping: " & pingTime & "ms"

                    ' Load the appropriate image based on the ping range
                    If pingTime >= 0 AndAlso pingTime <= 49 Then
                        PictureBox7.Image = My.Resources.internet_6
                    ElseIf pingTime >= 50 AndAlso pingTime <= 79 Then
                        PictureBox7.Image = My.Resources.internet_5
                    ElseIf pingTime >= 80 AndAlso pingTime <= 100 Then
                        PictureBox7.Image = My.Resources.internet_4
                    ElseIf pingTime >= 100 AndAlso pingTime <= 119 Then
                        PictureBox7.Image = My.Resources.internet_3
                    ElseIf pingTime >= 120 AndAlso pingTime <= 149 Then
                        PictureBox7.Image = My.Resources.internet_2
                    ElseIf pingTime = 150 Then
                        PictureBox7.Image = My.Resources.internet_max
                    End If
                Else
                    ' If ping failed, display an error message
                    Label15.Text = "Ping Failed"
                    PictureBox7.Image = My.Resources.internet_none ' Clear the image
                End If
            End Using
        Catch ex As PingException
            ' If an exception occurs during the ping, display the error message
            Label15.Text = "Ping Exception: " & ex.Message
            PictureBox7.Image = My.Resources.internet_none ' Clear the image
        End Try
    End Sub

    Private Sub PerformPing6(targetHost As String)
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
                    Label17.Text = "Ping: " & pingTime & "ms"

                    ' Load the appropriate image based on the ping range
                    If pingTime >= 0 AndAlso pingTime <= 49 Then
                        PictureBox8.Image = My.Resources.internet_6
                    ElseIf pingTime >= 50 AndAlso pingTime <= 79 Then
                        PictureBox8.Image = My.Resources.internet_5
                    ElseIf pingTime >= 80 AndAlso pingTime <= 100 Then
                        PictureBox8.Image = My.Resources.internet_4
                    ElseIf pingTime >= 100 AndAlso pingTime <= 119 Then
                        PictureBox8.Image = My.Resources.internet_3
                    ElseIf pingTime >= 120 AndAlso pingTime <= 149 Then
                        PictureBox8.Image = My.Resources.internet_2
                    ElseIf pingTime = 150 Then
                        PictureBox8.Image = My.Resources.internet_max
                    End If
                Else
                    ' If ping failed, display an error message
                    Label17.Text = "Ping Failed"
                    PictureBox8.Image = My.Resources.internet_none ' Clear the image
                End If
            End Using
        Catch ex As PingException
            ' If an exception occurs during the ping, display the error message
            Label17.Text = "Ping Exception: " & ex.Message
            PictureBox5.Image = My.Resources.internet_none ' Clear the image
        End Try
    End Sub

    Private Sub PerformPing7(targetHost As String)
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
                    Label19.Text = "Ping: " & pingTime & "ms"

                    ' Load the appropriate image based on the ping range
                    If pingTime >= 0 AndAlso pingTime <= 49 Then
                        PictureBox9.Image = My.Resources.internet_6
                    ElseIf pingTime >= 50 AndAlso pingTime <= 79 Then
                        PictureBox9.Image = My.Resources.internet_5
                    ElseIf pingTime >= 80 AndAlso pingTime <= 100 Then
                        PictureBox9.Image = My.Resources.internet_4
                    ElseIf pingTime >= 100 AndAlso pingTime <= 119 Then
                        PictureBox9.Image = My.Resources.internet_3
                    ElseIf pingTime >= 120 AndAlso pingTime <= 149 Then
                        PictureBox9.Image = My.Resources.internet_2
                    ElseIf pingTime = 150 Then
                        PictureBox9.Image = My.Resources.internet_max
                    End If
                Else
                    ' If ping failed, display an error message
                    Label19.Text = "Ping Failed"
                    PictureBox9.Image = My.Resources.internet_none ' Clear the image
                End If
            End Using
        Catch ex As PingException
            ' If an exception occurs during the ping, display the error message
            Label19.Text = "Ping Exception: " & ex.Message
            PictureBox5.Image = My.Resources.internet_none ' Clear the image
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Cursor = Cursors.WaitCursor
        PerformPing("usny2-auto-udp.ptoserver.com")
        PerformPing2("usca2-auto-udp.ptoserver.com")
        PerformPing3("usfl2-auto-tcp.ptoserver.com")
        PerformPing4("mx2-auto-tcp.ptoserver.com")
        PerformPing5("ca2-auto-tcp.ptoserver.com")
        PerformPing6("vancouver.ca")
        PerformPing7("ukl2-auto-tcp.ptoserver.com")
        Me.Cursor = Cursors.Default
    End Sub

    Private selectedServer As String = ""

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        ' Handle the click event for PictureBox3
        SelectServer("US New York")
        SaveSelectedServer(selectedServer)
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        ' Handle the click event for Label5
        SelectServer("US New York")
        SaveSelectedServer(selectedServer)
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        ' Handle the click event for Label6
        SelectServer("US New York")
        SaveSelectedServer(selectedServer)
    End Sub

    Private Sub SelectServer(serverName As String)
        ' Update the label to display the selected server
        Label5.Text = "Selected Server: " & serverName

        ' Get the ping for the selected server
        'Dim ping As Integer = GetPing(serverName)

        ' Update the label to display the ping
        'Label6.Text = "Ping: " & pingtime & "ms"

        ' Update the image based on the ping range
        'PictureBox3.ImageLocation = (ping)
        PerformPing("usny2-auto-udp.ptoserver.com")
    End Sub

    Private Sub SaveSelectedServer(serverName As String)
        ' Get the application settings
        Dim settings = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings.Settings

        ' Update the selected server value in the application settings
        settings("SelectedServer").Value = serverName

        ' Save the changes
        ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).Save(ConfigurationSaveMode.Modified)
    End Sub
End Class
