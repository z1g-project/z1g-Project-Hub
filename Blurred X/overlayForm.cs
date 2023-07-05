using CefSharp;
using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Terbium
{
    public partial class overlayForm : Form
    {
        private Bitmap overlayImage;

        public overlayForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.ShowInTaskbar = false;
            this.BackColor = Color.Magenta;
            this.TransparencyKey = this.BackColor;
            this.Size = new Size(400, 300);

            // Load the overlay image with transparency
            //overlayImage = new Bitmap(Properties.Resources.overlay_v2);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw the overlay image on the form's surface
            e.Graphics.DrawImage(overlayImage, Point.Empty);
        }

        private void overlayForm_Load(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Load("https://google.com");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Back();
            button4.BackColor = Color.DodgerBlue;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Forward();
            button1.BackColor = Color.DodgerBlue;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Stop();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Forward();
            button1.BackColor = Color.DodgerBlue;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Stop();
            panel3.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Load(comboBox1.Text);
        }

        private void ComboBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                chromiumWebBrowser1.Load(comboBox1.Text);
        }

        private void chromiumWebBrowser1_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            // Execute the UI-related code on the main UI thread
            Invoke(new Action(() =>
            {
                comboBox1.Text = chromiumWebBrowser1.Address;
                comboBox1.Items.Add(chromiumWebBrowser1.Address);
                //ListBox1.Items.Add(chromiumWebBrowser1.Text);
                button1.BackColor = Color.DodgerBlue;

                // Check if the webpage is secure (HTTPS)
                bool isSecure = false;
                if (Uri.TryCreate(chromiumWebBrowser1.Address, UriKind.Absolute, out Uri uri))
                {
                    isSecure = uri.Scheme.Equals("https", StringComparison.OrdinalIgnoreCase);
                }

                if (isSecure)
                {
                    label1.ForeColor = Color.Green;
                    label1.Text = "🔒 Secure";
                }
                else
                {
                    label1.ForeColor = Color.Red;
                    label1.Text = "🔓 Un-Secure";
                }
            }));
        }

        private void label4_Click(object sender, EventArgs e)
        {
            string url = "https://classroom.google.com";
            Process.Start(url);
            this.WindowState = FormWindowState.Minimized;
            //form1.WindowState = FormWindowState.Minimized;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cef.Shutdown();
            this.Close();
        }
    }
}
