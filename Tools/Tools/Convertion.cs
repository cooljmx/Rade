using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rade.Tools
{
    public class Convertion
    {
        public static string IntToHex(int value, int digits)
        {
            string format = "{0:X" + digits.ToString() + "}";
            return string.Format(format, value); 
        }

        public static string IntToBin(int value, int digits)
        {
            string result = Convert.ToString(value, 2);
            return StringTools.StringOfChar('0', digits - result.Length) + result;
        }

        public static int HexToInt(string value)
        {
            return Convert.ToInt32(value, 16);
        }

        public static int BinToInt(string value)
        {
            return Convert.ToInt32(value, 2);
        }
    }
}
