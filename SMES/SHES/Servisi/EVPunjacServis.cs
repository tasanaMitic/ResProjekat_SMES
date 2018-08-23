using Common;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES.Servisi
{
    public class EVPunjacServis : IEVPunjac
    {
        public void PreuzmiEnergiju()
        {
            MainWindow.Info.VisakEnergije -= MainWindow.Info.MaxSnagaBaterije;
        }

        public RezimRadaBaterije PreuzmiRezimRadaBaterije()
        {
            if (MainWindow.Sat.Sati >= 3 && MainWindow.Sat.Sati < 6)
            {
                return RezimRadaBaterije.PUNJENJE;
            }
            else if (MainWindow.Sat.Sati >= 13 && MainWindow.Sat.Sati < 17)
            {
                return RezimRadaBaterije.PRAZNJENJE;
            }
            else
            {
                return RezimRadaBaterije.NEAKTIVNO;
            }
        }
    }
}
