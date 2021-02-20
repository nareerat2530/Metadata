using System;
using System.IO;
using System.Linq;

namespace Lab3
{
    public enum FileType
    {
        Png,
        Bmp,
        Invalid
    }

    public class DataCheck
    {
        private readonly string _path;

        public DataCheck(string path)
        {
            _path = path;
        }

        private byte[] Metadata
        {
            get
            {
                var fs = new FileStream(_path, FileMode.Open);
                var fileSize = (int) fs.Length;
                var data = new byte[fileSize];
                fs.Read(data, 0, fileSize);
                fs.Close();
                return data;
            }
        }

        public Enum CheckFile()
        {
            var pmgSignature = new byte[] {137, 80, 78, 71, 13, 10, 26, 10};
            var firstEightByte = Metadata[..8];
            switch (Metadata[0])
            {
                case 66:
                    if (Metadata[1] == 77)
                        return FileType.Bmp;
                    break;
                case 137:
                    if (pmgSignature.SequenceEqual(firstEightByte))
                        return FileType.Png;
                    break;
                default:
                    return FileType.Invalid;
            }

            return FileType.Invalid;
        }

        public object ClassObjectCreator(Enum filetype)
        {
            return filetype switch
            {
                FileType.Bmp => new Bmp(Metadata),
                FileType.Png => new Png(Metadata),
                _ => null
            };
        }
    }
}