using System;
using System.IO;

namespace Lab3
{
    internal abstract class Program
    {
        private static void Main(string[] args)
        {
            var dataCheck = new DataCheck(CheckPath(args));
            PrintFileTypeInformation(dataCheck.ClassObjectCreator(dataCheck.CheckFile()));
        }

        private static string CheckPath(string[] args)
        {
            string path;
            if (args.Length != 0)
            {
                path = args[0];
            }
            else
            {
                Console.Write("Please input a filepath: ");
                path = Console.ReadLine();
            }

            while (!File.Exists(path))
            {
                Console.WriteLine("File not find");
                Console.WriteLine("Please insert a proper path");
                path = Console.ReadLine();
            }

            return path;
        }

        private static void PrintFileTypeInformation(object filetype)
        {
            if (filetype == null)
            {
                Console.WriteLine("Invalid File");
                return;
            }

            Console.WriteLine($"\n{filetype}\n");

            if (filetype is not Png p) return;
            var chunkList = p.GetListOfChunks();
            Console.WriteLine("Here is the list of chunks:");
            foreach (var chunk in chunkList)

                Console.WriteLine($"Chunkname is {chunk.Type}, Chunksize is {chunk.Size} bytes");
        }
    }
}