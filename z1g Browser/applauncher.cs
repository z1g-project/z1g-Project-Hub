using CefSharp;
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

namespace z1g_Browser
{
    public partial class applauncher : Form
    {
        public applauncher()
        {
            InitializeComponent();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Form1 = new Form1();
            if (Form1.chromiumWebBrowser1.CanGoBack)
            {
                Form1.chromiumWebBrowser1.Back();
            }
            Process.Start(textBox1.Text);
        }
    }
}
