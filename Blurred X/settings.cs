﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terbium
{
    public partial class settings : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        public settings()
        {
            InitializeComponent();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Blurred_X.Properties.Settings.Default.versionurl = "https://terbium-46q.pages.dev";
            Blurred_X.Properties.Settings.Default.Save();
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            Blurred_X.Properties.Settings.Default.versionurl = "https://terbium-46q.pages.dev";
            Blurred_X.Properties.Settings.Default.Save();
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            RunNodeJsApplication();
            Blurred_X.Properties.Settings.Default.versionurl = "http://localhost";
            Blurred_X.Properties.Settings.Default.Save();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            RunNodeJsApplication();
            Blurred_X.Properties.Settings.Default.versionurl = "http://localhost";
            Blurred_X.Properties.Settings.Default.Save();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int formWidth = int.Parse(textBox1.Text);
            int formHeight = int.Parse(textBox2.Text);

            Blurred_X.Properties.Settings.Default.FormWidth = formWidth;
            Blurred_X.Properties.Settings.Default.FormHeight = formHeight;
            Blurred_X.Properties.Settings.Default.Save();
        }

        private void settings_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            textBox1.Text = Blurred_X.Properties.Settings.Default.FormWidth.ToString();
            textBox2.Text = Blurred_X.Properties.Settings.Default.FormHeight.ToString();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void label12_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Directory.Delete("C:\\z1g Apps\\Blurred X\\Data\\");
            MessageBox.Show("Your cache located in: C:\\z1g Apps\\Blurred X\\Data\\ has been cleared. Blurred X will now restart to apply the changes.");
            Process.Start(":\\z1g Apps\\Blurred X\\Blurred X.exe");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Create a SaveFileDialog to choose the destination for the zip file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "ZIP files (*.zip)|*.zip";
            saveFileDialog.FileName = "BlurredXData.zip";
            saveFileDialog.InitialDirectory = "C:\\";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string sourceFolder = @"C:\z1g Apps\Blurred X\Data";
                string destinationZipFile = saveFileDialog.FileName;

                // Create a new zip file
                ZipFile.CreateFromDirectory(sourceFolder, destinationZipFile);
                MessageBox.Show("Successfully Exported Cache to: " + destinationZipFile);
            }
        }

        public void RunNodeJsApplication()
        {
            // Check if Node.js is installed
            Process process = new Process();
            process.StartInfo.FileName = "node";
            process.StartInfo.Arguments = "--version";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            if (output.StartsWith("v"))
            {
                // Node.js is installed
                string version = output.Substring(1);
                Console.WriteLine("Node.js version: " + version);

                // Download and extract project
                string projectUrl = "https://github.com/z1g-project/Blurred-X-v2/archive/refs/heads/master.zip"; // Replace with the project URL
                string projectPath = @"C:\z1g apps\temp\BX-main.zip"; // Replace with the desired path to save the project zip file
                string extractPath = @"C:\z1g apps\Blurred X\BX-local"; // Replace with the desired extraction path

                using (var webClient = new System.Net.WebClient())
                {
                    webClient.DownloadFile(projectUrl, projectPath);
                }

                // Extract the project
                System.IO.Compression.ZipFile.ExtractToDirectory(projectPath, extractPath);

                // Change directory to the extracted project folder
                string projectDirectory = Path.Combine(extractPath, "Blurred-X-v2-master"); // Update with the correct folder name
                Directory.SetCurrentDirectory(projectDirectory);

                // Run npm start
                Process runProcess = new Process();
                runProcess.StartInfo.FileName = "npm";
                runProcess.StartInfo.Arguments = "start";
                runProcess.StartInfo.WorkingDirectory = projectDirectory; // Set the working directory to the project folder
                runProcess.StartInfo.UseShellExecute = false;
                runProcess.StartInfo.RedirectStandardOutput = true;
                runProcess.StartInfo.RedirectStandardError = true;
                runProcess.Start();

                string runOutput = runProcess.StandardOutput.ReadToEnd();
                string runError = runProcess.StandardError.ReadToEnd();

                runProcess.WaitForExit();

                if (!string.IsNullOrEmpty(runError))
                {
                    // Error occurred, log it in the console or display a messagebox
                    Console.WriteLine("Error occurred: " + runError);
                    // MessageBox.Show("Error occurred: " + runError);
                }
                else
                {
                    // Successful execution, log output in the console
                    Console.WriteLine("Execution completed: " + runOutput);

                    // Load the URL in ChromiumWebBrowser
                    Blurred_X.Properties.Settings.Default.versionurl = "http://localhost";
                    Blurred_X.Properties.Settings.Default.Save();
                    Application.Restart();
                }

                //Console.WriteLine("Press any key to exit.");
                //Console.ReadKey();
            }
            else
            {
                // Node.js is not installed
                Console.WriteLine("Node.js is not installed.");

                // Ask the user if they want to install Node.js
                DialogResult result = MessageBox.Show("Node.js is not installed. Do you want to install it?", "Node.js Installation", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // Download and install Node.js
                    string nodeInstallerUrl = "https://nodejs.org/dist/latest-v18.x/win-x64/node.exe"; // URL for latest LTS version
                    string tempPath = @"C:\z1g apps\temp\nodejs\node.exe"; // Replace with the desired temporary path

                    using (var webClient = new System.Net.WebClient())
                    {
                        webClient.DownloadFile(nodeInstallerUrl, tempPath);
                    }

                    // Run the installer silently
                    Process installProcess = new Process();
                    installProcess.StartInfo.FileName = tempPath;
                    installProcess.StartInfo.Arguments = "/verysilent";
                    installProcess.Start();

                    // Wait for the installation to complete
                    installProcess.WaitForExit();
                    Console.WriteLine("Node.js installation completed.");

                    // Download and extract project
                    string projectUrl = "https://github.com/z1g-project/Blurred-X-v2/archive/refs/heads/master.zip"; // Replace with the project URL
                    string projectPath = @"C:\z1g apps\temp\BX-main.zip"; // Replace with the desired path to save the project zip file
                    string extractPath = @"C:\z1g apps\Blurred X\BX-local"; // Replace with the desired extraction path

                    using (var webClient = new System.Net.WebClient())
                    {
                        webClient.DownloadFile(projectUrl, projectPath);
                    }

                    // Extract the project
                    System.IO.Compression.ZipFile.ExtractToDirectory(projectPath, extractPath);

                    // Change directory to the extracted project folder
                    string projectDirectory = Path.Combine(extractPath, "Blurred-X-v2-master"); // Update with the correct folder name
                    Directory.SetCurrentDirectory(projectDirectory);

                    // Run npm start
                    Process runProcess = new Process();
                    runProcess.StartInfo.FileName = "npm";
                    runProcess.StartInfo.Arguments = "start";
                    runProcess.StartInfo.WorkingDirectory = projectDirectory; // Set the working directory to the project folder
                    runProcess.StartInfo.UseShellExecute = false;
                    runProcess.StartInfo.RedirectStandardOutput = true;
                    runProcess.StartInfo.RedirectStandardError = true;
                    runProcess.Start();

                    string runOutput = runProcess.StandardOutput.ReadToEnd();
                    string runError = runProcess.StandardError.ReadToEnd();

                    runProcess.WaitForExit();

                    if (!string.IsNullOrEmpty(runError))
                    {
                        // Error occurred, log it in the console or display a messagebox
                        Console.WriteLine("Error occurred: " + runError);
                        // MessageBox.Show("Error occurred: " + runError);
                    }
                    else
                    {
                        // Successful execution, log output in the console
                        Console.WriteLine("Execution completed: " + runOutput);

                        // Load the URL in ChromiumWebBrowser
                        Blurred_X.Properties.Settings.Default.versionurl = "http://localhost";
                        Blurred_X.Properties.Settings.Default.Save();
                        Application.Restart();
                    }

                    //Console.WriteLine("Press any key to exit.");
                    //Console.ReadKey();
                }
                else
                {
                    // User chose not to install Node.js
                    Console.WriteLine("Node.js installation aborted.");
                }
            }
            File.Create("C:/z1g apps/Blurred X/Data/localinstall.DAT").Close();
            File.Create("C:/z1g apps/Blurred X/Data/setupdone.DAT").Close();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            int formWidth = int.Parse("1028");
            int formHeight = int.Parse("664");

            textBox1.Text = "1028";
            textBox2.Text = "664";

            Blurred_X.Properties.Settings.Default.FormWidth = formWidth;
            Blurred_X.Properties.Settings.Default.FormHeight = formHeight;
            Blurred_X.Properties.Settings.Default.Save();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Blurred_X.Properties.Settings.Default.versionurl = textBox3.Text;
            Blurred_X.Properties.Settings.Default.Save();
        }
    }
}
