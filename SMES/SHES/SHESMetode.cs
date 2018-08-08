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
        public RezimRadaBaterije PosaljiRezimRadaBateriji()
        {
            //u zavisnosti od toga koliko ima sati
            return RezimRadaBaterije.PRAZNJENJE;
           
        }

        public void PreuzmiInfoOdBaterije(double kapacitet, RezimRadaBaterije rezimRada, double snagaBaterije)
        {
            switch (rezimRada)
            {
                case RezimRadaBaterije.PUNJENJE:
                    visakEnergije -= kapacitet * snagaBaterije;
                    break;
                case RezimRadaBaterije.PRAZNJENJE:
                    visakEnergije += kapacitet * snagaBaterije;
                    break;
                case RezimRadaBaterije.NEAKTIVNO:
                    break;
                default:
                    break;
            }
        }
    }
}
