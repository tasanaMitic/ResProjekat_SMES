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
    public class EVPunjacServer
    {
        ServiceHost _serviceHost;

        public EVPunjacServer()
        {
            _serviceHost = new ServiceHost(typeof(EVPunjacServis));
            _serviceHost.AddServiceEndpoint(typeof(IEVPunjac), new NetTcpBinding(), new Uri("net.tcp://localhost:4004/IEVPunjac"));
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
