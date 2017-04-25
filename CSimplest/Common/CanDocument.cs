using CSimplest.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSimplest.Common
{
    public interface CanDocument: Stringable
    {
        Document AsDocument();
    }
}
