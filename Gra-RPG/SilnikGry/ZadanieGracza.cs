using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilnikGry
{
    public class ZadanieGracza
    {
        public Zadanie Szczegoly { get; set; }
        public bool JestUkonczone { get; set; }

        public ZadanieGracza(Zadanie szczegoly)
        {
            Szczegoly = szczegoly;
            JestUkonczone = false;
        }
    }
}
