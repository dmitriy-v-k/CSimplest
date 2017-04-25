using CSimplest.Common;
using CSimplest.Documents;
using System.Collections.Generic;
using System;
using CSimplest.Documents.Interfaces;
using System.Text;

namespace Sample.Entities
{
    public sealed class User: CanDocument, CanHtml, CanJson
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

        public Document AsJson()
        {
            return new DcPlain(
                new Text(
                    ToJson()
                )
            );
        }

        public string AsString()
        {
            return string.Format("{0} {1}", _name, _secondName);
        }

        private string ToJson()
        {
            var json = new StringBuilder("{");
            json.AppendFormat("\"name\": \"{0}\", \"secondName\": \"{1}\"", _name, _secondName);
            json.Append("}");
            return json.ToString();
        }
    }
}