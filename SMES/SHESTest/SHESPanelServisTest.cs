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
    public class SHESPanelServisTest
    {
        [Test]
        [TestCase(30)]
        [TestCase(0)]
        [TestCase(-30)]
        public void PosaljiEnergijuSnagaPenelaTest(double kolicina)
        {
            MainWindow.Info.SnagaPanela = 30;
            var panelServis = new PanelServis();

            panelServis.PosaljiEnergiju(kolicina);

            Assert.AreEqual(30 + kolicina, MainWindow.Info.SnagaPanela);
        }

        [Test]
        [TestCase(30)]
        [TestCase(0)]
        [TestCase(-30)]
        public void PosaljiEnergijuVisakEnergijeTest(double kolicina)
        {
            MainWindow.Info.VisakEnergije = 30;
            var panelServis = new PanelServis();

            panelServis.PosaljiEnergiju(kolicina);

            Assert.AreEqual(30 + kolicina, MainWindow.Info.VisakEnergije);
        }
    }
}
