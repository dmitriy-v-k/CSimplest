using CSimplest.Common;
using System.Collections.Generic;
using System.Linq;

namespace CSimplest.Documents
{
    public sealed class DcTemplate : Document
    {
        private readonly Document _origin;
        private readonly Dictionary<string, Stringable> _data;
        public DcTemplate(Document origin, Dictionary<string, Stringable> data )
        {
            _origin = origin;
            _data = data;
        }
        public string AsString()
        {
            var template = _origin.AsString();

            _data.Keys.ToList().ForEach(k => template = template.Replace("@:" + k, _data[k].AsString()));
            return template;
        }
    }
}
