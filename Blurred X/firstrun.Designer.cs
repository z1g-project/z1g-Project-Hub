namespace Terbium
{
    partial class firstrun
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(firstrun));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            Button3 = new Button();
            Button2 = new Button();
            Label9 = new Label();
            Button1 = new Button();
            Label5 = new Label();
            PictureBox3 = new PictureBox();
            Label3 = new Label();
            PictureBox2 = new PictureBox();
            Label4 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(Button3);
            panel1.Controls.Add(Button2);
            panel1.Controls.Add(Label9);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(530, 29);
            panel1.TabIndex = 37;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Blurred_X.Properties.Resources.bx;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 24);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // Button3
            // 
            Button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Button3.BackColor = Color.FromArgb(64, 0, 0);
            Button3.FlatAppearance.BorderSize = 0;
            Button3.FlatStyle = FlatStyle.Flat;
            Button3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            Button3.Location = new Point(492, 3);
            Button3.Name = "Button3";
            Button3.Size = new Size(35, 23);
            Button3.TabIndex = 13;
            Button3.Text = "X";
            Button3.UseVisualStyleBackColor = false;
            Button3.Click += Button3_Click;
            // 
            // Button2
            // 
            Button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Button2.BackColor = Color.FromArgb(45, 45, 45);
            Button2.FlatAppearance.BorderSize = 0;
            Button2.FlatStyle = FlatStyle.Flat;
            Button2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            Button2.Location = new Point(451, 3);
            Button2.Name = "Button2";
            Button2.Size = new Size(35, 23);
            Button2.TabIndex = 12;
            Button2.Text = "-";
            Button2.UseVisualStyleBackColor = false;
            Button2.Click += Button2_Click;
            // 
            // Label9
            // 
            Label9.AutoSize = true;
            Label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Label9.Location = new Point(39, 2);
            Label9.Name = "Label9";
            Label9.Size = new Size(199, 21);
            Label9.TabIndex = 11;
            Label9.Text = "Blurred X First-Run Setup";
            // 
            // Button1
            // 
            Button1.BackColor = Color.FromArgb(45, 45, 45);
            Button1.FlatAppearance.BorderSize = 0;
            Button1.FlatStyle = FlatStyle.Flat;
            Button1.Location = new Point(421, 218);
            Button1.Name = "Button1";
            Button1.Size = new Size(97, 32);
            Button1.TabIndex = 40;
            Button1.Text = "Apply";
            Button1.UseVisualStyleBackColor = false;
            Button1.Click += Button1_Click;
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label5.Location = new Point(248, 169);
            Label5.Name = "Label5";
            Label5.Size = new Size(139, 21);
            Label5.TabIndex = 49;
            Label5.Text = "Enter your own url";
            Label5.Click += Label5_Click;
            // 
            // PictureBox3
            // 
            PictureBox3.Image = Blurred_X.Properties.Resources.bx;
            PictureBox3.Location = new Point(267, 97);
            PictureBox3.Name = "PictureBox3";
            PictureBox3.Size = new Size(91, 69);
            PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox3.TabIndex = 48;
            PictureBox3.TabStop = false;
            PictureBox3.Click += PictureBox3_Click;
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label3.Location = new Point(157, 169);
            Label3.Name = "Label3";
            Label3.Size = new Size(72, 21);
            Label3.TabIndex = 47;
            Label3.Text = "Self Host";
            Label3.Click += Label3_Click;
            // 
            // PictureBox2
            // 
            PictureBox2.Image = Blurred_X.Properties.Resources.bx;
            PictureBox2.Location = new Point(147, 97);
            PictureBox2.Name = "PictureBox2";
            PictureBox2.Size = new Size(91, 69);
            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox2.TabIndex = 46;
            PictureBox2.TabStop = false;
            PictureBox2.Click += PictureBox2_Click;
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);
            Label4.Location = new Point(125, 53);
            Label4.Name = "Label4";
            Label4.Size = new Size(252, 25);
            Label4.TabIndex = 50;
            Label4.Text = "Select a Version to Continue";
            // 
            // firstrun
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(530, 262);
            Controls.Add(Label4);
            Controls.Add(Label5);
            Controls.Add(PictureBox3);
            Controls.Add(Label3);
            Controls.Add(PictureBox2);
            Controls.Add(Button1);
            Controls.Add(panel1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "firstrun";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blurred X First-Run Setup";
            TopMost = true;
            Load += firstrun_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        internal Button Button3;
        internal Button Button2;
        internal Label Label9;
        internal Button Button1;
        internal Label Label5;
        internal PictureBox PictureBox3;
        internal Label Label3;
        internal PictureBox PictureBox2;
        internal Label Label4;
    }
}