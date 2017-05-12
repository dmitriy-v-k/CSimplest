using CSimplest.CSSession.Interfaces;
using System;
using System.Collections.Generic;

namespace CSimplest.CSSession.Mock
{
    public sealed class SMock : SSource
    {
        private readonly Dictionary<string, string> _dict;

        public SMock()
        {
            _dict = new Dictionary<string, string>();
        }


        public string CookieName()
        {
            return "Mock_Session";
        }

        public string Id()
        {
            return new Random().Next(10000, 99999).ToString();
        }

        public string Item(string key)
        {
            return _dict[key];
        }

        public SSource Item(string key, string value)
        {
            _dict[key] = value;
            return this;
        }

        public SSource Unwrap()
        {
            return this;
        }
    }
}
