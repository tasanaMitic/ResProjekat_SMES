using NUnit.Framework;
using SHES;
using SHES.Servisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHESTest
{
    [TestFixture]
    public class SHESElektrodistribucijaTest
    {
        [Test]
        [TestCase(30)]
        public void PosaljiCenuTest(double cena)
        {
            var elektroDistribucijaServis = new ElektroDistribucijaServis();
            MainWindow.Info.UvozElektrodistribucije = 30;

            elektroDistribucijaServis.PosaljiCenu(cena);

            Assert.AreEqual(30 + cena, MainWindow.Info.UvozElektrodistribucije);
        }

        [Test]
        public void VisakEnergije ()
        {
            var elektroDistribucijaServis = new ElektroDistribucijaServis();
            MainWindow.Info.VisakEnergije = 30;

            elektroDistribucijaServis.DobaviVisak();
            Assert.Zero(MainWindow.Info.VisakEnergije);
        }

        [Test]
        [TestCase(20, 30)]
        [TestCase(20, 20)]
        public void DobaviVisakSnagaIzElektrodistribucije(double visakEnergije, double snagaIzEd)
        {
            MainWindow.Info.VisakEnergije = visakEnergije;
            MainWindow.Info.SnagaIzElektrodistribucije = snagaIzEd;
            var elektroDistribucijaServis = new ElektroDistribucijaServis();
            elektroDistribucijaServis.DobaviVisak();

            if (visakEnergije == snagaIzEd)
            {
                Assert.Zero(MainWindow.Info.SnagaIzElektrodistribucije);
            }
            else
            {
                Assert.AreEqual(snagaIzEd - visakEnergije, MainWindow.Info.SnagaIzElektrodistribucije);
            }
        }
    }
}
