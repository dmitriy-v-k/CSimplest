using System.Collections.Specialized;

namespace CSimplest.CSRequest.Interfaces
{
    public interface RqSource : RqWrap
    {
        string Text();
        NameValueCollection Headers();
        string Method();
        string Path();
    }
}
