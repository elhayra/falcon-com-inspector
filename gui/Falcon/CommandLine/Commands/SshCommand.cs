using Falcon.CommandLine.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.CommandLine.Commands
{
    class SshCommand : Command
    {
        public override Type GetCommandType()
        {
            return Type.SSH;
        }

        public override string GetHelpMsg()
        {
            return "'ssh' command allow you to establish SSH connection to a remote pc. \n" +
                "The command itself takes no argument. However, when executed, a new SSH \n" +
                "credentials form will open, and there you need to enter user name, host \n" +
                "address and password. ";
        }

        public override string GetInvalidArgumentMsg()
        {
            return "ssh argument '" + GetRawArgs() + "' is invalid";
        }

        public override string GetNoArgumentMsg()
        {
            return "ssh command must have an argument";
        }

        public override string GetSuccessMsg()
        {
            return "Got SSH command";
        }

        public override void InitArgument(string args)
        {
            rawArgs = args;
            argument = new SshArgument(args);
        }

    }
}
