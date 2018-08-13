using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baterija
{
    public class OsnovnaKlasa
    {
        public double Kapacitet { get; private set; }
        public double MaksimalnaSnaga { get; private set; }
        public int Ime { get; private set; }

        public OsnovnaKlasa()
        {
            Ime = GetHashCode();
            MaksimalnaSnaga = 200;
            Kapacitet = 250;
        }

        public void PromeniKapacitet(RezimRadaBaterije rezimRada)
        {
            switch (rezimRada)
            {
                case RezimRadaBaterije.PUNJENJE:
                    Kapacitet += 1 / 60;       //izmeniti da se kapacitet povecava za jedan u odnosu na vreme
                    break;
                case RezimRadaBaterije.PRAZNJENJE:
                    Kapacitet -= 1 / 60;
                    break;
                case RezimRadaBaterije.NEAKTIVNO:
                    break;
                default:
                    break;
            }
        }
    }
}
