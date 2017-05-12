using System;
using CSimplest.Common;
using CSimplest.Documents.Interfaces;

namespace CSimplest.Documents
{
    public sealed class DcWithHtml : DcHtml
    {
        private readonly DcText _origin;
        public DcWithHtml(DcText origin)
        {
            _origin = origin;
        }
        public Text AsHtml()
        {
            return _origin.AsText();
        }

        public Text AsText()
        {
            throw new NotImplementedException();
        }

        public string Unwrap()
        {
            throw new NotImplementedException();
        }
    }
}
