/*******************************************************************************
* Copyright (c) 2018 Elhay Rauper
* All rights reserved.
*
* Redistribution and use in source and binary forms, with or without
* modification, are permitted (subject to the limitations in the disclaimer
* below) provided that the following conditions are met:
*
*     * Redistributions of source code must retain the above copyright notice,
*     this list of conditions and the following disclaimer.
*
*     * Redistributions in binary form must reproduce the above copyright
*     notice, this list of conditions and the following disclaimer in the
*     documentation and/or other materials provided with the distribution.
*
*     * Neither the name of the copyright holder nor the names of its
*     contributors may be used to endorse or promote products derived from this
*     software without specific prior written permission.
*
* NO EXPRESS OR IMPLIED LICENSES TO ANY PARTY'S PATENT RIGHTS ARE GRANTED BY
* THIS LICENSE. THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND
* CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
* LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
* PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
* CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
* EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
* PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR
* BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER
* IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
* ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
* POSSIBILITY OF SUCH DAMAGE.
*******************************************************************************/

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
using Falcon.Utils;

namespace Falcon.Com
{ 
    public class TCPServerCom : TcpListener
    {
        uint clientsCounter_ = 0;
        List<TcpSmartClient> clientsList_ = new List<TcpSmartClient>();
        List<Action<byte[]>> subsList_ = new List<Action<byte[]>>();
        List<Action<uint>> notifyNewClientsLst_ = new List<Action<uint>>();
        CancellationTokenSource cs_;
        CancellationToken ct_;
        bool isDead_ = true;

        public bool IsDead { get { return isDead_; } }

        public TCPServerCom(int port) : base(IPAddress.Any, port) {}

        public bool Connect()
        {
            clientsCounter_ = 0;
            try
            {
                Start();
            }
            catch (SocketException exp)
            {
                //error: trying to open more than one server with same ip and port
                MsgBox.ErrorMsg("Server Error", exp.Message);
                return false;
            }
            AsyncListen();
            isDead_ = false;

            cs_ = new CancellationTokenSource();
            ct_ = cs_.Token;
            var t = Task.Run(() => KeepAliveClients());
            return true;
        }

        /// <summary>
        /// wait for new incoming clients
        /// </summary>
        private void AsyncListen()
        {
            BeginAcceptTcpClient(OnIncomingClients, null);
        }

        private void KeepAliveClients()
        {
            while (!ct_.IsCancellationRequested)
            {
                foreach (var smartClient in clientsList_.ToList())
                {
                    if (smartClient.IsDead)
                    {
                        clientsCounter_--;
                        smartClient.Close();
                        clientsList_.Remove(smartClient);
                        NotifyOnDeadClient();
                    } 
                }
                Thread.Sleep(1000);
            }
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

        public void SubscribeToClientsState(Action<uint> func)
        {
            notifyNewClientsLst_.Add(func);
        }

        public void UnsubscribeToClientsState(Action<uint> func)
        {
            notifyNewClientsLst_.Remove(func);
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
            foreach (var func in notifyNewClientsLst_)
            {
                func(clientsCounter_);
            }
        }

        private void NotifyOnDeadClient()
        {
            foreach (var func in notifyNewClientsLst_)
            {
                func(clientsCounter_);
            }
        }

        public void Close()
        {
            cs_.Cancel();
            isDead_ = true;
            foreach (var clientWrapper in clientsList_) 
               clientWrapper.Client.Close();
            Stop();
        }

    }
}
