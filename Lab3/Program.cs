using System;

namespace Lab3
{
    internal abstract class Program
    {
        private static void Main(string[] args)
        {
            const string path = @"..\..\..\Images\mushroom.png";
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

            Console.WriteLine();
            Console.WriteLine(filetype.ToString());
            Console.WriteLine();
            
            if (filetype is not Png p) return;
            var chunkList = p.GetListOfChunks();
            Console.WriteLine("Here is the list of chunks:");
            foreach (var chunk in chunkList)
                
                Console.WriteLine($"Chunkname is {chunk.Type}, Chunksize is {chunk.Size} bytes");
            
        }
    }
}