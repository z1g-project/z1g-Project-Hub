Imports System.IO.Compression
Imports System.Reflection.Emit
Imports System.Threading

Public Class Form1
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim selectedValue As String = ComboBox1.SelectedItem.ToString()

        Select Case selectedValue
            Case "v1.2.5 (Stable)"
                Button2.Text = "Downloading..."
                My.Computer.FileSystem.CreateDirectory("C:\Users\Public\z1g-project\")
                My.Computer.FileSystem.CreateDirectory("C:\Users\Public\z1g-project\dotnet\")
                My.Computer.Network.DownloadFile("https://github.com/z1g-project/z1g-Project-Hub/releases/download/1.2.5/z1g.Hub.v1.2.5.zip", "C:\z1g Apps\z1g Installer\update.zip")
                My.Computer.Network.DownloadFile("https://github.com/z1g-project/z1g-Project-Hub/releases/download/1.2.5/dotnet-sdk-6.0.408-win-x64.zip", "C:\z1g Apps\z1g Installer\dotnet.zip")
                My.Computer.Network.DownloadFile("https://github.com/z1g-project/z1g-Project-Hub/releases/download/1.2.5/dotnet-sdk-6.0.408-win-x64.zip", "C:\z1g Apps\z1g Installer\dotnet-pkg.zip")
                Button2.Text = "Extracting Files..."
                ZipFile.ExtractToDirectory("C:\z1g Apps\z1g Installer\update.zip", "C:\z1g Apps\z1g Installer\")
                ZipFile.ExtractToDirectory("C:\z1g Apps\z1g Installer\dotnet.zip", "C:\z1g Apps\z1g Installer\dotnet\")
                ZipFile.ExtractToDirectory("C:\z1g Apps\z1g Installer\dotnet-pkg.zip", "C:\Users\Public\z1g-project\dotnet\")
                Button2.Text = "Creating Shortcuts..."
                MsgBox("Unable to Create a desktop & startmenu Shortcut: Error Access Denied to cdn.z1g-project.repl.co/z1g-hub/client/shortcut.lnk")
                Button2.Text = "Launching..."
                Me.Cursor = Cursors.AppStarting
                Process.Start("C:\Users\Public\z1g-project\z1g-project-hub-universal.exe")
                Me.Cursor = Cursors.Default
                Me.Close()
            Case "v1.2.0u (LTS) [Recommended]"
                Button2.Text = "Downloading..."
                My.Computer.FileSystem.CreateDirectory("C:\Users\Public\z1g-project\")
                My.Computer.FileSystem.CreateDirectory("C:\Users\Public\z1g-project\dotnet\")
                My.Computer.Network.DownloadFile("https://github.com/z1g-project/z1g-Project-Hub/releases/download/1.2.0/z1g-hub.zip", "C:\Users\Public\z1g-project\z1g-hub.zip")
                My.Computer.Network.DownloadFile("https://github.com/z1g-project/z1g-Project-Hub/releases/download/1.2.0/dotnet-sdk-6.0.408-win-x64.zip", "C:\Users\Public\z1g-project\dotnet.zip")
                Button2.Text = "Installing z1g Hub"
                ZipFile.ExtractToDirectory("C:\Users\Public\z1g-project\z1g-hub.zip", "C:\Users\Public\z1g-project\")
                ZipFile.ExtractToDirectory("C:\Users\Public\z1g-project\dotnet.zip", "C:\Users\Public\z1g-project\dotnet\")
                Button2.Text = "Creating Shortcuts..."
                MsgBox("Unable to Create a desktop & startmenu Shortcut: Error Access Denied to cdn.z1g-project.repl.co/z1g-hub/client/shortcut.lnk")
                Button2.Text = "Launching..."
                Me.Cursor = Cursors.AppStarting
                Process.Start("C:\Users\Public\z1g-project\z1g-project-hub-universal.exe")
                Me.Cursor = Cursors.Default
                Me.Close()
            Case "v1.2.0 (Stable)"
                Button2.Text = "Downloading..."
                Thread.Sleep(5000)
                Button2.Text = "Error: 401 Download Failed"
                MsgBox("Error 401: Unable to fetch files from: cdn.z1g-project.repl.co Try again Later")
            Case Else
                Button2.Enabled = False
                MsgBox("Unable to Process your request: There is not current download avalible for your selected version")
        End Select
    End Sub
End Class
