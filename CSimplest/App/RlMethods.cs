using System.Collections.Generic;
using System.Linq;
using CSimplest.CSRequest.Interfaces;
using CSimplest.Extensions;

namespace CSimplest.App
{
    public sealed class RlMethods : AppRule
    {
        private readonly AppRule _origin;
        private readonly IEnumerable<string> _methods;
        public RlMethods(AppRule origin, IEnumerable<string> methods)
        {
            _origin = origin;
            _methods = methods.ToList().ConvertAll(m => m.ToUpper());
        }

        public Resolvable Resolve()
        {
            return _origin.Resolve();
        }

        public void Use()
        {
            _methods.ToList().Contains(Resolve().Resolve().Method()).If(
                () => { _origin.Use(); },
                () => { }    
            );
        }
    }
}
