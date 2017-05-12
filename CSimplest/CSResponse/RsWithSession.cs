using System.Collections.Generic;
using CSimplest.CSResponse.Interfaces;
using CSimplest.CSSession.Interfaces;

namespace CSimplest.CSResponse
{
    public sealed class RsWithSession : RsWrap
    {
        private readonly RsWrap _origin;
        private readonly Session _session;

        private readonly IEnumerable<KeyValuePair<string, string>> headers;
        public RsWithSession(RsWrap origin, Session session)
        {
            _origin = origin;
            _session = session;

            headers = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Set-Cookie", string.Format("{0}={1}",_session.CookieName(),_session.Id()))
            };
        }
        public void Go()
        {
            new RsWithHeaders(
                _origin,
                headers
            ).Go();
        }

        public RsDestination Unwrap()
        {
            return _origin.Unwrap();
        }
    }
}
