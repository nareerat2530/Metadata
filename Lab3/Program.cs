using System;

namespace Lab3
{
    internal abstract class Program
    {
        private static void Main(string[] args)
        {
            const string path = @"..\..\..\Images\meta.bmp";
            
            //var path = @"C:\Users\naree\Downloads\Koalala\23.bmp";
            var dataCheck = new DataCheck(path);
            PrintFileTypeInformation(dataCheck.ClassObjectCreator(dataCheck.CheckFile()));
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