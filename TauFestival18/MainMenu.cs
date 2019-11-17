using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Tau19
{
    public partial class MainMenu : Form
    {
        private Form[] forms;

        //private void AntiFlicker()
        //{
        //    typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, this, new object[] { true });
        //    SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.DoubleBuffer, true);
        //    SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.Opaque, false);
        //    FormBorderStyle = FormBorderStyle.None;
        //    DoubleBuffered = true;
        //}

        public MainMenu()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            Common.formSize = new Size(Size.Width, Size.Height);

            forms = new Form[] {
                new DigitalExperimentalCompetitionForm { Location = this.Location, StartPosition = FormStartPosition.Manual, Size = Common.formSize },
                new TheIsraeliCriticsAssociationForm { Location = this.Location, StartPosition = FormStartPosition.Manual, Size = Common.formSize },
                new TheInternationalCompetitionForm { Location = this.Location, StartPosition = FormStartPosition.Manual, Size = Common.formSize },
                new TheIsraeliCompetitionForm { Location = this.Location, StartPosition = FormStartPosition.Manual, Size = Common.formSize },
                new TheIndependentShortFilmCompetitionForm { Location = this.Location, StartPosition = FormStartPosition.Manual, Size = Common.formSize },
                new FestivalHightlightsForm { Location = this.Location, StartPosition = FormStartPosition.Manual, Size = Common.formSize },
            };

            Resize(this.resizePb, null);
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

            Common.formSize = new Size(Size.Width, Size.Height);

            base.WndProc(ref m);
        }
        #endregion

        private new void Resize(object sender, EventArgs e)
        {
            Common.Resize(sender, e, this, this.resizePb);
        }

        private void FormSwitch(Form frm)
        {
            frm.Size = Common.formSize;
            //frm.Height = 1200;
            //frm.Width = 1200;
            frm.Location = this.Location;
            frm.WindowState = this.WindowState;
            StartPosition = FormStartPosition.Manual;

            frm.FormClosing += delegate
            {
                Show();
                Size = Common.formSize;
                WindowState = frm.WindowState;
                StartPosition = FormStartPosition.Manual;
                resizePb.Image = this.WindowState == FormWindowState.Maximized ? Properties.Resources.full_close : Properties.Resources.full_open;
                Location = frm.Location;
            };

            frm.Show();
            this.Hide();
        }

        private void a2pb_Click(object sender, EventArgs e)
        {
            FormSwitch(new TheInternationalCompetitionForm());
        }

        private void a3pb_Click(object sender, EventArgs e)
        {
            FormSwitch(new TheIsraeliCompetitionForm());
        }

        private void a4pb_Click(object sender, EventArgs e)
        {
            FormSwitch(new TheIndependentShortFilmCompetitionForm());
        }

        private void a5pb_Click(object sender, EventArgs e)
        {
            FormSwitch(new TheIsraeliCriticsAssociationForm());
        }

        private void a6pb_Click(object sender, EventArgs e)
        {
            FormSwitch(new DigitalExperimentalCompetitionForm());
        }

        private void a7pb_Click(object sender, EventArgs e)
        {
            FormSwitch(new DigitalExperimentalCompetitionForm());
        }

        private void a8pb_Click(object sender, EventArgs e)
        {
            FormSwitch(new FestivalHightlightsForm());
        }

        private void CloseApp(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
