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

using System;
using System.Net.NetworkInformation;

namespace Falcon.Utils
{
    /// <summary>
    /// 
    /// 
    /// SSH: ssh username@hostaddress@password
    /// Ping: ping hostaddress
    /// Clear: clear
    /// Reset: reset
    /// 
    /// </summary>
    public class Argument
    {

    }

    public class SshArg : Argument
    {
        public const int USERNAME_INDX = 0;
        public const int HOSTADDR_INDX = 1;
        public const int PASS_INDX = 2;

        public string UserName,
                      HostAddress,
                      Password;
        public bool IsValid;


        public SshArg(string arg)
        {
            IsValid = true;
            string[] addrArr = arg.Split('@');
            UserName = addrArr[USERNAME_INDX];
            try
            {
                HostAddress = addrArr[HOSTADDR_INDX];
                Password = addrArr[PASS_INDX];
            }
            catch
            {
                IsValid = false;
            }
        }
    }

    public class AutoScrollArg : Argument
    {
        public const int FLAG_INDX = 0;

        public string Flag;
        public bool IsValid;

        public AutoScrollArg(string arg)
        {
            IsValid = true;
            Flag = arg;
            if (Flag != "on" && Flag != "off")
                IsValid = false;
        }
    }

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
        public static bool Parse(string cmd, ref string answer, ref Type type, ref string [] args)
        {
            /* get command name and args */
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
            bool noArgument = rawArgs == null ? true : false;

            /* return values to caller according to cmd name */
            switch (cmdName)
            {
                case "clear":
                    type = Type.CLEAR;
                    answer = "clear done";
                    return true;

                case "reset":
                    type = Type.RESET;
                    answer = "reset done";
                    return true;

                case "ssh":
                    type = Type.SSH;
                    if (noArgument)
                    {
                        answer = "ssh command must have an argument";
                        return false;
                    }
                    var sshArg = new SshArg(rawArgs);
                    if (!sshArg.IsValid)
                    {
                        answer = "ssh argument '" + rawArgs + "' is invalid";
                        return false;
                    }
                    args[SshArg.USERNAME_INDX] = sshArg.UserName;
                    args[SshArg.HOSTADDR_INDX] = sshArg.HostAddress;
                    args[SshArg.PASS_INDX] = sshArg.Password;
                    return true;

                case "ping":
                    type = Type.PING;
                    PingReply reply = null;
                    if (noArgument)
                    {
                        answer = "ping command must have an argument";
                        return false;
                    }
                    if (Ping(rawArgs, ref reply) &&
                        reply.Status == IPStatus.Success)
                    {
                        answer = "Ping to " + rawArgs + " [" + reply.Address.ToString() + "] Successful. "
                                 + "RTL: " + reply.RoundtripTime.ToString() + " ms";
                        return true;
                    }
                    answer = "Ping Failed";
                    return false;

                case "autoscroll":
                    type = Type.AUTO_SCROLL;
                    if (noArgument)
                    {
                        answer = "autoscroll command must have an argument";
                        return false;
                    }
                    var autoScrollArg = new AutoScrollArg(rawArgs);
                    if (!autoScrollArg.IsValid)
                    {
                        answer = "autoscroll argument '" + rawArgs + "' is invalid";
                        return false;
                    }
                    answer = "auto scroll is " + autoScrollArg.Flag;
                    args[AutoScrollArg.FLAG_INDX] = autoScrollArg.Flag;
                    return true;
            }
            type = Type.NONE;
            answer = "'" + cmd + "'" + " is not recognized as a Falcon command";
            return false;
        }

        private static bool Ping(string host, ref PingReply reply)
        {
            Ping pinger = new Ping();
            try
            {
                reply = pinger.Send(host); //////////////////////////////TODO: USE OTHER SEND OVERLOAD THAT ALLOW GETTING TIMEOUT AS PRARM FROM COMMAND LINE ARGUMENT
            }
            catch (PingException exp)
            {
                return false;
            }
            return true;
        }
      
        //TODO: ENABLE HELP FLAG, AND OTHER FLAGS WITH --
        //ENABLE FLAGS WITH -
        //PROTECT FROM ERRORS

    }
}
