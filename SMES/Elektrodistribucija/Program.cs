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
            string adresa = "net.tcp://localhost:5000/IElektrodistribucija";
            ServiceHost host = new ServiceHost(typeof(MetodeElektrodistribucije));
            host.AddServiceEndpoint(typeof(IElektrodistribucija),
                                    new NetTcpBinding(),
                                    new Uri(adresa));
            host.Open();



            Console.WriteLine("Elektrodistribucija je pokrenuta.");
            Console.ReadLine();
            host.Close();
        }
    }
}
