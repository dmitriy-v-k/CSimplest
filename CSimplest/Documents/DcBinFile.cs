using CSimplest.Documents.Interfaces;
using System;
using System.IO;
using CSimplest.Common;

namespace CSimplest.Documents
{
    public sealed class DcBinFile: DcBin, DcFile
    {
        private readonly string _path;
        public DcBinFile(string path)
        {
            _path = path;
        }

        public Bin AsBin()
        {
            return new PlainBin(Unwrap());
        }

        public string Path()
        {
            return _path;
        }

        public byte[] Unwrap()
        {
            return File.ReadAllBytes(Path());
        }
    }
}
