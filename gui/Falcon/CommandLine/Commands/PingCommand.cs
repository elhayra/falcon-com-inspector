using Falcon.CommandLine.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.CommandLine.Commands
{
    class PingCommand : Command
    {
        public override Type GetCommandType()
        {
            return Type.PING;
        }

        public override string GetHelpMsg()
        {
            return "ping command enables you to Ping other hosts. The \n" +
                "command takes as an argument host address in the following \n" +
                "structure: ping <host address>. For example: ping 10.2.1.5";
        }

        public override string GetInvalidArgumentMsg()
        {
            return "Invalid address argument";
        }

        public override string GetNoArgumentMsg()
        {
            return "Ping command must have address argument";
        }

        public override string GetSuccessMsg()
        {
            return "Got ping command";
        }

        public override void InitArgument(string args)
        {
            rawArgs = args;
            argument = new PingArgument(args);
        }
    }
}
