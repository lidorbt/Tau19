using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

enum FormsEnum
{
    DigitalExperimental,
    FestivalHightlights,
    IndependentShort,
    International,
    Israeli,
    IsraeliCritics
}

namespace Tau19
{
    public partial class MainMenu : Form
    {
        private Dictionary<FormsEnum, Form> formsDict = new Dictionary<FormsEnum, Form>();

        public MainMenu()
        {
            InitializeComponent();

            ClientSize = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.85), (int)(Screen.PrimaryScreen.Bounds.Height * 0.85));

            Common.FormLocation = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            MinimizeBox = false;
            MaximizeBox = false;


            formsDict.Add(FormsEnum.DigitalExperimental, new DigitalExperimentalCompetitionForm());
            formsDict.Add(FormsEnum.FestivalHightlights, new FestivalHightlightsForm());
            formsDict.Add(FormsEnum.IndependentShort, new TheIndependentShortFilmCompetitionForm());
            formsDict.Add(FormsEnum.International, new TheInternationalCompetitionForm());
            formsDict.Add(FormsEnum.Israeli, new TheIsraeliCompetitionForm());
            formsDict.Add(FormsEnum.IsraeliCritics, new TheIsraeliCriticsAssociationForm());

            //Resize(this.resizePb, null);
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
        //                if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE) && clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
        //                {
        //                    m.Result = (IntPtr)2/*HTCAPTION*/ ;
        //                    Common.FormLocation = new Point(this.Location.X, this.Location.Y);
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

        private void FormSwitch(Form frm)
        {
            frm.Location = this.Location;
            frm.WindowState = this.WindowState;
            frm.Location = Common.FormLocation;

            frm.VisibleChanged += delegate
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
            FormSwitch(formsDict[FormsEnum.International]);
        }

        private void a3pb_Click(object sender, EventArgs e)
        {
            FormSwitch(formsDict[FormsEnum.Israeli]);
        }

        private void a4pb_Click(object sender, EventArgs e)
        {
            FormSwitch(formsDict[FormsEnum.IndependentShort]);
        }

        private void a5pb_Click(object sender, EventArgs e)
        {
            FormSwitch(formsDict[FormsEnum.IsraeliCritics]);
        }

        private void a6pb_Click(object sender, EventArgs e)
        {
            FormSwitch(formsDict[FormsEnum.DigitalExperimental]);
        }

        private void a7pb_Click(object sender, EventArgs e)
        {
            FormSwitch(formsDict[FormsEnum.DigitalExperimental]);
        }

        private void a8pb_Click(object sender, EventArgs e)
        {
            FormSwitch(formsDict[FormsEnum.FestivalHightlights]);
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
