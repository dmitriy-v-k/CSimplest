using System;
using CSimplest.CSResponse.Interfaces;
using CSimplest.Common;
using System.Collections.Generic;

namespace CSimplest.CSResponse
{
    public sealed class RsHtml : Resolvable
    {
        private readonly Resolvable _origin;
        private readonly CanHtml _htmlDoc;

        private readonly IEnumerable<KeyValuePair<string, string>> headers;

        public RsHtml(Resolvable origin, CanHtml htmlDocument)
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

        public Dest Resolve()
        {
            return _origin.Resolve();
        }
    }
}
