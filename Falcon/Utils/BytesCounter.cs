using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.Utils
{
    public class BytesCounter
    {
        private ulong counter_ = 0;

        public enum MeasureUnit
        {
            B,
            KB,
            MB,
            GB,
            TB
        }

        public void Add(uint amount)
        {
            counter_ += amount;
        }

        public void Reset()
        {
            counter_ = 0;
        }

        public double CounterKB()
        {
            return counter_ / 1000.0;
        }

        public double CounterMB()
        {
            return CounterKB() / 1000.0;
        }

        public double CounterGB()
        {
            return CounterMB() / 1000.0;
        }

        public double CounterTB()
        {
            return CounterGB() / 1000.0;
        }

        public ulong GetRawCounter() { return counter_; }

        public double GetProcessedCounter(MeasureUnit mUnit)
        {
            switch (mUnit)
            {
                case MeasureUnit.B:
                    return counter_;
                case MeasureUnit.KB:
                    return CounterKB();
                case MeasureUnit.MB:
                    return CounterMB();
                case MeasureUnit.GB:
                    return CounterGB();
                case MeasureUnit.TB:
                    return CounterTB();
            }
            return -1;
        }

        public MeasureUnit RecomendedMeasureUnit()
        {
            if (counter_ > 1000)
            {
                if (counter_ < 1000000)
                    return MeasureUnit.KB;
                if (counter_ < 1000000000)
                    return MeasureUnit.MB;
                if (counter_ < 1000000000000)
                    return MeasureUnit.GB;
                return MeasureUnit.TB;
            }
            else return MeasureUnit.B;
        }

        public static string MeasureUnitToString(MeasureUnit mUnit)
        {
            switch (mUnit)
            {
                case MeasureUnit.B:
                    return "B";
                case MeasureUnit.KB:
                    return "KB";
                case MeasureUnit.MB:
                    return "MB";
                case MeasureUnit.GB:
                    return "GB";
                case MeasureUnit.TB:
                    return "TB";
            }
            return "";
        }
    }
}
