using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicaLabsTask
{
    class Program
    {
        static void Main(string[] args)
        {
            ExtractCsvFiles();
        }

        public static void ExtractCsvFiles()
        {
            //Console.Write("Insert zip archive path here: ");
            //string pathToZip = Console.ReadLine();
            //Console.WriteLine("Provide path where to extract the zip file: ");
            //string extractPath = Console.ReadLine();
            string pathToZip = @"C:\Users\Dmitriy\Desktop\DynamicaLabsTask.zip";
            string extractPath = @"C:\Users\Dmitriy\Desktop\test";
            extractPath = Path.GetFullPath(extractPath);
            if (!extractPath.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
                extractPath += Path.DirectorySeparatorChar;

            using (ZipArchive archive = ZipFile.OpenRead(pathToZip))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                    {
                        string destinationPath = Path.GetFullPath(Path.Combine(extractPath, entry.FullName));
                        if (destinationPath.StartsWith(extractPath, StringComparison.Ordinal))
                            entry.ExtractToFile(destinationPath);
                    }
                }
            }
        }
    }
}
