using CSimplest.CSRequest.Interfaces;
using System.Text.RegularExpressions;
using System;
using CSimplest.Extensions;

namespace CSimplest.App
{
    public sealed class RxRule: AppRule
    {
        private readonly Resolvable _request;
        private readonly Regex _path;

        public RxRule(Regex path, Resolvable request)
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
    }
}
