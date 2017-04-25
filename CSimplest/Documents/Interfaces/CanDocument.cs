using CSimplest.Common;

namespace CSimplest.Documents.Interfaces
{
    public interface CanDocument: Stringable
    {
        Document AsDocument();
    }
}
