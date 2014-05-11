using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monopol
{
    public partial class FormaRazno : Form
    {
        int id;
        Animacija anim1, anim3, anim4, anim2, anim5, anim6, anim7;
        Karticka kar;
        String[] pom;
        public FormaRazno(int i, Karticka k1)
        {

            id = i;
            kar = k1;
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void FormaRazno_Load(object sender, EventArgs e)
        {
            if (id == 1)
            {
                System.Media.SoundPlayer pesna = new System.Media.SoundPlayer(Properties.Resources.Tom_und_Jerry_german_Intro);
                pesna.Play();
            
            }
            anim1 = new Animacija(new Bitmap[] {Properties.Resources.prasalnik_000,
                Properties.Resources.prasalnik_001,Properties.Resources.prasalnik_002,
                Properties.Resources.prasalnik_003,Properties.Resources.prasalnik_004,
                Properties.Resources.prasalnik_005,Properties.Resources.prasalnik_006,
                Properties.Resources.prasalnik_007,Properties.Resources.prasalnik_008,
                Properties.Resources.prasalnik_009,Properties.Resources.prasalnik_010,
                Properties.Resources.prasalnik_011,Properties.Resources.prasalnik_012,
                Properties.Resources.prasalnik_013});

            anim4 = new Animacija(new Bitmap[] {Properties.Resources.prasalnik_013,
                Properties.Resources.prasalnik_012,Properties.Resources.prasalnik_011,
                Properties.Resources.prasalnik_010,Properties.Resources.prasalnik_009,
                Properties.Resources.prasalnik_008,Properties.Resources.prasalnik_007,
                Properties.Resources.prasalnik_006,Properties.Resources.prasalnik_005,
                Properties.Resources.prasalnik_004,Properties.Resources.prasalnik_003,
                Properties.Resources.prasalnik_002,Properties.Resources.prasalnik_001,
                Properties.Resources.prasalnik_000});
            anim2 = new Animacija(new Bitmap[] { Properties.Resources.bp1, Properties.Resources.bp2, Properties.Resources.bp3 });
            anim3 = new Animacija(new Bitmap[] {
                Properties.Resources.sansa_001,Properties.Resources.sansa_002,
                Properties.Resources.sansa_003,Properties.Resources.sansa_004,
                Properties.Resources.sansa_005});

            anim5 = new Animacija(new Bitmap[] {Properties.Resources.izvicnik_000,
                Properties.Resources.izvicnik_001,Properties.Resources.izvicnik_002,
                Properties.Resources.izvicnik_003,Properties.Resources.izvicnik_004,
                Properties.Resources.izvicnik_005,Properties.Resources.izvicnik_006,
                Properties.Resources.izvicnik_007,Properties.Resources.izvicnik_008,
                Properties.Resources.izvicnik_009,Properties.Resources.izvicnik_010,
                Properties.Resources.izvicnik_011,Properties.Resources.izvicnik_012,
                Properties.Resources.izvicnik_013});
            anim6 = new Animacija(new Bitmap[] {Properties.Resources.izvicnik_013,
                Properties.Resources.izvicnik_012,Properties.Resources.izvicnik_011,
                Properties.Resources.izvicnik_010,Properties.Resources.izvicnik_009,
                Properties.Resources.izvicnik_008,Properties.Resources.izvicnik_007,
                Properties.Resources.izvicnik_006,Properties.Resources.izvicnik_005,
                Properties.Resources.izvicnik_004,Properties.Resources.izvicnik_003,
                Properties.Resources.izvicnik_002,Properties.Resources.izvicnik_001,
                Properties.Resources.izvicnik_000});
            anim7 = new Animacija(new Bitmap[] {
                Properties.Resources.iz_001,Properties.Resources.iz_002,
                Properties.Resources.iz_003,Properties.Resources.iz_004,
                Properties.Resources.iz_005});


            timer1.Start();

        }
        protected override void WndProc(ref Message message)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            switch (message.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = message.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }

            base.WndProc(ref message);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            Invalidate();

        }

        private void FormaRazno_Paint(object sender, PaintEventArgs e)
        {

            if (id == 1)
            {
                
                e.Graphics.DrawImage(anim2.dajmiSlika(), 0, 0, this.Width, this.Height - 5);
                e.Graphics.DrawImage(Properties.Resources.B2, 10, 70, 200, 100);
                e.Graphics.DrawImage(Properties.Resources.B2, 10, 170, 200, 100);
                e.Graphics.DrawImage(Properties.Resources.B2, 470, 70, 200, 100);
                e.Graphics.DrawImage(Properties.Resources.B2, 470, 170, 200, 100);

                label1.Visible = false;
                label2.Visible = false;
            }
            if (id == 2)
            {
                label1.Visible = false;
                label2.Visible = false;
                e.Graphics.DrawImage(Properties.Resources.gray, 0, 0, this.Width, this.Height);
                e.Graphics.DrawImage(Properties.Resources.zatvor12, 20, 200, 200, 100);
                e.Graphics.DrawImage(Properties.Resources.platete, 20, 90, 200, 100);
                e.Graphics.DrawImage(Properties.Resources.zatvor4, 20, 10, 200, 100);
                e.Graphics.DrawImage(Properties.Resources.resetki, 300, 0, 500, 500);
                e.Graphics.DrawImage(Properties.Resources._7000, 220, 90, 200, 100);
            }
            if (id == 3)
            {

                label1.Visible = false;
                label2.Visible = false;
                e.Graphics.DrawImage(Properties.Resources.p11, 30, 55, 200, 100);
                e.Graphics.DrawImage(Properties.Resources.n11, 30, 15, 200, 100);

                e.Graphics.DrawImage(Properties.Resources.balonce1, 230, -20, 400, 200);
                e.Graphics.DrawImage(Properties.Resources.zaplakanje, 260, 10, 300, 70);
                e.Graphics.DrawImage(Properties.Resources._7000, 320, 70, 180, 80);
                e.Graphics.DrawImage(Properties.Resources.danok, 30, 200, 300, 150);
                e.Graphics.DrawImage(Properties.Resources.tax, 440, 150, 200, 200);

            }
            if (id == 4)
            {
                label1.Visible = false;
                label2.Visible = false;
                e.Graphics.DrawImage(Properties.Resources.zeleno1, 0, 0, this.Width, this.Height);
                e.Graphics.DrawImage(Properties.Resources.parking1, 100, 2, 420, 50);
                e.Graphics.DrawImage(Properties.Resources.podignete, 150, 80, 300, 60);
                e.Graphics.DrawImage(Properties.Resources._7000, 200, 120, 170, 100);
                e.Graphics.DrawImage(Properties.Resources.pp1, 7, 165, 180, 180);
                e.Graphics.DrawImage(Properties.Resources.parkingS, 360, 150, 300, 200);

            }
            if (id == 5)
            {
                label1.Visible = false;
                label2.Visible = false;
                e.Graphics.DrawImage(Properties.Resources.red, 0, 0, this.Width, this.Height);
                e.Graphics.DrawImage(Properties.Resources.bb, 30, 30, 150, 250);
                e.Graphics.DrawImage(Properties.Resources.KRAJ, 240, 40, 220, 70);
                e.Graphics.DrawImage(Properties.Resources.NA, 480, 42, 130, 65);
                e.Graphics.DrawImage(Properties.Resources.IGRATA, 290, 120, 230, 80);
                e.Graphics.DrawImage(Properties.Resources.sad, 360, 230, 120, 80);

            }
            if (id == 6)
            {

                pom = kar.Opis.Split(',');
                e.Graphics.DrawImage(Properties.Resources.pozadinaKarticki, this.ClientRectangle);
                e.Graphics.DrawImage(anim1.dajmiSlika(), 30, 10, 100, 100);
                label1.Visible = true;
                label2.Visible = true;
                e.Graphics.DrawImage(anim3.dajmiSlika(), 185, 20, 300, 100);
                label1.Text = pom[0];
                label1.SetBounds(185, this.Height - 200, 50, 500);
                label2.Text = pom[1];
                label2.SetBounds(185, this.Height - 150, 50, 500);
            }
            if (id == 7)
            {
                pom = kar.Opis.Split(',');
                e.Graphics.DrawImage(Properties.Resources.pozadinaKarticki, this.ClientRectangle);
                e.Graphics.DrawImage(anim5.dajmiSlika(), 30, 10, 100, 100);
                e.Graphics.DrawImage(anim7.dajmiSlika(), 185, 20, 300, 100);
                label1.Visible = true;
                label2.Visible = true;
                label1.Text = pom[0];
                label1.SetBounds(185, this.Height - 200, 50, 500);
                label2.Text = pom[1];
                label2.SetBounds(185, this.Height - 150, 50, 500);
            }
            if (id == 8)
            {
                e.Graphics.DrawImage(anim2.dajmiSlika(), 0, 0, this.Width, this.Height - 5);
                e.Graphics.DrawImage(Properties.Resources.cestitki,10,100,200,100);
                e.Graphics.DrawImage(Properties.Resources.cestitki, 430, 100, 200, 100);
                e.Graphics.DrawImage(Properties.Resources.viepobedivte, 130, 250, 400, 100);
                
                label1.Visible = false;
                label2.Visible = false;
            }
        }

        private void FormaRazno_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (id == 8 || id == 5)
            {
                Pochetna p = new Pochetna(2);
                p.Show();
                this.DialogResult = DialogResult.Cancel;
            }
            this.Close();
        }

    }
}