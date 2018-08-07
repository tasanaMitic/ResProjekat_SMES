using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektrodistribucija
{
    class MetodeElektrodistribucije : IElektrodistribucija
    {
        OsnovnaKlasa osnovnaKlasa = new OsnovnaKlasa();

        public void PosaljiVisakEnergijeElektrodistribuciji(double visakEnergije)
        {            
            osnovnaKlasa.Energija = visakEnergije;
        }

        public int PreuzmiInfoOdElektrodistribucije()
        {
            return (int)(osnovnaKlasa.Cena * osnovnaKlasa.Energija);
        }
    }
}
