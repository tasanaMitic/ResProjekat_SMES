using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    [ServiceContract]
    public interface IElektroDistribucija
    {
        [OperationContract]
        double DobaviVisak();

        [OperationContract]
        void PosaljiCenu(double cenaEnergije);
    }
}
