using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract;
using Utility;

namespace ModelLibrary
{
    class HullWhite
    {
        public double reversionRate
        {
            get { return _theta * _a; }
        }
        private double _theta;
        private double _a;
        private double _shortRateVol;
        private double calculateVolatility(double tau)
        {
            return _shortRateVol / _a * (1.0 - Math.Exp(-_a * tau));
        }

        public double calculatePrice(
            PlainVanillaOption contract, double interestRate, double volatility)
        {
            double tau = contract._maturity;
            double discountFactor = calculateDiscountFactor(interestRate, tau);
            NormalDisribution n = new NormalDisribution();
            double dayCountFraction = tau;
            double discountFactorNext = 0.9; // FIX ME
            double d = (((Math.Log(1.0 + contract._strike * dayCountFraction) * discountFactorNext)/discountFactor) + volatility * volatility * 0.5) / volatility;
            return 0.0;
            
        }

        private double calculateDiscountFactor(double interestRate, double tau)
        {
            return Math.Exp(-interestRate * tau);

        }

    }
}
