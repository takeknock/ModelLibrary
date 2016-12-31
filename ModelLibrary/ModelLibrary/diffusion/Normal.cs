using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract;
using Utility;

namespace ModelLibrary.diffusion
{
    class Normal
    {
        public double evaluate(SpreadOption spreadOption, double interestRate, double volatility, double underlying)
        {
            double discountFactor = getDiscountFactor(interestRate, spreadOption._maturity);
            NormalDisribution n = new NormalDisribution();
            double d = (underlying - spreadOption._strike) / (volatility * spreadOption._maturity);
            double diffusionProbDensity =
                n.getStandardNormalDistributionProbabilityDensity(d);

            double price = discountFactor * (volatility * Math.Sqrt(spreadOption._maturity) 
                    * diffusionProbDensity + (underlying - spreadOption._strike) * n.normalDistribution(d));
            return price;
        }

        private double getDiscountFactor(double interestRate, double maturity)
        {
            // assume interest rate is constant
            return Math.Exp(-interestRate * maturity);
        }
    }
}
