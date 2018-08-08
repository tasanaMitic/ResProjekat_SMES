using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES
{
    public class SHESMetode : ISHES
    {
        private double visakEnergije;
        private double uvozElektrodistribucije;
        private double potrosnjaPotrosaca;

        public double PosaljiVisakEnergijeElektrodistribuciji()
        {
            return visakEnergije;
        }

        public void PreuzmiInfoOdElektrodistribucije(double uvoz)
        {
            uvozElektrodistribucije = uvoz;
        }
        public void PreuzmiInfoOdPotrosaca(double potrosac)
        {
            potrosnjaPotrosaca  = potrosac;
        }
    }
}
