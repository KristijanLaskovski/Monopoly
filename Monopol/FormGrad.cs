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
    public partial class FormGrad : Form
    {
        public Grad g1;
        public Igrach i1;
        public FormGrad(Grad g2, Igrach i2)
        {
            InitializeComponent();
            g1 = g2;
            i1 = i2;
            if (i1.money < g1.Cena)
                btnDa.Enabled = false;
            DoubleBuffered = true;
        }

        private void FormGrad_Paint_1(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.pozadinaGrad, this.ClientRectangle);
            PointF p = new PointF();
            Font f = new Font("Garamond", 16, FontStyle.Bold);
            p.X = 15;
            p.Y = 23;
            e.Graphics.DrawString("Добродојдовте    во ",f,new SolidBrush(Color.Firebrick),p);
            p.X = 251;
            p.Y = 23;
            e.Graphics.DrawString(g1.Ime, f, new SolidBrush(Color.Firebrick), p);
            f = new Font("Garamond", 12, FontStyle.Bold);
            p.X = 15;
            p.Y = 70;
            e.Graphics.DrawString("Цена на земјиштето:", f, new SolidBrush(Color.Firebrick), p);
            p.X = 15;
            p.Y = 105;
            e.Graphics.DrawString(g1.Cena.ToString(), f, new SolidBrush(Color.Firebrick), p);
            p.X = 15;
            p.Y = 140;
            e.Graphics.DrawString("Данок на земјиштето:", f, new SolidBrush(Color.Firebrick), p);
            p.X = 15;
            p.Y = 175;
            e.Graphics.DrawString(g1.Danok.ToString(), f, new SolidBrush(Color.Firebrick), p);
            p.X = 15;
            p.Y = 210;
            e.Graphics.DrawString("Сопственик:", f, new SolidBrush(Color.Firebrick), p);
            p.X = 15;
            p.Y = 245;
            if (g1.Sopstvenik == null)
                e.Graphics.DrawString("Нема", f, new SolidBrush(Color.Firebrick), p);
            else
            {
                e.Graphics.DrawString(i1.ime, f, new SolidBrush(Color.Firebrick), p);
                if (g1.Sopstvenik.ime != i1.ime)
                {
                    if (i1.money > i1.money - g1.Danok)
                    {
                        i1.money = Convert.ToInt32(i1.money - g1.Danok);
                    }
                    //else GAME OVER
                }
                btnDa.Enabled = false;
                btnNe.Enabled = false;
            }
            p.X = 15;
            p.Y = 280;
            e.Graphics.DrawString("Дали ќе го купиш?", f, new SolidBrush(Color.Firebrick), p);
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

        private void btnDa_Click(object sender, EventArgs e)
        {
                this.DialogResult = DialogResult.OK;
                this.Close();
        }

        private void btnNe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
