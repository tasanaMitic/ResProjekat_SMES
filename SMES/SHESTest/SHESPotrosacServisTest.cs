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
    public class SHESPotrosacServisTest
    {
        [Test]
        [TestCase(-50)]
        [TestCase(30)]
        [TestCase(0)]
        public void PotrosnjaPotrosnjaPotrosacaTest(double potrosnja)
        {
            MainWindow.Info.PotrosnjaPotrosaca = 30;
            var potrosacServis = new PotrosacServis();
            potrosacServis.PosaljiPotrosnju(potrosnja);

            Assert.AreEqual(30 + potrosnja, MainWindow.Info.PotrosnjaPotrosaca);
        }

        [Test]
        [TestCase(-50)]
        [TestCase(30)]
        [TestCase(0)]
        public void PotrosnjaVisakEnergijeTest(double potrosnja)
        {
            MainWindow.Info.VisakEnergije = 30;
            var potrosacServis = new PotrosacServis();
            potrosacServis.PosaljiPotrosnju(potrosnja);

            Assert.AreEqual(30 - potrosnja, MainWindow.Info.VisakEnergije);
        }
    }
}
