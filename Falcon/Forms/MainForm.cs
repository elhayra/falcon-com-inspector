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
using Falcon.Forms;
using Falcon.Utils;
using Falcon.Com;


namespace Falcon
{
    public partial class MainForm : Form
    {




        private AboutForm aboutForm_;

        private BytesCounter bytesInCounter_ = new BytesCounter();
        private BytesCounter bytesOutCounter_ = new BytesCounter();
        private ConnectionsManager connections_ = new ConnectionsManager(); 


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

            LoadSerialSettigns();
            LoadTcpSettings();
            LoadUdpSettings();
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
            SaveTcpSettings();
            bool connected = false;
            if (tcpServerRdBtn.Checked)
            {
                connections_.InitTcpServer((int)tcpPortTxt.Value);
                if (connections_.TCPServer.Connect())
                {
                    connections_.TCPServer.SubscribeToMsgs(OnTcpByteIn);
                    connections_.TCPServer.NotifyOnNewClient(OnNewTcpClient);
                    tcpClientRdBtn.Enabled = false;
                    connected = true;
                }
            }
            else
            {
                connections_.InitTcpClient();
                if (connections_.TCPClient.ConnectTo(tcpIpTxt.Text, (int)tcpPortTxt.Value))
                {
                    connections_.TCPClient.Subscribe(OnTcpByteIn);
                    tcpServerRdBtn.Enabled = false;
                    connected = true;
                }
            }
            if (connected)
            {
                tcpConnectBtn.Enabled = false;
                tcpDisconnectBtn.Enabled = true;
                tcpConnectionStateLbl.Text = "Connected";
                tcpIndicatorLbl.BackColor = Color.LimeGreen;
            }
        }

        private void SaveTcpSettings()
        {
            Properties.Settings.Default.tcpIp = tcpIpTxt.Text;
            Properties.Settings.Default.tcpPort = (uint)tcpPortTxt.Value;
            Properties.Settings.Default.tcpServerChecked = tcpServerRdBtn.Checked;
            SaveProperties();
        }

        private void LoadTcpSettings()
        {
            tcpIpTxt.Text = Properties.Settings.Default.tcpIp;
            tcpPortTxt.Value = (decimal)Properties.Settings.Default.tcpPort;
            tcpServerRdBtn.Checked = Properties.Settings.Default.tcpServerChecked;
            tcpClientRdBtn.Checked = !tcpServerRdBtn.Checked;
            tcpIpTxt.Enabled = tcpClientRdBtn.Checked;
        }

        private void SaveUdpSettings()
        {
            Properties.Settings.Default.udpIp = udpIpTxt.Text;
            Properties.Settings.Default.udpPort = (uint)udpPortTxt.Value;
            Properties.Settings.Default.udpServerChecked = udpServerRdBtn.Checked;
            SaveProperties();
        }

        private void LoadUdpSettings()
        {
            udpIpTxt.Text = Properties.Settings.Default.udpIp;
            udpPortTxt.Value = (decimal)Properties.Settings.Default.udpPort;
            udpServerRdBtn.Checked = Properties.Settings.Default.udpServerChecked;
            udpClientRdBtn.Checked = !udpServerRdBtn.Checked;
            udpIpTxt.Enabled = udpClientRdBtn.Checked;
        }

        private void SaveSerialSettings()
        {
            Properties.Settings.Default.serialBaudRate = serialBaudCmBx.Text;
            Properties.Settings.Default.serialDataBits = (uint)serialDataBitsTxt.Value;
            Properties.Settings.Default.serialParity = serialParityCmBx.Text;
            Properties.Settings.Default.serialStopBits = serialStopBitsCmBx.Text;
            SaveProperties();
        }

        private void LoadSerialSettigns()
        {
            serialBaudCmBx.Text = Properties.Settings.Default.serialBaudRate;
            serialDataBitsTxt.Value = (decimal)Properties.Settings.Default.serialDataBits;
            serialParityCmBx.Text = Properties.Settings.Default.serialParity;
            serialStopBitsCmBx.Text = Properties.Settings.Default.serialStopBits;
        }

        private void SaveProperties()
        {
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
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
                connections_.TCPServer.Close();
                tcpClientRdBtn.Enabled = true;
            }
            else
            {
                connections_.TCPClient.Kill();
                tcpServerRdBtn.Enabled = true;
            }

            tcpIndicatorLbl.BackColor = SystemColors.Control;
            tcpConnectBtn.Enabled = true;
            tcpConnectionStateLbl.Text = "Disconnected";
        }



        private void sendBtn_Click(object sender, EventArgs e)
        {
            SendMsg();
        }

        private void SendMsg()
        {
            var bytes = Encoding.ASCII.GetBytes(textToSendCmBx.Text);
            textToSendCmBx.Items.Add(textToSendCmBx.Text);
            textToSendCmBx.Text = "";

            if (connections_.IsTcpServerInitiated())
                connections_.TCPServer.Send(bytes);

            if (connections_.IsTcpClientInitiated())
                connections_.TCPClient.Send(bytes);

            if (connections_.IsUdpServerInitiated())
                connections_.UDPServer.Send(bytes);

            if (connections_.IsUdpClientInitiated())
                connections_.UDPClient.Send(bytes);

            if (connections_.IsSerialInitiated())
                connections_.Serial.Send(bytes);

            if (connections_.IsSomeConnectionInitiated())
            {
                bytesOutCounter_.Add((uint)bytes.Length);
                BytesCounter.MeasureUnit mUnit = bytesOutCounter_.RecomendedMeasureUnit();
                int processedCounter = (int)bytesOutCounter_.GetProcessedCounter(mUnit);

                bytesOutLbl.BackColor = Color.LimeGreen;
                bytesOutTimer.Enabled = true;
                bytesOutLbl.Text = processedCounter.ToString() + " " + BytesCounter.MeasureUnitToString(mUnit);
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

        private void serialConnectBtn_Click(object sender, EventArgs e)
        {
            SaveSerialSettings();
            string port = serialComCmBx.SelectedItem.ToString();
            int baud = int.Parse(serialBaudCmBx.SelectedItem.ToString());
            StopBits stopBits = SerialCom.StringToStopBits(serialStopBitsCmBx.SelectedItem.ToString());
            int dataBits = (int)serialDataBitsTxt.Value;
            Parity parity = SerialCom.StringToParity(serialParityCmBx.SelectedItem.ToString());

            connections_.InitSerial();
            if (connections_.Serial.Connect(port, baud, parity, dataBits, stopBits))
            {
                serialConnectionStateLbl.Text = "Connected";
                serialIndicatorLbl.BackColor = Color.LimeGreen;
                serialDisconnectBtn.Enabled = true;
                serialConnectBtn.Enabled = false;
                connections_.Serial.Subscribe(OnSerialByteIn);
            }
        }

        private void serialDisconnectBtn_Click(object sender, EventArgs e)
        {
            connections_.Serial.CloseMe();
            serialDisconnectBtn.Enabled = false;
            serialConnectBtn.Enabled = true;
            serialConnectionStateLbl.Text = "Disconnected";
            serialIndicatorLbl.BackColor = SystemColors.Control;
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
            bytesInCounter_.Add((uint)bytes.Length);
            BytesCounter.MeasureUnit mUnit = bytesInCounter_.RecomendedMeasureUnit();
            int processedCounter = (int)bytesInCounter_.GetProcessedCounter(mUnit);

            Invoke((MethodInvoker)delegate
            {
                bytesInLbl.BackColor = Color.LimeGreen;
                bytesInTimer.Enabled = true;
                bytesInLbl.Text = processedCounter.ToString() + " " + BytesCounter.MeasureUnitToString(mUnit);

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


        private void textToSendCmBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                SendMsg();
        }

        private void udpConnectBtn_Click(object sender, EventArgs e)
        {
            SaveUdpSettings();
            bool connected = false;
            if (udpServerRdBtn.Checked)
            {
                connections_.InitUdpServer((int)udpPortTxt.Value);
                connections_.UDPServer.Subscribe(OnUdpByteIn);
                udpClientRdBtn.Enabled = false;
                connected = true;
            }
            else
            {
                connections_.InitUdpClient();
                if (connections_.UDPClient.ConnectTo(udpIpTxt.Text, (int)udpPortTxt.Value))
                {
                    connections_.UDPClient.Subscribe(OnUdpByteIn);
                    udpServerRdBtn.Enabled = false;
                    connected = true;
                }
            }
            if (connected)
            {
                udpConnectBtn.Enabled = false;
                udpDisconnectBtn.Enabled = true;
                udpConnectionStateLbl.Text = "Connected";
                udpIndicatorLbl.BackColor = Color.LimeGreen;
            }
        }

        private void OnUdpByteIn(byte[] bytes)
        {
            AppendBytesToScreens(bytes);
        }

        private void udpServerRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (udpServerRdBtn.Checked)
                udpIpTxt.Enabled = false;
            else
                udpIpTxt.Enabled = true;
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            if (aboutForm_ == null || aboutForm_.IsDisposed)
            {
                aboutForm_ = new AboutForm();
                aboutForm_.Show();
            }
            else
            {
                aboutForm_.Show();
                aboutForm_.Focus();
            }
        }

        private void udpDisconnectBtn_Click(object sender, EventArgs e)
        {
            if (udpServerRdBtn.Checked)
            {
                connections_.UDPServer.Close();
                udpClientRdBtn.Enabled = true;
            }
            else
            {
                connections_.UDPClient.Kill();
                udpServerRdBtn.Enabled = true;
            }

            udpIndicatorLbl.BackColor = SystemColors.Control;
            udpConnectBtn.Enabled = true;
            udpConnectionStateLbl.Text = "Disconnected";
        }

        private void bytesInTimer_Tick(object sender, EventArgs e)
        {
            bytesInLbl.BackColor = SystemColors.Control;
            bytesInTimer.Enabled = false;
        }

        private void bytesOutTimer_Tick(object sender, EventArgs e)
        {
            bytesOutLbl.BackColor = SystemColors.Control;
            bytesOutTimer.Enabled = false;
        }




    }
}
