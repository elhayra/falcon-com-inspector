using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.CommandLine.Arguments
{
    class PingArgument : Argument
    {
        public const int IP_INDX = 0;
        public const int TIMEOUT_INDX = 1;

        public const int MIN_ARGS = 1;
        public const int MAX_ARGS = 2;

        private string ipAddress;
        private int timeout = -1;

        public PingArgument(string args) : base(args)
        {
           
        }

        public override void ExtractArguments(string args)
        {
            isValid = true;
            string[] argsArr = args.Split(' ');

            if (argsArr.Length >= MIN_ARGS && argsArr.Length <= MAX_ARGS)
                ipAddress = argsArr[IP_INDX];
            else
            {
                isValid = false;
                return;
            }

            try
            {
                if (argsArr.Length == MAX_ARGS)
                    timeout = int.Parse(argsArr[TIMEOUT_INDX]);
            }
            catch
            {
                isValid = false;
            }
        }

        public string GetIp()
        {
            return ipAddress;
        }

        /// <summary>
        /// Get Timeout
        /// </summary>
        /// <returns>-1 if no timeout argument was passed, or timeout value</returns>
        public int GetTimeout()
        {
            return timeout;
        }
    }
}
