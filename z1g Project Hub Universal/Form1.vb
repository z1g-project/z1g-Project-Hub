Imports System.Windows
Imports System.Net.Http
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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        PictureBox2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(5)
        If ProgressBar1.Value = 50 Then
            PictureBox2.Visible = True
            Label3.Visible = True
            Label4.Visible = True
        End If
        If ProgressBar1.Value = 100 Then
            Timer1.Stop()
            If My.Computer.FileSystem.FileExists(My.Settings.savelocation + "acciscreated.dat") Then
                Form3.Show()
                Me.Hide()
            Else
                If My.Computer.FileSystem.FileExists("C:/Users/Public/z1g-project/migrated.Dat") Then
                    welcomeback.Show()
                    Me.Hide()
                Else
                    ' Nothing Happens lol
                End If
                Form2.Show()
                Me.Hide()
            End If
        End If
    End Sub

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub
End Class
