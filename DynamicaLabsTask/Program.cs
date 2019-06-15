using System;
using System.IO;

namespace DynamicaLabsTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Start:
            try
            {
                ExtractFromZip extractFromZip = new ExtractFromZip();
                extractFromZip.StartExtract();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Path not found!");
                goto Start;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
