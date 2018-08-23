using NUnit.Framework;
using SHES.Serveri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SHESTest.ServeriTest
{
    class PanelServerTest
    {
        [Test]
        public void OtvoriServerTest()
        {
            var panelServer = new PanelServer();
            panelServer.Open();

            Assert.AreEqual(CommunicationState.Opened, panelServer.serviceHost.State);
            panelServer.Close();
        }

        [Test]
        public void ZatvoriServerTest()
        {
            var panelServer = new PanelServer();
            panelServer.Open();

            panelServer.Close();
   

            Assert.AreEqual(CommunicationState.Closed, panelServer.serviceHost.State);
        }
    }
}
