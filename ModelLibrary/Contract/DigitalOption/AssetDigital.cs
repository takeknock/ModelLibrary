using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.DigitalOption
{
    public class AssetDigital : IDigitalOption
    {
        public decimal _strike { get; private set; }
        public decimal _maturity { get; private set; }

        public AssetDigital(decimal strike, decimal maturity)
        {
            _strike = strike;
            _maturity = maturity;
        }

        public decimal payoff(decimal spot)
        {
            if (spot > _strike)
                return spot;

            return 0.0;
        }
    }
}
