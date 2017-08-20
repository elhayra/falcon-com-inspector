using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace BlueSky.Com
{
    public class SerialCom : ComInterface
    {
        private SerialPort port_;
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
            try
            {
                port_ = new SerialPort(port, baudRate, parity, dataBits, stopBits);
                port_.DataReceived += new SerialDataReceivedEventHandler(OnDataReceived);
                port_.Open();
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
                port_.Write(bytes, 0, bytes.Length);
                return true;
            }
            return false;
        }

        public void Close()
        {
            if (connected_)
            {
                port_.Dispose();
                connected_ = false;
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
            string incoming = port_.ReadExisting();
            foreach (var func in subsList_)
            {
                func(Encoding.ASCII.GetBytes(incoming));
            }
        }

        public static string[] GetAvailPorts()
        {
            return SerialPort.GetPortNames();
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

