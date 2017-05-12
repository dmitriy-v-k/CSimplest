using CSimplest.Common;
using CSimplest.Documents.Interfaces;
using CSimplest.Documents;
using System.Collections.Generic;

namespace SimpleSite.Pages
{
    public sealed class MainPage : DcHtml
    {
        private readonly DcHtml _content;
        public MainPage(DcHtml content)
        {
            _content = content;
        }
        public Text AsHtml()
        {
            return new DcTemplate(
                new DcFile(
                    new FilePath("~/App_Data/Templates/Html/MainPage.html").Unwrap()
                ),
                new Dictionary<string, Text>()
                {
                    { "content" , _content.AsHtml() }
                }
            ).AsText();
        }

        public Text AsText()
        {
            return new PlainText(Unwrap());
        }

        public string Unwrap()
        {
            return nameof(MainPage);
        }
    }
}