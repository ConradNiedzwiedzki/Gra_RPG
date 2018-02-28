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

            _gracz = new Gracz();

            _gracz.BiezacePunktyZdrowia = 10;
            _gracz.MaksymalnePunktyZdrowia = 10;
            _gracz.Złoto = 20;
            _gracz.PunktyDoświadczenia = 0;
            _gracz.Poziom = 1;

            lblPunktyZdrowia.Text = _gracz.BiezacePunktyZdrowia.ToString();
            lblZłoto.Text = _gracz.Złoto.ToString();
            lblDoświadczenie.Text = _gracz.PunktyDoświadczenia.ToString();
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
