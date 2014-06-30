using Rade.Compression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace test
{
    class Program
    {       
        static void Main(string[] args)
        {
            unrar_test t = new unrar_test();
            t.FileName = "T:\\asrksources\\C#\\fias\\Fias.Update\\bin\\Release\\Data\\20120813\\fias_delta_xml.rar";
            t.DestPath = "T:\\asrksources\\C#\\fias\\Fias.Update\\bin\\Release\\Data\\20120813\\Extracted\\";
            //t.OpenRarFile();
            t.unrar.ExtractionProgress += unrar_ExtractionProgress;
            t.extract();
            Console.WriteLine("done");
            //Thread.Sleep(2000);
            Console.ReadKey();
        }

        static void unrar_ExtractionProgress(object sender, ExtractionProgressEventArgs e)
        {
            Console.WriteLine(string.Format("{0} {1} {2} {3}", e.BytesExtracted, e.ContinueOperation, e.FileSize, e.PercentComplete));
        }
    }
}
