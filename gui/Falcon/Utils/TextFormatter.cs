using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.Utils
{
    class TextFormatter
    {
        public enum LineEndingType
        {
            LF,
            LF_CR,
            NONE,
            INVALID
        }

        public enum TextFormatType
        {
            ASCII,
            BINARY,
            HEX,
            INVALID
        }

        public static LineEndingType StringToLineEndingType(string lineEndingType)
        {
            switch(lineEndingType)
            {
                case "LF":
                    return LineEndingType.LF;

                case "LF CR":
                    return LineEndingType.LF_CR;

                case "None":
                    return LineEndingType.NONE;

                default:
                    return LineEndingType.INVALID;
            }
        }

        public static TextFormatType StringToTextFormatType(string textFormatType)
        {
            switch (textFormatType)
            {
                case "ASCII":
                    return TextFormatType.ASCII;

                case "Binary":
                    return TextFormatType.BINARY;

                case "Hex":
                    return TextFormatType.HEX;

                default:
                    return TextFormatType.INVALID;
            }
        }

        public static string BytesToString(byte[] bytes, string start, string end, string splitter)
        {
            var sb = new StringBuilder(start);
            for (int i=0; i<bytes.Length; i++)
            {
                if (i == bytes.Length-1)
                    sb.Append(bytes[i]);
                else
                    sb.Append(bytes[i] + splitter);
            }
            sb.Append(end);
            return sb.ToString();
        }

        public static string BytesToHexString(byte[] bytes)
        {
            StringBuilder result = new StringBuilder(bytes.Length * 2);
            string HexAlphabet = "0123456789ABCDEF";

            foreach (byte B in bytes)
            {
                result.Append(HexAlphabet[(int)(B >> 4)]);
                result.Append(HexAlphabet[(int)(B & 0xF)]);
                result.Append(" ");
            }

            return result.ToString();
        }

        public static string TimestampString()
        {
            return "[" + Logger.GetTime() + "]: ";
        }

        public static string BytesToAsciiString(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        public static string CarriageReturnString()
        {
            return "\r";
        }

        public static string EndOfLineString()
        {
            return "\n";
        }
    }
}
