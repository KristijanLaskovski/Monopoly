using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Monopol
{
    public class Karticka: Pole
    {
        public string Opis { get; set; }
        public float ZaPlakanje { get; set; }
        public int br { get; set; }
        public Karticka(string o, float z, int b)
        {
            Opis = o;
            ZaPlakanje = z;
            br = b;
            
        }
        public override string ToString()
        {
            return String.Format(Opis);
        }
    }
}
