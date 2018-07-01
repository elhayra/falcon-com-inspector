using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.Utils.Ssh
{
    class SshCredentials
    {
        public string Username;
        public string Hostname;
        public string Password;

        public SshCredentials() { }

        public SshCredentials(string username, string hostname, string password)
        {
            Username = username;
            Hostname = hostname;
            Password = password;
        }
    }
}
