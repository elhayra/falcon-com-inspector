using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.CommandLine.Commands
{
    class ClearCommand : Command
    {
        public override Type GetCommandType()
        {
            return Type.CLEAR;
        }

        public override string GetHelpMsg()
        {
            return "clear command enables you to clear the CLI screen from \n" +
                "the text currently on it. clear command takes no arguments. \n" +
                "To execute just type 'clear'";
        }

        public override string GetInvalidArgumentMsg()
        {
            throw new NotImplementedException();
        }

        public override string GetNoArgumentMsg()
        {
            throw new NotImplementedException();
        }

        public override string GetSuccessMsg()
        {
            return "Got clear command";
        }

        public override void InitArgument(string args)
        {

        }
    }
}
