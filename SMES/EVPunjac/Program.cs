using Common;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EVPunjac
{
    class Program
    {
        private static IEVPunjac _proxy;
        private static OsnovnaKlasa evpunjac = new OsnovnaKlasa();
        private static RezimRadaBaterije rezimRadaBaterije;
        private static string key1;
        static void Main(string[] args)
        {
            ChannelFactory<IEVPunjac> factory = new ChannelFactory<IEVPunjac>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:4004/IEVPunjac"));
            _proxy = factory.CreateChannel();             
          
            Thread t = new Thread(new ThreadStart(MetodaPunjaca));

            Console.WriteLine("Unesite vrednost u procentima, koliko je automobil trenutno napunjen: ");
            int temp;
            while (!Int32.TryParse(Console.ReadLine(), out temp)) ;
            if (temp >= 0 || temp <= 100)
            {
                evpunjac.Napunjen = temp;
            }
            else
            {
                Console.WriteLine("Vrednost moze da bude u rasponu 0-100.");
            }

            t.IsBackground = true;
            t.Start();

            while (true)
            {
                Console.WriteLine($"Trenutno stanje automobila je: {evpunjac.PreuzmiStanjePunjaca}, a napunjen je {evpunjac.Napunjen}%.");
                Console.WriteLine("Pritisnite P da prikljucite automobil na punjac ili N da ga ne prikljucite.");
                String key = Console.ReadLine();
                if (key == "P")
                {
                    evpunjac.NaPunjacu = true;
                }
                else if (key == "N")
                {
                    evpunjac.NaPunjacu = false;
                }
                Console.WriteLine("Pritisnite D ako zelite punjenje automobila ili N ako ne zelite.");
                key1 = Console.ReadLine();
            }
            Console.ReadLine();
        }

        private static void MetodaPunjaca()
        {
            while (true)
            {              
                
                if (key1 == "D")
                {
                    if (evpunjac.NaPunjacu.Equals(true) && evpunjac.Napunjen < 100)
                    {
                        _proxy.PreuzmiEnergiju();
                        evpunjac.Napunjen += 1; //odrediti koliki procenat iznosi energija kojom se automobil puni
                    }
                }
                else if (key1 == "N")
                {
                    rezimRadaBaterije =  _proxy.PreuzmiRezimRadaBaterije();

                    if(evpunjac.NaPunjacu.Equals(true) && rezimRadaBaterije.Equals(RezimRadaBaterije.PUNJENJE) && evpunjac.Napunjen < 100)
                    {
                        _proxy.PreuzmiEnergiju();
                        evpunjac.Napunjen += 1; //odrediti koliki procenat iznosi energija kojom se automobil puni
                    }
                }

                Thread.Sleep(1000);
            }
        }
    }
}
