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

        public const char DATA_OPEN_CHAR = '|';
        public const char DATA_CLOSE_CHAR = '|';
        public string NameId;

        /// <summary>
        /// number b/w 0-9
        /// </summary>
        public byte DataIndex;

        /// <summary>
        /// setpoint value only used if 
        /// DataType == SETPOINT
        /// </summary>
        public double Setpoint;

        /// <summary>
        /// Type of data:
        /// NONE - not initialized
        /// INCOMING_DATA - data from outter source (tcp/udp/serial)
        /// SETPOINT - fixed data to create horizontal line
        /// BYTES_RATE - incoming bytes rate data from main form
        /// </summary>
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
