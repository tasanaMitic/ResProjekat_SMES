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
        public RezimRadaBaterije PreuzmiRezimRada()
        {
            if (MainWindow.Sat.Sati >= 3 && MainWindow.Sat.Sati < 6)
            {
                return RezimRadaBaterije.PUNJENJE;
            }
            else if (MainWindow.Sat.Sati > 13 && MainWindow.Sat.Sati < 17)
            {
                return RezimRadaBaterije.PRAZNJENJE;
            }
            else
            {
                return RezimRadaBaterije.NEAKTIVNO;
            }
        }

        public void PosaljiInfoSHESu(double kapacitet, RezimRadaBaterije rezimRada, double snagaBaterije)
        {
            switch (rezimRada)
            {
                case RezimRadaBaterije.PUNJENJE:
                    {
                        MainWindow.Info.VisakEnergije -= kapacitet * snagaBaterije;
                        MainWindow.Info.EnergijaBaterije -= kapacitet * snagaBaterije;
                        MainWindow.Info.MaxSnagaBaterije = snagaBaterije;
                        break;
                    }
                case RezimRadaBaterije.PRAZNJENJE:
                    {
                        MainWindow.Info.EnergijaBaterije += kapacitet * snagaBaterije;
                        MainWindow.Info.VisakEnergije += kapacitet * snagaBaterije;
                        MainWindow.Info.MaxSnagaBaterije = snagaBaterije;
                        break;
                    } 
                case RezimRadaBaterije.NEAKTIVNO:
                    break;
                default:
                    break;
            }
        }
    }
}
