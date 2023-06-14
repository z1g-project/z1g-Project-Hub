Imports System.Net.Http
Imports System.Reflection.Emit
Imports Newtonsoft.Json.Linq
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Status
Imports System.IO.Compression
Imports System.Runtime.InteropServices

Public Class Form3
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HT_CAPTION As Integer = &H2

    <DllImport("user32.dll")>
    Private Shared Function SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As Integer
    End Function

    <DllImport("user32.dll")>
    Private Shared Function ReleaseCapture() As Boolean
    End Function

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

    Private Async Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Panel3.Visible = True
        Panel4.Visible = True
        Panel5.Visible = True
        Panel6.Visible = True
        Panel7.Visible = True
        Panel8.Visible = False
        Panel11.Visible = False
        Label9.Text = "Feed [Beta]"
        Try
            Button7.Enabled = False
            Using client As New HttpClient()
                ' Make a request to the CDN URL and retrieve the article data
                Dim response As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/welcome.json")
                Dim response2 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/tnnews.json")
                Dim response3 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/tnnews2.json")
                Dim response4 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/z1gnews.json")
                'Page 2 Requests
                Dim response5 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/z1gnews2.json")
                Dim response6 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/z1gnews3.json")
                Dim response7 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/tnnews3.json")
                Dim response8 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/googlenews.json")

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
                        articleimg3.ImageLocation = imageUrl3
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
                    articleimg3.Load(imageUrl3)
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
                    Dim articleData4 As String = Await response4.Content.ReadAsStringAsync()

                    ' Parse the article data (assuming it's in JSON format)
                    Dim article4 As JObject = JObject.Parse(articleData4)

                    ' Extract the required data from the article object
                    Dim imageUrl4 As String = String.Empty
                    If article4.TryGetValue("image", imageUrl4) Then
                        ' The "image" property exists, assign its value to the imageUrl variable
                        ' Set the ImageLocation property of PictureBox to the imageUrl
                        articleimg4.ImageLocation = imageUrl4
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
                    articleimg4.Load(imageUrl4)
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
                'Page 2 responses
                If response5.IsSuccessStatusCode Then
                    ' Read the response content as a string
                    Dim articleData5 As String = Await response5.Content.ReadAsStringAsync()

                    ' Parse the article data (assuming it's in JSON format)
                    Dim article5 As JObject = JObject.Parse(articleData5)

                    ' Extract the required data from the article object
                    Dim imageUrl5 As String = String.Empty
                    If article5.TryGetValue("image", imageUrl5) Then
                        ' The "image" property exists, assign its value to the imageUrl variable
                        ' Set the ImageLocation property of PictureBox to the imageUrl
                        PictureBox14.ImageLocation = imageUrl5
                    Else
                        ' The "image" property is missing, handle it accordingly
                        ' You might want to set a default image or display an error message
                        MessageBox.Show("Image URL Not Available.")
                        Button7.Enabled = True
                        Return
                    End If
                    Dim title5 As String = String.Empty
                    If article5.TryGetValue("title", title5) Then
                        ' The "title" property exists, assign its value to the title variable
                        ' Proceed with displaying the title
                        Label69.Text = title5
                    Else
                        ' The "title" property is missing, handle it accordingly
                        ' You might want to set a default title or display an error message
                        Label69.Text = "Title Not Available"
                    End If

                    Dim description5 As String = String.Empty
                    If article5.TryGetValue("description", description5) Then
                        ' The "description" property exists, assign its value to the description variable
                        ' Proceed with displaying the description
                        Label68.Text = description5
                    Else
                        ' The "description" property is missing, handle it accordingly
                        ' You might want to set a default description or display an error message
                        Label68.Text = "Description Not Available"
                    End If

                    Dim datePublished5 As String = String.Empty
                    If article5.TryGetValue("datePublished", datePublished5) Then
                        ' The "datePublished" property exists, assign its value to the datePublished variable
                        ' Proceed with displaying the datePublished
                        Label67.Text = "Released: " + datePublished5
                    Else
                        ' The "datePublished" property is missing, handle it accordingly
                        ' You might want to set a default datePublished or display an error message
                        Label67.Text = "Date Not Available"
                    End If

                    Dim source5 As String = String.Empty
                    If article5.TryGetValue("source", source5) Then
                        ' The "source" property exists, assign its value to the source variable
                        ' Proceed with displaying the source
                        Label66.Text = "Source: " + source5
                    Else
                        ' The "source" property is missing, handle it accordingly
                        ' You might want to set a default source or display an error message
                        Label66.Text = "Source Not Available"
                    End If


                    ' Display the data in the appropriate controls
                    PictureBox14.Load(imageUrl5)
                    Label69.Text = title5
                    Label68.Text = description5
                    Label67.Text = "Released: " + datePublished5
                    Label66.Text = "Source: " + source5
                    Button7.Enabled = True
                Else
                    ' Handle the case when the request fails
                    MessageBox.Show("Failed to retrieve the article data.")
                    Button7.Enabled = True
                End If
                If response6.IsSuccessStatusCode Then
                    ' Read the response content as a string
                    Dim articleData6 As String = Await response6.Content.ReadAsStringAsync()

                    ' Parse the article data (assuming it's in JSON format)
                    Dim article6 As JObject = JObject.Parse(articleData6)

                    ' Extract the required data from the article object
                    Dim imageUrl6 As String = String.Empty
                    If article6.TryGetValue("image", imageUrl6) Then
                        ' The "image" property exists, assign its value to the imageUrl variable
                        ' Set the ImageLocation property of PictureBox to the imageUrl
                        PictureBox15.ImageLocation = imageUrl6
                    Else
                        ' The "image" property is missing, handle it accordingly
                        ' You might want to set a default image or display an error message
                        MessageBox.Show("Image URL Not Available.")
                        Button7.Enabled = True
                        Return
                    End If
                    Dim title6 As String = String.Empty
                    If article6.TryGetValue("title", title6) Then
                        ' The "title" property exists, assign its value to the title variable
                        ' Proceed with displaying the title
                        Label73.Text = title6
                    Else
                        ' The "title" property is missing, handle it accordingly
                        ' You might want to set a default title or display an error message
                        Label73.Text = "Title Not Available"
                    End If

                    Dim description6 As String = String.Empty
                    If article6.TryGetValue("description", description6) Then
                        ' The "description" property exists, assign its value to the description variable
                        ' Proceed with displaying the description
                        Label72.Text = description6
                    Else
                        ' The "description" property is missing, handle it accordingly
                        ' You might want to set a default description or display an error message
                        Label72.Text = "Description Not Available"
                    End If

                    Dim datePublished6 As String = String.Empty
                    If article6.TryGetValue("datePublished", datePublished6) Then
                        ' The "datePublished" property exists, assign its value to the datePublished variable
                        ' Proceed with displaying the datePublished
                        Label71.Text = "Released: " + datePublished6
                    Else
                        ' The "datePublished" property is missing, handle it accordingly
                        ' You might want to set a default datePublished or display an error message
                        Label71.Text = "Date Not Available"
                    End If

                    Dim source6 As String = String.Empty
                    If article6.TryGetValue("source", source6) Then
                        ' The "source" property exists, assign its value to the source variable
                        ' Proceed with displaying the source
                        Label70.Text = "Source: " + source6
                    Else
                        ' The "source" property is missing, handle it accordingly
                        ' You might want to set a default source or display an error message
                        Label70.Text = "Source Not Available"
                    End If


                    ' Display the data in the appropriate controls
                    PictureBox15.Load(imageUrl6)
                    Label73.Text = title6
                    Label72.Text = description6
                    Label71.Text = "Released: " + datePublished6
                    Label70.Text = "Source: " + source6
                    Button7.Enabled = True
                Else
                    ' Handle the case when the request fails
                    MessageBox.Show("Failed to retrieve the article data.")
                    Button7.Enabled = True
                End If
                If response7.IsSuccessStatusCode Then
                    ' Read the response content as a string
                    Dim articleData7 As String = Await response7.Content.ReadAsStringAsync()

                    ' Parse the article data (assuming it's in JSON format)
                    Dim article7 As JObject = JObject.Parse(articleData7)

                    ' Extract the required data from the article object
                    Dim imageUrl7 As String = String.Empty
                    If article7.TryGetValue("image", imageUrl7) Then
                        ' The "image" property exists, assign its value to the imageUrl variable
                        ' Set the ImageLocation property of PictureBox to the imageUrl
                        PictureBox17.ImageLocation = imageUrl7
                    Else
                        ' The "image" property is missing, handle it accordingly
                        ' You might want to set a default image or display an error message
                        MessageBox.Show("Image URL Not Available.")
                        Button7.Enabled = True
                        Return
                    End If
                    Dim title7 As String = String.Empty
                    If article7.TryGetValue("title", title7) Then
                        ' The "title" property exists, assign its value to the title variable
                        ' Proceed with displaying the title
                        Label77.Text = title7
                    Else
                        ' The "title" property is missing, handle it accordingly
                        ' You might want to set a default title or display an error message
                        Label77.Text = "Title Not Available"
                    End If

                    Dim description7 As String = String.Empty
                    If article7.TryGetValue("description", description7) Then
                        ' The "description" property exists, assign its value to the description variable
                        ' Proceed with displaying the description
                        Label76.Text = description7
                    Else
                        ' The "description" property is missing, handle it accordingly
                        ' You might want to set a default description or display an error message
                        Label76.Text = "Description Not Available"
                    End If

                    Dim datePublished7 As String = String.Empty
                    If article7.TryGetValue("datePublished", datePublished7) Then
                        ' The "datePublished" property exists, assign its value to the datePublished variable
                        ' Proceed with displaying the datePublished
                        Label75.Text = "Released: " + datePublished7
                    Else
                        ' The "datePublished" property is missing, handle it accordingly
                        ' You might want to set a default datePublished or display an error message
                        Label75.Text = "Date Not Available"
                    End If

                    Dim source7 As String = String.Empty
                    If article7.TryGetValue("source", source7) Then
                        ' The "source" property exists, assign its value to the source variable
                        ' Proceed with displaying the source
                        Label74.Text = "Source: " + source7
                    Else
                        ' The "source" property is missing, handle it accordingly
                        ' You might want to set a default source or display an error message
                        Label74.Text = "Source Not Available"
                    End If


                    ' Display the data in the appropriate controls
                    PictureBox17.Load(imageUrl7)
                    Label77.Text = title7
                    Label76.Text = description7
                    Label75.Text = "Released: " + datePublished7
                    Label74.Text = "Source: " + source7
                    Button7.Enabled = True
                Else
                    ' Handle the case when the request fails
                    MessageBox.Show("Failed to retrieve the article data.")
                    Button7.Enabled = True
                End If
                If response8.IsSuccessStatusCode Then
                    ' Read the response content as a string
                    Dim articleData8 As String = Await response8.Content.ReadAsStringAsync()

                    ' Parse the article data (assuming it's in JSON format)
                    Dim article8 As JObject = JObject.Parse(articleData8)

                    ' Extract the required data from the article object
                    Dim imageUrl8 As String = String.Empty
                    If article8.TryGetValue("image", imageUrl8) Then
                        ' The "image" property exists, assign its value to the imageUrl variable
                        ' Set the ImageLocation property of PictureBox to the imageUrl
                        PictureBox18.ImageLocation = imageUrl8
                    Else
                        ' The "image" property is missing, handle it accordingly
                        ' You might want to set a default image or display an error message
                        MessageBox.Show("Image URL Not Available.")
                        Button7.Enabled = True
                        Return
                    End If
                    Dim title8 As String = String.Empty
                    If article8.TryGetValue("title", title8) Then
                        ' The "title" property exists, assign its value to the title variable
                        ' Proceed with displaying the title
                        Label81.Text = title8
                    Else
                        ' The "title" property is missing, handle it accordingly
                        ' You might want to set a default title or display an error message
                        Label81.Text = "Title Not Available"
                    End If

                    Dim description8 As String = String.Empty
                    If article8.TryGetValue("description", description8) Then
                        ' The "description" property exists, assign its value to the description variable
                        ' Proceed with displaying the description
                        Label80.Text = description8
                    Else
                        ' The "description" property is missing, handle it accordingly
                        ' You might want to set a default description or display an error message
                        Label80.Text = "Description Not Available"
                    End If

                    Dim datePublished8 As String = String.Empty
                    If article8.TryGetValue("datePublished", datePublished8) Then
                        ' The "datePublished" property exists, assign its value to the datePublished variable
                        ' Proceed with displaying the datePublished
                        Label79.Text = "Released: " + datePublished8
                    Else
                        ' The "datePublished" property is missing, handle it accordingly
                        ' You might want to set a default datePublished or display an error message
                        Label79.Text = "Date Not Available"
                    End If

                    Dim source8 As String = String.Empty
                    If article8.TryGetValue("source", source8) Then
                        ' The "source" property exists, assign its value to the source variable
                        ' Proceed with displaying the source
                        Label78.Text = "Source: " + source8
                    Else
                        ' The "source" property is missing, handle it accordingly
                        ' You might want to set a default source or display an error message
                        Label78.Text = "Source Not Available"
                    End If


                    ' Display the data in the appropriate controls
                    PictureBox18.Load(imageUrl8)
                    Label81.Text = title8
                    Label80.Text = description8
                    Label79.Text = "Released: " + datePublished8
                    Label78.Text = "Source: " + source8
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

    Private Async Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        Panel3.Visible = True
        Panel4.Visible = True
        Panel5.Visible = True
        Panel6.Visible = True
        Panel7.Visible = True
        Panel8.Visible = False
        Panel11.Visible = False
        Label9.Text = "Feed [Beta]"
        Try
            Button7.Enabled = False
            Using client As New HttpClient()
                ' Make a request to the CDN URL and retrieve the article data
                Dim response As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/welcome.json")
                Dim response2 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/tnnews.json")
                Dim response3 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/tnnews2.json")
                Dim response4 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/z1gnews.json")
                'Page 2 Requests
                Dim response5 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/z1gnews2.json")
                Dim response6 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/z1gnews3.json")
                Dim response7 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/tnnews3.json")
                Dim response8 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/googlenews.json")

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
                        articleimg3.ImageLocation = imageUrl3
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
                    articleimg3.Load(imageUrl3)
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
                    Dim articleData4 As String = Await response4.Content.ReadAsStringAsync()

                    ' Parse the article data (assuming it's in JSON format)
                    Dim article4 As JObject = JObject.Parse(articleData4)

                    ' Extract the required data from the article object
                    Dim imageUrl4 As String = String.Empty
                    If article4.TryGetValue("image", imageUrl4) Then
                        ' The "image" property exists, assign its value to the imageUrl variable
                        ' Set the ImageLocation property of PictureBox to the imageUrl
                        articleimg4.ImageLocation = imageUrl4
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
                    articleimg4.Load(imageUrl4)
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
                'Page 2 responses
                If response5.IsSuccessStatusCode Then
                    ' Read the response content as a string
                    Dim articleData5 As String = Await response5.Content.ReadAsStringAsync()

                    ' Parse the article data (assuming it's in JSON format)
                    Dim article5 As JObject = JObject.Parse(articleData5)

                    ' Extract the required data from the article object
                    Dim imageUrl5 As String = String.Empty
                    If article5.TryGetValue("image", imageUrl5) Then
                        ' The "image" property exists, assign its value to the imageUrl variable
                        ' Set the ImageLocation property of PictureBox to the imageUrl
                        PictureBox14.ImageLocation = imageUrl5
                    Else
                        ' The "image" property is missing, handle it accordingly
                        ' You might want to set a default image or display an error message
                        MessageBox.Show("Image URL Not Available.")
                        Button7.Enabled = True
                        Return
                    End If
                    Dim title5 As String = String.Empty
                    If article5.TryGetValue("title", title5) Then
                        ' The "title" property exists, assign its value to the title variable
                        ' Proceed with displaying the title
                        Label69.Text = title5
                    Else
                        ' The "title" property is missing, handle it accordingly
                        ' You might want to set a default title or display an error message
                        Label69.Text = "Title Not Available"
                    End If

                    Dim description5 As String = String.Empty
                    If article5.TryGetValue("description", description5) Then
                        ' The "description" property exists, assign its value to the description variable
                        ' Proceed with displaying the description
                        Label68.Text = description5
                    Else
                        ' The "description" property is missing, handle it accordingly
                        ' You might want to set a default description or display an error message
                        Label68.Text = "Description Not Available"
                    End If

                    Dim datePublished5 As String = String.Empty
                    If article5.TryGetValue("datePublished", datePublished5) Then
                        ' The "datePublished" property exists, assign its value to the datePublished variable
                        ' Proceed with displaying the datePublished
                        Label67.Text = "Released: " + datePublished5
                    Else
                        ' The "datePublished" property is missing, handle it accordingly
                        ' You might want to set a default datePublished or display an error message
                        Label67.Text = "Date Not Available"
                    End If

                    Dim source5 As String = String.Empty
                    If article5.TryGetValue("source", source5) Then
                        ' The "source" property exists, assign its value to the source variable
                        ' Proceed with displaying the source
                        Label66.Text = "Source: " + source5
                    Else
                        ' The "source" property is missing, handle it accordingly
                        ' You might want to set a default source or display an error message
                        Label66.Text = "Source Not Available"
                    End If


                    ' Display the data in the appropriate controls
                    PictureBox14.Load(imageUrl5)
                    Label69.Text = title5
                    Label68.Text = description5
                    Label67.Text = "Released: " + datePublished5
                    Label66.Text = "Source: " + source5
                    Button7.Enabled = True
                Else
                    ' Handle the case when the request fails
                    MessageBox.Show("Failed to retrieve the article data.")
                    Button7.Enabled = True
                End If
                If response6.IsSuccessStatusCode Then
                    ' Read the response content as a string
                    Dim articleData6 As String = Await response6.Content.ReadAsStringAsync()

                    ' Parse the article data (assuming it's in JSON format)
                    Dim article6 As JObject = JObject.Parse(articleData6)

                    ' Extract the required data from the article object
                    Dim imageUrl6 As String = String.Empty
                    If article6.TryGetValue("image", imageUrl6) Then
                        ' The "image" property exists, assign its value to the imageUrl variable
                        ' Set the ImageLocation property of PictureBox to the imageUrl
                        PictureBox15.ImageLocation = imageUrl6
                    Else
                        ' The "image" property is missing, handle it accordingly
                        ' You might want to set a default image or display an error message
                        MessageBox.Show("Image URL Not Available.")
                        Button7.Enabled = True
                        Return
                    End If
                    Dim title6 As String = String.Empty
                    If article6.TryGetValue("title", title6) Then
                        ' The "title" property exists, assign its value to the title variable
                        ' Proceed with displaying the title
                        Label73.Text = title6
                    Else
                        ' The "title" property is missing, handle it accordingly
                        ' You might want to set a default title or display an error message
                        Label73.Text = "Title Not Available"
                    End If

                    Dim description6 As String = String.Empty
                    If article6.TryGetValue("description", description6) Then
                        ' The "description" property exists, assign its value to the description variable
                        ' Proceed with displaying the description
                        Label72.Text = description6
                    Else
                        ' The "description" property is missing, handle it accordingly
                        ' You might want to set a default description or display an error message
                        Label72.Text = "Description Not Available"
                    End If

                    Dim datePublished6 As String = String.Empty
                    If article6.TryGetValue("datePublished", datePublished6) Then
                        ' The "datePublished" property exists, assign its value to the datePublished variable
                        ' Proceed with displaying the datePublished
                        Label71.Text = "Released: " + datePublished6
                    Else
                        ' The "datePublished" property is missing, handle it accordingly
                        ' You might want to set a default datePublished or display an error message
                        Label71.Text = "Date Not Available"
                    End If

                    Dim source6 As String = String.Empty
                    If article6.TryGetValue("source", source6) Then
                        ' The "source" property exists, assign its value to the source variable
                        ' Proceed with displaying the source
                        Label70.Text = "Source: " + source6
                    Else
                        ' The "source" property is missing, handle it accordingly
                        ' You might want to set a default source or display an error message
                        Label70.Text = "Source Not Available"
                    End If


                    ' Display the data in the appropriate controls
                    PictureBox15.Load(imageUrl6)
                    Label73.Text = title6
                    Label72.Text = description6
                    Label71.Text = "Released: " + datePublished6
                    Label70.Text = "Source: " + source6
                    Button7.Enabled = True
                Else
                    ' Handle the case when the request fails
                    MessageBox.Show("Failed to retrieve the article data.")
                    Button7.Enabled = True
                End If
                If response7.IsSuccessStatusCode Then
                    ' Read the response content as a string
                    Dim articleData7 As String = Await response7.Content.ReadAsStringAsync()

                    ' Parse the article data (assuming it's in JSON format)
                    Dim article7 As JObject = JObject.Parse(articleData7)

                    ' Extract the required data from the article object
                    Dim imageUrl7 As String = String.Empty
                    If article7.TryGetValue("image", imageUrl7) Then
                        ' The "image" property exists, assign its value to the imageUrl variable
                        ' Set the ImageLocation property of PictureBox to the imageUrl
                        PictureBox17.ImageLocation = imageUrl7
                    Else
                        ' The "image" property is missing, handle it accordingly
                        ' You might want to set a default image or display an error message
                        MessageBox.Show("Image URL Not Available.")
                        Button7.Enabled = True
                        Return
                    End If
                    Dim title7 As String = String.Empty
                    If article7.TryGetValue("title", title7) Then
                        ' The "title" property exists, assign its value to the title variable
                        ' Proceed with displaying the title
                        Label77.Text = title7
                    Else
                        ' The "title" property is missing, handle it accordingly
                        ' You might want to set a default title or display an error message
                        Label77.Text = "Title Not Available"
                    End If

                    Dim description7 As String = String.Empty
                    If article7.TryGetValue("description", description7) Then
                        ' The "description" property exists, assign its value to the description variable
                        ' Proceed with displaying the description
                        Label76.Text = description7
                    Else
                        ' The "description" property is missing, handle it accordingly
                        ' You might want to set a default description or display an error message
                        Label76.Text = "Description Not Available"
                    End If

                    Dim datePublished7 As String = String.Empty
                    If article7.TryGetValue("datePublished", datePublished7) Then
                        ' The "datePublished" property exists, assign its value to the datePublished variable
                        ' Proceed with displaying the datePublished
                        Label75.Text = "Released: " + datePublished7
                    Else
                        ' The "datePublished" property is missing, handle it accordingly
                        ' You might want to set a default datePublished or display an error message
                        Label75.Text = "Date Not Available"
                    End If

                    Dim source7 As String = String.Empty
                    If article7.TryGetValue("source", source7) Then
                        ' The "source" property exists, assign its value to the source variable
                        ' Proceed with displaying the source
                        Label74.Text = "Source: " + source7
                    Else
                        ' The "source" property is missing, handle it accordingly
                        ' You might want to set a default source or display an error message
                        Label74.Text = "Source Not Available"
                    End If


                    ' Display the data in the appropriate controls
                    PictureBox17.Load(imageUrl7)
                    Label77.Text = title7
                    Label76.Text = description7
                    Label75.Text = "Released: " + datePublished7
                    Label74.Text = "Source: " + source7
                    Button7.Enabled = True
                Else
                    ' Handle the case when the request fails
                    MessageBox.Show("Failed to retrieve the article data.")
                    Button7.Enabled = True
                End If
                If response8.IsSuccessStatusCode Then
                    ' Read the response content as a string
                    Dim articleData8 As String = Await response8.Content.ReadAsStringAsync()

                    ' Parse the article data (assuming it's in JSON format)
                    Dim article8 As JObject = JObject.Parse(articleData8)

                    ' Extract the required data from the article object
                    Dim imageUrl8 As String = String.Empty
                    If article8.TryGetValue("image", imageUrl8) Then
                        ' The "image" property exists, assign its value to the imageUrl variable
                        ' Set the ImageLocation property of PictureBox to the imageUrl
                        PictureBox18.ImageLocation = imageUrl8
                    Else
                        ' The "image" property is missing, handle it accordingly
                        ' You might want to set a default image or display an error message
                        MessageBox.Show("Image URL Not Available.")
                        Button7.Enabled = True
                        Return
                    End If
                    Dim title8 As String = String.Empty
                    If article8.TryGetValue("title", title8) Then
                        ' The "title" property exists, assign its value to the title variable
                        ' Proceed with displaying the title
                        Label81.Text = title8
                    Else
                        ' The "title" property is missing, handle it accordingly
                        ' You might want to set a default title or display an error message
                        Label81.Text = "Title Not Available"
                    End If

                    Dim description8 As String = String.Empty
                    If article8.TryGetValue("description", description8) Then
                        ' The "description" property exists, assign its value to the description variable
                        ' Proceed with displaying the description
                        Label80.Text = description8
                    Else
                        ' The "description" property is missing, handle it accordingly
                        ' You might want to set a default description or display an error message
                        Label80.Text = "Description Not Available"
                    End If

                    Dim datePublished8 As String = String.Empty
                    If article8.TryGetValue("datePublished", datePublished8) Then
                        ' The "datePublished" property exists, assign its value to the datePublished variable
                        ' Proceed with displaying the datePublished
                        Label79.Text = "Released: " + datePublished8
                    Else
                        ' The "datePublished" property is missing, handle it accordingly
                        ' You might want to set a default datePublished or display an error message
                        Label79.Text = "Date Not Available"
                    End If

                    Dim source8 As String = String.Empty
                    If article8.TryGetValue("source", source8) Then
                        ' The "source" property exists, assign its value to the source variable
                        ' Proceed with displaying the source
                        Label78.Text = "Source: " + source8
                    Else
                        ' The "source" property is missing, handle it accordingly
                        ' You might want to set a default source or display an error message
                        Label78.Text = "Source Not Available"
                    End If


                    ' Display the data in the appropriate controls
                    PictureBox18.Load(imageUrl8)
                    Label81.Text = title8
                    Label80.Text = description8
                    Label79.Text = "Released: " + datePublished8
                    Label78.Text = "Source: " + source8
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
        Panel8.Visible = False
        Panel11.Visible = False
        Label9.Text = "Feed [Beta]"
        Try
            Button7.Enabled = False
            Using client As New HttpClient()
                ' Make a request to the CDN URL and retrieve the article data
                Dim response As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/welcome.json")
                Dim response2 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/tnnews.json")
                Dim response3 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/tnnews2.json")
                Dim response4 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/z1gnews.json")
                'Page 2 Requests
                Dim response5 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/z1gnews2.json")
                Dim response6 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/z1gnews3.json")
                Dim response7 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/tnnews3.json")
                Dim response8 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/googlenews.json")

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
                        articleimg3.ImageLocation = imageUrl3
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
                    articleimg3.Load(imageUrl3)
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
                    Dim articleData4 As String = Await response4.Content.ReadAsStringAsync()

                    ' Parse the article data (assuming it's in JSON format)
                    Dim article4 As JObject = JObject.Parse(articleData4)

                    ' Extract the required data from the article object
                    Dim imageUrl4 As String = String.Empty
                    If article4.TryGetValue("image", imageUrl4) Then
                        ' The "image" property exists, assign its value to the imageUrl variable
                        ' Set the ImageLocation property of PictureBox to the imageUrl
                        articleimg4.ImageLocation = imageUrl4
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
                    articleimg4.Load(imageUrl4)
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
                'Page 2 responses
                If response5.IsSuccessStatusCode Then
                    ' Read the response content as a string
                    Dim articleData5 As String = Await response5.Content.ReadAsStringAsync()

                    ' Parse the article data (assuming it's in JSON format)
                    Dim article5 As JObject = JObject.Parse(articleData5)

                    ' Extract the required data from the article object
                    Dim imageUrl5 As String = String.Empty
                    If article5.TryGetValue("image", imageUrl5) Then
                        ' The "image" property exists, assign its value to the imageUrl variable
                        ' Set the ImageLocation property of PictureBox to the imageUrl
                        PictureBox14.ImageLocation = imageUrl5
                    Else
                        ' The "image" property is missing, handle it accordingly
                        ' You might want to set a default image or display an error message
                        MessageBox.Show("Image URL Not Available.")
                        Button7.Enabled = True
                        Return
                    End If
                    Dim title5 As String = String.Empty
                    If article5.TryGetValue("title", title5) Then
                        ' The "title" property exists, assign its value to the title variable
                        ' Proceed with displaying the title
                        Label69.Text = title5
                    Else
                        ' The "title" property is missing, handle it accordingly
                        ' You might want to set a default title or display an error message
                        Label69.Text = "Title Not Available"
                    End If

                    Dim description5 As String = String.Empty
                    If article5.TryGetValue("description", description5) Then
                        ' The "description" property exists, assign its value to the description variable
                        ' Proceed with displaying the description
                        Label68.Text = description5
                    Else
                        ' The "description" property is missing, handle it accordingly
                        ' You might want to set a default description or display an error message
                        Label68.Text = "Description Not Available"
                    End If

                    Dim datePublished5 As String = String.Empty
                    If article5.TryGetValue("datePublished", datePublished5) Then
                        ' The "datePublished" property exists, assign its value to the datePublished variable
                        ' Proceed with displaying the datePublished
                        Label67.Text = "Released: " + datePublished5
                    Else
                        ' The "datePublished" property is missing, handle it accordingly
                        ' You might want to set a default datePublished or display an error message
                        Label67.Text = "Date Not Available"
                    End If

                    Dim source5 As String = String.Empty
                    If article5.TryGetValue("source", source5) Then
                        ' The "source" property exists, assign its value to the source variable
                        ' Proceed with displaying the source
                        Label66.Text = "Source: " + source5
                    Else
                        ' The "source" property is missing, handle it accordingly
                        ' You might want to set a default source or display an error message
                        Label66.Text = "Source Not Available"
                    End If


                    ' Display the data in the appropriate controls
                    PictureBox14.Load(imageUrl5)
                    Label69.Text = title5
                    Label68.Text = description5
                    Label67.Text = "Released: " + datePublished5
                    Label66.Text = "Source: " + source5
                    Button7.Enabled = True
                Else
                    ' Handle the case when the request fails
                    MessageBox.Show("Failed to retrieve the article data.")
                    Button7.Enabled = True
                End If
                If response6.IsSuccessStatusCode Then
                    ' Read the response content as a string
                    Dim articleData6 As String = Await response6.Content.ReadAsStringAsync()

                    ' Parse the article data (assuming it's in JSON format)
                    Dim article6 As JObject = JObject.Parse(articleData6)

                    ' Extract the required data from the article object
                    Dim imageUrl6 As String = String.Empty
                    If article6.TryGetValue("image", imageUrl6) Then
                        ' The "image" property exists, assign its value to the imageUrl variable
                        ' Set the ImageLocation property of PictureBox to the imageUrl
                        PictureBox15.ImageLocation = imageUrl6
                    Else
                        ' The "image" property is missing, handle it accordingly
                        ' You might want to set a default image or display an error message
                        MessageBox.Show("Image URL Not Available.")
                        Button7.Enabled = True
                        Return
                    End If
                    Dim title6 As String = String.Empty
                    If article6.TryGetValue("title", title6) Then
                        ' The "title" property exists, assign its value to the title variable
                        ' Proceed with displaying the title
                        Label73.Text = title6
                    Else
                        ' The "title" property is missing, handle it accordingly
                        ' You might want to set a default title or display an error message
                        Label73.Text = "Title Not Available"
                    End If

                    Dim description6 As String = String.Empty
                    If article6.TryGetValue("description", description6) Then
                        ' The "description" property exists, assign its value to the description variable
                        ' Proceed with displaying the description
                        Label72.Text = description6
                    Else
                        ' The "description" property is missing, handle it accordingly
                        ' You might want to set a default description or display an error message
                        Label72.Text = "Description Not Available"
                    End If

                    Dim datePublished6 As String = String.Empty
                    If article6.TryGetValue("datePublished", datePublished6) Then
                        ' The "datePublished" property exists, assign its value to the datePublished variable
                        ' Proceed with displaying the datePublished
                        Label71.Text = "Released: " + datePublished6
                    Else
                        ' The "datePublished" property is missing, handle it accordingly
                        ' You might want to set a default datePublished or display an error message
                        Label71.Text = "Date Not Available"
                    End If

                    Dim source6 As String = String.Empty
                    If article6.TryGetValue("source", source6) Then
                        ' The "source" property exists, assign its value to the source variable
                        ' Proceed with displaying the source
                        Label70.Text = "Source: " + source6
                    Else
                        ' The "source" property is missing, handle it accordingly
                        ' You might want to set a default source or display an error message
                        Label70.Text = "Source Not Available"
                    End If


                    ' Display the data in the appropriate controls
                    PictureBox15.Load(imageUrl6)
                    Label73.Text = title6
                    Label72.Text = description6
                    Label71.Text = "Released: " + datePublished6
                    Label70.Text = "Source: " + source6
                    Button7.Enabled = True
                Else
                    ' Handle the case when the request fails
                    MessageBox.Show("Failed to retrieve the article data.")
                    Button7.Enabled = True
                End If
                If response7.IsSuccessStatusCode Then
                    ' Read the response content as a string
                    Dim articleData7 As String = Await response7.Content.ReadAsStringAsync()

                    ' Parse the article data (assuming it's in JSON format)
                    Dim article7 As JObject = JObject.Parse(articleData7)

                    ' Extract the required data from the article object
                    Dim imageUrl7 As String = String.Empty
                    If article7.TryGetValue("image", imageUrl7) Then
                        ' The "image" property exists, assign its value to the imageUrl variable
                        ' Set the ImageLocation property of PictureBox to the imageUrl
                        PictureBox17.ImageLocation = imageUrl7
                    Else
                        ' The "image" property is missing, handle it accordingly
                        ' You might want to set a default image or display an error message
                        MessageBox.Show("Image URL Not Available.")
                        Button7.Enabled = True
                        Return
                    End If
                    Dim title7 As String = String.Empty
                    If article7.TryGetValue("title", title7) Then
                        ' The "title" property exists, assign its value to the title variable
                        ' Proceed with displaying the title
                        Label77.Text = title7
                    Else
                        ' The "title" property is missing, handle it accordingly
                        ' You might want to set a default title or display an error message
                        Label77.Text = "Title Not Available"
                    End If

                    Dim description7 As String = String.Empty
                    If article7.TryGetValue("description", description7) Then
                        ' The "description" property exists, assign its value to the description variable
                        ' Proceed with displaying the description
                        Label76.Text = description7
                    Else
                        ' The "description" property is missing, handle it accordingly
                        ' You might want to set a default description or display an error message
                        Label76.Text = "Description Not Available"
                    End If

                    Dim datePublished7 As String = String.Empty
                    If article7.TryGetValue("datePublished", datePublished7) Then
                        ' The "datePublished" property exists, assign its value to the datePublished variable
                        ' Proceed with displaying the datePublished
                        Label75.Text = "Released: " + datePublished7
                    Else
                        ' The "datePublished" property is missing, handle it accordingly
                        ' You might want to set a default datePublished or display an error message
                        Label75.Text = "Date Not Available"
                    End If

                    Dim source7 As String = String.Empty
                    If article7.TryGetValue("source", source7) Then
                        ' The "source" property exists, assign its value to the source variable
                        ' Proceed with displaying the source
                        Label74.Text = "Source: " + source7
                    Else
                        ' The "source" property is missing, handle it accordingly
                        ' You might want to set a default source or display an error message
                        Label74.Text = "Source Not Available"
                    End If


                    ' Display the data in the appropriate controls
                    PictureBox17.Load(imageUrl7)
                    Label77.Text = title7
                    Label76.Text = description7
                    Label75.Text = "Released: " + datePublished7
                    Label74.Text = "Source: " + source7
                    Button7.Enabled = True
                Else
                    ' Handle the case when the request fails
                    MessageBox.Show("Failed to retrieve the article data.")
                    Button7.Enabled = True
                End If
                If response8.IsSuccessStatusCode Then
                    ' Read the response content as a string
                    Dim articleData8 As String = Await response8.Content.ReadAsStringAsync()

                    ' Parse the article data (assuming it's in JSON format)
                    Dim article8 As JObject = JObject.Parse(articleData8)

                    ' Extract the required data from the article object
                    Dim imageUrl8 As String = String.Empty
                    If article8.TryGetValue("image", imageUrl8) Then
                        ' The "image" property exists, assign its value to the imageUrl variable
                        ' Set the ImageLocation property of PictureBox to the imageUrl
                        PictureBox18.ImageLocation = imageUrl8
                    Else
                        ' The "image" property is missing, handle it accordingly
                        ' You might want to set a default image or display an error message
                        MessageBox.Show("Image URL Not Available.")
                        Button7.Enabled = True
                        Return
                    End If
                    Dim title8 As String = String.Empty
                    If article8.TryGetValue("title", title8) Then
                        ' The "title" property exists, assign its value to the title variable
                        ' Proceed with displaying the title
                        Label81.Text = title8
                    Else
                        ' The "title" property is missing, handle it accordingly
                        ' You might want to set a default title or display an error message
                        Label81.Text = "Title Not Available"
                    End If

                    Dim description8 As String = String.Empty
                    If article8.TryGetValue("description", description8) Then
                        ' The "description" property exists, assign its value to the description variable
                        ' Proceed with displaying the description
                        Label80.Text = description8
                    Else
                        ' The "description" property is missing, handle it accordingly
                        ' You might want to set a default description or display an error message
                        Label80.Text = "Description Not Available"
                    End If

                    Dim datePublished8 As String = String.Empty
                    If article8.TryGetValue("datePublished", datePublished8) Then
                        ' The "datePublished" property exists, assign its value to the datePublished variable
                        ' Proceed with displaying the datePublished
                        Label79.Text = "Released: " + datePublished8
                    Else
                        ' The "datePublished" property is missing, handle it accordingly
                        ' You might want to set a default datePublished or display an error message
                        Label79.Text = "Date Not Available"
                    End If

                    Dim source8 As String = String.Empty
                    If article8.TryGetValue("source", source8) Then
                        ' The "source" property exists, assign its value to the source variable
                        ' Proceed with displaying the source
                        Label78.Text = "Source: " + source8
                    Else
                        ' The "source" property is missing, handle it accordingly
                        ' You might want to set a default source or display an error message
                        Label78.Text = "Source Not Available"
                    End If


                    ' Display the data in the appropriate controls
                    PictureBox18.Load(imageUrl8)
                    Label81.Text = title8
                    Label80.Text = description8
                    Label79.Text = "Released: " + datePublished8
                    Label78.Text = "Source: " + source8
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form2.Show()
        Panel6.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
                Dim response2 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/tnnews.json")
                Dim response3 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/tnnews2.json")
                Dim response4 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/z1gnews.json")
                'Page 2 Requests
                Dim response5 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/z1gnews2.json")
                Dim response6 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/z1gnews3.json")
                Dim response7 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/tnnews3.json")
                Dim response8 As HttpResponseMessage = Await client.GetAsync("https://cdn.z1g-project.repl.co/z1g-hub/news/googlenews.json")

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
                        articleimg3.ImageLocation = imageUrl3
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
                    articleimg3.Load(imageUrl3)
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
                    Dim articleData4 As String = Await response4.Content.ReadAsStringAsync()

                    ' Parse the article data (assuming it's in JSON format)
                    Dim article4 As JObject = JObject.Parse(articleData4)

                    ' Extract the required data from the article object
                    Dim imageUrl4 As String = String.Empty
                    If article4.TryGetValue("image", imageUrl4) Then
                        ' The "image" property exists, assign its value to the imageUrl variable
                        ' Set the ImageLocation property of PictureBox to the imageUrl
                        articleimg4.ImageLocation = imageUrl4
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
                    articleimg4.Load(imageUrl4)
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
                'Page 2 responses
                If response5.IsSuccessStatusCode Then
                    ' Read the response content as a string
                    Dim articleData5 As String = Await response5.Content.ReadAsStringAsync()

                    ' Parse the article data (assuming it's in JSON format)
                    Dim article5 As JObject = JObject.Parse(articleData5)

                    ' Extract the required data from the article object
                    Dim imageUrl5 As String = String.Empty
                    If article5.TryGetValue("image", imageUrl5) Then
                        ' The "image" property exists, assign its value to the imageUrl variable
                        ' Set the ImageLocation property of PictureBox to the imageUrl
                        PictureBox14.ImageLocation = imageUrl5
                    Else
                        ' The "image" property is missing, handle it accordingly
                        ' You might want to set a default image or display an error message
                        MessageBox.Show("Image URL Not Available.")
                        Button7.Enabled = True
                        Return
                    End If
                    Dim title5 As String = String.Empty
                    If article5.TryGetValue("title", title5) Then
                        ' The "title" property exists, assign its value to the title variable
                        ' Proceed with displaying the title
                        Label69.Text = title5
                    Else
                        ' The "title" property is missing, handle it accordingly
                        ' You might want to set a default title or display an error message
                        Label69.Text = "Title Not Available"
                    End If

                    Dim description5 As String = String.Empty
                    If article5.TryGetValue("description", description5) Then
                        ' The "description" property exists, assign its value to the description variable
                        ' Proceed with displaying the description
                        Label68.Text = description5
                    Else
                        ' The "description" property is missing, handle it accordingly
                        ' You might want to set a default description or display an error message
                        Label68.Text = "Description Not Available"
                    End If

                    Dim datePublished5 As String = String.Empty
                    If article5.TryGetValue("datePublished", datePublished5) Then
                        ' The "datePublished" property exists, assign its value to the datePublished variable
                        ' Proceed with displaying the datePublished
                        Label67.Text = "Released: " + datePublished5
                    Else
                        ' The "datePublished" property is missing, handle it accordingly
                        ' You might want to set a default datePublished or display an error message
                        Label67.Text = "Date Not Available"
                    End If

                    Dim source5 As String = String.Empty
                    If article5.TryGetValue("source", source5) Then
                        ' The "source" property exists, assign its value to the source variable
                        ' Proceed with displaying the source
                        Label66.Text = "Source: " + source5
                    Else
                        ' The "source" property is missing, handle it accordingly
                        ' You might want to set a default source or display an error message
                        Label66.Text = "Source Not Available"
                    End If


                    ' Display the data in the appropriate controls
                    PictureBox14.Load(imageUrl5)
                    Label69.Text = title5
                    Label68.Text = description5
                    Label67.Text = "Released: " + datePublished5
                    Label66.Text = "Source: " + source5
                    Button7.Enabled = True
                Else
                    ' Handle the case when the request fails
                    MessageBox.Show("Failed to retrieve the article data.")
                    Button7.Enabled = True
                End If
                If response6.IsSuccessStatusCode Then
                    ' Read the response content as a string
                    Dim articleData6 As String = Await response6.Content.ReadAsStringAsync()

                    ' Parse the article data (assuming it's in JSON format)
                    Dim article6 As JObject = JObject.Parse(articleData6)

                    ' Extract the required data from the article object
                    Dim imageUrl6 As String = String.Empty
                    If article6.TryGetValue("image", imageUrl6) Then
                        ' The "image" property exists, assign its value to the imageUrl variable
                        ' Set the ImageLocation property of PictureBox to the imageUrl
                        PictureBox15.ImageLocation = imageUrl6
                    Else
                        ' The "image" property is missing, handle it accordingly
                        ' You might want to set a default image or display an error message
                        MessageBox.Show("Image URL Not Available.")
                        Button7.Enabled = True
                        Return
                    End If
                    Dim title6 As String = String.Empty
                    If article6.TryGetValue("title", title6) Then
                        ' The "title" property exists, assign its value to the title variable
                        ' Proceed with displaying the title
                        Label73.Text = title6
                    Else
                        ' The "title" property is missing, handle it accordingly
                        ' You might want to set a default title or display an error message
                        Label73.Text = "Title Not Available"
                    End If

                    Dim description6 As String = String.Empty
                    If article6.TryGetValue("description", description6) Then
                        ' The "description" property exists, assign its value to the description variable
                        ' Proceed with displaying the description
                        Label72.Text = description6
                    Else
                        ' The "description" property is missing, handle it accordingly
                        ' You might want to set a default description or display an error message
                        Label72.Text = "Description Not Available"
                    End If

                    Dim datePublished6 As String = String.Empty
                    If article6.TryGetValue("datePublished", datePublished6) Then
                        ' The "datePublished" property exists, assign its value to the datePublished variable
                        ' Proceed with displaying the datePublished
                        Label71.Text = "Released: " + datePublished6
                    Else
                        ' The "datePublished" property is missing, handle it accordingly
                        ' You might want to set a default datePublished or display an error message
                        Label71.Text = "Date Not Available"
                    End If

                    Dim source6 As String = String.Empty
                    If article6.TryGetValue("source", source6) Then
                        ' The "source" property exists, assign its value to the source variable
                        ' Proceed with displaying the source
                        Label70.Text = "Source: " + source6
                    Else
                        ' The "source" property is missing, handle it accordingly
                        ' You might want to set a default source or display an error message
                        Label70.Text = "Source Not Available"
                    End If


                    ' Display the data in the appropriate controls
                    PictureBox15.Load(imageUrl6)
                    Label73.Text = title6
                    Label72.Text = description6
                    Label71.Text = "Released: " + datePublished6
                    Label70.Text = "Source: " + source6
                    Button7.Enabled = True
                Else
                    ' Handle the case when the request fails
                    MessageBox.Show("Failed to retrieve the article data.")
                    Button7.Enabled = True
                End If
                If response7.IsSuccessStatusCode Then
                    ' Read the response content as a string
                    Dim articleData7 As String = Await response5.Content.ReadAsStringAsync()

                    ' Parse the article data (assuming it's in JSON format)
                    Dim article7 As JObject = JObject.Parse(articleData7)

                    ' Extract the required data from the article object
                    Dim imageUrl7 As String = String.Empty
                    If article7.TryGetValue("image", imageUrl7) Then
                        ' The "image" property exists, assign its value to the imageUrl variable
                        ' Set the ImageLocation property of PictureBox to the imageUrl
                        PictureBox17.ImageLocation = imageUrl7
                    Else
                        ' The "image" property is missing, handle it accordingly
                        ' You might want to set a default image or display an error message
                        MessageBox.Show("Image URL Not Available.")
                        Button7.Enabled = True
                        Return
                    End If
                    Dim title7 As String = String.Empty
                    If article7.TryGetValue("title", title7) Then
                        ' The "title" property exists, assign its value to the title variable
                        ' Proceed with displaying the title
                        Label77.Text = title7
                    Else
                        ' The "title" property is missing, handle it accordingly
                        ' You might want to set a default title or display an error message
                        Label77.Text = "Title Not Available"
                    End If

                    Dim description7 As String = String.Empty
                    If article7.TryGetValue("description", description7) Then
                        ' The "description" property exists, assign its value to the description variable
                        ' Proceed with displaying the description
                        Label76.Text = description7
                    Else
                        ' The "description" property is missing, handle it accordingly
                        ' You might want to set a default description or display an error message
                        Label76.Text = "Description Not Available"
                    End If

                    Dim datePublished7 As String = String.Empty
                    If article7.TryGetValue("datePublished", datePublished7) Then
                        ' The "datePublished" property exists, assign its value to the datePublished variable
                        ' Proceed with displaying the datePublished
                        Label75.Text = "Released: " + datePublished7
                    Else
                        ' The "datePublished" property is missing, handle it accordingly
                        ' You might want to set a default datePublished or display an error message
                        Label75.Text = "Date Not Available"
                    End If

                    Dim source7 As String = String.Empty
                    If article7.TryGetValue("source", source7) Then
                        ' The "source" property exists, assign its value to the source variable
                        ' Proceed with displaying the source
                        Label74.Text = "Source: " + source7
                    Else
                        ' The "source" property is missing, handle it accordingly
                        ' You might want to set a default source or display an error message
                        Label74.Text = "Source Not Available"
                    End If


                    ' Display the data in the appropriate controls
                    PictureBox17.Load(imageUrl7)
                    Label77.Text = title7
                    Label76.Text = description7
                    Label75.Text = "Released: " + datePublished7
                    Label74.Text = "Source: " + source7
                    Button7.Enabled = True
                Else
                    ' Handle the case when the request fails
                    MessageBox.Show("Failed to retrieve the article data.")
                    Button7.Enabled = True
                End If
                If response8.IsSuccessStatusCode Then
                    ' Read the response content as a string
                    Dim articleData8 As String = Await response8.Content.ReadAsStringAsync()

                    ' Parse the article data (assuming it's in JSON format)
                    Dim article8 As JObject = JObject.Parse(articleData8)

                    ' Extract the required data from the article object
                    Dim imageUrl8 As String = String.Empty
                    If article8.TryGetValue("image", imageUrl8) Then
                        ' The "image" property exists, assign its value to the imageUrl variable
                        ' Set the ImageLocation property of PictureBox to the imageUrl
                        PictureBox18.ImageLocation = imageUrl8
                    Else
                        ' The "image" property is missing, handle it accordingly
                        ' You might want to set a default image or display an error message
                        MessageBox.Show("Image URL Not Available.")
                        Button7.Enabled = True
                        Return
                    End If
                    Dim title8 As String = String.Empty
                    If article8.TryGetValue("title", title8) Then
                        ' The "title" property exists, assign its value to the title variable
                        ' Proceed with displaying the title
                        Label81.Text = title8
                    Else
                        ' The "title" property is missing, handle it accordingly
                        ' You might want to set a default title or display an error message
                        Label81.Text = "Title Not Available"
                    End If

                    Dim description8 As String = String.Empty
                    If article8.TryGetValue("description", description8) Then
                        ' The "description" property exists, assign its value to the description variable
                        ' Proceed with displaying the description
                        Label80.Text = description8
                    Else
                        ' The "description" property is missing, handle it accordingly
                        ' You might want to set a default description or display an error message
                        Label80.Text = "Description Not Available"
                    End If

                    Dim datePublished8 As String = String.Empty
                    If article8.TryGetValue("datePublished", datePublished8) Then
                        ' The "datePublished" property exists, assign its value to the datePublished variable
                        ' Proceed with displaying the datePublished
                        Label79.Text = "Released: " + datePublished8
                    Else
                        ' The "datePublished" property is missing, handle it accordingly
                        ' You might want to set a default datePublished or display an error message
                        Label79.Text = "Date Not Available"
                    End If

                    Dim source8 As String = String.Empty
                    If article8.TryGetValue("source", source8) Then
                        ' The "source" property exists, assign its value to the source variable
                        ' Proceed with displaying the source
                        Label78.Text = "Source: " + source8
                    Else
                        ' The "source" property is missing, handle it accordingly
                        ' You might want to set a default source or display an error message
                        Label78.Text = "Source Not Available"
                    End If


                    ' Display the data in the appropriate controls
                    PictureBox18.Load(imageUrl8)
                    Label81.Text = title8
                    Label80.Text = description8
                    Label79.Text = "Released: " + datePublished8
                    Label78.Text = "Source: " + source8
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
            Me.Cursor = Cursors.WaitCursor
            My.Computer.Network.DownloadFile("https://cdn.z1g-project.repl.co/z1g-hub/client/blurreds-vault.zip", "C:\z1g Apps\Blurreds Vault\blurreds-vault.zip")
            ZipFile.ExtractToDirectory("C:\z1g Apps\Blurreds Vault\blurreds-vault.zip", "C:\Users\Public\Blurreds Vault\")
            System.IO.Directory.CreateDirectory("C:\Users\Public\Blurreds Vault\")
            Process.Start("C:\z1g Apps\Blurreds Vault\Blurred's Vault.exe")
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click
        'Blurred's Vault
        If My.Computer.FileSystem.FileExists("C:\z1g Apps\Blurreds Vault\Blurred's Vault.exe") Then
            Process.Start("C:\z1g Apps\Blurreds Vault\Blurred's Vault.exe")
        Else
            Me.Cursor = Cursors.WaitCursor
            My.Computer.Network.DownloadFile("https://cdn.z1g-project.repl.co/z1g-hub/client/blurreds-vault.zip", "C:\z1g Apps\Blurreds Vault\blurreds-vault.zip")
            ZipFile.ExtractToDirectory("C:\z1g Apps\Blurreds Vault\blurreds-vault.zip", "C:\Users\Public\Blurreds Vault\")
            System.IO.Directory.CreateDirectory("C:\Users\Public\Blurreds Vault\")
            Process.Start("C:\z1g Apps\Blurreds Vault\Blurred's Vault.exe")
            Me.Cursor = Cursors.Default
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

    Private Sub Panel2_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel2.MouseDown
        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        'Terbium ContextMenu
        If My.Computer.FileSystem.FileExists("C:\z1g Apps\Terbium\Terbium.exe") Then
            Process.Start("C:\z1g Apps\Terbium\Terbium.exe")
        Else
            My.Computer.Network.DownloadFile("https://cdn.z1g-project.repl.co/z1g-hub/client/Terbium-bootstrap.exe", "C:\z1g Apps\Terbium\Terbium-bootstrap.exe")
            Process.Start("C:\z1g Apps\Terbium\Terbium-bootstrap.exe")
        End If
    End Sub

    Private Sub UninstallToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UninstallToolStripMenuItem.Click
        My.Computer.FileSystem.DeleteDirectory("C:\z1g Apps\Terbium\", True)
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Terbium_Settings.Show()
    End Sub

    Private Sub ResetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetToolStripMenuItem.Click
        My.Computer.FileSystem.DeleteDirectory("C:\z1g Apps\Terbium\Data\", True)
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        'Velocity ContextMenu
        If My.Computer.FileSystem.FileExists("C:\z1g Apps\Velocity\velocity.exe") Then
            Process.Start("C:\z1g Apps\Velocity\velocity.exe")
        Else
            My.Computer.Network.DownloadFile("https://cdn.z1g-project.repl.co/z1g-hub/client/velocity-bootstrap.exe", "C:\z1g Apps\Velocity\velocity-bootstrap.exe")
            Process.Start("C:\z1g Apps\Velocity\velocity-bootstrap.exe")
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        My.Computer.FileSystem.DeleteDirectory("C:\z1g Apps\Velocity\", True)
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        My.Computer.FileSystem.DeleteDirectory("C:\z1g Apps\Velocity\Data\", True)
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Velocity_Settings.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Panel8.Visible = False
        Panel11.Visible = False
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Panel8.Visible = True
        Panel11.Visible = True
    End Sub

    Private Sub Panel10_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel10.MouseDown
        Panel8.Visible = True
        Panel11.Visible = True
    End Sub

    Private Sub Panel11_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel11.MouseUp
        Panel8.Visible = False
        Panel11.Visible = False
    End Sub

    Private Sub Panel10_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel10.MouseUp
        Panel8.Visible = False
        Panel11.Visible = False
    End Sub

    Private Sub Panel11_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel11.MouseDown
        Panel8.Visible = True
        Panel11.Visible = True
    End Sub
End Class