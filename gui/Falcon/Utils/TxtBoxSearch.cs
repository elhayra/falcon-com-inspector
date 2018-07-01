
using System;
using System.Windows.Forms;

namespace Falcon.Utils
{
    class TxtBoxSearch
    {
        int searchPos;
        TextBox textBox;

        public TxtBoxSearch(ref TextBox textBox)
        {
            this.textBox = textBox;
        }

        /// <summary>
        /// Search text in TextBox and forward search position
        /// </summary>
        /// <param name="text">text to search</param>
        /// <returns>true if text found</returns>
        public bool Search(string text)
        {
            searchPos = textBox.Text.IndexOf(text);
            if (searchPos != -1)
            {
                textBox.SelectionStart = searchPos;
                textBox.SelectionLength = text.Length;
                textBox.HideSelection = false;
                searchPos += text.Length;
                return true;
            }
            searchPos = 0;
            return false;
        }

        /// <summary>
        /// Search text in TextBox from last searched position,
        /// and forward search position
        /// </summary>
        /// <param name="text">text to search</param>
        /// <returns>true if text found</returns>
        public bool SearchForward(string text)
        {
            bool found = false;
            try
            {
                string subStr = textBox.Text.Substring(searchPos, textBox.Text.Length - searchPos);
                int pos = subStr.IndexOf(text);
                if (searchPos != -1)
                {
                    textBox.SelectionStart = pos + searchPos;
                    textBox.SelectionLength = text.Length;
                    textBox.HideSelection = false;
                    searchPos += pos + searchPos + text.Length;
                    found = true;
                }
                else
                    found = false;

                if (searchPos >= textBox.Text.Length)
                {
                    searchPos = 0;
                }
            }
            catch (ArgumentOutOfRangeException exp)
            {
                found = false;
            }
            return found;
        }
    }
}
