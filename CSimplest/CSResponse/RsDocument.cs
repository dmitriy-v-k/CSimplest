using CSimplest.Common;
using CSimplest.CSResponse.Interfaces;
using CSimplest.Documents;

namespace CSimplest.CSResponse
{
    public sealed class RsDocument : Resolvable
    {
        private readonly Resolvable _origin;
        private readonly Document _doc;
        public RsDocument(Resolvable origin, Document document)
        {
            _origin = origin;
            _doc = document;
        }

        public Dest Resolve()
        {
            return _origin.Resolve();
        }

        public void Go()
        {
            Resolve().Text(_doc.AsString()).Go();
        }
    }
}
