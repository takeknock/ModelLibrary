using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootFinding
{
    public class Bisect : IRootFinder
    {
        private readonly double _initial;
        private readonly Func<double> _f;
        private readonly double _epsilon;

        public double Answer { get; private set; }

        public Bisect(Func<double> targetFunction, double initial, double epsilon = 1E-10)
        {
            _f = targetFunction;
        }

        public void solve()
        {
        }




    }
}
