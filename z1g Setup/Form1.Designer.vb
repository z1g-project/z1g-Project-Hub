<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form1))
        Label1 = New Label()
        Button1 = New Button()
        ComboBox1 = New ComboBox()
        LinkLabel1 = New LinkLabel()
        Label2 = New Label()
        panel1 = New Panel()
        pictureBox1 = New PictureBox()
        Button3 = New Button()
        Button5 = New Button()
        Label9 = New Label()
        Button2 = New Button()
        panel1.SuspendLayout()
        CType(pictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(179, 36)
        Label1.Name = "Label1"
        Label1.Size = New Size(144, 40)
        Label1.TabIndex = 0
        Label1.Text = "Welcome"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(45))
        Button1.FlatStyle = FlatStyle.Flat
        Button1.ForeColor = Color.White
        Button1.Location = New Point(2, 254)
        Button1.Name = "Button1"
        Button1.Size = New Size(79, 26)
        Button1.TabIndex = 1
        Button1.Text = "Exit"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' ComboBox1
        ' 
        ComboBox1.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(45))
        ComboBox1.FlatStyle = FlatStyle.Flat
        ComboBox1.ForeColor = Color.White
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"v1.3.0 (Nightly 6/16/2023)", "v1.3.0 (Nightly 6/15/2023)", "v1.2.5 (Nightly 6/11/2023)", "v1.2.5 (Stable)", "v1.2.0u (LTS) [Recommended]", "v1.2.0 (Stable)", "v1.1.0", "v1.0.2"})
        ComboBox1.Location = New Point(149, 128)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(238, 23)
        ComboBox1.TabIndex = 2
        ComboBox1.Text = "Long Term Support Option"
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.ActiveLinkColor = Color.White
        LinkLabel1.AutoSize = True
        LinkLabel1.LinkColor = Color.White
        LinkLabel1.Location = New Point(96, 260)
        LinkLabel1.Name = "LinkLabel1"
        LinkLabel1.Size = New Size(161, 15)
        LinkLabel1.TabIndex = 3
        LinkLabel1.TabStop = True
        LinkLabel1.Text = "What Version is right for you?"
        LinkLabel1.VisitedLinkColor = Color.White
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(52, 131)
        Label2.Name = "Label2"
        Label2.Size = New Size(91, 15)
        Label2.TabIndex = 4
        Label2.Text = "Select a Version:"
        ' 
        ' panel1
        ' 
        panel1.Controls.Add(pictureBox1)
        panel1.Controls.Add(Button3)
        panel1.Controls.Add(Button5)
        panel1.Controls.Add(Label9)
        panel1.Dock = DockStyle.Top
        panel1.Location = New Point(0, 0)
        panel1.Name = "panel1"
        panel1.Size = New Size(482, 29)
        panel1.TabIndex = 5
        ' 
        ' pictureBox1
        ' 
        pictureBox1.Image = My.Resources.Resources.z1g
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
        Button3.Location = New Point(444, 3)
        Button3.Name = "Button3"
        Button3.Size = New Size(35, 23)
        Button3.TabIndex = 13
        Button3.Text = "X"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Button5
        ' 
        Button5.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button5.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(45))
        Button5.FlatAppearance.BorderSize = 0
        Button5.FlatStyle = FlatStyle.Flat
        Button5.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
        Button5.Location = New Point(403, 3)
        Button5.Name = "Button5"
        Button5.Size = New Size(35, 23)
        Button5.TabIndex = 12
        Button5.Text = "-"
        Button5.UseVisualStyleBackColor = False
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label9.Location = New Point(39, 5)
        Label9.Name = "Label9"
        Label9.Size = New Size(159, 21)
        Label9.TabIndex = 11
        Label9.Text = "z1g Setup Launcher"
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(45))
        Button2.FlatStyle = FlatStyle.Flat
        Button2.ForeColor = Color.White
        Button2.Location = New Point(359, 254)
        Button2.Name = "Button2"
        Button2.Size = New Size(123, 26)
        Button2.TabIndex = 6
        Button2.Text = "Download Installer"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        ClientSize = New Size(482, 281)
        Controls.Add(Button2)
        Controls.Add(panel1)
        Controls.Add(Label2)
        Controls.Add(LinkLabel1)
        Controls.Add(ComboBox1)
        Controls.Add(Button1)
        Controls.Add(Label1)
        ForeColor = Color.White
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "z1g Setup Launcher"
        panel1.ResumeLayout(False)
        panel1.PerformLayout()
        CType(pictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Label2 As Label
    Private WithEvents panel1 As Panel
    Private WithEvents pictureBox1 As PictureBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Button2 As Button
End Class
