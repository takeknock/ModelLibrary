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

        public double next(double mean = 0.0, double volatility = 1.0)
        {

            double rand1 = _random.NextDouble();
            double rand2 = _random.NextDouble();

            double normalDistributedRandomness = Math.Sqrt(-2.0 * Math.Log(rand1)) * Math.Cos(2.0 * Math.PI * rand2);
            return volatility * normalDistributedRandomness + mean;
        }
    }
}
