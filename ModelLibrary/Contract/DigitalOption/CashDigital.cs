using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.DigitalOption
{
    public class CashDigital : IDigitalOption
    {
        public double payoff(double strike, double spot)
        {
            if (spot > strike)
            {
                return spot;
            }

            return 0.0;
        }
    }
}
