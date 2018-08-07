using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potrosac
{
    public class MetodaPotrosaca : IPotrosac
    {
        public double PreuzmiInfoOdPotrosaca()
        {
            OsnovnaKlasa potrosac = new OsnovnaKlasa();
            double potrosnja = potrosac.Potrosnja;

            return potrosnja;
        }
    }
}
