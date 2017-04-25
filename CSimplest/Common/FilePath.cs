using System;
using System.Web;

namespace CSimplest.Common
{
    public class FilePath: Resolvable<string>
    {
        private readonly string path;
        public FilePath(string relativePath)
        {
            path = relativePath;
        }

        public string Resolve()
        {
            return HttpContext.Current.Server.MapPath(path);
        }
    }
}
