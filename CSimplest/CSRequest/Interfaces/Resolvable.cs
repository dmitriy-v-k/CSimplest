using CSimplest.Common;

namespace CSimplest.CSRequest.Interfaces
{
    public interface Resolvable : Request, Resolvable<Src>
    {
    }
}
