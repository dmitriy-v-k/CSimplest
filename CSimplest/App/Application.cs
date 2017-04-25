using System.Collections.Generic;
using System.Linq;

namespace CSimplest.App
{
    public sealed class Application
    {
        private readonly IEnumerable<AppRule> _allRules;

        public Application(IEnumerable<AppRule> allRules)
        {
            _allRules = allRules;
        }

        public void Run()
        {
            _allRules.ToList().ForEach(rq => rq.Use());
        }
    }
}
