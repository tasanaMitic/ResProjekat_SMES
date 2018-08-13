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
        ServiceHost _serviceHost;

        public ElektrodistribucijaServer()
        {
            _serviceHost = new ServiceHost(typeof(ElektroDistribucijaServis));
            _serviceHost.AddServiceEndpoint(typeof(IElektroDistribucija), new NetTcpBinding(), new Uri("net.tcp://localhost:4002/IElektroDistribucija"));
        }

        public void Open()
        {
            _serviceHost.Open();
        }

        public void Close()
        {
            _serviceHost.Close();
        }
    }
}
