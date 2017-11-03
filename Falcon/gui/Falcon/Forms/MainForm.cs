﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

namespace Falcon
{
    public partial class MainForm : Form
    {
        private AboutForm aboutForm_;
        private GraphForm graphFrom_;
        private PreferencesForm preferencesForm_;

        Ssh ssh_;

        string fileToSendPath_ = "";

        int prevLinesCount_ = 0;

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
            serialComCmBx.Items.Clear();
            var availablePorts = SerialCom.GetConnectedPorts();
            serialComCmBx.Items.AddRange(availablePorts);
            if (serialComCmBx.Items.Count > 0)
                serialComCmBx.SelectedIndex = 0;
        }

        private void tcpConnectBtn_Click(object sender, EventArgs e)
        {
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
                    ConnectionsManager.Inst.TCPServer.SubscribeToMsgs(OnTcpByteIn);
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
                    ConnectionsManager.Inst.TCPClient.Subscribe(OnTcpByteIn);
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

        private void OnTcpByteIn(byte[] bytes)
        {
            AppendBytesToTerminal(bytes);
        }

        private void tcpDisconnectBtn_Click(object sender, EventArgs e)
        {
            stopSendFile.PerformClick();
            if (tcpServerRdBtn.Checked)
            {
                ConnectionsManager.Inst.TCPServer.Close();
                tcpClientRdBtn.Enabled = true;
                incomingClientsCountLBl.Text = "0";
            }
            else
            {
                ConnectionsManager.Inst.TCPClient.Kill();
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

            if (ssh_ != null) /* terminal is in ssh mode (ssh connected) */
            {
                ssh_.RunCommand(textToSendCmBx.Text);
                if (textToSendCmBx.Text == "exit")
                {
                    clearScreenBtn.PerformClick();
                    WriteLnToTerminal("ssh session terminated");
                    ssh_ = null;
                }
                PassOutTxtToHistory();
                return;
            }

            /* if no communication is open, handle text as a command */
            /* line otherwise, send msg on opened communication line */
            if (!ConnectionsManager.Inst.IsSomeConnectionInitiated())
            {
                string [] cmdArgs = new string[5];
                string cmdAnswer = "";
                CommandParser.Type cmdType = CommandParser.Type.NONE;
                bool validCmd;
                validCmd = CommandParser.Parse(textToSendCmBx.Text, ref cmdAnswer, ref cmdType, ref cmdArgs);

                if (validCmd)
                {
                    switch (cmdType)
                    {
                        case CommandParser.Type.AUTO_SCROLL:
                            string flag = cmdArgs[AutoScrollArg.FLAG_INDX];
                            bool value = flag == "on" ? true : false;
                            autoScrollChkBx.Checked = value;
                            break;
                        case CommandParser.Type.RESET:
                            resetBtn.PerformClick();
                            break;
                        case CommandParser.Type.CLEAR:
                            clearScreenBtn.PerformClick();
                            break;
                        case CommandParser.Type.PING:
                            break;
                        case CommandParser.Type.SSH:
                            bool a = ConnectSsh(cmdArgs[SshArg.HOSTADDR_INDX],
                                                   cmdArgs[SshArg.USERNAME_INDX],
                                                   cmdArgs[SshArg.PASS_INDX],
                                                   ref cmdAnswer,
                                                   ref ssh_);
                            break;
                        case CommandParser.Type.NONE:
                            break;
                    }
                }
                WriteLnToTerminal(cmdAnswer);
            }
            else
            {
                var bytes = Encoding.ASCII.GetBytes(textToSendCmBx.Text);
                PassOutTxtToHistory();
                SendMsg(bytes);
            }
        }

        private void PassOutTxtToHistory()
        {
            if (textToSendCmBx.Items.Count >= 10) //TODO: MAKE MAX HISTROY ITEMS A SETTING //////////////////////////////////
                textToSendCmBx.Items.RemoveAt(textToSendCmBx.Items.Count-1); //remove last element
            textToSendCmBx.Items.Insert(0, textToSendCmBx.Text); //push back new element 
            textToSendCmBx.Text = "";
        }

       

        private void SendMsg(byte [] msg)
        {
            bool send_success = false;
            if (ConnectionsManager.Inst.IsTcpServerInitiated())
                send_success = ConnectionsManager.Inst.TCPServer.Send(msg);

            if (ConnectionsManager.Inst.IsTcpClientInitiated())
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

            if (ConnectionsManager.Inst.IsUdpServerInitiated())
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

            if (ConnectionsManager.Inst.IsUdpClientInitiated())
                send_success = ConnectionsManager.Inst.UDPClient.Send(msg);

            if (ConnectionsManager.Inst.IsSerialInitiated())
                send_success = ConnectionsManager.Inst.Serial.Send(msg);

            if (send_success && ConnectionsManager.Inst.IsSomeConnectionInitiated())
            {
                ConnectionsManager.Inst.BytesOutCounter.Add((uint)msg.Length);
                BytesCounter.MeasureUnit mUnit = ConnectionsManager.Inst.BytesOutCounter.RecomendedMeasureUnit();
                var format = "{0:0}";
                if (mUnit != BytesCounter.MeasureUnit.B)
                    format = "{0:0.00}";
                var processedCounter = String.Format(format, ConnectionsManager.Inst.BytesOutCounter.GetProcessedCounter(mUnit));
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
            dataInScreenTxt.Clear();
            textToSendCmBx.Items.Clear();
            textToSendCmBx.Text = "";
            prevLinesCount_ = 0;
        }

        private void serialConnectBtn_Click(object sender, EventArgs e)
        {
            SaveSerialSettings();
            string port = serialComCmBx.Text;
            bool failed = false;
            if (port == "")
            {
                MsgBox.WarningMsg("Serial Connection Failed", "No port was selected");
                serialConnectionStateLbl.Text = "Failed";
                serialConnectionStateLbl.BackColor = Color.Tomato;
                return;
            }
            int baud = int.Parse(serialBaudCmBx.SelectedItem.ToString());
            StopBits stopBits = SerialCom.StringToStopBits(serialStopBitsCmBx.SelectedItem.ToString());
            int dataBits = (int)serialDataBitsTxt.Value;
            Parity parity = SerialCom.StringToParity(serialParityCmBx.SelectedItem.ToString());

            ConnectionsManager.Inst.InitSerial();
            if (ConnectionsManager.Inst.Serial.Connect(port, baud, parity, dataBits, stopBits))
            {
                serialConnectionStateLbl.Text = "Connected";
                serialConnectionStateLbl.BackColor = Color.LimeGreen;
                serialIndicatorLbl.BackColor = Color.LimeGreen;
                serialDisconnectBtn.Enabled = true;
                serialConnectBtn.Enabled = false;
                ConnectionsManager.Inst.Serial.Subscribe(OnSerialByteIn);
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
            var t = Task.Run(delegate
            {
                Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;
                ConnectionsManager.Inst.Serial.CloseMe();
                Thread.CurrentThread.Priority = ThreadPriority.Normal;
            });
            serialDisconnectBtn.Enabled = false;
            serialConnectBtn.Enabled = true;
            serialConnectionStateLbl.Text = "Disconnected";
            serialConnectionStateLbl.BackColor = SystemColors.Control;
            serialIndicatorLbl.BackColor = SystemColors.Control;
        }

        private void OnSerialByteIn(byte[] bytes)
        {
            AppendBytesToTerminal(bytes);            
        }

        private void AppendBytesToTerminal(byte[] bytes)
        {
            if (bytes.Length == 0)
                return;
            ConnectionsManager.Inst.BytesInCounter.Add((uint)bytes.Length);
            BytesCounter.MeasureUnit mUnit = ConnectionsManager.Inst.BytesInCounter.RecomendedMeasureUnit();
            var format = "{0:0}";
            if (mUnit != BytesCounter.MeasureUnit.B)
                format = "{0:0.00}";
            var processedCounter = String.Format(format, ConnectionsManager.Inst.BytesInCounter.GetProcessedCounter(mUnit));

            Invoke((MethodInvoker)delegate
            {
                try
                {
                    bytesInLbl.BackColor = Color.LimeGreen;
                    bytesInTimer.Stop();
                    bytesInTimer.Start();
                    bytesInTimer.Enabled = true;

                    bytesInLbl.Text = processedCounter + " " + BytesCounter.MeasureUnitToString(mUnit);

                    string bytesString = System.Text.Encoding.UTF8.GetString(bytes);
                    if (autoScrollChkBx.Checked)
                        dataInScreenTxt.AppendText(bytesString);
                    else
                        dataInScreenTxt.Text += bytesString;

                    /* if new line arrived, pass it to graph form */
                    if (graphFrom_ != null &&
                        dataInScreenTxt.Lines.Any() &&
                        dataInScreenTxt.Lines.Length >= 2 &&
                        dataInScreenTxt.Lines.Length != prevLinesCount_)
                    {
                        prevLinesCount_ = dataInScreenTxt.Lines.Length;
                        string newLine = dataInScreenTxt.Lines[dataInScreenTxt.Lines.Length - 2];
                        graphFrom_.OnIncomingData(newLine);
                    }

                }
                catch (ObjectDisposedException exp)
                {
                    return;
                }
            });
        }

        private void WriteLnToTerminal(string txt)
        {
            Invoke((MethodInvoker)delegate
            {
                dataInScreenTxt.AppendText("> " + txt + "\n");
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
                    ConnectionsManager.Inst.UDPServer.Subscribe(OnUdpByteIn);
                    udpClientRdBtn.Enabled = false;
                }
            }
            else
            {
                ConnectionsManager.Inst.InitUdpClient();
                if (ConnectionsManager.Inst.UDPClient.ConnectTo(udpIpTxt.Text, (int)udpPortTxt.Value))
                {
                    ConnectionsManager.Inst.UDPClient.Subscribe(OnUdpByteIn);
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

        private void OnUdpByteIn(byte[] bytes)
        {
            AppendBytesToTerminal(bytes);
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
                ConnectionsManager.Inst.UDPServer.Close();
                udpClientRdBtn.Enabled = true;
            }
            else
            {
                ConnectionsManager.Inst.UDPClient.Kill();
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
            if (graphFrom_ == null || graphFrom_.IsDisposed)
            {
                ChartManager.Inst.Reset();
                graphFrom_ = new GraphForm(ref dataInScreenTxt);
                graphFrom_.Show();
            }
            else
            {
                graphFrom_.Show();
                graphFrom_.Focus();
            }
        }

        private void bytesRateTimer_Tick(object sender, EventArgs e)
        {
            ulong newBytesCount = ConnectionsManager.Inst.BytesInCounter.GetRawCounter();
            ConnectionsManager.Inst.BytesRateCounter.SetCounter(newBytesCount - ConnectionsManager.Inst.PrevBytesCount);
            ConnectionsManager.Inst.PrevBytesCount = newBytesCount;

            BytesCounter.MeasureUnit mUnit = ConnectionsManager.Inst.BytesRateCounter.RecomendedMeasureUnit();
            var format = "{0:0}";
            if (mUnit != BytesCounter.MeasureUnit.B)
                format = "{0:0.00}";
            var processedCounter = String.Format(format, ConnectionsManager.Inst.BytesRateCounter.GetProcessedCounter(mUnit));
            Invoke((MethodInvoker)delegate
            {
                receivingRateLbl.Text = processedCounter + " " + BytesCounter.MeasureUnitToString(mUnit) + "/s";
            });
        }

        private void serialComRefreshBtn_Click(object sender, EventArgs e)
        {
            UpdateSerialPorts();
        }

        private void preferencesBtn_Click(object sender, EventArgs e)
        {
            if (preferencesForm_ == null || preferencesForm_.IsDisposed)
            {
                preferencesForm_ = new PreferencesForm();
                preferencesForm_.Show();
            }
            else
            {
                preferencesForm_.Show();
                preferencesForm_.Focus();
            }
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            bytesInLbl.Text = "0 B";
            bytesOutLbl.Text = "0 B";
            ConnectionsManager.Inst.BytesInCounter.Reset();
            ConnectionsManager.Inst.BytesOutCounter.Reset();
            ConnectionsManager.Inst.PrevBytesCount = 0;
        }

        private bool ConnectSsh(string hostAddrs, string userName, string password, ref string reply, ref Ssh ssh)
        {
            ssh = new Ssh();
            ssh.Subscribe(OnIncomingSsh);
            if (ssh.Connect(hostAddrs, userName, password, ref reply))
            {
                ssh.CreateShellStream("terminal", 80, 24, 800, 600, 1024); //TODO: CHANGE THIS ACCORDING TO WINDOW SIZE, FOR LONG LINES PRINTING
                return true;
            }
            return false;
        }

        private void OnIncomingSsh(string msg)
        {
            Invoke((MethodInvoker)delegate
            {
                if (autoScrollChkBx.Checked)
                    dataInScreenTxt.AppendText(msg);
                else
                    dataInScreenTxt.Text += msg;
            });
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

        private void sendFileWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var lines = File.ReadAllLines(@fileToSendPath_);
            fileToSendPath_ = ""; 
            int iter_count = 1;

            foreach (var line in lines)
            {
                double progress = (double)iter_count / (double)lines.Length * 100;
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
                //else
                //    Thread.Sleep(1);
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
    }
}