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
    public class ElektrodistribucijaServerTest
    {
        [Test]
        public void OtvoriServerTest()
        {
            var elektrodistribucijaServer = new ElektrodistribucijaServer();
            elektrodistribucijaServer.Open();

            Assert.AreEqual(CommunicationState.Opened, elektrodistribucijaServer.serviceHost.State);
            elektrodistribucijaServer.Close();
        }

        [Test]
        public void ZatvoriServerTest()
        {
            var elektrodistribucijaServer = new ElektrodistribucijaServer();
            elektrodistribucijaServer.Open();
            Thread.Sleep(10);
            elektrodistribucijaServer.Close();
            Thread.Sleep(10);

            Assert.AreEqual(CommunicationState.Closed, elektrodistribucijaServer.serviceHost.State);
        }
    }
}
