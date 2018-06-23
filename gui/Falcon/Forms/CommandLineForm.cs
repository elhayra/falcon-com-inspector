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

        DisplayMode displayMode = DisplayMode.NORMAL;

        const int MAX_HISTORY_NODES = 10;

        DoubleStackHistoryBuffer historyBuff = new DoubleStackHistoryBuffer(MAX_HISTORY_NODES);

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
                        return true; //stop handling key here
                    }
                }

                if (keyData == Keys.Up)
                {
                    string command = "";
                    if (historyBuff.GetHistoryBackward(ref command))
                    {
                        RemoveLastCliLine();
                        PrintLinePrefix();
                        PrintToScreen(command, Color.White, true);
                    }
                    return true; //stop handling key here
                }

                if (keyData == Keys.Down)
                {
                    string command = "";
                    if (historyBuff.GetHistoryForward(ref command))
                    {
                        RemoveLastCliLine();
                        PrintLinePrefix();
                        PrintToScreen(command, Color.White, true);
                    }
                    return true; //stop handling key here
                }
            }

            return base.ProcessCmdKey(ref msg, keyData); 
        }

        /// <summary>
        /// Remove last line in CLI. This method of removing last line
        /// keep RTF colors unchanged
        /// </summary>
        private void RemoveLastCliLine()
        {
            List<string> physicalLines = GetPhysicalCliLines();

            int lineStartIndex = cliDisplayTxtBx.GetFirstCharIndexOfCurrentLine();

            cliDisplayTxtBx.SelectionStart = lineStartIndex;
            cliDisplayTxtBx.SelectionLength = physicalLines[physicalLines.Count - 1].Length;
            cliDisplayTxtBx.SelectedText = "";
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

            List<string> physicalLines = GetPhysicalCliLines();

            int c = cliDisplayTxtBx.Lines.Length;
            int selectionIndex = cliDisplayTxtBx.SelectionStart - predictStep;
            int currCarretLineIndex = cliDisplayTxtBx.GetLineFromCharIndex(selectionIndex);
            string currCarretLineStr = physicalLines[currCarretLineIndex];
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

        /// <summary>
        /// get physical lines. physical line is a new line 
        /// as it apears in the textbox, and not necesseraly a new line 
        /// that ends with \n
        /// </summary>
        /// <returns>List of physical line in display text box</returns>
        private List<string> GetPhysicalCliLines()
        {
            bool continueProcess = true;
            int i = 1; //Zero Based So Start from 1
            int j = 0;
            List<string> result = new List<string>();
            while (continueProcess)
            {
                var index = cliDisplayTxtBx.GetFirstCharIndexFromLine(i);
                if (index != -1)
                {
                    result.Add(cliDisplayTxtBx.Text.Substring(j, index - j));
                    j = index;
                    i++;
                }
                else
                {
                    result.Add(cliDisplayTxtBx.Text.Substring(j, cliDisplayTxtBx.Text.Length - j));
                    continueProcess = false;
                }
            }

            return result;
        }

        private void cliDisplayTxtBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string command = GetCommandInCurrentLine();
                ExecuteCli(command);
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
                PrintToScreen(msg, Color.White, true);
            });
        }

        /// <summary>
        /// Get the command in the current line (without CLI prefix)
        /// </summary>
        /// <returns>the command in current line, or empty string if the line is not command line</returns>
        private string GetCommandInCurrentLine()
        {
            List<string> physicalLines = GetPhysicalCliLines();

            int selectionIndex = cliDisplayTxtBx.SelectionStart + 1;
            // get line index before enter was pressed
            int prevCarretLineIndex = cliDisplayTxtBx.GetLineFromCharIndex(selectionIndex) - 1;
            string currCarretLineStr = physicalLines[prevCarretLineIndex];

            if (currCarretLineStr.Contains(CLI_PREFIX_TEXT))
            {
                string [] splittedLine = currCarretLineStr.Split('>');
                if (splittedLine.Length == 2)
                {
                    string command = splittedLine[1].TrimStart();
                    command = command.TrimEnd('\r', '\n');
                    return command;
                }

            }
            return "";
        }

        /// <summary>
        /// Parse and execute command line
        /// </summary>
        /// <param name="commandLine">Falcon command line string</param>
        private void ExecuteCli(string commandLine)
        {
            historyBuff.ResetNavigation();
            historyBuff.AddItem(commandLine);

            if (displayMode == DisplayMode.SSH)
            {
                ssh_.RunCommand(commandLine);
                if (commandLine == "exit")
                {
                    ssh_.Close();
                    PrintToScreen("ssh session terminated.", Color.White, true);
                    ssh_ = null;
                    displayMode = DisplayMode.NORMAL;
                }
                return;
            }

            Argument argumentObj = null;
            string reply = "";
            string parserAnswer = "";
            CommandParser.Type cmdType = CommandParser.Type.NONE;
            bool validCmd;
            validCmd = CommandParser.Parse(commandLine, ref parserAnswer, ref cmdType, ref argumentObj);

            if (validCmd)
            {
                switch (cmdType)
                {
                    case CommandParser.Type.PING:
                        {
                            string targetIp = ((PingArgument)argumentObj).GetIp();
                            int timeout = ((PingArgument)argumentObj).GetTimeout();

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
                                        ref reply,
                                        ref ssh_);
                            if (success)
                                displayMode = DisplayMode.SSH;
                            break;
                        }

                    case CommandParser.Type.NONE:
                        break;
                }
            }

            if (parserAnswer != "")
                PrintToScreen(parserAnswer + "\n", Color.White, true);
            if (reply != "")
                PrintToScreen(reply + "\n", Color.White, true);

            PrintLinePrefix();
        }

        private void cliDisplayTxtBx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                PrintToScreen("^C\n", Color.White, true);
                PrintLinePrefix();
            }
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
