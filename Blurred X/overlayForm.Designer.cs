namespace Terbium
{
    partial class overlayForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(overlayForm));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panel1 = new Panel();
            label2 = new Label();
            panel2 = new Panel();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label7 = new Label();
            label8 = new Label();
            panel3 = new Panel();
            chromiumWebBrowser1 = new CefSharp.WinForms.ChromiumWebBrowser();
            panel4 = new Panel();
            comboBox1 = new ComboBox();
            button8 = new Button();
            button7 = new Button();
            label10 = new Label();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button1 = new Button();
            Button3 = new Button();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(80, 73);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(91, 9);
            label1.Name = "label1";
            label1.Size = new Size(168, 32);
            label1.TabIndex = 1;
            label1.Text = "%username%";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 64, 0);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(317, 79);
            panel1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(107, 41);
            label2.Name = "label2";
            label2.Size = new Size(118, 21);
            label2.TabIndex = 2;
            label2.Text = "Using Blurred X";
            // 
            // panel2
            // 
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(panel1);
            panel2.Location = new Point(12, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(320, 618);
            panel2.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(74, 224);
            label6.Name = "label6";
            label6.Size = new Size(167, 25);
            label6.TabIndex = 6;
            label6.Text = "Close All z1g Apps";
            label6.Click += label6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(23, 190);
            label5.Name = "label5";
            label5.Size = new Size(284, 25);
            label5.TabIndex = 5;
            label5.Text = "Open z1g Hub Big Picture (Beta)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(58, 156);
            label4.Name = "label4";
            label4.Size = new Size(218, 25);
            label4.TabIndex = 4;
            label4.Text = "Open Google Classroom";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(50, 98);
            label3.Name = "label3";
            label3.Size = new Size(226, 45);
            label3.TabIndex = 3;
            label3.Text = "Quick Actions";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(1575, 24);
            label7.Name = "label7";
            label7.Size = new Size(320, 86);
            label7.TabIndex = 4;
            label7.Text = "12:00 PM";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(1662, 110);
            label8.Name = "label8";
            label8.Size = new Size(152, 47);
            label8.TabIndex = 5;
            label8.Text = "1/1/2023";
            // 
            // panel3
            // 
            panel3.Controls.Add(chromiumWebBrowser1);
            panel3.Controls.Add(panel4);
            panel3.Location = new Point(476, 214);
            panel3.Name = "panel3";
            panel3.Size = new Size(1013, 620);
            panel3.TabIndex = 6;
            // 
            // chromiumWebBrowser1
            // 
            chromiumWebBrowser1.ActivateBrowserOnCreation = false;
            chromiumWebBrowser1.Dock = DockStyle.Fill;
            chromiumWebBrowser1.Location = new Point(0, 31);
            chromiumWebBrowser1.Name = "chromiumWebBrowser1";
            chromiumWebBrowser1.Size = new Size(1013, 589);
            chromiumWebBrowser1.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Controls.Add(comboBox1);
            panel4.Controls.Add(button8);
            panel4.Controls.Add(button7);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(button6);
            panel4.Controls.Add(button5);
            panel4.Controls.Add(button4);
            panel4.Controls.Add(button1);
            panel4.Controls.Add(Button3);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1013, 31);
            panel4.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.BackColor = Color.FromArgb(37, 37, 37);
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.ForeColor = Color.White;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(247, 5);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(640, 23);
            comboBox1.TabIndex = 19;
            comboBox1.Text = "https://google.com";
            // 
            // button8
            // 
            button8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button8.BackColor = Color.FromArgb(37, 37, 37);
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Location = new Point(893, 3);
            button8.Name = "button8";
            button8.Size = new Size(35, 23);
            button8.TabIndex = 16;
            button8.Text = "G";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // button7
            // 
            button7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button7.BackColor = Color.FromArgb(37, 37, 37);
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Location = new Point(934, 3);
            button7.Name = "button7";
            button7.Size = new Size(35, 23);
            button7.TabIndex = 17;
            button7.Text = "...";
            button7.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.Green;
            label10.Location = new Point(165, 8);
            label10.Name = "label10";
            label10.Size = new Size(62, 15);
            label10.TabIndex = 18;
            label10.Text = "🔒 Secure";
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(37, 37, 37);
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Location = new Point(127, 4);
            button6.Name = "button6";
            button6.Size = new Size(35, 23);
            button6.TabIndex = 13;
            button6.Text = "R";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(37, 37, 37);
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.ForeColor = Color.Red;
            button5.Location = new Point(86, 4);
            button5.Name = "button5";
            button5.Size = new Size(35, 23);
            button5.TabIndex = 14;
            button5.Text = "X";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(37, 37, 37);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(45, 4);
            button4.Name = "button4";
            button4.Size = new Size(35, 23);
            button4.TabIndex = 15;
            button4.Text = ">";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(37, 37, 37);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(4, 4);
            button1.Name = "button1";
            button1.Size = new Size(35, 23);
            button1.TabIndex = 12;
            button1.Text = "<";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Button3
            // 
            Button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Button3.BackColor = Color.FromArgb(64, 0, 0);
            Button3.FlatAppearance.BorderSize = 0;
            Button3.FlatStyle = FlatStyle.Flat;
            Button3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            Button3.Location = new Point(975, 3);
            Button3.Name = "Button3";
            Button3.Size = new Size(35, 23);
            Button3.TabIndex = 11;
            Button3.Text = "X";
            Button3.UseVisualStyleBackColor = false;
            Button3.Click += Button3_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(1715, 1046);
            label9.Name = "label9";
            label9.Size = new Size(193, 25);
            label9.TabIndex = 7;
            label9.Text = "Terbium v2.0.0 (LTS)";
            // 
            // overlayForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(1920, 1080);
            Controls.Add(label9);
            Controls.Add(panel3);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(panel2);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "overlayForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "z1g Overlay";
            TopMost = true;
            WindowState = FormWindowState.Maximized;
            Load += overlayForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Panel panel1;
        private Label label2;
        private Panel panel2;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label7;
        private Label label8;
        private Panel panel3;
        private Label label9;
        private CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser1;
        private Panel panel4;
        internal Button Button3;
        private ComboBox comboBox1;
        private Button button8;
        private Button button7;
        private Label label10;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button1;
    }
}