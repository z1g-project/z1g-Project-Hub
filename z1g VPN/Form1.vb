Imports System.Runtime.InteropServices

Public Class Form1
    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HT_CAPTION As Integer = &H2

    <DllImport("user32.dll")>
    Private Shared Function SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As Integer
    End Function

    <DllImport("user32.dll")>
    Private Shared Function ReleaseCapture() As Boolean
    End Function

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://minkvpn.com")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Process.Start("https://minkvpn.com/signup")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Process.Start("https://minkvpn.com/reset")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
        Me.Hide()
        Dim emailsave As New System.IO.StreamWriter("C:\z1g Apps\z1g VPN\email.dat")
        emailsave.WriteLine(TextBox1.Text)
        emailsave.Close()
        Dim passwordsave As New System.IO.StreamWriter("C:\z1g Apps\z1g VPN\password.dat")
        passwordsave.WriteLine(TextBox2.Text)
        passwordsave.Close()
        Dim accountsave As New System.IO.StreamWriter("C:\z1g Apps\z1g VPN\account.dat")
        accountsave.WriteLine(TextBox1.Text)
        accountsave.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.FileExists("C:\z1g Apps\z1g VPN\account.dat") Then
            Me.Hide()
            Dim form2 As New Form2()
            form2.ShowDialog()
            Me.Close()
        Else
            ' Show an error message or take appropriate action
        End If
    End Sub
End Class
