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

        public int Minuta
        {
            get { return _minuta; }
            private set { _minuta = value; OnPropertyChanged("Minuta"); }
        }

        private int _dan = DateTime.Now.Day;

        public int Dan
        {
            get { return _dan; }
            set { _dan = value; OnPropertyChanged("Dan"); }
        }

        private int _mesec = DateTime.Now.Month;

        public int Mesec
        {
            get { return _mesec; }
            set { _mesec = value; OnPropertyChanged("Mesec"); }
        }

        private int _godina = DateTime.Now.Year;

        public int Godina
        {
            get { return _godina; }
            set { _godina = value; OnPropertyChanged("Godina"); }
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
                        if (Dan == 31)
                        {
                            Dan = 1;
                            if (Mesec == 12)
                            {
                                Mesec = 1;
                                Godina++;
                            }
                            else
                            {
                                Mesec++;
                            }
                            
                        }
                        else
                        {
                            Dan++;
                        }
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

                await Task.Delay(100);
            }
        }
    }
}
