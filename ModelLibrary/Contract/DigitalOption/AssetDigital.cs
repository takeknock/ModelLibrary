using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.DigitalOption
{
    public class AssetDigital : IDigitalOption
    {
        public double _strike { get; private set; }
        public double _maturity { get; private set; }

        public AssetDigital(double strike, double maturity)
        {
            _strike = strike;
            _maturity = maturity;
        }

        public double payoff(double spot)
        {
            if (spot > _strike)
                return spot;

            return 0.0;
        }
    }
}
