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
    public class PotrosacServer
    {
        ServiceHost _serviceHost;

        public PotrosacServer()
        {
            _serviceHost = new ServiceHost(typeof(PotrosacServis));
            _serviceHost.AddServiceEndpoint(typeof(IPotrosac), new NetTcpBinding(), new Uri("net.tcp://localhost:4000/IPotrosac"));
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
