﻿using System;
using System.IO;
using System.IO.Compression;
using System.Threading;

namespace DynamicaLabsTask
{
    class ExtractFromZip
    {
        public void ExtractCsvFiles(string pathToZip) // method A
        {
            string tempFolderPath = Path.GetDirectoryName(pathToZip);
            tempFolderPath = Path.Combine(tempFolderPath) + @"\tempZipFolder";

            if (!Directory.Exists(tempFolderPath))
            {
                DirectoryInfo tempDirectory = Directory.CreateDirectory(tempFolderPath);
                Console.WriteLine("Temp directory created!");
            }

            tempFolderPath = Path.GetFullPath(tempFolderPath);
            Console.WriteLine(tempFolderPath);

            if (!tempFolderPath.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
                tempFolderPath += Path.DirectorySeparatorChar;
            try
            {
                using (ZipArchive archive = ZipFile.OpenRead(pathToZip))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (entry.FullName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                        {
                            string destinationPath = Path.GetFullPath(Path.Combine(tempFolderPath, entry.FullName));
                            if (destinationPath.StartsWith(tempFolderPath, StringComparison.Ordinal))
                                entry.ExtractToFile(destinationPath);
                        }
                    }
                    Console.WriteLine("CSV files extracted!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            DirectoryInfo tempFolder = new DirectoryInfo(tempFolderPath);
            foreach (var item in tempFolder.GetFiles("*.csv"))
            {
                EmptyMethod(item);
            }

            Thread.Sleep(2000); // wait for some visual 

            Directory.Delete(tempFolderPath, true);

            Console.WriteLine("Temp folder deleted!");
        }

        public static void EmptyMethod(FileInfo info) // method B
        {
            Console.WriteLine(info.FullName);
        }
    }
}
