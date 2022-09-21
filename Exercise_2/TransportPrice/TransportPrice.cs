using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportPrice
{
    public class TransportPriceClass
    {

        public double GetPrice(double weight, double distance)
        {
            if (distance < 5)
            {
                if (weight < 10)
                    return 0;
                else
                    return 50;
            }
            else // (distance >= 5)
            {
                if (weight < 10)
                    return 75;
                else
                    return 100;
            }
        }

    }
}
