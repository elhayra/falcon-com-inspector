using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.Utils
{
    class Logger
    {
        public static string GetTime()
        {
            return DateTime.Now.ToString("hh-mm-ss.fff");
        }
    }

    
}
