using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market
{
    public class SwapRate
    {
        public double value;

        public SwapRate(double swapValue)
        {
            value = swapValue;
        }

        public decimal? ToDecimal()
        {
            if (value == 0.0)
                return null;

            return (decimal)value;
        }
    }
}
