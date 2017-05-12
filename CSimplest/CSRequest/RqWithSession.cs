using System;
using CSimplest.CSRequest.Interfaces;
using CSimplest.CSSession.Interfaces;

namespace CSimplest.CSRequest
{
    public sealed class RqWithSession : RqWithSess
    {
        private readonly RqWrap _original;
        private readonly SWrap _session;
        public RqWithSession(RqWrap original, SWrap session)
        {
            _original = original;
            _session = session;
        }

        public void Process()
        {
            _original.Process();
        }

        public string Session(string key)
        {
            return _session.Unwrap().Item(key);
        }

        public RqWithSess Session(string key, string value)
        {
            _session.Unwrap().Item(key, value);
            return this;
        }

        public RqSource Unwrap()
        {
            return _original.Unwrap();
        }
    }
}
