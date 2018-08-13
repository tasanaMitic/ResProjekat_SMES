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
    public class BaterijaServer
    {
        ServiceHost _serviceHost;

        public BaterijaServer()
        {
            _serviceHost = new ServiceHost(typeof(BaterijaServis));
            _serviceHost.AddServiceEndpoint(typeof(IBaterija), new NetTcpBinding(), new Uri("net.tcp://localhost:4003/IBaterija"));
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
