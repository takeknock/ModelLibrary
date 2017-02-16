using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{

    class DualNumber
    {
        public double a { get; private set; }
        public double b { get; private set; }
        private Type this_type = typeof(DualNumber);

        public DualNumber(double  a, double b)
        {
            this.a = a;
            this.b = b;
        }
        

        //static public DualNumber operator +=(DualNumber rhs)
        //{
        //    double next = rhs.a;
        //    return new DualNumber();
        //}

        static public DualNumber operator +(DualNumber x, DualNumber y)
        {
            return new DualNumber(x.a + y.a, x.b + y.b);
        }

        static public DualNumber operator -(DualNumber x, DualNumber y)
        {
            return new DualNumber(x.a - y.a, x.b - y.b);
        }
    }
}
