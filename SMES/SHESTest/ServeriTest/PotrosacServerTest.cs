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
    public class PotrosacServerTest
    {
        [Test]
        public void OtvoriServerTest ()
        {
            var potrosacServer = new PotrosacServer();
            potrosacServer.Open();

            Assert.AreEqual(CommunicationState.Opened, potrosacServer.serviceHost.State);
            potrosacServer.Close();
        }

        [Test]
        public void ZatvoriServerTest()
        {
            var potrosacServer = new PotrosacServer();
            potrosacServer.Open();

            potrosacServer.Close();



            Assert.AreEqual(CommunicationState.Closed, potrosacServer.serviceHost.State);
        }
    }
}
