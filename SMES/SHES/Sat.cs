using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SHES
{
    public class Sat : INotifyPropertyChanged
    {
        private int _sati = 0;

        public int Sati
        {
            get { return _sati; }
            private set { _sati = value; OnPropertyChanged("Sati"); }
        }

        private int _minuta = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Minuta
        {
            get { return _minuta; }
            private set { _minuta = value; OnPropertyChanged("Minuta"); }
        }

        public void OnPropertyChanged (string parameter)
        {
            
            PropertyChangedEventHandler ph = PropertyChanged;
            if (ph != null)
            {
                ph(this, new PropertyChangedEventArgs(parameter));
            }
            
        }
        public async void PokreniSat()
        {
            while (true)
            {
                if (Minuta == 59)
                {
                    Minuta = 0;
                    if (Sati == 23)
                    {
                        Sati = 0;
                    }
                    else
                    {
                        Sati++;
                    }
                }
                else
                {
                    Minuta++;
                }

                await Task.Delay(1000);
            }
        }
    }
}
