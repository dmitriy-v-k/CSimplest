using CSimplest.Common;

namespace CSimplest.Documents.Interfaces
{
    public interface CanHtml: Stringable
    {
        Document AsHtml();
    }
}
