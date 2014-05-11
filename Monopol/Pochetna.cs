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
    public partial class Pochetna : Form
    {
        public Animacija slideShow { get; set; }
        Bitmap[] sliki;
        int i = 0;
        int mode;
        public Rectangle nigra { get; set; }
        public Rectangle pomos { get; set; }
        public Rectangle izlez { get; set; }
        System.Media.SoundPlayer pesna;
        public Pochetna(int k)
        {
            mode = k;
            
            InitializeComponent();
            DoubleBuffered = true;
            nigra = new Rectangle(new Point(255, 278), new Size(350, 60));
            pomos = new Rectangle(new Point(305, 378), new Size(250, 60));
            izlez = new Rectangle(new Point(330, 478), new Size(200, 60));
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
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
        private void Pochetna_Load(object sender, EventArgs e)
        {
            pesna = new System.Media.SoundPlayer(Properties.Resources.Monopoly_Deluxe_Music_2);
            pesna.Play();
            this.BackgroundImage = Properties.Resources.finkifinki;
            sliki = new Bitmap[] {Properties.Resources.finkifinki, Properties.Resources.finki1, Properties.Resources.nie,
                 Properties.Resources.value,Properties.Resources.dice};
            slideShow = new Animacija(sliki);
        }
        private void Pochetna_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.nigra.Contains(e.Location))
            {
                pesna.Stop();
                NewGame a = new NewGame();
                a.Show();
                this.Hide();
            }
            else if (this.izlez.Contains(e.Location))
            {
                Environment.Exit(1);

            }
            else if (this.pomos.Contains(e.Location))
            {
                FormHelp n = new FormHelp();
                n.Show();
                this.Hide();

            }
        }

        private void Pochetna_Paint(object sender, PaintEventArgs e)
        {
            if (mode == 1)
            {
                e.Graphics.DrawImage(slideShow.dajmiSlika(), 0, 0, this.Width, this.Height);
                i++;
                if (i == 6)
                {
                    i = 0;
                    timer1.Stop();
                    e.Graphics.Clear(Color.Beige);
                    e.Graphics.DrawImage(Properties.Resources.too, this.ClientRectangle);
                    e.Graphics.DrawImage(Properties.Resources.nigra, 255, 278, 350, 60);
                    e.Graphics.DrawImage(Properties.Resources.pomos, 305, 378, 250, 60);
                    e.Graphics.DrawImage(Properties.Resources.izlez, 330, 478, 200, 60);
                    e.Graphics.DrawImage(Properties.Resources.monopolnas, 30, 100, 800, 100);
                }
            }
            else if (mode == 2)
            {
                e.Graphics.Clear(Color.Beige);
                e.Graphics.DrawImage(Properties.Resources.too, this.ClientRectangle);
                e.Graphics.DrawImage(Properties.Resources.nigra, 255, 278, 350, 60);
                e.Graphics.DrawImage(Properties.Resources.pomos, 305, 378, 250, 60);
                e.Graphics.DrawImage(Properties.Resources.izlez, 330, 478, 200, 60);
                e.Graphics.DrawImage(Properties.Resources.monopolnas, 30, 100, 800, 100);
            }

        }

        private void Pochetna_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}