using CefSharp;
using CefSharp.DevTools.IO;
using CefSharp.WinForms;
using DiscordRPC;
using DiscordRPC.Logging;
using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Terbium
{
    public partial class form1 : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        // Resize Code

        private const int HTBOTTOMRIGHT = 17;
        private const int WM_NCHITTEST = 0x0084;
        private const int RESIZE_HANDLE_SIZE = 10;

        //private Color applicationBackColor;
        //private Color titleBarBackColor;
        //private Color defaultFontColor;
        //private Color defaultTitleBarFontColor;
        //private Font defaultFont;

        private DiscordRpcClient rpcClient;

        private bool isResizing = false;
        private Point lastMousePos;

        public form1()
        {
            InitializeComponent();
            InitializeCefSharp();
            LoadDefaultSettings();

            int formWidth = Properties.Settings.Default.FormWidth;
            int formHeight = Properties.Settings.Default.FormHeight;

            // Set the width and height of the form
            this.Width = formWidth;
            this.Height = formHeight;

            DateTime startTime = DateTime.Now; // Store the start time

            rpcClient = new DiscordRpcClient("1115687781998547066");
            rpcClient.Logger = new ConsoleLogger() { Level = LogLevel.Info };
            rpcClient.Initialize();

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // Update presence every 1 second
            timer.Tick += (sender, e) => UpdatePresence();
            timer.Start();

            // Method to update the RPC presence
            void UpdatePresence()
            {
                TimeSpan elapsedTime = DateTime.Now - startTime;
                string elapsedTimeString = elapsedTime.ToString(@"hh\:mm\:ss"); // Format the elapsed time as HH:MM:SS

                var presence = new RichPresence()
                {
                    Details = "Using Terbium WebOS by the z1g Project",
                    State = elapsedTimeString,
                    Assets = new Assets()
                    {
                        LargeImageKey = "terbium",
                        LargeImageText = "Terbium Logo",
                        SmallImageKey = "z1g",
                        SmallImageText = "z1g Project Logo"
                    },
                    Buttons = new[]
                    {
            new DiscordRPC.Button { Label = "Download", Url = "https://z1g-project.johnglynn2.repl.co/z1g-hub/" },
            new DiscordRPC.Button { Label = "View Repository", Url = "https://github.com/z1g-project/z1g-project-hub" }
        }
                };
                rpcClient.SetPresence(presence);
            }

        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            rpcClient.Dispose();
        }

        private void LoadDefaultSettings()
        {
            // Load default settings or values from the Properties.Settings.Default
            //applicationBackColor = Properties.Settings.Default.ApplicationBackColor;
            //titleBarBackColor = Properties.Settings.Default.TitleBarBackColor;
            //defaultFontColor = Properties.Settings.Default.DefaultFontColor;
            //defaultTitleBarFontColor = Properties.Settings.Default.DefaultTitleBarFontColor;
            //defaultFont = Properties.Settings.Default.DefaultFont;

            // Apply the loaded settings
            //ApplySettings();
        }

        //private void ApplySettings()
        //{
        //    this.BackColor = applicationBackColor;
        //    UpdateTitleBarBackgroundColor();
        //    this.ForeColor = defaultFontColor;
        //    UpdateTitleBarFontColor();
        //    this.Font = defaultFont;
        //}

        private void UpdateTitleBarBackgroundColor()
        {
            // Custom method to update title bar background color
            // You need to handle the title bar background color update based on the UI framework you're using

            // Example code for WinForms:
            // NativeMethods.SetWindowCompositionAttribute(this.Handle, NativeMethods.WCA_ACCENT_POLICY, new NativeMethods.AccentPolicy { AccentState = NativeMethods.AccentState.ACCENT_ENABLE_TRANSPARENTGRADIENT });
        }

        private void UpdateTitleBarFontColor()
        {
            // Custom method to update title bar font color
            // You need to handle the title bar font color update based on the UI framework you're using

            // Example code for WinForms:
            // this.TitleBar.ForeColor = defaultTitleBarFontColor;
        }

        private void InitializeCefSharp()
        {
            CefSettings settings = new CefSettings();
            settings.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36 z1g Browser/114.0.1722.64";
            string path = ("C:\\z1g Apps\\Terbium\\Data\\");
            settings.RemoteDebuggingPort = 8080;
            settings.CachePath = path;

            // Initialize Cef with the provided settings
            Cef.Initialize(settings);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create("https://cdn.z1g-project.repl.co/z1g-hub/client/terbium-ver.txt");
            System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();

            System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());

            string newestversion = sr.ReadToEnd();
            string currentversion = Application.ProductVersion;

            if (newestversion.Contains(currentversion))
            {
                if (File.Exists("C:/z1g apps/Terbium/Data/setupdone.DAT"))
                {

                }
                else
                {
                    firstrun firstrun = new firstrun();
                    firstrun.Show();
                    chromiumWebBrowser1.Load("about:blank");
                }
            }
            else
            {
                getupdates getupdates = new getupdates();
                getupdates.Show();
            }
            if (File.Exists("C:/z1g apps/Terbium/Data/verconf.DAT"))
            {
                chromiumWebBrowser1.Load("https://terbium-46q.pages.dev");
            }
            else
            {
                chromiumWebBrowser1.Load("https://terbium--johnglynn2.repl.co");
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

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    if (m.Result.ToInt32() == HTBOTTOMRIGHT)
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left && IsResizingArea(e.Location))
            {
                isResizing = true;
                lastMousePos = e.Location;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isResizing)
            {
                int deltaX = e.X - lastMousePos.X;
                int deltaY = e.Y - lastMousePos.Y;

                this.Width += deltaX;
                this.Height += deltaY;

                lastMousePos = e.Location;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            isResizing = false;
        }

        private bool IsResizingArea(Point mouseLocation)
        {
            Rectangle resizeArea = new Rectangle(
                this.ClientSize.Width - RESIZE_HANDLE_SIZE,
                this.ClientSize.Height - RESIZE_HANDLE_SIZE,
                RESIZE_HANDLE_SIZE,
                RESIZE_HANDLE_SIZE);

            return resizeArea.Contains(mouseLocation);
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            settings settings = new settings();
            settings.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Cef.Shutdown();
            this.Close();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Back();
        }

        private void forwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Forward();
        }

        private void inspectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature isn't ready yet. Check the source here: https://github.com/z1g-project/Terbium");
        }

        private void resetSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Refresh();
        }
    }
}
