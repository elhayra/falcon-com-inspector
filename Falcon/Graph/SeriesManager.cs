using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;


namespace Falcon.Graph
{
    /// <summary>
    /// Series contains a list of points which will be drawn on chart
    /// </summary>
    

    class SeriesManager
    {
        public int TailSize;
        public string NameId;
        public int DataSourceIndex;
        public double Setpoint;
        public bool IsSetpoint;

        public SeriesManager(string nameId, int tailSize, int dataSourceIndex, bool isSetpoint, double setpoint)
        {
            NameId = nameId;
            TailSize = tailSize;
            DataSourceIndex = dataSourceIndex;
            IsSetpoint = isSetpoint;
            Setpoint = setpoint;
        }

        public override string ToString()
        {
            return NameId;
        }
    }
}
