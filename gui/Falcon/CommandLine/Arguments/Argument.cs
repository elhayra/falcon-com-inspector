using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.CommandLine.Arguments
{
    public abstract class Argument
    {
        protected bool isValid;
     
        public abstract void ExtractArguments(string args);

        public Argument(string args)
        {
            ExtractArguments(args);
        }

        public bool IsValid()
        {
            return isValid;
        }
    }
}
