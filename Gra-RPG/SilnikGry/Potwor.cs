using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilnikGry
{
    public class Potwor : PostacGry
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public int MaksymalneObrazenia { get; set; }
        public int PunktyDoswiadczeniaDoZdobycia { get; set; }
        public int ZlotoDoZdobycia { get; set; }
        public List<PrzedmiotLupu> TabelaLupu { get; set;}

        public Potwor(int id, string nazwa, int maksymalneObrazenia, int punktyDoswiadczeniaDoZdobycia, int zlotoDoZdobycia, int biezacePunktyZdrowia, int maksymalnePunktyZdrowia) : base(biezacePunktyZdrowia, maksymalnePunktyZdrowia)
        {
            ID = id;
            Nazwa = nazwa;
            MaksymalneObrazenia = maksymalneObrazenia;
            PunktyDoswiadczeniaDoZdobycia = punktyDoswiadczeniaDoZdobycia;
            ZlotoDoZdobycia = zlotoDoZdobycia;
            TabelaLupu = new List<PrzedmiotLupu>();
        }
    }
}
