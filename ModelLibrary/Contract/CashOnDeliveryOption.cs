using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public class CashOnDeliveryOption
    {
        public double _maturity { get; private set; }
        public double _strike { get; private set; }
        public double? _premium { get; private set; }

        CashOnDeliveryOption(double maturity)
        {
            _maturity = maturity;
        }
        public double payoff(double underlying)
        {
            if (_premium == null)
                throw new NullReferenceException();
            return Math.Max(underlying - _strike - (double)_premium, 0);
        }

    }
}
