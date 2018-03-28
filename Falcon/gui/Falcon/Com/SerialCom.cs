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
using System.IO.Ports;

namespace Falcon.Com
{
    public class SerialCom : SerialPort
    {
        private bool connected_ = false;
        List<Action<byte[]>> subsList_ = new List<Action<byte[]>>();
   
        public bool Connect(string port, int baudRate)
        {
            return Connect(port, baudRate, Parity.None, 8, StopBits.One);
        }

        public bool Connect(string port, 
                            int baudRate, 
                            Parity parity, 
                            int dataBits, 
                            StopBits stopBits)
        {
            BaudRate = baudRate;
            PortName = port;
            Parity = parity;
            DataBits = dataBits;
            StopBits = stopBits;
            

            try
            {
                DataReceived += new SerialDataReceivedEventHandler(OnDataReceived);
                Open();
                connected_ = true;
            }
            catch (Exception e)
            {
                string err = e.ToString();
                connected_ = false;
            }
            return connected_;
        }

        public bool Send(byte[] bytes)
        {
            if (connected_)
            {
                Write(bytes, 0, bytes.Length);
                return true;
            }
            return false;
        }

        public void CloseMe()
        {
            if (connected_)
            {
                connected_ = false;
                Dispose();
            }
        }

        public bool IsConnected()
        {
            return connected_;
        }

        public void Subscribe(Action<byte[]> func)
        {
            subsList_.Add(func);
        }

        public void Unsubscribe(Action<byte[]> func)
        {
            subsList_.Remove(func);
        }

        private void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (connected_)
            {
                string incoming = ReadExisting();
                foreach (var func in subsList_)
                {
                    func(Encoding.ASCII.GetBytes(incoming));
                }
            }
        }

        public static string[] GetConnectedPorts()
        {
            return SerialPort.GetPortNames().Distinct().ToArray();
        }

        public static Parity StringToParity(string parity)
        {
            switch(parity)
            {
                case "None":
                    return Parity.None;
                case "Odd":
                    return Parity.Odd;
                case "Even":
                    return Parity.Even;
                case "Mark":
                    return Parity.Mark;
                case "Space":
                    return Parity.Space;
                default:
                    return Parity.None;
            }
        }

        public static StopBits StringToStopBits(string stopBits)
        {
            switch(stopBits)
            {
                case "0":
                    return StopBits.None;
                case "1":
                    return StopBits.One;
                case "1.5":
                    return StopBits.OnePointFive;
                case "2":
                    return StopBits.Two;
                default:
                    return StopBits.None;
            }
        }
    }
}

