using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSimplest.Extensions
{
    public static class NameValueCollectionExtension
    {
        public static IEnumerable<KeyValuePair<string,string>> ToPairs(this NameValueCollection collection)
        {
            return 
                from key in collection.AllKeys
                    from value in collection.GetValues(key)
                        select new KeyValuePair<string, string>(key, value);
        }
    }
}
