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
            return DateTime.Now.ToString("h-mm-ss.fff");
        }

        public static string GetDate()
        {
            return DateTime.Now.ToString("dd.MM.yyyy");
        }

        public static string GetTimeMinimal()
        {
            return DateTime.Now.ToString("h-mm-ss");
        }
    }

    
}
