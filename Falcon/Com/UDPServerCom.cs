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
    public class UDPServerCom : UdpClient
    {
        private IPEndPoint endpoint_;
        List<Action<byte[]>> subsFuncs_ = new List<Action<byte[]>>();
        bool isDead_ = true;

        public bool IsDead { get { return isDead_; } }

        public UDPServerCom(int port) : base(port)
        {
            endpoint_ = new IPEndPoint(IPAddress.Any, port);
            AsyncListen();
        }

        private void AsyncListen()
        {
            if (!IsDead)
                BeginReceive(new AsyncCallback(OnIncomingBytes), null);
        }
    

        private void OnIncomingBytes(IAsyncResult res)
        {
            if (IsDead)
                return;
            byte[] bytes = EndReceive(res, ref endpoint_);

            Publish(bytes);
  
            AsyncListen(); //keep listening
        }

        public void Kill()
        {
            isDead_ = true;
            Close();
        }

        public bool Send(byte[] bytes)
        {
            if (!IsDead)
            {
                Send(bytes, bytes.Length, endpoint_);
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
