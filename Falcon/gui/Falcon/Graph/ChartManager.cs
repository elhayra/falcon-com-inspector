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

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;


namespace Falcon.Graph
{
    class ChartManager
    {
        public const int MAX_SERIESES = 10;
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
        }

        public void AddPointToSeries(string nameId, double x, double y)
        {
            chart_.Series[nameId].Points.Add(new DataPoint(x, y));
        }
    }
}
