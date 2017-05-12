using CSimplest.CSSession.Interfaces;
using System.Web.SessionState;

namespace CSimplest.CSSession
{
    public sealed class SIIS : SSource
    {
        private readonly HttpSessionState _session;
        public SIIS(HttpSessionState session)
        {
            _session = session;
        }

        public string Item(string key)
        {
            return _session[key].ToString();
        }

        public SSource Item(string key, string value)
        {
            _session[key] = value;
            return this;
        }

        public SSource Unwrap()
        {
            return this;
        }
    }
}
