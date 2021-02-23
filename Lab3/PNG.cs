using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public class Png
    {
        private readonly List<ChunkInfo> _chunkInfos = new();
        private readonly byte[] _metaData;

        public Png(byte[] metaData)
        {
            _metaData = metaData;

            ChunkAdder();
        }

        private int Width => (_metaData[16] << 24) + (_metaData[17] << 16) + (_metaData[18] << 8) + _metaData[19];
        private int Height => (_metaData[20] << 24) + (_metaData[21] << 16) + (_metaData[22] << 8) + _metaData[23];


        private void ChunkAdder()
        {
            var startIndex = 8;
            var chunkDataSize = 0;
            const int chunkInformationSize = 12;
            while (startIndex < _metaData.Length)
            {
                if (startIndex + 8 <= _metaData.Length)
                {
                    var sizeSegment = new ArraySegment<byte>(_metaData, startIndex, 4);
                    chunkDataSize = chunkInformationSize + (sizeSegment[0] << 24) + (sizeSegment[1] << 16) +
                                    (sizeSegment[2] << 8) +
                                    sizeSegment[3];
                    var typeSegment = new ArraySegment<byte>(_metaData, startIndex + 4, 4);
                    var chunkType = Encoding.ASCII.GetString(typeSegment);
                    _chunkInfos.Add(new ChunkInfo(chunkDataSize, chunkType));
                }

                startIndex += chunkDataSize;
            }
        }

        public IEnumerable<ChunkInfo> GetListOfChunks()
        {
            return _chunkInfos;
        }

        public override string ToString()
        {
            return $"This is a .png image. Resolution : {Width}x{Height} pixels";
        }
    }
}