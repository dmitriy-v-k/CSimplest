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
            var textResponse =
                new RqWithResponse(
                    new RqIIS(Request),
                    new RsDocument(
                        new RsIIS(Response),
                        new DcTemplate(
                            new DcFile(
                                new FilePath("~/App_Data/test.txt").Resolve()
                            ),
                            new Dictionary<string, Stringable>()
                            {
                                { "user", new User("Dmitriy", "Konovalov") }
                            }
                        )
                    )
                );

            var htmlResponse =
                new RqWithResponse(
                    new RqIIS(Request),
                        new RsHtml(
                            new RsIIS(Response),
                            new User("Dmitriy", "Konovalov")
                        )
                );

            new Application(new List<RxRule>() {
                new RxRule(
                    new Regex("^~/$",RegexOptions.Compiled),textResponse
                ),
                new RxRule(
                    new Regex("^~/html.*$",RegexOptions.Compiled),htmlResponse
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