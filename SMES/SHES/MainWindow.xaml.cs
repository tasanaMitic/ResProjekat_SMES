using Common;
using SHES.Serveri;
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
        public static Sat Sat = new Sat();
        public static SHESInfo Info = new SHESInfo();
        public MainWindow()
        {
            InitializeComponent();

            PotrosacServer potrosacServer = new PotrosacServer();
            PanelServer panelServer = new PanelServer();
            potrosacServer.Open();
            panelServer.Open();

            BindPropertyToUIElement(Sat, Sati, TextBlock.TextProperty, "Sati");
            BindPropertyToUIElement(Sat, Minuta, TextBlock.TextProperty, "Minuta");
            BindPropertyToUIElement(Info, Potrosnja, TextBlock.TextProperty, "PotrosnjaPotrosaca");
            BindPropertyToUIElement(Info, Snaga, TextBlock.TextProperty, "SnagaPanela");
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
    }
}
