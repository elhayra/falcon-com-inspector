/*******************************************************************************
* Copyright (c) 2018 Elhay Rauper
* All rights reserved.
*
* Redistribution and use in source and binary forms, with or without
* modification, are permitted (subject to the limitations in the disclaimer
* below) provided that the following conditions are met:
*
*     * Redistributions of source code must retain the above copyright notice,
*     this list of conditions and the following disclaimer.
*
*     * Redistributions in binary form must reproduce the above copyright
*     notice, this list of conditions and the following disclaimer in the
*     documentation and/or other materials provided with the distribution.
*
*     * Neither the name of the copyright holder nor the names of its
*     contributors may be used to endorse or promote products derived from this
*     software without specific prior written permission.
*
* NO EXPRESS OR IMPLIED LICENSES TO ANY PARTY'S PATENT RIGHTS ARE GRANTED BY
* THIS LICENSE. THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND
* CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
* LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
* PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
* CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
* EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
* PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR
* BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER
* IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
* ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
* POSSIBILITY OF SUCH DAMAGE.
*******************************************************************************/

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
using System.Diagnostics;

namespace Falcon.Forms
{
    public partial class GraphForm : Form
    {
        SeriesForm seriesFrom_;
        Stopwatch stopwatch_;

        bool gotData_ = false;

        public GraphForm(ref TextBox dataInScreenTxt)
        {
            InitializeComponent();
            ChartManager.Inst.Init(ref chart);
            chart.MouseWheel += chData_MouseWheel;

            stopwatch_ = new Stopwatch();
            stopwatch_.Start();

            //Console.WriteLine("Elapsed={0}", sw.Elapsed);
        }

        public void OnIncomingData(string data)
        {
            gotData_ = true;
            double[] resultCsv = null;
            resultCsv = DataStream.extractCsvFromLine(data);
            ToggleInvalidDataAlert("", false);

            if (resultCsv != null && resultCsv.Length > 0)
            {
                TreeNode root = treeView.Nodes[0];
                stopwatch_.Stop();
                ChartManager.Inst.LastPointTime = stopwatch_.ElapsedMilliseconds / 1000.0;

                foreach (var series in ChartManager.Inst.GetSeriesManagersList())
                {
                    try
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
                                /* fill tree view node with series name and data value */
                                root.Nodes[series.DataIndex].Nodes[0].Text = series.NameId;
                                root.Nodes[series.DataIndex].Nodes[0].Nodes[0].Text = resultCsv[series.DataIndex].ToString();

                                addPointToSeries(series.NameId, resultCsv[series.DataIndex]);
                                break;
                            default:
                                ToggleInvalidDataAlert("INVALID DATA", true);
                                break;
                        }
                    }
                    catch (ObjectDisposedException exp)
                    {
                        return;
                    }
                }

                stopwatch_.Start();
            }
            else
            {
                ToggleInvalidDataAlert("INVALID DATA", true);
            }

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


        private void graphTimer_Tick(object sender, EventArgs e)
        {
            if (!gotData_)
                ToggleInvalidDataAlert("NO DATA", true);
            else
                gotData_ = false;
        }

        private void ToggleInvalidDataAlert(string msg, bool onoff)
        {
            invalidDataLbl.Text = msg;
            invalidDataLbl.Visible = onoff;
        }

        private void addPointToSeries(string seriesName, double y)
        {
            ChartManager.Inst.AddPointToSeries(seriesName, ChartManager.Inst.LastPointTime, y);
            ChartManager.Inst.TrimAllToTailSize();
            ChartManager.Inst.UpdateChart();
        }

        private void chart_MouseLeave(object sender, EventArgs e)
        {
            if (chart.Focused) chart.Parent.Focus();
        }

        private void chart_MouseEnter(object sender, EventArgs e)
        {
            if (!chart.Focused) chart.Focus();
        }

        private void GraphForm_Deactivate(object sender, EventArgs e)
        {
            chart.Enabled = false;
        }

        private void GraphForm_Activated(object sender, EventArgs e)
        {
            chart.Enabled = true;
        }

        private void addRmBtn_Click(object sender, EventArgs e)
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



        private void tailTxt_ValueChanged(object sender, EventArgs e)
        {
            tailTxt.BackColor = Color.White;
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            tailTxt.BackColor = Color.LightGreen;
            ChartManager.Inst.TailLength = (int)tailTxt.Value;
            //TODO: UPDATE TIME AXIS ACCORDINGLY
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {

        }

        private void GraphForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                applyBtn.PerformClick();
            }
        }
    }
}
