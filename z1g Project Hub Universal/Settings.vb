Imports System.Diagnostics.CodeAnalysis
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Status

Public Class Settings
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        FolderBrowserDialog1.InitialDirectory = My.Settings.savelocation
        FolderBrowserDialog1.ShowDialog()
        If DialogResult.OK Then
            ComboBox1.Text = FolderBrowserDialog1.SelectedPath
            ComboBox1.Items.Add(FolderBrowserDialog1.SelectedPath)
            My.Settings.savelocation = FolderBrowserDialog1.SelectedPath
            My.Settings.Save()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FolderBrowserDialog2.InitialDirectory = My.Settings.applocation
        FolderBrowserDialog2.ShowDialog()
        If DialogResult.OK Then
            ComboBox2.Text = FolderBrowserDialog2.SelectedPath
            ComboBox2.Items.Add(FolderBrowserDialog2.SelectedPath)
            My.Settings.applocation = FolderBrowserDialog2.SelectedPath
            My.Settings.Save()
        End If
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        ComboBox1.Text = My.Settings.savelocation
        ComboBox2.Text = My.Settings.applocation
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Panel1.Visible = True
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Panel1.Visible = True
        Panel2.Visible = True
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Panel1.Visible = True
        Panel2.Visible = True
        Panel3.Visible = True
        Panel4.Visible = False
        Panel5.Visible = False
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Panel1.Visible = True
        Panel2.Visible = True
        Panel3.Visible = True
        Panel4.Visible = True
        Panel5.Visible = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Button4.Text = "Restart" Then
            Updater.Show()
            Form3.Hide()
            beta.Hide()
            Tutorial.Hide()
            Me.Hide()
        Else
            Timer1.Start()
            Button4.Enabled = False
            PictureBox1.Image = My.Resources.WindowsLoading
        End If
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
                PictureBox1.Image = My.Resources.z1g
                Label16.Text = "Your up to date!"
                Button3.Enabled = True
            Else
                PictureBox1.Image = My.Resources.z1g
                Label16.Text = "Restart the z1g Project Hub to update!"
                Button4.Text = "Restart"
                Button4.Visible = True
                Timer2.Start()
            End If
            Timer1.Stop()
            ProgressBar1.Value = 0
            Button4.Enabled = True
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Panel1.Visible = True
        Panel2.Visible = True
        Panel3.Visible = True
        Panel4.Visible = True
        Panel5.Visible = True
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        ProgressBar3.Increment(1)
        If ProgressBar3.Value = 100 Then
            Timer2.Stop()
            notifengine.Show()
            notifengine.Label48.Text = "Update is ready"
            notifengine.Label47.Text = "Visit Settings to finish the update"
        End If
    End Sub
End Class