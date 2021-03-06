﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilnikGry
{
    public class Zadanie
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public int PunktyDoswiadczeniaDoZdobycia { get; set; }
        public int ZlotoDoZdobycia { get; set; }
        public Przedmiot PrzedmiotNagroda { get; set; }
        public List<PrzedmiotDoWykonaniaZadania> PrzedmiotyDoWykonaniaZadania { get; set; }

        public Zadanie(int id, string nazwa, string opis, int punktyDoswiadczeniaDoZdobycia, int zlotoDoZdobycia)
        {
            ID = id;
            Nazwa = nazwa;
            Opis = opis;
            PunktyDoswiadczeniaDoZdobycia = punktyDoswiadczeniaDoZdobycia;
            ZlotoDoZdobycia = zlotoDoZdobycia;
            PrzedmiotyDoWykonaniaZadania = new List<PrzedmiotDoWykonaniaZadania>();
        }
    }
}
