using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilnikGry
{
    public class Bron : Przedmiot
    {
        public int MinimalneObrazenia { get; set; }
        public int MaksymalneObrazenia { get; set; }

        public Bron(int id, string nazwa, string nazwaMnoga, int minimalneObrazenia, int maksymalneObrazenia) : base(id, nazwa, nazwaMnoga)
        {
            MinimalneObrazenia = minimalneObrazenia;
            MaksymalneObrazenia = maksymalneObrazenia;
        }
    }
}
