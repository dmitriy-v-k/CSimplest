using CSimplest.CSResponse.Interfaces;
using System;
using System.Collections.Specialized;

namespace CSimplest.CSResponse
{
    public sealed class RsParametric : RsWrap
    {
        private readonly Func<NameValueCollection, RsWrap> _rsDelegate;
        private readonly NameValueCollection _parameters;
        public RsParametric(Func<NameValueCollection, RsWrap> rsDelegate, NameValueCollection parameters)
        {
            _rsDelegate = rsDelegate;
            _parameters = parameters;
        }
        public void Go()
        {
            _rsDelegate(_parameters).Go();
        }

        public RsDestination Unwrap()
        {
            return _rsDelegate(_parameters).Unwrap();
        }
    }
}
