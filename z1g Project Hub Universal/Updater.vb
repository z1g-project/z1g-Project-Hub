Public Class Updater
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Updater_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        Panel2.Visible = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(1)
        If ProgressBar1.Value = 50 Then
            Label2.Text = "Extracting Files..."
            Panel2.Visible = True
            If My.Computer.FileSystem.FileExists("C:\z1g apps\temp\update.exe") Then
                My.Computer.FileSystem.DeleteFile("C:\z1g apps\temp\update.exe")
                My.Computer.Network.DownloadFile("https://cdn.z1g-project.repl.co/z1g-hub/latest/update.exe", "C:\z1g apps\temp\update.exe")
            Else
                My.Computer.Network.DownloadFile("https://cdn.z1g-project.repl.co/z1g-hub/latest/update.exe", "C:\z1g apps\temp\update.exe")
            End If
        End If
            If ProgressBar1.Value = 100 Then
            Process.Start("C:\z1g apps\temp\update.exe")
            Me.Close()
        End If
    End Sub
End Class