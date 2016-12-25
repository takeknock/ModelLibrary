using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.DigitalOption
{
    public class CashDigital : IDigitalOption
    {
        public double _strike { get; private set; }
        public double _paymentValue { get; private set; }
        public double _maturity{ get; private set; }

        public CashDigital(double strike, double maturity, double paymentValue)
        {
            _strike = strike;
            _maturity = maturity;
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
