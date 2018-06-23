using Falcon.CommandLine;
using Falcon.CommandLine.Arguments;
using Falcon.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Falcon.Forms
{
    public partial class CommandLineForm : Form
    {
        public enum DisplayMode
        {
            NORMAL,
            SSH
        }

        public DisplayMode displayMode = DisplayMode.NORMAL;

        Ssh ssh_;

        const string CLI_PREFIX_TEXT = "Falcon CLI > ";

        public CommandLineForm()
        {
            InitializeComponent();

            PrintLinePrefix();
        }

        private void CommandLineForm_Load(object sender, EventArgs e)
        {
            cliDisplayTxtBx.Focus();
        }

        private void cliDisplayTxtBx_TextChanged(object sender, EventArgs e)
        {

        }

        private void PrintLinePrefix()
        {
            PrintToScreen(CLI_PREFIX_TEXT, Color.LawnGreen, true);
        }

        /// <summary>
        /// override key processing before form does, so we can ignore
        /// attempts to delete or navigate into CLI prefix
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (cliDisplayTxtBx.Focused)
            {
                if (ProtectCliPrefixText(true))
                {
                    if (keyData == Keys.Back ||
                        keyData == Keys.Left)
                    {
                        return true;
                    }
                }
            }

            return base.ProcessCmdKey(ref msg, keyData); 
        }

        /// <summary>
        /// Print text to CLI display. All printings should be done throught this function
        /// </summary>
        /// <param name="text">text to print</param>
        /// <param name="append">appen text or overwrite existing text with this</param>
        private void PrintToScreen(string text, Color color, bool append)
        {
            if (append)
                RichTextBoxExtensions.AppendText(cliDisplayTxtBx, text, color);
            else
            {
                cliDisplayTxtBx.Text = "";
                RichTextBoxExtensions.AppendText(cliDisplayTxtBx, text, color);
            }
            ProtectCliPrefixText(false);
        }

        private void cliDisplayTxtBx_MouseClick(object sender, MouseEventArgs e)
        {
            ProtectCliPrefixText(false);
        }

        /// <summary>
        /// Protect CLI prefix text from being selected or edited.
        /// If trying to select prefix text, this function will move
        /// cursor to an index after prefix text in the current line
        /// </summary>
        /// <param name="predict">predict protection in case carret would have moved back one step</param>
        /// <returns>true if protection was applied</returns>
        private bool ProtectCliPrefixText(bool predict)
        {
            int predictStep = 0;
            if (predict)
                predictStep = 1;

            int selectionIndex = cliDisplayTxtBx.SelectionStart + 1 - predictStep;
            int currCarretLineIndex = cliDisplayTxtBx.GetLineFromCharIndex(selectionIndex);
            string currCarretLineStr = cliDisplayTxtBx.Lines[currCarretLineIndex];
            int lineStartIndex = cliDisplayTxtBx.GetFirstCharIndexOfCurrentLine();
            int lineRelativeSelection = cliDisplayTxtBx.SelectionStart - lineStartIndex;
            
            if (currCarretLineStr.Contains(CLI_PREFIX_TEXT))
            {
                if (lineRelativeSelection <= CLI_PREFIX_TEXT.Length)
                {
                    cliDisplayTxtBx.SelectionStart = lineStartIndex + CLI_PREFIX_TEXT.Length;
                    return true;
                }
            }
            return false;
        }

        private void cliDisplayTxtBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ExecuteCli();
            }

         
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
                    displayTxt.AppendText(msg);
                else
                    displayTxt.Text += msg;
            });
        }

        private void ExecuteCli()
        {
            // todo: extract only the command to excute without the prefix

            if (displayMode == DisplayMode.SSH)
            {
                ssh_.RunCommand(textToSendCmBx.Text);
                if (textToSendCmBx.Text == "exit")
                {
                    clearScreenBtn.PerformClick();
                    WriteLineToTerminal("ssh session terminated.");
                    ssh_ = null;
                    displayMode = DisplayMode.NORMAL;
                }
                PassOutTxtToHistory();
                return;
            }

            Argument argumentObj = null;
            string cmdAnswer = "";
            CommandParser.Type cmdType = CommandParser.Type.NONE;
            bool validCmd;
            validCmd = CommandParser.Parse(textToSendCmBx.Text, ref cmdAnswer, ref cmdType, ref argumentObj);

            if (validCmd)
            {
                switch (cmdType)
                {
                    case CommandParser.Type.PING:
                        {
                            string targetIp = ((PingArgument)argumentObj).GetIp();
                            int timeout = ((PingArgument)argumentObj).GetTimeout();
                            string reply = "";

                            if (timeout != -1) // use timeout
                                Pinger.Ping(targetIp, timeout, ref reply);
                            else // disable timeout
                                Pinger.Ping(targetIp, 0, ref reply);

                            break;
                        }

                    case CommandParser.Type.SSH:
                        {
                            bool success = ConnectSsh(((SshArgument)argumentObj).GetHostAddress(),
                                        ((SshArgument)argumentObj).GetUserName(),
                                        ((SshArgument)argumentObj).GetPassword(),
                                        ref cmdAnswer,
                                        ref ssh_);
                            if (success)
                                displayMode = DisplayMode.SSH;
                            break;
                        }

                    case CommandParser.Type.NONE:
                        break;
                }
            }
            WriteLineToTerminal(cmdAnswer);


            PrintLinePrefix();
        }
    }

   

    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
