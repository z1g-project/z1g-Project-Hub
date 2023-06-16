namespace Terbium
{
    partial class getupdates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(getupdates));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            Button3 = new Button();
            Button2 = new Button();
            Label9 = new Label();
            textBox1 = new TextBox();
            Label2 = new Label();
            Label1 = new Label();
            Button4 = new Button();
            Button1 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            panel1.Size = new Size(712, 29);
            panel1.TabIndex = 1;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = BruhProx.Properties.Resources.uv;
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
            Button3.Location = new Point(674, 3);
            Button3.Name = "Button3";
            Button3.Size = new Size(35, 23);
            Button3.TabIndex = 13;
            Button3.Text = "X";
            Button3.UseVisualStyleBackColor = false;
            Button3.Click += Button3_Click_1;
            // 
            // Button2
            // 
            Button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Button2.BackColor = Color.FromArgb(45, 45, 45);
            Button2.FlatAppearance.BorderSize = 0;
            Button2.FlatStyle = FlatStyle.Flat;
            Button2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            Button2.Location = new Point(633, 3);
            Button2.Name = "Button2";
            Button2.Size = new Size(35, 23);
            Button2.TabIndex = 12;
            Button2.Text = "-";
            Button2.UseVisualStyleBackColor = false;
            Button2.Click += Button2_Click_1;
            // 
            // Label9
            // 
            Label9.AutoSize = true;
            Label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Label9.Location = new Point(39, 5);
            Label9.Name = "Label9";
            Label9.Size = new Size(147, 21);
            Label9.TabIndex = 11;
            Label9.Text = "BruhProx Updater";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(24, 24, 24);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(12, 106);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(688, 338);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            Label2.Location = new Point(53, 81);
            Label2.Name = "Label2";
            Label2.Size = new Size(284, 17);
            Label2.TabIndex = 21;
            Label2.Text = "A new version of BruhProx is waiting for you!";
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            Label1.Location = new Point(21, 32);
            Label1.Name = "Label1";
            Label1.Size = new Size(280, 45);
            Label1.TabIndex = 20;
            Label1.Text = "BruhProx Update";
            // 
            // Button4
            // 
            Button4.BackColor = Color.FromArgb(45, 45, 45);
            Button4.FlatAppearance.BorderSize = 0;
            Button4.FlatStyle = FlatStyle.Flat;
            Button4.Location = new Point(500, 450);
            Button4.Name = "Button4";
            Button4.Size = new Size(97, 32);
            Button4.TabIndex = 23;
            Button4.Text = "Install later";
            Button4.UseVisualStyleBackColor = false;
            Button4.Click += Button4_Click_1;
            // 
            // Button1
            // 
            Button1.BackColor = Color.FromArgb(45, 45, 45);
            Button1.FlatAppearance.BorderSize = 0;
            Button1.FlatStyle = FlatStyle.Flat;
            Button1.Location = new Point(603, 450);
            Button1.Name = "Button1";
            Button1.Size = new Size(97, 32);
            Button1.TabIndex = 22;
            Button1.Text = "Update";
            Button1.UseVisualStyleBackColor = false;
            Button1.Click += Button1_Click_1;
            // 
            // getupdates
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(712, 489);
            Controls.Add(Button4);
            Controls.Add(Button1);
            Controls.Add(Label2);
            Controls.Add(Label1);
            Controls.Add(textBox1);
            Controls.Add(panel1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "getupdates";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BruhProx Updater";
            TopMost = true;
            Load += getupdates_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        internal Button Button3;
        internal Button Button2;
        internal Label Label9;
        private TextBox textBox1;
        internal Label Label2;
        internal Label Label1;
        internal Button Button4;
        internal Button Button1;
    }
}