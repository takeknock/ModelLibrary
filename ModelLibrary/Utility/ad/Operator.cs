using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.ad
{
    class Operator : IAutomaticDifferenciation
    {
        private string op = "";

        Operator(string op)
        {
            this.op = op;
        }

        public IAutomaticDifferenciation Eval(IAutomaticDifferenciation x, IAutomaticDifferenciation y)
        {
            if (op.Equals(""))
                throw new InvalidOperationException("No operator is set.");

            // TODO: how do i add operators in the structure?
            //if (op.Equals("+"))
            //    return x + y;
            //else if (op.Equals("-"))
            //    return x - y;
            //else if (op.Equals("*"))
            //    return x * y;
            //else if (op.Equals("/"))
            //    return x / y;

            return null;
        }

    }
}
