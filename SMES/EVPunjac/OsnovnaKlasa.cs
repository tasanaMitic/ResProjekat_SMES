using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVPunjac
{
    public class OsnovnaKlasa
    {
        public bool NaPunjacu { get; set; }
        public int Napunjen { get; set; }

        public OsnovnaKlasa()
        {
            NaPunjacu = false;
        }

        public string PreuzmiStanjePunjaca
        {
            get
            {
                return NaPunjacu ? "Prikljucen na punjac" : "Nije prikljucen na punjac";
            }
        }
    }
}
