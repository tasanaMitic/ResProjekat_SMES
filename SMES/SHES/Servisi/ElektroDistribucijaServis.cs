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
            double visak = MainWindow.Info.VisakEnergije;
            MainWindow.Info.SnagaIzElektrodistribucije -= visak;
            MainWindow.Info.VisakEnergije -= visak;
            return visak;
        }

        public void PosaljiCenu(double cenaEnergije)
        {
            MainWindow.Info.UvozElektrodistribucije += cenaEnergije;
        }
    }
}
