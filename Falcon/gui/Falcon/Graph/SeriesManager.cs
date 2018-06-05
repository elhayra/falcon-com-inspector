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
