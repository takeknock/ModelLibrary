using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.DigitalOption
{
    public interface IDigitalOption
    {
        double payoff(double spot);

    }
}
