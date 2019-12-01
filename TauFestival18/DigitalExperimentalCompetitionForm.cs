using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tau19
{
    public partial class DigitalExperimentalCompetitionForm : Form
    {
        public DigitalExperimentalCompetitionForm()
        {
            InitializeComponent();
            ClientSize = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.85), (int)(Screen.PrimaryScreen.Bounds.Height * 0.85));

            Common.FormLocation = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            MinimizeBox = false;
            MaximizeBox = false;

            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        int originalExStyle = -1;
        bool enableFormLevelDoubleBuffering = true;

        protected override CreateParams CreateParams
        {
            get
            {
                if (originalExStyle == -1)
                    originalExStyle = base.CreateParams.ExStyle;

                CreateParams cp = base.CreateParams;
                if (enableFormLevelDoubleBuffering)
                    cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                else
                    cp.ExStyle = originalExStyle;

                return cp;
            }
        }

        private void TurnOffFormLevelDoubleBuffering()
        {
            enableFormLevelDoubleBuffering = false;
            this.MaximizeBox = true;
        }

        protected override void OnShown(EventArgs e)
        {
            //TurnOffFormLevelDoubleBuffering();
            this.resizePb.Image = this.WindowState == FormWindowState.Maximized ? Properties.Resources.full_close : Properties.Resources.full_open;
            Common.OnPaint(e, this);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Common.OnPaint(e, this);
        }

        //#region draggable resizable
        //protected override void WndProc(ref Message m)
        //{
        //    const int RESIZE_HANDLE_SIZE = 10;

        //    switch (m.Msg)
        //    {
        //        case 0x0084/*NCHITTEST*/ :
        //            base.WndProc(ref m);

        //            if ((int)m.Result == 0x01/*HTCLIENT*/)
        //            {
        //                Point screenPoint = new Point(m.LParam.ToInt32());
        //                Point clientPoint = this.PointToClient(screenPoint);
        //                if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
        //                {
        //                    if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
        //                    {
        //                        m.Result = (IntPtr)2/*HTCAPTION*/ ;
        //                        Common.FormLocation = new Point(this.Location.X, this.Location.Y);
        //                    }

        //                }
        //            }
        //            return;
        //    }

        //    base.WndProc(ref m);
        //}
        //#endregion

        private new void Resize(object sender, EventArgs e)
        {
            Common.Resize(sender, e, this, this.resizePb);
        }

        private void Back(object sender, EventArgs e)
        {
            this.Close();
        }

        private void f2pb_Click(object sender, EventArgs e)
        {
            Common.OpenVideo($"{System.Reflection.MethodBase.GetCurrentMethod().Name.Replace("pb_Click", "")}.mp4");
        }

        private void f4pb_Click(object sender, EventArgs e)
        {
            Common.OpenVideo($"{System.Reflection.MethodBase.GetCurrentMethod().Name.Replace("pb_Click", "")}.mp4");
        }
    }
}
