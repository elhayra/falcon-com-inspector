using Renci.SshNet;
using Renci.SshNet.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.Com
{
    class Ssh
    {
        public const int DEFAULT_PORT = 22;
        public const int BUFF_SIZE = 1;

        public string UserName, Password;

        private PasswordAuthenticationMethod passAuth_;
        private KeyboardInteractiveAuthenticationMethod keyboardInteractive_;
        private SshClient client_;
        private ShellStream shellStream_;
        private List<Action<byte[]>> subsFuncs_ = new List<Action<byte[]>>();
        private byte[] bytesIn_;

        public Ssh()
        {
            
        }

        public bool Connect(string hostAddr, string username, string password)
        {
            return Connect(hostAddr, username, password, DEFAULT_PORT);
        }

        public bool Connect(string hostAddr, string username, string password, int port)
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
                return false;
            }
            
        }

        public void CreateShellStream(string terminalName, uint cols, uint rows, uint width, uint height, int buffSize)
        {
            shellStream_ = client_.CreateShellStream(terminalName, cols, rows, width, height, buffSize);
            AsyncListen();
        }

        private void AsyncListen()
        {
            shellStream_.BeginRead(bytesIn_, 0, bytesIn_.Length, new AsyncCallback(OnReadCB), null);
        }

        private void OnReadCB(IAsyncResult ar)
        {
            int numberOfBytesRead = shellStream_.EndRead(ar);
            if (numberOfBytesRead == 0)
                return;
            foreach (var func in subsFuncs_)
                func(bytesIn_);
            bytesIn_ = new byte[BUFF_SIZE];
            AsyncListen();
        }

        public void Subscribe(Action<byte[]> func)
        {
            subsFuncs_.Add(func);
        }

        public void Unsubscribe(Action<byte[]> func)
        {
            subsFuncs_.Remove(func);
        }

        public void RunCommand(string command)
        {
            client_.RunCommand(command);
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
