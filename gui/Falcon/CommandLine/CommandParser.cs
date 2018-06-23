/*******************************************************************************
* Copyright (c) 2018 Elhay Rauper
* All rights reserved.
*
* Redistribution and use in source and binary forms, with or without
* modification, are permitted (subject to the limitations in the disclaimer
* below) provided that the following conditions are met:
*
*     * Redistributions of source code must retain the above copyright notice,
*     this list of conditions and the following disclaimer.
*
*     * Redistributions in binary form must reproduce the above copyright
*     notice, this list of conditions and the following disclaimer in the
*     documentation and/or other materials provided with the distribution.
*
*     * Neither the name of the copyright holder nor the names of its
*     contributors may be used to endorse or promote products derived from this
*     software without specific prior written permission.
*
* NO EXPRESS OR IMPLIED LICENSES TO ANY PARTY'S PATENT RIGHTS ARE GRANTED BY
* THIS LICENSE. THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND
* CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
* LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
* PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
* CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
* EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
* PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR
* BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER
* IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
* ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
* POSSIBILITY OF SUCH DAMAGE.
*******************************************************************************/

using Falcon.CommandLine.Arguments;
using System;
using System.Net.NetworkInformation;

namespace Falcon.CommandLine
{
    /// <summary>
    /// SSH: ssh username@hostaddress@password
    /// Ping: ping hostaddress
    /// Clear: clear
    /// Reset: reset
    /// </summary>

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
        /// Handle Falcom commands. Determine if command is valid, 
        /// what is the type of it, and execute (if valid).
        /// </summary>
        /// <param name="input">Falcon command (including cmd char)</param>
        /// <param name="output">Execution result</param>
        /// <returns>Is command valid, Command message, Command Type, On or Off flag</returns>
        public static bool Parse(string cmd, ref string message, ref Type type, ref Argument argumentObj)
        {
            // extract command name and arguments 
            string[] cmdArr = cmd.Split(CMD_SPLITTER);
            string cmdName = cmdArr[CMD_NAME_INDX];
            string rawArgs = null;
            try
            {
                rawArgs = cmdArr[CMD_ARG_INDX];
            }
            catch (IndexOutOfRangeException exp)
            {
                rawArgs = null;
            }

            bool noArgument = (rawArgs == null ? true : false);

            // return values to caller according to cmd name */
            switch (cmdName)
            {
                case "clear":
                    type = Type.CLEAR;
                    message = "got clear command";
                    return true;

                case "reset":
                    type = Type.RESET;
                    message = "got reset command";
                    return true;

                case "ssh":
                    type = Type.SSH;
                    if (noArgument)
                    {
                        message = "ssh command must have an argument";
                        return false;
                    }
                    var sshArg = new SshArgument(rawArgs);
                    if (!sshArg.IsValid())
                    {
                        message = "ssh argument '" + rawArgs + "' is invalid";
                        return false;
                    }
                    argumentObj = sshArg;
                    return true;

                case "ping":
                    type = Type.PING;
                    if (noArgument)
                    {
                        message = "ping command must have an argument";
                        return false;
                    }
                    var pingArg = new PingArgument(rawArgs);
                    argumentObj = pingArg;
                    message = "got ping command";
                    return false;

                case "autoscroll":
                    type = Type.AUTO_SCROLL;
                    if (noArgument)
                    {
                        message = "autoscroll command must have an argument";
                        return false;
                    }
                    var autoScrollArg = new AutoScrollArgument(rawArgs);
                    if (!autoScrollArg.IsValid())
                    {
                        message = "autoscroll argument '" + rawArgs + "' is invalid";
                        return false;
                    }
                    string onoffTxt = (autoScrollArg.IsAutoScroll() ? "on" : "off");
                    argumentObj = autoScrollArg;
                    message = "auto scroll is " + onoffTxt;
                    return true;
            }
            type = Type.NONE;
            message = "'" + cmd + "'" + " is not recognized as a Falcon command";
            return false;
        }

      
      
        //TODO: ENABLE HELP FLAG, AND OTHER FLAGS WITH --
        //ENABLE FLAGS WITH -
        //PROTECT FROM ERRORS

    }
}
