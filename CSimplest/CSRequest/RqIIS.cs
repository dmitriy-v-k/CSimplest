using CSimplest.CSRequest.Interfaces;
using System.Collections.Specialized;
using System.IO;
using System.Web;

namespace CSimplest.CSRequest
{
    public sealed class RqIIS : Src
    {
        private readonly HttpRequest src;
        public RqIIS(HttpRequest IISRequest)
        {
            src = IISRequest;
        }

        public NameValueCollection Headers()
        {
            return src.Headers;
        }

        public string Method()
        {
            return src.HttpMethod;
        }

        public string Path()
        {
            return src.AppRelativeCurrentExecutionFilePath;
        }

        public void Process()
        {
        }

        public Src Resolve()
        {
            return this;
        }

        public string Text()
        {
            return new StreamReader(src.InputStream).ReadToEnd();
        }
    }
}
