using CSimplest.Common;
using CSimplest.CSRequest.Interfaces;

namespace CSimplest.App
{
    public interface AppRule: Wrap<RqWrap>
    {
        void Use();
    }
}
