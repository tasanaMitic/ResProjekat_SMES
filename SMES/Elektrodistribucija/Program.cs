using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Elektrodistribucija
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<ISHES> factory = new ChannelFactory<ISHES>(
                                                            new NetTcpBinding(),
                                                            new EndpointAddress("net.tcp://localhost:4000/ISHES"));


            ISHES proxy = factory.CreateChannel();
            Console.WriteLine("Elektrodistribucija je pokrenuta.");

            OsnovnaKlasa elektrodistribucija = new OsnovnaKlasa();

            elektrodistribucija.Energija = proxy.PosaljiVisakEnergijeElektrodistribuciji();
            proxy.PreuzmiInfoOdElektrodistribucije(elektrodistribucija.Energija * elektrodistribucija.Cena);
            
            Console.ReadLine();
        }
    }
}
