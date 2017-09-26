using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.Command
{
    public static class Command
    {
        public enum Type
        {
            NONE,
            CLEAR,
            CLEAN,
            AUTO_SCROLL,
            PING,
            SSH
        }

        public static bool IsFalconCommand(string input)
        {
            if (input.First() == Properties.Settings.Default.cmdChar)
                return true;
            return false;
        }

        /// <summary>
        /// Handle Falcom commands - execute if valid 
        /// and return execution answer
        /// </summary>
        /// <param name="input">Falcon command (including cmd char)</param>
        /// <param name="output">Execution result</param>
        /// <returns></returns>
        public static Type GetCommandType(string input)
        {
            return Type.NONE; //TODO: IMPLEMENT
        }
    }
}
