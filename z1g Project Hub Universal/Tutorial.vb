Public Class Tutorial
    Private Sub Tutorial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        panel1.visible = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(2)
        If ProgressBar1.Value = 100 Then
            FadeOutLabel("Bienvenido al centro del proyecto z1g")
        ElseIf ProgressBar1.Value = 200 Then
            FadeOutLabel("Bienvenue dans le centre de projets z1g")
        ElseIf ProgressBar1.Value = 300 Then
            FadeOutLabel("欢迎来到 z1g 项目中心")
        ElseIf ProgressBar1.Value = 400 Then
            FadeOutLabel("Willkommen im z1g Project Hub")
        ElseIf ProgressBar1.Value = 500 Then
            FadeOutLabel("Welcome to the z1g Project Hub")
            ProgressBar1.Value = 0
        End If
    End Sub

    Private Sub FadeOutLabel(newText As String)
        fadeTimer.Enabled = False ' Disable the fade timer while fading

        ' Fade out the label
        For opacityValue As Double = 1 To 0 Step -0.1
            Label1.ForeColor = Color.FromArgb(CInt(opacityValue * 255), Label1.ForeColor)
            System.Threading.Thread.Sleep(50) ' Add a small delay for each step to control the fade speed
            Application.DoEvents() ' Allow the UI to update
        Next

        ' Set the new text and fade in
        Label1.Text = newText

        ' Fade in the label
        For opacityValue As Double = 0 To 1 Step 0.1
            Label1.ForeColor = Color.FromArgb(CInt(opacityValue * 255), Label1.ForeColor)
            System.Threading.Thread.Sleep(50)
            Application.DoEvents()
        Next

        fadeTimer.Enabled = True ' Re-enable the fade timer
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        panel1.visible = True
    End Sub
End Class