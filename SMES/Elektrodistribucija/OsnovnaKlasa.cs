using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektrodistribucija
{
    public class OsnovnaKlasa
    {
        private int cena;
        private double energija;

        public int Cena { get => cena; set => cena = value; }
        public double Energija { get => energija; set => energija = value; }

        public OsnovnaKlasa()
        {
            Cena = 100;
            Energija = 0;
        }
    }
}
