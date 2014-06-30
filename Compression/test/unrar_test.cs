using Rade.Compression;
using System;

namespace test
{
    class unrar_test : IDisposable
    {
        public Unrar unrar = new Unrar();
        public string FileName { get; set; }
        public string DestPath { get; set; }
        public void extract()
        {
            try
            {
                unrar.Open(FileName, Unrar.OpenMode.Extract);
                unrar.DestinationPath = DestPath;
                while (unrar.ReadHeader())
                    unrar.Extract();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void Dispose()
        {
            unrar.Dispose();
        }
    }
}
