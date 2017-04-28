using CSimplest.CSRequest.Interfaces;
using System.Text.RegularExpressions;
using System.Collections.Specialized;

namespace CSimplest.CSRequest
{
    public sealed class RqWithParamsInPath : RqWithParams
    {
        private readonly RqWrap _origin;
        private readonly Regex _rule;

        public RqWithParamsInPath(RqWrap origin, Regex ruleForParameters)
        {
            _origin = origin;
            _rule = ruleForParameters;
        }

        public NameValueCollection Parameters()
        {
            var res = _rule.Match(Unwrap().Path()).Groups
            return 
        }

        public void Process()
        {
            _origin.Process();
        }

        public RqSource Unwrap()
        {
            return _origin.Unwrap();
        }
    }
}
