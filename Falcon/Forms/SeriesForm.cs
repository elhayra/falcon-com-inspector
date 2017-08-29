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
            dataSourceCmBx.Text = "Bytes Rate";
            tailSizeCmBx.Text = "10";
            seriesTypeCmBx.Text = "Regular";
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
            bool isSetpoint = true;
            if (seriesTypeCmBx.Text == "Regular")
                isSetpoint = false;

            ChartManager.Inst.AddSeries(nameTxt.Text,
                                        tailSizeToInt(tailSizeCmBx.Text),
                                        dataSourceToInt(dataSourceCmBx.Text),
                                        isSetpoint,
                                        (double)setpointTxt.Value);
            seriesLstBx.Items.Add(nameTxt.Text);

        }

        public int dataSourceToInt(string dataSource)
        {
            switch (dataSource)
            {
                case "Bytes Rate":
                    return -1;
                case "Index 0":
                    return 0;
                case "Index 1":
                    return 1;
                case "Index 2":
                    return 2;
                case "Index 3":
                    return 3;
                case "Index 4":
                    return 4;
                case "Index 5":
                    return 5;
                case "Index 6":
                    return 6;
                case "Index 7":
                    return 7;
                case "Index 8":
                    return 8;
                case "Index 9":
                    return 9;
            }
            return -2;
        }

        public int tailSizeToInt(string tailSize)
        {
            switch (tailSize)
            {
                case "10":
                    return 10;
                case "Index 20":
                    return 20;
                case "Index 50":
                    return 50;
                case "Index 100":
                    return 100;
                case "Index 300":
                    return 300;
                case "Index 500":
                    return 500;
            }
            return -1;
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (seriesLstBx.SelectedItem == null)
            {
                MsgBox.ErrorMsg("Removing Series Failed", "You must select a series to remove first");
                return;
            }
            string seriesId = seriesLstBx.SelectedItem.ToString();
            ChartManager.Inst.RemoveSeries(seriesId);
            seriesLstBx.Items.Remove(seriesId);
        }

        private void removeAllBtn_Click(object sender, EventArgs e)
        {
            ChartManager.Inst.RemoveAllSeries();
            seriesLstBx.Items.Clear();
        }

        private void seriesLstBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (seriesLstBx.SelectedItem == null)
                return;
            string selectedSeries = seriesLstBx.SelectedItem.ToString();
            SeriesManager seriesManager = ChartManager.Inst.GetSeries(selectedSeries);
            if (seriesManager.IsSetpoint)
            {
                seriesTypeCmBx.Text = "Setpoint";
                setpointTxt.Value = (decimal)seriesManager.Setpoint;
            }
            else
                seriesTypeCmBx.Text = "Regular";
            nameTxt.Text = seriesManager.NameId;
            if (seriesManager.DataSourceIndex == -1)
                dataSourceCmBx.Text = "Bytes Rate";
            else
                dataSourceCmBx.Text = "Index " + seriesManager.DataSourceIndex.ToString();
            tailSizeCmBx.Text = seriesManager.TailSize.ToString();
        }

        private void seriesTypeCmBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (seriesTypeCmBx.Text == "Regular")
                setpointTxt.Enabled = false;
            else
                setpointTxt.Enabled = true;
        }
    }


}
