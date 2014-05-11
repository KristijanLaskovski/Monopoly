
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopol
{
    public class Drzava
    {
        public string Ime { get; set; }
        public List<Grad> Gradovi { get; set; }
        public Drzava()
        {
            Gradovi = new List<Grad>();
        }
    }
}
