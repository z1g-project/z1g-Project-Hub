Imports System.IO.Compression
Imports IWshRuntimeLibrary
Imports System.IO
Imports System.ComponentModel.DataAnnotations

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
                If My.Computer.FileSystem.DirectoryExists("C:/Users/Public/z1g-project/") Then
                    My.Computer.FileSystem.RenameDirectory("C:/Users/Public/z1g-project", "C:/Users/Public/z1g-project.old")
                    My.Computer.FileSystem.CreateDirectory("C:/Users/Public/z1g-project")
                Else
                    My.Computer.FileSystem.CreateDirectory("C:/Users/Public/z1g-project")
                End If
                My.Computer.FileSystem.DeleteFile("C:/Users/Public/z1g-project/temp/client.zip")
                My.Computer.Network.DownloadFile("https://dl2.johnglynn2.repl.co/v1.2.5/client.zip", "C:/Users/Public/z1g-project/temp/client.zip")
                ZipFile.ExtractToDirectory("C:/Users/Public/z1g-project/temp/client.zip", "C:/Users/Public/z1g-project/")
                My.Computer.FileSystem.DeleteFile("C:/Users/Public/z1g-project/temp/client.zip")
            Else
                If My.Computer.FileSystem.DirectoryExists("C:/Users/Public/z1g-project/") Then
                    My.Computer.FileSystem.RenameDirectory("C:/Users/Public/z1g-project", "C:/Users/Public/z1g-project.old")
                    My.Computer.FileSystem.CreateDirectory("C:/Users/Public/z1g-project")
                Else
                    My.Computer.FileSystem.CreateDirectory("C:/Users/Public/z1g-project")
                End If
                My.Computer.Network.DownloadFile("https://dl2.johnglynn2.repl.co/v1.2.5/client.zip", "C:/Users/Public/z1g-project/temp/client.zip")
                ZipFile.ExtractToDirectory("C:/Users/Public/z1g-project/temp/client.zip", "C:/Users/Public/z1g-project/")
                My.Computer.FileSystem.DeleteFile("C:/Users/Public/z1g-project/temp/client.zip")
            End If
        End If
        If ProgressBar1.Value = 50 Then
            Label2.Text = "Installing..."
            Try
                'Skip over Legacy Download Shortcut Feature My.Computer.Network.DownloadFile("https://cdn.z1g-project.repl.co/z1g-hub/client/z1g-Project-Hub.lnk", "C:\ProgramData\Microsoft\Windows\Start Menu\Programs\z1g Project Hub.lnk")
                Dim shortcutPath As String = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) & "\z1g-project-hub.lnk"
                Dim targetPath As String = "C:/Users/Public/z1g-project/z1g Project Hub Universal.exe"

                Dim shell As New WshShell()
                Dim shortcut As IWshShortcut = DirectCast(shell.CreateShortcut(shortcutPath), IWshShortcut)
                shortcut.TargetPath = targetPath
                shortcut.WorkingDirectory = "C:/Users/Public/z1g-project/"
                shortcut.Description = "The all new and Reformed z1g Hub App!"
                shortcut.Save()
                Console.WriteLine("File downloaded successfully.")
            Catch ex As Exception
                MsgBox("Error Creating Startmenu Shortcut. Error Code: " & ex.Message)
            End Try
            Panel3.Visible = True
            If My.Computer.FileSystem.DirectoryExists("C:/Users/Public/z1g-project.old/") Then
                My.Computer.FileSystem.MoveFile("C:/Users/Public/z1g-project.old/acciscreated.dat", "C:/Users/Public/z1g-project/acciscreated.dat")
                My.Computer.FileSystem.MoveFile("C:/Users/Public/z1g-project.old/username.dat", "C:/Users/Public/z1g-project/username.dat")
                My.Computer.FileSystem.MoveFile("C:/Users/Public/z1g-project.old/password.dat", "C:/Users/Public/z1g-project/password.dat")
                Dim updateexists As New System.IO.StreamWriter("C:/Users/Public/z1g-project/migrated.Dat")
                updateexists.WriteLine("isMigrated=True")
                updateexists.Close()
            Else
                Console.WriteLine("No OLD Directory was found. Skiping Migration")
            End If
        End If
        If ProgressBar1.Value = 100 Then
            Timer1.Stop()
            Process.Start("C:/Users/Public/z1g-project/z1g Project Hub Universal.exe")
            Me.Close()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub
End Class