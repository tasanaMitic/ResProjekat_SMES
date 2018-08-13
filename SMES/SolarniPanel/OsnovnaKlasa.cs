﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarniPanel
{
    public class OsnovnaKlasa
    {
        public int Ime { get; private set; }
        public double MaksimalnaSnaga { get; private set; }
        public double JacinaSunca { get; set; }

        public OsnovnaKlasa()
        {
            Random rnd = new Random();

            Ime = GetHashCode();
            MaksimalnaSnaga = (double)rnd.Next(0, 100); //W
            JacinaSunca = 0;
        }

        public double PreuzmiTrenutnuSnaguPanela()
        {
            return MaksimalnaSnaga * (JacinaSunca / 100);
        }
    }
}