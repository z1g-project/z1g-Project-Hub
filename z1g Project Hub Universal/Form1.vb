Imports System.Windows
Imports System.Net.Http

Public Class Form1
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
End Class
