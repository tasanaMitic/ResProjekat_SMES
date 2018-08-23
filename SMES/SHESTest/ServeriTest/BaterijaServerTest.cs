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
    [TestFixture]
    public class BaterijaServerTest
    {
        [Test]
        public void OtvoriServerTest()
        {
            var baterijaServer = new BaterijaServer();
            baterijaServer.Open();

            Assert.AreEqual(CommunicationState.Opened, baterijaServer.serviceHost.State);
            baterijaServer.Close();
        }

        [Test]
        public void ZatvoriServerTest()
        {
            var baterijaServer = new BaterijaServer();
            baterijaServer.Open();

            baterijaServer.Close();
           

            Assert.AreEqual(CommunicationState.Closed, baterijaServer.serviceHost.State);
        }
    }
}
