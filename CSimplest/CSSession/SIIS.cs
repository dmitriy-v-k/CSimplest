using CSimplest.CSSession.Interfaces;
using System.Web.SessionState;
using System;
using System.Web.Configuration;
using System.Configuration;

namespace CSimplest.CSSession
{
    public sealed class SIIS : SSource
    {
        private readonly HttpSessionState _session;
        public SIIS(HttpSessionState session)
        {
            _session = session;
        }

        public string CookieName()
        {
            SessionStateSection sessionStateSection =
              (SessionStateSection)ConfigurationManager.GetSection("system.web/sessionState");
            return sessionStateSection.CookieName;
        }

        public string Id()
        {
            return _session.SessionID;
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
