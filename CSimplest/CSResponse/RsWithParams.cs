using CSimplest.CSResponse.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace CSimplest.CSResponse
{
    public class RsWithParams : RsWithParameters
    {
        private readonly RsWrap _origin;
        public RsWithParams(RsWrap origin)
        {
            _origin = origin;
        }
        public void Go()
        {
            throw new NotImplementedException();
        }

        public void Go(NameValueCollection parameters)
        {
            throw new NotImplementedException();
        }

        public RsDestination Unwrap()
        {
            throw new NotImplementedException();
        }
    }
}
