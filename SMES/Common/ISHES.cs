using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [ServiceContract]
    public interface ISHES
    {
        [OperationContract]
        double PosaljiVisakEnergijeElektrodistribuciji();

        [OperationContract]
        void PreuzmiInfoOdElektrodistribucije(double uvozElektrodistribucije);

        [OperationContract]
        void PreuzmiInfoOdPotrosaca(double potrosnjaPotrosaca);

    }
}
