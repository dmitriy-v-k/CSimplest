using System.Collections.Specialized;

namespace CSimplest.CSRequest.Interfaces
{
    public interface Src : Resolvable
    {
        string Text();
        NameValueCollection Headers();
        string Method();
        string Path();
    }
}
