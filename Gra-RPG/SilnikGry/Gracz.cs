﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace SilnikGry
{
    public class Gracz : PostacGry
    {
        public int Zloto { get; set; }
        public int PunktyDoswiadczenia { get; private set; }
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
        public Bron BiezacaBron { get; set; }

        private Gracz(int biezacePunktyZdrowia, int maksymalnePunktyZdrowia, int zloto, int punktyDoswiadczenia) : base(biezacePunktyZdrowia, maksymalnePunktyZdrowia)
        {
            Zloto = zloto;
            PunktyDoswiadczenia = punktyDoswiadczenia;
            Inwentarz = new List<PrzedmiotInwentarza>();
            Zadania = new List<ZadanieGracza>();
        }

        public static Gracz UtworzDomyslnegoGracza()
        {
            Gracz gracz = new Gracz(10, 10, 20, 0);
            gracz.Inwentarz.Add(new PrzedmiotInwentarza(Swiat.PrzedmiotPoID(Swiat.ID_PRZEDMIOTU_ZARDZEWIALY_MIECZ), 1));
            gracz.BiezacaLokalizacja = Swiat.LokalizacjaPoID(Swiat.ID_LOKALIZACJI_DOM);
            return gracz;
        }

        public void DodajPunktyDoswiadczenia(int punktyDoswiadczeniaDoDodania)
        {
            PunktyDoswiadczenia += punktyDoswiadczeniaDoDodania;
            MaksymalnePunktyZdrowia = (Poziom * 10);
        }

        public static Gracz UtworzGraczaZStringuXML(string daneXMLGracza)
        {
            try
            {
                XmlDocument daneGracza = new XmlDocument();

                daneGracza.LoadXml(daneXMLGracza);

                int biezacePunktyZdrowia = Convert.ToInt32(daneGracza.SelectSingleNode("/Gracz/Statystyki/BiezacePunktyZdrowia").InnerText);
                int maksymalnePunktyZdrowia = Convert.ToInt32(daneGracza.SelectSingleNode("/Gracz/Statystyki/MaksymalnePunktyZdrowia").InnerText);
                int zloto = Convert.ToInt32(daneGracza.SelectSingleNode("/Gracz/Statystyki/Zloto").InnerText);
                int punktyDoswiadczenia = Convert.ToInt32(daneGracza.SelectSingleNode("/Gracz/Statystyki/PunktyDoswiadczenia").InnerText);

                Gracz gracz = new Gracz(biezacePunktyZdrowia, maksymalnePunktyZdrowia, zloto, punktyDoswiadczenia);

                int idBiezacejLokalizacji = Convert.ToInt32(daneGracza.SelectSingleNode("/Gracz/Statystyki/BiezacaLokalizacja").InnerText);
                gracz.BiezacaLokalizacja = Swiat.LokalizacjaPoID(idBiezacejLokalizacji);

                if(daneGracza.SelectSingleNode("/Gracz/Statystyki/BiezacaBron") != null)
                {
                    int idBiezacejBroni = Convert.ToInt32(daneGracza.SelectSingleNode("/Gracz/Statystyki/BiezacaBron").InnerText);
                    gracz.BiezacaBron = (Bron)Swiat.PrzedmiotPoID(idBiezacejBroni);
                }

                foreach(XmlNode node in daneGracza.SelectNodes("/Gracz/PrzedmiotyInwentarza/PrzedmiotInwentarza"))
                {
                    int id = Convert.ToInt32(node.Attributes["ID"].Value);
                    int ilosc = Convert.ToInt32(node.Attributes["Ilosc"].Value);

                    for(int i = 0; i < ilosc; i++)
                    {
                        gracz.DodajPrzedmiotDoInwentarza(Swiat.PrzedmiotPoID(id));
                    }
                }

                foreach(XmlNode node in daneGracza.SelectNodes("/Gracz/ZadaniaGracza/ZadanieGracza"))
                {
                    int id = Convert.ToInt32(node.Attributes["ID"].Value);
                    bool jestUkonczone = Convert.ToBoolean(node.Attributes["JestUkonczone"].Value);

                    ZadanieGracza zadanieGracza = new ZadanieGracza(Swiat.ZadaniePoID(id));
                    zadanieGracza.JestUkonczone = jestUkonczone;

                    gracz.Zadania.Add(zadanieGracza);
                }

                return gracz;
            }
            catch
            {
                return Gracz.UtworzDomyslnegoGracza();
            }
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

            if(BiezacaBron != null)
            {
                XmlNode biezacaBron = daneGracza.CreateElement("BiezacaBron");
                biezacaBron.AppendChild(daneGracza.CreateTextNode(this.BiezacaBron.ID.ToString()));
                statystyki.AppendChild(biezacaBron);
            }

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
