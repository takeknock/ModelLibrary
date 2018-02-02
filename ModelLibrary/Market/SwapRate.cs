using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnumConst;

namespace Market
{
    public class SwapRate
    {

        private double mid;
        private Tenor tenor;

        public SwapRate(Tenor tenor, double swapValue)
        {
            Value = swapValue;
            Tenor = tenor;
        }

        public decimal? ToDecimal()
        {
            if (Value == 0.0)
                return null;

            return (decimal)Value;
        }

        public Tenor Tenor
        {
            get { return tenor; }
            private set { tenor = value; }
        }

        public double Value
        {
            get { return mid; }
            private set { mid = value; }
        }
    }
}
