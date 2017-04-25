using CSimplest.CSResponse.Interfaces;
using CSimplest.Documents.Interfaces;
using System.Collections.Generic;

namespace CSimplest.CSResponse
{
    public sealed class RsJson : Resolvable
    {
        private readonly Resolvable _origin;
        private readonly CanJson _jsonDoc;
        private readonly IEnumerable<KeyValuePair<string, string>> headers;

        public RsJson(Resolvable origin, CanJson jsonDocument)
        {
            _origin = origin;
            _jsonDoc = jsonDocument;

            headers = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Content-Type", "application/json")
            };
        }
        public void Go()
        {
            new RsWithHeaders(
                new RsText(
                    _origin,
                    _jsonDoc.AsJson()
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
