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
                                        dataIndex,
                                        seriesCmBxToType(),
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
            if (seriesManager.DataType == SeriesManager.Type.SETPOINT)
            {
                seriesTypeCmBx.Text = "Setpoint";
                setpointTxt.Value = (decimal)seriesManager.Setpoint;
            }
            else if (seriesManager.DataType == SeriesManager.Type.INCOMING_DATA)
                seriesTypeCmBx.Text = "Data";
            else if (seriesManager.DataType == SeriesManager.Type.BYTES_RATE)
                seriesTypeCmBx.Text = "Bytes Rate";

            nameTxt.Text = seriesManager.NameId;
            dataIndexTxt.Value = seriesManager.DataIndex;
        }

        private void seriesTypeCmBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (seriesTypeCmBx.Text == "Data")
            {
                nameTxt.Visible = true;
                nameLbl.Visible = true;
                nameTxt.Text = "";
                dataIndexTxt.Visible = true;
                dataIndexLbl.Visible = true;
                setpointTxt.Visible = false;
                setpointLbl.Visible = false;
            }
            else if (seriesTypeCmBx.Text == "Setpoint")
            {
                nameTxt.Visible = true;
                nameLbl.Visible = true;
                nameTxt.Text = "";
                dataIndexTxt.Visible = false;
                dataIndexLbl.Visible = false;
                setpointTxt.Visible = true;
                setpointLbl.Visible = true;
            }
            else if (seriesTypeCmBx.Text == "Bytes Rate")
            {
                nameTxt.Text = "Bytes Rate";
                nameTxt.Visible = false;
                nameLbl.Visible = false;
                dataIndexTxt.Visible = false;
                dataIndexLbl.Visible = false;
                setpointTxt.Visible = false;
                setpointLbl.Visible = false;
            }
        }
    }


}
