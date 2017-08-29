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
using Falcon.Utils;

namespace Falcon.Forms
{
    public partial class GraphForm : Form
    {
        BytesCounter bytesRateCounter_;
        ulong secondsCounter_ = 0;
        int tailSize_ = 10;

        public GraphForm(ref BytesCounter bytesRateCounter)
        {
            InitializeComponent();
            bytesRateCounter_ = bytesRateCounter;
        }

        public void Monitor()
        {
            for (int i = 0; i < 100; i++ )
            {
                chart.Series["Data"].Points.AddXY(i, i*i);
                if (chart.Series["Data"].Points.Count > 10)
                    chart.Series["Data"].Points.RemoveAt(chart.Series["Data"].Points.Count - 11);
                
                Thread.Sleep(800);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Monitor();
        }

        private void graphTimer_Tick(object sender, EventArgs e)
        {
            secondsCounter_++;
            chart.Series["Bytes Rate"].Points.AddXY(secondsCounter_, bytesRateCounter_.GetRawCounter());
            if (chart.Series["Bytes Rate"].Points.Count == tailSize_)
            {
                DataPoint firstElement = chart.Series["Bytes Rate"].Points.First<DataPoint>();
                chart.Series["Bytes Rate"].Points.Remove(firstElement);
                chart.ResetAutoValues();
                chart.Update();
            }
            
        }
    }
}
