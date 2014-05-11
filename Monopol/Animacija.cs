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
    public class Animacija:ISerializable
    {
        public Bitmap[] niza { get; set; }
        public int pozicija = 0;
        public Bitmap dajmiSlika()
        {
            Bitmap b = null;
            if (pozicija < niza.Length)
            {
                b = niza[pozicija++];
            }
            else
            {
                pozicija = 0;
                b = niza[pozicija++];
            }
            return b;
        }
        public Animacija(Bitmap[] n)
        {
            niza = n;
        }
        private Animacija(SerializationInfo inf, StreamingContext con)
        {
            pozicija = inf.GetInt32("pozicija");
            niza = (Bitmap[])inf.GetValue("niza", typeof(Bitmap[]));
        }
        public void GetObjectData(SerializationInfo inf, StreamingContext con)
        {
            inf.AddValue("niza", niza);
            inf.AddValue("pozicija", pozicija);
            

        }

    }
}
