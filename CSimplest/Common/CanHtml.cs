using CSimplest.Documents;

namespace CSimplest.Common
{
    public interface CanHtml: Stringable
    {
        Document AsHtml();
    }
}
