using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potrosac
{
    public class OsnovnaKlasa
    {
        private int ime;
        private double potrosnja;
        private bool upaljen;

        public int Ime { get => ime; set => ime = value; }
        public double Potrosnja { get => potrosnja; set => potrosnja = value; }
        public bool Upaljen { get => upaljen; set => upaljen = value; }

        public OsnovnaKlasa()
        {
            Random rnd = new Random();

            Upaljen = true;
            Ime = GetHashCode();
            Potrosnja = (double)rnd.Next(0, 50);           
        }
    }
}
