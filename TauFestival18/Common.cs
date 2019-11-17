using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tau19
{
    public static class Common
    {
        private const int cGrip = 16;      // Grip size
        private const int cCaption = 32;   // Caption bar height;

        public static Size formSize = new Size(1280, 960);

        public static void OpenVideo(string videoUrl)
        {
            string appPath = Application.StartupPath;
            //MessageBox.Show($"{appPath}\\Videos\\{videoUrl}");
            try { System.Diagnostics.Process.Start($"{appPath}\\Videos\\{videoUrl}"); }
            catch { MessageBox.Show("Video is missing"); }
        }

        public static void OnPaint(PaintEventArgs e, Form form)
        {
            //Rectangle rc = new Rectangle(form.ClientSize.Width - cGrip, form.ClientSize.Height - cGrip, cGrip, cGrip);
            //ControlPaint.DrawSizeGrip(e.Graphics, form.BackColor, rc);
            //rc = new Rectangle(0, 0, form.ClientSize.Width, cCaption);
            //e.Graphics.FillRectangle(Brushes.Transparent, rc);
        }

        public static void Resize(object sender, EventArgs e, Form form, PictureBox pb)
        {
            if (form.WindowState == FormWindowState.Maximized)
            {
                form.TopMost = false;
                form.WindowState = FormWindowState.Normal;
                pb.Image = Properties.Resources.full_open;
            }
            else
            {
                form.TopMost = true;
                form.WindowState = FormWindowState.Maximized;
                pb.Image = Properties.Resources.full_close;
            }
        }
    }
}
