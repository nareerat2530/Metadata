namespace Lab3
{
    public class Bmp
    {
        private readonly byte[] _metaData;

        public Bmp(byte[] metaData)
        {
            _metaData = metaData;
        }

        private int Width => _metaData[18] + (_metaData[19] << 8) + (_metaData[20] << 16) + (_metaData[21] << 24);
        private int Height => _metaData[22] + (_metaData[23] << 8) + (_metaData[24] << 16) + (_metaData[25] << 24);

        public override string ToString()
        {
            return $"This is a .bmp image. Resolution : {Width}x{Height} pixels";
        }
    }
}