using SilnikGry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gra_RPG
{
    public partial class GraRPG : Form
    {
        private Gracz _gracz;
        private Potwor _biezacyPotwor;

        public GraRPG()
        {
            InitializeComponent();            

            _gracz = new Gracz(10, 10, 20, 0, 1);
            IdzDo(Swiat.LokalizacjaPoID(Swiat.ID_LOKALIZACJI_DOM));
            _gracz.Inwentarz.Add(new PrzedmiotInwentarza(Swiat.PrzedmiotPoID(Swiat.ID_PRZEDMIOTU_ZARDZEWIALY_MIECZ), 1));
            
            lblPunktyZdrowia.Text = _gracz.BiezacePunktyZdrowia.ToString();
            lblZłoto.Text = _gracz.Zloto.ToString();
            lblDoświadczenie.Text = _gracz.PunktyDoswiadczenia.ToString();
            lblPoziom.Text = _gracz.Poziom.ToString();
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
                            rbtWiadomosci.Text += "Wykonałeś zadanie o nazwie " + nowaLokalizacja.DostepneZadanieTegoMiejsca.Nazwa + "." + Environment.NewLine;

                            _gracz.UsunPrzedmiotyWymaganeDoWykonaniaZadania(nowaLokalizacja.DostepneZadanieTegoMiejsca);

                            rbtWiadomosci.Text += "Otrzymałeś: " + Environment.NewLine;
                            rbtWiadomosci.Text += nowaLokalizacja.DostepneZadanieTegoMiejsca.PunktyDoswiadczeniaDoZdobycia.ToString() + " punktów doświadczenia" + Environment.NewLine;
                            rbtWiadomosci.Text += nowaLokalizacja.DostepneZadanieTegoMiejsca.ZlotoDoZdobycia.ToString() + " złota" + Environment.NewLine;
                            rbtWiadomosci.Text += nowaLokalizacja.DostepneZadanieTegoMiejsca.PrzedmiotNagroda.Nazwa + Environment.NewLine;

                            _gracz.PunktyDoswiadczenia += nowaLokalizacja.DostepneZadanieTegoMiejsca.PunktyDoswiadczeniaDoZdobycia;
                            _gracz.Zloto += nowaLokalizacja.DostepneZadanieTegoMiejsca.ZlotoDoZdobycia;

                            _gracz.DodajPrzedmiotDoInwentarza(nowaLokalizacja.DostepneZadanieTegoMiejsca.PrzedmiotNagroda);

                            _gracz.OznaczZadanieJakoUkonczone(nowaLokalizacja.DostepneZadanieTegoMiejsca);
                        }
                    }
                }
                else
                {
                    rbtWiadomosci.Text += "Otrzymałeś zadanie o nazwie " + nowaLokalizacja.DostepneZadanieTegoMiejsca.Nazwa + "." + Environment.NewLine;
                    rbtWiadomosci.Text += nowaLokalizacja.DostepneZadanieTegoMiejsca.Opis + Environment.NewLine;
                    rbtWiadomosci.Text += "Aby ukończyć to zadanie, powróć tu z:" + Environment.NewLine;
                    foreach (PrzedmiotDoWykonaniaZadania przedmiotDoWykonaniaZadania in nowaLokalizacja.DostepneZadanieTegoMiejsca.PrzedmiotyDoWykonaniaZadania)
                    {
                        if (przedmiotDoWykonaniaZadania.Ilosc == 1)
                        {
                            rbtWiadomosci.Text += przedmiotDoWykonaniaZadania.Ilosc.ToString() + " " + przedmiotDoWykonaniaZadania.Szczegoly.Nazwa + Environment.NewLine;
                        }
                        else
                        {
                            rbtWiadomosci.Text += przedmiotDoWykonaniaZadania.Ilosc.ToString() + " " + przedmiotDoWykonaniaZadania.Szczegoly.NazwaMnoga + Environment.NewLine;
                        }
                    }
                    rbtWiadomosci.Text += Environment.NewLine;

                    _gracz.Zadania.Add(new ZadanieGracza(nowaLokalizacja.DostepneZadanieTegoMiejsca));
                }
            }

            if (nowaLokalizacja.PotworZyjacyWTymMiejscu != null)
            {
                rbtWiadomosci.Text += "Widzisz " + nowaLokalizacja.PotworZyjacyWTymMiejscu.Nazwa + Environment.NewLine;

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

            ZaktualizujSpisInwentarzaWInterfejsieUzytkownika();
            ZaktualizujSpisZadanWInterfejsieUzytkownika();
            ZaktualizujSpisBroniWInterfejsieUzytkownika();
            ZaktualizujSpisMiskturWInterfejsieUzytkownika();
        }

        private void ZaktualizujSpisInwentarzaWInterfejsieUzytkownika()
        {
            dgvInwentarz.RowHeadersVisible = false;

            dgvInwentarz.ColumnCount = 2;
            dgvInwentarz.Columns[0].Name = "Name";
            dgvInwentarz.Columns[0].Width = 197;
            dgvInwentarz.Columns[0].Name = "Ilość";

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
            dgvZadania.Columns[0].Name = "Name";
            dgvZadania.Columns[0].Width = 197;
            dgvZadania.Columns[0].Name = "Ukończone?";

            dgvZadania.Rows.Clear();

            foreach(ZadanieGracza zadanieGracza in _gracz.Zadania)
            {
                dgvZadania.Rows.Add(new[] { zadanieGracza.Szczegoly.Nazwa, zadanieGracza.JestUkonczone.ToString() });
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
                cboBronie.DataSource = bronie;
                cboBronie.DisplayMember = "Nazwa";
                cboBronie.ValueMember = "ID";

                cboBronie.SelectedIndex = 0;
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

        }

        private void btnUzyjMikstury_Click(object sender, EventArgs e)
        {

        }
    }
}
