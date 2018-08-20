using System;
using System.Collections.Generic;
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
            using (XmlWriter xmlWriter = XmlWriter.Create("database.xml"))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteEndDocument();
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

        public void UnesiUXML (double potrosnjaPotrosaca, double visakEnergije, double snagaPanela, double energijaBaterije, DateTime vremeUnosa)
        {
            //TODO
        }
        public void UnesiCenu (double cena, DateTime datumUnosa)
        {
            //TODO
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