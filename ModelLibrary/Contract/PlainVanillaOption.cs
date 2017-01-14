using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public class PlainVanillaOption
    {
        public double _strike { get; private set; }
        public double _maturity { get; private set; }
        public bool _isCall { get; private set; }

        public PlainVanillaOption(double strike, double maturity, bool isCall)
        {
            _strike = strike;
            _maturity = maturity;
            _isCall = isCall;
        }


    }
}
