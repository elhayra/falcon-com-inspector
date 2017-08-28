

        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.Net;
        using System.Windows.Forms;


namespace Falcon.Utils
{
    public static class MsgBox
    {
        public static void ErrorMsg(String title, String content)
        {
            MessageBox.Show(content,
                            title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }

        public static void WarningMsg(String title, String content)
        {
            MessageBox.Show(content,
                            title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
        }
        public static void InfoMsg(String title, String content)
        {
            MessageBox.Show(content,
                            title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        public static bool YesNoMsg(string title, string content)
        {
            var window = MessageBox.Show(
                title,
                content,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );

            return (window == DialogResult.Yes);
        }
    }
}
