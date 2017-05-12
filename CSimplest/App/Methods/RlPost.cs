using CSimplest.CSRequest.Interfaces;
using CSimplest.Extensions;

namespace CSimplest.App.Methods
{
    public sealed class RlPost : AppRule
    {
        private readonly AppRule _origin;

        public RlPost(AppRule origin)
        {
            _origin = origin;
        }

        public RqWrap Unwrap()
        {
            return _origin.Unwrap();
        }

        public void Use()
        {
            "POST".Equals(_origin.Unwrap().Unwrap().Method().ToUpper()).If(
                () => { _origin.Use(); },
                () => { }
            );
        }
    }
}
