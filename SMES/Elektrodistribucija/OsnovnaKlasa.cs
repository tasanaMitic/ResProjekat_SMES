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
        public double Energija { get; set; }

        public OsnovnaKlasa()
        {
            Cena = 100;
            Energija = 0;
        }

        public double IzracunajCenuEnergije()
        {
            return Cena * Energija;
        }
    }
}
