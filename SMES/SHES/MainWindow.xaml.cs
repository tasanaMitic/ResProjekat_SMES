﻿using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace SHES
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ChannelFactory<IPotrosac> factory = new ChannelFactory<IPotrosac>(
                                                            new NetTcpBinding(),
                                                            new EndpointAddress("net.tcp://localhost:4000/IPotrosac"));

            IPotrosac proxyPotrosac = factory.CreateChannel();
            double potrosnjaPotrosaca = proxyPotrosac.PreuzmiInfoOdPotrosaca();

           /* using (XmlWriter writer = XmlWriter.Create("UPIS.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Potrosnja");

                
                    writer.WriteStartElement("potrosnjaPotrosaca");

                    writer.WriteElementString("potrosac", potrosnjaPotrosaca.ToString());

                    writer.WriteEndElement();
                

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }*/

        }
    }
}
