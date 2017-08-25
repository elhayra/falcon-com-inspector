using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BlueSky.Com
{
    public class TCPClientCom : TcpClient
    {
        public const int BUFF_SIZE = 1;
        NetworkStream serverStream_;
        byte[] bytesIn_;
        List<Action<byte[]>> subsFuncs_ = new List<Action<byte[]>>();

        bool isDead_ = true;

        public bool IsDead { get { return isDead_; } }

        public TCPClientCom()
        {
            bytesIn_ = new byte[BUFF_SIZE];
        }

        public bool ConnectTo(string ip, int port)
        {
            return Connect(new NetworkAdderss(ip, port));
        }

        public bool Connect(NetworkAdderss srvrAddr)
        {
            try 
            {
                if (ConnectAsync(srvrAddr.IP.ToString(), srvrAddr.Port).Wait(500))
                {
                    isDead_ = false;
                    serverStream_ = GetStream();
                    AsyncListen();
                }
            }
            catch (SocketException exp)
            {
                //wrong address
            }
            return isDead_;
        }

        public void Subscribe(Action<byte[]> func)
        {
            subsFuncs_.Add(func);
        }

        public void Unsubscribe(Action<byte[]> func)
        {
            subsFuncs_.Remove(func);
        }

        private void AsyncListen()
        {
            serverStream_.BeginRead(bytesIn_, 0, bytesIn_.Length, new AsyncCallback(OnReadCB), null);
        }

        private void OnReadCB(IAsyncResult ar)
        {
            if (IsDead)
                return;
            int numberOfBytesRead = serverStream_.EndRead(ar);
            if (numberOfBytesRead == 0)
                return;
            foreach (var func in subsFuncs_)
                func(bytesIn_);
            bytesIn_ = new byte[BUFF_SIZE];
            AsyncListen();
        }

        public bool Send(byte[] bytes)
        {
            if (!IsDead)
            {
                serverStream_.Write(bytes, 0, bytes.Length);
                return true;
            }
            return false;
        }

        public void Kill()
        {
            isDead_ = true;
            serverStream_.Close();
            Close();
        }
    }
}
