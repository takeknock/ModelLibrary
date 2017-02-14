using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{

    class DualNumber<T>
    {
        public T _a { get; private set; }
        public T _b { get; private set; }
        private Type this_type = typeof(DualNumber<T>);

        //static public this_type operator +=(DualNumber<T> rhs)
        //{
        //    _a += rhs._a;
        //    return this;
        //}
    }
}
