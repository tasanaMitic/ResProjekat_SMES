using NUnit.Framework;
using SHES;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace SHESTest
{
    [TestFixture]
    public class XMLWorkerTest
    {
        String putanja = @"E:\Fax\RES\Projekat\ResProjekat_SMES\SMES\database.xml";
        [Test]
        public void FajlNePostojiTest()
        {
            XMLWorker.Instance();
            Assert.IsTrue(File.Exists(putanja));
            File.Delete(putanja);
        }

        [Test]
        public void FajlPostojiTest()
        {
            using (var stream = File.Create(putanja)) { }
            
            XMLWorker.Instance();
            Assert.IsTrue(File.Exists(putanja));
            File.Delete(putanja);

        }

        [Test]
        public void UpisPotrosnjeUXMLTest()
        {
            double potrosnjaPotrosaca = 20;
            double uvozIzElektrodistribucije = 20;
            double snagaPanela = 40;
            double energijaBaterije = 10;
            DateTime dateTime = new DateTime(2017, 2, 2, 3, 40, 0);

            XMLWorker.Instance().UnesiUXML(potrosnjaPotrosaca, uvozIzElektrodistribucije, snagaPanela, energijaBaterije, dateTime);
            StringBuilder ocekivano = new StringBuilder();
            ocekivano.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            ocekivano.AppendLine("<Unosi>");
            ocekivano.AppendLine("<DnevniUnos Datum=\"2.2.2017\">");
            ocekivano.AppendLine("<Unos Vreme=\"3:40\">");
            ocekivano.AppendLine("<PotrosnjaPotrosaca >20</ PotrosnjaPotrosaca >");
            ocekivano.AppendLine("<UvozIzElektrodistribucije>20</UvozIzElektrodistribucije>");
            ocekivano.AppendLine("<SnagaPanela>40</ SnagaPanela>");
            ocekivano.AppendLine("<EnergijaBaterije>10</EnergijaBaterije>");
            ocekivano.AppendLine("</Unos>");
            ocekivano.AppendLine("</DnevniUnos>");
            ocekivano.AppendLine("</Unosi>");
            String strOcekivano = ocekivano.ToString();
            strOcekivano = Regex.Replace(strOcekivano, @"\s+", string.Empty);

            String procitano = File.ReadAllText(putanja);
            procitano = Regex.Replace(procitano, @"\s+", string.Empty);

            Assert.AreEqual(strOcekivano, procitano);

        }
    }
}
