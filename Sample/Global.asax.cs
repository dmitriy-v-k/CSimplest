using CSimplest.App;
using CSimplest.Common;
using CSimplest.CSRequest;
using CSimplest.CSResponse;
using CSimplest.Documents;
using Sample.Entities;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;

namespace Sample
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var textRq =
                new RqWithResponse(
                    new RqIIS(Request),
                    new RsDocument(
                        new RsIIS(Response),
                        new DcTemplate(
                            new DcFile(
                                new FilePath("~/App_Data/test.txt").Unwrap()
                            ),
                            new Dictionary<string, Text>()
                            {
                                { "user", new User("User", "Sample") }
                            }
                        )
                    )
                );

            var htmlRq=
                new RqWithResponse(
                    new RqIIS(Request),
                        new RsHtml(
                            new RsIIS(Response),
                            new User("User", "Sample")
                        )
                );

            var jsonRq =
                new RqWithResponse(
                    new RqIIS(Request),
                        new RsJson(
                            new RsIIS(Response),
                            new User("User", "Sample")
                        )
                );

            new Application(new List<AppRule>() {
                new RlRegex(
                    textRq, new Regex("^~/$",RegexOptions.Compiled)
                ),
                new RlRegex(
                    htmlRq, new Regex("^~/html.*$",RegexOptions.Compiled)
                ),
                new RlPost(
                    new RlRegex(
                        jsonRq, 
                        new Regex("^~/json.*$",RegexOptions.Compiled)
                    )
                )
            }).Run();
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}