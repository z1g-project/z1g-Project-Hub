Imports System.IO.Compression
Imports System.Runtime.InteropServices
Imports System.Threading

Public Class Form1

    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HT_CAPTION As Integer = &H2

    <DllImport("user32.dll")>
    Private Shared Function SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As Integer
    End Function

    <DllImport("user32.dll")>
    Private Shared Function ReleaseCapture() As Boolean
    End Function

    ' Resize Code

    Private Const HTBOTTOMRIGHT As Integer = 17
    Private Const WM_NCHITTEST As Integer = &H84
    Private Const RESIZE_HANDLE_SIZE As Integer = 10

    Private isResizing As Boolean = False
    Private lastMousePos As Point

    Protected Overrides Sub WndProc(ByRef m As Message)
        MyBase.WndProc(m)

        If m.Msg = WM_NCHITTEST AndAlso isResizing Then
            Dim screenCoords As Point = New Point(m.LParam.ToInt32())
            Dim clientCoords As Point = PointToClient(screenCoords)

            If clientCoords.X >= ClientSize.Width - RESIZE_HANDLE_SIZE AndAlso clientCoords.Y >= ClientSize.Height - RESIZE_HANDLE_SIZE Then
                m.Result = New IntPtr(HTBOTTOMRIGHT)
            End If
        End If
    End Sub

    Private Sub panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel4.MouseDown
        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub

    ' Resize Handlers

    Private Sub panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel4.MouseMove
        If e.Button = MouseButtons.Left AndAlso Not isResizing Then
            lastMousePos = e.Location
            isResizing = True
        End If
    End Sub

    Private Sub panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel4.MouseUp
        isResizing = False
    End Sub

    Private Sub panel1_MouseMove_Resize(sender As Object, e As MouseEventArgs) Handles Panel4.MouseMove
        If isResizing Then
            Dim widthChange = e.X - lastMousePos.X
            Dim heightChange = e.Y - lastMousePos.Y

            Width += widthChange
            Height += heightChange

            lastMousePos = e.Location
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        timer1.start
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment("10")
        If ProgressBar1.Value = 100 Then
            If My.Computer.FileSystem.FileExists("C:/z1g-apps/Terbium/Terbium.zip") Then
                My.Computer.FileSystem.DeleteFile("C:/z1g-apps/Terbium/Terbium.zip")
                My.Computer.Network.DownloadFile("https://cdn.z1g-project.repl.co/z1g-hub/client/apps/terbium/client.zip", "C:/z1g-apps/Terbium/Terbium.zip")
                ZipFile.ExtractToDirectory("C:/z1g-apps/Terbium/Terbium.zip", "C:/z1g-apps/Terbium/")
                My.Computer.FileSystem.DeleteFile("C:/z1g-apps/Terbium/Terbium.zip")
            Else
                My.Computer.Network.DownloadFile("https://cdn.z1g-project.repl.co/z1g-hub/client/apps/terbium/client.zip", "C:/z1g-apps/Terbium/Terbium.zip")
                ZipFile.ExtractToDirectory("C:/z1g-apps/Terbium/Terbium.zip", "C:/z1g-apps/Terbium/")
                My.Computer.FileSystem.DeleteFile("C:/z1g-apps/Terbium/Terbium.zip")
            End If
        End If
    End Sub
End Class

