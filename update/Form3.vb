Imports System.IO.Compression
Imports System.IO

Public Class Form3
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel3.Visible = False
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(1)
        If ProgressBar1.Value = 25 Then
            If My.Computer.FileSystem.FileExists("C:/Users/Public/z1g-project/temp/client.zip") Then
                My.Computer.FileSystem.DeleteFile("C:/Users/Public/z1g-project/temp/client.zip")
                My.Computer.Network.DownloadFile("https://cdn.z1g-project.repl.co/z1g-hub/client/v1.2.5/client.zip", "C:/Users/Public/z1g-project/temp/client.zip")
                ZipFile.ExtractToDirectory("C:/Users/Public/z1g-project/temp/client.zip", "C:/Users/Public/z1g-project/")
                My.Computer.FileSystem.DeleteFile("C:/Users/Public/z1g-project/temp/client.zip")
            Else
                My.Computer.Network.DownloadFile("https://cdn.z1g-project.repl.co/z1g-hub/client/v1.2.5/z1g-project-hub.zip", "C:/Users/Public/z1g-project/temp/client.zip")
                ZipFile.ExtractToDirectory("C:/Users/Public/z1g-project/temp/client.zip", "C:/Users/Public/z1g-project/")
                My.Computer.FileSystem.DeleteFile("C:/Users/Public/z1g-project/temp/client.zip")
            End If
        End If
            If ProgressBar1.Value = 50 Then
            Label2.Text = "Installing..."
            Try
                My.Computer.Network.DownloadFile("https://cdn.z1g-project.repl.co/z1g-hub/client/z1g-Project-Hub.lnk", "C:\ProgramData\Microsoft\Windows\Start Menu\Programs\z1g Project Hub.lnk")
                Console.WriteLine("File downloaded successfully.")
            Catch ex As Exception
                MsgBox("Error Creating Startmenu Shortcut. Error Code: " & ex.Message)
            End Try
            Panel3.Visible = True
        End If
        If ProgressBar1.Value = 100 Then
            Timer1.Stop()
            Process.Start("C:/Users/Public/z1g-project/z1g-project-hub.exe")
            Me.Close()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub
End Class