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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tcpConnectionStateLbl = new System.Windows.Forms.Label();
            this.tcpConnectedClientsLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tcpDisconnectBtn = new System.Windows.Forms.Button();
            this.tcpConnectBtn = new System.Windows.Forms.Button();
            this.tcpIpTxt = new System.Windows.Forms.TextBox();
            this.tcpPortTxt = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tcpServerIpLbl = new System.Windows.Forms.Label();
            this.tcpClientRdBtn = new System.Windows.Forms.RadioButton();
            this.tcpServerRdBtn = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.serialComRefreshBtn = new System.Windows.Forms.Button();
            this.serialStopBitsCmBx = new System.Windows.Forms.ComboBox();
            this.serialDataBitsTxt = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.serialConnectionStateLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.serialDisconnectBtn = new System.Windows.Forms.Button();
            this.serialConnectBtn = new System.Windows.Forms.Button();
            this.serialParityCmBx = new System.Windows.Forms.ComboBox();
            this.serialBaudCmBx = new System.Windows.Forms.ComboBox();
            this.serialComCmBx = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clearScreenBtn = new System.Windows.Forms.Button();
            this.sendBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoScrollChkBx = new System.Windows.Forms.CheckBox();
            this.dataInScreenTxt = new System.Windows.Forms.TextBox();
            this.textToSendCmBx = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcpPortTxt)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serialDataBitsTxt)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(10, 35);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(156, 471);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tcpConnectionStateLbl);
            this.tabPage1.Controls.Add(this.tcpConnectedClientsLbl);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.tcpDisconnectBtn);
            this.tabPage1.Controls.Add(this.tcpConnectBtn);
            this.tabPage1.Controls.Add(this.tcpIpTxt);
            this.tabPage1.Controls.Add(this.tcpPortTxt);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tcpServerIpLbl);
            this.tabPage1.Controls.Add(this.tcpClientRdBtn);
            this.tabPage1.Controls.Add(this.tcpServerRdBtn);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(148, 445);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "TCP";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tcpConnectionStateLbl
            // 
            this.tcpConnectionStateLbl.AutoSize = true;
            this.tcpConnectionStateLbl.Location = new System.Drawing.Point(15, 155);
            this.tcpConnectionStateLbl.Name = "tcpConnectionStateLbl";
            this.tcpConnectionStateLbl.Size = new System.Drawing.Size(79, 13);
            this.tcpConnectionStateLbl.TabIndex = 18;
            this.tcpConnectionStateLbl.Text = "Not Connected";
            // 
            // tcpConnectedClientsLbl
            // 
            this.tcpConnectedClientsLbl.AutoSize = true;
            this.tcpConnectedClientsLbl.Location = new System.Drawing.Point(118, 126);
            this.tcpConnectedClientsLbl.Name = "tcpConnectedClientsLbl";
            this.tcpConnectedClientsLbl.Size = new System.Drawing.Size(13, 13);
            this.tcpConnectedClientsLbl.TabIndex = 17;
            this.tcpConnectedClientsLbl.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Connected Clients:";
            // 
            // tcpDisconnectBtn
            // 
            this.tcpDisconnectBtn.Location = new System.Drawing.Point(36, 234);
            this.tcpDisconnectBtn.Name = "tcpDisconnectBtn";
            this.tcpDisconnectBtn.Size = new System.Drawing.Size(75, 23);
            this.tcpDisconnectBtn.TabIndex = 15;
            this.tcpDisconnectBtn.Text = "Disconnect";
            this.tcpDisconnectBtn.UseVisualStyleBackColor = true;
            this.tcpDisconnectBtn.Click += new System.EventHandler(this.tcpDisconnectBtn_Click);
            // 
            // tcpConnectBtn
            // 
            this.tcpConnectBtn.Location = new System.Drawing.Point(15, 85);
            this.tcpConnectBtn.Name = "tcpConnectBtn";
            this.tcpConnectBtn.Size = new System.Drawing.Size(75, 23);
            this.tcpConnectBtn.TabIndex = 14;
            this.tcpConnectBtn.Text = "Connect";
            this.tcpConnectBtn.UseVisualStyleBackColor = true;
            this.tcpConnectBtn.Click += new System.EventHandler(this.tcpConnectBtn_Click);
            // 
            // tcpIpTxt
            // 
            this.tcpIpTxt.Enabled = false;
            this.tcpIpTxt.Location = new System.Drawing.Point(77, 32);
            this.tcpIpTxt.Name = "tcpIpTxt";
            this.tcpIpTxt.Size = new System.Drawing.Size(85, 20);
            this.tcpIpTxt.TabIndex = 13;
            // 
            // tcpPortTxt
            // 
            this.tcpPortTxt.Location = new System.Drawing.Point(77, 59);
            this.tcpPortTxt.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.tcpPortTxt.Name = "tcpPortTxt";
            this.tcpPortTxt.Size = new System.Drawing.Size(85, 20);
            this.tcpPortTxt.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Server Port:";
            // 
            // tcpServerIpLbl
            // 
            this.tcpServerIpLbl.AutoSize = true;
            this.tcpServerIpLbl.Enabled = false;
            this.tcpServerIpLbl.Location = new System.Drawing.Point(12, 36);
            this.tcpServerIpLbl.Name = "tcpServerIpLbl";
            this.tcpServerIpLbl.Size = new System.Drawing.Size(54, 13);
            this.tcpServerIpLbl.TabIndex = 10;
            this.tcpServerIpLbl.Text = "Server IP:";
            // 
            // tcpClientRdBtn
            // 
            this.tcpClientRdBtn.AutoSize = true;
            this.tcpClientRdBtn.Location = new System.Drawing.Point(77, 6);
            this.tcpClientRdBtn.Name = "tcpClientRdBtn";
            this.tcpClientRdBtn.Size = new System.Drawing.Size(51, 17);
            this.tcpClientRdBtn.TabIndex = 9;
            this.tcpClientRdBtn.Text = "Client";
            this.tcpClientRdBtn.UseVisualStyleBackColor = true;
            // 
            // tcpServerRdBtn
            // 
            this.tcpServerRdBtn.AutoSize = true;
            this.tcpServerRdBtn.Checked = true;
            this.tcpServerRdBtn.Location = new System.Drawing.Point(15, 6);
            this.tcpServerRdBtn.Name = "tcpServerRdBtn";
            this.tcpServerRdBtn.Size = new System.Drawing.Size(56, 17);
            this.tcpServerRdBtn.TabIndex = 8;
            this.tcpServerRdBtn.TabStop = true;
            this.tcpServerRdBtn.Text = "Server";
            this.tcpServerRdBtn.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(148, 445);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "UDP";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.serialComRefreshBtn);
            this.tabPage3.Controls.Add(this.serialStopBitsCmBx);
            this.tabPage3.Controls.Add(this.serialDataBitsTxt);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.serialConnectionStateLbl);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.serialDisconnectBtn);
            this.tabPage3.Controls.Add(this.serialConnectBtn);
            this.tabPage3.Controls.Add(this.serialParityCmBx);
            this.tabPage3.Controls.Add(this.serialBaudCmBx);
            this.tabPage3.Controls.Add(this.serialComCmBx);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(148, 445);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Serial";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // serialComRefreshBtn
            // 
            this.serialComRefreshBtn.Location = new System.Drawing.Point(99, 32);
            this.serialComRefreshBtn.Name = "serialComRefreshBtn";
            this.serialComRefreshBtn.Size = new System.Drawing.Size(39, 23);
            this.serialComRefreshBtn.TabIndex = 25;
            this.serialComRefreshBtn.Text = "Refresh";
            this.serialComRefreshBtn.UseVisualStyleBackColor = true;
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
            this.serialStopBitsCmBx.Location = new System.Drawing.Point(13, 152);
            this.serialStopBitsCmBx.Name = "serialStopBitsCmBx";
            this.serialStopBitsCmBx.Size = new System.Drawing.Size(99, 21);
            this.serialStopBitsCmBx.TabIndex = 24;
            // 
            // serialDataBitsTxt
            // 
            this.serialDataBitsTxt.Location = new System.Drawing.Point(13, 113);
            this.serialDataBitsTxt.Name = "serialDataBitsTxt";
            this.serialDataBitsTxt.Size = new System.Drawing.Size(100, 20);
            this.serialDataBitsTxt.TabIndex = 23;
            this.serialDataBitsTxt.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Data Bits:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 318);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Data Out: 100 bytes";
            // 
            // serialConnectionStateLbl
            // 
            this.serialConnectionStateLbl.AutoSize = true;
            this.serialConnectionStateLbl.Location = new System.Drawing.Point(14, 267);
            this.serialConnectionStateLbl.Name = "serialConnectionStateLbl";
            this.serialConnectionStateLbl.Size = new System.Drawing.Size(79, 13);
            this.serialConnectionStateLbl.TabIndex = 21;
            this.serialConnectionStateLbl.Text = "Not Connected";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Data In: 100 bytes";
            // 
            // serialDisconnectBtn
            // 
            this.serialDisconnectBtn.Location = new System.Drawing.Point(25, 392);
            this.serialDisconnectBtn.Name = "serialDisconnectBtn";
            this.serialDisconnectBtn.Size = new System.Drawing.Size(75, 23);
            this.serialDisconnectBtn.TabIndex = 20;
            this.serialDisconnectBtn.Text = "Disconnect";
            this.serialDisconnectBtn.UseVisualStyleBackColor = true;
            this.serialDisconnectBtn.Click += new System.EventHandler(this.serialDisconnectBtn_Click);
            // 
            // serialConnectBtn
            // 
            this.serialConnectBtn.Location = new System.Drawing.Point(14, 229);
            this.serialConnectBtn.Name = "serialConnectBtn";
            this.serialConnectBtn.Size = new System.Drawing.Size(75, 23);
            this.serialConnectBtn.TabIndex = 19;
            this.serialConnectBtn.Text = "Connect";
            this.serialConnectBtn.UseVisualStyleBackColor = true;
            this.serialConnectBtn.Click += new System.EventHandler(this.serialConnectBtn_Click);
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
            this.serialParityCmBx.Location = new System.Drawing.Point(14, 192);
            this.serialParityCmBx.Name = "serialParityCmBx";
            this.serialParityCmBx.Size = new System.Drawing.Size(99, 21);
            this.serialParityCmBx.TabIndex = 7;
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
            this.serialBaudCmBx.Location = new System.Drawing.Point(13, 73);
            this.serialBaudCmBx.Name = "serialBaudCmBx";
            this.serialBaudCmBx.Size = new System.Drawing.Size(99, 21);
            this.serialBaudCmBx.TabIndex = 5;
            // 
            // serialComCmBx
            // 
            this.serialComCmBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serialComCmBx.FormattingEnabled = true;
            this.serialComCmBx.Location = new System.Drawing.Point(13, 33);
            this.serialComCmBx.Name = "serialComCmBx";
            this.serialComCmBx.Size = new System.Drawing.Size(80, 21);
            this.serialComCmBx.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Parity:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Stop Bits:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Baud Rate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Com:";
            // 
            // clearScreenBtn
            // 
            this.clearScreenBtn.Location = new System.Drawing.Point(172, 452);
            this.clearScreenBtn.Name = "clearScreenBtn";
            this.clearScreenBtn.Size = new System.Drawing.Size(68, 22);
            this.clearScreenBtn.TabIndex = 23;
            this.clearScreenBtn.Text = "Clear";
            this.clearScreenBtn.UseVisualStyleBackColor = true;
            this.clearScreenBtn.Click += new System.EventHandler(this.clearScreenBtn_Click);
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(603, 480);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(54, 21);
            this.sendBtn.TabIndex = 25;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(667, 24);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
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
            this.autoScrollChkBx.AutoSize = true;
            this.autoScrollChkBx.Checked = true;
            this.autoScrollChkBx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoScrollChkBx.Location = new System.Drawing.Point(580, 455);
            this.autoScrollChkBx.Name = "autoScrollChkBx";
            this.autoScrollChkBx.Size = new System.Drawing.Size(77, 17);
            this.autoScrollChkBx.TabIndex = 27;
            this.autoScrollChkBx.Text = "Auto Scroll";
            this.autoScrollChkBx.UseVisualStyleBackColor = true;
            // 
            // dataInScreenTxt
            // 
            this.dataInScreenTxt.Location = new System.Drawing.Point(172, 35);
            this.dataInScreenTxt.Multiline = true;
            this.dataInScreenTxt.Name = "dataInScreenTxt";
            this.dataInScreenTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataInScreenTxt.Size = new System.Drawing.Size(485, 411);
            this.dataInScreenTxt.TabIndex = 29;
            // 
            // textToSendCmBx
            // 
            this.textToSendCmBx.FormattingEnabled = true;
            this.textToSendCmBx.Location = new System.Drawing.Point(173, 480);
            this.textToSendCmBx.Name = "textToSendCmBx";
            this.textToSendCmBx.Size = new System.Drawing.Size(424, 21);
            this.textToSendCmBx.TabIndex = 37;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 512);
            this.Controls.Add(this.textToSendCmBx);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.autoScrollChkBx);
            this.Controls.Add(this.dataInScreenTxt);
            this.Controls.Add(this.clearScreenBtn);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Falcon Com Inspector";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcpPortTxt)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serialDataBitsTxt)).EndInit();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label tcpServerIpLbl;
        private System.Windows.Forms.RadioButton tcpClientRdBtn;
        private System.Windows.Forms.RadioButton tcpServerRdBtn;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button clearScreenBtn;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.Label tcpConnectedClientsLbl;
        private System.Windows.Forms.Label label5;
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
        private System.Windows.Forms.TextBox dataInScreenTxt;
        private System.Windows.Forms.ComboBox textToSendCmBx;
    }
}

