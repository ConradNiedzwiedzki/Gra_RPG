using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilnikGry
{
    public class PostacGry
    {
        public int BiezacePunktyZdrowia { get; set; }
        public int MaksymalnePunktyZdrowia { get; set; }

        public PostacGry(int biezacePunktyZdrowia, int maksymalnePunktyZdrowia)
        {
            BiezacePunktyZdrowia = biezacePunktyZdrowia;
            MaksymalnePunktyZdrowia = maksymalnePunktyZdrowia;
        }
    }
}
