using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHES;
using SHES.Servisi;
using Common;

namespace SHESTest
{
    [TestFixture]
    class SHESBaterijaServisTest
    {
        [Test]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(6)]
        [TestCase(11)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(17)]
        public void PreuzmiRezimRadaTest (int sati)
        {
            var baterijaServis = new BaterijaServis();
            MainWindow.Sat.Sati = sati;
            

            RezimRadaBaterije rezimRadaBaterije = baterijaServis.PreuzmiRezimRada();

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
        [TestCase(30, 30, RezimRadaBaterije.NEAKTIVNO)]
        [TestCase(30, 30, RezimRadaBaterije.PRAZNJENJE)]
        [TestCase(30, 30, RezimRadaBaterije.PUNJENJE)]
        public void PosaljiInfoSHESuVisakEnergijeTest (double kapacitet, double snagaBaterije, RezimRadaBaterije rezimRadaBaterije)
        {
            MainWindow.Info.VisakEnergije = 50;
            var baterijaServis = new BaterijaServis();
            baterijaServis.PosaljiInfoSHESu(kapacitet, rezimRadaBaterije, snagaBaterije);

            if (rezimRadaBaterije == RezimRadaBaterije.NEAKTIVNO)
            {
                Assert.AreEqual(50, MainWindow.Info.VisakEnergije);
            }
            else if (rezimRadaBaterije == RezimRadaBaterije.PRAZNJENJE)
            {
                Assert.AreEqual(50 + kapacitet * snagaBaterije, MainWindow.Info.VisakEnergije);
            }
            else
            {
                Assert.AreEqual(50 - kapacitet * snagaBaterije, MainWindow.Info.VisakEnergije);
            }
        }
    }
}
