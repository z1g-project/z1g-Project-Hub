using CefSharp;
using CefSharp.WinForms;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Terbium
{
    public partial class Form1 : Form
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

        private bool isResizing = false;
        private Point lastMousePos;

        public Form1()
        {
            InitializeComponent();
            InitializeCefSharp();
        }

        private void InitializeCefSharp()
        {
            CefSettings settings = new CefSettings();
            settings.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36 z1g Browser/113.0.1722.64";
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
                chromiumWebBrowser1.Load("https://terbium.johnglynn2.repl.co");
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
    }
}
