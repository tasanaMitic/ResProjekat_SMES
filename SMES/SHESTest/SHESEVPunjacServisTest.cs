using NUnit.Framework;
using SHES.Servisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHES;
using Common;

namespace SHESTest
{
    [TestFixture]
    public class SHESEVPunjacServisTest
    {
        [Test]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(6)]
        [TestCase(11)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(17)]
        public void PreuzmiRezimRadaTest(int sati)
        {
            var punjacServis = new EVPunjacServis();
            MainWindow.Sat.Sati = sati;


            RezimRadaBaterije rezimRadaBaterije = punjacServis.PreuzmiRezimRadaBaterije();

            if (sati >= 3 && sati < 6)
            {
                Assert.AreEqual(RezimRadaBaterije.PUNJENJE, rezimRadaBaterije);
            }
            else if (sati >= 13 && sati < 17)
            {
                Assert.AreEqual(RezimRadaBaterije.PRAZNJENJE, rezimRadaBaterije);
            }
            else
            {
                Assert.AreEqual(RezimRadaBaterije.NEAKTIVNO, rezimRadaBaterije);
            }
        }

        [Test]
        [TestCase(30)]
        public void PreuzmiEnergijuServis(double maxSnagaBaterije)
        {
            MainWindow.Info.MaxSnagaBaterije = maxSnagaBaterije;
            MainWindow.Info.VisakEnergije = 30;
            var punjcaServis = new EVPunjacServis();
            punjcaServis.PreuzmiEnergiju();

            Assert.AreEqual(30 - maxSnagaBaterije, MainWindow.Info.VisakEnergije);
        }
    }
}
