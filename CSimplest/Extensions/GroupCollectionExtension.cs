using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;

namespace CSimplest.Extensions
{
    public static class GroupCollectionExtension
    {
        public static IEnumerable<KeyValuePair<string, string>> AsPairs(this GroupCollection collection, IEnumerable<string> groupNames)
        {
            return groupNames.Select(gn => new KeyValuePair<string, string>(gn, collection[gn].Value));
        }

        public static NameValueCollection AsNameValueCollection(this GroupCollection collection, IEnumerable<string> groupNames)
        {
            var res = new NameValueCollection();
            AsPairs(collection, groupNames).ToList().ForEach(kv => res.Add(kv.Key, kv.Value));
            return res;
        }
    }
}
