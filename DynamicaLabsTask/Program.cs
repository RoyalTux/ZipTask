using System;
using System.IO;
using System.IO.Compression;
using System.Threading;

namespace DynamicaLabsTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Insert zip archive path here: ");
            string pathToZip = Console.ReadLine();
            ExtractFromZip extractFromZip = new ExtractFromZip();
            extractFromZip.ExtractCsvFiles(pathToZip);
        }
    }
}
