using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Monopol
{
    [Serializable]
    public class Igrach: ISerializable
    {
        public Animacija coveche { get; set; }
        public string ime { get; set; }
        public bool Nared { get; set; }
        public Point pozicija { get; set; }
        public int brPole { get; set; }
        public List<Grad> zemjishta { get; set; }
        public int money { get; set; }
        public int zatvor { get; set; }
        public Image mala { get; set; }
        public Image golema { get; set; }
        public int parking { get; set; }
        public Igrach()
        { }
        public Igrach(Animacija c, string i, bool n,Point p,Image m,Image g)
        {
            golema = g;
            mala = m;
            coveche = c;
            ime = i;
            Nared = n;
            pozicija = p;
            parking = 0;
            zatvor = 0;
            zemjishta = new List<Grad>();
            money = 100000;
            brPole = 0;
        }
        private Igrach(SerializationInfo info, StreamingContext context)
        {
            golema = (Image)info.GetValue("golema", typeof(Image));
            mala = (Image)info.GetValue("mala", typeof(Image));
            coveche = (Animacija)info.GetValue("coveche", typeof(Animacija));
            ime = info.GetString("ime");
            Nared = info.GetBoolean("Nared");
            pozicija = (Point)info.GetValue("pozicija",typeof(Point));
            parking = info.GetInt32("parking");
            zatvor = info.GetInt32("zatvor");
            zemjishta = (List<Grad>)info.GetValue("zemjishta",typeof(List<Grad>));
            money =info.GetInt32("money");
            brPole = info.GetInt32("brPole");
        }
        public void GetObjectData(SerializationInfo inf, StreamingContext con)
        {
            inf.AddValue("golema", golema);
            inf.AddValue("mala", mala);
            inf.AddValue("coveche", coveche);
            inf.AddValue("ime", ime);
            inf.AddValue("Nared", Nared);
            inf.AddValue("pozicija", pozicija);
            inf.AddValue("parking", parking);
            inf.AddValue("zatvor", zatvor);
            inf.AddValue("zemjishta", zemjishta);
            inf.AddValue("money", money);
            inf.AddValue("brPole", brPole);
 
        }
        public Bitmap MoveOneStep()
        {
            return coveche.dajmiSlika();
        }
        public void AddZemjushte(Grad b)
        {
            zemjishta.Add(b);
        }
        public String GiveMeMoney()
        {
            bool b = false;
            string str = String.Format("{0}", money % 1000);
            string temp = String.Format("{0}", money/1000);
            if (temp.Length == 2)
            {
                b = true;
            }
            if (str.Length == 3)
            {
                if (b)
                {
                    str = String.Format("  {0}.{1}", money / 1000, money % 1000);
                }
                else
                    str = String.Format(" {0}.{1}", money / 1000, money % 1000);
            }
            else if (str.Length == 2)
            {
                if(b)
                str = String.Format("  {0}.0{1}", money / 1000, money % 1000);
                else str = String.Format("{0}.0{1}", money / 1000, money % 1000);
            }
            else if (str.Length == 1)
            {
                if (b)
                    str = String.Format("  {0}.00{1}", money / 1000, money % 1000);
                else
                    str = String.Format("{0}.00{1}", money / 1000, money % 1000);
            }
            return str;
        }

    }
}
