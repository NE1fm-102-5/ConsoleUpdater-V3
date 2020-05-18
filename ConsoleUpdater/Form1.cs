using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.IO;

namespace ConsoleUpdaterC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Timer1.Enabled = false;
            foreach (Process Pr1 in System.Diagnostics.Process.GetProcessesByName("NE1fmConsole"))
            {
                Pr1.Kill();
            }

            System.Threading.Thread.Sleep(5000);
            try
            {
                string link;
                link = "https://www.dropbox.com/s/tnx7j2vtbrnh9k7/NE1fmConsole.exe?dl=1";
                //int size1;
                WebRequest wr;
                wr = WebRequest.Create(link);
                WebResponse webr = wr.GetResponse();
                //size1 = webr.ContentLength;
                //size1 = (size1 / 1024);
                try
                {
                    File.Delete("C:\\NE1fmConsole\\NE1fmConsole.exe");
                }
                catch (Exception ex2)
                {
                }

                WebClient wc = new WebClient();
                wc.DownloadFile(link, "C:\\NE1fmConsole\\NE1fmConsole.exe");
            }
            catch (Exception ex)
            {
            }

            System.Threading.Thread.Sleep(5000);
            Process.Start("C:\\NE1fmConsole\\NE1fmConsole.exe");
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);
        }
    }
}
