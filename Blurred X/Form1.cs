using CefSharp;
using CefSharp.DevTools.IO;
using CefSharp.WinForms;
using DiscordRPC;
using DiscordRPC.Logging;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Terbium
{
    public partial class form1 : Form
    {
        private overlayForm overlayForm;

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int WM_KEYDOWN = 0x0100;
        private const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        // Resize Code
        private const int HTBOTTOMRIGHT = 17;
        private const int WM_NCHITTEST = 0x0084;
        private const int RESIZE_HANDLE_SIZE = 10;

        private DiscordRpcClient rpcClient;
        private bool isResizing = false;
        private Point lastMousePos;

        public form1()
        {
            InitializeComponent();
            InitializeCefSharp();
            LoadDefaultSettings();

            int formWidth = Blurred_X.Properties.Settings.Default.FormWidth;
            int formHeight = Blurred_X.Properties.Settings.Default.FormHeight;

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
                    Details = "Using Blurred X by the z1g Project",
                    State = elapsedTimeString,
                    Assets = new Assets()
                    {
                        LargeImageKey = "blurred-x",
                        LargeImageText = "Blurred X Logo",
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
            // Load default settings or values from the Blurred_X.Properties.Settings.Default
            // Apply the loaded settings
        }

        private void UpdateTitleBarBackgroundColor()
        {
            // Custom method to update title bar background color
            // You need to handle the title bar background color update based on the UI framework you're using
        }

        private void UpdateTitleBarFontColor()
        {
            // Custom method to update title bar font color
            // You need to handle the title bar font color update based on the UI framework you're using
        }

        private void InitializeCefSharp()
        {
            CefSettings settings = new CefSettings();
            settings.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36 z1g Browser/114.0.1722.64";
            string path = ("C:\\z1g Apps\\Blurred X\\Data\\");
            settings.RemoteDebuggingPort = 8080;
            settings.CachePath = path;

            if (Directory.Exists("C:\\z1g Apps\\Blurred X\\UBlock\\"))
            {
                string extensionPath = "C:\\z1g Apps\\Blurred X\\UBlock\\";
                settings.CefCommandLineArgs.Add("load-extension", extensionPath);
            }

            if (Directory.Exists("C:\\z1g Apps\\Blurred X\\CustomCur\\"))
            {
                string extensionPath = "C:\\z1g Apps\\Blurred X\\CustomCur\\";
                settings.CefCommandLineArgs.Add("load-extension", extensionPath);
            }
            // Initialize Cef with the provided settings
            Cef.Initialize(settings);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            try
            {
                string terbiumVerUrl = "https://cdn.z1g-project.repl.co/z1g-hub/client/blurred-x-ver.txt";
                string setupDoneFile = "C:/z1g apps/Blurred X/Data/setupdone.DAT";
                string localinstallexists = "C:/z1g apps/Blurred X/Data/localinstall.DAT";

                using (HttpClient client = new HttpClient())
                {
                    string newestVersion = await client.GetStringAsync(terbiumVerUrl);
                    string currentVersion = Application.ProductVersion;

                    if (!newestVersion.Contains(currentVersion))
                    {
                        getupdates getupdates = new getupdates();
                        getupdates.Show();
                        return; // Stop execution after showing the getupdates form
                    }

                    if (!File.Exists(setupDoneFile))
                    {
                        firstrun firstrun = new firstrun();
                        firstrun.Show();
                        chromiumWebBrowser1.Load("about:blank");
                        return; // Stop execution after showing the firstrun form
                    }
                    else
                    {
                        // Nothing happens lol
                    }

                    if (!File.Exists(localinstallexists))
                    {
                        // Change directory to the desired path
                        string projectDirectory = @"C:\z1g Apps\Blurred X\BX-local\Blurred-X-v2-master"; // Update with the correct folder name
                        Directory.SetCurrentDirectory(projectDirectory);

                        Process runProcess = new Process();
                        runProcess.StartInfo.FileName = "npm";
                        runProcess.StartInfo.Arguments = "install";
                        runProcess.StartInfo.WorkingDirectory = projectDirectory; // Set the working directory to the project folder
                        runProcess.StartInfo.UseShellExecute = false;
                        runProcess.StartInfo.RedirectStandardOutput = true;
                        runProcess.StartInfo.RedirectStandardError = true;

                        StringBuilder outputBuilder = new StringBuilder();
                        StringBuilder errorBuilder = new StringBuilder();

                        runProcess.OutputDataReceived += (s, evt) =>
                        {
                            if (!string.IsNullOrEmpty(evt.Data))
                            {
                                outputBuilder.AppendLine(evt.Data);
                                this.Invoke(new Action(() =>
                                {
                                    textBox3.Text = outputBuilder.ToString();
                                }));
                            }
                        };
                        runProcess.ErrorDataReceived += (s, evt) =>
                        {
                            if (!string.IsNullOrEmpty(evt.Data))
                            {
                                errorBuilder.AppendLine(evt.Data);
                                this.Invoke(new Action(() =>
                                {
                                    textBox3.Text = errorBuilder.ToString();
                                }));
                            }
                        };

                        runProcess.Start();
                        runProcess.BeginOutputReadLine();
                        runProcess.BeginErrorReadLine();
                        runProcess.WaitForExit();

                        if (runProcess.ExitCode != 0)
                        {
                            // Error occurred during npm install
                            MessageBox.Show("Error occurred during npm install. See textbox3 for details.", "Error");
                            return;
                        }

                        // Run npm start
                        Process startProcess = new Process();
                        startProcess.StartInfo.FileName = "npm";
                        startProcess.StartInfo.Arguments = "start";
                        startProcess.StartInfo.WorkingDirectory = projectDirectory; // Set the working directory to the project folder
                        startProcess.StartInfo.UseShellExecute = false;
                        startProcess.StartInfo.RedirectStandardOutput = true;
                        startProcess.StartInfo.RedirectStandardError = true;

                        outputBuilder.Clear();
                        errorBuilder.Clear();

                        startProcess.OutputDataReceived += (s, evt) =>
                        {
                            if (!string.IsNullOrEmpty(evt.Data))
                            {
                                outputBuilder.AppendLine(evt.Data);
                                this.Invoke(new Action(() =>
                                {
                                    textBox3.Text = outputBuilder.ToString();
                                }));
                            }
                        };
                        startProcess.ErrorDataReceived += (s, evt) =>
                        {
                            if (!string.IsNullOrEmpty(evt.Data))
                            {
                                errorBuilder.AppendLine(evt.Data);
                                this.Invoke(new Action(() =>
                                {
                                    textBox3.Text = errorBuilder.ToString();
                                }));
                            }
                        };

                        startProcess.Start();
                        startProcess.BeginOutputReadLine();
                        startProcess.BeginErrorReadLine();
                        startProcess.WaitForExit();

                        if (startProcess.ExitCode != 0)
                        {
                            // Error occurred during npm start
                            MessageBox.Show("Error occurred during npm start. See textbox3 for details.", "Error");
                            return;
                        }

                        // Load the URL in ChromiumWebBrowser
                        chromiumWebBrowser1.Load("http://localhost");
                    }
                    else
                    {
                        // Load the URL in ChromiumWebBrowser
                        chromiumWebBrowser1.Load(Blurred_X.Properties.Settings.Default.versionurl);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error");
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
            MessageBox.Show("Feature isn't ready yet. Check the source here: https://github.com/z1g-project/Blurred-X-v2");
        }

        private void resetSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Refresh();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Check if Shift + Tab keys are pressed and the panel1 has focus
            if (keyData == (Keys.Shift | Keys.Tab) && panel1.ContainsFocus)
            {
                if (overlayForm == null)
                {
                    // Create an instance of the overlay form
                    overlayForm = new overlayForm();
                    overlayForm.Owner = this;
                    overlayForm.Show();
                }
                else
                {
                    // Close the overlay form if it's already open
                    overlayForm.Close();
                    overlayForm = null;
                }
                return true; // Prevent default handling of the key combination
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }
    }
}
