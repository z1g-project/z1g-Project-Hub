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
            button4 = new Button();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            Button3 = new Button();
            Button2 = new Button();
            Label9 = new Label();
            chromiumWebBrowser1 = new CefSharp.WinForms.ChromiumWebBrowser();
            panel1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.ContextMenuStrip = contextMenuStrip1;
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
            Label9.Size = new Size(81, 21);
            Label9.TabIndex = 11;
            Label9.Text = "BruhProx";
            // 
            // chromiumWebBrowser1
            // 
            chromiumWebBrowser1.ActivateBrowserOnCreation = false;
            chromiumWebBrowser1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chromiumWebBrowser1.ContextMenuStrip = contextMenuStrip1;
            chromiumWebBrowser1.Location = new Point(0, 29);
            chromiumWebBrowser1.Name = "chromiumWebBrowser1";
            chromiumWebBrowser1.Size = new Size(1028, 635);
            chromiumWebBrowser1.TabIndex = 1;
            // 
            // form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(1028, 664);
            Controls.Add(chromiumWebBrowser1);
            Controls.Add(panel1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BruhProx";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        internal Button Button3;
        internal Button Button2;
        internal Label Label9;
        private CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser1;
        internal Button button1;
        internal Button button4;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem backToolStripMenuItem;
        private ToolStripMenuItem forwardToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem inspectToolStripMenuItem;
        private ToolStripMenuItem resetSessionToolStripMenuItem;
    }
}