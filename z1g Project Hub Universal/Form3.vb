Imports System.Net.Http
Imports System.Reflection.Emit
Imports Newtonsoft.Json.Linq
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Status
Imports System.IO.Compression

Public Class Form3
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Tutorial.Hide()
        Tutorial.Timer1.Start()
        Tutorial.Show()
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click
        Tutorial.Hide()
        Tutorial.Timer1.Start()
        Tutorial.Show()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        beta.Hide()
        beta.Show()
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click
        beta.Hide()
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

    Private Async Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Panel3.Visible = True
        Panel4.Visible = True
        Panel5.Visible = True
        Panel6.Visible = True
        Panel7.Visible = True
        Label9.Text = "Feed [Beta]"
        Try
            Button7.Enabled = False
            Using client As New HttpClient()
                ' Make a request to the CDN URL and retrieve the article data
                Dim response As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/welcome.json")
                Dim response2 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/tnnews.json")
                Dim response3 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/tnnews2.json")
                Dim response4 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/z1gnews.json")

                ' Check if the request was successful
                If response.IsSuccessStatusCode Then
                    ' Read the response content as a string
                    Dim articleData As String = Await response.Content.ReadAsStringAsync()

                    ' Parse the article data (assuming it's in JSON format)
                    Dim article As JObject = JObject.Parse(articleData)

                    ' Extract the required data from the article object
                    Dim imageUrl As String = String.Empty
                    If article.TryGetValue("image", imageUrl) Then
                        ' The "image" property exists, assign its value to the imageUrl variable
                        ' Set the ImageLocation property of PictureBox to the imageUrl
                        PictureBox12.ImageLocation = imageUrl
                    Else
                        ' The "image" property is missing, handle it accordingly
                        ' You might want to set a default image or display an error message
                        MessageBox.Show("Image URL Not Available.")
                        Button7.Enabled = True
                        Return
                    End If
                    Dim title As String = String.Empty
                    If article.TryGetValue("title", title) Then
                        ' The "title" property exists, assign its value to the title variable
                        ' Proceed with displaying the title
                        Label49.Text = title
                    Else
                        ' The "title" property is missing, handle it accordingly
                        ' You might want to set a default title or display an error message
                        Label49.Text = "Title Not Available"
                    End If

                    Dim description As String = String.Empty
                    If article.TryGetValue("description", description) Then
                        ' The "description" property exists, assign its value to the description variable
                        ' Proceed with displaying the description
                        Label50.Text = description
                    Else
                        ' The "description" property is missing, handle it accordingly
                        ' You might want to set a default description or display an error message
                        Label50.Text = "Description Not Available"
                    End If

                    Dim datePublished As String = String.Empty
                    If article.TryGetValue("datePublished", datePublished) Then
                        ' The "datePublished" property exists, assign its value to the datePublished variable
                        ' Proceed with displaying the datePublished
                        Label51.Text = datePublished
                    Else
                        ' The "datePublished" property is missing, handle it accordingly
                        ' You might want to set a default datePublished or display an error message
                        Label51.Text = "Date Not Available"
                    End If

                    Dim source As String = String.Empty
                    If article.TryGetValue("source", source) Then
                        ' The "source" property exists, assign its value to the source variable
                        ' Proceed with displaying the source
                        Label52.Text = source
                    Else
                        ' The "source" property is missing, handle it accordingly
                        ' You might want to set a default source or display an error message
                        Label52.Text = "Source Not Available"
                    End If


                    ' Display the data in the appropriate controls
                    PictureBox12.Load(imageUrl)
                    Label49.Text = title
                    Label50.Text = description
                    Label51.Text = "Released: " + datePublished
                    Label52.Text = "Source: " + source
                    Button7.Enabled = True
                Else
                    ' Handle the case when the request fails
                    MessageBox.Show("Failed to retrieve the article data.")
                    Button7.Enabled = True
                End If
                If response2.IsSuccessStatusCode Then
                    ' Read the response content as a string
                    Dim articleData2 As String = Await response2.Content.ReadAsStringAsync()

                    ' Parse the article data (assuming it's in JSON format)
                    Dim article2 As JObject = JObject.Parse(articleData2)

                    ' Extract the required data from the article object
                    Dim imageUrl2 As String = String.Empty
                    If article2.TryGetValue("image", imageUrl2) Then
                        ' The "image" property exists, assign its value to the imageUrl variable
                        ' Set the ImageLocation property of PictureBox to the imageUrl
                        PictureBox13.ImageLocation = imageUrl2
                    Else
                        ' The "image" property is missing, handle it accordingly
                        ' You might want to set a default image or display an error message
                        MessageBox.Show("Image URL Not Available.")
                        Button7.Enabled = True
                        Return
                    End If
                    Dim title2 As String = String.Empty
                    If article2.TryGetValue("title", title2) Then
                        ' The "title" property exists, assign its value to the title variable
                        ' Proceed with displaying the title
                        Label56.Text = title2
                    Else
                        ' The "title" property is missing, handle it accordingly
                        ' You might want to set a default title or display an error message
                        Label56.Text = "Title Not Available"
                    End If

                    Dim description2 As String = String.Empty
                    If article2.TryGetValue("description", description2) Then
                        ' The "description" property exists, assign its value to the description variable
                        ' Proceed with displaying the description
                        Label55.Text = description2
                    Else
                        ' The "description" property is missing, handle it accordingly
                        ' You might want to set a default description or display an error message
                        Label55.Text = "Description Not Available"
                    End If

                    Dim datePublished2 As String = String.Empty
                    If article2.TryGetValue("datePublished", datePublished2) Then
                        ' The "datePublished" property exists, assign its value to the datePublished variable
                        ' Proceed with displaying the datePublished
                        Label54.Text = "Released: " + datePublished2
                    Else
                        ' The "datePublished" property is missing, handle it accordingly
                        ' You might want to set a default datePublished or display an error message
                        Label54.Text = "Date Not Available"
                    End If

                    Dim source2 As String = String.Empty
                    If article2.TryGetValue("source", source2) Then
                        ' The "source" property exists, assign its value to the source variable
                        ' Proceed with displaying the source
                        Label53.Text = "Source: " + source2
                    Else
                        ' The "source" property is missing, handle it accordingly
                        ' You might want to set a default source or display an error message
                        Label53.Text = "Source Not Available"
                    End If


                    ' Display the data in the appropriate controls
                    PictureBox13.Load(imageUrl2)
                    Label56.Text = title2
                    Label55.Text = description2
                    Label54.Text = "Released: " + datePublished2
                    Label53.Text = "Source: " + source2
                    Button7.Enabled = True
                Else
                    ' Handle the case when the request fails
                    MessageBox.Show("Failed to retrieve the article data.")
                    Button7.Enabled = True
                End If
                If response3.IsSuccessStatusCode Then
                    ' Read the response content as a string
                    Dim articleData3 As String = Await response3.Content.ReadAsStringAsync()

                    ' Parse the article data (assuming it's in JSON format)
                    Dim article3 As JObject = JObject.Parse(articleData3)

                    ' Extract the required data from the article object
                    Dim imageUrl3 As String = String.Empty
                    If article3.TryGetValue("image", imageUrl3) Then
                        ' The "image" property exists, assign its value to the imageUrl variable
                        ' Set the ImageLocation property of PictureBox to the imageUrl
                        PictureBox14.ImageLocation = imageUrl3
                    Else
                        ' The "image" property is missing, handle it accordingly
                        ' You might want to set a default image or display an error message
                        MessageBox.Show("Image URL Not Available.")
                        Button7.Enabled = True
                        Return
                    End If
                    Dim title3 As String = String.Empty
                    If article3.TryGetValue("title", title3) Then
                        ' The "title" property exists, assign its value to the title variable
                        ' Proceed with displaying the title
                        Label60.Text = title3
                    Else
                        ' The "title" property is missing, handle it accordingly
                        ' You might want to set a default title or display an error message
                        Label60.Text = "Title Not Available"
                    End If

                    Dim description3 As String = String.Empty
                    If article3.TryGetValue("description", description3) Then
                        ' The "description" property exists, assign its value to the description variable
                        ' Proceed with displaying the description
                        Label59.Text = description3
                    Else
                        ' The "description" property is missing, handle it accordingly
                        ' You might want to set a default description or display an error message
                        Label59.Text = "Description Not Available"
                    End If

                    Dim datePublished3 As String = String.Empty
                    If article3.TryGetValue("datePublished", datePublished3) Then
                        ' The "datePublished" property exists, assign its value to the datePublished variable
                        ' Proceed with displaying the datePublished
                        Label58.Text = "Released: " + datePublished3
                    Else
                        ' The "datePublished" property is missing, handle it accordingly
                        ' You might want to set a default datePublished or display an error message
                        Label58.Text = "Date Not Available"
                    End If

                    Dim source3 As String = String.Empty
                    If article3.TryGetValue("source", source3) Then
                        ' The "source" property exists, assign its value to the source variable
                        ' Proceed with displaying the source
                        Label57.Text = "Source: " + source3
                    Else
                        ' The "source" property is missing, handle it accordingly
                        ' You might want to set a default source or display an error message
                        Label57.Text = "Source Not Available"
                    End If


                    ' Display the data in the appropriate controls
                    PictureBox14.Load(imageUrl3)
                    Label60.Text = title3
                    Label59.Text = description3
                    Label58.Text = "Released: " + datePublished3
                    Label57.Text = "Source: " + source3
                    Button7.Enabled = True
                Else
                    ' Handle the case when the request fails
                    MessageBox.Show("Failed to retrieve the article data.")
                    Button7.Enabled = True
                End If
                If response4.IsSuccessStatusCode Then
                    ' Read the response content as a string
                    Dim articleData4 As String = Await response3.Content.ReadAsStringAsync()

                    ' Parse the article data (assuming it's in JSON format)
                    Dim article4 As JObject = JObject.Parse(articleData4)

                    ' Extract the required data from the article object
                    Dim imageUrl4 As String = String.Empty
                    If article4.TryGetValue("image", imageUrl4) Then
                        ' The "image" property exists, assign its value to the imageUrl variable
                        ' Set the ImageLocation property of PictureBox to the imageUrl
                        PictureBox15.ImageLocation = imageUrl4
                    Else
                        ' The "image" property is missing, handle it accordingly
                        ' You might want to set a default image or display an error message
                        MessageBox.Show("Image URL Not Available.")
                        Button7.Enabled = True
                        Return
                    End If
                    Dim title4 As String = String.Empty
                    If article4.TryGetValue("title", title4) Then
                        ' The "title" property exists, assign its value to the title variable
                        ' Proceed with displaying the title
                        Label64.Text = title4
                    Else
                        ' The "title" property is missing, handle it accordingly
                        ' You might want to set a default title or display an error message
                        Label64.Text = "Title Not Available"
                    End If

                    Dim description4 As String = String.Empty
                    If article4.TryGetValue("description", description4) Then
                        ' The "description" property exists, assign its value to the description variable
                        ' Proceed with displaying the description
                        Label63.Text = description4
                    Else
                        ' The "description" property is missing, handle it accordingly
                        ' You might want to set a default description or display an error message
                        Label63.Text = "Description Not Available"
                    End If

                    Dim datePublished4 As String = String.Empty
                    If article4.TryGetValue("datePublished", datePublished4) Then
                        ' The "datePublished" property exists, assign its value to the datePublished variable
                        ' Proceed with displaying the datePublished
                        Label62.Text = "Released: " + datePublished4
                    Else
                        ' The "datePublished" property is missing, handle it accordingly
                        ' You might want to set a default datePublished or display an error message
                        Label62.Text = "Date Not Available"
                    End If

                    Dim source4 As String = String.Empty
                    If article4.TryGetValue("source", source4) Then
                        ' The "source" property exists, assign its value to the source variable
                        ' Proceed with displaying the source
                        Label61.Text = "Source: " + source4
                    Else
                        ' The "source" property is missing, handle it accordingly
                        ' You might want to set a default source or display an error message
                        Label61.Text = "Source Not Available"
                    End If


                    ' Display the data in the appropriate controls
                    PictureBox14.Load(imageUrl4)
                    Label64.Text = title4
                    Label63.Text = description4
                    Label62.Text = "Released: " + datePublished4
                    Label61.Text = "Source: " + source4
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

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label32.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        Panel6.Visible = False
        Panel7.Visible = False
        Dim getuser As New System.IO.StreamReader(My.Settings.savelocation + "username.dat")
        Label2.Text = getuser.ReadToEnd
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) 
        Form2.Show()
        Panel6.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) 
        Dim getpassword As New System.IO.StreamReader(My.Settings.savelocation + "password.dat")
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

    Private Sub Button6_Click(sender As Object, e As EventArgs) 
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

    Private Async Sub Button7_Click(sender As Object, e As EventArgs) 
        Try
            Button7.Enabled = False
            Using client As New HttpClient()
                ' Make a request to the CDN URL and retrieve the article data
                Dim response As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/welcome.json")
                Dim response2 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/tnnews.json")
                Dim response3 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/tnnews2.json")
                Dim response4 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/z1gnews.json")

                ' Check if the request was successful
                If response.IsSuccessStatusCode Then
                    ' Read the response content as a string
                    Dim articleData As String = Await response.Content.ReadAsStringAsync()

                    ' Parse the article data (assuming it's in JSON format)
                    Dim article As JObject = JObject.Parse(articleData)

                    ' Extract the required data from the article object
                    Dim imageUrl As String = String.Empty
                    If article.TryGetValue("image", imageUrl) Then
                        ' The "image" property exists, assign its value to the imageUrl variable
                        ' Set the ImageLocation property of PictureBox to the imageUrl
                        PictureBox12.ImageLocation = imageUrl
                    Else
                        ' The "image" property is missing, handle it accordingly
                        ' You might want to set a default image or display an error message
                        MessageBox.Show("Image URL Not Available.")
                        Button7.Enabled = True
                        Return
                    End If
                    Dim title As String = String.Empty
                    If article.TryGetValue("title", title) Then
                        ' The "title" property exists, assign its value to the title variable
                        ' Proceed with displaying the title
                        Label49.Text = title
                    Else
                        ' The "title" property is missing, handle it accordingly
                        ' You might want to set a default title or display an error message
                        Label49.Text = "Title Not Available"
                    End If

                    Dim description As String = String.Empty
                    If article.TryGetValue("description", description) Then
                        ' The "description" property exists, assign its value to the description variable
                        ' Proceed with displaying the description
                        Label50.Text = description
                    Else
                        ' The "description" property is missing, handle it accordingly
                        ' You might want to set a default description or display an error message
                        Label50.Text = "Description Not Available"
                    End If

                    Dim datePublished As String = String.Empty
                    If article.TryGetValue("datePublished", datePublished) Then
                        ' The "datePublished" property exists, assign its value to the datePublished variable
                        ' Proceed with displaying the datePublished
                        Label51.Text = datePublished
                    Else
                        ' The "datePublished" property is missing, handle it accordingly
                        ' You might want to set a default datePublished or display an error message
                        Label51.Text = "Date Not Available"
                    End If

                    Dim source As String = String.Empty
                    If article.TryGetValue("source", source) Then
                        ' The "source" property exists, assign its value to the source variable
                        ' Proceed with displaying the source
                        Label52.Text = source
                    Else
                        ' The "source" property is missing, handle it accordingly
                        ' You might want to set a default source or display an error message
                        Label52.Text = "Source Not Available"
                    End If


                    ' Display the data in the appropriate controls
                    PictureBox12.Load(imageUrl)
                    Label49.Text = title
                    Label50.Text = description
                    Label51.Text = "Released: " + datePublished
                    Label52.Text = "Source: " + source
                    Button7.Enabled = True
                Else
                    ' Handle the case when the request fails
                    MessageBox.Show("Failed to retrieve the article data.")
                    Button7.Enabled = True
                End If
                If response2.IsSuccessStatusCode Then
                    ' Read the response content as a string
                    Dim articleData2 As String = Await response2.Content.ReadAsStringAsync()

                    ' Parse the article data (assuming it's in JSON format)
                    Dim article2 As JObject = JObject.Parse(articleData2)

                    ' Extract the required data from the article object
                    Dim imageUrl2 As String = String.Empty
                    If article2.TryGetValue("image", imageUrl2) Then
                        ' The "image" property exists, assign its value to the imageUrl variable
                        ' Set the ImageLocation property of PictureBox to the imageUrl
                        PictureBox13.ImageLocation = imageUrl2
                    Else
                        ' The "image" property is missing, handle it accordingly
                        ' You might want to set a default image or display an error message
                        MessageBox.Show("Image URL Not Available.")
                        Button7.Enabled = True
                        Return
                    End If
                    Dim title2 As String = String.Empty
                    If article2.TryGetValue("title", title2) Then
                        ' The "title" property exists, assign its value to the title variable
                        ' Proceed with displaying the title
                        Label56.Text = title2
                    Else
                        ' The "title" property is missing, handle it accordingly
                        ' You might want to set a default title or display an error message
                        Label56.Text = "Title Not Available"
                    End If

                    Dim description2 As String = String.Empty
                    If article2.TryGetValue("description", description2) Then
                        ' The "description" property exists, assign its value to the description variable
                        ' Proceed with displaying the description
                        Label55.Text = description2
                    Else
                        ' The "description" property is missing, handle it accordingly
                        ' You might want to set a default description or display an error message
                        Label55.Text = "Description Not Available"
                    End If

                    Dim datePublished2 As String = String.Empty
                    If article2.TryGetValue("datePublished", datePublished2) Then
                        ' The "datePublished" property exists, assign its value to the datePublished variable
                        ' Proceed with displaying the datePublished
                        Label54.Text = "Released: " + datePublished2
                    Else
                        ' The "datePublished" property is missing, handle it accordingly
                        ' You might want to set a default datePublished or display an error message
                        Label54.Text = "Date Not Available"
                    End If

                    Dim source2 As String = String.Empty
                    If article2.TryGetValue("source", source2) Then
                        ' The "source" property exists, assign its value to the source variable
                        ' Proceed with displaying the source
                        Label53.Text = "Source: " + source2
                    Else
                        ' The "source" property is missing, handle it accordingly
                        ' You might want to set a default source or display an error message
                        Label53.Text = "Source Not Available"
                    End If


                    ' Display the data in the appropriate controls
                    PictureBox13.Load(imageUrl2)
                    Label56.Text = title2
                    Label55.Text = description2
                    Label54.Text = "Released: " + datePublished2
                    Label53.Text = "Source: " + source2
                    Button7.Enabled = True
                Else
                    ' Handle the case when the request fails
                    MessageBox.Show("Failed to retrieve the article data.")
                    Button7.Enabled = True
                End If
                If response3.IsSuccessStatusCode Then
                    ' Read the response content as a string
                    Dim articleData3 As String = Await response3.Content.ReadAsStringAsync()

                    ' Parse the article data (assuming it's in JSON format)
                    Dim article3 As JObject = JObject.Parse(articleData3)

                    ' Extract the required data from the article object
                    Dim imageUrl3 As String = String.Empty
                    If article3.TryGetValue("image", imageUrl3) Then
                        ' The "image" property exists, assign its value to the imageUrl variable
                        ' Set the ImageLocation property of PictureBox to the imageUrl
                        PictureBox14.ImageLocation = imageUrl3
                    Else
                        ' The "image" property is missing, handle it accordingly
                        ' You might want to set a default image or display an error message
                        MessageBox.Show("Image URL Not Available.")
                        Button7.Enabled = True
                        Return
                    End If
                    Dim title3 As String = String.Empty
                    If article3.TryGetValue("title", title3) Then
                        ' The "title" property exists, assign its value to the title variable
                        ' Proceed with displaying the title
                        Label60.Text = title3
                    Else
                        ' The "title" property is missing, handle it accordingly
                        ' You might want to set a default title or display an error message
                        Label60.Text = "Title Not Available"
                    End If

                    Dim description3 As String = String.Empty
                    If article3.TryGetValue("description", description3) Then
                        ' The "description" property exists, assign its value to the description variable
                        ' Proceed with displaying the description
                        Label59.Text = description3
                    Else
                        ' The "description" property is missing, handle it accordingly
                        ' You might want to set a default description or display an error message
                        Label59.Text = "Description Not Available"
                    End If

                    Dim datePublished3 As String = String.Empty
                    If article3.TryGetValue("datePublished", datePublished3) Then
                        ' The "datePublished" property exists, assign its value to the datePublished variable
                        ' Proceed with displaying the datePublished
                        Label58.Text = "Released: " + datePublished3
                    Else
                        ' The "datePublished" property is missing, handle it accordingly
                        ' You might want to set a default datePublished or display an error message
                        Label58.Text = "Date Not Available"
                    End If

                    Dim source3 As String = String.Empty
                    If article3.TryGetValue("source", source3) Then
                        ' The "source" property exists, assign its value to the source variable
                        ' Proceed with displaying the source
                        Label57.Text = "Source: " + source3
                    Else
                        ' The "source" property is missing, handle it accordingly
                        ' You might want to set a default source or display an error message
                        Label57.Text = "Source Not Available"
                    End If


                    ' Display the data in the appropriate controls
                    PictureBox14.Load(imageUrl3)
                    Label60.Text = title3
                    Label59.Text = description3
                    Label58.Text = "Released: " + datePublished3
                    Label57.Text = "Source: " + source3
                    Button7.Enabled = True
                Else
                    ' Handle the case when the request fails
                    MessageBox.Show("Failed to retrieve the article data.")
                    Button7.Enabled = True
                End If
                If response4.IsSuccessStatusCode Then
                    ' Read the response content as a string
                    Dim articleData4 As String = Await response3.Content.ReadAsStringAsync()

                    ' Parse the article data (assuming it's in JSON format)
                    Dim article4 As JObject = JObject.Parse(articleData4)

                    ' Extract the required data from the article object
                    Dim imageUrl4 As String = String.Empty
                    If article4.TryGetValue("image", imageUrl4) Then
                        ' The "image" property exists, assign its value to the imageUrl variable
                        ' Set the ImageLocation property of PictureBox to the imageUrl
                        PictureBox15.ImageLocation = imageUrl4
                    Else
                        ' The "image" property is missing, handle it accordingly
                        ' You might want to set a default image or display an error message
                        MessageBox.Show("Image URL Not Available.")
                        Button7.Enabled = True
                        Return
                    End If
                    Dim title4 As String = String.Empty
                    If article4.TryGetValue("title", title4) Then
                        ' The "title" property exists, assign its value to the title variable
                        ' Proceed with displaying the title
                        Label64.Text = title4
                    Else
                        ' The "title" property is missing, handle it accordingly
                        ' You might want to set a default title or display an error message
                        Label64.Text = "Title Not Available"
                    End If

                    Dim description4 As String = String.Empty
                    If article4.TryGetValue("description", description4) Then
                        ' The "description" property exists, assign its value to the description variable
                        ' Proceed with displaying the description
                        Label63.Text = description4
                    Else
                        ' The "description" property is missing, handle it accordingly
                        ' You might want to set a default description or display an error message
                        Label63.Text = "Description Not Available"
                    End If

                    Dim datePublished4 As String = String.Empty
                    If article4.TryGetValue("datePublished", datePublished4) Then
                        ' The "datePublished" property exists, assign its value to the datePublished variable
                        ' Proceed with displaying the datePublished
                        Label62.Text = "Released: " + datePublished4
                    Else
                        ' The "datePublished" property is missing, handle it accordingly
                        ' You might want to set a default datePublished or display an error message
                        Label62.Text = "Date Not Available"
                    End If

                    Dim source4 As String = String.Empty
                    If article4.TryGetValue("source", source4) Then
                        ' The "source" property exists, assign its value to the source variable
                        ' Proceed with displaying the source
                        Label61.Text = "Source: " + source4
                    Else
                        ' The "source" property is missing, handle it accordingly
                        ' You might want to set a default source or display an error message
                        Label61.Text = "Source Not Available"
                    End If


                    ' Display the data in the appropriate controls
                    PictureBox14.Load(imageUrl4)
                    Label64.Text = title4
                    Label63.Text = description4
                    Label62.Text = "Released: " + datePublished4
                    Label61.Text = "Source: " + source4
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

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Settings.Hide()
        Settings.Show()
    End Sub

    Private Sub Label25_Click(sender As Object, e As EventArgs) Handles Label25.Click
        'Blurred's Vault
        If My.Computer.FileSystem.FileExists("C:\z1g Apps\Blurreds Vault\Blurred's Vault.exe") Then
            Process.Start("C:\z1g Apps\Blurreds Vault\Blurred's Vault.exe")
        Else
            My.Computer.Network.DownloadFile("https://cdn.z1g-project.repl.co/z1g-hub/client/blurreds-vault.zip", "C:\z1g Apps\Blurreds Vault\blurreds-vault.zip")
            ZipFile.ExtractToDirectory("C:\z1g Apps\Blurreds Vault\blurreds-vault.zip", "C:\Users\Public\Blurreds Vault\")
            System.IO.Directory.CreateDirectory("C:\Users\Public\Blurreds Vault\")
            Process.Start("C:\z1g Apps\Blurreds Vault\Blurred's Vault.exe")
        End If
    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click
        'Blurred's Vault
        If My.Computer.FileSystem.FileExists("C:\z1g Apps\Blurreds Vault\Blurred's Vault.exe") Then
            Process.Start("C:\z1g Apps\Blurreds Vault\Blurred's Vault.exe")
        Else
            My.Computer.Network.DownloadFile("https://cdn.z1g-project.repl.co/z1g-hub/client/blurreds-vault.zip", "C:\z1g Apps\Blurreds Vault\blurreds-vault.zip")
            ZipFile.ExtractToDirectory("C:\z1g Apps\Blurreds Vault\blurreds-vault.zip", "C:\Users\Public\Blurreds Vault\")
            System.IO.Directory.CreateDirectory("C:\Users\Public\Blurreds Vault\")
            Process.Start("C:\z1g Apps\Blurreds Vault\Blurred's Vault.exe")
        End If
    End Sub

    Private Sub Label26_Click(sender As Object, e As EventArgs) Handles Label26.Click
        'BlurredX
        MsgBox("This product is not released yet. Check back soon!", MsgBoxStyle.Critical, "Download Unavalible")
    End Sub

    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click
        'BlurredX
        MsgBox("This product is not released yet. Check back soon!", MsgBoxStyle.Critical, "Download Unavalible")
    End Sub

    Private Sub Label24_Click(sender As Object, e As EventArgs) Handles Label24.Click
        'BruhProx
        MsgBox("This product is not released yet. Check back soon!", MsgBoxStyle.Critical, "Download Unavalible")
    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        'BruhProx
        MsgBox("This product is not released yet. Check back soon!", MsgBoxStyle.Critical, "Download Unavalible")
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        'Terbium
        If My.Computer.FileSystem.FileExists("C:\z1g Apps\Terbium\Terbium.exe") Then
            Process.Start("C:\z1g Apps\Terbium\Terbium.exe")
        Else
            My.Computer.Network.DownloadFile("https://cdn.z1g-project.repl.co/z1g-hub/client/Terbium-bootstrap.exe", "C:\z1g Apps\Terbium\Terbium-bootstrap.exe")
            Process.Start("C:\z1g Apps\Terbium\Terbium-bootstrap.exe")
        End If
    End Sub

    Private Sub Label21_Click(sender As Object, e As EventArgs) Handles Label21.Click
        'Terbium
        If My.Computer.FileSystem.FileExists("C:\z1g Apps\Terbium\Terbium.exe") Then
            Process.Start("C:\z1g Apps\Terbium\Terbium.exe")
        Else
            My.Computer.Network.DownloadFile("https://cdn.z1g-project.repl.co/z1g-hub/client/Terbium-bootstrap.exe", "C:\z1g Apps\Terbium\Terbium-bootstrap.exe")
            Process.Start("C:\z1g Apps\Terbium\Terbium-bootstrap.exe")
        End If
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        'Velocity
        If My.Computer.FileSystem.FileExists("C:\z1g Apps\Velocity\velocity.exe") Then
            Process.Start("C:\z1g Apps\Velocity\velocity.exe")
        Else
            My.Computer.Network.DownloadFile("https://cdn.z1g-project.repl.co/z1g-hub/client/velocity-bootstrap.exe", "C:\z1g Apps\Velocity\velocity-bootstrap.exe")
            Process.Start("C:\z1g Apps\Velocity\velocity-bootstrap.exe")
        End If
    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click
        'Velocity
        If My.Computer.FileSystem.FileExists("C:\z1g Apps\Velocity\velocity.exe") Then
            Process.Start("C:\z1g Apps\Velocity\velocity.exe")
        Else
            My.Computer.Network.DownloadFile("https://cdn.z1g-project.repl.co/z1g-hub/client/velocity-bootstrap.exe", "C:\z1g Apps\Velocity\velocity-bootstrap.exe")
            Process.Start("C:\z1g Apps\Velocity\velocity-bootstrap.exe")
        End If
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        'z1g X
        MsgBox("This product is not released yet. Check back soon!", MsgBoxStyle.Critical, "Download Unavalible")
    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click
        'z1g X
        MsgBox("This product is not released yet. Check back soon!", MsgBoxStyle.Critical, "Download Unavalible")
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        'z1g VPN
        MsgBox("This product is not released yet. Check back soon!", MsgBoxStyle.Critical, "Download Unavalible")
    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click
        'z1g VPN
        MsgBox("This product is not released yet. Check back soon!", MsgBoxStyle.Critical, "Download Unavalible")
    End Sub

    Private Sub PictureBox16_Click(sender As Object, e As EventArgs) Handles PictureBox16.Click
        'Soon
        MsgBox("This product is not announced yet. Check back soon!", MsgBoxStyle.Critical, "Download Unavalible")
    End Sub

    Private Sub Label65_Click(sender As Object, e As EventArgs) Handles Label65.Click
        'Soon
        MsgBox("This product is not announced yet. Check back soon!", MsgBoxStyle.Critical, "Download Unavalible")
    End Sub
End Class