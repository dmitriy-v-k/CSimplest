using CSimplest.Common;

namespace CSimplest.Documents.Interfaces
{
    public interface CanJson: Stringable
    {
        Document AsJson();
    }
}
