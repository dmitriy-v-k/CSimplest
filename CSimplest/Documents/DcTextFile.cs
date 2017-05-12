using CSimplest.Documents.Interfaces;
using System.IO;
using CSimplest.Common;

namespace CSimplest.Documents
{
    public sealed class DcTextFile : DcText, DcFile
    {
        private readonly string _path;
        public DcTextFile(string path)
        {
            _path = path;
        }

        public Text AsText()
        {
            return new PlainText(Unwrap());
        }

        public string Path()
        {
            return _path;
        }

        public string Unwrap()
        {
            using (StreamReader sr = new StreamReader(Path()))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
