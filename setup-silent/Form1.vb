Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.ComTypes
Imports System.Text

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://cdn.z1g-project.repl.co/z1g-hub/client/currentversion.txt")
        Dim response As System.Net.HttpWebResponse = request.GetResponse

        Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream)

        Dim newestversion As String = sr.ReadToEnd
        Dim currentversion As String = Application.ProductVersion
        If newestversion.Contains(currentversion) Then
            If My.Computer.FileSystem.FileExists("C:/Users/Public/z1g-project/z1g-project-hub.exe") Then
                My.Computer.Network.DownloadFile("https://cdn.z1g-project.repl.co/z1g-hub/archives/1.2.0/z1g-project-hub.zip", "C:/Users/Public/z1g-project/z1g-project-hub.exe")
            Else

            End If
            Dim shortcutPath As String = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) & "\z1g-project-hub.lnk"
            Dim targetPath As String = "C:/Users/Public/z1g-project/z1g Project Hub Universal.exe"

            Dim shellLink As New ShellLink()
                shellLink.TargetPath = targetPath
            shellLink.WorkingDirectory = "C:/Users/Public/z1g-project/"

            shellLink.Description = "The all new and Reformed z1g Hub App!"
            shellLink.Save(shortcutPath)
            Process.Start("C:/Users/Public/z1g-project/z1g Project Hub Universal.exe")
            Me.Close()
            Else
                Me.Close()
            My.Computer.FileSystem.DeleteFile("C:\Users\Public\z1g-project\update.exe")
            My.Computer.Network.DownloadFile("https://cdn.z1g-project.repl.co/z1g-hub/latest/update.exe", "C:\Users\Public\z1g-project\update.exe")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Public Class ShellLink
        <ComImport>
        <Guid("00021401-0000-0000-C000-000000000046")>
        Public Class ShellLinkCoClass
        End Class

        <ComImport>
        <InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
        <Guid("000214F9-0000-0000-C000-000000000046")>
        Public Interface IShellLink
            Sub GetPath(<Out> pszFile As StringBuilder, cchMaxPath As Integer, <[In], Out> pfd As IntPtr, fFlags As Integer)
            Sub GetIDList(ppidl As IntPtr)
            Sub SetIDList(pidl As IntPtr)
            Sub GetDescription(<Out> pszName As StringBuilder, cchMaxName As Integer)
            Sub SetDescription(pszName As String)
            Sub GetWorkingDirectory(<Out> pszDir As StringBuilder, cchMaxPath As Integer)
            Sub SetWorkingDirectory(pszDir As String)
            Sub GetArguments(<Out> pszArgs As StringBuilder, cchMaxPath As Integer)
            Sub SetArguments(pszArgs As String)
            Sub GetHotKey(pwHotkey As Short)
            Sub SetHotKey(wHotkey As Short)
            Sub GetShowCmd(piShowCmd As Integer)
            Sub SetShowCmd(iShowCmd As Integer)
            Sub GetIconLocation(<Out> pszIconPath As StringBuilder, cchIconPath As Integer, <Out> piIcon As Integer)
            Sub SetIconLocation(pszIconPath As String, iIcon As Integer)
            Sub SetRelativePath(pszPathRel As String, dwReserved As Integer)
            Sub Resolve(hwnd As IntPtr, fFlags As Integer)
            Sub SetPath(pszFile As String)
        End Interface

        Public Property TargetPath As String
        Public Property WorkingDirectory As String
        Public Property Description As String

        Public Sub Save(shortcutPath As String)
            Dim shellLink As IShellLink = DirectCast(New ShellLinkCoClass(), IShellLink)

            shellLink.SetPath(TargetPath)
            shellLink.SetWorkingDirectory(WorkingDirectory)
            shellLink.SetDescription(Description)

            Dim persistFile As IPersistFile = DirectCast(shellLink, IPersistFile)
            persistFile.Save(shortcutPath, True)
        End Sub
    End Class
End Class
