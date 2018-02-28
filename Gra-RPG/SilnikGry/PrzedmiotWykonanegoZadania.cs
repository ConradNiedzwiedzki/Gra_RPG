using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilnikGry
{
    public class PrzedmiotDoWykonaniaZadania
    {
        public Przedmiot Szczegoly { get; set; }
        public int Ilosc { get; set; }

        public PrzedmiotDoWykonaniaZadania(Przedmiot szczegoly, int ilosc)
        {
            Szczegoly = szczegoly;
            Ilosc = ilosc;
        }
    }
}
