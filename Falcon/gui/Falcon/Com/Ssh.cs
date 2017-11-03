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
            //AsyncListen();
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
