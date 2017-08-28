using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Collections;

namespace Falcon.Com
{ 
    public class TCPServerCom : TcpListener
    {
        uint clientsCounter_ = 0;
        List<TcpSmartClient> clientsList_ = new List<TcpSmartClient>();
        List<Action<byte[]>> subsList_ = new List<Action<byte[]>>();
        List<Action<uint>> notifyList_ = new List<Action<uint>>();
        bool isDead_ = true;

        public bool IsDead { get { return isDead_; } }

        public TCPServerCom(int port) : base(IPAddress.Any, port) {}

        public bool Connect()
        {
            clientsCounter_ = 0;
            Start();
            AsyncListen();
            isDead_ = false;
            return true;
        }

        private void AsyncListen()
        {
            BeginAcceptTcpClient(OnIncomingClients, null);
        }

        private void OnIncomingClients(IAsyncResult res)
        {
            if (IsDead)
                return;
            TcpClient newClient = EndAcceptTcpClient(res);
            var newSmartClient = new TcpSmartClient(newClient);
            newSmartClient.Subscribe(PublishMsg);
            clientsList_.Add(newSmartClient);
            clientsCounter_++;
            NotifyOnNewClient();
            AsyncListen(); //keep listening
        }

        public bool Send(byte[] bytes)
        {
            if (!IsDead)
            {
                foreach (var smartClient in clientsList_)
                    smartClient.Client.GetStream().Write(bytes, 0, bytes.Length);
                return true;
            }
            return false;
        }

        public void SubscribeToMsgs(Action<byte[]> func)
        {
            subsList_.Add(func);
        }

        public void UnsubscribeToMsgs(Action<byte[]> func)
        {
            subsList_.Remove(func);
        }

        public void NotifyOnNewClient(Action<uint> func)
        {
            notifyList_.Add(func);
        }

        public void UnNotifyOnNewClient(Action<uint> func)
        {
            notifyList_.Remove(func);
        }

        private void PublishMsg(byte[] bytes)
        {
            foreach (var func in subsList_)
            {
                func(bytes);
            }
        }

        private void NotifyOnNewClient()
        {
            foreach (var func in notifyList_)
            {
                func(clientsCounter_);
            }
        }

        public void Close()
        {
            isDead_ = true;
            foreach (var clientWrapper in clientsList_) 
               clientWrapper.Client.Close();
            Stop();
        }

    }
}
