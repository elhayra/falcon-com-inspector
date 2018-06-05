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
using System.Net.Sockets;

namespace Falcon.Com
{
    public class TCPClientCom : TcpClient
    {
        public const int BUFF_SIZE = 65536;
        NetworkStream serverStream_;
        byte[] bytesIn_;
        List<Action<byte[]>> subsFuncs_ = new List<Action<byte[]>>();

        bool isDead_ = true;

        public bool IsDead { get { return isDead_; } }

        public TCPClientCom()
        {
            bytesIn_ = new byte[BUFF_SIZE];
        }

        public bool ConnectTo(string ip, int port)
        {
            return Connect(new NetworkAdderss(ip, port));
        }

        public bool Connect(NetworkAdderss srvrAddr)
        {
            try 
            {
                if (!srvrAddr.IsIpValid() || !srvrAddr.IsPortValid())
                    return false;
                if (ConnectAsync(srvrAddr.IP.ToString(), srvrAddr.Port).Wait(100))
                {
                    isDead_ = false;
                    serverStream_ = GetStream();
                    AsyncListen();
                }
            }
            catch (SocketException exp)
            {
                //wrong address
                isDead_ = true;
            }
            return !isDead_;
        }

        public void Subscribe(Action<byte[]> func)
        {
            subsFuncs_.Add(func);
        }

        public void Unsubscribe(Action<byte[]> func)
        {
            subsFuncs_.Remove(func);
        }

        private void AsyncListen()
        {
            serverStream_.BeginRead(bytesIn_, 0, bytesIn_.Length, new AsyncCallback(OnReadCB), null);
        }

        private void OnReadCB(IAsyncResult ar)
        {
            if (IsDead)
                return;
            int numberOfBytesRead = serverStream_.EndRead(ar);
            if (numberOfBytesRead == 0)
                return;
            byte[] truncArray = new byte[numberOfBytesRead];
            Array.Copy(bytesIn_, truncArray, truncArray.Length);
            foreach (var func in subsFuncs_)
                func(truncArray);
            bytesIn_ = new byte[BUFF_SIZE];
            AsyncListen();
        }

        public bool Send(byte[] bytes)
        {
            if (!IsDead)
            {
                try
                {
                    serverStream_.Write(bytes, 0, bytes.Length);
                }
                catch (IOException exp)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        public void CloseMe()
        {
            isDead_ = true;
            serverStream_.Close();
            Close();
        }
    }
}
