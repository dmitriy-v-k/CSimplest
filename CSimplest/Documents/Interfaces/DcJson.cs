using CSimplest.Common;

namespace CSimplest.Documents.Interfaces
{
    public interface DcJson: DcText
    {
        Text AsJson();
    }
}
