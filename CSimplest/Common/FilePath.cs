using System.Web;

namespace CSimplest.Common
{
    public sealed class FilePath: Wrap<string>
    {
        private readonly string path;
        public FilePath(string relativePath)
        {
            path = relativePath;
        }

        public string Unwrap()
        {
            return HttpContext.Current.Server.MapPath(path);
        }
    }
}
