using Falcon.CommandLine.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.CommandLine.Arguments
{
    public class HelpArgument : Argument
    {
        public HelpArgument(string args) : base(args)
        {
        }

        public override void ExtractArguments(string args)
        {
            if (Command.IsFalconCommand(args))
            {
                isValid = true;
            }
            else
                isValid = false;
        }


    }
}
