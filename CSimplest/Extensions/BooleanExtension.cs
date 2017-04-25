using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSimplest.Extensions
{
    public static class BooleanExtension
    {
        public static void If(this bool result, Action ifTrue, Action ifFalse)
        {
            if (result)
                ifTrue();
            else
                ifFalse();
        }
    }
}
