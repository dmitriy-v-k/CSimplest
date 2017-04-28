using CSimplest.Common;
using CSimplest.CSResponse.Interfaces;

namespace CSimplest.CSResponse
{
    public sealed class RsText : RsWrap
    {
        private readonly RsWrap _origin;
        private readonly Text _text;
        public RsText(RsWrap origin, Text text)
        {
            _origin = origin;
            _text = text;
        }

        public RsDestination Unwrap()
        {
            return _origin.Unwrap();
        }

        public void Go()
        {
            Unwrap().Text(_text.Unwrap());
            _origin.Go();
        }
    }
}
