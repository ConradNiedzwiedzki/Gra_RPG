using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SilnikGry
{
    public static class GeneratorLiczbPseudolosowych
    {
        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();

        public static int LiczbaPomiedzy(int wartoscMinimalna, int wartoscMaksymalna)
        {
            byte[] pseudolosowaLiczba = new byte[1];

            _generator.GetBytes(pseudolosowaLiczba);

            double wartoscASCIIzPseudolosowegoZnaku = Convert.ToDouble(pseudolosowaLiczba[0]);
            double multyplikator = Math.Max(0, (wartoscASCIIzPseudolosowegoZnaku / 255d) - 0.00000000001d);

            int zakres = wartoscMaksymalna - wartoscMinimalna + 1;

            double wartoscPseudolosowaWZakresie = Math.Floor(multyplikator * zakres);

            return (int)(wartoscMinimalna + wartoscPseudolosowaWZakresie);
        }
    }
}
