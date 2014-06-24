using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rade.Tools
{
    public class StringTools
    {
        private const string Mask = "\x60\x29\x64\xEC\x58\x22\xC1\xF4\xCF\x2F\xF6\xF0\xFE\x26\xD8\x65\xFC\x61\x2D\xF1\x2C\x6C\x4E\xCC\x6A\x51\xF3\x42\xE9\x55\x3B\xA8\x7C\x39\xDC\xF7\xF2\xC3\xE2\x5E\xED\x62\xDE\x4C\x32\x76\x33\x28\xE4\x34\x46\x3C\x69\x5B\x67\xD0\x41\x2E\xE1\xFB\x48\x68\x21\xD2\x72\xE0\x3D\x71\xFD\x70\x52\xD3\xD5\x7D\x23\x7E\xFA\xFF\x24\x75\x3A\x4D\x7B\x31\xF9\x6D\xD9\xDD\x2A\x50\xC8\x49\x66\x77\xF5\xE3\xC0\xC2\xE8\xCB\xD1\x57\x4B\x5C\x79\xDA\x73\x43\x3E\x5F\xE6\xC7\x5A\x6E\xEA\xD4\x63\x38\xD7\x53\xD6\x54\x7A\xC4\xC9\xEE\x74\x44\xDB\x45\xCA\x47\xDF\xF8\x40\x36\x5D\xC5\xE7\x4A\xCE\xEF\x56\x30\x78\x59\x37\xEB\x6F\xB8\xCD\x2B\xE5\x25\xC6\x6B\x4F\x3F\x35";

        public static string StringOfChar(char value, int count)
        {
            var result = "";
            for (var x = 0; x < count; x++)
                result += value;
            return result;
        }
               
        public static string CryptString(string value)
        {
            try
            {
                var len8 = value.Length * 8;
                var len6 = (len8 / 6) * 6;
                if (len6 < len8) len6 = len6 + 6;

                var bin8 = StringOfChar('0', len6 - len8);
                bin8 = value.Aggregate(bin8, (current, t) => Convertion.IntToBin(t, 8) + current);

                var r = "";
                for (var i = 0; i < (len6 / 6); i++)
                    r += Mask[Convertion.BinToInt("00" + bin8.Substring(i * 6, 6))];

                return r.Aggregate("", (current, t) => current + Convertion.IntToHex(t, 2));
            }
            catch
            {
                return "";
            }
        }

        public static string DecryptString(string value)
        {
            if (value == null) return "";
            var r = "";
            for (var i = 0; i < (value.Length / 2); i++)
            {
                var charByte = string.Format("{0}{1}", value[(i * 2)], value[(i * 2) + 1]);
                r += Convert.ToChar(Convertion.HexToInt(charByte));
            }
            var len6 = r.Length * 6;
            var len8 = (len6 / 8) * 8;
            var bin6 = r.Aggregate("", (current, t) => current + Convertion.IntToBin(Mask.IndexOf(t), 6));
            var result = "";
            for (var i = 0; i < len8 / 8; i++)
                result = Convert.ToChar(Convertion.BinToInt(bin6.Substring(i * 8, 8))) + result;
            return result;
        }
    }
}
