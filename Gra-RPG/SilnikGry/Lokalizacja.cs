using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilnikGry
{
    public class Lokalizacja
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }

        public Lokalizacja(int id, string nazwa, string opis)
        {
            ID = id;
            Nazwa = nazwa;
            Opis = opis;
        }
    }
}
