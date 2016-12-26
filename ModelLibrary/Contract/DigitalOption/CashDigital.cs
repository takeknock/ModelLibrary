using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.DigitalOption
{
    public class CashDigital : IDigitalOption
    {
        public decimal _strike { get; private set; }
        public decimal _paymentValue { get; private set; }
        public decimal _maturity{ get; private set; }

        public CashDigital(decimal strike, decimal maturity, decimal paymentValue)
        {
            _strike = strike;
            _maturity = maturity;
            _paymentValue = paymentValue;
        }

        public decimal payoff(decimal spot)
        {
            if (spot > _strike)
                return _paymentValue;

            return 0.0;
        }
    }
}
