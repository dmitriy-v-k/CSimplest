using System.Collections.Generic;

namespace CSimplest.CSResponse.Interfaces
{
    public interface Dest : Resolvable
    {
        Dest Text(string text);
        Dest Header(KeyValuePair<string,string> value);
    }
}