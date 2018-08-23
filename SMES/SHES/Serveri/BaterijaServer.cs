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
        public ServiceHost serviceHost;

        public BaterijaServer()
        {
            serviceHost = new ServiceHost(typeof(BaterijaServis));
            serviceHost.AddServiceEndpoint(typeof(IBaterija), new NetTcpBinding(), new Uri("net.tcp://localhost:4003/IBaterija"));
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
