using System.Collections.Specialized;

namespace CSimplest.CSRequest.Interfaces
{
    public interface RqWithParams: RqWrap
    {
        NameValueCollection Parameters();
    }
}
