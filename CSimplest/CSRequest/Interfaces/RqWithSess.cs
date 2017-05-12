namespace CSimplest.CSRequest.Interfaces
{
    public interface RqWithSess : RqWrap
    {
        RqWithSess Session(string key, string value);
        string Session(string key);
    }
}
