using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Monopol
{
    public partial class Form1 : Form
    {
        public Igrach igrach1 { get; set; }
        public Igrach igrach2 { get; set; }
        Animacija animacija;
        string tekovno;
        Bitmap b, tekKocka1;
        int K1, sledna, kockaVrednost;
        Bitmap[] kocki, coveche, coveche2;
        Graphics g, kocka1, pole;
        bool kliknat = false;
        Brush brush;
        List<Karticka> karticki, karticki1;
        List<Pole> tabla;
        List<Drzava> listaDrzavi;
        Random r;
        ListaIgraci lista;
        System.Media.SoundPlayer muzika;
        public Form1(string ime, string moeIme)
        {
            tekovno = ime;
            InitializeComponent();
            lista = new ListaIgraci();
            kockaVrednost = 0;
            DoubleBuffered = true;
            tekKocka1 = null;
            karticki = new List<Karticka>();
            karticki1 = new List<Karticka>();
            Karticka k0 = new Karticka("Роденден ви е., Банката ве наградува со 3 000.", (float)3000, 0);
            Karticka k1 = new Karticka("Наследувате од далечен роднина., Подигнете 7 000.", (float)7000, 1);
            Karticka k2 = new Karticka("Добитник сте на стипендија., Подигнете 5 500.", (float)5500, 2);
            Karticka k3 = new Karticka("Осигурувањето ви истекло., Морате да платете 2 000.", (float)-2000, 3);
            Karticka k4 = new Karticka("Сте уплатиле за патување., Платете 8 000.", (float)-8000, 4);
            Karticka k5 = new Karticka("Автомобилот ви се расипал., Платете 4 000 за поправка.", (float)-4000, 5);
            Karticka k6 = new Karticka("Потребен ви е нов почеток., Вратете се на СТАРТ!", (float)0, 6);
            Karticka k7 = new Karticka("Го прекршивте законот., Морате да одите во затвор!", (float)0, 7);
            Karticka k8 = new Karticka("Возачката ви истекла., платете 4 000 за нова", (float)-4000, 9);
            Karticka k9 = new Karticka("Добивте егзотично патување., Посетете го Дубаи!", (float)0, 8);

            tabla = new List<Pole>();
            listaDrzavi = new List<Drzava>();
            Drzava d1 = new Drzava();
            d1.Ime = "Македонија";
            Grad g1 = new Grad();
            g1.Ime = "Крива Паланка";
            g1.Opis = "Крива Паланка е град сместен во североисточниот дел на Република Македонија";
            g1.Cena = 16000;
            g1.Danok = g1.Cena * 3 / 10;
            g1.Slika = new Bitmap(Properties.Resources.KP);
            d1.Gradovi.Add(g1);
            Grad g2 = new Grad();
            g2.Ime = "Гостивар";
            g2.Opis = "Гостивар е град сместен Западниот дел на Македонија";
            g2.Cena = 18000;
            g2.Danok = g2.Cena * 3 / 10;
            g2.Slika = new Bitmap(Properties.Resources.GV);
            d1.Gradovi.Add(g2);
            listaDrzavi.Add(d1);
            Drzava d2 = new Drzava();
            d2.Ime = "Франција";
            Grad g3 = new Grad();
            g3.Ime = "Париз";
        g3.Opis = "Париз е град сместен во северниот дел Франција на бреговите на реката Сена";
            g3.Cena = 12000;
            g3.Danok = g3.Cena * 3 / 10;
            g3.Slika = new Bitmap(Properties.Resources.PARIZ);
            d2.Gradovi.Add(g3);
            Grad g4 = new Grad();
            g4.Ime = "Марсеј";
            g4.Opis = "Марсеј е град кој лежи на Лионскиот залив во Франција";
            g4.Cena = 10000;
            g4.Danok = g4.Cena * 3 / 10;
            g4.Slika = new Bitmap(Properties.Resources.MARSEJ);
            d2.Gradovi.Add(g4);
            Grad g5 = new Grad();
            g5.Ime = "Лион";
            g5.Opis = "Лион е град во источниот дел на Средна Франција";
            g5.Cena = 11000;
            g5.Danok = g5.Cena * 3 / 10;
            g5.Slika = new Bitmap(Properties.Resources.LION);
            d2.Gradovi.Add(g5);
            listaDrzavi.Add(d2);
            Drzava d3 = new Drzava();
            Grad g6 = new Grad();
            g6.Ime = "Лондон";
            g6.Opis = "Лондон е главен град на Англија и Обединетото Кралство";
            g6.Cena = 15000;
            g6.Danok = g6.Cena * 3 / 10;
            g6.Slika = new Bitmap(Properties.Resources.London);
            d3.Gradovi.Add(g6);
            Grad g7 = new Grad();
            g7.Ime = "Манчестер";
            g7.Opis = "Манчестер е град во Англија и Велика Британија";
            g7.Cena = 13000;
            g7.Danok = g7.Cena * 3 / 10;
            g7.Slika = new Bitmap(Properties.Resources.MSTER);
            d3.Gradovi.Add(g7);
            listaDrzavi.Add(d3);
            Drzava d4 = new Drzava();
            Grad g8 = new Grad();
            g8.Ime = "Абу Даби";
            g8.Opis = "Абу Даби е главен град и втор најголем град во Обединетите Арапски Емирати.";
            g8.Cena = 17000;
            g8.Danok = g8.Cena * 3 / 10;
            g8.Slika = new Bitmap(Properties.Resources.aBUDABI);
            d4.Gradovi.Add(g8);
            Grad g9 = new Grad();
            g9.Ime = "Дубаи";
            g9.Opis = "Дубаи е еден од седумте емирати во Обединетите Арапски Емирати.Тој се наоѓа јужно од Персискиот Залив на Арапскиот Полуостров.";
            g9.Cena = 19000;
            g9.Danok = g9.Cena * 3 / 10;
            g9.Slika = new Bitmap(Properties.Resources.DUBAI);
            d4.Gradovi.Add(g9);
            listaDrzavi.Add(d4);
            Drzava d5 = new Drzava();
            d5.Ime = "Германија";
            Grad g10 = new Grad();
            g10.Ime = "Минхен";
            g10.Opis = "Минхен е главен град на германската покраина Баварија. Градот лежи на реката Изар, северно од Баварските Алпи. ";
            g10.Cena = 15000;
            g10.Danok = g10.Cena * 3 / 10;
            g10.Slika = new Bitmap(Properties.Resources.MINEHN);
            d5.Gradovi.Add(g10);
            Grad g11 = new Grad();
            g11.Ime = "Франкфурт";
            g11.Opis = "Франкфурт е најголемиот град во германската покраина Хесен и петти по големина во Германија, со 672.000 жители.";
            g11.Cena = 14000;
            g11.Danok = g11.Cena * 3 / 10;
            g11.Slika = new Bitmap(Properties.Resources.FFF);
            d5.Gradovi.Add(g11);
            Grad g12 = new Grad();
            g12.Ime = "Берлин";
            g12.Opis = "Берлин главен град на Германија и една од нејзините шеснаесет покраини. Со население од 3.45 милиони жители, Берлин е најголемиот град во Германија. ";
            g12.Cena = 16000;
            g12.Danok = g12.Cena * 3 / 10;
            g12.Slika = new Bitmap(Properties.Resources.BERLIN);
            d5.Gradovi.Add(g12);
            listaDrzavi.Add(d5);
            Drzava d6 = new Drzava();
            d6.Ime = "Италија";
            Grad g13 = new Grad();
            g13.Ime = "Милано";
            g13.Opis = "Милано е вториот најголем град во Италија и главен град на регионот Ломбардија. Самиот град има население од околу 1,35 милиони";
            g13.Cena = 10000;
            g13.Danok = g13.Cena * 3 / 10;
            g13.Slika = new Bitmap(Properties.Resources.MILANO);
            d6.Gradovi.Add(g13);
            Grad g14 = new Grad();
            g14.Ime = "Рим";
            g14.Opis = "Рим е град и посебна општина во Италија. Рим е главен град на Италија како и главен град на Лацио.";
            g14.Cena = 11000;
            g14.Danok = g14.Cena * 3 / 10;
            g14.Slika = new Bitmap(Properties.Resources.RIM);
            d6.Gradovi.Add(g14);
            listaDrzavi.Add(d6);
            Karticka k10 = new Karticka("Старт", (float)0, 10);
            Karticka k11 = new Karticka("Затвор", (float)0, 11);
            Karticka k12 = new Karticka("Паркинг", (float)0, 12);
            Karticka k13 = new Karticka("Бингооооо", (float)0, 13);
            Karticka k14 = new Karticka("Оди во затвор", (float)0, 14);
            Karticka k15 = new Karticka("Данок", (float)0, 15);
            karticki.Add(k0);
            karticki.Add(k1);
            karticki.Add(k2);
            karticki.Add(k3);
            karticki.Add(k4);
            karticki.Add(k5);
            karticki.Add(k6);
            karticki.Add(k7);
            karticki.Add(k8);
            karticki.Add(k9);
            karticki1.Add(k10);
            karticki1.Add(k11);
            karticki1.Add(k12);
            karticki1.Add(k13);
            karticki1.Add(k14);
            karticki1.Add(k15);
            tabla.Add(karticki1[0]);//Start
            tabla.Add(d1.Gradovi[0]);//Kriva Palanka
            tabla.Add(d1.Gradovi[1]);//Gostivar
            tabla.Add(d2.Gradovi[0]);//Paris
            tabla.Add(d2.Gradovi[1]);//Marsej
            tabla.Add(karticki[0]);//Iznenaduvanje1
            tabla.Add(d2.Gradovi[2]);//Lion
            tabla.Add(karticki1[1]);//Zatvor
            tabla.Add(d3.Gradovi[0]);//London
            tabla.Add(karticki[1]);//Sansa1
            tabla.Add(karticki1[2]);//Bingo
            tabla.Add(d3.Gradovi[1]);//Manchester
            tabla.Add(karticki1[3]);//Parking
            tabla.Add(d4.Gradovi[0]);//Abu Dhabi
            tabla.Add(d4.Gradovi[1]);//Dubai
            tabla.Add(karticki[2]);//Sansa 2 
            tabla.Add(d5.Gradovi[0]);//Minhen
            tabla.Add(d5.Gradovi[1]);//Frankfurt
            tabla.Add(d5.Gradovi[2]);//Berlin
            tabla.Add(karticki1[4]);//Odi vo zatvor
            tabla.Add(d6.Gradovi[0]);//Milano
            tabla.Add(karticki[3]);//Iznenaduvanje 3
            tabla.Add(karticki1[5]);//Danok
            tabla.Add(d6.Gradovi[1]);//Rim
            //kocka
            animacija = new Animacija(new Bitmap[] { Properties.Resources.frame_000,Properties.Resources.frame_001,
                Properties.Resources.frame_002,Properties.Resources.frame_003,Properties.Resources.frame_004,Properties.Resources.frame_005,
                Properties.Resources.frame_006, Properties.Resources.frame_007,Properties.Resources.frame_008,
                Properties.Resources.frame_009,});
            kocki = new Bitmap[]{Properties.Resources._1,Properties.Resources._2,Properties.Resources._3,Properties.Resources._4,
                Properties.Resources._5,Properties.Resources._6};
            coveche = new Bitmap[] { Properties.Resources.c1, Properties.Resources.c2, Properties.Resources.c3, Properties.Resources.c4, Properties.Resources.c5,
                Properties.Resources.c6, Properties.Resources.c7, Properties.Resources.c8, Properties.Resources.c9, Properties.Resources.c10,
                Properties.Resources.c11, Properties.Resources.c12, Properties.Resources.c13, Properties.Resources.c14, 
                Properties.Resources.c15, Properties.Resources.c16, Properties.Resources.c17, Properties.Resources.c18,
                Properties.Resources.c19, };

            Animacija covecheSkok = new Animacija(coveche);
            coveche2 = new Bitmap[]{Properties.Resources.cc1, Properties.Resources.cc2, Properties.Resources.cc3, Properties.Resources.cc4, Properties.Resources.cc5,
                Properties.Resources.cc6, Properties.Resources.cc7, Properties.Resources.cc8, Properties.Resources.cc9, Properties.Resources.cc10,
                Properties.Resources.cc11, Properties.Resources.cc12, Properties.Resources.cc13, Properties.Resources.cc14, 
                Properties.Resources.cc15, Properties.Resources.cc16, Properties.Resources.cc17, Properties.Resources.cc18,
                Properties.Resources.cc19, };
            Animacija covecheSkok2 = new Animacija(coveche2);
            if (tekovno.CompareTo("Дени") == 0)
            {
                if (moeIme == "")
                {
                    igrach1 = new Igrach(covecheSkok, "Дени", false, new Point(230, 0), Properties.Resources.c1, Properties.Resources.popu);
                    igrach2 = new Igrach(covecheSkok2, "Вики", true, new Point(240, 0), Properties.Resources.cc1, Properties.Resources.popu___Copy);
                }
                else
                {
                    igrach1 = new Igrach(covecheSkok, moeIme, false, new Point(230, 0), Properties.Resources.c1, Properties.Resources.popu);
                    igrach2 = new Igrach(covecheSkok2, "Вики", true, new Point(240, 0), Properties.Resources.cc1, Properties.Resources.popu___Copy);
                }
            }
            else
            {
                if (moeIme == "")
                {
                    igrach2 = new Igrach(covecheSkok, "Дени", true, new Point(240, 0), Properties.Resources.c1, Properties.Resources.popu);
                    igrach1 = new Igrach(covecheSkok2, "Вики", false, new Point(230, 0), Properties.Resources.cc1, Properties.Resources.popu___Copy);
                }
                else
                {
                    igrach2 = new Igrach(covecheSkok, "Дени", true, new Point(240, 0), Properties.Resources.c1, Properties.Resources.popu);
                    igrach1 = new Igrach(covecheSkok2, moeIme, false, new Point(230, 0), Properties.Resources.cc1, Properties.Resources.popu___Copy);
                }
            }
            sledna = 265;
            lblIme1.Text = igrach1.ime;
            lblIme2.Text = igrach2.ime;
            MoneyC1.Text = igrach1.GiveMeMoney();
            MoneyC2.Text = igrach2.GiveMeMoney();
            lista.Add(igrach1);
            lista.Add(igrach2);

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
        private void Form1_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            b = new Bitmap(this.Width, this.Height);
            kocka1 = Graphics.FromImage(b);
            pole = Graphics.FromImage(b);
            brush = new SolidBrush(Color.LightSalmon);

        }
        private void izcrtaj()
        {

            pole.DrawImage(Properties.Resources.prazno, 180, 60, 110, 100);
            pole.DrawImage(Properties.Resources.start_large, 190, 67, 80, 80);
            pole.DrawImage(Properties.Resources.KP, 290, 60, 110, 100);
            pole.DrawImage(Properties.Resources.GV, 400, 60, 110, 100);
            pole.DrawImage(Properties.Resources.PARIZ, 510, 60, 110, 100);
            pole.DrawImage(Properties.Resources.MARSEJ, 620, 60, 110, 100);
            pole.DrawImage(Properties.Resources.prazno, 730, 60, 110, 100);
            pole.DrawImage(Properties.Resources.prashalnik, 740, 67, 90, 90);
            pole.DrawImage(Properties.Resources.LION, 840, 60, 110, 100);
            pole.DrawImage(Properties.Resources.prazno, 950, 60, 110, 100);
            pole.DrawImage(Properties.Resources.jail, 960, 66, 90, 90);

            pole.DrawImage(Properties.Resources.RIM, 180, 162, 110, 100);
            pole.DrawImage(Properties.Resources.prazno, 180, 264, 110, 100);
            pole.DrawImage(Properties.Resources.tex, 190, 273, 90, 90);
            pole.DrawImage(Properties.Resources.prazno, 180, 366, 110, 100);
            pole.DrawImage(Properties.Resources.prashalnik, 190, 373, 90, 90);
            pole.DrawImage(Properties.Resources.MILANO, 180, 468, 110, 100);
            pole.DrawImage(Properties.Resources.prazno, 180, 570, 110, 100);
            pole.DrawImage(Properties.Resources.gotoJail, 190, 576, 90, 90);

            pole.DrawImage(Properties.Resources.BERLIN, 290, 570, 110, 100);
            pole.DrawImage(Properties.Resources.FFF, 400, 570, 110, 100);
            pole.DrawImage(Properties.Resources.MINEHN, 510, 570, 110, 100);
            pole.DrawImage(Properties.Resources.prazno, 620, 570, 110, 100);
            pole.DrawImage(Properties.Resources.shansa1, 630, 577, 90, 90);
            pole.DrawImage(Properties.Resources.DUBAI, 730, 570, 110, 100);
            pole.DrawImage(Properties.Resources.aBUDABI, 840, 570, 110, 100);
            pole.DrawImage(Properties.Resources.prazno, 950, 570, 110, 100);
            pole.DrawImage(Properties.Resources.parking, 960, 577, 90, 90);

            pole.DrawImage(Properties.Resources.London, 950, 162, 110, 100);
            pole.DrawImage(Properties.Resources.prazno, 950, 264, 110, 100);
            pole.DrawImage(Properties.Resources.shansa1, 960, 273, 90, 90);
            pole.DrawImage(Properties.Resources.prazno, 950, 366, 110, 100);
            pole.DrawImage(Properties.Resources.bin, 960, 374, 90, 90);
            pole.DrawImage(Properties.Resources.MSTER, 950, 468, 110, 100);

            pole.FillRectangle(brush, 15, 250, 150, 400);
            pole.FillRectangle(brush, 1070, 250, 150, 400);
            pole.DrawImage(igrach1.golema, 45, 65, 100, 110);
            pole.DrawImage(igrach2.golema, 1095, 65, 100, 110);


            if (tekKocka1 != null)
            {

                kocka1.DrawImage(Properties.Resources.transparent, 330, 400, 250, 200);
                kocka1.DrawImage(tekKocka1, new Point(420, 456));
            }
            if (K1 == 0)
            {
                kocka1.DrawImage(igrach1.mala, new Point(igrach1.pozicija.X, igrach1.pozicija.Y));
                kocka1.DrawImage(igrach2.mala, new Point(igrach2.pozicija.X, igrach2.pozicija.Y));
            }
            if (igrach1.zemjishta.Count > 0)
            {
                sledna = 265;
                int poz = 20;
                for (int j = igrach1.zemjishta.Count - 1; j >= 0; --j)
                {
                    if (sledna > 550)
                    {
                        sledna = 265;
                        poz = 100;
                    }
                    pole.DrawImage(igrach1.zemjishta[j].Slika, poz, sledna, 60, 60);
                    sledna += 65;
                }
            }
            if (igrach2.zemjishta.Count > 0)
            {
                sledna = 265;
                int poz = 1075;
                for (int j = igrach2.zemjishta.Count - 1; j >= 0; --j)
                {
                    if (sledna > 550)
                    {
                        sledna = 265;
                        poz = 1150;
                    }
                    pole.DrawImage(igrach2.zemjishta[j].Slika, poz, sledna, 60, 60);
                    sledna += 65;
                }
            }

        }
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            kocka1.Clear(Color.SkyBlue);
            pole.DrawImage(Properties.Resources.gradPozadina, 280, 100, 680, 500);

            if (!kliknat)
            {
                kocka1.DrawImage(Properties.Resources.transparent, 330, 400, 250, 200);
                kocka1.DrawImage(kocki[0], new Point(420, 456));
            }
            izcrtaj();
            if (kliknat)
            {

                kocka1.DrawImage(Properties.Resources.transparent, 330, 400, 250, 200);
                kocka1.DrawImage(animacija.dajmiSlika(), new Point(420, 456));
                i++;
                if (i == 10)
                {

                    timer1.Stop();
                    r = new Random();
                    int broj1 = r.Next(1, 7);
                    animacija.pozicija = 0;

                    igrach1.Nared = !igrach1.Nared;
                    igrach2.Nared = !igrach2.Nared;

                    tekKocka1 = kocki[broj1 - 1];
                    K1 = broj1;
                    kockaVrednost = K1;
                    kocka1.DrawImage(kocki[broj1 - 1], new Point(420, 456));
                    timer3.Start();
                    g.DrawImage(b, Point.Empty);
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button2.BackColor = Color.SkyBlue;
                    button3.BackColor = Color.SkyBlue;
                }
                g.DrawImage(b, Point.Empty);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(String.Format("Igrach1:{0}  x= {1}  y= {2} Igrach2: {3} x2= {4} y2={5}",
            //   igrach1.ime, x, y, igrach2.ime, x2, y2));
            muzika = new System.Media.SoundPlayer(Properties.Resources.Dice_roll_sound_effect);
            muzika.Play();
            kliknat = true;
            tekKocka1 = null;
            timer1.Start();
            button1.Enabled = false;
            button1.BackColor = Color.SkyBlue;
        }
        int j = 0;
       
           private void timer3_Tick(object sender, EventArgs e)
        {
            izcrtaj();

            if (i == 10)
            {
                kocka1.Clear(Color.SkyBlue);
                pole.DrawImage(Properties.Resources.gradPozadina, 280, 100, 680, 500);
                izcrtaj();

                if (igrach1.pozicija.X < 958 && igrach1.pozicija.Y == 0 && igrach1.Nared)
                {
                    Point temp = new Point(igrach1.pozicija.X + 8, igrach1.pozicija.Y);
                    kocka1.DrawImage(igrach1.MoveOneStep(), temp);
                    igrach1.pozicija = temp;
                    kocka1.DrawImage(igrach2.mala, igrach2.pozicija);

                }
                else if (igrach2.pozicija.X < 968 && igrach2.pozicija.Y == 0 && igrach2.Nared)
                {
                    Point temp = new Point(igrach2.pozicija.X + 8, igrach2.pozicija.Y);
                    kocka1.DrawImage(igrach2.MoveOneStep(), temp);
                    kocka1.DrawImage(igrach1.mala, igrach1.pozicija);
                    igrach2.pozicija = temp;
                }
                else if (igrach1.pozicija.X == 958 && igrach1.pozicija.Y < 520 && igrach1.Nared)
                {
                    Point temp = new Point(igrach1.pozicija.X, igrach1.pozicija.Y + 8);
                    kocka1.DrawImage(igrach1.MoveOneStep(), temp);
                    kocka1.DrawImage(igrach2.mala, igrach2.pozicija);
                    igrach1.pozicija = temp;
                }
                else if (igrach2.pozicija.X == 968 && igrach2.pozicija.Y < 520 && igrach2.Nared)
                {
                    Point temp = new Point(igrach2.pozicija.X, igrach2.pozicija.Y + 8);
                    kocka1.DrawImage(igrach1.mala, igrach1.pozicija);
                    kocka1.DrawImage(igrach2.MoveOneStep(), temp);
                    igrach2.pozicija = temp;
                }
                else if (igrach1.pozicija.X > 230 && igrach1.pozicija.Y == 520 && igrach1.Nared)
                {
                    Point temp = new Point(igrach1.pozicija.X - 8, igrach1.pozicija.Y);
                    kocka1.DrawImage(igrach1.MoveOneStep(), temp);
                    kocka1.DrawImage(igrach2.mala, igrach2.pozicija);
                    igrach1.pozicija = temp;
                }
                else if (igrach2.pozicija.X > 240 && igrach2.pozicija.Y == 520 && igrach2.Nared)
                {
                    Point temp = new Point(igrach2.pozicija.X - 8, igrach2.pozicija.Y);
                    kocka1.DrawImage(igrach1.mala, igrach1.pozicija);
                    kocka1.DrawImage(igrach2.MoveOneStep(), temp);
                    igrach2.pozicija = temp;
                }
                else if (igrach1.pozicija.X == 230 && igrach1.Nared)
                {
                    Point temp = new Point(igrach1.pozicija.X, igrach1.pozicija.Y - 8);
                    kocka1.DrawImage(igrach1.MoveOneStep(), temp);
                    kocka1.DrawImage(igrach2.mala, igrach2.pozicija);
                    igrach1.pozicija = temp;
                }
                else if (igrach2.pozicija.X == 240 && igrach2.Nared)
                {
                    Point temp = new Point(igrach2.pozicija.X, igrach2.pozicija.Y - 8);
                    kocka1.DrawImage(igrach1.mala, igrach1.pozicija);
                    kocka1.DrawImage(igrach2.MoveOneStep(), temp);
                    igrach2.pozicija = temp;

                }

                j++;
                if (j == 13)
                {
                    muzika = new System.Media.SoundPlayer(Properties.Resources.Cartoon_Boing_Jump_Sound_Effect__High_Quality_Free);
                    muzika.Play();
                    K1--;
                    j = 0;
                    
                   
                    if (K1 == 0)
                    {
                        if (igrach1.Nared == false)
                        {
                            button1.Enabled = true;
                            button1.BackColor = Color.DarkGreen;
                        }
                        button3.Enabled = true;
                        button2.Enabled = true;
                        button3.BackColor = Color.Green;
                        button2.BackColor = Color.Green;
                        i = 0;
                        timer3.Stop();
                        // MessageBox.Show(String.Format("x={0}  y={1}  x1={2} y1={3}", igrach1.pozicija.X, igrach1.pozicija.Y,igrach2.pozicija.X,igrach2.pozicija.Y));
                        kocka1.Clear(Color.SkyBlue);
                        pole.DrawImage(Properties.Resources.gradPozadina, 280, 100, 680, 500);
                        izcrtaj();
                        timer5.Start();
                    }
                    igrach1.coveche.pozicija = 0;
                    igrach2.coveche.pozicija = 0;
                    g.DrawImage(b, Point.Empty);
                }

            }
            g.DrawImage(b, Point.Empty);
        }
        

        public void random()
        {
            if (igrach2.Nared == false && igrach1.Nared==true)
            {
                timer1.Start();
                muzika = new System.Media.SoundPlayer(Properties.Resources.Dice_roll_sound_effect);
                muzika.Play();
            }
        }
        int k = 0;
        private void timer5_Tick(object sender, EventArgs e)
        {
            if (k == 3)
            {
                k = 0;
                timer5.Stop();
                if (igrach1.Nared)
                {
                   
                    int d = igrach1.brPole + kockaVrednost;
                    d = d % 24;
                    igrach1.brPole = d;
                    Pole pom = tabla[d];
                    if (pom is Grad)
                    {
                        Grad gg1 = (Grad)pom;
                        FormGrad g = new FormGrad((Grad)pom, igrach1);
                        if (gg1.Sopstvenik == null)
                        {
                            if (g.ShowDialog() == DialogResult.OK)
                            {
                                igrach1.money -= (int)gg1.Cena;
                                igrach1.AddZemjushte(gg1);
                                MoneyC1.Text = igrach1.GiveMeMoney();
                                gg1.Sopstvenik = igrach1;
                                pom = gg1;
                                tabla[d] = pom;
                                StringBuilder sb = new StringBuilder();
                                sb.Append(igrach1.ime);
                                sb.Append(" ");
                                sb.Append("го купи земјиштето во ");
                                sb.Append(gg1.Ime);
                                textBox1.Text = sb.ToString();
                            }
                            else
                            {
                                StringBuilder sb = new StringBuilder();
                                sb.Append(igrach1.ime);
                                sb.Append(" ");
                                sb.Append("не го купи земјиштето во ");
                                sb.Append(gg1.Ime);
                                textBox1.Text = sb.ToString();
                            }
                        }
                        else if (gg1.Sopstvenik == igrach2)
                        {
                            if (igrach1.money < (int)gg1.Danok)
                            {

                                FormaRazno go = new FormaRazno(5, null);
                                igrach1.money = 0;
                                StringBuilder sb = new StringBuilder();
                                sb.Append(igrach1.ime);
                                sb.Append(" ");
                                sb.Append("банкнотираше.");
                                textBox1.Text = sb.ToString();
                                igrach1.Nared = false;
                                igrach2.Nared = false;
                                if (go.ShowDialog() == DialogResult.Cancel)
                                    this.Hide();
                            }
                            else
                            {
                                Drzava pomdrz = null;
                                for (int i = 0; i < listaDrzavi.Count; i++)
                                {
                                    if (listaDrzavi[i].Gradovi.Contains(gg1) == true)
                                    {
                                        pomdrz = listaDrzavi[i];
                                    }

                                }
                                int br = 0;
                                if (pomdrz != null)
                                {
                                    for (int i = 0; i < pomdrz.Gradovi.Count; i++)
                                    {
                                        for (int j = 0; j < igrach2.zemjishta.Count; j++)
                                            if (igrach2.zemjishta[j].Equals(pomdrz.Gradovi[i]))
                                                br++;

                                    }
                                }
                                if (br == pomdrz.Gradovi.Count)
                                {
                                    if (igrach1.money > gg1.Danok * 2)
                                    {
                                        igrach1.money -= (int)gg1.Danok * 2;
                                        igrach2.money += (int)gg1.Danok * 2;
                                        StringBuilder sb = new StringBuilder();
                                        sb.Append(igrach1.ime);
                                        sb.Append(" ");
                                        sb.Append("плати двојно повеќе данок за земјиштето ");
                                        sb.Append(gg1.Ime);
                                        textBox1.Text = sb.ToString();
                                    }
                                    else
                                    {
                                        FormaRazno go = new FormaRazno(5, null);
                                        igrach1.money = 0;
                                        StringBuilder sb = new StringBuilder();
                                        sb.Append(igrach1.ime);
                                        sb.Append(" ");
                                        sb.Append("банкнотираше.");
                                        textBox1.Text = sb.ToString();
                                        igrach1.Nared = false;
                                        igrach2.Nared = false;
                                        if (go.ShowDialog() == DialogResult.Cancel)
                                            this.Hide();
                                    }
                                }
                                else
                                {
                                    igrach1.money -= (int)gg1.Danok;
                                    igrach2.money += (int)gg1.Danok;
                                    StringBuilder sb = new StringBuilder();
                                    sb.Append(igrach1.ime);
                                    sb.Append(" ");
                                    sb.Append("плати данок за земјиштето ");
                                    sb.Append(gg1.Ime);
                                    textBox1.Text = sb.ToString();
                                }

                            }
                        }
                        MoneyC2.Text = igrach2.GiveMeMoney();
                        MoneyC1.Text = igrach1.GiveMeMoney();

                    }
                    else if (pom is Karticka)
                    {
                        Karticka temp = null;
                        if (d == 5 || d == 21) //shansa
                        {
                            StringBuilder sb = new StringBuilder();
                            r = new Random();
                            int broj = r.Next(0, 10);
                            temp = karticki[broj];

                            if (broj == 7)
                            {
                                Point p = new Point(958, 0);
                                igrach1.pozicija = p;
                                igrach1.brPole = 7;
                                if (igrach1.money > 7000)
                                {
                                    igrach1.money -= 7000;
                                }
                                else
                                {
                                    FormaRazno go = new FormaRazno(5, null);
                                    igrach1.money = 0;
                                    sb.Append(igrach1.ime);
                                    sb.Append(" ");
                                    sb.Append("банкнотираше.");
                                    textBox1.Text = sb.ToString();
                                    igrach1.Nared = false;
                                    igrach2.Nared = false;
                                    if (go.ShowDialog() == DialogResult.Cancel)
                                        this.Hide();

                                }
                                MoneyC1.Text = igrach1.GiveMeMoney();
                            }
                            if (broj == 8)
                            {
                                Point p = new Point(750, 520);
                                igrach1.pozicija = p;
                                igrach1.brPole = 14;
                                Grad dgrad = (Grad)tabla[14];
                                if (igrach2.zemjishta.Contains((Grad)tabla[14]))
                                {
                                    if (igrach1.money > dgrad.Danok)
                                    {
                                        igrach1.money -= (int)dgrad.Danok;
                                        igrach2.money += (int)dgrad.Danok;
                                    }
                                    else
                                    {
                                        FormaRazno go = new FormaRazno(5, null);
                                        igrach1.money = 0;
                                        sb.Append(igrach1.ime);
                                        sb.Append(" ");
                                        sb.Append("банкнотираше.");
                                        textBox1.Text = sb.ToString();
                                        igrach1.Nared = false;
                                        igrach2.Nared = false;
                                        if (go.ShowDialog() == DialogResult.Cancel)
                                            this.Hide();
                                    }

                                }
                                MoneyC2.Text = igrach2.GiveMeMoney();
                                MoneyC1.Text = igrach1.GiveMeMoney();
                            }

                            if (broj == 6)
                            {
                                Point p = new Point(230, 0);
                                igrach1.pozicija = p;
                                igrach1.brPole = 0;
                            }
                            igrach1.money += (int)(temp.ZaPlakanje);
                            MoneyC1.Text = igrach1.GiveMeMoney();
                            FormaRazno fr = new FormaRazno(6, karticki[broj]);
                            //StringBuilder sb = new StringBuilder();
                            sb.Append(igrach1.ime);
                            sb.Append(" доби шанса : ''");
                            sb.Append(temp.Opis);
                            sb.Append("''");
                            textBox1.Text = sb.ToString();
                            fr.ShowDialog();
                            if (igrach1.money <= 0)
                            {
                                fr.Close();
                                igrach1.money = 0;
                                MoneyC1.Text = igrach1.GiveMeMoney();
                                FormaRazno go = new FormaRazno(5, null);
                                //StringBuilder sb = new StringBuilder();
                                sb.Append(igrach1.ime);
                                sb.Append(" ");
                                sb.Append("банкнотираше.");
                                textBox1.Text = sb.ToString();
                                MoneyC1.Text = igrach1.GiveMeMoney();
                                igrach1.Nared = false;
                                igrach2.Nared = false;
                                if (go.ShowDialog() == DialogResult.Cancel)
                                    this.Hide();
                            }
                        }
                        else if (d == 9 || d == 15) // iznenaduvanje
                        {
                            r = new Random();
                            int broj = r.Next(0, 10);
                            StringBuilder sb = new StringBuilder();
                            temp = karticki[broj];

                            if (broj == 7)
                            {
                                Point p = new Point(958, 0);
                                igrach1.pozicija = p;
                                igrach1.brPole = 7;
                                if (igrach1.money > 7000)
                                {
                                    igrach1.money -= 7000;
                                }
                                else
                                {
                                    FormaRazno go = new FormaRazno(5, null);
                                    igrach1.money = 0;
                                    sb.Append(igrach1.ime);
                                    sb.Append(" ");
                                    sb.Append("банкнотираше.");
                                    textBox1.Text = sb.ToString();
                                    igrach1.Nared = false;
                                    igrach2.Nared = false;
                                    if (go.ShowDialog() == DialogResult.Cancel)
                                        this.Hide();

                                }
                                MoneyC1.Text = igrach1.GiveMeMoney();
                            }
                            if (broj == 6)
                            {
                                Point p = new Point(230, 0);
                                igrach1.pozicija = p;
                                igrach1.brPole = 0;
                            }
                            if (broj == 8)
                            {
                                Point p = new Point(750, 520);
                                igrach1.pozicija = p;
                                igrach1.brPole = 14;
                                Grad dgrad = (Grad)tabla[14];
                                if (igrach2.zemjishta.Contains((Grad)tabla[14]))
                                {
                                    if (igrach1.money > dgrad.Danok)
                                    {
                                        igrach1.money -= (int)dgrad.Danok;
                                        igrach2.money += (int)dgrad.Danok;
                                    }
                                    else
                                    {
                                        FormaRazno go = new FormaRazno(5, null);
                                        igrach1.money = 0;
                                        sb.Append(igrach1.ime);
                                        sb.Append(" ");
                                        sb.Append("банкнотираше.");
                                        textBox1.Text = sb.ToString();
                                        igrach1.Nared = false;
                                        igrach2.Nared = false;
                                        if (go.ShowDialog() == DialogResult.Cancel)
                                            this.Hide();

                                    }

                                }
                                MoneyC2.Text = igrach2.GiveMeMoney();
                                MoneyC1.Text = igrach1.GiveMeMoney();
                            }
                            FormaRazno fr = new FormaRazno(7, karticki[broj]);
                            igrach1.money += (int)(temp.ZaPlakanje);
                            MoneyC1.Text = igrach1.GiveMeMoney();
                            //StringBuilder sb = new StringBuilder();
                            sb.Append(igrach1.ime);
                            sb.Append(" доби изненадување : ''");
                            sb.Append(temp.Opis);
                            sb.Append("''");
                            textBox1.Text = sb.ToString();
                            fr.ShowDialog();
                            if (igrach1.money <= 0)
                            {
                                fr.Close();
                                igrach1.money = 0;
                                MoneyC1.Text = igrach1.GiveMeMoney();
                                FormaRazno go = new FormaRazno(5, null);
                                //StringBuilder sb = new StringBuilder();
                                sb.Append(igrach1.ime);
                                sb.Append(" ");
                                sb.Append("банкнотираше.");
                                textBox1.Text = sb.ToString();
                                MoneyC1.Text = igrach1.GiveMeMoney();
                                igrach1.Nared = false;
                                igrach2.Nared = false;
                                if (go.ShowDialog() == DialogResult.Cancel)
                                    this.Hide();
                            }
                        }
                        else if (d == 10) //bingo
                        {
                            igrach1.money += 10000;
                            MoneyC1.Text = igrach1.GiveMeMoney();
                            StringBuilder sb = new StringBuilder();
                            sb.Append(igrach1.ime);
                            sb.Append(" доби 10 000 на БИНГО!");
                            textBox1.Text = sb.ToString();
                            FormaRazno fr = new FormaRazno(1, null);
                            fr.ShowDialog();
                        }
                        else if (d == 7) // jail
                        {
                            if (igrach1.money > 7000)
                            {
                                igrach1.money -= 7000;
                                MoneyC1.Text = igrach1.GiveMeMoney();
                                StringBuilder sb = new StringBuilder();
                                sb.Append(igrach1.ime);
                                sb.Append(" плати 7 000, за да излезе од затвор!");
                                textBox1.Text = sb.ToString();
                                FormaRazno fr = new FormaRazno(2, null);
                                fr.ShowDialog();

                            }
                            else
                            {
                                //gameOVER;
                                FormaRazno go = new FormaRazno(5, null);
                                igrach1.money = 0;
                                StringBuilder sb = new StringBuilder();
                                sb.Append(igrach1.ime);
                                sb.Append(" ");
                                sb.Append("банкнотираше.");
                                textBox1.Text = sb.ToString();
                                MoneyC1.Text = igrach1.GiveMeMoney();
                                igrach1.Nared = false;
                                igrach2.Nared = false;
                                if (go.ShowDialog() == DialogResult.Cancel)
                                    this.Hide();
                            }
                        }
                        else if (d == 12) // parking
                        {
                            igrach1.money += 7000;
                            MoneyC1.Text = igrach1.GiveMeMoney();
                            StringBuilder sb = new StringBuilder();
                            sb.Append(igrach1.ime);
                            sb.Append(" подигна 7 000 од паркингот!");
                            textBox1.Text = sb.ToString();
                            FormaRazno fr = new FormaRazno(4, null);
                            fr.ShowDialog();
                        }
                        else if (d == 19) // gotoJail
                        {
                            Point p = new Point(958, 0);
                            igrach1.pozicija = p;
                            igrach1.brPole = 7;
                            StringBuilder sb = new StringBuilder();
                            sb.Append(igrach1.ime);
                            sb.Append(" директно отиде во затвор!");
                            textBox1.Text = sb.ToString();
                            FormaRazno fr = new FormaRazno(2, null);
                            fr.ShowDialog();
                            if (igrach1.money > 7000)
                            {
                                igrach1.money -= 7000;
                                MoneyC1.Text = igrach1.GiveMeMoney();

                            }
                            else
                            {
                                fr.Close();
                                //gameOVER;
                                FormaRazno go = new FormaRazno(5, null);
                                igrach1.money = 0;
                                //StringBuilder sb = new StringBuilder();
                                sb.Append(igrach1.ime);
                                sb.Append(" ");
                                sb.Append("банкнотираше.");
                                MoneyC1.Text = igrach1.GiveMeMoney();
                                textBox1.Text = sb.ToString();
                                igrach1.Nared = false;
                                igrach2.Nared = false;
                                if (go.ShowDialog() == DialogResult.Cancel)
                                    this.Hide();
                            }

                        }
                        else if (d == 22) // danok
                        {
                            FormaRazno fr = new FormaRazno(3, null);
                            fr.ShowDialog();
                            if (igrach1.money > 7000)
                            {
                                igrach1.money -= 7000;
                                MoneyC1.Text = igrach1.GiveMeMoney();
                                StringBuilder sb = new StringBuilder();
                                sb.Append(igrach1.ime);
                                sb.Append(" плати 7 000 за данок!");
                                textBox1.Text = sb.ToString();

                            }
                            else
                            {
                                FormaRazno go = new FormaRazno(5, null);
                                igrach1.money = 0;
                                StringBuilder sb = new StringBuilder();
                                sb.Append(igrach1.ime);
                                sb.Append(" ");
                                sb.Append("банкнотираше.");
                                textBox1.Text = sb.ToString();
                                MoneyC1.Text = igrach1.GiveMeMoney();
                                igrach1.Nared = false;
                                igrach2.Nared = false;
                                if (go.ShowDialog() == DialogResult.Cancel)
                                    this.Hide();
                            }
                        }
                    }
                }
            
                if (igrach2.Nared)
                {
                     
                    int d = igrach2.brPole + kockaVrednost;
                    d = d % 24;
                    igrach2.brPole = d;
                    Pole pom = tabla[d];
                    if (pom is Grad)
                    {
                        Grad gg1 = (Grad)pom;
                        if (gg1.Sopstvenik == null)
                        {
                            if (igrach2.money > gg1.Cena)
                            {
                                igrach2.money -= (int)gg1.Cena;
                                igrach2.AddZemjushte(gg1);
                                MoneyC2.Text = igrach2.GiveMeMoney();
                                gg1.Sopstvenik = igrach2;
                                pom = gg1;
                                tabla[d] = pom;
                                StringBuilder sb = new StringBuilder();
                                sb.Append(igrach2.ime);
                                sb.Append(" ");
                                sb.Append("го купи земјиштето во ");
                                sb.Append(gg1.Ime);
                                textBox1.Text = sb.ToString();
                            }
                            else
                            {
                                StringBuilder sb = new StringBuilder();
                                sb.Append(igrach2.ime);
                                sb.Append(" ");
                                sb.Append("не го купи земјиштето во ");
                                sb.Append(gg1.Ime);
                                textBox1.Text = sb.ToString();
                            }
                        }
                        else if (gg1.Sopstvenik == igrach1)
                        {
                            if (igrach2.money < (int)gg1.Danok)
                            {

                                FormaRazno go = new FormaRazno(8, null);
                                igrach2.money = 0;
                                StringBuilder sb = new StringBuilder();
                                sb.Append(igrach2.ime);
                                sb.Append(" ");
                                sb.Append("банкнотираше.");
                                textBox1.Text = sb.ToString();
                                igrach1.Nared = false;
                                igrach2.Nared = false;
                                if (go.ShowDialog() == DialogResult.Cancel)
                                    this.Hide();
                            }
                            else
                            {
                                Drzava pomdrz = null;
                                for (int i = 0; i < listaDrzavi.Count; i++)
                                {
                                    if (listaDrzavi[i].Gradovi.Contains(gg1) == true)
                                    {
                                        pomdrz = listaDrzavi[i];
                                    }

                                }
                                int br = 0;
                                if (pomdrz != null)
                                {
                                    for (int i = 0; i < pomdrz.Gradovi.Count; i++)
                                    {
                                        for (int j = 0; j < igrach1.zemjishta.Count; j++)
                                            if (igrach1.zemjishta[j].Equals(pomdrz.Gradovi[i]))
                                                br++;

                                    }
                                }
                                if (br == pomdrz.Gradovi.Count)
                                {
                                    if (igrach2.money > gg1.Danok * 2)
                                    {
                                        igrach2.money -= (int)gg1.Danok * 2;
                                        igrach1.money += (int)gg1.Danok * 2;
                                        StringBuilder sb = new StringBuilder();
                                        sb.Append(igrach2.ime);
                                        sb.Append(" ");
                                        sb.Append("плати двојно повеќе данок за земјиштето ");
                                        sb.Append(gg1.Ime);
                                        textBox1.Text = sb.ToString();
                                    }
                                    else
                                    {
                                        FormaRazno go = new FormaRazno(8, null);
                                        igrach2.money = 0;
                                        StringBuilder sb = new StringBuilder();
                                        sb.Append(igrach2.ime);
                                        sb.Append(" ");
                                        sb.Append("банкнотираше.");
                                        textBox1.Text = sb.ToString();
                                        igrach1.Nared = false;
                                        igrach2.Nared = false;
                                        if(go.ShowDialog()==DialogResult.Cancel)
                                        this.Hide();
                                    }
                                }
                                else
                                {
                                    igrach2.money -= (int)gg1.Danok;
                                    igrach1.money += (int)gg1.Danok;
                                    StringBuilder sb = new StringBuilder();
                                    sb.Append(igrach2.ime);
                                    sb.Append(" ");
                                    sb.Append("плати данок за земјиштето ");
                                    sb.Append(gg1.Ime);
                                    textBox1.Text = sb.ToString();
                                }
                            }
                            MoneyC2.Text = igrach2.GiveMeMoney();
                            MoneyC1.Text = igrach1.GiveMeMoney();

                        }
                    }

                    else if (pom is Karticka)
                    {
                        StringBuilder sb = new StringBuilder();
                        Karticka temp = null;
                        if (d == 5 || d == 21) //shansa
                        {
                            r = new Random();
                            int broj = r.Next(0, 10);
                            temp = karticki[broj];
                            if (broj == 7)
                            {
                                Point p = new Point(968, 0);
                                igrach2.pozicija = p;
                                igrach2.brPole = 7;
                                if (igrach2.money > 7000)
                                {
                                    igrach2.money -= 7000;
                                }
                                else
                                {
                                    FormaRazno go = new FormaRazno(8, null);
                                    igrach2.money = 0;
                                    sb.Append(igrach2.ime);
                                    sb.Append(" ");
                                    sb.Append("банкнотираше.");
                                    textBox1.Text = sb.ToString();
                                    igrach1.Nared = false;
                                    igrach2.Nared = false;
                                    if (go.ShowDialog() == DialogResult.Cancel)
                                        this.Hide();

                                }
                                MoneyC2.Text = igrach2.GiveMeMoney();
                            }
                            if (broj == 6)
                            {
                                Point p = new Point(240, 0);
                                igrach2.pozicija = p;
                                igrach2.brPole = 0;
                            }
                            if (broj == 8)
                            {
                                Point p = new Point(760, 520);
                                igrach2.pozicija = p;
                                igrach2.brPole = 14;

                                Grad dgrad = (Grad)tabla[14];
                                if (igrach1.zemjishta.Contains((Grad)tabla[14]))
                                {
                                    if (igrach2.money > dgrad.Danok)
                                    {
                                        igrach2.money -= (int)dgrad.Danok;
                                        igrach1.money += (int)dgrad.Danok;
                                    }
                                    else
                                    {
                                        FormaRazno go = new FormaRazno(8, null);
                                        igrach2.money = 0;
                                        sb.Append(igrach2.ime);
                                        sb.Append(" ");
                                        sb.Append("банкнотираше.");
                                        textBox1.Text = sb.ToString();
                                        igrach1.Nared = false;
                                        igrach2.Nared = false;
                                        if (go.ShowDialog() == DialogResult.Cancel)
                                            this.Hide();

                                    }

                                }
                                MoneyC2.Text = igrach2.GiveMeMoney();
                                MoneyC1.Text = igrach1.GiveMeMoney();
                            }

                            igrach2.money += (int)(temp.ZaPlakanje);
                            MoneyC2.Text = igrach2.GiveMeMoney();
                            //StringBuilder sb = new StringBuilder();
                            sb.Append(igrach2.ime);
                            sb.Append(" ");
                            sb.Append("доби шанса : ''");
                            sb.Append(temp.Opis);
                            sb.Append("''");
                            textBox1.Text = sb.ToString();
                            if (igrach2.money <= 0)
                            {
                                FormaRazno go = new FormaRazno(8, null);
                                igrach2.money = 0;
                                MoneyC2.Text = igrach2.GiveMeMoney();
                                //StringBuilder sb = new StringBuilder();
                                sb.Append(igrach2.ime);
                                sb.Append(" ");
                                sb.Append("банкнотираше.");
                                textBox1.Text = sb.ToString();
                                MoneyC2.Text = igrach2.GiveMeMoney();
                                igrach1.Nared = false;
                                igrach2.Nared = false;
                                if (go.ShowDialog() == DialogResult.Cancel)
                                    this.Hide();
                            }

                        }
                        else if (d == 9 || d == 15) // iznenaduvanje
                        {
                            r = new Random();
                            int broj = r.Next(0, 10);
                            temp = karticki[broj];
                            if (broj == 7)
                            {
                                Point p = new Point(968, 0);
                                igrach2.pozicija = p;
                                igrach2.brPole = 7;
                                if (igrach2.money > 7000)
                                {
                                    igrach2.money -= 7000;
                                }
                                else
                                {
                                    FormaRazno go = new FormaRazno(8, null);
                                    igrach2.money = 0;
                                    sb.Append(igrach2.ime);
                                    sb.Append(" ");
                                    sb.Append("банкнотираше.");
                                    textBox1.Text = sb.ToString();
                                    igrach1.Nared = false;
                                    igrach2.Nared = false;
                                    if (go.ShowDialog() == DialogResult.Cancel)
                                        this.Hide();
                                }
                                MoneyC2.Text = igrach2.GiveMeMoney();
                            }
                            if (broj == 6)
                            {
                                Point p = new Point(240, 0);
                                igrach2.pozicija = p;
                                igrach2.brPole = 0;
                            }
                            if (broj == 8)
                            {
                                Point p = new Point(760, 520);
                                igrach2.pozicija = p;
                                igrach2.brPole = 14;
                                Grad dgrad = (Grad)tabla[14];
                                if (igrach1.zemjishta.Contains((Grad)tabla[14]))
                                {
                                    if (igrach2.money > dgrad.Danok)
                                    {
                                        igrach2.money -= (int)dgrad.Danok;
                                        igrach1.money += (int)dgrad.Danok;
                                    }
                                    else
                                    {
                                        FormaRazno go = new FormaRazno(8, null);
                                        igrach2.money = 0;
                                        sb.Append(igrach2.ime);
                                        sb.Append(" ");
                                        sb.Append("банкнотираше.");
                                        textBox1.Text = sb.ToString();
                                        igrach1.Nared = false;
                                        igrach2.Nared = false;
                                        if (go.ShowDialog() == DialogResult.Cancel)
                                            this.Hide();   
                                    }

                                }
                                MoneyC2.Text = igrach2.GiveMeMoney();
                                MoneyC1.Text = igrach1.GiveMeMoney();
                            }
                            igrach2.money += (int)(temp.ZaPlakanje);
                            MoneyC2.Text = igrach2.GiveMeMoney();
                            //StringBuilder sb = new StringBuilder();
                            sb.Append(igrach2.ime);
                            sb.Append(" ");
                            sb.Append("доби изненадување : ''");
                            sb.Append(temp.Opis);
                            sb.Append("''");
                            textBox1.Text = sb.ToString();
                            if (igrach2.money <= 0)
                            {
                                FormaRazno go = new FormaRazno(8, null);
                                igrach2.money = 0;
                                MoneyC2.Text = igrach2.GiveMeMoney();
                                //StringBuilder sb = new StringBuilder();
                                sb.Append(igrach2.ime);
                                sb.Append(" ");
                                sb.Append("банкнотираше.");
                                textBox1.Text = sb.ToString();
                                MoneyC2.Text = igrach2.GiveMeMoney();
                                igrach1.Nared = false;
                                igrach2.Nared = false;
                                if (go.ShowDialog() == DialogResult.Cancel)
                                    this.Hide();
                            }
                        }
                        else if (d == 10) //bingo
                        {
                            igrach2.money += 10000;
                            MoneyC2.Text = igrach2.GiveMeMoney();
                            //StringBuilder sb = new StringBuilder();
                            sb.Append(igrach2.ime);
                            sb.Append(" доби 10 000 на БИНГО!");
                            textBox1.Text = sb.ToString();
                        }
                        else if (d == 7) // jail
                        {
                            if (igrach2.money > 7000)
                            {
                                igrach2.money -= 7000;
                                MoneyC2.Text = igrach2.GiveMeMoney();
                                //StringBuilder sb = new StringBuilder();
                                sb.Append(igrach2.ime);
                                sb.Append(" плати 7 000, за да излезе од затвор!");
                                textBox1.Text = sb.ToString();
                            }
                            else
                            {
                                //gameOVER;
                                igrach2.money = 0;
                                MoneyC2.Text = igrach2.GiveMeMoney();
                                //StringBuilder sb = new StringBuilder();
                                sb.Append(igrach2.ime);
                                sb.Append(" нема пари да плати за да излезе од затвор!");
                                textBox1.Text = sb.ToString();
                                FormaRazno go = new FormaRazno(8, null);
                                sb.Append(igrach2.ime);
                                sb.Append(" ");
                                sb.Append("банкнотираше.");
                                textBox1.Text = sb.ToString();
                                MoneyC2.Text = igrach2.GiveMeMoney();
                                igrach1.Nared = false;
                                igrach2.Nared = false;
                                if (go.ShowDialog() == DialogResult.Cancel)
                                    this.Hide();
                            }

                        }
                        else if (d == 12) // parking
                        {
                            igrach2.money += 7000;
                            MoneyC2.Text = igrach2.GiveMeMoney();
                            //StringBuilder sb = new StringBuilder();
                            sb.Append(igrach2.ime);
                            sb.Append(" подигна 7 000 од паркингот!");
                            textBox1.Text = sb.ToString();
                        }
                        else if (d == 19) // gotoJail
                        {
                            if (igrach2.money > 7000)
                            {
                                Point p = new Point(968, 0);
                                igrach2.pozicija = p;
                                igrach2.brPole = 7;
                                igrach2.money -= 7000;
                                //StringBuilder sb = new StringBuilder();
                                sb.Append(igrach2.ime);
                                sb.Append(" директно отиде во затвор!");
                                textBox1.Text = sb.ToString();
                                MoneyC2.Text = igrach2.GiveMeMoney();
                            }
                            else
                            {
                                FormaRazno go = new FormaRazno(8, null);
                                igrach2.money = 0;
                                //StringBuilder sb = new StringBuilder();
                                sb.Append(igrach2.ime);
                                sb.Append(" ");
                                sb.Append("банкнотираше.");
                                textBox1.Text = sb.ToString();
                                MoneyC2.Text = igrach2.GiveMeMoney();
                                igrach1.Nared = false;
                                igrach2.Nared = false;
                                if (go.ShowDialog() == DialogResult.Cancel)
                                    this.Hide();
                            }
                        }
                        else if (d == 22) // danok
                        {
                            if (igrach2.money > 7000)
                            {
                                igrach2.money -= 7000;
                                MoneyC2.Text = igrach2.GiveMeMoney();
                                //StringBuilder sb = new StringBuilder();
                                sb.Append(igrach2.ime);
                                sb.Append(" плати 7 000 за данок!");
                                textBox1.Text = sb.ToString();
                            }
                            else
                            {
                                FormaRazno go = new FormaRazno(8, null);
                                igrach2.money = 0;
                                //StringBuilder sb = new StringBuilder();
                                sb.Append(igrach2.ime);
                                sb.Append(" ");
                                sb.Append("банкнотираше.");
                                textBox1.Text = sb.ToString();
                                MoneyC2.Text = igrach2.GiveMeMoney();
                                igrach1.Nared = false;
                                igrach2.Nared = false;
                                if (go.ShowDialog() == DialogResult.Cancel)
                                    this.Hide();
                            }
                        }
                    }

                
            }
                random();
            }
            k++;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MoneyC2_TextChanged(object sender, EventArgs e)
        {
            if (igrach2.brPole != 10)
            {
                System.Media.SoundPlayer pesna = new System.Media.SoundPlayer(Properties.Resources.Coins_Free_Sound_Effects);
                pesna.Play();
            }
        }

        private void MoneyC1_TextChanged(object sender, EventArgs e)
        {
            if (igrach1.brPole != 10)
            {
                System.Media.SoundPlayer pesna = new System.Media.SoundPlayer(Properties.Resources.Coins_Free_Sound_Effects);
                pesna.Play();
            }
        }

        private void зачувајToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void отвориToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stream str = File.Create("igra.bin");
            BinaryFormatter bf = new BinaryFormatter();
            bf.Context = new
            StreamingContext(StreamingContextStates.CrossAppDomain);
            bf.Serialize(str, lista);
            str.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stream str = File.OpenRead("igra.bin");
            BinaryFormatter bf = new BinaryFormatter();
            lista = (ListaIgraci)bf.Deserialize(str);
            igrach1 = lista.lista[0];
            igrach2 = lista.lista[1];
            izcrtaj();
            str.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            igrach1.Nared = false;
            igrach2.Nared = false;
           
             this.Hide();
                Pochetna p = new Pochetna(2);
                p.Show();
        }


    }

}
