using Common;
using SHES.Serveri;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
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
        private static BackgroundWorker backgroundWorker = new BackgroundWorker(); //ovo ce trebati za tred koji unosi u xml
        public static Sat Sat = new Sat();
        public static SHESInfo Info = new SHESInfo();
        public MainWindow()
        {
            InitializeComponent();

            PotrosacServer potrosacServer = new PotrosacServer();
            PanelServer panelServer = new PanelServer();
            ElektrodistribucijaServer elektrodistribucijaServer = new ElektrodistribucijaServer();
            BaterijaServer baterijaServer = new BaterijaServer();
            EVPunjacServer eVPunjacServer = new EVPunjacServer();
            potrosacServer.Open();
            panelServer.Open();
            elektrodistribucijaServer.Open();
            baterijaServer.Open();
            eVPunjacServer.Open();

            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.RunWorkerAsync();

            BindPropertyToUIElement(Sat, Sati, TextBlock.TextProperty, "Sati");
            BindPropertyToUIElement(Sat, Minuta, TextBlock.TextProperty, "Minuta");
            //BindPropertyToUIElement(Info, Potrosnja, TextBlock.TextProperty, "PotrosnjaPotrosaca");
            //BindPropertyToUIElement(Info, Snaga, TextBlock.TextProperty, "SnagaPanela");
            //BindPropertyToUIElement(Info, Cena, TextBlock.TextProperty, "UvozElektrodistribucije");
            //BindPropertyToUIElement(Info, VisakEnergije, TextBlock.TextProperty, "VisakEnergije");
            
            Sat.PokreniSat();
            
        }

        private void BindPropertyToUIElement(Object source, DependencyObject target, DependencyProperty dp, String nameOfProperty)
        {
            Binding binding = new Binding();
            binding.Source = source;
            binding.Path = new PropertyPath(nameOfProperty);
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(target, dp, binding);
        }

        private void backgroundWorker_DoWork (object sender, DoWorkEventArgs e)
        {
            int poslednjiUnos = Sat.Sati - 1;
            while (true)
            {
                
                if (Sat.Minuta == 0 && Sat.Sati != poslednjiUnos)
                {
                    XMLWorker.Instance().UnesiUXML(Info.PotrosnjaPotrosaca, Info.SnagaIzElektrodistribucije, Info.SnagaPanela, Info.EnergijaBaterije, new DateTime(Sat.Datum.Year, Sat.Datum.Month, Sat.Datum.Day, Sat.Sati, Sat.Minuta, 0));
                    Info.PotrosnjaPotrosaca = 0;
                    Info.SnagaIzElektrodistribucije = 0;
                    Info.SnagaPanela = 0;
                    Info.EnergijaBaterije = 0;
                    if (poslednjiUnos == 23)
                    {
                        poslednjiUnos = 0;
                    }
                    else
                    {
                        poslednjiUnos++;
                    }

                    if (Sat.Sati == 0 && Sat.Minuta == 0)
                    {
                        XMLWorker.Instance().UnesiCenu(Info.UvozElektrodistribucije, new DateTime(Sat.Datum.Year, Sat.Datum.Month, Sat.Datum.Day).AddDays(-1));
                        Info.UvozElektrodistribucije = 0;
                    }
                }
            }
        }

    }
}
