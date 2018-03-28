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

        public void SetCounter(ulong count)
        {
            counter_ = count;
        }

        public void Add(ulong amount)
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
