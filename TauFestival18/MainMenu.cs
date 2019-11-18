using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Tau19
{
    public partial class MainMenu : Form
    {
        private Form[] forms;

        public MainMenu()
        {
            InitializeComponent();
            ClientSize = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.7), (int)(Screen.PrimaryScreen.Bounds.Height * 0.7));
            forms = new Form[] {
                new DigitalExperimentalCompetitionForm(),
                new TheIsraeliCriticsAssociationForm(),
                new TheInternationalCompetitionForm(),
                new TheIsraeliCompetitionForm(),
                new TheIndependentShortFilmCompetitionForm(),
                new FestivalHightlightsForm(),
            };

            Resize(this.resizePb, null);
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

        private new void Resize(object sender, EventArgs e)
        {
            Common.Resize(sender, e, this, this.resizePb);
        }

        private void FormSwitch(Form frm)
        {
            frm.Location = this.Location;
            frm.WindowState = this.WindowState;
            frm.Location = Common.FormLocation;

            frm.FormClosing += delegate
            {
                Show();
                WindowState = frm.WindowState;
                resizePb.Image = this.WindowState == FormWindowState.Maximized ? Properties.Resources.full_close : Properties.Resources.full_open;
                Location = Common.FormLocation;
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

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
