using System.Collections.Generic;
using System.Linq;
using System.Xml;

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

        public string KonwertujDoStringaXML()
        {
            XmlDocument daneGracza = new XmlDocument();

            XmlNode gracz = daneGracza.CreateElement("Gracz");
            daneGracza.AppendChild(gracz);

            XmlNode statystyki = daneGracza.CreateElement("Statystyki");
            gracz.AppendChild(statystyki);

            XmlNode biezacePunktyZdrowia = daneGracza.CreateElement("BiezacePunktyZdrowia");
            biezacePunktyZdrowia.AppendChild(daneGracza.CreateTextNode(this.BiezacePunktyZdrowia.ToString()));
            statystyki.AppendChild(biezacePunktyZdrowia);

            XmlNode maksymalnePunktyZdrowia = daneGracza.CreateElement("MaksymalnePunktyZdrowia");
            maksymalnePunktyZdrowia.AppendChild(daneGracza.CreateTextNode(this.MaksymalnePunktyZdrowia.ToString()));
            statystyki.AppendChild(maksymalnePunktyZdrowia);

            XmlNode zloto = daneGracza.CreateElement("Zloto");
            zloto.AppendChild(daneGracza.CreateTextNode(this.Zloto.ToString()));
            statystyki.AppendChild(zloto);

            XmlNode punktyDoswiadczenia = daneGracza.CreateElement("PunktyDoswiadczenia");
            punktyDoswiadczenia.AppendChild(daneGracza.CreateTextNode(this.PunktyDoswiadczenia.ToString()));
            statystyki.AppendChild(punktyDoswiadczenia);

            XmlNode biezacaLokalizacja = daneGracza.CreateElement("BiezacaLokalizacja");
            biezacaLokalizacja.AppendChild(daneGracza.CreateTextNode(this.BiezacaLokalizacja.ToString()));
            statystyki.AppendChild(biezacaLokalizacja);

            XmlNode przedmiotyInwentarza = daneGracza.CreateElement("PrzedmiotyInwentarza");
            gracz.AppendChild(przedmiotyInwentarza);

            foreach(PrzedmiotInwentarza przedmiot in this.Inwentarz)
            {
                XmlNode przedmiotInwentarza = daneGracza.CreateElement("PrzedmiotInwentarza");

                XmlAttribute atrybutID = daneGracza.CreateAttribute("ID");
                atrybutID.Value = przedmiot.Szczegoly.ID.ToString();
                przedmiotInwentarza.Attributes.Append(atrybutID);

                XmlAttribute atrybutIlosc = daneGracza.CreateAttribute("Ilosc");
                atrybutIlosc.Value = przedmiot.Ilosc.ToString();
                przedmiotInwentarza.Attributes.Append(atrybutIlosc);
            }

            XmlNode zadaniaGracza = daneGracza.CreateElement("ZadaniaGracza");
            gracz.AppendChild(zadaniaGracza);

            foreach(ZadanieGracza zadanie in this.Zadania)
            {
                XmlNode zadanieGracza = daneGracza.CreateElement("ZadanieGracza");

                XmlAttribute atrybutID = daneGracza.CreateAttribute("ID");
                atrybutID.Value = zadanie.Szczegoly.ID.ToString();
                zadanieGracza.Attributes.Append(atrybutID);

                XmlAttribute atrybutJestUkonczone = daneGracza.CreateAttribute("JestUkonczone");
                atrybutJestUkonczone.Value = zadanie.JestUkonczone.ToString();
                zadanieGracza.Attributes.Append(atrybutJestUkonczone);
            }

            return daneGracza.InnerXml;
        }
    }
}
