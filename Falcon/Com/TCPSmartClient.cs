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
        public const int BUFF_SIZE = 1024;
        NetworkStream stream_;
        List<Action<byte[]>> subsList_ = new List<Action<byte[]>>();
        byte[] bytesIn_;
        TcpClient tcpClient_;
        public TcpClient Client { get { return tcpClient_; } }
        public bool IsDead = false;

        public TcpSmartClient(TcpClient tcpClient)
        {
            tcpClient_ = tcpClient;
            stream_ = tcpClient_.GetStream();
            AsyncListen();
        }

        private void AsyncListen()
        {
            if (!IsDead)
            {
                bytesIn_ = new byte[BUFF_SIZE];
                try
                {
                    stream_.BeginRead(bytesIn_, 0, BUFF_SIZE, OnIncomingBytes, null);
                }
                catch (System.ObjectDisposedException exp)
                {
                    IsDead = true;
                }
            }
        }

        private void OnIncomingBytes(IAsyncResult res)
        {
            if (!IsDead)
            {
                int numberOfBytesRead = 0;
                try
                {
                    numberOfBytesRead = stream_.EndRead(res);
                    if (numberOfBytesRead == 0)
                    {
                        IsDead = true;
                        return;
                    }
                }
                catch(System.ObjectDisposedException exp)
                {
                    IsDead = true;
                }
                byte[] truncArray = new byte[numberOfBytesRead];
                Array.Copy(bytesIn_, truncArray, truncArray.Length);
                Publish(truncArray);
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

        private void Publish(byte [] msg)
        {
            foreach (var funcion in subsList_)
            {
                funcion(msg);
            }
        }

        public void Close()
        {
            IsDead = true;
            Client.Close();
        }
    }
}