using CSimplest.CSResponse.Interfaces;
using CSimplest.Documents.Interfaces;

namespace CSimplest.CSResponse
{
    public sealed class RsDocument : RsWrap
    {
        private readonly RsWrap _origin;
        private readonly DcText _doc;
        public RsDocument(RsWrap origin, DcText document)
        {
            _origin = origin;
            _doc = document;
        }

        public RsDestination Unwrap()
        {
            return _origin.Unwrap();
        }

        public void Go()
        {
            Unwrap().Text(_doc.Unwrap());
            _origin.Go();
        }
    }
}
