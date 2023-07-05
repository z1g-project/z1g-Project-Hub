using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terbium
{
    public partial class firstrun : Form
    {
        public firstrun()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //File.Create("C:/z1g apps/Terbium/Data/verconf.DAT"); (Deprecated)
            File.Create("C:/z1g apps/Blurred X/Data/setupdone.DAT");
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            settings settings = new settings();
            settings.Show();
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            settings settings = new settings();
            settings.Show();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            RunNodeJsApplication();
            //File.Create("C:/z1g apps/Terbium/Data/verconf.DAT");
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            RunNodeJsApplication();
            //File.Create("C:/z1g apps/Terbium/Data/verconf.DAT");
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

        private void Button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You must complete the setup to use Blurred X!", "Error");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You must complete the setup to use Blurred X!", "Error");
        }

        private void firstrun_Load(object sender, EventArgs e)
        {

        }
    }
}
