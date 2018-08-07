using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Potrosac
{
    class Program
    {
        static void Main(string[] args)
        {
            string adresa = "net.tcp://localhost:4000/IPotrosac";
            ServiceHost host = new ServiceHost(typeof(MetodaPotrosaca));
            host.AddServiceEndpoint(typeof(IPotrosac),
                                    new NetTcpBinding(),
                                    new Uri(adresa));
            host.Open();

            

            Console.WriteLine("Potrosa je pokrenut.");
            Console.ReadLine();
            host.Close();
        }
    }
}
