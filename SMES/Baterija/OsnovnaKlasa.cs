using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baterija
{
    public class OsnovnaKlasa
    {
        private double kapacitet;
        private double maksimalnaSnaga;
        private int ime;

        public double Kapacitet { get => kapacitet; set => kapacitet = value; }
        public double MaksimalnaSnaga { get => maksimalnaSnaga; set => maksimalnaSnaga = value; }
        public int Ime { get => ime; set => ime = value; }

        public OsnovnaKlasa()
        {
            Ime = GetHashCode();
            MaksimalnaSnaga = 200;
            Kapacitet = 250;
        }
    }
}
