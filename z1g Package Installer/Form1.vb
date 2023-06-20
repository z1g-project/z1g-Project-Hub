Imports System.IO
Imports System.IO.Compression
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
        ' Check if the application is run for the first time
        If Not IsFileAssociationSet(".z1a") Then
            ' Associate the .z1a file extension with your application
            SetFileAssociation(".z1a", "z1g Package Installer", Application.ExecutablePath, "C:\Users\Public\z1g-project\z1g-package-installer.exe", "C:\Users\Public\z1g-project\z1g-package-installer.ico")
        End If
    End Sub

    Private Sub ButtonInstall_Click(sender As Object, e As EventArgs) Handles ButtonInstall.Click
        ' Rest of your installation code here
        ' ...
    End Sub

    ' Helper method to check if the file association is set
    Private Function IsFileAssociationSet(extension As String) As Boolean
        Dim progId As String = GetProgIdByExtension(extension)
        Return Not String.IsNullOrEmpty(progId)
    End Function

    ' Helper method to get the ProgID associated with a file extension
    Private Function GetProgIdByExtension(extension As String) As String
        Dim regKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(extension)
        If regKey IsNot Nothing Then
            Dim progId As String = regKey.GetValue(String.Empty)?.ToString()
            regKey.Close()
            Return progId
        End If
        Return Nothing
    End Function

    ' Helper method to set the file association
    Private Sub SetFileAssociation(extension As String, description As String, exePath As String, openWithExePath As String, iconPath As String)
        ' Set the ProgID
        Dim progId As String = $"{Application.ProductName}.File"
        Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(progId, Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)?.SetValue(String.Empty, description)

        ' Set the default icon
        Dim defaultIconKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey($"{progId}\DefaultIcon", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
        defaultIconKey?.SetValue(String.Empty, $"{iconPath},1")
        defaultIconKey?.Close()

        ' Set the shell open command
        Dim openCommandKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey($"{progId}\shell\open\command", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
        openCommandKey?.SetValue(String.Empty, $"\""{openWithExePath}\"" ""%1""")
        openCommandKey?.Close()

        ' Set the file extension association
        Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(extension, Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)?.SetValue(String.Empty, progId)
    End Sub

    Private Sub panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub
End Class
