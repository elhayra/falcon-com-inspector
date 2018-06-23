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
            PrintToScreen(CLI_PREFIX_TEXT, true);
        }

        private void cliDisplayTxtBx_KeyPress(object sender, KeyPressEventArgs e)
        {

            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    {
                        PrintLinePrefix();
                        break;
                    }
            }
        }

        private void PrintToScreen(string text, bool append)
        {
            if (append)
                cliDisplayTxtBx.Text += text;
            else
                cliDisplayTxtBx.Text = text;
            ProtectCliPrefixText();
        }

        private void cliDisplayTxtBx_MouseClick(object sender, MouseEventArgs e)
        {
            ProtectCliPrefixText();
        }

        private void ProtectCliPrefixText()
        {
            int selectionIndex = cliDisplayTxtBx.SelectionStart + 1;
            int currCarretLineIndex = cliDisplayTxtBx.GetLineFromCharIndex(selectionIndex);
            string currCarretLineStr = cliDisplayTxtBx.Lines[currCarretLineIndex];
            int lineStartIndex = cliDisplayTxtBx.GetFirstCharIndexOfCurrentLine();
            int lineRelativeSelection = cliDisplayTxtBx.SelectionStart - lineStartIndex;
            
            if (currCarretLineStr.Contains(CLI_PREFIX_TEXT))
            {
                if (lineRelativeSelection <= CLI_PREFIX_TEXT.Length)
                    cliDisplayTxtBx.SelectionStart = lineStartIndex + CLI_PREFIX_TEXT.Length;
            }
        }
    }
}
