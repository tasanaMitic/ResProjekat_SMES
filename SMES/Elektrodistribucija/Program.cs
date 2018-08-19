using Common;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Elektrodistribucija
{
    class Program
    {
        private static IElektroDistribucija _proxy;
        private static OsnovnaKlasa elektrodistribucija = new OsnovnaKlasa();
        static void Main(string[] args)
        {
            Console.WriteLine("Unesite cenu energije za 1kWh: ");
            Double temp;
            while (!Double.TryParse(Console.ReadLine(), out temp)) ;
            elektrodistribucija.Cena = temp;

            ChannelFactory<IElektroDistribucija> factory = new ChannelFactory<IElektroDistribucija>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:4002/IElektroDistribucija"));
            _proxy = factory.CreateChannel();
            Thread t = new Thread(new ThreadStart(MetodaElektrodistribucije));

            t.IsBackground = true;
            t.Start();            

           Console.ReadLine();
        }

        private static void MetodaElektrodistribucije()
        {
            while (true)
            {

                double cena = elektrodistribucija.IzracunajCenuEnergije(_proxy.DobaviVisak());
                _proxy.PosaljiCenu(cena);

                Thread.Sleep(1000);
            }
        }
    }
}
