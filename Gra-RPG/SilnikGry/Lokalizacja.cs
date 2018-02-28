using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilnikGry
{
    public class Lokalizacja
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public Przedmiot PrzedmiotWymaganyDoWejscia { get; set; }
        public Zadanie DostepneZadanieTegoMiejsca { get; set; }
        public Potwor PotworZyjacyWTymMiejscu { get; set; }
        public Lokalizacja LokalizacjaNaPolnoc { get; set; }
        public Lokalizacja LokalizacjaNaWschod { get; set; }
        public Lokalizacja LokalizacjaNaPoludnie { get; set; }
        public Lokalizacja LokalizacjaNaZachod { get; set; }
        
        public Lokalizacja(int id, string nazwa, string opis, Przedmiot przedmiotWymaganyDoWejscia = null, Zadanie dostepneZadanieTegoMiejsca = null, Potwor potworZyjacyWTymMiejscu = null)
        {
            ID = id;
            Nazwa = nazwa;
            Opis = opis;
            PrzedmiotWymaganyDoWejscia = przedmiotWymaganyDoWejscia;
            DostepneZadanieTegoMiejsca = dostepneZadanieTegoMiejsca;
            PotworZyjacyWTymMiejscu = potworZyjacyWTymMiejscu;
        }
    }
}
