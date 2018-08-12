using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Baterija
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Baterija je pokrenuta.");

            OsnovnaKlasa baterija = new OsnovnaKlasa();
            RezimRadaBaterije rezimRada = new RezimRadaBaterije();

            

            switch (rezimRada)
            {
                case RezimRadaBaterije.PUNJENJE:
                    baterija.Kapacitet += 1/60;       //izmeniti da se kapacitet povecava za jedan u odnosu na vreme
                    break;
                case RezimRadaBaterije.PRAZNJENJE:
                    baterija.Kapacitet -= 1/60;
                    break;
                case RezimRadaBaterije.NEAKTIVNO:
                    break;
                default:
                    break;
            }       

           
        }
    }
}
