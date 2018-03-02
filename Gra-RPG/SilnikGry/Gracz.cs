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
        public int Poziom { get; set; }
        public List<PrzedmiotInwentarza> Inwentarz { get; set; }
        public List<ZadanieGracza> Zadania { get; set; }
        public Lokalizacja BiezacaLokalizacja { get; set; }

        public Gracz(int biezacePunktyZdrowia, int maksymalnePunktyZdrowia, int zloto, int punktyDoswiadczenia, int poziom) : base(biezacePunktyZdrowia, maksymalnePunktyZdrowia)
        {
            Zloto = zloto;
            PunktyDoswiadczenia = punktyDoswiadczenia;
            Poziom = poziom;
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
            return false;
        }

        public bool MaJuzToZadanie(Zadanie zadanie)
        {
            foreach(ZadanieGracza zadanieGracza in Zadania)
            {
                if (zadanieGracza.Szczegoly.ID == zadanie.ID)
                    return true;
            }
            return false;
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
                bool znalezionoPrzedmiotWInwentarzuGracza = false;

                foreach (PrzedmiotInwentarza przedmiotInwentarza in Inwentarz)
                {
                    if (przedmiotInwentarza.Szczegoly.ID == przedmiotDoWykonaniaZadania.Szczegoly.ID)
                    {
                        znalezionoPrzedmiotWInwentarzuGracza = true;
                        if (przedmiotInwentarza.Ilosc < przedmiotDoWykonaniaZadania.Ilosc)
                            return false;
                    }
                }

                if (!znalezionoPrzedmiotWInwentarzuGracza)
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
                foreach(PrzedmiotInwentarza przedmiotInwentarza in Inwentarz)
                {
                    if(przedmiotInwentarza.Szczegoly.ID == przedmiotDoWykonaniaZadania.Szczegoly.ID)
                    {
                        przedmiotInwentarza.Ilosc -= przedmiotDoWykonaniaZadania.Ilosc;
                        break;
                    }
                }
            }
        }

        public void DodajPrzedmiotDoInwentarza(Przedmiot przedmiotDoDodania)
        {
            foreach (PrzedmiotInwentarza przedmiotInwentarza in Inwentarz)
            {
                if (przedmiotInwentarza.Szczegoly.ID == przedmiotDoDodania.ID)
                {
                    przedmiotInwentarza.Ilosc++;
                    return;
                }
            }
            Inwentarz.Add(new PrzedmiotInwentarza(przedmiotDoDodania, 1));
        }

        public void OznaczZadanieJakoUkonczone(Zadanie zadanie)
        {
            foreach(ZadanieGracza zadanieGracza in Zadania)
            {
                if (zadanieGracza.Szczegoly.ID == zadanie.ID)
                {
                    zadanieGracza.JestUkonczone = true;
                    return;
                }
            }
        }
    }
}
