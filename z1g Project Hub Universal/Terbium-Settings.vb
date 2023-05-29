Imports System.Runtime.InteropServices

Public Class Terbium_Settings
    Private Sub Terbium_Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HT_CAPTION As Integer = &H2

    <DllImport("user32.dll")>
    Private Shared Function SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As Integer
    End Function

    <DllImport("user32.dll")>
    Private Shared Function ReleaseCapture() As Boolean
    End Function

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        If My.Computer.FileSystem.FileExists("C:/z1g apps/Terbium/Data/verconf.DAT") Then
            My.Computer.FileSystem.DeleteFile("C:/z1g apps/Terbium/Data/verconf.DAT")
            Dim g As New System.IO.StreamWriter("C:/z1g apps/Terbium/Data/verconf.DAT")
            g.WriteLine("Version = CloudFlare")
            g.Close()
        Else
            Console.WriteLine("File doesn't exist Skipping...")
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If My.Computer.FileSystem.FileExists("C:/z1g apps/Terbium/Data/verconf.DAT") Then
            My.Computer.FileSystem.DeleteFile("C:/z1g apps/Terbium/Data/verconf.DAT")
            Dim g As New System.IO.StreamWriter("C:/z1g apps/Terbium/Data/verconf.DAT")
            g.WriteLine("Version = CloudFlare")
            g.Close()
        Else
            Console.WriteLine("File doesn't exist Skipping...")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If My.Computer.FileSystem.FileExists("C:/z1g apps/Terbium/Data/userconf.DAT") Then
            My.Computer.FileSystem.DeleteFile("C:/z1g apps/Terbium/Data/userconf.DAT")
        Else
            Console.WriteLine("File doesn't exist Skipping...")
        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        If My.Computer.FileSystem.FileExists("C:/z1g apps/Terbium/Data/verconf.DAT") Then
            My.Computer.FileSystem.DeleteFile("C:/z1g apps/Terbium/Data/verconf.DAT")
        Else
            Console.WriteLine("File doesn't exist Skipping...")
        End If
    End Sub
End Class