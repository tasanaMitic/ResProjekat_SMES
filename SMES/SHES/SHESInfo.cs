using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES
{
    public class SHESInfo : INotifyPropertyChanged
    {
        private double _visakEnergije;
        private double _uvozElektrodistribucije;
        private double _potrosnjaPotrosaca;
        private double _snagaPanela;


        public double VisakEnergije
        {
            get { return _visakEnergije; }
            set { _visakEnergije = value; OnPropertyChanged("VisakEnergije"); }
        }
        public double UvozElektrodistribucije
        {
            get { return _uvozElektrodistribucije; }
            set { _uvozElektrodistribucije = value; OnPropertyChanged("UvozElektrodistribucije"); }
        }
        public double PotrosnjaPotrosaca
        {
            get { return _potrosnjaPotrosaca; }
            set { _potrosnjaPotrosaca = value; OnPropertyChanged("PotrosnjaPotrosaca"); }
        }

        public double SnagaPanela
        {
            get { return _snagaPanela; }
            set { _snagaPanela = value; OnPropertyChanged("SnagaPanela"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string parameter)
        {

            PropertyChangedEventHandler ph = PropertyChanged;
            if (ph != null)
            {
                ph(this, new PropertyChangedEventArgs(parameter));
            }

        }
    }
}
