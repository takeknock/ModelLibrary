using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market
{
    public class Tenor
    {
        public string _tenor
        {
            get;
            private set;
        }

        Tenor(string tenor)
        {
            _tenor = tenor;
        }

        public bool Equals(Tenor rhs)
        {
            return _tenor.Equals(rhs._tenor);
        }

    }
}
