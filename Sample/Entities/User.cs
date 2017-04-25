using CSimplest.Common;
using CSimplest.Documents;
using System.Collections.Generic;
using System;

namespace Sample.Entities
{
    public sealed class User: CanDocument, CanHtml
    {
        private readonly string _name;
        private readonly string _secondName;
        public User(string name, string secondName)
        {
            _name = name;
            _secondName = secondName;
        }

        public Document AsDocument()
        {
            return new DcPlain(
                new Text(
                    AsString()
                )
            );
        }

        public Document AsHtml()
        {
            return new DcTemplate(
                new DcFile(
                    new FilePath("~/App_Data/Templates/Html/User.html").Resolve()
                ),
                new Dictionary<string, Stringable>() {
                    { "name", new Text(_name) },
                    { "secondName", new Text(_secondName) }
                }
            );
        }

        public string AsString()
        {
            return string.Format("{0} {1}", _name, _secondName);
        }
    }
}