using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tau19
{
    public static class Common
    {
        private const int cGrip = 16;      // Grip size
        private const int cCaption = 32;   // Caption bar height;

        public static Point FormLocation { get; set; } = new Point(200, 200);

        public static void OpenVideo(string videoUrl)
        {
            string appPath = Application.StartupPath;
            try { System.Diagnostics.Process.Start($"{appPath}\\Videos\\{videoUrl}"); }
            catch { MessageBox.Show("Video is missing"); }
        }

        public static void OnPaint(EventArgs e, Form form)//OnShown
        {
            form.Location = FormLocation;
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
