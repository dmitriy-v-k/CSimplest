using CSimplest.CSResponse.Interfaces;
using System.Collections.Generic;
using System.Web;

namespace CSimplest.CSResponse
{
    //Our response To IIS response
    public sealed class RsIIS : Dest
    {
        private readonly HttpResponse dest;
        public RsIIS(HttpResponse IISResponse)
        {
            dest = IISResponse;
        }

        public Dest Text(string text)
        {
            dest.Write(text);
            return this;
        }

        public Dest Header(KeyValuePair<string, string> value)
        {
            dest.AddHeader(value.Key, value.Value);
            return this;
        }

        public Dest Resolve()
        {
            return this;
        }

        public void Go()
        {
            dest.End();
        }
    }
}
