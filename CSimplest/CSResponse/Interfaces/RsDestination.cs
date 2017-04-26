using System.Collections.Generic;

namespace CSimplest.CSResponse.Interfaces
{
    public interface RsDestination : RsWrap
    {
        RsDestination Text(string text);
        RsDestination Header(KeyValuePair<string,string> value);
    }
}