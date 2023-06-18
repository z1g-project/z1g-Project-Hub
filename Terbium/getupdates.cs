using CefSharp;
using Markdig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Terbium
{
    public partial class getupdates : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        public getupdates()
        {
            InitializeComponent();
        }

        public static string HtmlToRtf(string html)
        {
            RichTextBox rtBox = new RichTextBox();
            rtBox.Text = html;
            return rtBox.Rtf;
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void getupdates_Load(object sender, EventArgs e)
        {
            string markdownUrl = "https://cdn.z1g-project.repl.co/z1g-hub/client/terbium-changelog.md";
            string backgroundColor = "#181818"; // Replace with your desired background color
            string fontName = "Segoe UI"; // Replace with your desired font name
            string textColor = "#FFFFFF"; // Replace with your desired text color

            using (WebClient client = new WebClient())
            {
                string markdownText = client.DownloadString(markdownUrl);

                // Convert Markdown to HTML
                string htmlText = Markdown.ToHtml(markdownText);

                // Inject custom CSS to modify the background color, font, and text color
                string styledHtmlText = $"<html><head><style>body {{ background-color: {backgroundColor}; font-family: '{fontName}', sans-serif; color: {textColor}; }}</style></head><body>{htmlText}</body></html>";

                // Set the HTML text to the ChromiumWebBrowser control
                chromiumWebBrowser1.LoadHtml(styledHtmlText, markdownUrl);
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

        private void Button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            // Close the application
            Application.Exit();

            // Download the update zip file
            string updateUrl = "https://tb-client.johnglynn2.repl.co/terbium.zip";
            string zipFilePath = @"C:\z1g Apps\Terbium\update.zip"; // Path to save the downloaded zip file

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(updateUrl, zipFilePath);
            }

            // Extract the update zip file
            string extractPath = @"C:\z1g Apps\Terbium\"; // Path to extract the zip contents

            try
            {
                System.IO.Compression.ZipFile.ExtractToDirectory(zipFilePath, extractPath, true);
                File.Delete(zipFilePath);

                MessageBox.Show("Update completed successfully. Please restart the application.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the application: " + ex.Message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
