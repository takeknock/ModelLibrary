using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.DigitalOption
{
    public class CashDigital : IDigitalOption
    {
        public double payoff(double strike, double spot, double paymentValue)
        {
            if (spot > strike)
                return paymentValue;

            return 0.0;
        }
    }
}
