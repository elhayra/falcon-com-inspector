using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;


namespace BlueSky.Com
{
    public class UDPClientCom
    {
        //TODO: CLIENT CALL BACK OF INCOMING BYTES???
        private UdpClient udpClient_;

        public void Connect(string ip, int port)
        {
            udpClient_ = new UdpClient();
            udpClient_.Connect(ip, port);
        }

        public bool Publish(byte[] bytes)
        {
            if (udpClient_ != null)
            {
                udpClient_.Send(bytes, bytes.Length);
                return true;
            }
            return false;
        }

        public void Close()
        {
            udpClient_.Close();
            udpClient_ = null;
        }

        public void Subscribe(Action<byte[]> bytes)
        {

        }

        public void Unsubscribe(Action<byte[]> bytes)
        {

        }

        public bool Send(byte[] bytes)
        {
            return false;
        }
    }
}
