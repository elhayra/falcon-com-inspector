using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.PackageWizard
{
    class Package
    {
        public enum EndianTypeEnum
        {
            BIG,
            SMALL
        }

        public enum FieldTypeEnum
        {
            UINT8,
            INT8, 
            UINT16,
            INT16, 
            UINT32,
            INT32,
            UINT64,
            INT64,
            FLOAT32, 
            FLOAT64,
            STRING
        }

        //private List<fields> headerFields = new List<fields>();

        //private List<fields> dataFields = new List<fields>();

        //public void AddField()
    }
}
