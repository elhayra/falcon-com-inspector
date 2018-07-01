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
using Falcon.CommandLine.Commands;
using Falcon.Forms;
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

        /// <summary>
        /// Handle Falcom commands. Determine if command is valid, 
        /// what is the type of it, and execute (if valid).
        /// </summary>
        /// <param name="input">Falcon command (including cmd char)</param>
        /// <param name="output">Execution result</param>
        /// <returns>Is command valid, Command message, Command Type, On or Off flag</returns>
        public static bool Parse(string cmd, ref string message, ref Command.Type type, ref Argument argumentObj)
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

            bool noArgument = (rawArgs == null) ? true : false;

            SshCommand sshCmd = new SshCommand();
            PingCommand pingCmd = new PingCommand();
            ClearCommand clearCmd = new ClearCommand();
            HelpCommand helpCmd = new HelpCommand();
            InvalidCommand invalidCmd = new InvalidCommand();

            // return values to caller according to cmd name
            switch (cmdName)
            {
                case "ssh":
                    SshForm sshForm = new SshForm();
                    sshForm.Show();
                    sshForm.Focus();


                    //TODO: GET FORM SSH CREDENTIALS HERE WITH SshCredential Object///////////////////////////////////////////////////////////////

                    if (noArgument)
                    {
                        message = sshCmd.GetNoArgumentMsg();
                        return false;
                    }

                    sshCmd.InitArgument(rawArgs);
                    type = sshCmd.GetCommandType();

                    if (!sshCmd.IsValidArgument())
                    {
                        message = sshCmd.GetInvalidArgumentMsg();
                        return false;
                    }
                    argumentObj = sshCmd.GetArgumentObject();
                    return true;

                case "ping":
                    
                    if (noArgument)
                    {
                        message = pingCmd.GetNoArgumentMsg();
                        return false;
                    }

                    pingCmd.InitArgument(rawArgs);
                    type = pingCmd.GetCommandType();

                    argumentObj = pingCmd.GetArgumentObject();
                    message = pingCmd.GetSuccessMsg();
                    return true;

                case "clear":
                    type = clearCmd.GetCommandType();
                    message = clearCmd.GetSuccessMsg();
                    return true;
                    
                case "help":
                    if (noArgument)
                    {
                        message = helpCmd.GetNoArgumentMsg();
                        return false;
                    }
                    helpCmd.InitArgument(rawArgs);
                    if (!helpCmd.IsValidArgument())
                    {
                        message = helpCmd.GetInvalidArgumentMsg();
                        return false;
                    }

                    switch (rawArgs)
                    {
                        case "ssh":
                            message = sshCmd.GetHelpMsg();
                            break;

                        case "ping":
                            message = pingCmd.GetHelpMsg();
                            break;

                        case "clear":
                            message = clearCmd.GetHelpMsg();
                            break;

                        case "help":
                            message = helpCmd.GetHelpMsg();
                            break;
                    }
                    break;

                default:
                    {
                        type = invalidCmd.GetCommandType();
                        message = invalidCmd.GetInvalidArgumentMsg();
                        break;
                    }
            }
            return false;
        }

        //TODO: catch errors

    }
}
