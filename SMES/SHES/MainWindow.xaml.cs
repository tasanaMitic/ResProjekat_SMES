using Common;
using SHES.Serveri;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private static BackgroundWorker backgroundWorker = new BackgroundWorker(); //ovo ce trebati za tred koji unosi u xml
        public static Sat Sat = new Sat();
        public static SHESInfo Info = new SHESInfo();
        private ObservableCollection<String> _listaDatuma = new ObservableCollection<string>();

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string parameter)
        {

            PropertyChangedEventHandler ph = PropertyChanged;
            if (ph != null)
            {
                ph(this, new PropertyChangedEventArgs(parameter));
            }

        }

        private Double _cena;

        public Double Cena
        {
            get { return _cena; }
            set { _cena = value;  OnPropertyChanged("Cena"); }
        }


        //public event NotifyCollectionChangedEventHandler CollectionChanged;

        public ObservableCollection<String> ListaDatuma
        {
            get { return _listaDatuma; }
            set { _listaDatuma = value; }
        }

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
            DataContext = this;

            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.RunWorkerAsync();

            BindPropertyToUIElement(Sat, Sati, TextBlock.TextProperty, "Sati");
            BindPropertyToUIElement(Sat, Minuta, TextBlock.TextProperty, "Minuta");
            

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
                        DateTime datum = new DateTime(Sat.Datum.Year, Sat.Datum.Month, Sat.Datum.Day).AddDays(-1);
                        XMLWorker.Instance().UnesiCenu(Info.UvozElektrodistribucije, datum);
                        Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Background, new Action(() =>
                        ListaDatuma.Add($"{datum.Day}.{datum.Month}.{datum.Year}")));
                        
                        Info.UvozElektrodistribucije = 0;
                    }
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Dictionary<string, double>> unosiZaDatum = XMLWorker.Instance().PreuzmiInfoZaDatum(IzborDatuma.SelectedValue.ToString());
            ((LineSeries)chart.Series[0]).ItemsSource = unosiZaDatum[0];
            ((LineSeries)chart.Series[1]).ItemsSource = unosiZaDatum[1];
            ((LineSeries)chart.Series[2]).ItemsSource = unosiZaDatum[2];
            ((LineSeries)chart.Series[3]).ItemsSource = unosiZaDatum[3];
            Cena = XMLWorker.Instance().PreuzmiCenuZaDatun(IzborDatuma.SelectedValue.ToString());
        }
    }
}
