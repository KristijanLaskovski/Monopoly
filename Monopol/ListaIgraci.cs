using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace Monopol
{
    [Serializable]
    class ListaIgraci:ISerializable
    {
        public List<Igrach> lista;

        public ListaIgraci()
        {
            lista = new List<Igrach>();
        }
        public ListaIgraci(SerializationInfo inf, StreamingContext str)
        {
            lista = (List<Igrach>)inf.GetValue("lista", typeof(List<Igrach>));
        }
        public void GetObjectData(SerializationInfo inf, StreamingContext con)
        {
            inf.AddValue("lista", lista);
    

        }
        public void Add(Igrach i)
        {
            lista.Add(i);
        }
    }
}
