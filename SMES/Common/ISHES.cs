using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum RezimRadaBaterije
    {
        PUNJENJE, PRAZNJENJE, NEAKTIVNO 
    }

    [ServiceContract]
    public interface ISHES
    {
        [OperationContract]
        double PosaljiVisakEnergijeElektrodistribuciji();

        [OperationContract]
        void PreuzmiInfoOdElektrodistribucije(double uvozElektrodistribucije);

        [OperationContract]
        void PreuzmiInfoOdPotrosaca(double potrosnjaPotrosaca);

        [OperationContract]
        void PreuzmiInfoOdBaterije(double kapacitet, RezimRadaBaterije rezimRada, double snagaBaterije);

        [OperationContract]
        RezimRadaBaterije PosaljiRezimRadaBateriji();

    }
}
