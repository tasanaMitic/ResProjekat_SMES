using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SHES
{
    public class XMLWorker
    {
       
        private XMLWorker()
        {
            if (!File.Exists("database.xml"))
            {
                using (XmlWriter xmlWriter = XmlWriter.Create("database.xml"))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("Unosi");
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                }
            } 
            else
            {
                File.Delete("database.xml");
                using (XmlWriter xmlWriter = XmlWriter.Create("database.xml"))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("Unosi");
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                }
            }
        }

        private static XMLWorker _instance;

        public static XMLWorker Instance ()
        {
            if (_instance == null)
            {
                _instance = new XMLWorker();
            }

            return _instance;
        }

        public void UnesiUXML (double potrosnjaPotrosaca, double uvozIzElektrodistribucije, double snagaPanela, double energijaBaterije, DateTime vremeUnosa)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("database.xml");
            bool postojiDatum = false;
            XmlNode xmlNodeDatum = null;
            String datum = $"{vremeUnosa.Day.ToString()}.{vremeUnosa.Month.ToString()}.{vremeUnosa.Year.ToString()}";
            foreach (XmlNode xmlNode in xmlDocument.DocumentElement.ChildNodes)
            {
                if (xmlNode.Attributes["Datum"].Value.ToString() == datum)
                {
                    postojiDatum = true;
                    xmlNodeDatum = xmlNode;
                    break;
                }
            }

            if (!postojiDatum)
            {
                xmlNodeDatum = xmlDocument.CreateElement("DnevniUnos");
                XmlAttribute datumAttribute = xmlDocument.CreateAttribute("Datum");
                datumAttribute.Value = datum;
                xmlNodeDatum.Attributes.Append(datumAttribute);
                xmlDocument.DocumentElement.AppendChild(xmlNodeDatum);
                
            }
            
            XmlNode unos = xmlDocument.CreateElement("Unos");
            XmlAttribute attribute = xmlDocument.CreateAttribute("Vreme");
            attribute.Value = $"{vremeUnosa.Hour}:{vremeUnosa.Minute}";
            unos.Attributes.Append(attribute);
            XmlNode potrosnjaPotrosacaNode = xmlDocument.CreateElement("PotrosnjaPotrosaca");
            potrosnjaPotrosacaNode.InnerText = potrosnjaPotrosaca.ToString();
            unos.AppendChild(potrosnjaPotrosacaNode);
            XmlNode uvozIzElektrodistribucijeNode = xmlDocument.CreateElement("UvozIzElektrodistribucije");
            uvozIzElektrodistribucijeNode.InnerText = uvozIzElektrodistribucije.ToString();
            unos.AppendChild(uvozIzElektrodistribucijeNode);
            XmlNode snagaPanelaNode = xmlDocument.CreateElement("SnagaPanela");
            snagaPanelaNode.InnerText = snagaPanela.ToString();
            unos.AppendChild(snagaPanelaNode);
            XmlNode energijaBaterijeNode = xmlDocument.CreateElement("EnergijaBaterije");
            energijaBaterijeNode.InnerText = energijaBaterije.ToString();
            unos.AppendChild(energijaBaterijeNode);

            xmlNodeDatum.AppendChild(unos);
            xmlDocument.Save("database.xml");
        }
        public void UnesiCenu (double cena, DateTime datumUnosa)
        {
            String datum = $"{datumUnosa.Day.ToString()}.{datumUnosa.Month.ToString()}.{datumUnosa.Year.ToString()}";
            XmlNode xmlNodeDatum = null;
            bool postojiDatum = false;
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("database.xml");
            foreach (XmlNode xmlNode in xmlDocument.DocumentElement.ChildNodes)
            {
                if (xmlNode.Attributes["Datum"].Value.ToString() == datum)
                {
                    postojiDatum = true;
                    xmlNodeDatum = xmlNode;
                    break;
                }
            }

            if (!postojiDatum)
            {
                xmlNodeDatum = xmlDocument.CreateElement("DnevniUnos");
                XmlAttribute datumAttribute = xmlDocument.CreateAttribute("Datum");
                datumAttribute.Value = datum;
                xmlNodeDatum.Attributes.Append(datumAttribute);
                xmlDocument.DocumentElement.AppendChild(xmlNodeDatum);
            }

            XmlNode unosCeneNode = xmlDocument.CreateElement("Cena");
            unosCeneNode.InnerText = cena.ToString();
            xmlNodeDatum.AppendChild(unosCeneNode);
            xmlDocument.Save("database.xml");
        }
    }
}
/*
<DnevniUnos Datum="3.3.2018"> 
    <Unos Vreme="12:00">
        <PotrosnjaPotrosaca>20</PotrosnjaPotrosaca>
        <VisakEnergije>40</VisakEnergije>
        <SnagaPanela>30</SnagaPanela>
        <EnergijaBaterije>50</EnergijaBaterije>
    </Unos>
    ovde idu ostali unosi za dan
    iza poslednjeg unosa:
    <Cena>1500</Cena>
</DnevniUnos>
..ovde ostali dnevni unosi...
 */