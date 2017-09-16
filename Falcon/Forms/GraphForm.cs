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
using Falcon.Com;

namespace Falcon.Forms
{
    public partial class GraphForm : Form
    {
        SeriesForm seriesFrom_;
        TextBox dataTxBx_;
        
        public GraphForm(ref TextBox dataInScreenTxt)
        {
            InitializeComponent();
            ChartManager.Inst.Init(ref chart);
            chart.MouseWheel += chData_MouseWheel;
            dataTxBx_ = dataInScreenTxt;
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
            ChartManager.Inst.SecondsCounter++;

            foreach (var series in ChartManager.Inst.GetSeriesManagersList())
            {
                switch (series.DataType)
                {
                    case SeriesManager.Type.BYTES_RATE:
                        addPointToSeries("Bytes Rate", ConnectionsManager.Inst.BytesRateCounter.GetRawCounter());
                        break;

                    case SeriesManager.Type.SETPOINT:
                        addPointToSeries(series.NameId, series.Setpoint);
                        break;

                    case SeriesManager.Type.INCOMING_DATA:
                        //add spline according to incoming data
                        double result = 0;
                        bool validData = extractDataSrcFromCsvRow(series.DataIndex, ref result);
                  
                        if (validData)
                            addPointToSeries(series.NameId, result);
                        break;
                }
            }
        }

        private bool extractDataSrcFromCsvRow(int index, ref double result)
        {
            //find opening break character
            string lastLine = "";
            if (dataTxBx_.Lines.Any())
                lastLine = dataTxBx_.Lines[dataTxBx_.Lines.Length - 2];

            int breakIndex = lastLine.IndexOf('|');
            if (breakIndex < 0)
                return false;

           // result = 1; //delete after test
          //  return true;

            string trimmedRow = lastLine.Substring(breakIndex+1);

            //find closing break character
            breakIndex = trimmedRow.IndexOf('|');
            if (breakIndex < 0)
                return false;
            trimmedRow = trimmedRow.Substring(0, breakIndex);

            string[] dataArr = trimmedRow.Split(',');
            result = Convert.ToDouble(dataArr[index]);
            return true;
        }

        private void addPointToSeries(string seriesName, double y)
        {
            chart.Series[seriesName].Points.AddXY(ChartManager.Inst.SecondsCounter, y);
            if (chart.Series[seriesName].Points.Count == ChartManager.Inst.TailLength) //trim line tail
            {
                DataPoint firstElement = chart.Series[seriesName].Points.First<DataPoint>();
                chart.Series[seriesName].Points.Remove(firstElement);
            }
            chart.ResetAutoValues();
            chart.Update();
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
       
        }



        private void GraphForm_Deactivate(object sender, EventArgs e)
        {
            chart.Enabled = false;
        }

        private void GraphForm_Activated(object sender, EventArgs e)
        {
            chart.Enabled = true;
        }



        private void sampleRateCmBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string hzStr = sampleRateCmBx.SelectedItem.ToString().Split(' ')[0]; //extract hz value
            int hz = int.Parse(hzStr);
            graphTimer.Interval = 1000 / hz;
        }

        private void tailCmBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChartManager.Inst.TailLength = Convert.ToByte(tailCmBx.SelectedItem);
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addRmSeriesBtn_Click(object sender, EventArgs e)
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

        private void resetGraphBtn_Click(object sender, EventArgs e)
        {
        }
    }
}
