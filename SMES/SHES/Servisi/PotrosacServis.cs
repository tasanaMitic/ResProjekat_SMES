using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES.Servisi
{
    public class PotrosacServis : IPotrosac
    {
        public void PosaljiPotrosnju(double potrosnja)
        {
            MainWindow.Info.PotrosnjaPotrosaca += potrosnja;
            MainWindow.Info.VisakEnergije -= potrosnja;
        }
    }
}
