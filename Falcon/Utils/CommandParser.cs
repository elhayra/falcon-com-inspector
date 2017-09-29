using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.Command
{
    public static class CommandParser
    {
        private const char CMD_SPLITTER = ' ';
        private const int CMD_NAME_INDX = 0;
        private const int CMD_ARG_INDX = 1;
       

        public enum Type
        {
            NONE,
            CLEAR,
            RESET,
            AUTO_SCROLL,
            PING,
            SSH
        }

        /// <summary>
        /// Handle Falcom commands - execute if valid 
        /// and return execution answer
        /// </summary>
        /// <param name="input">Falcon command (including cmd char)</param>
        /// <param name="output">Execution result</param>
        /// <returns></returns>
        public static Type GetCommandType(string cmd)
        {
            string[] cmdArr = cmd.Split(CMD_SPLITTER);
            string cmdName = cmdArr[CMD_NAME_INDX];
            switch (cmdName)
            {
                case "clear":
                    return Type.CLEAR;
                case "clean":
                    return Type.RESET;
                case "ssh":
                    return Type.SSH;
                case "ping":
                    return Type.PING;
                case "autoscroll":
                    return Type.AUTO_SCROLL;
            }
            return Type.NONE;
        }

        public static string GetCommandArgument(string cmd)
        {
            string[] cmdArr = cmd.Split(CMD_SPLITTER);
            string arg = null;
            try
            {
                arg = cmdArr[CMD_ARG_INDX];
            }
            catch (IndexOutOfRangeException exp)
            {
                return null;
            }
            return arg;
        }

        //TODO: ENABLE HELP FLAG, AND OTHER FLAGS WITH --
        //ENABLE FLAGS WITH -
        //PROTECT FROM ERRORS

    }
}
