using NUnit.Framework;
using Potrosac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotrosacTest
{
    [TestFixture]
    public class PotrosacTest
    {
        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void PreuzmiStanjePotrosaca(bool upaljen)
        {
            var potrosac = new OsnovnaKlasa()
            {
                Upaljen = upaljen
            };

            if (upaljen)
            {
                Assert.IsTrue(potrosac.Upaljen);
            }
            else
            {
                Assert.IsFalse(potrosac.Upaljen);
            }
        }
    }
}
