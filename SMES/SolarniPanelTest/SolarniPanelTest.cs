using NUnit.Framework;
using SolarniPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarniPanelTest
{
    [TestFixture]
    public class SolarniPanelTest
    {
        [Test]
        [TestCase(50, 0)]
        [TestCase(0, 50)]
        [TestCase(50, 100)]
        [TestCase(10, 30)]
        public void PreuzmiTrenutnuSnaguPanela(double maksimalnaSnaga, double jacinaSunca)
        {
            var panel = new OsnovnaKlasa() { MaksimalnaSnaga = maksimalnaSnaga, JacinaSunca = jacinaSunca };
            double snagaPanela = panel.PreuzmiTrenutnuSnaguPanela();
            if (jacinaSunca == 100)
            {
                Assert.AreEqual(maksimalnaSnaga, snagaPanela);
            }
            else if (maksimalnaSnaga == 0 || jacinaSunca == 0)
            {
                Assert.Zero(snagaPanela);
            }
            else
            {
                Assert.AreEqual(maksimalnaSnaga * jacinaSunca / 100, snagaPanela);
            }
        }
    }
}
