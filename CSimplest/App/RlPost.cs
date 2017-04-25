using System;
using CSimplest.CSRequest.Interfaces;
using CSimplest.Extensions;

namespace CSimplest.App
{
    public sealed class RlPost : AppRule
    {
        private readonly AppRule _origin;

        public RlPost(AppRule origin)
        {
            _origin = origin;
        }

        public Resolvable Resolve()
        {
            return _origin.Resolve();
        }

        public void Use()
        {
            "POST".Equals(_origin.Resolve().Resolve().Method().ToUpper()).If(
                () => { _origin.Use(); },
                () => { }
            );
        }
    }
}
