using CSimplest.Documents.Interfaces;
using System.IO;
using CSimplest.Common;
using System;

namespace CSimplest.Documents
{
    public sealed class DcFile : DcText
    {
        private readonly string path;
        public DcFile(string fullPath)
        {
            path = fullPath;
        }

        public Text AsText()
        {
            return new PlainText(Unwrap());
        }

        public string Unwrap()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
