using CSimplest.CSRequest.Interfaces;
using CSimplest.Extensions;

namespace CSimplest.App.Methods
{
    public sealed class RlGet : AppRule
    {
        private readonly AppRule _origin;

        public RlGet(AppRule origin)
        {
            _origin = origin;
        }

        public RqWrap Unwrap()
        {
            return _origin.Unwrap();
        }

        public void Use()
        {
            "GET".Equals(_origin.Unwrap().Unwrap().Method().ToUpper()).If(
                () => { _origin.Use(); },
                () => { }
            );
        }
    }
}
