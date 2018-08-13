using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SolarniPanel
{
    class Program
    {
        private static IPanel _proxy;
        private static OsnovnaKlasa panel = new OsnovnaKlasa();
        private static Object _lockObject = new object();
        private static double jacinaSunca = 0;
        static void Main(string[] args)
        {
            Console.WriteLine($"Maksimalna snaga solarnog panela je: {panel.MaksimalnaSnaga}W.");

            ChannelFactory<IPanel> factory = new ChannelFactory<IPanel>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:4001/IPanel"));
            _proxy = factory.CreateChannel();
            Thread t = new Thread(new ThreadStart(MetodaPanela));

            t.IsBackground = true;
            t.Start();

            while(true)
            {
                Console.WriteLine($"Trenutna snaga solarnog panela je: {panel.PreuzmiTrenutnuSnaguPanela()}W. Pritisnite P za promenu jacine suncevog zracenja ili E za izlaz iz programa.");

                String key = Console.ReadLine();
                if(key == "P")
                {
                    Console.WriteLine("Unesite zeljenu jacinu suncevog zracenja:");
                    jacinaSunca = Convert.ToDouble(Console.ReadLine());
                    if (jacinaSunca > 0 && jacinaSunca < 100)
                    {
                        panel.JacinaSunca = jacinaSunca;
                    }
                    else
                    {
                        Console.WriteLine("Jacina sunca moze da bude u rasponu 0-100.");
                    }
                }
                else if(key == "E")
                {
                    break;
                }
            }
            Console.WriteLine("Program se zavrsava...");
            Console.ReadLine();

        }

        private static void MetodaPanela()
        {
            while(true)
            {
                _proxy.PosaljiEnergiju(panel.PreuzmiTrenutnuSnaguPanela()); //simulira se slanje svake sekunde
                Thread.Sleep(100);
            }
        }
    }
}
