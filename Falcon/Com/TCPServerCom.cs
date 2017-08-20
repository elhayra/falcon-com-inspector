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
    class TCPServerCom : ComInterface
    {
        public const int BUFF_SIZE = 256;
        Task listen_to_cons_task_ = new Task(() => { });
        TcpListener server_;
        int clientsCounter = 0;
        List<TcpClient> clientsList_ = new List<TcpClient>();
        List<Action<byte[]>> subsList_ = new List<Action<byte[]>>();
        byte [] bytes_ = new byte[BUFF_SIZE];

        public bool Connect(int port)
        {
            clientsCounter = 0;
            server_ = new TcpListener(IPAddress.Any, port);
            server_.Start();
            return true;
        }

        private void AsyncListen()
        {
            server_.BeginAcceptTcpClient(OnIncomingBytes, null);
        }

        public bool Send(byte[] bytes)
        {
            if (server_ != null)
            {
                foreach (var client in clientsList_)
                    client.GetStream().Write(bytes, 0, bytes.Length);
                return true;
            }
            return false;
        }

        public void Subscribe(Action<byte[]> func)
        {
            subsList_.Add(func);
        }

        public void Unsubscribe(Action<byte[]> func)
        {
            subsList_.Remove(func);
        }


        private void OnIncomingClients(IAsyncResult res)
        {
            if (server_ == null)
                return;
            var new_client = server_.EndAcceptTcpClient(res);

            new_client.GetStream().BeginRead(bytes_, 0, bytes_.Length, OnIncomingBytes, null); //TODO: EACH CLIENT SHOULD BE ON ITS OWN CLASS AND LISTEN TO BYTES
            
            clientsList_.Add(new_client);
            clientsCounter++;
            AsyncListen(); //keep listening
        }

        private void OnIncomingBytes(IAsyncResult res)
        {
            
        }

        public void Close()
        {
            foreach (var client in clientsList_) 
                client.Close();
                
            server_.Stop(); 
        }

    }
}
