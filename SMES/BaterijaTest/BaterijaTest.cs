using Baterija;
using Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaterijaTest
{
    [TestFixture]
    public class BaterijaTest
    {
        [Test]
        [TestCase(RezimRadaBaterije.NEAKTIVNO)]
        [TestCase(RezimRadaBaterije.PRAZNJENJE)]
        [TestCase(RezimRadaBaterije.PUNJENJE)]
        public void BaterijaPromeniKapacitet(RezimRadaBaterije rezimRada)
        {
            var baterija = new OsnovnaKlasa();
            baterija.PromeniKapacitet(rezimRada);
            switch (rezimRada)
            {
                case RezimRadaBaterije.NEAKTIVNO:
                    {
                        Assert.AreEqual(10, baterija.Kapacitet);
                        break;
                    }
                case RezimRadaBaterije.PRAZNJENJE:
                    {
                        Assert.AreEqual(10 - 1 / 60, baterija.Kapacitet);
                        break;
                    }
                case RezimRadaBaterije.PUNJENJE:
                    {
                        Assert.AreEqual(10 + 1 / 60, baterija.Kapacitet);
                        break;
                    }
            }
        }
    }
}
