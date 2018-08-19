using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES.Servisi
{
    public class ElektroDistribucijaServis : IElektroDistribucija
    {
        public double DobaviVisak()
        {
            return MainWindow.Info.VisakEnergije;
        }

        public void PosaljiCenu(double cenaEnergije)
        {
            MainWindow.Info.UvozElektrodistribucije = cenaEnergije;
        }
    }
}
