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
    public partial class FormHelp : Form
    {
        Bitmap b;
        //Bitmap[] sliki;
        Graphics g, obj;

        public FormHelp()
        {
            InitializeComponent();
        }

        private void FormHelp_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            b = new Bitmap(this.Width, this.Height);
            obj = Graphics.FromImage(b);
            this.BackColor = Color.Beige;
            string s1 = "На почетокот на играта секој играч има почетен капитал \nдоделен од Банката  во износ од 70000. Играта се \nсостои од купување на градови кои ги посетува играчот\nво текот на својата игра.Доколку е заинтересиран истиот\n го купува ,под услов да  има доволно салдо за негово\nплаќање.Динамиката на игрта е по купувањето на одреден\nброј на градови.Таа се состои од плаќање на данок докулку\nиграчот посети град кој e во сопственост на\nнеговиот противник.Тука започнува магијата на МОНОПОЛ!!";
            string s2 = "Доколку играчот застане на полето ОДИ ВО\nЗАТВОР задолжително преминува во полето ЗАТВОР!\n  Од затвор може да се излезе само доколку\nигрчот исплати данок од 7000. Овие пари \nавтоматски се земаат од неговото салдо. Во затвор\n играчот не добива никакви приход, односно\n доколку противникот застане на поле во \n сопственост на играчот тој не плаќа данок ";
            string s3 = "ДАНОК-> играчот мора да плати 7000\nПАРКИНГ-> играчот добива 7000\nБИНГО->играчот добива 10000\nШАНСА->играчот го извршува она што се бара\nИЗНЕНАДУВАЊЕ->играчот го извршува барањето";
            string s4 = " And now . . .\n  Let the game \n    begin!!!!";
            string s5 = "Играта завршува кога\n барем еден од играчите ке банкротира\n односно неговото салдо ке изнесува 0 ";
            label3.Text = s1;
            label5.Text = s2;
            label1.Text = s3;
            label4.Text = s4;
            label6.Text = s5;

        }

        private void FormHelp_FormClosed(object sender, FormClosedEventArgs e)
        {
            Pochetna p = new Pochetna(2);
            p.Show();
            this.Hide();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Pochetna p = new Pochetna(2);
            p.Show();
            this.Hide();
        }
    }
}