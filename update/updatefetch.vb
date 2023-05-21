Imports System.Reflection.Emit
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar

Public Class updatefetch
    Private Sub updatefetch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(10)
        If ProgressBar1.Value = 100 Then
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://cdn.z1g-project.repl.co/z1g-hub/client/currentversion.txt")
            Dim response As System.Net.HttpWebResponse = request.GetResponse

            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream)

            Dim newestversion As String = sr.ReadToEnd
            Dim currentversion As String = Application.ProductVersion
            If newestversion.Contains(currentversion) Then
                form2.show
                Me.Hide()
                Form1.Hide()
            Else
                Me.Close()
                My.Computer.FileSystem.DeleteFile("C:/z1g apps/temp/update.exe")
                My.Computer.Network.DownloadFile("https://cdn.z1g-project.repl.co/z1g-hub/latest/update.exe", "C:/z1g apps/temp/update.exe")
            End If
            Timer1.Stop()
            ProgressBar1.Value = 0
        End If
    End Sub
End Class