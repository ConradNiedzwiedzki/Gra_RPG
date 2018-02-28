using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilnikGry
{
    public class Przedmiot
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public string NazwaMnoga { get; set; }

        public Przedmiot(int id, string nazwa, string nazwaMnoga)
        {
            ID = id;
            Nazwa = nazwa;
            NazwaMnoga = nazwaMnoga;
        }
    }
}
