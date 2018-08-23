using NUnit.Framework;
using SHES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SHESTest
{
    [TestFixture]
    public class SatTest
    {
        [Test]
        public void PokreniSatTest()
        {
            Sat sat = new Sat();
            sat.Minuta = 59;
            sat.Sati = 23;
            sat.Datum = new DateTime(2012, 12, 31);

            sat.PokreniSat();
            //Thread.Sleep(100);
            var expected = new DateTime(2013, 1, 1);
            Assert.AreEqual(expected, sat.Datum);
        }

        [Test]
        [TestCase(59)]
        [TestCase(31)]
        public void PokreniSatMinuti (int minuta)
        {
            Sat sat = new Sat();
            sat.Minuta = minuta;

            sat.PokreniSat();
            if (minuta == 59)
            {
                Assert.Zero(sat.Minuta);
            }
            else
            {
                Assert.AreEqual(minuta + 1, sat.Minuta);
            }
        }
    }
}
