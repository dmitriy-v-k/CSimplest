using System.Collections.Generic;
using System.Linq;
using CSimplest.CSRequest.Interfaces;
using CSimplest.Extensions;

namespace CSimplest.App.Methods
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

        public RqWrap Unwrap()
        {
            return _origin.Unwrap();
        }

        public void Use()
        {
            _methods.ToList().Contains(Unwrap().Unwrap().Method()).If(
                () => { _origin.Use(); },
                () => { }    
            );
        }
    }
}
