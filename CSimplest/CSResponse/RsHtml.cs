using CSimplest.CSResponse.Interfaces;
using System.Collections.Generic;
using CSimplest.Documents.Interfaces;

namespace CSimplest.CSResponse
{
    public sealed class RsHtml : RsWrap
    {
        private readonly RsWrap _origin;
        private readonly DcHtml _htmlDoc;
        private readonly IEnumerable<KeyValuePair<string, string>> headers;

        public RsHtml(RsWrap origin, DcHtml htmlDocument)
        {
            _origin = origin;
            _htmlDoc = htmlDocument;

            headers = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Content-Type", "text/html;charset=utf-8")
            };
        }

        public void Go()
        {
            new RsWithHeaders(
                new RsText(
                    _origin,
                    _htmlDoc.AsHtml()
                ),
                headers
            ).Go();
        }

        public RsDestination Unwrap()
        {
            return _origin.Unwrap();
        }
    }
}
