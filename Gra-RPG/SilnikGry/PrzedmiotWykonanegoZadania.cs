using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilnikGry
{
    public class PrzedmiotWykonanegoZadania
    {
        public Przedmiot Szczegoly { get; set; }
        public int Ilosc { get; set; }

        public PrzedmiotWykonanegoZadania(Przedmiot szczegoly, int ilosc)
        {
            Szczegoly = szczegoly;
            Ilosc = ilosc;
        }
    }
}
