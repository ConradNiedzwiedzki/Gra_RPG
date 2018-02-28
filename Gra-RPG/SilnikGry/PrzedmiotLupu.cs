using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilnikGry
{
    public class PrzedmiotLupu
    {
        public Przedmiot Szczegoly { get; set; }
        public int ProcentowaSzansaZdobyciaPrzedmiotu { get; set; }
        public bool JestPrzedmiotemDomyslnym { get; set; }

        public PrzedmiotLupu(Przedmiot szczegoly, int procentowaSzansaZdobyciaPrzedmiotu, bool jestPrzedmiotemDomyslnym)
        {
            Szczegoly = szczegoly;
            ProcentowaSzansaZdobyciaPrzedmiotu = procentowaSzansaZdobyciaPrzedmiotu;
            JestPrzedmiotemDomyslnym = jestPrzedmiotemDomyslnym;
        }
    }
}
