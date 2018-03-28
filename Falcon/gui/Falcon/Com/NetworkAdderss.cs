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
using System.Net;
using System.Net.Sockets;

namespace Falcon.Com
{
    public class NetworkAdderss
    {
        public NetworkAdderss(){}

        public NetworkAdderss(string ip, string port)
        {
            IP = StringToIPAddress(ip);
            Port = PortStringToInt(port);
        }

        public NetworkAdderss(string ip, int port)
        {
            IP = StringToIPAddress(ip);
            Port = port;
        }

        public NetworkAdderss(IPAddress ip, int port)
        {
            IP = ip;
            Port = port;
        }

        private IPAddress ip_;
        public IPAddress IP
        {
            get{ return ip_; }
            set { ip_ = value; }
        }

        private int port_;
        public int Port
        {
            get { return port_; }
            set { port_ = value; }
        }

        public IPEndPoint EndPoint()
        {
            return new IPEndPoint(IP, Port);
        }

        public IPAddress StringToIPAddress(string ip)
        {
            IPAddress temp_ip = null;
            if (!IPAddress.TryParse(ip, out temp_ip))
            {
                return null; //error parsing
            }
            return temp_ip;
        }

        public static string GetLocalIPAddress()
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                try
                {
                    socket.Connect("10.0.0.255", 65530);
                    IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                    return endPoint.Address.ToString(); 
                }
                catch (System.Net.Sockets.SocketException e)
                { 
                    return null;
                }
            }
        }

        public static int PortStringToInt(string port)
        {
            int parsed_port;
            try
            {
                parsed_port =  int.Parse(port);
                if (!IsPortValid(parsed_port)) 
                    parsed_port = -1; //error parsing
            }
            catch (FormatException)
            {
                parsed_port = -1; //error parsing
            }
            return parsed_port;
        }

        public static bool IsPortValid(int port)
        {
            if (port <= 65535)
                return true;
            return false;
        }

        public bool IsIpValid() { return IP != null; }
        public bool IsPortValid() { return IsPortValid(Port); }

    }
}
