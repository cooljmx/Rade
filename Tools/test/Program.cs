using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RADE.Tools;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "masterkey";
            Console.WriteLine(StringTools.CryptString(s));
            Console.WriteLine(StringTools.DecryptString(StringTools.CryptString(s)));
            Console.ReadKey();
        }
    }
}
