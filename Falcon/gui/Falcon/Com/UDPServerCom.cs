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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using Falcon.Utils;

namespace Falcon.Com
{
    public class UDPServerCom : UdpClient
    {
        private IPEndPoint endpoint_;
        List<Action<byte[]>> subsFuncs_ = new List<Action<byte[]>>();
        bool isDead_ = false;

        public bool IsDead { get { return isDead_; } }

        public UDPServerCom(int port) : base(new IPEndPoint(IPAddress.Any, port)) 
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
            try
            {
                byte[] bytes = EndReceive(res, ref endpoint_);
                Publish(bytes);
                AsyncListen(); //keep listening
            }
            catch (System.ObjectDisposedException exp)
            {
                isDead_ = true;
            }
            catch (SocketException exp)
            {
                //other side disconnected
            }
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
                try
                {
                    int a = Send(bytes, bytes.Length, endpoint_);
                    return true;
                }
                catch (SocketException exp)
                {
                    MsgBox.ErrorMsg("UDP Server Error", exp.Message + "\n" +
                        "server must recieve bytes from client (to get client address) before trying to send bytes");
                }
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
