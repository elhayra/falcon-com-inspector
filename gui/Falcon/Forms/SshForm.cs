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
    public partial class SshForm : Form
    {
        public SshForm()
        {
            InitializeComponent();
        }

        // prevent form from loosing focus because shell 
        // is waiting for ssh credentials
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            this.Focus();
        }

        private void SshForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // TODO: IF CANCLED, LET SHELL KNOW ABOUT IT
        }

    }
}
