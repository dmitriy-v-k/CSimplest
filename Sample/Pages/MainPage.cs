using System;
using CSimplest.Common;
using CSimplest.Documents.Interfaces;
using CSimplest.Documents;
using System.Collections.Generic;

namespace Sample.Pages
{
    public sealed class MainPage : DcHtml
    {
        public Text AsHtml()
        {
            return new DcTemplate(
                new DcFile(
                    new FilePath("~/App_Data/Templates/Html/MainPage.html").Unwrap()
                ),
                new Dictionary<string, Text>()
                {
                    
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