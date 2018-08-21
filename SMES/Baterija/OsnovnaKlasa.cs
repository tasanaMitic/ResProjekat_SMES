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
        public double MaksimalnaSnaga { get; set; }
        public int Ime { get; private set; }

        public OsnovnaKlasa()
        {
            Ime = GetHashCode();
            
            Kapacitet = 10;
        }

        public void PromeniKapacitet(RezimRadaBaterije rezimRada)
        {
            switch (rezimRada)
            {
                case RezimRadaBaterije.PUNJENJE:
                    Kapacitet += 1/60;       //rezim rada se ucitava svakog minuta, pa se i kapacitet menja svakog minuta
                    break;
                case RezimRadaBaterije.PRAZNJENJE:
                    Kapacitet -= 1/60;
                    break;
                case RezimRadaBaterije.NEAKTIVNO:
                    break;
                default:
                    break;
            }
        }
    }
}
