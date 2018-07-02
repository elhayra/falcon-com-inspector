using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.CommandLine.Commands
{
    class InvalidCommand : Command
    {
        public override Type GetCommandType()
        {
            return Type.INVALID;
        }

        public override string GetHelpMsg()
        {
            throw new NotImplementedException();
        }

        public override string GetInvalidArgumentMsg()
        {
            return "'" + GetRawArgs() + "'" + " is not recognized as a Falcon command";
        }

        public override string GetNoArgumentMsg()
        {
            throw new NotImplementedException();
        }

        public override string GetSuccessMsg()
        {
            throw new NotImplementedException();
        }

        public override void InitArgument(string args)
        {
            rawArgs = args;
        }
    }
}
