using CefSharp.WinForms;
using CefSharp;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace z1g_Browser
{
    public partial class Form1 : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        public Form1()
        {
            InitializeComponent();

            if (Cef.IsInitialized)
            {

            }
            else
            {
                CefSettings settings = new CefSettings();
                settings.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) z1g Browser/114.1.4.0 Safari/537.36 z1g Browser/114.1.4.0";
                string path = ("C://z1g Apps//z1g Browser//Data//");
                settings.RemoteDebuggingPort = 8080;
                settings.CachePath = path;
                Cef.Initialize(settings);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private static void Browser_LoadError(object sender, LoadErrorEventArgs e)
        {
            // Check if the error code indicates a failed DNS resolution
            if (e.ErrorCode == CefErrorCode.DnsRequestCancelled)
            {
                // Load a custom HTML error page
                var errorPagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error.html");
                ((ChromiumWebBrowser)sender).LoadHtml(File.ReadAllText(errorPagePath), "C://RWOS2//App Data//RW Browser//13//Pages//dnsreqcancled.html");
            }
        }

        private void ComboBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                chromiumWebBrowser1.Load(comboBox1.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Load(comboBox1.Text);
            if (comboBox1.Text.Equals("https://terbium-46q.pages.dev"))
            {
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Load("https://google.com");
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
            chromiumWebBrowser1.Refresh();
            button1.BackColor = Color.DodgerBlue;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal; // Restore the window if it's maximized
            }
            else
            {
                WindowState = FormWindowState.Maximized; // Maximize the window if it's not already maximized
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Cef.Shutdown();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}