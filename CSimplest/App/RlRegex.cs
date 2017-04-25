using CSimplest.CSRequest.Interfaces;
using System.Text.RegularExpressions;
using CSimplest.Extensions;
using System;

namespace CSimplest.App
{
    public sealed class RlRegex: AppRule
    {
        private readonly Resolvable _request;
        private readonly Regex _path;

        public RlRegex(Resolvable request, Regex path)
        {
            _request = request;
            _path = path;
        }

        public void Use()
        {
            _path.IsMatch(_request.Resolve().Path()).If(
                () => { _request.Process(); },
                () => {  }
            );
        }

        public Resolvable Resolve()
        {
            return _request;
        }
    }
}
