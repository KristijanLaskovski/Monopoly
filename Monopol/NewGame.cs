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
    public partial class NewGame : Form
    {
        public Animacija coveche1 { get; set; }
        public Animacija coveche2 { get; set; }
        public Animacija tekovna { get; set; }
        string ime1, ime2, imetekovno;
        Bitmap b;
        Bitmap[] slikiCoveche1;
        Bitmap[] slikiCoveche2;
        Graphics g, obj;
        public Rectangle play { get; set; }
        public Rectangle left { get; set; }
        public Rectangle right { get; set; }
        public Rectangle back { get; set; }

        public NewGame()
        {
            InitializeComponent();
            timer1.Start();
            textBox1.Text = "";
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

        private void NewGame_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            play = new Rectangle(new Point(500, 450), new Size(110, 40));
            left = new Rectangle(new Point(500, 350), new Size(40, 40));
            right = new Rectangle(new Point(325, 350), new Size(40, 40));
            back = new Rectangle(new Point(270, 450), new Size(110, 40));
            b = new Bitmap(this.Width, this.Height);
            obj = Graphics.FromImage(b);
            slikiCoveche1 = new Bitmap[] { Properties.Resources.c1, Properties.Resources.c2, Properties.Resources.c3, Properties.Resources.c4, Properties.Resources.c5,
                Properties.Resources.c6, Properties.Resources.c7, Properties.Resources.c8, Properties.Resources.c9, Properties.Resources.c10,
                Properties.Resources.c11, Properties.Resources.c12, Properties.Resources.c13, Properties.Resources.c14, 
                Properties.Resources.c15, Properties.Resources.c16, Properties.Resources.c17, Properties.Resources.c18,
                Properties.Resources.c19};
            slikiCoveche2 = new Bitmap[] { Properties.Resources.cc1, Properties.Resources.cc2, Properties.Resources.cc3, Properties.Resources.cc4, Properties.Resources.cc5,
                Properties.Resources.cc6, Properties.Resources.cc7, Properties.Resources.cc8, Properties.Resources.cc9, Properties.Resources.cc10,
                Properties.Resources.cc11, Properties.Resources.cc12, Properties.Resources.cc13, Properties.Resources.cc14, 
                Properties.Resources.cc15, Properties.Resources.cc16, Properties.Resources.cc17, Properties.Resources.cc18,
                Properties.Resources.cc19};
            coveche1 = new Animacija(slikiCoveche1);
            coveche2 = new Animacija(slikiCoveche2);
            tekovna = coveche1;
            ime1 = "Дени";
            ime2 = "Вики";
            imetekovno = ime1;

        }
        public void precrtaj()
        {
            obj.Clear(Color.Beige);
            obj.DrawImage(Properties.Resources.too, 0, 0, this.Width, this.Height);
            obj.DrawImage(Properties.Resources.yeey, 200, 160, 480, 380);
            obj.DrawImage(Properties.Resources.nova_igra1, 325, 150, 210, 50);
            obj.DrawImage(Properties.Resources.ime, 270, 233, 120, 30);
            obj.DrawImage(Properties.Resources.igraj, 520, 450, 110, 40);
            obj.DrawRectangle(new Pen(Color.Transparent), play);
            obj.DrawImage(Properties.Resources.nazad, 250, 450, 110, 40);
            obj.DrawRectangle(new Pen(Color.Transparent), back);
            obj.DrawImage(Properties.Resources.strelka1___Copy, 500, 350, 40, 40);
            obj.DrawImage(Properties.Resources.strelka2, 335, 350, 40, 40);
            obj.DrawRectangle(new Pen(Color.Transparent), left);
            obj.DrawRectangle(new Pen(Color.Transparent), right);
            obj.DrawRectangle(new Pen(Color.Transparent), back);
            obj.DrawImage(tekovna.dajmiSlika(), 370, 250, 150, 200);
            label1.Text = imetekovno;
            g.DrawImage(b, Point.Empty);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            precrtaj();
        }
        private void NewGame_MouseDown(object sender, MouseEventArgs e)
        {

            if (this.play.Contains(e.Location))
            {
                Form1 f = new Form1(imetekovno, textBox1.Text);
                f.Show();
                this.Hide();
            }
            else if (this.left.Contains(e.Location))
            {
                tekovna = coveche2;
                imetekovno = ime2;
                precrtaj();

            }
            else if (this.back.Contains(e.Location))
            {
                Pochetna p = new Pochetna(2);
                p.Show();
                this.Hide();

            }
            else if (this.right.Contains(e.Location))
            {
                tekovna = coveche1;
                imetekovno = ime1;
                precrtaj();
            }
        }

        private void NewGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                tekovna = coveche2;
                imetekovno = ime2;
                precrtaj();
            }
            if (e.KeyCode == Keys.Right)
            {
                tekovna = coveche1;
                imetekovno = ime1;
                precrtaj();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                tekovna = coveche2;
                imetekovno = ime2;
                precrtaj();
            }
            if (e.KeyCode == Keys.Right)
            {
                tekovna = coveche1;
                imetekovno = ime1;
                precrtaj();
            }

        }

        private void NewGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}