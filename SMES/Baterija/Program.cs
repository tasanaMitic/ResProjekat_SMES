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

            ChannelFactory<IBaterija> factory = new ChannelFactory<IBaterija>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:4003/IBaterija"));
            _proxy = factory.CreateChannel();
            
        }
    }
}
