namespace CSimplest.CSSession.Interfaces
{
    public interface SSource : SWrap
    {
        string Item(string key);
        SSource Item(string key, string value);
    }
}
