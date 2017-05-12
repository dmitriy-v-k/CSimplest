using CSimplest.CSResponse.Interfaces;
using System;

namespace CSimplest.CSResponse
{
    public sealed class RsLazy : RsWrap
    {
        private readonly Func<RsWrap> _rsDelegate;

        public RsLazy(Func<RsWrap> rsDelegate)
        {
            _rsDelegate = rsDelegate;
        }

        public void Go()
        {
            _rsDelegate().Go();
        }

        public RsDestination Unwrap()
        {
            return _rsDelegate().Unwrap();
        }
    }
}
