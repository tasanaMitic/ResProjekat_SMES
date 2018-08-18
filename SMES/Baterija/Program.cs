using Common;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Baterija
{
    class Program
    {
        private static IBaterija _proxy;
        private static OsnovnaKlasa baterija = new OsnovnaKlasa();
        private static RezimRadaBaterije rezimRada = new RezimRadaBaterije();
        static void Main(string[] args)
        {
            Console.WriteLine($"Baterija ima kapacitet: {baterija.Kapacitet}h.");

            Console.WriteLine("Unesite maksimalnu snagu baterije: ");
            Double temp;
            while (!Double.TryParse(Console.ReadLine(), out temp)) ;
            baterija.MaksimalnaSnaga = temp;

            ChannelFactory<IBaterija> factory = new ChannelFactory<IBaterija>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:4003/IBaterija"));
            _proxy = factory.CreateChannel();
            Thread t = new Thread(new ThreadStart(MetodaBaterije));

            t.IsBackground = true;
            t.Start();

            Console.ReadLine();
        }

        private static void MetodaBaterije()
        {
            while(true)
            {
                rezimRada =  _proxy.PreuzmiRezimRada();
                Console.WriteLine($"Rezim rada baterije je: {rezimRada}");
                baterija.PromeniKapacitet(rezimRada);
                _proxy.PosaljiInfoSHESu(baterija.Kapacitet, rezimRada, baterija.MaksimalnaSnaga);

                Thread.Sleep(1000);
            }
        }
    }
}
