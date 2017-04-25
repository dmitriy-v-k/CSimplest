namespace CSimplest.Common
{
    public sealed class Text: Stringable
    {
        private readonly string _origin;
        public Text(string origin)
        {
            _origin = origin;
        }

        public string AsString()
        {
            return _origin;
        }
    }
}
