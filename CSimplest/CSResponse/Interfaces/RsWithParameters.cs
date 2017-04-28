using System.Collections.Specialized;

namespace CSimplest.CSResponse.Interfaces
{
    interface RsWithParameters: RsWrap
    {
        void Go(NameValueCollection parameters);
    }
}
