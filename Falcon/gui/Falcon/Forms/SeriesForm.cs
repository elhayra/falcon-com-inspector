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
