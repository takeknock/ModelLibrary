using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.ad
{
    class Constant : IAutomaticDifferenciation
    {
        private double cnst;
        private double difference;

        Constant(double cnst)
        {
            this.cnst = cnst;
        }

        public IAutomaticDifferenciation Eval(IAutomaticDifferenciation x, IAutomaticDifferenciation y)
        {
            return this;
        }

    }
}
