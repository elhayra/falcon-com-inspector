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
            PrintToScreen(CLI_PREFIX_TEXT, Color.LawnGreen, true);
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



            ProtectCliPrefixText();
        }

        private void cliDisplayTxtBx_MouseClick(object sender, MouseEventArgs e)
        {
            ProtectCliPrefixText();
        }

        /// <summary>
        /// Protect CLI prefix text from being selected or edited.
        /// If trying to select prefix text, this function will move
        /// cursor to an index after prefix text in the current line
        /// </summary>
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
