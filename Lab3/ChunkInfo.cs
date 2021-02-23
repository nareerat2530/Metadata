namespace Lab3
{
    public class ChunkInfo
    {
        private readonly int _sizeOfData;
        private readonly string _type;


        public ChunkInfo(int sizeOfData, string type)
        {
            _sizeOfData = sizeOfData;
            _type = type;
        }

        public override string ToString()
        {
            return $"Chunkname is {_type}, Chunksize is {_sizeOfData} bytes";
        }
    }
}