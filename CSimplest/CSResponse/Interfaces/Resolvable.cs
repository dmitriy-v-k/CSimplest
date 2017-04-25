using CSimplest.Common;

namespace CSimplest.CSResponse.Interfaces
{
    public interface Resolvable : Response, Resolvable<Dest>
    {
    }
}
