using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilnikGry
{
    public class MiksturaLeczenia : Przedmiot
    {
        public int LiczbaPunktowLeczenia { get; set; }

        public MiksturaLeczenia(int id, string nazwa, string nazwaMnoga, int liczbaPunktowLeczenia) : base(id, nazwa, nazwaMnoga)
        {
            LiczbaPunktowLeczenia = liczbaPunktowLeczenia;
        }
    }
}
