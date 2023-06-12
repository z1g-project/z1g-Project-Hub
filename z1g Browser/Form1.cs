using CefSharp.WinForms;
using CefSharp;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.Devices;
using System.Net;
using CefSharp.Handler;
using Microsoft.VisualBasic.ApplicationServices;

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
                settings.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/94.0.4606.81 Safari/537.36 z1g Browser/114.1.4.0";
                string path = "C://z1g Apps//z1g Browser//Data//";
                settings.RemoteDebuggingPort = 8080;
                settings.CachePath = path;
                settings.CefCommandLineArgs.Add("enable-system-flash", "1");
                settings.CefCommandLineArgs.Add("allow-file-access-from-files", "1");

                string extensionPath = "C://z1g Apps//z1g Browser//Extensions";
                settings.CefCommandLineArgs.Add("load-extension", extensionPath);

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
            if (comboBox1.Text.Equals("https://terbium-46q.pages.dev/") || comboBox1.Text.Contains("https://terbium-46q.pages.dev"))
            {
                applauncher applauncher = new applauncher();
                applauncher.label1.Text = "Would you like to Launch Terbium?";
                applauncher.label2.Text = "It appears that your trying to access Terbium which can be \r\ninstalled or opened from your computer.";
                if (File.Exists("C:\\z1g Apps\\Terbium\\Terbium.exe")) 
                {
                    applauncher.textBox1.Text = "C:\\z1g Apps\\Terbium\\Terbium.exe";
                }
                else
                {
                    string fileUrl = "https://cdn.z1g-project.repl.co/z1g-hub/client/Terbium-bootstrap.exe";
                    string savePath = "C:\\z1g Apps\\Terbium\\terbium-bootstraper.exe";

                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(fileUrl, savePath);
                    }

                    applauncher.textBox1.Text = "C:\\z1g Apps\\Terbium\\terbium-bootstraper.exe";
                }
                applauncher.Show();
            }
            if (comboBox1.Text.Equals("https://terbium.johnglynn2.repl.co") || comboBox1.Text.Contains("https://terbium.johnglynn2.repl.co"))
            {
                applauncher applauncher = new applauncher();
                applauncher.label1.Text = "Would you like to Launch Terbium?";
                applauncher.label2.Text = "It appears that your trying to access Terbium which can be \r\ninstalled or opened from your computer.";
                if (File.Exists("C:\\z1g Apps\\Terbium\\Terbium.exe"))
                {
                    applauncher.textBox1.Text = "C:\\z1g Apps\\Terbium\\Terbium.exe";
                }
                else
                {
                    string fileUrl = "https://cdn.z1g-project.repl.co/z1g-hub/client/Terbium-bootstrap.exe";
                    string savePath = "C:\\z1g Apps\\Terbium\\terbium-bootstraper.exe";

                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(fileUrl, savePath);
                    }

                    applauncher.textBox1.Text = "C:\\z1g Apps\\Terbium\\terbium-bootstraper.exe";
                }
                applauncher.Show();
            }
            if (comboBox1.Text.Equals("https://velocity.radon.games") || comboBox1.Text.Contains("https://velocity.radon.games"))
            {
                applauncher applauncher = new applauncher();
                applauncher.label1.Text = "Would you like to Launch Velocity?";
                applauncher.label2.Text = "It appears that your trying to access Velocity which can be \r\ninstalled or opened from your computer.";
                if (File.Exists("C:\\z1g Apps\\Velocity\\Velocity.exe"))
                {
                    applauncher.textBox1.Text = "C:\\z1g Apps\\Velocity\\Velocity.exe";
                }
                else
                {
                    string fileUrl = "https://cdn.z1g-project.repl.co/z1g-hub/client/velocity-bootstrap.exe";
                    string savePath = "C:\\z1g Apps\\Velocity\\velocity-bootstrap.exe";

                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(fileUrl, savePath);
                    }

                    applauncher.textBox1.Text = "C:\\z1g Apps\\Velocity\\velocity-bootstrap.exe";
                }
                applauncher.Show();
            }
            if (comboBox1.Text.Equals("https://z1g-project.repl.co/z1g-hub/launch") || comboBox1.Text.Contains("https://z1g-project.repl.co/z1g-hub/launch"))
            {
                applauncher applauncher = new applauncher();
                applauncher.label1.Text = "Would you like to Launch z1g Hub?";
                applauncher.label2.Text = "It appears that your trying to access z1g Hub which can be \r\ninstalled or opened from your computer.";
                if (File.Exists("C:\\Users\\Public\\z1g-project\\z1g-project-hub-universal.exe"))
                {
                    applauncher.textBox1.Text = "C:\\Users\\Public\\z1g-project\\z1g-project-hub-universal.exe";
                }
                else
                {
                    string fileUrl = "http://err404";
                    string savePath = "C:\\Users\\Public\\z1g-project\\z1g-project-hub-universal.exe";

                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(fileUrl, savePath);
                    }

                    applauncher.textBox1.Text = "C:\\Users\\Public\\z1g-project\\z1g-project-hub-universal.exe";
                }
                applauncher.Show();
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

                if (comboBox1.Text.Equals("https://terbium-46q.pages.dev/") || comboBox1.Text.Contains("https://terbium-46q.pages.dev"))
                {
                    applauncher applauncher = new applauncher();
                    applauncher.label1.Text = "Would you like to Launch Terbium?";
                    applauncher.label2.Text = "It appears that your trying to access Terbium which can be \r\ninstalled or opened from your computer.";
                    if (File.Exists("C:\\z1g Apps\\Terbium\\Terbium.exe"))
                    {
                        applauncher.textBox1.Text = "C:\\z1g Apps\\Terbium\\Terbium.exe";
                    }
                    else
                    {
                        string fileUrl = "https://cdn.z1g-project.repl.co/z1g-hub/client/Terbium-bootstrap.exe";
                        string savePath = "C:\\z1g Apps\\Terbium\\terbium-bootstraper.exe";

                        using (WebClient client = new WebClient())
                        {
                            client.DownloadFile(fileUrl, savePath);
                        }

                        applauncher.textBox1.Text = "C:\\z1g Apps\\Terbium\\terbium-bootstraper.exe";
                    }
                    applauncher.Show();
                }
                if (comboBox1.Text.Equals("https://terbium.johnglynn2.repl.co") || comboBox1.Text.Contains("https://terbium.johnglynn2.repl.co"))
                {
                    applauncher applauncher = new applauncher();
                    applauncher.label1.Text = "Would you like to Launch Terbium?";
                    applauncher.label2.Text = "It appears that your trying to access Terbium which can be \r\ninstalled or opened from your computer.";
                    if (File.Exists("C:\\z1g Apps\\Terbium\\Terbium.exe"))
                    {
                        applauncher.textBox1.Text = "C:\\z1g Apps\\Terbium\\Terbium.exe";
                    }
                    else
                    {
                        string fileUrl = "https://cdn.z1g-project.repl.co/z1g-hub/client/Terbium-bootstrap.exe";
                        string savePath = "C:\\z1g Apps\\Terbium\\terbium-bootstraper.exe";

                        using (WebClient client = new WebClient())
                        {
                            client.DownloadFile(fileUrl, savePath);
                        }

                        applauncher.textBox1.Text = "C:\\z1g Apps\\Terbium\\terbium-bootstraper.exe";
                    }
                    applauncher.Show();
                }
                if (comboBox1.Text.Equals("https://velocity.radon.games") || comboBox1.Text.Contains("https://velocity.radon.games"))
                {
                    applauncher applauncher = new applauncher();
                    applauncher.label1.Text = "Would you like to Launch Velocity?";
                    applauncher.label2.Text = "It appears that your trying to access Velocity which can be \r\ninstalled or opened from your computer.";
                    if (File.Exists("C:\\z1g Apps\\Velocity\\Velocity.exe"))
                    {
                        applauncher.textBox1.Text = "C:\\z1g Apps\\Velocity\\Velocity.exe";
                    }
                    else
                    {
                        string fileUrl = "https://cdn.z1g-project.repl.co/z1g-hub/client/velocity-bootstrap.exe";
                        string savePath = "C:\\z1g Apps\\Velocity\\velocity-bootstrap.exe";

                        using (WebClient client = new WebClient())
                        {
                            client.DownloadFile(fileUrl, savePath);
                        }

                        applauncher.textBox1.Text = "C:\\z1g Apps\\Velocity\\velocity-bootstrap.exe";
                    }
                    applauncher.Show();
                }
                if (comboBox1.Text.Equals("https://z1g-project.repl.co/z1g-hub/launch") || comboBox1.Text.Contains("https://z1g-project.repl.co/z1g-hub/launch"))
                {
                    applauncher applauncher = new applauncher();
                    applauncher.label1.Text = "Would you like to Launch z1g Hub?";
                    applauncher.label2.Text = "It appears that your trying to access z1g Hub which can be \r\ninstalled or opened from your computer.";
                    if (File.Exists("C:\\Users\\Public\\z1g-project\\z1g-project-hub-universal.exe"))
                    {
                        applauncher.textBox1.Text = "C:\\Users\\Public\\z1g-project\\z1g-project-hub-universal.exe";
                    }
                    else
                    {
                        string fileUrl = "http://err404";
                        string savePath = "C:\\Users\\Public\\z1g-project\\z1g-project-hub-universal.exe";

                        using (WebClient client = new WebClient())
                        {
                            client.DownloadFile(fileUrl, savePath);
                        }

                        applauncher.textBox1.Text = "C:\\Users\\Public\\z1g-project\\z1g-project-hub-universal.exe";
                    }
                    applauncher.Show();
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