﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tau19
{
    public partial class TheIndependentShortFilmCompetitionForm : Form
    {
        public TheIndependentShortFilmCompetitionForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected override void OnShown(EventArgs e)
        {
            this.pictureBox3.Image = this.WindowState == FormWindowState.Maximized ? Properties.Resources.full_close : Properties.Resources.full_open;
        }

        private const int cGrip = 16;      // Grip size
        private const int cCaption = 32;   // Caption bar height;

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            e.Graphics.FillRectangle(Brushes.Transparent, rc);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84 && this.WindowState != FormWindowState.Maximized)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string appPath = Application.StartupPath;
            try
            {
                System.Diagnostics.Process.Start(appPath + Properties.Resources.IntergalacticSamuraiurl);
            }
            catch
            {
                MessageBox.Show("Video is missing");
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            string appPath = Application.StartupPath;
            try
            {
                System.Diagnostics.Process.Start(appPath + Properties.Resources.OldThingurl);
            }
            catch
            {
                MessageBox.Show("Video is missing");
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string appPath = Application.StartupPath;
            try
            {
                System.Diagnostics.Process.Start(appPath + Properties.Resources.Shmamaurl);
            }
            catch
            {
                MessageBox.Show("Video is missing");
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.TopMost = false;
                this.WindowState = FormWindowState.Normal;
                this.pictureBox3.Image = Properties.Resources.full_open;
            }
            else
            {
                this.TopMost = true;
                this.WindowState = FormWindowState.Maximized;
                this.pictureBox3.Image = Properties.Resources.full_close;
            }
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {

        }
    }
}