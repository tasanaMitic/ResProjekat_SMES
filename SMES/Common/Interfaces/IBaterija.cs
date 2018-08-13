using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    [ServiceContract]
    public interface IBaterija
    {
        [OperationContract]
        void PosaljiInfoSHESu(double kapacitet, RezimRadaBaterije rezimRada, double snagaBaterije);

        [OperationContract]
        RezimRadaBaterije PreuzmiRezimRada();

    }
}
