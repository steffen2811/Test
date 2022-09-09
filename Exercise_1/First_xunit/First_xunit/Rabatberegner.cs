using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_xunit
{
    public class Rabatberegner
    {
        public double GetPrisEfterRabat(int antalVarer, double stykPris)
        {
            double bruttoPris = antalVarer * stykPris;
            double rabat = 0;

            if (bruttoPris > 1000)
                rabat += bruttoPris * 0.03; // Indkøb over 1000 kr. giver 3% rabat
            if (antalVarer > 10)
                rabat += bruttoPris * 0.02; // Flere end 10 varer giver 2% rabat

            return (bruttoPris - rabat);
        }
    }
}
