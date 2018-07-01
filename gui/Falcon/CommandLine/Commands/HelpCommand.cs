using Falcon.CommandLine.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.CommandLine.Commands
{
    class HelpCommand : Command
    {
        public override Type GetCommandType()
        {
            return Type.HELP;
        }

        public override string GetHelpMsg()
        {
            return "help command enables you to get a short explanation \n" +
                "of a chosen command, and instructions on how it is executed. \n" +
                "help command takes as an argument other command you wish to get \n" +
                "help for, in the following structure: help <other command>. for \n" +
                "example: help ping.";
        }

        public override string GetInvalidArgumentMsg()
        {
            return GetRawArgs() + " is invalid argument, because it is not a falcon command";
        }

        public override string GetNoArgumentMsg()
        {
            return "help command must have an argument";
        }

        public override string GetSuccessMsg()
        {
            return "Got help command";
        }

        public override void InitArgument(string args)
        {
            rawArgs = args;
            argument = new HelpArgument(args);
        }
    }
}
