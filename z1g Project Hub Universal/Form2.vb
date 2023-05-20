Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        System.IO.Directory.CreateDirectory("C:\Users\Public\z1g-project\")
        Dim acciscreated As New System.IO.StreamWriter("C:\Users\Public\z1g-project\acciscreated.dat")
        acciscreated.Write("account.iscreated=true")
        acciscreated.Close()
        Dim username As New System.IO.StreamWriter("C:\Users\Public\z1g-project\username.dat")
        username.WriteLine(TextBox1.Text)
        username.Close()
        Dim password As New System.IO.StreamWriter("C:\Users\Public\z1g-project\password.dat")
        password.WriteLine(TextBox2.Text)
        password.Close()
        Form3.Label2.Text = TextBox1.Text
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class