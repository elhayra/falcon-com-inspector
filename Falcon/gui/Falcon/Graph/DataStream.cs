using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.Graph
{
    class DataStream
    {
        public static double[] extractCsvFromLine(string line)
        {
            /* find data opening character */
            int breakIndex = line.IndexOf(SeriesManager.DATA_OPEN_CHAR);
            if (breakIndex < 0)
                return null;

            string trimmedRow = line.Substring(breakIndex + 1);

            /* find data closing character */
            breakIndex = trimmedRow.IndexOf(SeriesManager.DATA_CLOSE_CHAR);
            if (breakIndex < 0)
                return null;
            trimmedRow = trimmedRow.Substring(0, breakIndex);
            string[] dataArr = trimmedRow.Split(',');
            var csv = new double[dataArr.Length];
            for (int indx = 0; indx < dataArr.Length; indx++)
            {
                try
                {
                    csv[indx] = Convert.ToDouble(dataArr[indx]);
                }
                catch (FormatException exp)
                {
                    return null;
                }
            }
            return csv;
        }
    }
}
