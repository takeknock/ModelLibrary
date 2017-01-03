using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Utility
{
    public class Log
    {
        private static ILog logger;

        public static ILog getLogger()
        {
            if (logger == null)
                logger = LogManager.GetLogger(@"TestLogger");

            return logger;

        }
    }
}
