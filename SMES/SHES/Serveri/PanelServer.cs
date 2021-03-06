﻿using Common.Interfaces;
using SHES.Servisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SHES.Serveri
{
    public class PanelServer
    {
        public ServiceHost serviceHost;

        public PanelServer()
        {
            serviceHost = new ServiceHost(typeof(PanelServis));
            serviceHost.AddServiceEndpoint(typeof(IPanel), new NetTcpBinding(), new Uri("net.tcp://localhost:4001/IPanel"));
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
