using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BlueSky.Com
{
    public class TCPClientCom
    {
        public const int BUFF_SIZE = 256;
        private TcpClient client_;
        NetworkStream serverStream_;
        byte[] bytesIn_;
        List<Action<byte[]>> subsFuncs_ = new List<Action<byte[]>>();

        public TCPClientCom()
        {
            bytesIn_ = new byte[BUFF_SIZE];
        }

        public bool Connect(string ip, int port)
        {
            return Connect(new NetworkAdderss(ip, port));
        }

        public bool Connect(NetworkAdderss srvrAddr)
        {
            client_ = new TcpClient();
            if (client_.ConnectAsync(srvrAddr.IP.ToString(), srvrAddr.Port).Wait(1000))
            {
                // connection success
                serverStream_ = client_.GetStream();
                AsyncListen();
                return true;
            }
            else
                return false;
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
            int numberOfBytesRead = serverStream_.EndRead(ar);

            if (numberOfBytesRead == 0)
                return;

            var bytes = new byte[numberOfBytesRead];
            for (int i = 0; i < numberOfBytesRead; i++)
                bytes[i] = bytesIn_[i];

            bytesIn_ = new byte[BUFF_SIZE];

            foreach (var func in subsFuncs_)
            {
                func(bytes);
            }

            AsyncListen();
        }



        public bool Send(byte[] bytes)
        {
            if (client_ != null)
            {
                serverStream_.Write(bytes, 0, bytes.Length);
                return true;
            }
            return false;
        }

        public void Close()
        {
            serverStream_.Close();
            client_.Close();
        }
    }
}
