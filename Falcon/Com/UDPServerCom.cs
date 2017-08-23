using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace BlueSky.Com
{
    class UDPServerCom
    {
        private UdpClient udpClient_;
        private IPEndPoint endPoint_;
        List<Action<byte[]>> subsFuncs_ = new List<Action<byte[]>>();

        public bool Connect(int port)
        {
            bool success = true;
            try
            {
                udpClient_ = new UdpClient(new IPEndPoint(IPAddress.Any, port));
                AsyncListen();
            }
            catch(SocketException exp)
            {
                success = false;
            }
            return success;
        }

        private void AsyncListen()
        {
            if (udpClient_ != null)
                udpClient_.BeginReceive(new AsyncCallback(OnIncomingBytes), null);
        }
    

        private void OnIncomingBytes(IAsyncResult res)
        {
            if (udpClient_ == null)
                return;
            byte[] bytes = udpClient_.EndReceive(res, ref endPoint_);

            Publish(bytes);
  
            AsyncListen(); //keep listening
        }

        public void Close()
        {
            udpClient_.Close();
            udpClient_ = null;
        }

        public bool Send(byte[] bytes, IPEndPoint endpoint)
        {
            if (udpClient_ != null)
            {
                udpClient_.Send(bytes, bytes.Length, endpoint);
                return true;
            }
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

        public void Publish(byte[] bytes)
        {
            foreach (var func in subsFuncs_)
                func(bytes);
        }

    }
}
