using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tau19
{
    public partial class TheIsraeliCompetitionForm : Form
    {
        public TheIsraeliCompetitionForm()
        {
            InitializeComponent();
            ClientSize = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.7), (int)(Screen.PrimaryScreen.Bounds.Height * 0.7));
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected override void OnShown(EventArgs e)
        {
            this.resizePb.Image = this.WindowState == FormWindowState.Maximized ? Properties.Resources.full_close : Properties.Resources.full_open;
            Common.OnPaint(e, this);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Common.OnPaint(e, this);
        }

        #region draggable resizable
        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                            {
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                                Common.FormLocation = new Point(this.Location.X, this.Location.Y);
                            }

                        }
                    }
                    return;
            }

            base.WndProc(ref m);
        }
        #endregion

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }

        private new void Resize(object sender, EventArgs e)
        {
            Common.Resize(sender, e, this, this.resizePb);
        }

        private void Back(object sender, EventArgs e)
        {
            this.Close();
        }

        private void c2pb_Click(object sender, EventArgs e)
        {
            Common.OpenVideo($"{System.Reflection.MethodBase.GetCurrentMethod().Name.Replace("pb_Click", "")}.mp4");
        }

        private void c3pb_Click(object sender, EventArgs e)
        {
            Common.OpenVideo($"{System.Reflection.MethodBase.GetCurrentMethod().Name.Replace("pb_Click", "")}.mp4");
        }

        private void c4pb_Click(object sender, EventArgs e)
        {
            Common.OpenVideo($"{System.Reflection.MethodBase.GetCurrentMethod().Name.Replace("pb_Click", "")}.mp4");
        }

        private void c5pb_Click(object sender, EventArgs e)
        {
            Common.OpenVideo($"{System.Reflection.MethodBase.GetCurrentMethod().Name.Replace("pb_Click", "")}.mp4");
        }

        private void c6pb_Click(object sender, EventArgs e)
        {
            Common.OpenVideo($"c3.mp4");
        }

        private void c7pb_Click(object sender, EventArgs e)
        {
            Common.OpenVideo($"{System.Reflection.MethodBase.GetCurrentMethod().Name.Replace("pb_Click", "")}.mp4");
        }

        private void c8pb_Click(object sender, EventArgs e)
        {
            Common.OpenVideo($"{System.Reflection.MethodBase.GetCurrentMethod().Name.Replace("pb_Click", "")}.mp4");
        }
    }
}
