using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.CommandLine.Arguments
{
    class AutoScrollArgument : Argument
    {
        public const int FLAG_INDX = 0;

        private string flag;

        public AutoScrollArgument(string args) : base(args)
        {
            
        }

        public override void ExtractArguments(string args)
        {
            isValid = true;
            flag = args;
            if (flag != "on" && flag != "off")
                isValid = false;
        }

        public bool IsAutoScroll()
        {
            return (flag == "on" ? true : false);
        }


    }
}
