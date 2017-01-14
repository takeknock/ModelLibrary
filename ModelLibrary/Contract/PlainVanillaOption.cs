using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public class PlainVanillaOption
    {
        private double _strike;
        private double _maturity;
        private bool _isCall;

        PlainVanillaOption(double strike, double maturity, bool isCall)
        {
            _strike = strike;
            _maturity = maturity;
            _isCall = isCall;
        }


    }
}
