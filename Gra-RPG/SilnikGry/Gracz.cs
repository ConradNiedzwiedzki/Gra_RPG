using System;
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
        public int Poziom
        {
            get
            {
                return ((PunktyDoswiadczenia / 100) + 1);
            }
        }
        public List<PrzedmiotInwentarza> Inwentarz { get; set; }
        public List<ZadanieGracza> Zadania { get; set; }
        public Lokalizacja BiezacaLokalizacja { get; set; }

        public Gracz(int biezacePunktyZdrowia, int maksymalnePunktyZdrowia, int zloto, int punktyDoswiadczenia) : base(biezacePunktyZdrowia, maksymalnePunktyZdrowia)
        {
            Zloto = zloto;
            PunktyDoswiadczenia = punktyDoswiadczenia;
            Inwentarz = new List<PrzedmiotInwentarza>();
            Zadania = new List<ZadanieGracza>();
        }

        public bool PosiadaWymaganyPrzedmiotDoWejscia(Lokalizacja lokalizacja)
        {
            if (lokalizacja.PrzedmiotWymaganyDoWejscia == null)
                return true;
            foreach(PrzedmiotInwentarza przedmiotinwentarza in Inwentarz)
            {
                if (przedmiotinwentarza.Szczegoly.ID == lokalizacja.PrzedmiotWymaganyDoWejscia.ID)
                    return true;
            }   
            return Inwentarz.Exists(przedmiotInwentarza => przedmiotInwentarza.Szczegoly.ID == lokalizacja.PrzedmiotWymaganyDoWejscia.ID);
        }

        public bool MaJuzToZadanie(Zadanie zadanie)
        {
            return Zadania.Exists(zadanieGracza => zadanieGracza.Szczegoly.ID == zadanie.ID);
        }

        public bool WykonalJuzToZadanie(Zadanie zadanie)
        {
            foreach(ZadanieGracza zadanieGracza in Zadania)
            {
                if (zadanieGracza.Szczegoly.ID == zadanie.ID)
                    return zadanieGracza.JestUkonczone;
            }
            return false;
        }

        public bool PosiadaWszystkiePrzedmiotyDoWykonaniaZadania(Zadanie zadanie)
        {
            foreach (PrzedmiotDoWykonaniaZadania przedmiotDoWykonaniaZadania in zadanie.PrzedmiotyDoWykonaniaZadania)
            {
                if (!Inwentarz.Exists(przedmiotInwentarza => przedmiotInwentarza.Szczegoly.ID == przedmiotDoWykonaniaZadania.Szczegoly.ID && przedmiotInwentarza.Ilosc >= przedmiotInwentarza.Ilosc))
                {
                    return false;
                }
            }
            return true;
        }

        public void UsunPrzedmiotyWymaganeDoWykonaniaZadania(Zadanie zadanie)
        {
            foreach(PrzedmiotDoWykonaniaZadania przedmiotDoWykonaniaZadania in zadanie.PrzedmiotyDoWykonaniaZadania)
            {
                PrzedmiotInwentarza przedmiot = Inwentarz.SingleOrDefault(przedmiotInwentarza => przedmiotInwentarza.Szczegoly.ID == przedmiotDoWykonaniaZadania.Szczegoly.ID);
                {
                    if(przedmiot != null)
                    {
                        przedmiot.Ilosc -= przedmiotDoWykonaniaZadania.Ilosc;
                    }
                }
            }
        }

        public void DodajPrzedmiotDoInwentarza(Przedmiot przedmiotDoDodania)
        {
            PrzedmiotInwentarza przedmiot = Inwentarz.SingleOrDefault(przedmiotInwentarza => przedmiotInwentarza.Szczegoly.ID == przedmiotDoDodania.ID);

            if(przedmiot == null)
            {
                Inwentarz.Add(new PrzedmiotInwentarza(przedmiotDoDodania, 1));
            }
            else
            {
                przedmiot.Ilosc++;
            }
        }

        public void OznaczZadanieJakoUkonczone(Zadanie zadanie)
        {
            ZadanieGracza zadanieGracza = Zadania.SingleOrDefault(zG => zG.Szczegoly.ID == zadanie.ID);
            
            if (zadanieGracza != null)
            {
                zadanieGracza.JestUkonczone = true;
            }
        }
    }
}
