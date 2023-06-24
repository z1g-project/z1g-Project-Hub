<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class appviewer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        panel1 = New Panel()
        pictureBox1 = New PictureBox()
        Button3 = New Button()
        Button2 = New Button()
        Label9 = New Label()
        Button1 = New Button()
        Label2 = New Label()
        Label1 = New Label()
        PictureBox2 = New PictureBox()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        TextBox1 = New TextBox()
        Button4 = New Button()
        Button5 = New Button()
        Label7 = New Label()
        panel1.SuspendLayout()
        CType(pictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' panel1
        ' 
        panel1.Controls.Add(pictureBox1)
        panel1.Controls.Add(Button3)
        panel1.Controls.Add(Button2)
        panel1.Controls.Add(Label9)
        panel1.Dock = DockStyle.Top
        panel1.Location = New Point(0, 0)
        panel1.Name = "panel1"
        panel1.Size = New Size(859, 29)
        panel1.TabIndex = 25
        ' 
        ' pictureBox1
        ' 
        pictureBox1.Image = My.Resources.Resources.downloadicon
        pictureBox1.Location = New Point(3, 3)
        pictureBox1.Name = "pictureBox1"
        pictureBox1.Size = New Size(30, 24)
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        pictureBox1.TabIndex = 14
        pictureBox1.TabStop = False
        ' 
        ' Button3
        ' 
        Button3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button3.BackColor = Color.FromArgb(CByte(64), CByte(0), CByte(0))
        Button3.FlatAppearance.BorderSize = 0
        Button3.FlatStyle = FlatStyle.Flat
        Button3.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
        Button3.Location = New Point(821, 3)
        Button3.Name = "Button3"
        Button3.Size = New Size(35, 23)
        Button3.TabIndex = 13
        Button3.Text = "X"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button2.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(45))
        Button2.FlatAppearance.BorderSize = 0
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
        Button2.Location = New Point(780, 3)
        Button2.Name = "Button2"
        Button2.Size = New Size(35, 23)
        Button2.TabIndex = 12
        Button2.Text = "-"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label9.Location = New Point(39, 2)
        Label9.Name = "Label9"
        Label9.Size = New Size(98, 21)
        Label9.TabIndex = 11
        Label9.Text = "App Viewer"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(45))
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Location = New Point(750, 559)
        Button1.Name = "Button1"
        Button1.Size = New Size(97, 32)
        Button1.TabIndex = 30
        Button1.Text = "Install"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.Location = New Point(58, 97)
        Label2.Name = "Label2"
        Label2.Size = New Size(254, 17)
        Label2.TabIndex = 29
        Label2.Text = "View the Information about {application}"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(26, 48)
        Label1.Name = "Label1"
        Label1.Size = New Size(320, 45)
        Label1.TabIndex = 28
        Label1.Text = "About {Application}"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = My.Resources.Resources.downloadicon
        PictureBox2.Location = New Point(64, 150)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(135, 124)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 31
        PictureBox2.TabStop = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.Location = New Point(222, 141)
        Label3.Name = "Label3"
        Label3.Size = New Size(146, 32)
        Label3.TabIndex = 32
        Label3.Text = "Application"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label4.Location = New Point(235, 211)
        Label4.Name = "Label4"
        Label4.Size = New Size(160, 17)
        Label4.TabIndex = 33
        Label4.Text = "Publisher: ✅ z1g Project"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label5.Location = New Point(235, 184)
        Label5.Name = "Label5"
        Label5.Size = New Size(234, 17)
        Label5.TabIndex = 34
        Label5.Text = "Version: 1.4.0 [Checking for updates...]"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label6.Location = New Point(235, 237)
        Label6.Name = "Label6"
        Label6.Size = New Size(107, 17)
        Label6.TabIndex = 35
        Label6.Text = "Size on Disk: NA"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(1030, 131)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(111, 23)
        TextBox1.TabIndex = 36
        ' 
        ' Button4
        ' 
        Button4.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(45))
        Button4.FlatAppearance.BorderSize = 0
        Button4.FlatStyle = FlatStyle.Flat
        Button4.Location = New Point(647, 559)
        Button4.Name = "Button4"
        Button4.Size = New Size(97, 32)
        Button4.TabIndex = 37
        Button4.Text = "UnInstall"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Button5
        ' 
        Button5.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(45))
        Button5.FlatAppearance.BorderSize = 0
        Button5.FlatStyle = FlatStyle.Flat
        Button5.Location = New Point(12, 559)
        Button5.Name = "Button5"
        Button5.Size = New Size(97, 32)
        Button5.TabIndex = 38
        Button5.Text = "Cancel"
        Button5.UseVisualStyleBackColor = False
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label7.Location = New Point(235, 263)
        Label7.Name = "Label7"
        Label7.Size = New Size(100, 17)
        Label7.TabIndex = 39
        Label7.Text = "Installed in: NA"
        ' 
        ' appviewer
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        ClientSize = New Size(859, 603)
        Controls.Add(Label7)
        Controls.Add(Button5)
        Controls.Add(Button4)
        Controls.Add(TextBox1)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(PictureBox2)
        Controls.Add(Button1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(panel1)
        ForeColor = Color.White
        FormBorderStyle = FormBorderStyle.None
        Name = "appviewer"
        StartPosition = FormStartPosition.CenterScreen
        Text = "z1g App Viewer"
        panel1.ResumeLayout(False)
        panel1.PerformLayout()
        CType(pictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Private WithEvents panel1 As Panel
    Private WithEvents pictureBox1 As PictureBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Label7 As Label
End Class
