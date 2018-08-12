using Common;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES.Servisi
{
    public class BaterijaServis : IBaterija
    {
        public RezimRadaBaterije PosaljiInfoSHESu(double kapacitet, RezimRadaBaterije rezimRada, double snagaBaterije)
        {
            switch (rezimRada)
            {
                case RezimRadaBaterije.PUNJENJE:
                    MainWindow.Info.PotrosnjaPotrosaca -= kapacitet * snagaBaterije;
                    return RezimRadaBaterije.PUNJENJE; //za sada ovako, inace ce ovo zavisiti od sata
                case RezimRadaBaterije.PRAZNJENJE:
                    MainWindow.Info.PotrosnjaPotrosaca += kapacitet * snagaBaterije;
                    return RezimRadaBaterije.PRAZNJENJE;
                case RezimRadaBaterije.NEAKTIVNO:
                    return RezimRadaBaterije.NEAKTIVNO;
                default:
                    return RezimRadaBaterije.NEAKTIVNO;
            }
        }
    }
}
