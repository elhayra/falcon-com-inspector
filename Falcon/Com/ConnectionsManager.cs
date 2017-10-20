using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Com;
using Falcon.Utils;

namespace Falcon.Com
{
    public class ConnectionsManager
    {
        private TCPClientCom tcpClient_;
        private UDPClientCom udpClient_;
        private TCPServerCom tcpServer_;
        private UDPServerCom udpServer_;
        private SerialCom serialCom_;

        public TCPClientCom TCPClient { get { return tcpClient_; } }
        public TCPServerCom TCPServer { get { return tcpServer_; } }
        public UDPClientCom UDPClient { get { return udpClient_; } }
        public UDPServerCom UDPServer { get { return udpServer_; } }
        public SerialCom Serial { get { return serialCom_; } }
        protected static readonly object padlock = new object();
        private static ConnectionsManager instance = null;

        public BytesCounter BytesCounter = new BytesCounter();
        public BytesCounter BytesOutCounter = new BytesCounter();
        public BytesCounter BytesInCounter = new BytesCounter();
        public BytesCounter BytesRateCounter = new BytesCounter();
        public ulong PrevBytesCount;

        ConnectionsManager()
        {
        }

        public static ConnectionsManager Inst
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ConnectionsManager();
                    }
                    return instance;
                }
            }
        }

        public bool IsSomeConnectionInitiated()
        {
            if ((IsTcpClientInitiated() && !tcpClient_.IsDead) ||
                (IsTcpServerInitiated() && !tcpServer_.IsDead) ||
                (IsUdpClientInitiated() && !udpClient_.IsDead) ||
                (IsUdpServerInitiated() && !udpClient_.IsDead) ||
                (IsSerialInitiated() && serialCom_.IsOpen))
                return true;
            return false;
        }

        public bool IsTcpClientInitiated()
        {
            if (tcpClient_ != null)
                return true;
            return false;
        }
        public bool IsTcpServerInitiated()
        {
            if (tcpServer_ != null)
                return true;
            return false;
        }
        public bool IsUdpClientInitiated()
        {
            if (udpClient_ != null)
                return true;
            return false;
        }
        public bool IsUdpServerInitiated()
        {
            if (udpServer_ != null)
                return true;
            return false;
        }
        public bool IsSerialInitiated()
        {
            if (serialCom_ != null)
                return true;
            return false;
        }

        public void InitTcpClient()
        {
            tcpClient_ = new TCPClientCom();
        }

        public void InitUdpClient()
        {
            udpClient_ = new UDPClientCom();
        }

        public void InitTcpServer(int port)
        {
            tcpServer_ = new TCPServerCom(port);
        }

        public void InitUdpServer(int port)
        {
            udpServer_ = new UDPServerCom(port);
        }

        public void InitSerial()
        {
            serialCom_ = new SerialCom();
        }


    }
}
