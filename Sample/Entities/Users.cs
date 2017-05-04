using CSimplest.Documents.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSimplest.Common;

namespace Sample.Entities
{
    public sealed class Users : DcHtml
    {

        public User FindById(string id)
        {
            return new User(string.Format("name-{0}", id), string.Format("secondName-{0}", id));
        }

        public Text AsHtml()
        {
            throw new NotImplementedException();
        }

        public Text AsText()
        {
            throw new NotImplementedException();
        }

        public string Unwrap()
        {
            throw new NotImplementedException();
        }
    }
}