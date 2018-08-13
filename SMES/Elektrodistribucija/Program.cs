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
            Console.WriteLine($"Cena energije za 1kWh je: {elektrodistribucija.Cena}din.");

            ChannelFactory<IElektroDistribucija> factory = new ChannelFactory<IElektroDistribucija>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:4002/IElektroDistribucija"));
            _proxy = factory.CreateChannel();

            while (true)
            {
                elektrodistribucija.Energija = _proxy.DobaviVisak();
                double cena = elektrodistribucija.IzracunajCenuEnergije();
                _proxy.PosaljiCenu(cena);

                Thread.Sleep(1000);
            }

            //Console.ReadLine();
        }
    }
}
