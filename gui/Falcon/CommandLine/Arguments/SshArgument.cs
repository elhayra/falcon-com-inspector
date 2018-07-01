using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.CommandLine.Arguments
{
    class SshArgument : Argument
    {
        public const int USERNAME_INDX = 0;
        public const int HOSTADDR_INDX = 1;
        public const int PASS_INDX = 2;

        public const int NUM_OF_ARGS = 3;

        private string userName,
                      hostAddress,
                      password;

        public SshArgument(string args) : base(args)
        {

        }

        public override void ExtractArguments(string args)
        {
            isValid = true;
            string[] argsArr = args.Split(' ');
            if (argsArr.Length < NUM_OF_ARGS)
            {
                isValid = false;
                return;
            }
            userName = argsArr[USERNAME_INDX];
            try
            {
                hostAddress = argsArr[HOSTADDR_INDX];
                password = argsArr[PASS_INDX];
            }
            catch
            {
                isValid = false;
            }
        }

        public string GetUserName() { return userName;  }
        public string GetHostAddress() { return hostAddress; }
        public string GetPassword() { return password; }
    }
}
