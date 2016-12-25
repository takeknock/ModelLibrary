using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.DigitalOption
{
    class AssetDigital : IDigitalOption
    {
        private double _strike { get; set; }

        public AssetDigital(double strike)
        {
            _strike = strike;
        }

        public double payoff(double spot)
        {
            if (spot > _strike)
                return spot;

            return 0.0;
        }
    }
}
