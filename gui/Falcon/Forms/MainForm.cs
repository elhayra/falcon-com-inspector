﻿/*******************************************************************************
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
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Falcon.Com;
using System.IO.Ports;
using Falcon.Forms;
using Falcon.Utils;
using System.Threading;
using System.IO;
using System.Net.Sockets;
using Falcon.Graph;
using System.Collections.Generic;

namespace Falcon
{
    public partial class MainForm : Form
    {
        private const int MAX_HISTORY_ITEMS = 10;

        private AboutForm aboutForm_;
        private PlotForm graphFrom_;
        private CommandLineForm cliForm_;

        string fileToSendPath_ = "";

        int prevLinesCount_ = 0;

        TxtBoxSearch searcher;

        List<string> connectedSerialPorts;

        BytesCounter bytesOutCounter = new BytesCounter();
        BytesCounter bytesInCounter = new BytesCounter();
        BytesCounter bytesInRateCounter = new BytesCounter();
        BytesCounter bytesOutRateCounter = new BytesCounter();
       

        public MainForm()
        {
            InitializeComponent();

            Application.EnableVisualStyles();

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
            LoadGlobalSettings();

            searcher = new TxtBoxSearch(ref displayTxt);
        }

        /// <summary>
        /// Update serialComCmBx items, and keep existing 
        /// ports at their current index in the list
        /// </summary>
        private void UpdateSerialPorts()
        {
            var t = Task.Run(delegate
            {
                // the following function is a blocking one, therefore must be 
                // called in a seperate thread so GUI won't freeze
                connectedSerialPorts = SerialCom.GetConnectedPortsDetailedStrings();
            });

            if (connectedSerialPorts == null)
                return;

            // create a clone of serialComCmBx.Items to allow
            // modifying serialComCmBx.Items while iterating
            // over its elements
            List<string> portsListClone = new List<string>();
            foreach (string port in serialComCmBx.Items)
                portsListClone.Add(port);

            //remove disconnected ports from combobox
            foreach (string port in portsListClone)
            {
                if (!connectedSerialPorts.Contains(port))
                {
                    serialComCmBx.Items.Remove(port);
                }
            }

            // add new connected ports the combobox
            foreach (string port in connectedSerialPorts)
            {
                if (!serialComCmBx.Items.Contains(port))
                {
                    serialComCmBx.Items.Add(port);
                }
            }

            if (serialComCmBx.Items.Count > 0)
                serialComCmBx.SelectedIndex = 0;
        }

        private void tcpConnectBtn_Click(object sender, EventArgs e)
        {
            if (ConnectionsManager.Inst.IsSomeConnectionInitiated())
            {
                MsgBox.WarningMsg("Multiple Connections Are Not Allowed",
                    "Some other connection type (UDP or Serial) is already open. Close it and try again");
                return;
            }
            ConnectTcp();
        }

        private void ConnectTcp()
        {
            SaveTcpSettings();
            bool connected = false;
            if (tcpServerRdBtn.Checked)
            {
                ConnectionsManager.Inst.InitTcpServer((int)tcpPortTxt.Value);
                if (!ConnectionsManager.Inst.TCPServer.Connect())
                {
                    tcpConnectionStateLbl.BackColor = Color.Tomato;
                    tcpConnectionStateLbl.Text = "Failed";
                }
                else
                {
                    ConnectionsManager.Inst.TCPServer.Subscribe(OnIncomingBytes);
                    ConnectionsManager.Inst.TCPServer.SubscribeToClientsState(OnNewTcpClient);
                    tcpClientRdBtn.Enabled = false;
                    connected = true;
                }
            }
            else
            {
                ConnectionsManager.Inst.InitTcpClient();
                if (ConnectionsManager.Inst.TCPClient.ConnectTo(tcpIpTxt.Text, (int)tcpPortTxt.Value))
                {
                    ConnectionsManager.Inst.TCPClient.Subscribe(OnIncomingBytes);
                    tcpServerRdBtn.Enabled = false;
                    connected = true;
                }
                else
                {
                    MsgBox.WarningMsg("TCP Connection Failed", "Wrong IP or port address");
                }
            }
            if (connected)
            {
                tcpConnectBtn.Enabled = false;
                tcpDisconnectBtn.Enabled = true;
                tcpConnectionStateLbl.Text = "Connected";
                tcpConnectionStateLbl.BackColor = Color.LimeGreen;
                tcpIndicatorLbl.BackColor = Color.LimeGreen;
            }
            else
            {
                tcpConnectionStateLbl.Text = "Failed";
                tcpConnectionStateLbl.BackColor = Color.DarkOrange;
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

        private void LoadGlobalSettings()
        {
            asciiRdbtn.Checked = Properties.Settings.Default.displayASCII;
            bytesRdbtn.Checked = !asciiRdbtn.Checked;
            detailedChkBx.Checked = Properties.Settings.Default.displayDetailed;
            autoScrollChkBx.Checked = Properties.Settings.Default.autoScroll;
            newLineChkBx.Checked = Properties.Settings.Default.newLine;
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
                incomingClientsCountLBl.Text = numOfClients.ToString();
            });
        }

        private void OnIncomingBytes(byte[] bytes)
        {
            if (this.Focused)
                AppendBytesToTerminal(bytes);
        }

        private void tcpDisconnectBtn_Click(object sender, EventArgs e)
        {
            stopSendFile.PerformClick();
            if (tcpServerRdBtn.Checked)
            {
                ConnectionsManager.Inst.TCPServer.Unsubscribe(OnIncomingBytes);
                ConnectionsManager.Inst.TCPServer.Close();
                tcpClientRdBtn.Enabled = true;
                incomingClientsCountLBl.Text = "0";
            }
            else
            {
                ConnectionsManager.Inst.TCPClient.Unsubscribe(OnIncomingBytes);
                ConnectionsManager.Inst.TCPClient.CloseMe();
                tcpServerRdBtn.Enabled = true;
            }
            tcpIndicatorLbl.BackColor = SystemColors.Control;
            tcpConnectBtn.Enabled = true;
            tcpConnectionStateLbl.Text = "Disconnected";
            tcpConnectionStateLbl.BackColor = SystemColors.Control; 
        }



        private void sendBtn_Click(object sender, EventArgs e)
        {
            if (textToSendCmBx.Text == "")
                return;

            if (ConnectionsManager.Inst.IsSomeConnectionInitiated())
            {
                var bytes = Encoding.ASCII.GetBytes(textToSendCmBx.Text);
                PassOutTxtToHistory();
                SendMsg(bytes);
            }
        }

        private void PassOutTxtToHistory()
        {
            if (textToSendCmBx.Items.Count >= MAX_HISTORY_ITEMS) 
                textToSendCmBx.Items.RemoveAt(textToSendCmBx.Items.Count-1); //remove last element
            textToSendCmBx.Items.Insert(0, textToSendCmBx.Text); //push back new element 
            textToSendCmBx.Text = ""; // clean combobox text
        }

       
        /// <summary>
        /// Send message bytes to one of the open connections, and 
        /// present bytes statistics
        /// </summary>
        /// <param name="msg">bytes array</param>
        private void SendMsg(byte [] msg)
        {
            bool send_success = false;
            if (ConnectionsManager.Inst.IsTcpServerInitiated())
            {
                send_success = ConnectionsManager.Inst.TCPServer.Send(msg);
                if (!send_success)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        tcpDisconnectBtn.PerformClick();
                    });
                }
            }
            else if (ConnectionsManager.Inst.IsTcpClientInitiated())
            {
                send_success = ConnectionsManager.Inst.TCPClient.Send(msg);
                if (!send_success)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        tcpDisconnectBtn.PerformClick();
                    });
                }
            }
            else if (ConnectionsManager.Inst.IsUdpServerInitiated())
            {
                send_success = ConnectionsManager.Inst.UDPServer.Send(msg);
                if (!send_success)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        udpDisconnectBtn.PerformClick();
                    });
                }
            }
            else if(ConnectionsManager.Inst.IsUdpClientInitiated())
            {
                send_success = ConnectionsManager.Inst.UDPClient.Send(msg);
                if (!send_success)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        udpDisconnectBtn.PerformClick();
                    });
                }
            }
            else if (ConnectionsManager.Inst.IsSerialInitiated())
            {
                send_success = ConnectionsManager.Inst.Serial.Send(msg);
                if (!send_success)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        serialDisconnectBtn.PerformClick();
                    });
                }
            }

            if (send_success && ConnectionsManager.Inst.IsSomeConnectionInitiated())
            {
                bytesOutCounter.Add((uint)msg.Length);
                BytesCounter.MeasureUnit mUnit = bytesOutCounter.RecomendedMeasureUnit();
                var format = "{0:0}";
                if (mUnit != BytesCounter.MeasureUnit.B)
                    format = "{0:0.00}";
                var processedCounter = String.Format(format, bytesOutCounter.GetProcessedCounter(mUnit));
                Invoke((MethodInvoker)delegate
                {
                    bytesOutLbl.BackColor = Color.LimeGreen;
                    bytesInTimer.Stop();
                    bytesInTimer.Start();
                    bytesOutTimer.Enabled = true;
                    bytesOutLbl.Text = processedCounter + " " + BytesCounter.MeasureUnitToString(mUnit);
                });
            }
        }

        private void clearScreenBtn_Click(object sender, EventArgs e)
        {
            displayTxt.Clear();
            textToSendCmBx.Items.Clear();
            textToSendCmBx.Text = "";
            prevLinesCount_ = 0;
        }

        private void serialConnectBtn_Click(object sender, EventArgs e)
        {
            if (ConnectionsManager.Inst.IsSomeConnectionInitiated())
            {
                MsgBox.WarningMsg("Multiple Connections Are Not Allowed", 
                    "Some other connection type (TCP or UDP) is already open. Close it and try again");
                return;
            }

            // no port was selected
            if (serialComCmBx.Text == "")
            {
                MsgBox.WarningMsg("Serial Connection Failed", "No port was selected");
                serialConnectionStateLbl.Text = "Failed";
                serialConnectionStateLbl.BackColor = Color.Tomato;
                return;
            }

            SaveSerialSettings();
            string detailedPort = serialComCmBx.Text;
            string portName = SerialCom.DetailedToSimplefiedPortName(detailedPort);

            // selected port is not a serial port (doesn't contain 'COM')
            if (portName == null)
            {
                MsgBox.WarningMsg("Serial Connection Failed", "Invalid port");
                serialConnectionStateLbl.Text = "Failed";
                serialConnectionStateLbl.BackColor = Color.Tomato;
                return;
            }
         

            int baud = int.Parse(serialBaudCmBx.SelectedItem.ToString());
            StopBits stopBits = SerialCom.StringToStopBits(serialStopBitsCmBx.SelectedItem.ToString());
            int dataBits = (int)serialDataBitsTxt.Value;
            Parity parity = SerialCom.StringToParity(serialParityCmBx.SelectedItem.ToString());

            ConnectionsManager.Inst.InitSerial();
            if (ConnectionsManager.Inst.Serial.Connect(portName, baud, parity, dataBits, stopBits))
            {
                serialPortLbl.Text = portName;
                serialConnectionStateLbl.Text = "Connected";
                serialConnectionStateLbl.BackColor = Color.LimeGreen;
                serialIndicatorLbl.BackColor = Color.LimeGreen;
                serialDisconnectBtn.Enabled = true;
                serialConnectBtn.Enabled = false;
                ConnectionsManager.Inst.Serial.Subscribe(OnIncomingBytes);
            }
            else
            {
                serialConnectionStateLbl.Text = "Failed";
                serialConnectionStateLbl.BackColor = Color.Tomato;
            }
        }

        private void serialDisconnectBtn_Click(object sender, EventArgs e)
        {
            stopSendFile.PerformClick();
            ConnectionsManager.Inst.Serial.Unsubscribe(OnIncomingBytes);
            var t = Task.Run(delegate
            {
                Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;
                ConnectionsManager.Inst.Serial.CloseMe();
                Thread.CurrentThread.Priority = ThreadPriority.Normal;
            });
            serialDisconnectBtn.Enabled = false;
            serialConnectBtn.Enabled = true;
            serialPortLbl.Text = "-";
            serialConnectionStateLbl.Text = "Disconnected";
            serialConnectionStateLbl.BackColor = SystemColors.Control;
            serialIndicatorLbl.BackColor = SystemColors.Control;
        }
        

        private void AppendBytesToTerminal(byte[] bytes)
        {
            if (bytes.Length == 0)
                return;
            bytesInCounter.Add((uint)bytes.Length);
            BytesCounter.MeasureUnit mUnit = bytesInCounter.RecomendedMeasureUnit();
            var format = "{0:0}";
            if (mUnit != BytesCounter.MeasureUnit.B)
                format = "{0:0.00}";
            var processedCounter = String.Format(format, bytesInCounter.GetProcessedCounter(mUnit));

            Invoke((MethodInvoker)delegate
            {
                try
                {
                    bytesInLbl.BackColor = Color.LimeGreen;
                    bytesInTimer.Stop();
                    bytesInTimer.Start();
                    bytesInTimer.Enabled = true;

                    bytesInLbl.Text = processedCounter + " " + BytesCounter.MeasureUnitToString(mUnit);

                    string displayStr = "";
                    if (detailedChkBx.Checked)
                        displayStr = "[" + Logger.GetTime() + "]: ";

                    if (asciiRdbtn.Checked)
                        displayStr += Encoding.UTF8.GetString(bytes);
                    else //bytesRdbtn.Checked
                    {
                        displayStr += "|";
                        foreach (byte b in bytes)
                        {
                            displayStr += b + "|";
                        }
                    }


                    if (autoScrollChkBx.Checked)
                        displayTxt.AppendText(displayStr);
                    else
                        displayTxt.Text += displayStr;

                    if (newLineChkBx.Checked)
                        displayTxt.AppendText(Environment.NewLine);

                    /* if new line arrived, pass it to graph form */
                    if (graphFrom_ != null &&
                        displayTxt.Lines.Any() &&
                        displayTxt.Lines.Length >= 2 &&
                        displayTxt.Lines.Length != prevLinesCount_)
                    {
                        prevLinesCount_ = displayTxt.Lines.Length;
                        string newLine = displayTxt.Lines[displayTxt.Lines.Length - 2];
                        graphFrom_.OnIncomingData(newLine);
                    }

                }
                catch (ObjectDisposedException exp)
                {
                    return;
                }
            });
        }

        private void WriteLineToTerminal(string txt)
        {
            Invoke((MethodInvoker)delegate
            {
                displayTxt.AppendText("> " + txt + "\n");
                PassOutTxtToHistory();
            });
        }

        private void tcpServerRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            tcpIpTxt.Enabled = tcpClientRdBtn.Checked;
            tcpIpLbl.Enabled = tcpClientRdBtn.Checked;
            incomingClientsLBl.Enabled = tcpServerRdBtn.Checked;

            if (tcpServerRdBtn.Checked)
                tcpIpTxt.Text = NetworkAdderss.GetLocalIPAddress();
        }

        private void udpConnectBtn_Click(object sender, EventArgs e)
        {
            if (ConnectionsManager.Inst.IsSomeConnectionInitiated())
            {
                MsgBox.WarningMsg("Multiple Connections Are Not Allowed",
                    "Some other connection type (TCP or Serial) is already open. Close it and try again");
                return;
            }
            ConnectUdp();
        }

        private void ConnectUdp()
        {
            SaveUdpSettings();
            bool connected = true;
            if (udpServerRdBtn.Checked)
            {
                try
                {
                    ConnectionsManager.Inst.InitUdpServer((int)udpPortTxt.Value);
                }
                catch (SocketException exp)
                {
                    MsgBox.ErrorMsg("UDP Server Error", exp.Message);
                    connected = false;
                }
                if (connected)
                {
                    ConnectionsManager.Inst.UDPServer.Subscribe(OnIncomingBytes);
                    udpClientRdBtn.Enabled = false;
                }
            }
            else
            {
                ConnectionsManager.Inst.InitUdpClient();
                if (ConnectionsManager.Inst.UDPClient.ConnectTo(udpIpTxt.Text, (int)udpPortTxt.Value))
                {
                    ConnectionsManager.Inst.UDPClient.Subscribe(OnIncomingBytes);
                    udpServerRdBtn.Enabled = false;
                    connected = true;
                }
                else
                {
                    MsgBox.WarningMsg("UDP Connection Failed", "Wrong IP or port address");
                }
            }
            if (connected)
            {
                udpConnectBtn.Enabled = false;
                udpDisconnectBtn.Enabled = true;
                udpConnectionStateLbl.Text = "Connected";
                udpConnectionStateLbl.BackColor = Color.LimeGreen;
                udpIndicatorLbl.BackColor = Color.LimeGreen;
            }
            else
            {
                udpConnectionStateLbl.Text = "Failed";
                udpConnectionStateLbl.BackColor = Color.DarkOrange;
            }
        }

        private void udpServerRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            udpIpTxt.Enabled = !udpServerRdBtn.Checked;
            if (udpServerRdBtn.Checked)
                udpIpTxt.Text = NetworkAdderss.GetLocalIPAddress();

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
            stopSendFile.PerformClick();
            if (udpServerRdBtn.Checked)
            {
                ConnectionsManager.Inst.UDPServer.Unsubscribe(OnIncomingBytes);
                ConnectionsManager.Inst.UDPServer.Close();
                udpClientRdBtn.Enabled = true;
            }
            else
            {
                ConnectionsManager.Inst.UDPClient.Unsubscribe(OnIncomingBytes);
                ConnectionsManager.Inst.UDPClient.CloseMe();
                udpServerRdBtn.Enabled = true;
            }
            udpIndicatorLbl.BackColor = SystemColors.Control;
            udpConnectBtn.Enabled = true;
            udpConnectionStateLbl.Text = "Disconnected";
            udpConnectionStateLbl.BackColor = SystemColors.Control;
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

        private void udpIpTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                ConnectUdp();
        }

        private void udpPortTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                ConnectUdp();
        }

        private void tcpIpTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                ConnectTcp();
        }

        private void tcpPortTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                ConnectTcp();
        }

        private void graphToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void bytesRateTimer_Tick(object sender, EventArgs e)
        {
            ulong newBytesCount = bytesInCounter.GetRawCounter();
            bytesInRateCounter.SetCounter(newBytesCount - bytesInRateCounter.PrevCount);
            bytesInRateCounter.PrevCount = newBytesCount;

            BytesCounter.MeasureUnit mUnit = bytesInRateCounter.RecomendedMeasureUnit();
            var format = "{0:0}";
            if (mUnit != BytesCounter.MeasureUnit.B)
                format = "{0:0.00}";
            var processedCounter = String.Format(format, bytesInRateCounter.GetProcessedCounter(mUnit));
            Invoke((MethodInvoker)delegate
            {
                receivingRateLbl.Text = processedCounter + " " + BytesCounter.MeasureUnitToString(mUnit) + "/s";
            });
        }

        private void serialComRefreshBtn_Click(object sender, EventArgs e)
        {
            UpdateSerialPorts();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            bytesInLbl.Text = "0 B";
            bytesOutLbl.Text = "0 B";
            bytesInCounter.Reset();
            bytesOutCounter.Reset();
            bytesInRateCounter.PrevCount = 0;
        }

        private void sendFileBtn_Click(object sender, EventArgs e)
        {
            fileToSendPath_ = FileTools.ChooseFilePath("txt(*.*) | *.*");
            if (fileToSendPath_ != "")
            {
                sendFileBtn.Enabled = false;
                stopSendFile.Enabled = true;
                sendFileWorker.RunWorkerAsync();
            }
            else
                MsgBox.ErrorMsg("File Error", "No file was selected, cancelling send process");
        }

        // send selected file to open connection
        private void sendFileWorker_DoWork(object sender, DoWorkEventArgs e)
        { 
            var lines = File.ReadAllLines(@fileToSendPath_);
            fileToSendPath_ = ""; 
            int iter_count = 1;

            foreach (var line in lines)
            {
                double progress = iter_count / lines.Length * 100.0;
                sendFileWorker.ReportProgress((int)progress);

                SendMsg(Encoding.ASCII.GetBytes(line));

                iter_count++;

                if (sendFileWorker.CancellationPending)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        sendFileLbl.Text = "Canceled";
                    });
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void sendFileWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            sendFileLbl.Text = "Sending File: " + e.ProgressPercentage.ToString() + "%";
            if (e.ProgressPercentage == 100)
            {
                sendFileLbl.Text = "Done";
                stopSendFile.Enabled = false;
                sendFileBtn.Enabled = true;
            }
        }

        private void stopSendFile_Click(object sender, EventArgs e)
        {
            sendFileBtn.Enabled = true;
            stopSendFile.Enabled = false;
            sendFileWorker.CancelAsync();
        }
        
        // enable "select all" in display
        private void dataInScreenTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                displayTxt.SelectAll();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        // calculate and show sent bytes rate
        private void bytesOutRateTimer_Tick(object sender, EventArgs e)
        {
            ulong newBytesCount = bytesOutCounter.GetRawCounter();
            bytesOutRateCounter.SetCounter(newBytesCount - bytesOutRateCounter.PrevCount);
            bytesOutRateCounter.PrevCount = newBytesCount;

            BytesCounter.MeasureUnit mUnit = bytesOutRateCounter.RecomendedMeasureUnit();
            var format = "{0:0}";
            if (mUnit != BytesCounter.MeasureUnit.B)
                format = "{0:0.00}";
            var processedCounter = String.Format(format, bytesOutRateCounter.GetProcessedCounter(mUnit));
            Invoke((MethodInvoker)delegate
            {
                sendingRateLbl.Text = processedCounter + " " + BytesCounter.MeasureUnitToString(mUnit) + "/s";
            });
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (searcher.Search(searchTxt.Text))
                searchNextBtn.Enabled = true;
        }

        private void searchFwdBtn_Click(object sender, EventArgs e)
        {
            if (!searcher.SearchForward(searchTxt.Text))
            {
                searchNextBtn.Enabled = false;
            }
        }

        private void asciiRdbtn_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.displayASCII = true;
            SaveProperties();
        }

        private void bytesRdbtn_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.displayASCII = false;
            SaveProperties();
        }

        private void autoScrollChkBx_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.autoScroll = autoScrollChkBx.Checked;
            SaveProperties();
        }

        private void detailedChkBx_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.displayDetailed = detailedChkBx.Checked;
            SaveProperties();
        }

        private void newLineChkBx_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.newLine = newLineChkBx.Checked;
            SaveProperties();
        }

        /// <summary>
        /// auto update serialComCmBx with serial ports data
        /// </summary>
        private void serialPortsTimer_Tick(object sender, EventArgs e)
        {
           UpdateSerialPorts();
        }

        private void dataPlotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (graphFrom_ == null || graphFrom_.IsDisposed)
            {
                ChartManager.Inst.Reset();
                graphFrom_ = new PlotForm();
                graphFrom_.Show();
            }
            else
            {
                graphFrom_.Show();
                graphFrom_.Focus();
            }
        }

        private void commandLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cliForm_ == null || cliForm_.IsDisposed)
            {
                ChartManager.Inst.Reset();
                cliForm_ = new CommandLineForm();
                cliForm_.Show();
            }
            else
            {
                cliForm_.Show();
                cliForm_.Focus();
            }
        }
    }
}
