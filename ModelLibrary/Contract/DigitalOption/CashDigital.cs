using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.DigitalOption
{
    public class CashDigital : IDigitalOption
    {
        private double _strike { get; set; }
        private double _paymentValue { get; set; }

        public CashDigital(double strike, double paymentValue)
        {
            _strike = strike;
            _paymentValue = paymentValue;
        }

        public double payoff(double spot)
        {
            if (spot > _strike)
                return _paymentValue;

            return 0.0;
        }
    }
}
