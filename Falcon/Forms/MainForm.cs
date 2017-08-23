using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Falcon.Com;
using BlueSky.Com;
using System.IO.Ports;


namespace Falcon
{
    public partial class MainForm : Form
    {
        private TCPClientCom tcpClient_;
        private UDPClientCom udpClient_;
        private TCPServerCom tcpServer_;
        private UDPServerCom udpServer_;
        private SerialCom serialCom_;

        private Connection connectionState_ = new Connection();



        public MainForm()
        {
            InitializeComponent();

            this.SetStyle(
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);

            serialParityCmBx.SelectedIndex = 0;
            serialStopBitsCmBx.SelectedIndex = 1;
            serialBaudCmBx.SelectedIndex = 0;
            UpdateSerialPorts();
        }

        private void UpdateSerialPorts()
        {
            var availablePorts = SerialCom.GetAvailPorts();
            foreach (var port in availablePorts)
                serialComCmBx.Items.Add(port);
            if (serialComCmBx.Items.Count > 0)
                serialComCmBx.SelectedIndex = 0;
        }

        private void tcpConnectBtn_Click(object sender, EventArgs e)
        {
            //TODO: ONLY AFTER HANDLE CLIENTS IN TCP CLASS THIS WOULD WORK (GET BYTES)
            bool connected = false;
            if (tcpServerRdBtn.Checked)
            {
                tcpServer_ = new TCPServerCom();
                if (tcpServer_.Connect((int)tcpPortTxt.Value))
                {
                    tcpServer_.SubscribeToMsgs(OnTcpByteIn);
                    tcpServer_.NotifyOnNewClient(OnNewTcpClient);
                    tcpClientRdBtn.Enabled = false;
                    connected = true;
                }
            }
            else
            {
                tcpClient_ = new TCPClientCom();
                if (tcpClient_.Connect(tcpIpTxt.Text, (int)tcpPortTxt.Value))
                {
                    tcpClient_.Subscribe(OnTcpByteIn);
                    tcpServerRdBtn.Enabled = false;
                    connected = true;
                }
            }
            if (connected)
            {
                tcpConnectBtn.Enabled = false;
                tcpDisconnectBtn.Enabled = true;
                tcpConnectionStateLbl.Text = "Connected";
            }
        }

        private void OnNewTcpClient(uint numOfClients)
        {
            Invoke((MethodInvoker)delegate
            {
                tcpConnectedClientsLbl.Text = numOfClients.ToString();
            });
        }

        private void OnTcpByteIn(byte[] bytes)
        {
            AppendBytesToScreens(bytes);
        }

        private void tcpDisconnectBtn_Click(object sender, EventArgs e)
        {
            if (tcpServerRdBtn.Checked)
            {
                tcpServer_.Close();
                tcpServer_ = null;
                tcpClientRdBtn.Enabled = true;
            }
            else
            {
                tcpClient_.Close();
                tcpClient_ = null;
                tcpServerRdBtn.Enabled = true;
            }

            tcpConnectBtn.Enabled = true;
            tcpConnectionStateLbl.Text = "Disconnected";
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            var bytes = Encoding.ASCII.GetBytes(textToSendCmBx.Text);
            textToSendCmBx.Items.Add(textToSendCmBx.Text);
            textToSendCmBx.Text = "";

            if (tcpServer_ != null)
                tcpServer_.Send(bytes);

            if (tcpClient_ != null)
                tcpClient_.Send(bytes);

           // if (udpServer_ != null)
            //    udpServer_.Send(bytes, );

            if (udpClient_ != null)
                udpClient_.Send(bytes);

            if (serialCom_ != null)
            {
                connectionState_.BytesOut += (uint)bytes.Length;
                bytesOutLbl.Text = connectionState_.BytesOut.ToString() + " B";
                serialCom_.Send(bytes);
            }
        }

        private void clearScreenBtn_Click(object sender, EventArgs e)
        {
            dataInScreenTxt.Clear();
            bytesInLbl.Text = "0 B";
            bytesOutLbl.Text = "0 B";
        }

        private void clearInHistoryBtn_Click(object sender, EventArgs e)
        {
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void serialConnectBtn_Click(object sender, EventArgs e)
        {
            string port = serialComCmBx.SelectedItem.ToString();
            int baud = int.Parse(serialBaudCmBx.SelectedItem.ToString());
            StopBits stopBits = SerialCom.StringToStopBits(serialStopBitsCmBx.SelectedItem.ToString());
            int dataBits = (int)serialDataBitsTxt.Value;
            Parity parity = SerialCom.StringToParity(serialParityCmBx.SelectedItem.ToString());
            serialCom_ = new SerialCom();

            if (serialCom_.Connect(port, baud, parity, dataBits, stopBits))
            {
                serialConnectionStateLbl.Text = "Connected";
                serialDisconnectBtn.Enabled = true;
                serialConnectBtn.Enabled = false;
                serialCom_.Subscribe(OnSerialByteIn);
            }
        }

        private void serialDisconnectBtn_Click(object sender, EventArgs e)
        {
            serialCom_.Close();
            serialCom_ = null;
            serialDisconnectBtn.Enabled = false;
            serialConnectBtn.Enabled = true;
            serialConnectionStateLbl.Text = "Disconnected";
        }

        private void OnSerialByteIn(byte[] bytes)
        {
            AppendBytesToScreens(bytes);            
        }

        private void dataInHistoryLstBx_SelectedIndexChanged(object sender, EventArgs e)
        {
 
  
        }

        private void dataInHistoryLstBx_SizeChanged(object sender, EventArgs e)
        {

        }

        private void AppendBytesToScreens(byte[] bytes)
        {
            Invoke((MethodInvoker)delegate
            {
                connectionState_.BytesIn += (uint)bytes.Length;
                bytesInLbl.Text = connectionState_.BytesIn.ToString() + " B";
                var encodedString = System.Text.Encoding.UTF8.GetString(bytes);
                if (autoScrollChkBx.Checked)
                    dataInScreenTxt.AppendText(encodedString);
                else
                    dataInScreenTxt.Text += encodedString;
            });
        }

        private void tcpServerRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (tcpClientRdBtn.Checked)
            {
                tcpIpTxt.Enabled = true;
            }
            else 
                tcpIpTxt.Enabled = false;
        }


    }
}
