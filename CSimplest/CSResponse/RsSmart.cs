using CSimplest.CSResponse.Interfaces;
using System;

namespace CSimplest.CSResponse
{
    public sealed class RsSmart : RsWrap
    {
        private readonly RsWrap _origin;
        private readonly Func<RsWrap, RsWrap> _logic;

        private RsWrap rsNew;

        public RsSmart(RsWrap origin, Func<RsWrap, RsWrap> logic)
        {
            _origin = origin;
            _logic = logic;
        }
        public void Go()
        {
            GetRsNew().Go();
        }

        public RsDestination Unwrap()
        {
            return GetRsNew().Unwrap();
        }

        private RsWrap GetRsNew()
        {
            return rsNew == null ? rsNew = _logic(_origin) : rsNew;
        }
    }
}
