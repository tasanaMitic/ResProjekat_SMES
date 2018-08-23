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
        public ServiceHost serviceHost;

        public PotrosacServer()
        {
            serviceHost = new ServiceHost(typeof(PotrosacServis));
            serviceHost.AddServiceEndpoint(typeof(IPotrosac), new NetTcpBinding(), new Uri("net.tcp://localhost:4000/IPotrosac"));
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
