using CSimplest.Common;
using CSimplest.CSResponse.Interfaces;

namespace CSimplest.CSResponse
{
    public sealed class RsText : Resolvable
    {
        private readonly Resolvable _origin;
        private readonly Stringable _text;
        public RsText(Resolvable origin, Stringable text)
        {
            _origin = origin;
            _text = text;
        }

        public Dest Resolve()
        {
            return _origin.Resolve();
        }

        public void Go()
        {
            Resolve().Text(_text.AsString()).Go();
        }
    }
}
