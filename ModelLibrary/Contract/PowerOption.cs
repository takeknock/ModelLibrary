﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public class PowerOption
    {
        private double _strike;
        private double _maturity;
        private double _exponent;
        private bool _isCall;

        public PowerOption(double strike, double exponent, double maturity, bool isCall)
        {
            _strike = strike;
            _maturity = maturity;
            _exponent = exponent;
            _isCall = isCall;
        }
        public double payoff(double spot)
        {
            if (_isCall)
                return Math.Max(Math.Pow(spot, _exponent) - Math.Pow(_strike, _exponent), 0);

            return Math.Max(Math.Pow(_strike, _exponent) - Math.Pow(spot, _exponent), 0);
        }
    }
}
