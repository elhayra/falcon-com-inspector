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
            if ((IsTcpClientInitiated()) ||
                (IsTcpServerInitiated()) ||
                (IsUdpClientInitiated()) ||
                (IsUdpServerInitiated()) ||
                IsSerialInitiated())
                return true;
            return false;
        }

        public bool IsTcpClientInitiated()
        {
            if (tcpClient_ != null && !tcpClient_.IsDead)
                return true;
            return false;
        }
        public bool IsTcpServerInitiated()
        {
            if (tcpServer_ != null && !tcpServer_.IsDead)
                return true;
            return false;
        }
        public bool IsUdpClientInitiated()
        {
            if (udpClient_ != null && !udpClient_.IsDead)
                return true;
            return false;
        }
        public bool IsUdpServerInitiated()
        {
            if (udpServer_ != null && !udpServer_.IsDead)
                return true;
            return false;
        }
        public bool IsSerialInitiated()
        {
            if (serialCom_ != null && serialCom_.IsOpen)
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
