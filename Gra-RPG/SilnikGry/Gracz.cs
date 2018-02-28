﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilnikGry
{
    public class Gracz : PostacGry
    {
        public int Zloto { get; set; }
        public int PunktyDoswiadczenia { get; set; }
        public int Poziom { get; set; }

        public Gracz(int biezacePunktyZdrowia, int maksymalnePunktyZdrowia, int zloto, int punktyDoswiadczenia, int poziom) : base(biezacePunktyZdrowia, maksymalnePunktyZdrowia)
        {
            Zloto = zloto;
            PunktyDoswiadczenia = punktyDoswiadczenia;
            Poziom = poziom;
        }
    }
}
