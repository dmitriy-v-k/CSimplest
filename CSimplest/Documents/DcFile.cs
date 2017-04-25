using System.IO;

namespace CSimplest.Documents
{
    public sealed class DcFile : Document
    {
        private readonly string path;
        public DcFile(string fullPath)
        {
            path = fullPath;
        }
        public string AsString()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
