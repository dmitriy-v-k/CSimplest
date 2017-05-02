using System.Collections.Specialized;
using System.Linq;
using CSimplest.Extensions;
using System.Collections.Generic;
using CSimplest.CSResponse.Interfaces;

namespace CSimplest.CSResponse
{
    public sealed class RsWithHeaders : RsWrap
    {
        private readonly RsWrap _origin;
        private readonly NameValueCollection _headers = new NameValueCollection();
        public RsWithHeaders(RsWrap origin, IEnumerable<KeyValuePair<string,string>> headers)
        {
            _origin = origin;
            headers.ToList().ForEach(p => _headers.Add(p.Key,p.Value));
        }
        public void Go()
        {
            var dest = Unwrap();
            _headers.AsPairs().ToList().ForEach(p => dest.Header(p));
            _origin.Go();
        }

        public RsDestination Unwrap()
        {
            return _origin.Unwrap();
        }
    }
}
