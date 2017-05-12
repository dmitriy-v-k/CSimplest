using CSimplest.Common;
using CSimplest.Documents.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CSimplest.Documents
{
    public sealed class DcTemplate : DcText
    {
        private readonly DcText _origin;
        private readonly Dictionary<string, Text> _data;
        public DcTemplate(DcText origin, Dictionary<string, Text> data)
        {
            _origin = origin;
            _data = data;
        }
        public string Unwrap()
        {
            var template = _origin.Unwrap();

            _data.Keys.ToList().ForEach(k => template = template.Replace("@:" + k, _data[k].Unwrap()));
            return template;
        }

        public Text AsText()
        {
            return new PlainText(Unwrap());
        }
    }
}
