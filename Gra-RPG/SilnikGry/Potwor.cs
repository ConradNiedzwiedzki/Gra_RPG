using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilnikGry
{
    class Potwor : PostacGry
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public int MaksymalneObrazenia { get; set; }
        public int PunktyDoswiadczeniaDoZdobycia { get; set; }
        public int ZlotoDoZdobycia { get; set; }
    }
}
