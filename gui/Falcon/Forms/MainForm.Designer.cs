namespace Falcon
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.incomingClientsCountLBl = new System.Windows.Forms.Label();
            this.tcpConnectBtn = new System.Windows.Forms.Button();
            this.tcpConnectionStateLbl = new System.Windows.Forms.Label();
            this.tcpDisconnectBtn = new System.Windows.Forms.Button();
            this.incomingClientsLBl = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tcpServerRdBtn = new System.Windows.Forms.RadioButton();
            this.tcpClientRdBtn = new System.Windows.Forms.RadioButton();
            this.tcpIpLbl = new System.Windows.Forms.Label();
            this.tcpIpTxt = new System.Windows.Forms.TextBox();
            this.tcpServerPortLbl = new System.Windows.Forms.Label();
            this.tcpPortTxt = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.udpConnectBtn = new System.Windows.Forms.Button();
            this.udpConnectionStateLbl = new System.Windows.Forms.Label();
            this.udpDisconnectBtn = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.udpServerRdBtn = new System.Windows.Forms.RadioButton();
            this.udpClientRdBtn = new System.Windows.Forms.RadioButton();
            this.udpIpLbl = new System.Windows.Forms.Label();
            this.udpIpTxt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.udpPortTxt = new System.Windows.Forms.NumericUpDown();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.serialConnectBtn = new System.Windows.Forms.Button();
            this.serialDisconnectBtn = new System.Windows.Forms.Button();
            this.serialConnectionStateLbl = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.serialPortLbl = new System.Windows.Forms.Label();
            this.serialComRefreshBtn = new System.Windows.Forms.Button();
            this.serialParityCmBx = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.serialStopBitsCmBx = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.serialBaudCmBx = new System.Windows.Forms.ComboBox();
            this.serialDataBitsTxt = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.serialComCmBx = new System.Windows.Forms.ComboBox();
            this.receivingRateLbl = new System.Windows.Forms.Label();
            this.bytesOutLbl = new System.Windows.Forms.Label();
            this.bytesInLbl = new System.Windows.Forms.Label();
            this.labll = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.clearScreenBtn = new System.Windows.Forms.Button();
            this.sendBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.commandLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataPlotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoScrollChkBx = new System.Windows.Forms.CheckBox();
            this.displayTxt = new System.Windows.Forms.TextBox();
            this.textToSendCmBx = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.sendingRateLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.serialIndicatorLbl = new System.Windows.Forms.Label();
            this.udpIndicatorLbl = new System.Windows.Forms.Label();
            this.tcpIndicatorLbl = new System.Windows.Forms.Label();
            this.bytesInTimer = new System.Windows.Forms.Timer(this.components);
            this.bytesOutTimer = new System.Windows.Forms.Timer(this.components);
            this.bytesInRateTimer = new System.Windows.Forms.Timer(this.components);
            this.resetBtn = new System.Windows.Forms.Button();
            this.sendFileBtn = new System.Windows.Forms.Button();
            this.sendFileLbl = new System.Windows.Forms.Label();
            this.sendFileWorker = new System.ComponentModel.BackgroundWorker();
            this.stopSendFile = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lineEndingCmBx = new System.Windows.Forms.ComboBox();
            this.formatCmBx = new System.Windows.Forms.ComboBox();
            this.detailedChkBx = new System.Windows.Forms.CheckBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.searchTxt = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.bytesOutRateTimer = new System.Windows.Forms.Timer(this.components);
            this.serialPortsTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.logPathLbl = new System.Windows.Forms.Label();
            this.logPathBtn = new System.Windows.Forms.Button();
            this.logStartBtn = new System.Windows.Forms.Button();
            this.logStopBtn = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.pkgSizeLbl = new System.Windows.Forms.Label();
            this.pkgHeaderLbl = new System.Windows.Forms.Label();
            this.pkgParseChkBx = new System.Windows.Forms.CheckBox();
            this.pkgSendBtn = new System.Windows.Forms.Button();
            this.pkgLoadBtn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcpPortTxt)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udpPortTxt)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serialDataBitsTxt)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(10, 35);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(130, 523);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(122, 497);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "TCP";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.incomingClientsCountLBl);
            this.groupBox5.Controls.Add(this.tcpConnectBtn);
            this.groupBox5.Controls.Add(this.tcpConnectionStateLbl);
            this.groupBox5.Controls.Add(this.tcpDisconnectBtn);
            this.groupBox5.Controls.Add(this.incomingClientsLBl);
            this.groupBox5.Location = new System.Drawing.Point(6, 158);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(110, 144);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Connection";
            // 
            // incomingClientsCountLBl
            // 
            this.incomingClientsCountLBl.AutoSize = true;
            this.incomingClientsCountLBl.Enabled = false;
            this.incomingClientsCountLBl.Location = new System.Drawing.Point(47, 122);
            this.incomingClientsCountLBl.Name = "incomingClientsCountLBl";
            this.incomingClientsCountLBl.Size = new System.Drawing.Size(13, 13);
            this.incomingClientsCountLBl.TabIndex = 17;
            this.incomingClientsCountLBl.Text = "0";
            // 
            // tcpConnectBtn
            // 
            this.tcpConnectBtn.Location = new System.Drawing.Point(6, 19);
            this.tcpConnectBtn.Name = "tcpConnectBtn";
            this.tcpConnectBtn.Size = new System.Drawing.Size(98, 23);
            this.tcpConnectBtn.TabIndex = 14;
            this.tcpConnectBtn.Text = "Connect";
            this.tcpConnectBtn.UseVisualStyleBackColor = true;
            this.tcpConnectBtn.Click += new System.EventHandler(this.tcpConnectBtn_Click);
            // 
            // tcpConnectionStateLbl
            // 
            this.tcpConnectionStateLbl.AutoSize = true;
            this.tcpConnectionStateLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tcpConnectionStateLbl.Location = new System.Drawing.Point(8, 74);
            this.tcpConnectionStateLbl.MaximumSize = new System.Drawing.Size(93, 19);
            this.tcpConnectionStateLbl.MinimumSize = new System.Drawing.Size(93, 19);
            this.tcpConnectionStateLbl.Name = "tcpConnectionStateLbl";
            this.tcpConnectionStateLbl.Size = new System.Drawing.Size(93, 19);
            this.tcpConnectionStateLbl.TabIndex = 18;
            this.tcpConnectionStateLbl.Text = "Not Connected";
            this.tcpConnectionStateLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tcpDisconnectBtn
            // 
            this.tcpDisconnectBtn.Enabled = false;
            this.tcpDisconnectBtn.Location = new System.Drawing.Point(6, 45);
            this.tcpDisconnectBtn.Name = "tcpDisconnectBtn";
            this.tcpDisconnectBtn.Size = new System.Drawing.Size(98, 23);
            this.tcpDisconnectBtn.TabIndex = 15;
            this.tcpDisconnectBtn.Text = "Disconnect";
            this.tcpDisconnectBtn.UseVisualStyleBackColor = true;
            this.tcpDisconnectBtn.Click += new System.EventHandler(this.tcpDisconnectBtn_Click);
            // 
            // incomingClientsLBl
            // 
            this.incomingClientsLBl.AutoSize = true;
            this.incomingClientsLBl.Enabled = false;
            this.incomingClientsLBl.Location = new System.Drawing.Point(11, 103);
            this.incomingClientsLBl.Name = "incomingClientsLBl";
            this.incomingClientsLBl.Size = new System.Drawing.Size(87, 13);
            this.incomingClientsLBl.TabIndex = 16;
            this.incomingClientsLBl.Text = "Incoming Clients:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tcpServerRdBtn);
            this.groupBox3.Controls.Add(this.tcpClientRdBtn);
            this.groupBox3.Controls.Add(this.tcpIpLbl);
            this.groupBox3.Controls.Add(this.tcpIpTxt);
            this.groupBox3.Controls.Add(this.tcpServerPortLbl);
            this.groupBox3.Controls.Add(this.tcpPortTxt);
            this.groupBox3.Location = new System.Drawing.Point(6, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(110, 149);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Settings";
            // 
            // tcpServerRdBtn
            // 
            this.tcpServerRdBtn.AutoSize = true;
            this.tcpServerRdBtn.Checked = true;
            this.tcpServerRdBtn.Location = new System.Drawing.Point(6, 19);
            this.tcpServerRdBtn.Name = "tcpServerRdBtn";
            this.tcpServerRdBtn.Size = new System.Drawing.Size(56, 17);
            this.tcpServerRdBtn.TabIndex = 8;
            this.tcpServerRdBtn.TabStop = true;
            this.tcpServerRdBtn.Text = "Server";
            this.tcpServerRdBtn.UseVisualStyleBackColor = true;
            this.tcpServerRdBtn.CheckedChanged += new System.EventHandler(this.tcpServerRdBtn_CheckedChanged);
            // 
            // tcpClientRdBtn
            // 
            this.tcpClientRdBtn.AutoSize = true;
            this.tcpClientRdBtn.Location = new System.Drawing.Point(6, 42);
            this.tcpClientRdBtn.Name = "tcpClientRdBtn";
            this.tcpClientRdBtn.Size = new System.Drawing.Size(51, 17);
            this.tcpClientRdBtn.TabIndex = 9;
            this.tcpClientRdBtn.Text = "Client";
            this.tcpClientRdBtn.UseVisualStyleBackColor = true;
            this.tcpClientRdBtn.CheckedChanged += new System.EventHandler(this.tcpClientRdBtn_CheckedChanged);
            // 
            // tcpIpLbl
            // 
            this.tcpIpLbl.AutoSize = true;
            this.tcpIpLbl.Enabled = false;
            this.tcpIpLbl.Location = new System.Drawing.Point(4, 65);
            this.tcpIpLbl.Name = "tcpIpLbl";
            this.tcpIpLbl.Size = new System.Drawing.Size(54, 13);
            this.tcpIpLbl.TabIndex = 10;
            this.tcpIpLbl.Text = "Server IP:";
            // 
            // tcpIpTxt
            // 
            this.tcpIpTxt.Enabled = false;
            this.tcpIpTxt.Location = new System.Drawing.Point(6, 81);
            this.tcpIpTxt.Name = "tcpIpTxt";
            this.tcpIpTxt.Size = new System.Drawing.Size(98, 20);
            this.tcpIpTxt.TabIndex = 13;
            this.tcpIpTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tcpIpTxt_KeyPress);
            // 
            // tcpServerPortLbl
            // 
            this.tcpServerPortLbl.AutoSize = true;
            this.tcpServerPortLbl.Location = new System.Drawing.Point(3, 104);
            this.tcpServerPortLbl.Name = "tcpServerPortLbl";
            this.tcpServerPortLbl.Size = new System.Drawing.Size(63, 13);
            this.tcpServerPortLbl.TabIndex = 11;
            this.tcpServerPortLbl.Text = "Server Port:";
            // 
            // tcpPortTxt
            // 
            this.tcpPortTxt.Location = new System.Drawing.Point(6, 120);
            this.tcpPortTxt.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.tcpPortTxt.Name = "tcpPortTxt";
            this.tcpPortTxt.Size = new System.Drawing.Size(98, 20);
            this.tcpPortTxt.TabIndex = 12;
            this.tcpPortTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tcpPortTxt_KeyPress);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(122, 497);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "UDP";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.udpConnectBtn);
            this.groupBox6.Controls.Add(this.udpConnectionStateLbl);
            this.groupBox6.Controls.Add(this.udpDisconnectBtn);
            this.groupBox6.Location = new System.Drawing.Point(6, 163);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(110, 104);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Connection";
            // 
            // udpConnectBtn
            // 
            this.udpConnectBtn.Location = new System.Drawing.Point(6, 19);
            this.udpConnectBtn.Name = "udpConnectBtn";
            this.udpConnectBtn.Size = new System.Drawing.Size(98, 23);
            this.udpConnectBtn.TabIndex = 14;
            this.udpConnectBtn.Text = "Connect";
            this.udpConnectBtn.UseVisualStyleBackColor = true;
            this.udpConnectBtn.Click += new System.EventHandler(this.udpConnectBtn_Click);
            // 
            // udpConnectionStateLbl
            // 
            this.udpConnectionStateLbl.AutoSize = true;
            this.udpConnectionStateLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.udpConnectionStateLbl.Location = new System.Drawing.Point(8, 78);
            this.udpConnectionStateLbl.MaximumSize = new System.Drawing.Size(93, 19);
            this.udpConnectionStateLbl.MinimumSize = new System.Drawing.Size(93, 19);
            this.udpConnectionStateLbl.Name = "udpConnectionStateLbl";
            this.udpConnectionStateLbl.Size = new System.Drawing.Size(93, 19);
            this.udpConnectionStateLbl.TabIndex = 18;
            this.udpConnectionStateLbl.Text = "Not Connected";
            this.udpConnectionStateLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // udpDisconnectBtn
            // 
            this.udpDisconnectBtn.Enabled = false;
            this.udpDisconnectBtn.Location = new System.Drawing.Point(6, 48);
            this.udpDisconnectBtn.Name = "udpDisconnectBtn";
            this.udpDisconnectBtn.Size = new System.Drawing.Size(98, 23);
            this.udpDisconnectBtn.TabIndex = 15;
            this.udpDisconnectBtn.Text = "Disconnect";
            this.udpDisconnectBtn.UseVisualStyleBackColor = true;
            this.udpDisconnectBtn.Click += new System.EventHandler(this.udpDisconnectBtn_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.udpServerRdBtn);
            this.groupBox7.Controls.Add(this.udpClientRdBtn);
            this.groupBox7.Controls.Add(this.udpIpLbl);
            this.groupBox7.Controls.Add(this.udpIpTxt);
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Controls.Add(this.udpPortTxt);
            this.groupBox7.Location = new System.Drawing.Point(6, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(110, 153);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Settings";
            // 
            // udpServerRdBtn
            // 
            this.udpServerRdBtn.AutoSize = true;
            this.udpServerRdBtn.Checked = true;
            this.udpServerRdBtn.Location = new System.Drawing.Point(6, 19);
            this.udpServerRdBtn.Name = "udpServerRdBtn";
            this.udpServerRdBtn.Size = new System.Drawing.Size(56, 17);
            this.udpServerRdBtn.TabIndex = 8;
            this.udpServerRdBtn.TabStop = true;
            this.udpServerRdBtn.Text = "Server";
            this.udpServerRdBtn.UseVisualStyleBackColor = true;
            this.udpServerRdBtn.CheckedChanged += new System.EventHandler(this.udpServerRdBtn_CheckedChanged);
            // 
            // udpClientRdBtn
            // 
            this.udpClientRdBtn.AutoSize = true;
            this.udpClientRdBtn.Location = new System.Drawing.Point(6, 42);
            this.udpClientRdBtn.Name = "udpClientRdBtn";
            this.udpClientRdBtn.Size = new System.Drawing.Size(51, 17);
            this.udpClientRdBtn.TabIndex = 9;
            this.udpClientRdBtn.Text = "Client";
            this.udpClientRdBtn.UseVisualStyleBackColor = true;
            this.udpClientRdBtn.CheckedChanged += new System.EventHandler(this.udpClientRdBtn_CheckedChanged);
            // 
            // udpIpLbl
            // 
            this.udpIpLbl.AutoSize = true;
            this.udpIpLbl.Location = new System.Drawing.Point(4, 69);
            this.udpIpLbl.Name = "udpIpLbl";
            this.udpIpLbl.Size = new System.Drawing.Size(54, 13);
            this.udpIpLbl.TabIndex = 10;
            this.udpIpLbl.Text = "Server IP:";
            // 
            // udpIpTxt
            // 
            this.udpIpTxt.Enabled = false;
            this.udpIpTxt.Location = new System.Drawing.Point(6, 85);
            this.udpIpTxt.Name = "udpIpTxt";
            this.udpIpTxt.Size = new System.Drawing.Size(98, 20);
            this.udpIpTxt.TabIndex = 13;
            this.udpIpTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.udpIpTxt_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 108);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "Server Port:";
            // 
            // udpPortTxt
            // 
            this.udpPortTxt.Location = new System.Drawing.Point(6, 124);
            this.udpPortTxt.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.udpPortTxt.Name = "udpPortTxt";
            this.udpPortTxt.Size = new System.Drawing.Size(98, 20);
            this.udpPortTxt.TabIndex = 12;
            this.udpPortTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.udpPortTxt_KeyPress);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(122, 497);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Serial";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.serialConnectBtn);
            this.groupBox2.Controls.Add(this.serialDisconnectBtn);
            this.groupBox2.Controls.Add(this.serialConnectionStateLbl);
            this.groupBox2.Location = new System.Drawing.Point(6, 279);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(111, 104);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connection";
            // 
            // serialConnectBtn
            // 
            this.serialConnectBtn.Location = new System.Drawing.Point(6, 19);
            this.serialConnectBtn.Name = "serialConnectBtn";
            this.serialConnectBtn.Size = new System.Drawing.Size(100, 23);
            this.serialConnectBtn.TabIndex = 19;
            this.serialConnectBtn.Text = "Connect";
            this.serialConnectBtn.UseVisualStyleBackColor = true;
            this.serialConnectBtn.Click += new System.EventHandler(this.serialConnectBtn_Click);
            // 
            // serialDisconnectBtn
            // 
            this.serialDisconnectBtn.Enabled = false;
            this.serialDisconnectBtn.Location = new System.Drawing.Point(6, 48);
            this.serialDisconnectBtn.Name = "serialDisconnectBtn";
            this.serialDisconnectBtn.Size = new System.Drawing.Size(100, 23);
            this.serialDisconnectBtn.TabIndex = 20;
            this.serialDisconnectBtn.Text = "Disconnect";
            this.serialDisconnectBtn.UseVisualStyleBackColor = true;
            this.serialDisconnectBtn.Click += new System.EventHandler(this.serialDisconnectBtn_Click);
            // 
            // serialConnectionStateLbl
            // 
            this.serialConnectionStateLbl.AutoSize = true;
            this.serialConnectionStateLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serialConnectionStateLbl.Location = new System.Drawing.Point(9, 78);
            this.serialConnectionStateLbl.MaximumSize = new System.Drawing.Size(93, 19);
            this.serialConnectionStateLbl.MinimumSize = new System.Drawing.Size(93, 19);
            this.serialConnectionStateLbl.Name = "serialConnectionStateLbl";
            this.serialConnectionStateLbl.Size = new System.Drawing.Size(93, 19);
            this.serialConnectionStateLbl.TabIndex = 21;
            this.serialConnectionStateLbl.Text = "Not Connected";
            this.serialConnectionStateLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.serialPortLbl);
            this.groupBox1.Controls.Add(this.serialComRefreshBtn);
            this.groupBox1.Controls.Add(this.serialParityCmBx);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.serialStopBitsCmBx);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.serialBaudCmBx);
            this.groupBox1.Controls.Add(this.serialDataBitsTxt);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.serialComCmBx);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(111, 270);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // serialPortLbl
            // 
            this.serialPortLbl.AutoSize = true;
            this.serialPortLbl.Location = new System.Drawing.Point(41, 17);
            this.serialPortLbl.Name = "serialPortLbl";
            this.serialPortLbl.Size = new System.Drawing.Size(10, 13);
            this.serialPortLbl.TabIndex = 26;
            this.serialPortLbl.Text = "-";
            // 
            // serialComRefreshBtn
            // 
            this.serialComRefreshBtn.Location = new System.Drawing.Point(7, 63);
            this.serialComRefreshBtn.Name = "serialComRefreshBtn";
            this.serialComRefreshBtn.Size = new System.Drawing.Size(98, 23);
            this.serialComRefreshBtn.TabIndex = 25;
            this.serialComRefreshBtn.Text = "Refresh";
            this.serialComRefreshBtn.UseVisualStyleBackColor = true;
            this.serialComRefreshBtn.Click += new System.EventHandler(this.serialComRefreshBtn_Click);
            // 
            // serialParityCmBx
            // 
            this.serialParityCmBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serialParityCmBx.FormattingEnabled = true;
            this.serialParityCmBx.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even ",
            "Mark",
            "Space"});
            this.serialParityCmBx.Location = new System.Drawing.Point(7, 231);
            this.serialParityCmBx.Name = "serialParityCmBx";
            this.serialParityCmBx.Size = new System.Drawing.Size(99, 21);
            this.serialParityCmBx.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Parity:";
            // 
            // serialStopBitsCmBx
            // 
            this.serialStopBitsCmBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serialStopBitsCmBx.FormattingEnabled = true;
            this.serialStopBitsCmBx.Items.AddRange(new object[] {
            "0",
            "1",
            "1.5",
            "2"});
            this.serialStopBitsCmBx.Location = new System.Drawing.Point(6, 191);
            this.serialStopBitsCmBx.Name = "serialStopBitsCmBx";
            this.serialStopBitsCmBx.Size = new System.Drawing.Size(99, 21);
            this.serialStopBitsCmBx.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Stop Bits:";
            // 
            // serialBaudCmBx
            // 
            this.serialBaudCmBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serialBaudCmBx.FormattingEnabled = true;
            this.serialBaudCmBx.Items.AddRange(new object[] {
            "100",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600",
            "115200",
            "128000",
            "256000"});
            this.serialBaudCmBx.Location = new System.Drawing.Point(6, 112);
            this.serialBaudCmBx.Name = "serialBaudCmBx";
            this.serialBaudCmBx.Size = new System.Drawing.Size(99, 21);
            this.serialBaudCmBx.TabIndex = 5;
            // 
            // serialDataBitsTxt
            // 
            this.serialDataBitsTxt.Location = new System.Drawing.Point(6, 152);
            this.serialDataBitsTxt.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.serialDataBitsTxt.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.serialDataBitsTxt.Name = "serialDataBitsTxt";
            this.serialDataBitsTxt.Size = new System.Drawing.Size(100, 20);
            this.serialDataBitsTxt.TabIndex = 23;
            this.serialDataBitsTxt.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Baud Rate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Com:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Data Bits:";
            // 
            // serialComCmBx
            // 
            this.serialComCmBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serialComCmBx.DropDownWidth = 200;
            this.serialComCmBx.FormattingEnabled = true;
            this.serialComCmBx.Location = new System.Drawing.Point(7, 39);
            this.serialComCmBx.MaxDropDownItems = 15;
            this.serialComCmBx.Name = "serialComCmBx";
            this.serialComCmBx.Size = new System.Drawing.Size(98, 21);
            this.serialComCmBx.TabIndex = 4;
            // 
            // receivingRateLbl
            // 
            this.receivingRateLbl.AutoSize = true;
            this.receivingRateLbl.Location = new System.Drawing.Point(238, 8);
            this.receivingRateLbl.Name = "receivingRateLbl";
            this.receivingRateLbl.Size = new System.Drawing.Size(33, 13);
            this.receivingRateLbl.TabIndex = 41;
            this.receivingRateLbl.Text = "0 B/s";
            // 
            // bytesOutLbl
            // 
            this.bytesOutLbl.AutoSize = true;
            this.bytesOutLbl.Location = new System.Drawing.Point(119, 8);
            this.bytesOutLbl.Name = "bytesOutLbl";
            this.bytesOutLbl.Size = new System.Drawing.Size(23, 13);
            this.bytesOutLbl.TabIndex = 40;
            this.bytesOutLbl.Text = "0 B";
            // 
            // bytesInLbl
            // 
            this.bytesInLbl.AutoSize = true;
            this.bytesInLbl.Location = new System.Drawing.Point(30, 8);
            this.bytesInLbl.Name = "bytesInLbl";
            this.bytesInLbl.Size = new System.Drawing.Size(23, 13);
            this.bytesInLbl.TabIndex = 39;
            this.bytesInLbl.Text = "0 B";
            // 
            // labll
            // 
            this.labll.AutoSize = true;
            this.labll.Location = new System.Drawing.Point(188, 8);
            this.labll.Name = "labll";
            this.labll.Size = new System.Drawing.Size(49, 13);
            this.labll.TabIndex = 38;
            this.labll.Text = "Rx Rate:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Rx:";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(94, 8);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(22, 13);
            this.lbl.TabIndex = 17;
            this.lbl.Text = "Tx:";
            // 
            // clearScreenBtn
            // 
            this.clearScreenBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearScreenBtn.Location = new System.Drawing.Point(845, 451);
            this.clearScreenBtn.Name = "clearScreenBtn";
            this.clearScreenBtn.Size = new System.Drawing.Size(51, 22);
            this.clearScreenBtn.TabIndex = 23;
            this.clearScreenBtn.Text = "Clear";
            this.clearScreenBtn.UseVisualStyleBackColor = true;
            this.clearScreenBtn.Click += new System.EventHandler(this.clearScreenBtn_Click);
            // 
            // sendBtn
            // 
            this.sendBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendBtn.Location = new System.Drawing.Point(787, 451);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(54, 22);
            this.sendBtn.TabIndex = 25;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.aboutBtn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(968, 24);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commandLineToolStripMenuItem,
            this.dataPlotToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(47, 20);
            this.toolStripMenuItem1.Text = "Tools";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.graphToolStripMenuItem1_Click);
            // 
            // commandLineToolStripMenuItem
            // 
            this.commandLineToolStripMenuItem.Name = "commandLineToolStripMenuItem";
            this.commandLineToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.commandLineToolStripMenuItem.Text = "Command Line";
            this.commandLineToolStripMenuItem.Click += new System.EventHandler(this.commandLineToolStripMenuItem_Click);
            // 
            // dataPlotToolStripMenuItem
            // 
            this.dataPlotToolStripMenuItem.Name = "dataPlotToolStripMenuItem";
            this.dataPlotToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.dataPlotToolStripMenuItem.Text = "Data Plot";
            this.dataPlotToolStripMenuItem.Click += new System.EventHandler(this.dataPlotToolStripMenuItem_Click);
            // 
            // aboutBtn
            // 
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.Size = new System.Drawing.Size(52, 20);
            this.aboutBtn.Text = "About";
            this.aboutBtn.Click += new System.EventHandler(this.aboutBtn_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // graphToolStripMenuItem
            // 
            this.graphToolStripMenuItem.Name = "graphToolStripMenuItem";
            this.graphToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.graphToolStripMenuItem.Text = "Graph";
            // 
            // autoScrollChkBx
            // 
            this.autoScrollChkBx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.autoScrollChkBx.AutoSize = true;
            this.autoScrollChkBx.Checked = true;
            this.autoScrollChkBx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoScrollChkBx.Location = new System.Drawing.Point(175, 49);
            this.autoScrollChkBx.Name = "autoScrollChkBx";
            this.autoScrollChkBx.Size = new System.Drawing.Size(77, 17);
            this.autoScrollChkBx.TabIndex = 27;
            this.autoScrollChkBx.Tag = "";
            this.autoScrollChkBx.Text = "Auto Scroll";
            this.toolTip.SetToolTip(this.autoScrollChkBx, "Auto scroll when text reach the button of the display");
            this.autoScrollChkBx.UseVisualStyleBackColor = true;
            this.autoScrollChkBx.CheckedChanged += new System.EventHandler(this.autoScrollChkBx_CheckedChanged);
            // 
            // displayTxt
            // 
            this.displayTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayTxt.BackColor = System.Drawing.Color.White;
            this.displayTxt.Font = new System.Drawing.Font("Miriam Fixed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayTxt.ForeColor = System.Drawing.Color.Black;
            this.displayTxt.Location = new System.Drawing.Point(145, 58);
            this.displayTxt.Multiline = true;
            this.displayTxt.Name = "displayTxt";
            this.displayTxt.ReadOnly = true;
            this.displayTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.displayTxt.Size = new System.Drawing.Size(810, 387);
            this.displayTxt.TabIndex = 29;
            this.displayTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataInScreenTxt_KeyDown);
            // 
            // textToSendCmBx
            // 
            this.textToSendCmBx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textToSendCmBx.FormattingEnabled = true;
            this.textToSendCmBx.Location = new System.Drawing.Point(146, 452);
            this.textToSendCmBx.MaxLength = 70;
            this.textToSendCmBx.Name = "textToSendCmBx";
            this.textToSendCmBx.Size = new System.Drawing.Size(635, 21);
            this.textToSendCmBx.TabIndex = 37;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.sendingRateLbl);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.serialIndicatorLbl);
            this.groupBox4.Controls.Add(this.udpIndicatorLbl);
            this.groupBox4.Controls.Add(this.tcpIndicatorLbl);
            this.groupBox4.Controls.Add(this.receivingRateLbl);
            this.groupBox4.Controls.Add(this.bytesInLbl);
            this.groupBox4.Controls.Add(this.labll);
            this.groupBox4.Controls.Add(this.bytesOutLbl);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.lbl);
            this.groupBox4.Location = new System.Drawing.Point(146, 30);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(813, 25);
            this.groupBox4.TabIndex = 40;
            this.groupBox4.TabStop = false;
            // 
            // sendingRateLbl
            // 
            this.sendingRateLbl.AutoSize = true;
            this.sendingRateLbl.Location = new System.Drawing.Point(370, 8);
            this.sendingRateLbl.Name = "sendingRateLbl";
            this.sendingRateLbl.Size = new System.Drawing.Size(33, 13);
            this.sendingRateLbl.TabIndex = 46;
            this.sendingRateLbl.Text = "0 B/s";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(320, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Tx Rate:";
            // 
            // serialIndicatorLbl
            // 
            this.serialIndicatorLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serialIndicatorLbl.AutoSize = true;
            this.serialIndicatorLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.serialIndicatorLbl.Location = new System.Drawing.Point(778, 8);
            this.serialIndicatorLbl.Name = "serialIndicatorLbl";
            this.serialIndicatorLbl.Size = new System.Drawing.Size(31, 15);
            this.serialIndicatorLbl.TabIndex = 44;
            this.serialIndicatorLbl.Text = "SER";
            // 
            // udpIndicatorLbl
            // 
            this.udpIndicatorLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.udpIndicatorLbl.AutoSize = true;
            this.udpIndicatorLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.udpIndicatorLbl.Location = new System.Drawing.Point(738, 8);
            this.udpIndicatorLbl.Name = "udpIndicatorLbl";
            this.udpIndicatorLbl.Size = new System.Drawing.Size(32, 15);
            this.udpIndicatorLbl.TabIndex = 43;
            this.udpIndicatorLbl.Text = "UDP";
            // 
            // tcpIndicatorLbl
            // 
            this.tcpIndicatorLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcpIndicatorLbl.AutoSize = true;
            this.tcpIndicatorLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tcpIndicatorLbl.Location = new System.Drawing.Point(700, 8);
            this.tcpIndicatorLbl.Name = "tcpIndicatorLbl";
            this.tcpIndicatorLbl.Size = new System.Drawing.Size(30, 15);
            this.tcpIndicatorLbl.TabIndex = 42;
            this.tcpIndicatorLbl.Text = "TCP";
            // 
            // bytesInTimer
            // 
            this.bytesInTimer.Interval = 500;
            this.bytesInTimer.Tick += new System.EventHandler(this.bytesInTimer_Tick);
            // 
            // bytesOutTimer
            // 
            this.bytesOutTimer.Interval = 500;
            this.bytesOutTimer.Tick += new System.EventHandler(this.bytesOutTimer_Tick);
            // 
            // bytesInRateTimer
            // 
            this.bytesInRateTimer.Enabled = true;
            this.bytesInRateTimer.Interval = 1000;
            this.bytesInRateTimer.Tick += new System.EventHandler(this.bytesRateTimer_Tick);
            // 
            // resetBtn
            // 
            this.resetBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.resetBtn.Location = new System.Drawing.Point(901, 451);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(54, 22);
            this.resetBtn.TabIndex = 42;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // sendFileBtn
            // 
            this.sendFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sendFileBtn.Location = new System.Drawing.Point(6, 17);
            this.sendFileBtn.Name = "sendFileBtn";
            this.sendFileBtn.Size = new System.Drawing.Size(51, 22);
            this.sendFileBtn.TabIndex = 43;
            this.sendFileBtn.Text = "Send";
            this.sendFileBtn.UseVisualStyleBackColor = true;
            this.sendFileBtn.Click += new System.EventHandler(this.sendFileBtn_Click);
            // 
            // sendFileLbl
            // 
            this.sendFileLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sendFileLbl.AutoSize = true;
            this.sendFileLbl.Location = new System.Drawing.Point(63, 55);
            this.sendFileLbl.Name = "sendFileLbl";
            this.sendFileLbl.Size = new System.Drawing.Size(27, 13);
            this.sendFileLbl.TabIndex = 44;
            this.sendFileLbl.Text = "N/A";
            // 
            // sendFileWorker
            // 
            this.sendFileWorker.WorkerReportsProgress = true;
            this.sendFileWorker.WorkerSupportsCancellation = true;
            this.sendFileWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.sendFileWorker_DoWork);
            this.sendFileWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.sendFileWorker_ProgressChanged);
            // 
            // stopSendFile
            // 
            this.stopSendFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stopSendFile.Enabled = false;
            this.stopSendFile.Location = new System.Drawing.Point(6, 47);
            this.stopSendFile.Name = "stopSendFile";
            this.stopSendFile.Size = new System.Drawing.Size(51, 22);
            this.stopSendFile.TabIndex = 45;
            this.stopSendFile.Text = "Cancel";
            this.stopSendFile.UseVisualStyleBackColor = true;
            this.stopSendFile.Click += new System.EventHandler(this.stopSendFile_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox8.Controls.Add(this.sendFileBtn);
            this.groupBox8.Controls.Add(this.sendFileLbl);
            this.groupBox8.Controls.Add(this.stopSendFile);
            this.groupBox8.Location = new System.Drawing.Point(410, 479);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(100, 75);
            this.groupBox8.TabIndex = 46;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Send File";
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox9.Controls.Add(this.label5);
            this.groupBox9.Controls.Add(this.label2);
            this.groupBox9.Controls.Add(this.lineEndingCmBx);
            this.groupBox9.Controls.Add(this.formatCmBx);
            this.groupBox9.Controls.Add(this.detailedChkBx);
            this.groupBox9.Controls.Add(this.autoScrollChkBx);
            this.groupBox9.Location = new System.Drawing.Point(146, 479);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(258, 75);
            this.groupBox9.TabIndex = 47;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Display";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Line Ending:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Format:";
            // 
            // lineEndingCmBx
            // 
            this.lineEndingCmBx.FormattingEnabled = true;
            this.lineEndingCmBx.Items.AddRange(new object[] {
            "None",
            "LF",
            "LF CR"});
            this.lineEndingCmBx.Location = new System.Drawing.Point(78, 47);
            this.lineEndingCmBx.Name = "lineEndingCmBx";
            this.lineEndingCmBx.Size = new System.Drawing.Size(92, 21);
            this.lineEndingCmBx.TabIndex = 31;
            this.lineEndingCmBx.SelectedIndexChanged += new System.EventHandler(this.lineEndingCmBx_SelectedIndexChanged);
            // 
            // formatCmBx
            // 
            this.formatCmBx.FormattingEnabled = true;
            this.formatCmBx.Items.AddRange(new object[] {
            "ASCII",
            "Binary",
            "Hex"});
            this.formatCmBx.Location = new System.Drawing.Point(78, 20);
            this.formatCmBx.Name = "formatCmBx";
            this.formatCmBx.Size = new System.Drawing.Size(92, 21);
            this.formatCmBx.TabIndex = 30;
            this.formatCmBx.SelectedIndexChanged += new System.EventHandler(this.formatCmBx_SelectedIndexChanged);
            // 
            // detailedChkBx
            // 
            this.detailedChkBx.AutoSize = true;
            this.detailedChkBx.Location = new System.Drawing.Point(176, 22);
            this.detailedChkBx.Name = "detailedChkBx";
            this.detailedChkBx.Size = new System.Drawing.Size(65, 17);
            this.detailedChkBx.TabIndex = 28;
            this.detailedChkBx.Text = "Detailed";
            this.toolTip.SetToolTip(this.detailedChkBx, "When message arrives, print details like timestamp in dispay");
            this.detailedChkBx.UseVisualStyleBackColor = true;
            this.detailedChkBx.CheckedChanged += new System.EventHandler(this.detailedChkBx_CheckedChanged);
            // 
            // groupBox10
            // 
            this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox10.Controls.Add(this.searchBtn);
            this.groupBox10.Controls.Add(this.searchTxt);
            this.groupBox10.Location = new System.Drawing.Point(664, 479);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(110, 75);
            this.groupBox10.TabIndex = 48;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Search";
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(6, 46);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(97, 23);
            this.searchBtn.TabIndex = 1;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // searchTxt
            // 
            this.searchTxt.Location = new System.Drawing.Point(6, 19);
            this.searchTxt.Name = "searchTxt";
            this.searchTxt.Size = new System.Drawing.Size(97, 20);
            this.searchTxt.TabIndex = 0;
            // 
            // bytesOutRateTimer
            // 
            this.bytesOutRateTimer.Enabled = true;
            this.bytesOutRateTimer.Interval = 1000;
            this.bytesOutRateTimer.Tick += new System.EventHandler(this.bytesOutRateTimer_Tick);
            // 
            // serialPortsTimer
            // 
            this.serialPortsTimer.Enabled = true;
            this.serialPortsTimer.Interval = 1000;
            this.serialPortsTimer.Tick += new System.EventHandler(this.serialPortsTimer_Tick);
            // 
            // groupBox11
            // 
            this.groupBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox11.Controls.Add(this.logPathLbl);
            this.groupBox11.Controls.Add(this.logPathBtn);
            this.groupBox11.Controls.Add(this.logStartBtn);
            this.groupBox11.Controls.Add(this.logStopBtn);
            this.groupBox11.Location = new System.Drawing.Point(516, 479);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(142, 75);
            this.groupBox11.TabIndex = 49;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Log To File";
            // 
            // logPathLbl
            // 
            this.logPathLbl.AutoSize = true;
            this.logPathLbl.Location = new System.Drawing.Point(7, 22);
            this.logPathLbl.MaximumSize = new System.Drawing.Size(90, 13);
            this.logPathLbl.MinimumSize = new System.Drawing.Size(90, 13);
            this.logPathLbl.Name = "logPathLbl";
            this.logPathLbl.Size = new System.Drawing.Size(90, 13);
            this.logPathLbl.TabIndex = 48;
            this.logPathLbl.Text = "N/A";
            // 
            // logPathBtn
            // 
            this.logPathBtn.Location = new System.Drawing.Point(109, 18);
            this.logPathBtn.Name = "logPathBtn";
            this.logPathBtn.Size = new System.Drawing.Size(27, 22);
            this.logPathBtn.TabIndex = 47;
            this.logPathBtn.Text = "...";
            this.logPathBtn.UseVisualStyleBackColor = true;
            this.logPathBtn.Click += new System.EventHandler(this.logPathBtn_Click);
            // 
            // logStartBtn
            // 
            this.logStartBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.logStartBtn.Enabled = false;
            this.logStartBtn.Location = new System.Drawing.Point(6, 47);
            this.logStartBtn.Name = "logStartBtn";
            this.logStartBtn.Size = new System.Drawing.Size(51, 22);
            this.logStartBtn.TabIndex = 43;
            this.logStartBtn.Text = "Start";
            this.logStartBtn.UseVisualStyleBackColor = true;
            this.logStartBtn.Click += new System.EventHandler(this.logStartBtn_Click);
            // 
            // logStopBtn
            // 
            this.logStopBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.logStopBtn.Enabled = false;
            this.logStopBtn.Location = new System.Drawing.Point(85, 47);
            this.logStopBtn.Name = "logStopBtn";
            this.logStopBtn.Size = new System.Drawing.Size(51, 22);
            this.logStopBtn.TabIndex = 45;
            this.logStopBtn.Text = "Stop";
            this.logStopBtn.UseVisualStyleBackColor = true;
            this.logStopBtn.Click += new System.EventHandler(this.logStopBtn_Click);
            // 
            // groupBox12
            // 
            this.groupBox12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox12.Controls.Add(this.pkgSizeLbl);
            this.groupBox12.Controls.Add(this.pkgHeaderLbl);
            this.groupBox12.Controls.Add(this.pkgParseChkBx);
            this.groupBox12.Controls.Add(this.pkgSendBtn);
            this.groupBox12.Controls.Add(this.pkgLoadBtn);
            this.groupBox12.Location = new System.Drawing.Point(780, 479);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(174, 75);
            this.groupBox12.TabIndex = 50;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Package Wizard";
            // 
            // pkgSizeLbl
            // 
            this.pkgSizeLbl.AutoSize = true;
            this.pkgSizeLbl.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pkgSizeLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pkgSizeLbl.Location = new System.Drawing.Point(122, 19);
            this.pkgSizeLbl.MaximumSize = new System.Drawing.Size(59, 15);
            this.pkgSizeLbl.MinimumSize = new System.Drawing.Size(44, 15);
            this.pkgSizeLbl.Name = "pkgSizeLbl";
            this.pkgSizeLbl.Size = new System.Drawing.Size(44, 15);
            this.pkgSizeLbl.TabIndex = 6;
            this.pkgSizeLbl.Text = "Size";
            this.pkgSizeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pkgHeaderLbl
            // 
            this.pkgHeaderLbl.AutoSize = true;
            this.pkgHeaderLbl.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pkgHeaderLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pkgHeaderLbl.Location = new System.Drawing.Point(122, 49);
            this.pkgHeaderLbl.MaximumSize = new System.Drawing.Size(59, 15);
            this.pkgHeaderLbl.Name = "pkgHeaderLbl";
            this.pkgHeaderLbl.Size = new System.Drawing.Size(44, 15);
            this.pkgHeaderLbl.TabIndex = 5;
            this.pkgHeaderLbl.Text = "Header";
            this.pkgHeaderLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pkgParseChkBx
            // 
            this.pkgParseChkBx.AutoSize = true;
            this.pkgParseChkBx.Location = new System.Drawing.Point(66, 19);
            this.pkgParseChkBx.Name = "pkgParseChkBx";
            this.pkgParseChkBx.Size = new System.Drawing.Size(53, 17);
            this.pkgParseChkBx.TabIndex = 4;
            this.pkgParseChkBx.Text = "Parse";
            this.pkgParseChkBx.UseVisualStyleBackColor = true;
            // 
            // pkgSendBtn
            // 
            this.pkgSendBtn.Location = new System.Drawing.Point(6, 45);
            this.pkgSendBtn.Name = "pkgSendBtn";
            this.pkgSendBtn.Size = new System.Drawing.Size(53, 23);
            this.pkgSendBtn.TabIndex = 3;
            this.pkgSendBtn.Text = "Send";
            this.pkgSendBtn.UseVisualStyleBackColor = true;
            // 
            // pkgLoadBtn
            // 
            this.pkgLoadBtn.Location = new System.Drawing.Point(6, 17);
            this.pkgLoadBtn.Name = "pkgLoadBtn";
            this.pkgLoadBtn.Size = new System.Drawing.Size(53, 23);
            this.pkgLoadBtn.TabIndex = 1;
            this.pkgLoadBtn.Text = "Load";
            this.pkgLoadBtn.UseVisualStyleBackColor = true;
            this.pkgLoadBtn.Click += new System.EventHandler(this.pkgLoadBtn_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.sendBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 570);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.textToSendCmBx);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.displayTxt);
            this.Controls.Add(this.clearScreenBtn);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Falcon Com Inspector";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcpPortTxt)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udpPortTxt)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serialDataBitsTxt)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button tcpDisconnectBtn;
        private System.Windows.Forms.Button tcpConnectBtn;
        private System.Windows.Forms.TextBox tcpIpTxt;
        private System.Windows.Forms.NumericUpDown tcpPortTxt;
        private System.Windows.Forms.Label tcpServerPortLbl;
        private System.Windows.Forms.Label tcpIpLbl;
        private System.Windows.Forms.RadioButton tcpClientRdBtn;
        private System.Windows.Forms.RadioButton tcpServerRdBtn;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Button clearScreenBtn;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.Label incomingClientsCountLBl;
        private System.Windows.Forms.Label incomingClientsLBl;
        private System.Windows.Forms.Label tcpConnectionStateLbl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphToolStripMenuItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox serialParityCmBx;
        private System.Windows.Forms.ComboBox serialBaudCmBx;
        private System.Windows.Forms.ComboBox serialComCmBx;
        private System.Windows.Forms.Label serialConnectionStateLbl;
        private System.Windows.Forms.Button serialDisconnectBtn;
        private System.Windows.Forms.Button serialConnectBtn;
        private System.Windows.Forms.NumericUpDown serialDataBitsTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox serialStopBitsCmBx;
        private System.Windows.Forms.Button serialComRefreshBtn;
        private System.Windows.Forms.CheckBox autoScrollChkBx;
        private System.Windows.Forms.TextBox displayTxt;
        private System.Windows.Forms.ComboBox textToSendCmBx;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label receivingRateLbl;
        private System.Windows.Forms.Label bytesOutLbl;
        private System.Windows.Forms.Label bytesInLbl;
        private System.Windows.Forms.Label labll;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ToolStripMenuItem aboutBtn;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button udpConnectBtn;
        private System.Windows.Forms.Label udpConnectionStateLbl;
        private System.Windows.Forms.Button udpDisconnectBtn;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton udpServerRdBtn;
        private System.Windows.Forms.RadioButton udpClientRdBtn;
        private System.Windows.Forms.Label udpIpLbl;
        private System.Windows.Forms.TextBox udpIpTxt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown udpPortTxt;
        private System.Windows.Forms.Label tcpIndicatorLbl;
        private System.Windows.Forms.Label serialIndicatorLbl;
        private System.Windows.Forms.Label udpIndicatorLbl;
        private System.Windows.Forms.Timer bytesInTimer;
        private System.Windows.Forms.Timer bytesOutTimer;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Timer bytesInRateTimer;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Button sendFileBtn;
        private System.Windows.Forms.Label sendFileLbl;
        private System.ComponentModel.BackgroundWorker sendFileWorker;
        private System.Windows.Forms.Button stopSendFile;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label sendingRateLbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.CheckBox detailedChkBx;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.TextBox searchTxt;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Timer bytesOutRateTimer;
        private System.Windows.Forms.Timer serialPortsTimer;
        private System.Windows.Forms.Label serialPortLbl;
        private System.Windows.Forms.ToolStripMenuItem dataPlotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandLineToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox lineEndingCmBx;
        private System.Windows.Forms.ComboBox formatCmBx;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button logPathBtn;
        private System.Windows.Forms.Button logStartBtn;
        private System.Windows.Forms.Button logStopBtn;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Label pkgSizeLbl;
        private System.Windows.Forms.Label pkgHeaderLbl;
        private System.Windows.Forms.CheckBox pkgParseChkBx;
        private System.Windows.Forms.Button pkgSendBtn;
        private System.Windows.Forms.Button pkgLoadBtn;
        private System.Windows.Forms.Label logPathLbl;
    }
}

