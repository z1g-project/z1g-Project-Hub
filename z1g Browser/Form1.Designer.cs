namespace z1g_Browser
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            button9 = new Button();
            pictureBox1 = new PictureBox();
            Button3 = new Button();
            Button2 = new Button();
            Label9 = new Label();
            panel2 = new Panel();
            comboBox1 = new ComboBox();
            button8 = new Button();
            button7 = new Button();
            label1 = new Label();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button1 = new Button();
            tabPage1 = new TabPage();
            chromiumWebBrowser1 = new CefSharp.WinForms.ChromiumWebBrowser();
            tabControl1 = new TabControl();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            tabPage1.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button9);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(Button3);
            panel1.Controls.Add(Button2);
            panel1.Controls.Add(Label9);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1315, 29);
            panel1.TabIndex = 1;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // button9
            // 
            button9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button9.BackColor = Color.FromArgb(45, 45, 45);
            button9.FlatAppearance.BorderSize = 0;
            button9.FlatStyle = FlatStyle.Flat;
            button9.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            button9.Location = new Point(1201, 3);
            button9.Name = "button9";
            button9.Size = new Size(35, 23);
            button9.TabIndex = 13;
            button9.Text = "-";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.z1g;
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
            Button3.Location = new Point(1277, 3);
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
            Button2.Location = new Point(1239, 3);
            Button2.Name = "Button2";
            Button2.Size = new Size(35, 23);
            Button2.TabIndex = 12;
            Button2.Text = "[]";
            Button2.UseVisualStyleBackColor = false;
            Button2.Click += Button2_Click;
            // 
            // Label9
            // 
            Label9.AutoSize = true;
            Label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Label9.Location = new Point(39, 5);
            Label9.Name = "Label9";
            Label9.Size = new Size(102, 21);
            Label9.TabIndex = 11;
            Label9.Text = "z1g Browser";
            // 
            // panel2
            // 
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(button8);
            panel2.Controls.Add(button7);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(button6);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 29);
            panel2.Name = "panel2";
            panel2.Size = new Size(1315, 37);
            panel2.TabIndex = 2;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.BackColor = Color.FromArgb(37, 37, 37);
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.ForeColor = Color.White;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(255, 7);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(975, 23);
            comboBox1.TabIndex = 5;
            comboBox1.Text = "https://google.com";
            comboBox1.KeyPress += ComboBox1_KeyPress_1;
            // 
            // button8
            // 
            button8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button8.BackColor = Color.FromArgb(37, 37, 37);
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Location = new Point(1236, 6);
            button8.Name = "button8";
            button8.Size = new Size(35, 23);
            button8.TabIndex = 4;
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
            button7.Location = new Point(1277, 6);
            button7.Name = "button7";
            button7.Size = new Size(35, 23);
            button7.TabIndex = 4;
            button7.Text = "...";
            button7.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Green;
            label1.Location = new Point(176, 10);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 4;
            label1.Text = "🔒Secure";
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(37, 37, 37);
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Location = new Point(135, 6);
            button6.Name = "button6";
            button6.Size = new Size(35, 23);
            button6.TabIndex = 3;
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
            button5.Location = new Point(94, 6);
            button5.Name = "button5";
            button5.Size = new Size(35, 23);
            button5.TabIndex = 3;
            button5.Text = "X";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(37, 37, 37);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(53, 6);
            button4.Name = "button4";
            button4.Size = new Size(35, 23);
            button4.TabIndex = 3;
            button4.Text = ">";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(37, 37, 37);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(12, 6);
            button1.Name = "button1";
            button1.Size = new Size(35, 23);
            button1.TabIndex = 0;
            button1.Text = "<";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(24, 24, 24);
            tabPage1.Controls.Add(chromiumWebBrowser1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1307, 665);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Home";
            // 
            // chromiumWebBrowser1
            // 
            chromiumWebBrowser1.ActivateBrowserOnCreation = false;
            chromiumWebBrowser1.Dock = DockStyle.Fill;
            chromiumWebBrowser1.Location = new Point(3, 3);
            chromiumWebBrowser1.Name = "chromiumWebBrowser1";
            chromiumWebBrowser1.Size = new Size(1301, 659);
            chromiumWebBrowser1.TabIndex = 0;
            chromiumWebBrowser1.AddressChanged += chromiumWebBrowser1_AddressChanged;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 66);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1315, 693);
            tabControl1.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(1315, 759);
            Controls.Add(tabControl1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "z1g Browser";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        internal Button Button3;
        internal Button Button2;
        internal Label Label9;
        private Panel panel2;
        private ComboBox comboBox1;
        private Button button8;
        private Button button7;
        private Label label1;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button1;
        private TabPage tabPage1;
        internal Button button9;
        public CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser1;
        public TabControl tabControl1;
    }
}