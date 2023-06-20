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
        LabelAppName = New Label()
        panel1 = New Panel()
        pictureBox1 = New PictureBox()
        Button3 = New Button()
        Button2 = New Button()
        Label9 = New Label()
        Label1 = New Label()
        LabelDescription = New Label()
        LabelDiskSpace = New Label()
        ButtonInstall = New Button()
        panel1.SuspendLayout()
        CType(pictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LabelAppName
        ' 
        LabelAppName.AutoSize = True
        LabelAppName.Font = New Font("Segoe UI Semibold", 18.75F, FontStyle.Bold, GraphicsUnit.Point)
        LabelAppName.Location = New Point(39, 121)
        LabelAppName.Name = "LabelAppName"
        LabelAppName.Size = New Size(182, 35)
        LabelAppName.TabIndex = 0
        LabelAppName.Text = "Package Name"
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
        panel1.Size = New Size(617, 29)
        panel1.TabIndex = 2
        ' 
        ' pictureBox1
        ' 
        pictureBox1.Image = My.Resources.Resources.ms_appinstaller
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
        Button3.Location = New Point(579, 3)
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
        Button2.Location = New Point(538, 3)
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
        Label9.Location = New Point(39, 5)
        Label9.Name = "Label9"
        Label9.Size = New Size(171, 21)
        Label9.TabIndex = 11
        Label9.Text = "z1g Package Installer"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(26, 47)
        Label1.Name = "Label1"
        Label1.Size = New Size(334, 45)
        Label1.TabIndex = 3
        Label1.Text = "z1g Package Installer"
        ' 
        ' LabelDescription
        ' 
        LabelDescription.AutoSize = True
        LabelDescription.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point)
        LabelDescription.Location = New Point(49, 171)
        LabelDescription.Name = "LabelDescription"
        LabelDescription.Size = New Size(200, 30)
        LabelDescription.TabIndex = 4
        LabelDescription.Text = "Package Description"
        ' 
        ' LabelDiskSpace
        ' 
        LabelDiskSpace.AutoSize = True
        LabelDiskSpace.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        LabelDiskSpace.Location = New Point(66, 219)
        LabelDiskSpace.Name = "LabelDiskSpace"
        LabelDiskSpace.Size = New Size(102, 25)
        LabelDiskSpace.TabIndex = 5
        LabelDiskSpace.Text = "Disk Space"
        ' 
        ' ButtonInstall
        ' 
        ButtonInstall.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ButtonInstall.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(35))
        ButtonInstall.FlatAppearance.BorderSize = 0
        ButtonInstall.FlatStyle = FlatStyle.Flat
        ButtonInstall.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonInstall.Location = New Point(512, 378)
        ButtonInstall.Name = "ButtonInstall"
        ButtonInstall.Size = New Size(93, 36)
        ButtonInstall.TabIndex = 29
        ButtonInstall.Text = "Install"
        ButtonInstall.UseVisualStyleBackColor = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        ClientSize = New Size(617, 426)
        Controls.Add(ButtonInstall)
        Controls.Add(LabelDiskSpace)
        Controls.Add(LabelDescription)
        Controls.Add(Label1)
        Controls.Add(panel1)
        Controls.Add(LabelAppName)
        ForeColor = Color.White
        FormBorderStyle = FormBorderStyle.None
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "z1g Package Installer"
        panel1.ResumeLayout(False)
        panel1.PerformLayout()
        CType(pictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LabelAppName As Label
    Private WithEvents panel1 As Panel
    Private WithEvents pictureBox1 As PictureBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelDescription As Label
    Friend WithEvents LabelDiskSpace As Label
    Friend WithEvents ButtonInstall As Button
End Class
