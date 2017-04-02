using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.ad
{
    interface IAutomaticDifferenciation
    {

        IAutomaticDifferenciation Eval(IAutomaticDifferenciation x, IAutomaticDifferenciation y);
        

    }
}
