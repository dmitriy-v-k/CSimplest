namespace CSimplest.Common
{
    public sealed class PlainText: Text
    {
        private readonly string _origin;
        public PlainText(string origin)
        {
            _origin = origin;
        }

        public string Unwrap()
        {
            return _origin;
        }
    }
}
