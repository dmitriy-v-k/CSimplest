using CSimplest.CSRequest.Interfaces;
using CSimplest.CSResponse.Interfaces;

using RqResolvable = CSimplest.CSRequest.Interfaces.Resolvable;

namespace CSimplest.CSRequest
{
    public class RqWithResponse : RqResolvable
    {
        private RqResolvable _origin;
        private Response _response;
        public RqWithResponse(RqResolvable origin, Response response)
        {
            _origin = origin;
            _response = response;
        }

        public Src Resolve()
        {
            return _origin.Resolve();
        }

        public void Process()
        {
            _response.Go();
        }
    }
}
