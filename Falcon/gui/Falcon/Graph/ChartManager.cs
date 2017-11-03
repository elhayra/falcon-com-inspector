using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;


namespace Falcon.Graph
{
    class ChartManager
    {
        public const int MAX_SERIESES = 10;
        public double LastPointTime = 0; //secs
        public int TailLength = 100;

        /* this list also allows keep track after tail length */
        List<SeriesManager> seriesManagersList_ = new List<SeriesManager>();

        Chart chart_ = null;

        protected static readonly object padlock = new object();
        private static ChartManager instance = null;
        

        public SeriesManager GetSeries(string nameId)
        {
            return FindSeriesManager(nameId);
        }

        public List<SeriesManager> GetSeriesManagersList()
        {
            return seriesManagersList_;
        }

        public bool IsNameUnique(string nameId)
        {
            if (FindSeries(nameId) != null)
                return false;
            return true;
        }

        public void Init(ref Chart chart)
        {
            chart_ = chart;
        }

        public static ChartManager Inst
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        
                        instance = new ChartManager();
                    }
                    return instance;
                }
            }
        }

        public void Reset()
        {
            lock (padlock)
            {
                instance = new ChartManager();
            }
        }

        private bool IsFull()
        {
            if (chart_.Series.Count > MAX_SERIESES)
                return true;
            return false;
        }

        public bool AddSeries(string nameId,
                              SeriesManager.Type type,
                              byte dataIndex, 
                              double setpoint)
        {
            if (IsFull())
                return false;
            var newSeriesManager = new SeriesManager(nameId, type, dataIndex, setpoint);
            seriesManagersList_.Add(newSeriesManager);

            var newSeries = new Series(nameId);
            newSeries.BorderWidth = 4;
            if (type == SeriesManager.Type.SETPOINT)
                newSeries.ChartType = SeriesChartType.Line;
            else if (type == SeriesManager.Type.INCOMING_DATA || type == SeriesManager.Type.BYTES_RATE)
                newSeries.ChartType = SeriesChartType.Spline;
            chart_.Series.Add(newSeries);
            return true;
        }

        public void RemoveSeriesByName(string nameId)
        {
            seriesManagersList_.Remove(FindSeriesManager(nameId));
            chart_.Series.Remove(FindSeries(nameId));
        }

        public void RemoveAllSeries()
        {
            foreach (var series in chart_.Series.ToList())
                RemoveSeriesByName(series.Name);
        }

        private Series FindSeries(string nameId)
        {
            foreach (var series in chart_.Series)
            {
                if (series.Name == nameId)
                    return series;
            }
            return null;
        }

        private SeriesManager FindSeriesManager(string nameId)
        {
            foreach (var series in seriesManagersList_)
            {
                if (series.NameId == nameId)
                    return series;
            }
            return null;
        }

        public void UpdateChart()
        {
            chart_.ResetAutoValues();
            chart_.Update();
        }

        public void TrimAllToTailSize()
        {
            foreach(var series in chart_.Series)
            {
                TrimToTailSize(series.Name);
            }
            
        }

        private bool TrimToTailSize(string nameId)
        {
            var seriesManager = FindSeriesManager(nameId);

            if (chart_.Series[nameId].Points.Count == TailLength)
            {
                DataPoint firstElement = chart_.Series[nameId].Points.First<DataPoint>();
                chart_.Series[nameId].Points.Remove(firstElement);
                return true;
            }
            else
            {
                while (TailLength <= chart_.Series[nameId].Points.Count)
                {
                    DataPoint firstElement = chart_.Series[nameId].Points.First<DataPoint>();
                    chart_.Series[nameId].Points.Remove(firstElement);
                }
                return true;
            }

            return false;
        }

        public void AddPointToSeries(string nameId, double x, double y)
        {
            chart_.Series[nameId].Points.Add(new DataPoint(x, y));
        }
    }
}
