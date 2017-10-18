using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

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
                    answer = "reset done";
                    return true;

                case "reset":
                    type = Type.RESET;
                    answer = "clear done";
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
                        answer = "Ping to " + rawArgs + " [" + reply.Address.ToString() + "] Successful.\n"
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
