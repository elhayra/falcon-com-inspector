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

using Renci.SshNet;
using Renci.SshNet.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Falcon.Com
{
    class Ssh
    {
        public const int DEFAULT_PORT = 22;
        public const int BUFF_SIZE = 1024;
        public const int LISTEN_INTERVAL = 50; //millis

        public string UserName, Password;

        private SshClient client_;
        private ShellStream shellStream_;
        private List<Action<string>> subsFuncs_ = new List<Action<string>>();
        private byte[] bytesIn_;

        private Task listenTask_;
        private CancellationTokenSource cts_;

        public Ssh()
        {
            
        }

        public bool Connect(string hostAddr, string username, string password, ref string reply)
        {
            return Connect(hostAddr, username, password, DEFAULT_PORT, ref reply);
        }

        public bool Connect(string hostAddr, string username, string password, int port, ref string reply)
        {
            try
            {
                bytesIn_ = new byte[BUFF_SIZE];
                UserName = username;
                Password = password;
                var PasswordConnection = new PasswordAuthenticationMethod(username, password);
                var KeyboardInteractive = new KeyboardInteractiveAuthenticationMethod(username);
                KeyboardInteractive.AuthenticationPrompt += new EventHandler<AuthenticationPromptEventArgs>(HandleKeyEvent);
                var ConnectionInfo = new ConnectionInfo(hostAddr, port, username, PasswordConnection, KeyboardInteractive);
                client_ = new SshClient(ConnectionInfo);
                client_.Connect();
                return true;
            }
            catch (Exception exp)
            {
                reply = exp.Message;
                return false;
            }
            
        }

        public void CreateShellStream(string terminalName, uint cols, uint rows, uint width, uint height, int buffSize)
        {
            shellStream_ = client_.CreateShellStream(terminalName, cols, rows, width, height, buffSize);
            cts_ = new CancellationTokenSource();
            listenTask_ = new Task(() => Listen(cts_.Token), cts_.Token);
            listenTask_.Start();
        }

        private void Listen(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                Thread.Sleep(LISTEN_INTERVAL);
                if (shellStream_.DataAvailable)
                {
                    string result = "";
                    result = shellStream_.Read();
                    if (result != "")
                        SendBytesToSubscribers(result);
                }
            }
        }

        private void SendBytesToSubscribers(string msg)
        {
            foreach (var func in subsFuncs_)
                func(msg);
        }

        public void Subscribe(Action<string> func)
        {
            subsFuncs_.Add(func);
        }

        public void Unsubscribe(Action<string> func)
        {
            subsFuncs_.Remove(func);
        }

        public void RunCommand(string command)
        {
            shellStream_.WriteLine(command);
            if (command == "exit")
                cts_.Cancel();
        }

        void HandleKeyEvent(Object sender, AuthenticationPromptEventArgs e)
        {
            foreach (AuthenticationPrompt prompt in e.Prompts)
            {
                if (prompt.Request.IndexOf("Password:", StringComparison.InvariantCultureIgnoreCase) != -1)
                {
                    prompt.Response = Password;
                }
            }
        }


    }
}
