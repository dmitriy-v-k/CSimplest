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
            var request1 =
                new RqWithResponse(
                    new RqIIS(Request),
                    new RsWithHeaders(
                        new RsText(
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
                        ),
                        new List<KeyValuePair<string, string>>()
                        {
                            new KeyValuePair<string, string>("n1", "v1")
                        }
                    )
                );

            var request2 =
                new RqWithResponse(
                    new RqIIS(Request),
                    new RsText(
                        new RsIIS(Response),
                        new Text("Done2")
                    )
                );

            new Application(new List<RxRule>() {
                new RxRule(
                    new Regex("^~/$",RegexOptions.Compiled),request1
                ),
                new RxRule(
                    new Regex("^~/test.*$",RegexOptions.Compiled),request2
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