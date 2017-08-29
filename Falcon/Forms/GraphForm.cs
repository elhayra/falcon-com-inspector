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
using Falcon.Graph;

namespace Falcon.Forms
{
    public partial class GraphForm : Form
    {
        BytesCounter bytesRateCounter_;
        SeriesForm seriesFrom_;
        
        int tailSize_ = 10;

        public GraphForm(ref BytesCounter bytesRateCounter)
        {
            InitializeComponent();
            bytesRateCounter_ = bytesRateCounter;
            ChartManager.Inst.Init(ref chart);
            chart.MouseWheel += chData_MouseWheel;
        }

        private void chData_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Delta < 0)
                {
                    chart.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                    chart.ChartAreas[0].AxisY.ScaleView.ZoomReset();
                }

                if (e.Delta > 0)
                {
                    double xMin = chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                    double xMax = chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                    double yMin = chart.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                    double yMax = chart.ChartAreas[0].AxisY.ScaleView.ViewMaximum;

                    double posXStart = chart.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
                    double posXFinish = chart.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;
                    double posYStart = chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 4;
                    double posYFinish = chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 4;

                    chart.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish);
                    chart.ChartAreas[0].AxisY.ScaleView.Zoom(posYStart, posYFinish);
                }
            }
            catch { }
        }

        public void Monitor()
        {
           /* for (int i = 0; i < 100; i++ )
            {
                chart.Series["Data"].Points.AddXY(i, i*i);
                if (chart.Series["Data"].Points.Count > 10)
                    chart.Series["Data"].Points.RemoveAt(chart.Series["Data"].Points.Count - 11);
                
                Thread.Sleep(800);
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // Monitor();
        }

        private void graphTimer_Tick(object sender, EventArgs e)
        {
            /*ChartManager.Inst.SecondsCounter++;
            
            chart.Series["Bytes Rate"].Points.AddXY(ChartManager.Inst.SecondsCounter, bytesRateCounter_.GetRawCounter());
            if (chart.Series["Bytes Rate"].Points.Count == tailSize_)
            {
                DataPoint firstElement = chart.Series["Bytes Rate"].Points.First<DataPoint>();
                chart.Series["Bytes Rate"].Points.Remove(firstElement);
                chart.ResetAutoValues();
                chart.Update();
            }*/
            
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void chart_MouseLeave(object sender, EventArgs e)
        {
            if (chart.Focused) chart.Parent.Focus();
        }

        private void chart_MouseEnter(object sender, EventArgs e)
        {
            if (!chart.Focused) chart.Focus();
        }

        private void addRemoveBtn_Click(object sender, EventArgs e)
        {
            
            if (seriesFrom_ == null || seriesFrom_.IsDisposed)
            {
                seriesFrom_ = new SeriesForm();
                seriesFrom_.Show();
                seriesFrom_.Focus();
            }
            else
            {
                seriesFrom_.Show();
                seriesFrom_.Focus();
            }
        }



        private void GraphForm_Deactivate(object sender, EventArgs e)
        {
            chart.Enabled = false;
        }

        private void GraphForm_Activated(object sender, EventArgs e)
        {
            chart.Enabled = true;
        }
    }
}
