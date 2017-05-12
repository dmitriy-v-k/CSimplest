namespace CSimplest.Common
{
    public sealed class PlainBin : Bin
    {
        private readonly byte[] _origin;
        public PlainBin(byte[] origin)
        {
            _origin = origin;
        }
        public byte[] Unwrap()
        {
            return _origin;
        }
    }
}
