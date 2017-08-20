using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace BlueSky.Com
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
                    return "";
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
            if (port > 65535)
                return true;
            return false;
        }

    }
}
