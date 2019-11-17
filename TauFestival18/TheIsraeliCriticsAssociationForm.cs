using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tau19
{
    public partial class TheIsraeliCriticsAssociationForm : Form
    {
        public TheIsraeliCriticsAssociationForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            Size = Common.formSize;
        }

        protected override void OnShown(EventArgs e)
        {
            this.resizePb.Image = this.WindowState == FormWindowState.Maximized ? Properties.Resources.full_close : Properties.Resources.full_open;
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
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
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

        private void e2pb_Click(object sender, EventArgs e)
        {
            Common.OpenVideo($"{System.Reflection.MethodBase.GetCurrentMethod().Name.Replace("pb_Click", "")}.mp4");
        }

        private void e3pb_Click(object sender, EventArgs e)
        {
            Common.OpenVideo($"{System.Reflection.MethodBase.GetCurrentMethod().Name.Replace("pb_Click", "")}.mp4");
        }

        private void e4pb_Click(object sender, EventArgs e)
        {
            Common.OpenVideo($"{System.Reflection.MethodBase.GetCurrentMethod().Name.Replace("pb_Click", "")}.mp4");
        }

        private void e5pb_Click(object sender, EventArgs e)
        {
            Common.OpenVideo($"{System.Reflection.MethodBase.GetCurrentMethod().Name.Replace("pb_Click", "")}.mp4");
        }

        private void e6pb_Click(object sender, EventArgs e)
        {
            Common.OpenVideo($"{System.Reflection.MethodBase.GetCurrentMethod().Name.Replace("pb_Click", "")}.mp4");
        }
    }
}