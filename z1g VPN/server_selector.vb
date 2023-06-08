Imports System.IO
Imports System.Net.NetworkInformation
Imports System.Reflection
Imports System.Windows.Forms

Public Class server_selector
    Private Sub server_selector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim websiteUrl As String = "google.com"
        Dim pingThreshold As Integer = 20 ' Range of 20 for each image
        Dim minPing As Integer = 20 ' Minimum ping for the first image
        Dim maxPing As Integer = 120 ' Maximum ping for the last image
        Dim imagePathBase As String = "C:\z1g Apps\z1g VPN\resources\internet" ' Base path for the image files

        Try
            Using ping As New Ping()
                Dim reply As PingReply = ping.Send(websiteUrl)

                If reply.Status = IPStatus.Success Then
                    Dim pingTime As Integer = CInt(reply.RoundtripTime)

                    If pingTime >= minPing AndAlso pingTime <= maxPing Then
                        Dim imageNumber As Integer = (pingTime - minPing) \ pingThreshold
                        Dim imageName As String = imagePathBase & (imageNumber + 1).ToString() & ".png"
                        PictureBox3.Image = Image.FromFile(imageName)
                    Else
                        ' Ping is outside the desired range
                        ' Perform some other action or set a different image
                        ' PictureBox3.Image = ...
                    End If
                Else
                    ' Ping failed, handle the error accordingly
                    ' PictureBox3.Image = ... ' Set an image indicating failure
                End If
            End Using
        Catch ex As Exception
            MsgBox("An error has occurred: " & ex.Message)
        End Try
    End Sub
End Class
