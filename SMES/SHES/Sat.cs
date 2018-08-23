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
            set { _sati = value; OnPropertyChanged("Sati"); }
        }

        private int _minuta = 0;

        public int Minuta
        {
            get { return _minuta; }
            set { _minuta = value; OnPropertyChanged("Minuta"); }
        }

        private DateTime _datum = DateTime.Now;

        public DateTime Datum
        {
            get { return _datum; }
            set { _datum = value; }
        }




        public event PropertyChangedEventHandler PropertyChanged;
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
                        Datum = Datum.AddDays(1);
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

                await Task.Delay(100);
            }
        }
    }
}
