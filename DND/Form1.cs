using System;
using System.Drawing;
using System.Windows.Forms;

namespace DND
{
    public partial class Form1 : Form
    {
        private bool isDNDStatus = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                VerifySchedule();
                notifyIcon1.Visible = true;
            }
            
        }

        private void VerifySchedule()
        {
            var curTime = DateTime.Now.Hour;
            if (curTime >= 18 || curTime <= 8)
            {
                isDNDStatus = true;
                notifyIcon1.Icon = Properties.Resources.normal;
            }
            else if (curTime % 2 == 0)
            {
                isDNDStatus = false;
                notifyIcon1.Icon = Properties.Resources.cool;
            }
            else
            {
                isDNDStatus = true;
                notifyIcon1.Icon = Properties.Resources.dnd;
            }

            if(WindowState == FormWindowState.Normal)
            {
                if (isDNDStatus)
                {
                    pictureBox1.Image = Properties.Resources.No_Talk;
                    label1.Text = "Do not disturb now!";
                }
                else
                {
                    pictureBox1.Image = Properties.Resources.Sing;
                    label1.Text = "Free to sing now!";
                }
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            //notifyIcon1.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            VerifySchedule();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            const int margin = 0;
            var x = Screen.PrimaryScreen.WorkingArea.Right - this.Width - margin;
            var y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height - margin;
            this.Location = new Point(x, y);
        }
    }
}
