using Common;
using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
            InitializeComponent();
            
            ServiceHost host = new ServiceHost(typeof(SHESMetode));
            host.AddServiceEndpoint(typeof(ISHES), new NetTcpBinding(), new Uri("net.tcp://localhost:4000/ISHES"));
            host.Open();


            Sat s = new Sat();
            Binding satBin = new Binding();
            satBin.Source = s;
            satBin.Path = new PropertyPath("Sati");
            satBin.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            Binding minBin = new Binding();
            minBin.Source = s;
            minBin.Path = new PropertyPath("Minuta");
            minBin.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(Sati, TextBlock.TextProperty, satBin);
            BindingOperations.SetBinding(Minuta, TextBlock.TextProperty, minBin);
            s.PokreniSat();

        }
    }
}
