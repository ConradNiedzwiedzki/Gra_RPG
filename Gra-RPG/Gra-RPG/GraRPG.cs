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

        public GraRPG()
        {
            InitializeComponent();

            Lokalizacja lokalizacja = new Lokalizacja(1, "Dom", "To jest Twój dom.");

            _gracz = new Gracz(10, 10, 20, 0, 1);

            _gracz.BiezacePunktyZdrowia = 10;
            _gracz.MaksymalnePunktyZdrowia = 10;
            _gracz.Zloto = 20;
            _gracz.PunktyDoswiadczenia = 0;
            _gracz.Poziom = 1;

            lblPunktyZdrowia.Text = _gracz.BiezacePunktyZdrowia.ToString();
            lblZłoto.Text = _gracz.Zloto.ToString();
            lblDoświadczenie.Text = _gracz.PunktyDoswiadczenia.ToString();
            lblPoziom.Text = _gracz.Poziom.ToString();

        }

        private void GraRPG_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
