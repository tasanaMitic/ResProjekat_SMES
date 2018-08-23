using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using SHES.Serveri;
using NUnit.Framework;
using System.Threading;

namespace SHESTest.ServeriTest
{
    [TestFixture]
    public class EVPunjacServerTest
    {
        [Test]
        public void OtvoriServerTest()
        {
            var evPunjacServer = new EVPunjacServer();
            evPunjacServer.Open();

            Assert.AreEqual(CommunicationState.Opened, evPunjacServer.serviceHost.State);
            evPunjacServer.Close();
        }

        [Test]
        public void ZatvoriServerTest()
        {
            var evPunjacServer = new EVPunjacServer();
            evPunjacServer.Open();

            evPunjacServer.Close();


            Assert.AreEqual(CommunicationState.Closed, evPunjacServer.serviceHost.State);
        }
    }
}
