using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.Utils
{
    public class FileLogger
    {
        private StreamWriter strmWriter;
        private const string fileExtention = ".txt";

        public FileLogger(string filePath, string fileName, bool append, string headline)
        {
            strmWriter = new StreamWriter(filePath + "\\" + fileName + fileExtention, append);
            WriteLine("sys time, " + headline);
        }

        public FileLogger(string filePath, string fileName, bool append)
        {
            strmWriter = new StreamWriter(filePath + "\\" + fileName + fileExtention, append);
            
        }

        //write log line prefixed by time
        public void WriteLogLineWithTimestamp(string text)
        {
            if (strmWriter != null && strmWriter.BaseStream != null)
                strmWriter.WriteLine("[" + Logger.GetTime() + "]: " + text);
        }

        public void WriteLine(string text)
        {
            if (strmWriter != null && strmWriter.BaseStream != null)
                strmWriter.WriteLine(text);
        }

        public void WriteWithTimestamp(string text)
        {
            if (strmWriter != null && strmWriter.BaseStream != null)
                strmWriter.Write("[" + Logger.GetTime() + "]: " + text);
        }

        public void Write(string text)
        {
            if (strmWriter != null && strmWriter.BaseStream != null)
                strmWriter.Write(text);
        }

        public void Close() { strmWriter.Close(); }
    }
}
