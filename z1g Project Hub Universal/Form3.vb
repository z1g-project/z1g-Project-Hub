Imports System.Net.Http
Imports System.Reflection.Emit
Imports Newtonsoft.Json.Linq
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Status

Public Class Form3
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Tutorial.Show()
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click
        Tutorial.Show()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        beta.Show()
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click
        beta.Show()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Panel3.Visible = True
        Panel4.Visible = True
        Panel5.Visible = False
        Panel7.Visible = False
        Label9.Text = "App Manager"
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Panel3.Visible = True
        Panel4.Visible = True
        Panel5.Visible = False
        Panel7.Visible = False
        Label9.Text = "App Manager"
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Panel3.Visible = True
        Panel4.Visible = True
        Panel5.Visible = True
        Panel7.Visible = True
        Panel6.Visible = True
        Label9.Text = "Feed [Beta]"
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        Panel3.Visible = True
        Panel4.Visible = True
        Panel5.Visible = True
        Panel7.Visible = True
        Panel6.Visible = True
        Label9.Text = "Feed [Beta]"
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Panel3.Visible = True
        Panel4.Visible = False
        Panel5.Visible = False
        Panel7.Visible = False
        Label9.Text = "Home"
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Panel3.Visible = True
        Panel4.Visible = True
        Panel5.Visible = False
        Panel7.Visible = False
        Label9.Text = "App Manager"
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Panel3.Visible = True
        Panel4.Visible = True
        Panel5.Visible = True
        Panel6.Visible = False
        Panel7.Visible = False
        Label9.Text = "Account Manager"
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Panel3.Visible = True
        Panel4.Visible = True
        Panel5.Visible = True
        Panel6.Visible = True
        Panel7.Visible = True
        Label9.Text = "Feed [Beta]"
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label32.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        Panel6.Visible = False
        Panel7.Visible = False
        Dim getuser As New System.IO.StreamReader("C:\Users\Public\z1g-project\username.dat")
        Label2.Text = getuser.ReadToEnd
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form2.Show()
        Panel6.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim getpassword As New System.IO.StreamReader("C:\Users\Public\z1g-project\password.dat")
        TextBox2.Text = getpassword.ReadToEnd

        If TextBox2.Text = getpassword.ReadToEnd Then
            Label31.Visible = True
        Else
            Panel6.Visible = True
            Label43.Text = My.Computer.Name

            Dim strHostName As String = System.Net.Dns.GetHostName()
            Dim hostEntry As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)

            ' Find the first IPv4 address in the AddressList
            Dim ipAddress As System.Net.IPAddress = hostEntry.AddressList.FirstOrDefault(Function(a) a.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork)

            If ipAddress IsNot Nothing Then
                Dim strIPAddress As String = ipAddress.ToString()
                Label44.Text = strIPAddress
            Else
                Label44.Text = "No IPv4 address found"
            End If

            Label45.Text = DateTime.Now.ToString("HH:mm:ss MM/dd/yyyy")
        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Button6.Enabled = False
        Label43.Text = My.Computer.Name

        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim hostEntry As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)

        ' Find the first IPv4 address in the AddressList
        Dim ipAddress As System.Net.IPAddress = hostEntry.AddressList.FirstOrDefault(Function(a) a.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork)

        If ipAddress IsNot Nothing Then
            Dim strIPAddress As String = ipAddress.ToString()
            Label44.Text = strIPAddress
        Else
            Label44.Text = "No IPv4 address found"
        End If

        Label45.Text = DateTime.Now.ToString("HH:mm:ss MM/dd/yyyy")
        Button6.Enabled = True
    End Sub

    Private Async Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            Button7.Enabled = False
            Using client As New HttpClient()
                ' Make a request to the CDN URL and retrieve the article data
                Dim response As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/welcome.json")

                ' Check if the request was successful
                If response.IsSuccessStatusCode Then
                    ' Read the response content as a string
                    Dim articleData As String = Await response.Content.ReadAsStringAsync()

                    ' Parse the article data (assuming it's in JSON format)
                    Dim article As JObject = JObject.Parse(articleData)

                    ' Extract the required data from the article object
                    Dim imageUrl As String = article("image").ToString()
                    Dim title As String = article("title").ToString()
                    Dim description As String = article("description").ToString()
                    Dim datePublished As String = article("datePublished").ToString()
                    Dim source As String = article("source").ToString()

                    ' Display the data in the appropriate controls
                    PictureBox12.Load(imageUrl)
                    Label49.Text = title
                    Label50.Text = description
                    Label51.Text = datePublished
                    Label52.Text = source
                    Button7.Enabled = True
                Else
                    ' Handle the case when the request fails
                    MessageBox.Show("Failed to retrieve the article data.")
                    Button7.Enabled = True
                End If
            End Using
        Catch ex As Exception
            ' Handle any exceptions that occur during the process
            MessageBox.Show("An error occurred: " & ex.Message)
            Button7.Enabled = True
        End Try
    End Sub
End Class