using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektrodistribucija
{
    public class OsnovnaKlasa
    {
        public double Cena { get; private set; }

        public OsnovnaKlasa()
        {

        }

        public double IzracunajCenuEnergije(double energija)
        {
            return Cena * energija;
        }
    }
}
