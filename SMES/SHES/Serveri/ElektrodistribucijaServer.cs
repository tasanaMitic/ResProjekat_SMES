using Common.Interfaces;
using SHES.Servisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SHES.Serveri
{
    public class ElektrodistribucijaServer
    {
        public ServiceHost serviceHost;

        public ElektrodistribucijaServer()
        {
            serviceHost = new ServiceHost(typeof(ElektroDistribucijaServis));
            serviceHost.AddServiceEndpoint(typeof(IElektroDistribucija), new NetTcpBinding(), new Uri("net.tcp://localhost:4002/IElektroDistribucija"));
        }

        public void Open()
        {
            serviceHost.Open();
        }

        public void Close()
        {
            serviceHost.Close();
        }
    }
}
