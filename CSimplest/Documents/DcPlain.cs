using System;
using CSimplest.Common;
using CSimplest.Documents.Interfaces;

namespace CSimplest.Documents
{
    public sealed class DcPlain : DcText
    {
        private readonly Text _text;
        public DcPlain(Text text)
        {
            _text = text;
        }

        public Text AsText()
        {
            return _text;
        }

        public string Unwrap()
        {
            return _text.Unwrap();
        }
    }
}
