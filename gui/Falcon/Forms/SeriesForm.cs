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
using Falcon.Graph;
using Falcon.Utils;
using System.Windows.Forms.DataVisualization.Charting;


namespace Falcon.Forms
{
    public partial class SeriesForm : Form
    {
        public SeriesForm()
        {
            InitializeComponent();
            List<SeriesManager> seriesManagersList = ChartManager.Inst.GetSeriesManagersList();
            foreach (var seriesManager in seriesManagersList)
                seriesLstBx.Items.Add(seriesManager.NameId);
            seriesTypeCmBx.Text = "Data";
        }

        private SeriesManager.Type seriesCmBxToType()
        {
            switch (seriesTypeCmBx.SelectedItem.ToString())
            {
                case "Data":
                    return SeriesManager.Type.INCOMING_DATA;
                case "Setpoint":
                    return SeriesManager.Type.SETPOINT;
                case "Bytes Rate":
                    return SeriesManager.Type.BYTES_RATE;
            }
            return SeriesManager.Type.NONE;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (nameTxt.Text == "")
            {
                MsgBox.ErrorMsg("Adding Series Failed", "You must enter a series name");
                return;
            }
            if (!ChartManager.Inst.IsNameUnique(nameTxt.Text))
            {
                MsgBox.ErrorMsg("Adding Series Failed", "This name already exist. Please choose a unique name");
                return;
            }

            byte dataIndex = Convert.ToByte(dataIndexTxt.Text);
            if (dataIndex == 255) //error
                return;
            ChartManager.Inst.AddSeries(nameTxt.Text,
                                        seriesCmBxToType(),
                                        dataIndex,
                                        (double)setpointTxt.Value);
            seriesLstBx.Items.Add(nameTxt.Text);
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (seriesLstBx.SelectedItem == null)
            {
                MsgBox.ErrorMsg("Removing Series Failed", "You must select a series to remove first");
                return;
            }
            string seriesId = seriesLstBx.SelectedItem.ToString();
            ChartManager.Inst.RemoveSeriesByName(seriesId);
            seriesLstBx.Items.Remove(seriesId);
        }

        private void removeAllBtn_Click(object sender, EventArgs e)
        {
            ChartManager.Inst.RemoveAllSeries();
            seriesLstBx.Items.Clear();
        }

        /// <summary>
        /// fill fields with series saved data
        /// </summary>
        private void seriesLstBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (seriesLstBx.SelectedItem == null)
                return;
            string selectedSeries = seriesLstBx.SelectedItem.ToString();
            SeriesManager seriesManager = ChartManager.Inst.GetSeries(selectedSeries);
            EnableOnlyTypeFields(seriesManager.DataType);
            switch (seriesManager.DataType)
            {
                case SeriesManager.Type.INCOMING_DATA:
                    seriesTypeCmBx.Text = "Data";
                    nameTxt.Text = seriesManager.NameId;
                    dataIndexTxt.Text = seriesManager.DataIndex.ToString();
                    break;

                case SeriesManager.Type.SETPOINT:
                    seriesTypeCmBx.Text = "Setpoint";
                    nameTxt.Text = seriesManager.NameId;
                    dataIndexTxt.Text = seriesManager.DataIndex.ToString();
                    setpointTxt.Text = seriesManager.Setpoint.ToString();
                    break;

                case SeriesManager.Type.BYTES_RATE:
                    seriesTypeCmBx.Text = "Bytes Rate";
                    dataIndexTxt.Text = seriesManager.DataIndex.ToString();
                    break;
            }
        }

        private void seriesTypeCmBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (seriesTypeCmBx.Text)
            {
                case "Data":
                    EnableOnlyTypeFields(SeriesManager.Type.INCOMING_DATA);
                    break;

                case "Setpoint":
                    EnableOnlyTypeFields(SeriesManager.Type.SETPOINT);
                    break;

                case "Bytes Rate":
                    EnableOnlyTypeFields(SeriesManager.Type.BYTES_RATE);
                    break;
            }
        }

        private void EnableOnlyTypeFields(SeriesManager.Type type)
        {
            switch (type)
            {
                case SeriesManager.Type.INCOMING_DATA:
                    nameTxt.Visible = true;
                    nameLbl.Visible = true;
                    nameTxt.Text = "";
                    dataIndexTxt.Visible = true;
                    dataIndexLbl.Visible = true;
                    setpointTxt.Visible = false;
                    setpointLbl.Visible = false;
                    break;

                case SeriesManager.Type.SETPOINT:
                    nameTxt.Visible = true;
                    nameLbl.Visible = true;
                    nameTxt.Text = "";
                    dataIndexTxt.Visible = false;
                    dataIndexLbl.Visible = false;
                    setpointTxt.Visible = true;
                    setpointLbl.Visible = true;
                    break;

                case SeriesManager.Type.BYTES_RATE:
                    nameTxt.Text = "Bytes Rate";
                    nameTxt.Visible = false; //name is default for bytes rate
                    nameLbl.Visible = false;
                    dataIndexTxt.Visible = false;
                    dataIndexLbl.Visible = false;
                    setpointTxt.Visible = false;
                    setpointLbl.Visible = false;
                    break;
            }

        }
    }


}
