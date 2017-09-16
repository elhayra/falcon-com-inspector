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
    

    public class SeriesManager
    {
        public string NameId;

        /// <summary>
        /// number b/w 0-9
        /// </summary>
        public byte DataIndex;

        /// <summary>
        /// setpoint value should only be used if 
        /// DataType == SETPOINT
        /// </summary>
        public double Setpoint;
        public Type DataType;

        public enum Type
        {
            NONE,
            BYTES_RATE,
            SETPOINT,
            INCOMING_DATA
        }

        public SeriesManager(string nameId, Type dataType, byte dataIndex, double setpoint)
        {
            NameId = nameId;
            DataType = dataType;
            DataIndex = dataIndex;
            Setpoint = setpoint;
        }

        public override string ToString()
        {
            return NameId;
        }
    }
}
