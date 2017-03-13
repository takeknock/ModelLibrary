using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Portfolio
{
    class Asset
    {
        public double volatility { get; private set; }
        public double earningRatio { get; private set; }
        public double expectedEarningRatio { get; private set; }
        public Asset(double volatility, double earningRatio, double expectedEarningRatio)
        {
            this.volatility = volatility;
            this.earningRatio = earningRatio;
            this.expectedEarningRatio = expectedEarningRatio;
        }
    }
}
