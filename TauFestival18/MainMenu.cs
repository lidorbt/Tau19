using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tau19
{
    public partial class MainMenu : Form
    {
        private Form[] forms;

        public MainMenu()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            forms = new Form[] {
                new DigitalExperimentalCompetitionForm { Location = this.Location, StartPosition = FormStartPosition.Manual, Size = this.Size },
                new TheIsraeliCriticsAssociationForm { Location = this.Location, StartPosition = FormStartPosition.Manual, Size = this.Size },
                new TheInternationalCompetitionForm { Location = this.Location, StartPosition = FormStartPosition.Manual, Size = this.Size },
                new TheIsraeliCompetitionForm { Location = this.Location, StartPosition = FormStartPosition.Manual, Size = this.Size },
                new TheIndependentShortFilmCompetitionForm { Location = this.Location, StartPosition = FormStartPosition.Manual, Size = this.Size },
                new FestivalHightlightsForm { Location = this.Location, StartPosition = FormStartPosition.Manual, Size = this.Size },
            };

            pictureBox5_Click_1(null, null);
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

        private void FormSwitch(Form frm)
        {
            frm.Size = this.Size;
            frm.Location = this.Location;
            frm.WindowState = this.WindowState;
            StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate {
                this.Show();
                this.Size = frm.Size;
                this.WindowState = frm.WindowState;
                this.pictureBox5.Image = this.WindowState == FormWindowState.Maximized ? Properties.Resources.full_close : Properties.Resources.full_open;
            };
            // לשחר - למקרה שאתה רואה את השורות הבאות ולא מבין למה זה ככה
            // זה מופיע 3 פעמים כדי שלא יהיה אפקט פתיחה / סגירה 
            frm.Show();
            frm.Hide();
            frm.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Maximized)
            {
                this.TopMost = false;
                this.WindowState = FormWindowState.Normal;
                this.pictureBox5.Image = Properties.Resources.full_open;
            }
            else
            {
                this.TopMost = true;
                this.WindowState = FormWindowState.Maximized;
                this.pictureBox5.Image = Properties.Resources.full_close;
            }
        }

        private void a2pb_Click(object sender, EventArgs e)
        {
            FormSwitch(new TheInternationalCompetitionForm { Location = this.Location, StartPosition = FormStartPosition.Manual, Size = this.Size });
        }

        private void a3pb_Click(object sender, EventArgs e)
        {
            FormSwitch(new TheIsraeliCompetitionForm { Location = this.Location, StartPosition = FormStartPosition.Manual, Size = this.Size });
        }

        private void a4pb_Click(object sender, EventArgs e)
        {
            FormSwitch(new TheIndependentShortFilmCompetitionForm { Location = this.Location, StartPosition = FormStartPosition.Manual, Size = this.Size });
        }

        private void a5pb_Click(object sender, EventArgs e)
        {
            FormSwitch(new TheIsraeliCriticsAssociationForm { Location = this.Location, StartPosition = FormStartPosition.Manual, Size = this.Size });
        }

        private void a6pb_Click(object sender, EventArgs e)
        {
            FormSwitch(new DigitalExperimentalCompetitionForm { Location = this.Location, StartPosition = FormStartPosition.Manual, Size = this.Size });
        
        }

        private void a7pb_Click(object sender, EventArgs e)
        {
            FormSwitch(new DigitalExperimentalCompetitionForm { Location = this.Location, StartPosition = FormStartPosition.Manual, Size = this.Size });
        }

        private void a8pb_Click(object sender, EventArgs e)
        {
            FormSwitch(new FestivalHightlightsForm { Location = this.Location, StartPosition = FormStartPosition.Manual, Size = this.Size });
        }
    }
}
