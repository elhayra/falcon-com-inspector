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
    public partial class PreferencesForm : Form
    {
        public PreferencesForm()
        {
            InitializeComponent();
            cmdCharCmBx.Text = Properties.Settings.Default.cmdChar.ToString();
        }

        private void PreferencesForm_Load(object sender, EventArgs e)
        {

        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.cmdChar = Convert.ToChar(cmdCharCmBx.Text);

            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
        }
    }
}
