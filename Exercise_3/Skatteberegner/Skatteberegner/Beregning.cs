using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skatteberegner
{
    public class Beregning
    {
        // Funktionen returnerer det beløb, der skal beskattes (altså ikke selve skatten).
        public double SkatVedJulegave(double julegave, double andenGave)
        {
            double beskatning;

            if ((julegave + andenGave) > 1200)
            {
                if (julegave <= 900)
                    beskatning = andenGave;
                else
                    beskatning = julegave + andenGave;
            }
            else
                beskatning = 0;

            return beskatning;
        }
    }
}
