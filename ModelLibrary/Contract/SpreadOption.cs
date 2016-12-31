using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    class SpreadOption
    {
        public double _strike { get; private set; }
        public double _maturity { get; private set; }
        public bool _isCall { get; private set; }

        SpreadOption(double strike, double maturity, bool isCall)
        {
            _strike = strike;
            _maturity = maturity;
            _isCall = isCall;
        }

        public double payoff(double underlying)
        {
            if (_isCall)
                return Math.Max(underlying - _strike, 0);

            return Math.Max(_strike - underlying, 0);

        }


    }
}
