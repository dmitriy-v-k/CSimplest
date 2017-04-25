using CSimplest.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSimplest.Documents
{
    public sealed class DcPlain : Document
    {
        private readonly Stringable _text;
        public DcPlain(Stringable text)
        {
            _text = text;
        }
        public string AsString()
        {
            return _text.AsString();
        }
    }
}
