namespace Terbium
{
    partial class form1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form1));
            panel1 = new Panel();
            contextMenuStrip1 = new ContextMenuStrip(components);
            backToolStripMenuItem = new ToolStripMenuItem();
            forwardToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            inspectToolStripMenuItem = new ToolStripMenuItem();
            resetSessionToolStripMenuItem = new ToolStripMenuItem();
            button5 = new Button();
            button4 = new Button();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            Button3 = new Button();
            Button2 = new Button();
            Label9 = new Label();
            chromiumWebBrowser1 = new CefSharp.WinForms.ChromiumWebBrowser();
            panel2 = new Panel();
            textBox3 = new TextBox();
            label18 = new Label();
            button19 = new Button();
            pictureBox2 = new PictureBox();
            label3 = new Label();
            panel1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.ContextMenuStrip = contextMenuStrip1;
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(Button3);
            panel1.Controls.Add(Button2);
            panel1.Controls.Add(Label9);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1028, 29);
            panel1.TabIndex = 0;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.BackColor = Color.FromArgb(34, 34, 34);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { backToolStripMenuItem, forwardToolStripMenuItem, toolStripSeparator1, inspectToolStripMenuItem, resetSessionToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(145, 98);
            // 
            // backToolStripMenuItem
            // 
            backToolStripMenuItem.ForeColor = Color.White;
            backToolStripMenuItem.Name = "backToolStripMenuItem";
            backToolStripMenuItem.Size = new Size(144, 22);
            backToolStripMenuItem.Text = "Back";
            backToolStripMenuItem.Click += backToolStripMenuItem_Click;
            // 
            // forwardToolStripMenuItem
            // 
            forwardToolStripMenuItem.ForeColor = Color.White;
            forwardToolStripMenuItem.Name = "forwardToolStripMenuItem";
            forwardToolStripMenuItem.Size = new Size(144, 22);
            forwardToolStripMenuItem.Text = "Forward";
            forwardToolStripMenuItem.Click += forwardToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.ForeColor = Color.White;
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(141, 6);
            // 
            // inspectToolStripMenuItem
            // 
            inspectToolStripMenuItem.ForeColor = Color.White;
            inspectToolStripMenuItem.Name = "inspectToolStripMenuItem";
            inspectToolStripMenuItem.Size = new Size(144, 22);
            inspectToolStripMenuItem.Text = "Inspect";
            inspectToolStripMenuItem.Click += inspectToolStripMenuItem_Click;
            // 
            // resetSessionToolStripMenuItem
            // 
            resetSessionToolStripMenuItem.ForeColor = Color.White;
            resetSessionToolStripMenuItem.Name = "resetSessionToolStripMenuItem";
            resetSessionToolStripMenuItem.Size = new Size(144, 22);
            resetSessionToolStripMenuItem.Text = "Reset Session";
            resetSessionToolStripMenuItem.Click += resetSessionToolStripMenuItem_Click;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button5.BackColor = Color.FromArgb(45, 45, 45);
            button5.BackgroundImage = Blurred_X.Properties.Resources.nodejs;
            button5.BackgroundImageLayout = ImageLayout.Zoom;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            button5.Location = new Point(837, 3);
            button5.Name = "button5";
            button5.Size = new Size(35, 23);
            button5.TabIndex = 14;
            button5.Text = "JS";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.BackColor = Color.FromArgb(45, 45, 45);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(874, 3);
            button4.Name = "button4";
            button4.Size = new Size(35, 23);
            button4.TabIndex = 13;
            button4.Text = "⚙️";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(45, 45, 45);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(952, 3);
            button1.Name = "button1";
            button1.Size = new Size(35, 23);
            button1.TabIndex = 15;
            button1.Text = "[]";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
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
            Button3.Location = new Point(990, 3);
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
            Button2.Location = new Point(915, 3);
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
            Label9.Location = new Point(39, 5);
            Label9.Name = "Label9";
            Label9.Size = new Size(80, 21);
            Label9.TabIndex = 11;
            Label9.Text = "Blurred X";
            // 
            // chromiumWebBrowser1
            // 
            chromiumWebBrowser1.ActivateBrowserOnCreation = false;
            chromiumWebBrowser1.Dock = DockStyle.Fill;
            chromiumWebBrowser1.Location = new Point(0, 29);
            chromiumWebBrowser1.Name = "chromiumWebBrowser1";
            chromiumWebBrowser1.Size = new Size(1028, 635);
            chromiumWebBrowser1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(label18);
            panel2.Controls.Add(button19);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(183, 148);
            panel2.Name = "panel2";
            panel2.Size = new Size(666, 424);
            panel2.TabIndex = 2;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(34, 34, 34);
            textBox3.ForeColor = Color.White;
            textBox3.Location = new Point(3, 70);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ScrollBars = ScrollBars.Vertical;
            textBox3.Size = new Size(660, 351);
            textBox3.TabIndex = 55;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label18.Location = new Point(21, 30);
            label18.Name = "label18";
            label18.Size = new Size(181, 37);
            label18.TabIndex = 42;
            label18.Text = "NodeJS Logs";
            // 
            // button19
            // 
            button19.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button19.BackColor = Color.FromArgb(64, 0, 0);
            button19.FlatAppearance.BorderSize = 0;
            button19.FlatStyle = FlatStyle.Flat;
            button19.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            button19.Location = new Point(628, 4);
            button19.Name = "button19";
            button19.Size = new Size(35, 23);
            button19.TabIndex = 41;
            button19.Text = "X";
            button19.UseVisualStyleBackColor = false;
            button19.Click += button19_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Blurred_X.Properties.Resources.nodejs;
            pictureBox2.Location = new Point(3, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 24);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 40;
            pictureBox2.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(39, 2);
            label3.Name = "label3";
            label3.Size = new Size(107, 21);
            label3.TabIndex = 39;
            label3.Text = "NodeJS Logs";
            // 
            // form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(1028, 664);
            Controls.Add(panel2);
            Controls.Add(chromiumWebBrowser1);
            Controls.Add(panel1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blurred X";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        internal Button Button3;
        internal Button Button2;
        internal Label Label9;
        internal Button button1;
        internal Button button4;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem backToolStripMenuItem;
        private ToolStripMenuItem forwardToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem inspectToolStripMenuItem;
        private ToolStripMenuItem resetSessionToolStripMenuItem;
        private CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser1;
        internal Button button5;
        private Panel panel2;
        internal Label label18;
        internal Button button19;
        private PictureBox pictureBox2;
        internal Label label3;
        private TextBox textBox3;
    }
}