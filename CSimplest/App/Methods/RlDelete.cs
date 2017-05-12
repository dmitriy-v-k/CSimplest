using CSimplest.CSRequest.Interfaces;
using CSimplest.Extensions;

namespace CSimplest.App.Methods
{
    public sealed class RlDelete : AppRule
    {
        private readonly AppRule _origin;

        public RlDelete(AppRule origin)
        {
            _origin = origin;
        }

        public RqWrap Unwrap()
        {
            return _origin.Unwrap();
        }

        public void Use()
        {
            "DELETE".Equals(_origin.Unwrap().Unwrap().Method().ToUpper()).If(
                () => { _origin.Use(); },
                () => { }
            );
        }
    }
}
