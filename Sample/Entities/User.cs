using CSimplest.Common;
using CSimplest.Documents;
using System.Collections.Generic;
using CSimplest.Documents.Interfaces;
using System.Text;

namespace Sample.Entities
{
    public sealed class User: DcHtml, DcJson
    {
        private readonly string _name;
        private readonly string _secondName;
        public User(string name, string secondName)
        {
            _name = name;
            _secondName = secondName;
        }

        public Text AsHtml()
        {
            return new DcTemplate(
                new DcTextFile(
                    new FilePath("~/App_Data/Templates/Html/User.html").Unwrap()
                ),
                new Dictionary<string, Text>() {
                    { "name", new PlainText(_name) },
                    { "secondName", new PlainText(_secondName) }
                }
            ).AsText();
        }

        public Text AsJson()
        {
            return new DcPlain(
                new PlainText(
                    ToJson()
                )
            ).AsText();
        }

        public Text AsText()
        {
            return new PlainText(Unwrap());
        }

        public string Unwrap()
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