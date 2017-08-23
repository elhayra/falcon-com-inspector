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

namespace BlueSky.Com
{ 
    class TCPServerCom
    {
        public const int BUFF_SIZE = 256;
        TcpListener server_;
        uint clientsCounter_ = 0;
        List<TcpClientWrapper> clientsList_ = new List<TcpClientWrapper>();
        List<Action<byte[]>> subsList_ = new List<Action<byte[]>>();
        List<Action<uint>> notifyList_ = new List<Action<uint>>();
        byte [] bytes_ = new byte[BUFF_SIZE];

        public bool Connect(int port)
        {
            clientsCounter_ = 0;
            server_ = new TcpListener(IPAddress.Any, port);
            server_.Start();
            AsyncListen();
            return true;
        }

        private void AsyncListen()
        {
            server_.BeginAcceptTcpClient(OnIncomingClients, null);
        }

        private void OnIncomingClients(IAsyncResult res)
        {
            if (server_ == null)
                return;
            TcpClient new_client = server_.EndAcceptTcpClient(res);
            var clientWrapper = new TcpClientWrapper(new_client);
            clientWrapper.Subscribe(PublishMsg);
            clientsList_.Add(clientWrapper);
            clientsCounter_++;
            NotifyOnNewClient();
            AsyncListen(); //keep listening
        }

        public bool Send(byte[] bytes)
        {
            if (server_ != null)
            {
                foreach (var clientWrapper in clientsList_)
                    clientWrapper.Client.GetStream().Write(bytes, 0, bytes.Length);
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
            foreach (var clientWrapper in clientsList_) 
               clientWrapper.Client.Close();
                
            server_.Stop(); 
        }

    }
}
