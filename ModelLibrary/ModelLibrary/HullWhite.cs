using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    class HullWhite
    {
        public double reversionRate
        {
            get { return _theta * _a; }
        }
        private double _theta;
        private double _a;
        private double _shortRateVol;
        private double calculateVolatility(double tau)
        {
            return _shortRateVol / _a * (1.0 - Math.Exp(-_a * tau));
        }
    }
}
