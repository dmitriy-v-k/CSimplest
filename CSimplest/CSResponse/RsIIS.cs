using CSimplest.CSResponse.Interfaces;
using System.Collections.Generic;
using System.Web;

namespace CSimplest.CSResponse
{
    //Our response To IIS response
    public sealed class RsIIS : RsDestination
    {
        private readonly HttpResponse dest;
        public RsIIS(HttpResponse IISResponse)
        {
            dest = IISResponse;
        }

        public RsDestination Text(string text)
        {
            dest.Write(text);
            return this;
        }

        public RsDestination Header(KeyValuePair<string, string> value)
        {
            dest.AddHeader(value.Key, value.Value);
            return this;
        }

        public RsDestination Unwrap()
        {
            return this;
        }

        public void Go()
        {
            dest.End();
        }
    }
}
