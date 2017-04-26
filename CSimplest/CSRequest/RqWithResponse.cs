using CSimplest.CSRequest.Interfaces;
using CSimplest.CSResponse.Interfaces;

namespace CSimplest.CSRequest
{
    public class RqWithResponse : RqWrap
    {
        private RqWrap _origin;
        private Response _response;
        public RqWithResponse(RqWrap origin, Response response)
        {
            _origin = origin;
            _response = response;
        }

        public RqSource Unwrap()
        {
            return _origin.Unwrap();
        }

        public void Process()
        {
            _response.Go();
        }
    }
}
