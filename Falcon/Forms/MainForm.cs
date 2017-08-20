using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            bool connected = false;
            if (tcpServerRdBtn.Checked)
            {
                tcpServer_ = new TCPServerCom();
                if (tcpServer_.Connect((int)tcpPortTxt.Value))
                {
                    tcpClientRdBtn.Enabled = false;
                    connected = true;
                }
            }
            else
            {
                tcpClient_ = new TCPClientCom();
                if (tcpClient_.Connect(tcpIpTxt.Text, (int)tcpPortTxt.Value))
                {
                    tcpServerRdBtn.Enabled = false;
                    connected = true;
                }
            }
            if (connected)
            {
                tcpConnectBtn.Enabled = false;
                tcpConnectionStateLbl.Text = "Connected";
            }
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
                serialCom_.Send(bytes);
        }

        private void clearScreenBtn_Click(object sender, EventArgs e)
        {
            dataInScreenTxt.Clear();
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
                var encodedString = System.Text.Encoding.UTF8.GetString(bytes);
                if (autoScrollChkBx.Checked)
                    dataInScreenTxt.AppendText(encodedString);
                else
                    dataInScreenTxt.Text += encodedString;
            });
        }


    }
}
