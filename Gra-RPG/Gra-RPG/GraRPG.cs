using SilnikGry;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace Gra_RPG
{
    public partial class GraRPG : Form
    {
        private Gracz _gracz;
        private Potwor _biezacyPotwor;
        private const string NAZWA_PLIKU_DANYCH_GRACZA = "DaneGracza.xml";

        public GraRPG()
        {
            InitializeComponent();

            if(File.Exists(NAZWA_PLIKU_DANYCH_GRACZA))
            {
                _gracz = Gracz.UtworzGraczaZStringuXML(File.ReadAllText(NAZWA_PLIKU_DANYCH_GRACZA));
            }
            else
            {
                _gracz = Gracz.UtworzDomyslnegoGracza();
            }
            
            IdzDo(_gracz.BiezacaLokalizacja);
            ZaktualizujStatystykiGracza();
        }

        private void btnPolnoc_Click(object sender, EventArgs e)
        {
            IdzDo(_gracz.BiezacaLokalizacja.LokalizacjaNaPolnoc);
        }

        private void btnZachod_Click(object sender, EventArgs e)
        {
            IdzDo(_gracz.BiezacaLokalizacja.LokalizacjaNaZachod);
        }

        private void btnWschod_Click(object sender, EventArgs e)
        {
            IdzDo(_gracz.BiezacaLokalizacja.LokalizacjaNaWschod);
        }

        private void btnPoludnie_Click(object sender, EventArgs e)
        {
            IdzDo(_gracz.BiezacaLokalizacja.LokalizacjaNaPoludnie);
        }
        
        private void IdzDo(Lokalizacja nowaLokalizacja)
        {
            if(!_gracz.PosiadaWymaganyPrzedmiotDoWejscia(nowaLokalizacja))
            {
                rbtWiadomosci.Text += "Musisz posiadać " + nowaLokalizacja.PrzedmiotWymaganyDoWejscia.Nazwa + ", aby móc przejść do tej lokalizacji." + Environment.NewLine;
                return;
            }

            _gracz.BiezacaLokalizacja = nowaLokalizacja;

            btnPolnoc.Visible = (nowaLokalizacja.LokalizacjaNaPolnoc != null);
            btnWschod.Visible = (nowaLokalizacja.LokalizacjaNaWschod != null);
            btnPoludnie.Visible = (nowaLokalizacja.LokalizacjaNaPoludnie != null);
            btnZachod.Visible = (nowaLokalizacja.LokalizacjaNaZachod != null);

            rbtLokalizacja.Text = nowaLokalizacja.Nazwa + Environment.NewLine;
            rbtLokalizacja.Text += nowaLokalizacja.Opis + Environment.NewLine;

            _gracz.BiezacePunktyZdrowia = _gracz.BiezacePunktyZdrowia;

            lblPunktyZdrowia.Text = _gracz.BiezacePunktyZdrowia.ToString();

            if (nowaLokalizacja.DostepneZadanieTegoMiejsca != null)
            {
                bool graczMaJuzZadanie = _gracz.MaJuzToZadanie(nowaLokalizacja.DostepneZadanieTegoMiejsca);
                bool graczWykonalJuzToZadanie = _gracz.WykonalJuzToZadanie(nowaLokalizacja.DostepneZadanieTegoMiejsca);
                
                if (graczMaJuzZadanie)
                {
                    if (!graczWykonalJuzToZadanie)
                    {
                        bool graczPosiadaWszystkiePrzedmiotyDoWykonaniaZadania = _gracz.PosiadaWszystkiePrzedmiotyDoWykonaniaZadania(nowaLokalizacja.DostepneZadanieTegoMiejsca);

                        if (graczPosiadaWszystkiePrzedmiotyDoWykonaniaZadania)
                        {
                            rbtWiadomosci.Text += Environment.NewLine;
                            rbtWiadomosci.Text += "Gratulacje! Wykonałeś zadanie o nazwie " + nowaLokalizacja.DostepneZadanieTegoMiejsca.Nazwa + "." + Environment.NewLine;

                            _gracz.UsunPrzedmiotyWymaganeDoWykonaniaZadania(nowaLokalizacja.DostepneZadanieTegoMiejsca);

                            rbtWiadomosci.Text += "Otrzymałeś: " + Environment.NewLine;
                            rbtWiadomosci.Text += nowaLokalizacja.DostepneZadanieTegoMiejsca.PunktyDoswiadczeniaDoZdobycia.ToString() + " punktów doświadczenia" + Environment.NewLine;
                            rbtWiadomosci.Text += nowaLokalizacja.DostepneZadanieTegoMiejsca.ZlotoDoZdobycia.ToString() + " złota" + Environment.NewLine;
                            rbtWiadomosci.Text += "1 " + nowaLokalizacja.DostepneZadanieTegoMiejsca.PrzedmiotNagroda.Nazwa + Environment.NewLine + Environment.NewLine;

                            _gracz.PunktyDoswiadczenia += nowaLokalizacja.DostepneZadanieTegoMiejsca.PunktyDoswiadczeniaDoZdobycia;
                            _gracz.Zloto += nowaLokalizacja.DostepneZadanieTegoMiejsca.ZlotoDoZdobycia;
                            _gracz.DodajPrzedmiotDoInwentarza(nowaLokalizacja.DostepneZadanieTegoMiejsca.PrzedmiotNagroda);
                            _gracz.OznaczZadanieJakoUkonczone(nowaLokalizacja.DostepneZadanieTegoMiejsca);
                        }
                    }
                }
                else
                {
                    rbtWiadomosci.Text += "Otrzymałeś zadanie o nazwie:" + Environment.NewLine + nowaLokalizacja.DostepneZadanieTegoMiejsca.Nazwa + "." + Environment.NewLine;
                    rbtWiadomosci.Text += nowaLokalizacja.DostepneZadanieTegoMiejsca.Opis + Environment.NewLine;
                    rbtWiadomosci.Text += "Aby ukończyć to zadanie, powróć tu z:" + Environment.NewLine;
                    foreach (PrzedmiotDoWykonaniaZadania przedmiotDoWykonaniaZadania in nowaLokalizacja.DostepneZadanieTegoMiejsca.PrzedmiotyDoWykonaniaZadania)
                    {
                        if (przedmiotDoWykonaniaZadania.Ilosc == 1)
                        {
                            rbtWiadomosci.Text += " - " + przedmiotDoWykonaniaZadania.Ilosc.ToString() + " " + przedmiotDoWykonaniaZadania.Szczegoly.Nazwa + Environment.NewLine;
                        }
                        else
                        {
                            rbtWiadomosci.Text += " - " + przedmiotDoWykonaniaZadania.Ilosc.ToString() + " " + przedmiotDoWykonaniaZadania.Szczegoly.NazwaMnoga + Environment.NewLine;
                        }
                    }
                    rbtWiadomosci.Text += Environment.NewLine;
                    PrzewinNaDolOkienkaWiadomosci();

                    _gracz.Zadania.Add(new ZadanieGracza(nowaLokalizacja.DostepneZadanieTegoMiejsca));
                }
            }

            if (nowaLokalizacja.PotworZyjacyWTymMiejscu != null)
            {
                rbtWiadomosci.Text += "Widzisz " + nowaLokalizacja.PotworZyjacyWTymMiejscu.Nazwa + "a." + Environment.NewLine;

                Potwor typowyPotwor = Swiat.PotworPoID(nowaLokalizacja.PotworZyjacyWTymMiejscu.ID);
                _biezacyPotwor = new Potwor(typowyPotwor.ID, typowyPotwor.Nazwa, typowyPotwor.MaksymalneObrazenia, typowyPotwor.PunktyDoswiadczeniaDoZdobycia, typowyPotwor.ZlotoDoZdobycia, typowyPotwor.BiezacePunktyZdrowia, typowyPotwor.MaksymalnePunktyZdrowia);

                foreach(PrzedmiotLupu przedmiotLupu in typowyPotwor.TabelaLupu)
                {
                    _biezacyPotwor.TabelaLupu.Add(przedmiotLupu);
                }

                cboBronie.Visible = true;
                cboMikstury.Visible = true;
                btnUzyjBroni.Visible = true;
                btnUzyjMikstury.Visible = true;
            }
            else
            {
                _biezacyPotwor = null;

                cboBronie.Visible = false;
                cboMikstury.Visible = false;
                btnUzyjBroni.Visible = false;
                btnUzyjMikstury.Visible = false;
            }

            ZaktualizujStatystykiGracza();
            ZaktualizujSpisInwentarzaWInterfejsieUzytkownika();
            ZaktualizujSpisZadanWInterfejsieUzytkownika();
            ZaktualizujSpisBroniWInterfejsieUzytkownika();
            ZaktualizujSpisMiskturWInterfejsieUzytkownika();
        }

        private void ZaktualizujSpisInwentarzaWInterfejsieUzytkownika()
        {
            dgvInwentarz.RowHeadersVisible = false;
            dgvInwentarz.ColumnCount = 2;
            dgvInwentarz.Columns[0].Name = "Nazwa przedmiotu:";
            dgvInwentarz.Columns[0].Width = 197;
            dgvInwentarz.Columns[1].Name = "Ilość:";
            dgvInwentarz.Rows.Clear();

            foreach(PrzedmiotInwentarza przedmiotInwentarza in _gracz.Inwentarz)
            {
                if(przedmiotInwentarza.Ilosc > 0)
                {
                    dgvInwentarz.Rows.Add(new[] { przedmiotInwentarza.Szczegoly.Nazwa, przedmiotInwentarza.Ilosc.ToString() });
                }
            }
        }

        private void ZaktualizujSpisZadanWInterfejsieUzytkownika()
        {
            dgvZadania.ColumnCount = 2;
            dgvZadania.Columns[0].Name = "Nazwa zadania:";
            dgvZadania.Columns[0].Width = 197;
            dgvZadania.Columns[1].Name = "Status:";
            dgvZadania.Rows.Clear();

            foreach(ZadanieGracza zadanieGracza in _gracz.Zadania)
            {
                dgvZadania.Rows.Add(new[] { zadanieGracza.Szczegoly.Nazwa, zadanieGracza.JestUkonczonePoPolsku(zadanieGracza.JestUkonczone)});
            }
        }

        private void ZaktualizujSpisBroniWInterfejsieUzytkownika()
        {
            List<Bron> bronie = new List<Bron>();

            foreach(PrzedmiotInwentarza przedmiotInwentarza in _gracz.Inwentarz)
            {
                if(przedmiotInwentarza.Szczegoly is Bron)
                {
                    if(przedmiotInwentarza.Ilosc > 0)
                    {
                        bronie.Add((Bron)przedmiotInwentarza.Szczegoly);
                    }
                }
            }

            if(bronie.Count == 0)
            {
                cboBronie.Visible = false;
                btnUzyjBroni.Visible = false;
            }
            else
            {
                cboBronie.SelectedIndexChanged -= cboBronie_ZmienionoWybranyIndeks;
                cboBronie.DataSource = bronie;
                cboBronie.SelectedIndexChanged += cboBronie_ZmienionoWybranyIndeks;
                cboBronie.DisplayMember = "Nazwa";
                cboBronie.ValueMember = "ID";
                cboBronie.SelectedIndex = 0;

                if(_gracz.BiezacaBron != null)
                {
                    cboBronie.SelectedItem = _gracz.BiezacaBron;
                }
                else
                {
                    cboBronie.SelectedIndex = 0;
                }
            }
        }

        private void ZaktualizujSpisMiskturWInterfejsieUzytkownika()
        {
            List<MiksturaLeczenia> miksturyLeczenia = new List<MiksturaLeczenia>();

            foreach(PrzedmiotInwentarza przedmiotInwentarza in _gracz.Inwentarz)
            {
                if(przedmiotInwentarza.Szczegoly is MiksturaLeczenia)
                {
                    if(przedmiotInwentarza.Ilosc > 0)
                    {
                        miksturyLeczenia.Add((MiksturaLeczenia)przedmiotInwentarza.Szczegoly);
                    }
                }
            }

            if (miksturyLeczenia.Count == 0)
            {
                cboMikstury.Visible = false;
                btnUzyjMikstury.Visible = false;
            }
            else
            {
                cboMikstury.DataSource = miksturyLeczenia;
                cboMikstury.DisplayMember = "Nazwa";
                cboMikstury.ValueMember = "ID";

                cboMikstury.SelectedIndex = 0;
            }
        }


        private void btnUzyjBroni_Click(object sender, EventArgs e)
        {
            Bron biezacaBron = (Bron)cboBronie.SelectedItem;

            int obrazeniaZadaniePotworowi = GeneratorLiczbPseudolosowych.LiczbaPomiedzy(biezacaBron.MinimalneObrazenia, biezacaBron.MaksymalneObrazenia);

            _biezacyPotwor.BiezacePunktyZdrowia -= obrazeniaZadaniePotworowi;

            rbtWiadomosci.Text += "Zadałeś potworowi " + _biezacyPotwor.Nazwa + " " + obrazeniaZadaniePotworowi.ToString() + " punktów obrażeń." + Environment.NewLine;

            if(_biezacyPotwor.BiezacePunktyZdrowia <= 0)
            {
                rbtWiadomosci.Text += "Pokonałeś potwora " + _biezacyPotwor.Nazwa + "." + Environment.NewLine;

                _gracz.PunktyDoswiadczenia += _biezacyPotwor.PunktyDoswiadczeniaDoZdobycia;
                rbtWiadomosci.Text += "Otrzymałeś " + _biezacyPotwor.PunktyDoswiadczeniaDoZdobycia.ToString() + " punktów doświadczenia." + Environment.NewLine;
                
                _gracz.Zloto += _biezacyPotwor.ZlotoDoZdobycia;
                rbtWiadomosci.Text += "Otrzymałeś " + _biezacyPotwor.ZlotoDoZdobycia.ToString() + " złoto" + Environment.NewLine;

                List<PrzedmiotInwentarza> przedmiotyLupu = new List<PrzedmiotInwentarza>();

                foreach(PrzedmiotLupu przedmiotLupu in _biezacyPotwor.TabelaLupu)
                {
                    if(GeneratorLiczbPseudolosowych.LiczbaPomiedzy(1, 100) <= przedmiotLupu.ProcentowaSzansaZdobyciaPrzedmiotu)
                    {
                        przedmiotyLupu.Add(new PrzedmiotInwentarza(przedmiotLupu.Szczegoly, 1));
                    }
                }

                if(przedmiotyLupu.Count == 0)
                {
                    foreach(PrzedmiotLupu przedmiotLupu in _biezacyPotwor.TabelaLupu)
                    {
                        if(przedmiotLupu.JestPrzedmiotemDomyslnym)
                        {
                            przedmiotyLupu.Add(new PrzedmiotInwentarza(przedmiotLupu.Szczegoly, 1));
                        }
                    }
                }

                foreach(PrzedmiotInwentarza przedmiotInwentarza in przedmiotyLupu)
                {
                    _gracz.DodajPrzedmiotDoInwentarza(przedmiotInwentarza.Szczegoly);

                    if (przedmiotInwentarza.Ilosc == 1)
                    {
                        rbtWiadomosci.Text += "Zdobyłeś " + przedmiotInwentarza.Ilosc.ToString() + " " + przedmiotInwentarza.Szczegoly.Nazwa + Environment.NewLine;
                    }
                    else
                    {
                        rbtWiadomosci.Text += "Zdobyłeś " + przedmiotInwentarza.Ilosc.ToString() + " " + przedmiotInwentarza.Szczegoly.NazwaMnoga + Environment.NewLine;
                    }
                }

                ZaktualizujStatystykiGracza();
                ZaktualizujSpisInwentarzaWInterfejsieUzytkownika();
                ZaktualizujSpisBroniWInterfejsieUzytkownika();
                ZaktualizujSpisMiskturWInterfejsieUzytkownika();

                rbtWiadomosci.Text += Environment.NewLine;

                IdzDo(_gracz.BiezacaLokalizacja);
            }
            else
            {
                int obrazeniaZadaneGraczowi = GeneratorLiczbPseudolosowych.LiczbaPomiedzy(0, _biezacyPotwor.MaksymalneObrazenia);

                rbtWiadomosci.Text += _biezacyPotwor.Nazwa + " zadał Ci " + obrazeniaZadaneGraczowi.ToString() + " punktów obrażeń." + Environment.NewLine;

                _gracz.BiezacePunktyZdrowia -= obrazeniaZadaneGraczowi;

                lblPunktyZdrowia.Text = _gracz.BiezacePunktyZdrowia.ToString();

                if(_gracz.BiezacePunktyZdrowia <= 0)
                {
                    rbtWiadomosci.Text += "Zostałeś zabity przez " + _biezacyPotwor.Nazwa + Environment.NewLine;
                    IdzDo(Swiat.LokalizacjaPoID(Swiat.ID_LOKALIZACJI_DOM));
                    _gracz.BiezacePunktyZdrowia = _gracz.MaksymalnePunktyZdrowia;
                }
            }
            PrzewinNaDolOkienkaWiadomosci();
        }

        private void btnUzyjMikstury_Click(object sender, EventArgs e)
        {
            MiksturaLeczenia mikstura = (MiksturaLeczenia)cboMikstury.SelectedItem;

            _gracz.BiezacePunktyZdrowia = (_gracz.BiezacePunktyZdrowia + mikstura.LiczbaPunktowLeczenia);

            if(_gracz.BiezacePunktyZdrowia > _gracz.MaksymalnePunktyZdrowia)
            {
                _gracz.BiezacePunktyZdrowia = _gracz.MaksymalnePunktyZdrowia;
            }

            foreach(PrzedmiotInwentarza przedmiotInwentarza in _gracz.Inwentarz)
            {
                if(przedmiotInwentarza.Szczegoly.ID == mikstura.ID)
                {
                    przedmiotInwentarza.Ilosc--;
                    break;
                }
            }

            rbtWiadomosci.Text += "Wypiłeś miksturę o nazwie " + mikstura.Nazwa + Environment.NewLine;

            int obrazeniaZadaneGraczowi = GeneratorLiczbPseudolosowych.LiczbaPomiedzy(0, _biezacyPotwor.MaksymalneObrazenia);

            rbtWiadomosci.Text += _biezacyPotwor.Nazwa + " zadał Ci " + obrazeniaZadaneGraczowi.ToString() + " punktów obrażeń." + Environment.NewLine;

            _gracz.BiezacePunktyZdrowia -= obrazeniaZadaneGraczowi;

            if(_gracz.BiezacePunktyZdrowia <= 0)
            {
                rbtWiadomosci.Text += "Zostałeś zabity przez " + _biezacyPotwor.Nazwa + Environment.NewLine;
                IdzDo(Swiat.LokalizacjaPoID(Swiat.ID_LOKALIZACJI_DOM));
                _gracz.BiezacePunktyZdrowia = _gracz.MaksymalnePunktyZdrowia;
            }

            lblPunktyZdrowia.Text = _gracz.BiezacePunktyZdrowia.ToString();
            ZaktualizujSpisInwentarzaWInterfejsieUzytkownika();
            ZaktualizujSpisMiskturWInterfejsieUzytkownika();
            PrzewinNaDolOkienkaWiadomosci();
        }

        private void PrzewinNaDolOkienkaWiadomosci()
        {
            rbtWiadomosci.SelectionStart = rbtWiadomosci.Text.Length;
            rbtWiadomosci.ScrollToCaret();
        }
        private void ZaktualizujStatystykiGracza()
        {
            lblPunktyZdrowia.Text = _gracz.BiezacePunktyZdrowia.ToString();
            lblZłoto.Text = _gracz.Zloto.ToString();
            lblDoświadczenie.Text = _gracz.PunktyDoswiadczenia.ToString();
            lblPoziom.Text = _gracz.Poziom.ToString();
        }

        private void GraRPG_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText(NAZWA_PLIKU_DANYCH_GRACZA, _gracz.KonwertujDoStringaXML());
        }

        private void cboBronie_ZmienionoWybranyIndeks(object sender, EventArgs e)
        {
            _gracz.BiezacaBron = (Bron)cboBronie.SelectedItem;
        }
    }
}
