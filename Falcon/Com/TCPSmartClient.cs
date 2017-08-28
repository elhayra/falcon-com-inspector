using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.Com
{
    public class TcpSmartClient
    {
        public const int BUFF_SIZE = 1;
        NetworkStream stream_;
        List<Action<byte[]>> subsList_ = new List<Action<byte[]>>();
        byte[] container_;
        TcpClient tcpClient_;
        public TcpClient Client { get { return tcpClient_; } }
        bool isDead_ = false;

        public TcpSmartClient(TcpClient tcpClient)
        {
            tcpClient_ = tcpClient;
            stream_ = tcpClient_.GetStream();
            AsyncListen();
        }

        private void AsyncListen()
        {
            container_ = new byte[BUFF_SIZE];
            stream_.BeginRead(container_, 0, BUFF_SIZE, OnIncomingBytes, null);
        }

        private void OnIncomingBytes(IAsyncResult res)
        {
            if (!isDead_)
            {
                stream_.EndRead(res);
                Publish();
                AsyncListen();
            }
        }

        public void Subscribe(Action<byte[]> func)
        {
            subsList_.Add(func);
        }

        public void Unsubsctibe(Action<byte[]> func)
        {
            subsList_.Remove(func);
        }

        private void Publish()
        {
            foreach (var funcion in subsList_)
            {
                funcion(container_);
            }
        }

        public void Close()
        {
            isDead_ = true;
            Client.Close();
        }
    }
}