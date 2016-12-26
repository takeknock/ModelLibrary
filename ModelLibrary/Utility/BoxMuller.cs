using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class BoxMuller
    {
        private Random _random;

        public BoxMuller(int seed)
        {
            _random = new Random(seed);
        }

        public decimal next(decimal mean = 0.0, decimal volatility = 1.0)
        {

            decimal rand1 = _random.Nextdecimal();
            decimal rand2 = _random.Nextdecimal();

            decimal normDist = Math.Sqrt(-2.0 * Math.Log(rand1)) * Math.Cos(2.0 * Math.PI * rand2);
            return volatility * normDist + mean;
        }
    }
}
