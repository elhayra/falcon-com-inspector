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
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.Com
{
    public class TcpSmartClient
    {
        public const int BUFF_SIZE = 65536;
        NetworkStream stream_;
        List<Action<byte[]>> subsList_ = new List<Action<byte[]>>();
        byte[] bytesIn_;
        TcpClient tcpClient_;
        public TcpClient Client { get { return tcpClient_; } }
        public bool IsDead = false;

        public TcpSmartClient(TcpClient tcpClient)
        {
            tcpClient_ = tcpClient;
            stream_ = tcpClient_.GetStream();

            tcpClient_.NoDelay = true;
            tcpClient_.ReceiveBufferSize = 8192;
            tcpClient_.SendBufferSize = 8192;
            
            AsyncListen();
        }

        private void AsyncListen()
        {
            if (!IsDead)
            {
                bytesIn_ = new byte[BUFF_SIZE];
                try
                {
                    stream_.BeginRead(bytesIn_, 0, BUFF_SIZE, OnIncomingBytes, null);
                }
                catch (System.ObjectDisposedException exp)
                {
                    IsDead = true;
                }
            }
        }

        private void OnIncomingBytes(IAsyncResult res)
        {
            if (!IsDead)
            {
                int numberOfBytesRead = 0;
                try
                {
                    numberOfBytesRead = stream_.EndRead(res);
                    if (numberOfBytesRead == 0)
                    {
                        IsDead = true;
                        return;
                    }
                }
                catch(ObjectDisposedException exp)
                {
                    IsDead = true;
                }
                 catch (IOException exp)
                {
                    IsDead = true;
                }
                if (!IsDead)
                {
                    byte[] truncArray = new byte[numberOfBytesRead];
                    Array.Copy(bytesIn_, truncArray, truncArray.Length);
                    Publish(truncArray);
                    AsyncListen();
                }
            }
        }

        public void Subscribe(Action<byte[]> func)
        {
            subsList_.Add(func);
        }

        public void Unsubsctibe(Action<byte[]> func)
        {
            subsList_.Remove(func);
        }

        private void Publish(byte [] msg)
        {
            foreach (var funcion in subsList_)
            {
                funcion(msg);
            }
        }

        public void Close()
        {
            IsDead = true;
            Client.Close();
        }
    }
}