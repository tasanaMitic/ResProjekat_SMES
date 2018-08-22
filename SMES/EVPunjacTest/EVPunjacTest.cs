using EVPunjac;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVPunjacTest
{
    [TestFixture]
    public class EVPunjacTest
    {
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void EVPunjacPreuzmiStanjePunjaca(bool naPunjacu)
        {
            var punjac = new OsnovnaKlasa();
            punjac.NaPunjacu = naPunjacu;

            if (naPunjacu)
            {
                Assert.AreEqual("Prikljucen na punjac", punjac.PreuzmiStanjePunjaca);
            }
            else
            {
                Assert.AreEqual("Nije prikljucen na punjac", punjac.PreuzmiStanjePunjaca);
            }
        }
    }
}
