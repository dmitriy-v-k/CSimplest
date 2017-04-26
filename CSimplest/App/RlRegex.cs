using CSimplest.CSRequest.Interfaces;
using System.Text.RegularExpressions;
using CSimplest.Extensions;
using System;

namespace CSimplest.App
{
    public sealed class RlRegex: AppRule
    {
        private readonly RqWrap _request;
        private readonly Regex _path;

        public RlRegex(RqWrap request, Regex path)
        {
            _request = request;
            _path = path;
        }

        public void Use()
        {
            _path.IsMatch(_request.Unwrap().Path()).If(
                () => { _request.Process(); },
                () => {  }
            );
        }

        public RqWrap Unwrap()
        {
            return _request;
        }
    }
}
