using NUnit.Framework;
using SHES;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHESTest
{
    [TestFixture]
    public class XMLWorkerTest
    {
        [Test]
        public void FajlNePostojiTest()
        {
            XMLWorker.Instance();
            Assert.IsTrue(File.Exists("database.xml"));
            File.Delete("database.xml");
        }

        [Test]
        public void FajlPostojiTest()
        {
            using (var stream = File.Create("database.xml")) { }
            
            XMLWorker.Instance();
            Assert.IsTrue(File.Exists("database.xml"));
            File.Delete("database.xml");

        }
    }
}
