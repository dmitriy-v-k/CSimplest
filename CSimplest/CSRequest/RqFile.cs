using CSimplest.CSRequest.Interfaces;
using CSimplest.CSResponse.Interfaces;
using CSimplest.CSResponse;
using CSimplest.Documents;
using System.IO;
using CSimplest.Common;
using System;

namespace CSimplest.CSRequest
{
    public sealed class RqFile : RqWrap
    {
        private readonly RqWrap _src;
        private readonly RsWrap _dest;
        private readonly string root;

        public RqFile(RqWrap src, RsWrap dest, string rootFileDirectory)
        {
            _src = src;
            _dest = dest;
            root = rootFileDirectory;
        }

        public void Process()
        {
            new RsDocument(
                _dest, 
                new DcFile(
                    preparePath(Unwrap().Path())
                )
            ).Go();
        }

        private string preparePath(string path)
        {
            return Path.Combine(root, path.Replace("~/", ""));
        }

        public RqSource Unwrap()
        {
            return _src.Unwrap();
        }
    }
}
