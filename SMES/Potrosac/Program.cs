using Common;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Potrosac
{
    class Program
    {
        private static IPotrosac _proxy;
        private static OsnovnaKlasa potrosac = new OsnovnaKlasa();
        private static Object _lockObject = new object();
        static void Main(string[] args)
        {

            Console.WriteLine($"Potrosnja potrosaca je: {potrosac.Potrosnja}kWH.");

            ChannelFactory<IPotrosac> factory = new ChannelFactory<IPotrosac>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:4000/IPotrosac"));
            _proxy = factory.CreateChannel();
            Thread t = new Thread(new ThreadStart(MetodaPotrosaca));

            t.IsBackground = true;
            t.Start();
            while (true)
            {
                Console.WriteLine($"Trenutno stanje potrosaca je: {potrosac.PreuzmiStanjePotrosaca}. Pritisnite P za promenu stanja ili E za izlaz iz programa.");

                String key = Console.ReadLine();
                if (key == "P")
                {
                    potrosac.Upaljen = !potrosac.Upaljen;
                }
                else if (key == "E")
                {
                    potrosac.Upaljen = false;
                    break;
                }
                

                //Console.Clear();
            }
            Console.WriteLine("Program se zavrsava...");            
            Console.ReadLine();
        }

        private static void MetodaPotrosaca ()
        {
            while (true)
            {
                if (potrosac.Upaljen == true)
                {
                    _proxy.PosaljiPotrosnju(potrosac.Potrosnja / 60); //posto se simulira slanje na svaki minut
                }
                Thread.Sleep(1000);
            }
        }
    }
}
