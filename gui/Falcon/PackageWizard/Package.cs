
using Kaveret.Cells;
using System.Collections.Generic;

namespace Falcon.PackageWizard
{
    class Package
    {
        private List<Cell> cellsList = new List<Cell>();
        private int nextCellIndx = 0;

        protected static readonly object padlock = new object();
        private static Package instance = null;

        public static Package Inst
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Package();
                    }
                    return instance;
                }
            }
        }

        public List<Cell> GetCells()
        {
            return cellsList;
        }

        public bool IsExist(string name)
        {
            foreach (Cell cell in cellsList)
            {
                if (cell.GetName() == name)
                    return true;
            }
            return false;
        }

        /// <param name="size">Ignored unless string</param>
        public bool AddCell(string type, string name, int size)
        {
            switch (type)
            {
                case "uint8":
                    var newUint8 = new UInt8Cell(nextCellIndx);
                    AddCell(newUint8, name, size);
                    return true;
                case "int8":
                    var newInt8 = new Int8Cell(nextCellIndx);
                    AddCell(newInt8, name, size);
                    return true;
                case "uint16":
                    var newUint16 = new UInt16Cell(nextCellIndx);
                    AddCell(newUint16, name, size);
                    return true;
                case "int16":
                    var newInt16 = new Int16Cell(nextCellIndx);
                    AddCell(newInt16, name, size);
                    return true;
                case "uint32":
                    var newUint32 = new UInt32Cell(nextCellIndx);
                    AddCell(newUint32, name, size);
                    return true;
                case "int32":
                    var newInt32 = new Int32Cell(nextCellIndx);
                    AddCell(newInt32, name, size);
                    return true;
                case "uint64":
                    var newUint64 = new UInt64Cell(nextCellIndx);
                    AddCell(newUint64, name, size);
                    return true;
                case "int64":
                    var newInt64 = new Int64Cell(nextCellIndx);
                    AddCell(newInt64, name, size);
                    return true;
                case "float32":
                    var newFloat32 = new Float32Cell(nextCellIndx);
                    AddCell(newFloat32, name, size);
                    return true;
                case "float64":
                    var newFloat64 = new Float64Cell(nextCellIndx);
                    AddCell(newFloat64, name, size);
                    return true;
                case "string":
                    var newString = new StringCell(nextCellIndx);
                    AddCell(newString, name, size);
                    return true;
            }

            return false;
        }

        private void AddCell(Cell cell, string name, int size)
        {
            cell.SetName(name);
            cellsList.Add(cell);
            nextCellIndx += cell.GetSize();
        }

        public bool RemoveCell(string name)
        {
            int cellIndx = FindCell(name);
            if (cellIndx == -1)
                return false;
            cellsList.RemoveAt(cellIndx);
            return true;
        }

        public void RemoveAllCells()
        {
            cellsList = new List<Cell>();
        }

        private int FindCell(string name)
        {
            for (int i=0; i<cellsList.Count; i++)
            {
                if (cellsList[i].GetName() == name)
                    return i;
            }
            return -1;
        }

        public bool FromBytes(byte [] bytes)
        {
            //if (bytes.Length != GetSize())
            //    return false;

            foreach (Cell cell in cellsList)
                cell.FromBytes(bytes);

            return true;
        }

        public int GetSize() { return nextCellIndx; }
    }
}
