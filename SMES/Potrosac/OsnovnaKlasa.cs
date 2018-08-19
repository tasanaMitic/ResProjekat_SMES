using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potrosac
{
    public class OsnovnaKlasa
    {
        public int Ime { get; private set; }
        public double Potrosnja { get; set; }
        public bool Upaljen { get; set; }

        public OsnovnaKlasa()
        {
            Upaljen = false;
            Ime = GetHashCode();                 
        }

        public string PreuzmiStanjePotrosaca
        {
            get
            {
                return Upaljen ? "Upaljen" : "Ugasen";
            }
        }
    }
}
