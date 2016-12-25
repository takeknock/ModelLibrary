using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.DigitalOption
{
    class AssetDigital : IDigitalOption
    {
        public double payoff(double spot, double strike)
        {
            if (spot > strike)
                return spot;

            return 0.0;
        }
    }
}
