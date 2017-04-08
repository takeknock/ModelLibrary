using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Portfolio
{
    class EfficientFrontier
    {

        public double weightA { get; private set; }
        public double weightB { get; private set; }
        private Asset a;
        private Asset b;
        public double volatility { get; private set; }
        public double correlation { get; private set; }
        public double covariance { get; private set; }
        private double tolerance = 10E-9;

        // 2 asset case
        public EfficientFrontier(Asset a, Asset b, double weightA, double covariance)
        {
            this.weightA = weightA;
            this.weightB = 1.0 - weightA;
            this.a = a;
            this.b = b;
            correlation = covariance / (a.volatility * b.volatility);
            volatility = weightA * weightA * a.volatility * a.volatility
                + (1.0 - weightA) * (1.0 - weightA) * b.volatility * b.volatility
                + 2.0 * weightA * (1.0 - weightA) * a.volatility * b.volatility * correlation;
        }
        public void chanveWeight(double weightA)
        {
            this.weightA = weightA;
            weightB = 1.0 - weightA;
            volatility = calculatePortfolioVolatility(weightA, a, b);
        }

        private double calculatePortfolioVolatility(double weightA, Asset a, Asset b)
        {
            return weightA * weightA * a.volatility * a.volatility
                + (1.0 - weightA) * (1.0 - weightA) * b.volatility * b.volatility
                + 2.0 * weightA * (1.0 - weightA) * a.volatility * b.volatility * correlation;
                
        }

    }
}
