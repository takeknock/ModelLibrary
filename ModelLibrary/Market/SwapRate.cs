using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market
{
    public class SwapRate
    {

        public double quote;
        

        public SwapRate(double swapValue)
        {
            quote = swapValue;
        }

        public decimal? ToDecimal()
        {
            if (quote == 0.0)
                return null;

            return (decimal)quote;
        }
    }
}
