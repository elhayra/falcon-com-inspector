using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;

namespace Falcon.Forms
{
    public partial class GraphForm : Form
    {
        public GraphForm()
        {
            InitializeComponent();
        }

        public void Monitor()
        {
            for (int i = 0; i < 100; i++ )
            {
                chart.Series["Data"].Points.AddXY(i, i);
                if (chart.Series["Data"].Points.Count > 3)
                    chart.Series["Data"].Points.RemoveAt(chart.Series["Data"].Points.Count - 4);
                chart.ResetAutoValues();
                chart.Update();
                Thread.Sleep(800);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Monitor();
        }
    }
}
