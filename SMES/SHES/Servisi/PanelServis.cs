﻿using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES.Servisi
{
    public class PanelServis : IPanel
    {
        public void PosaljiEnergiju(double kolicinaEnergije)
        {
            MainWindow.Info.SnagaPanela = kolicinaEnergije;
        }
    }
}