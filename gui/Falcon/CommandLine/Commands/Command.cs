using Falcon.CommandLine.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.CommandLine.Commands
{
    public abstract class Command
    {
        public enum Type
        {
            INVALID,
            CLEAR,
            PING,
            SSH,
            HELP
        }

        protected Argument argument;
        protected string rawArgs;

        public bool IsValidArgument()
        {
            return argument.IsValid();
        }

        public string GetRawArgs()
        {
            return rawArgs;
        }

        public Argument GetArgumentObject()
        {
            return argument;
        }

        public static bool IsFalconCommand(string command)
        {
            if (command == "ssh" ||
                command == "ping" || 
                command == "help" ||
                command == "clear")
            {
                return true;
            }
            return false;
        }

        public abstract void InitArgument(string args);
        public abstract string GetHelpMsg();
        public abstract string GetSuccessMsg();
        public abstract string GetInvalidArgumentMsg();
        public abstract string GetNoArgumentMsg();
        public abstract Type GetCommandType();
        
        
    }
}
