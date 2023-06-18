Imports System.Diagnostics.CodeAnalysis
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Status
Imports System.Net.Http
Imports System.IO
Imports System.IO.Compression
Imports System.Runtime.InteropServices

Public Class Settings
    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HT_CAPTION As Integer = &H2

    <DllImport("user32.dll")>
    Private Shared Function SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As Integer
    End Function

    <DllImport("user32.dll")>
    Private Shared Function ReleaseCapture() As Boolean
    End Function

    Private ReadOnly httpClient As HttpClient = New HttpClient()

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

    Private Async Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(10)
        If ProgressBar1.Value = 100 Then
            Dim response As HttpResponseMessage = Await httpClient.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/client/currentversion.txt")
            Dim newestVersion As String = Await response.Content.ReadAsStringAsync()
            Dim currentVersion As String = Application.ProductVersion

            If newestVersion.Contains(currentVersion) Then
                PictureBox1.Image = My.Resources.z1g
                Label16.Text = "You're up to date!"
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Timer1.Start()
        ProgressBar1.Value = 0
        PictureBox1.Image = My.Resources.WindowsLoading
        Label16.Text = "Checking for Updates..."
        Button4.Enabled = False
    End Sub

    Private Sub Settings_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Directory.Delete(My.Settings.applocation)
        MsgBox("Your cache located in: " + My.Settings.applocation + " has been cleared. z1g Hub will now restart to apply the changes.", MsgBoxStyle.Information, "Cache Cleared")
        Process.Start(My.Settings.applocation + "z1g-project-hub-universal.exe")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim saveFileDialog As SaveFileDialog = New SaveFileDialog()
        saveFileDialog.Filter = "ZIP files (*.zip)|*.zip"
        saveFileDialog.FileName = "z1gData.zip"
        saveFileDialog.InitialDirectory = "C:\"

        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            Dim sourceFolder As String = My.Settings.applocation
            Dim destinationZipFile As String = saveFileDialog.FileName
            ZipFile.CreateFromDirectory(sourceFolder, destinationZipFile)
            MessageBox.Show("Successfully Exported Cache to: " & destinationZipFile)
        End If
    End Sub

    Private Sub button5_Click(sender As Object, e As EventArgs) Handles button5.Click
        Dim formWidth As Integer = Integer.Parse(textBox1.Text)
        Dim formHeight As Integer = Integer.Parse(textBox2.Text)

        My.Settings.FormWidth = formWidth
        My.Settings.FormHeight = formHeight
        My.Settings.Save()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Unchecked Then
            ' Set the value of your setting to "CenterScreen" when CheckBox is checked
            ' Replace "YourSetting" with the actual setting name or identifier
            My.Settings.windowPosition = "Manual"
            My.Settings.Save()
        Else
            ' Set the value of your setting to another value when CheckBox is unchecked
            ' Replace "YourSetting" with the actual setting name or identifier
            My.Settings.windowPosition = "CenterScreen"
            My.Settings.Save()
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim formWidth As Integer = Integer.Parse("1073")
        Dim formHeight As Integer = Integer.Parse("688")

        My.Settings.formWidth = formWidth
        My.Settings.formHeight = formHeight
        My.Settings.Save()
        textBox1.Text = formWidth
        textBox2.Text = formHeight
    End Sub
End Class