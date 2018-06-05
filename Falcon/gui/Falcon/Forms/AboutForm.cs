using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Falcon.Forms
{
    partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

        }

        private void okButton_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(urlLbl.Text);
        }
    }
}
