using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Monopol
{
    [Serializable]
    public class Grad : Pole,ISerializable
    {
        public string Ime { get; set; }
        public float Danok { get; set; }
        public float Cena { get; set; }
        public string Opis { get; set; }
        public bool Status { get; set; }
        public Igrach Sopstvenik { get; set; }
        public Image Slika { get; set; }

        public Grad()
        {
            Sopstvenik = null;
            Status = false;

        }
        private Grad(SerializationInfo inf, StreamingContext con)
        {
            Ime = inf.GetString("Ime");
            Danok = (float)inf.GetValue("Danok", typeof(float));
            Cena = (float)inf.GetValue("Cena", typeof(float));
            Opis = inf.GetString("Opis");
            Status = inf.GetBoolean("Status");
            Sopstvenik = (Igrach)inf.GetValue("Sopstvenik", typeof(Igrach));
            Slika = (Image)inf.GetValue("Slika", typeof(Image));
        }
        public void GetObjectData(SerializationInfo inf, StreamingContext con)
        {
            inf.AddValue("Ime", Ime);
            inf.AddValue("Danok", Danok);
            inf.AddValue("Cena", Cena);
            inf.AddValue("Opis", Opis);
            inf.AddValue("Status", Status);
            inf.AddValue("Sopstvenik", Sopstvenik);
            inf.AddValue("Slika", Slika);
            

        }
        public override string ToString()
        {
            return string.Format("Ime: {0} \n Opis: {1} \n Cena: {2}\n Danok za naplata: {3}\n", Ime, Opis, Cena, Danok);
        }
    }
}
