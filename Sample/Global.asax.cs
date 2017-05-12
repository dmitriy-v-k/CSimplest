using CSimplest.App;
using CSimplest.App.Methods;
using CSimplest.Common;
using CSimplest.CSRequest;
using CSimplest.CSResponse;
using CSimplest.CSSession;
using CSimplest.CSSession.Mock;
using CSimplest.Documents;
using Sample.Entities;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;

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

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var sessionMock = new SMock();

            var textRq =
                new RqWithResponse(
                    new RqIIS(Request),
                    new RsDocument(
                        new RsIIS(Response),
                        new DcTemplate(
                            new DcTextFile(
                                new FilePath("~/App_Data/test.txt").Unwrap()
                            ),
                            new Dictionary<string, Text>()
                            {
                                { "user", new User("User", "Sample") }
                            }
                        )
                    )
                );

            var htmlRq =
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

            var fileRq = new RqFile(
                new RqIIS(Request),
                new RsWithHeaders(
                    new RsIIS(Response),
                    new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("test","test")
                    }
                ),
                new FilePath("~/App_Data").Unwrap()
            );



            var paramsRq = new RqWithResponse(
                new RqIIS(Request),
                new RsWithHeaders(
                    new RsParametric((parameters) =>
                        new RsJson(
                            new RsIIS(Response),
                            new Users().FindById(parameters["name"])
                        ),
                        new RqWithParamsInPath(
                            new RqIIS(Request),
                            new Regex(@"~/params/(?<name>\w+)/(?<secondName>\w+)")
                        ).Parameters()
                    ),
                    new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("test","test")
                    }
                )
            );

            var sess = new RqWithResponse(
                new RqIIS(Request),
                new RsParametric((parameters) => {
                    var sessLoc = new RqWithSession(
                        new RqIIS(Request),
                        sessionMock
                    ).Session("id", parameters["id"]);
                    return new RsWithSession(
                        new RsJson(
                            new RsIIS(Response),
                            new Users().FindById(sessLoc.Session("id"))
                        ),
                        sessionMock
                    );
                },
                    new RqWithParamsInPath(
                        new RqIIS(Request),
                        new Regex(@"~/sess/(?<id>\w+)")
                    ).Parameters()
                )
            );

            new Application(new List<AppRule>() {
                new RlRegex(
                    textRq, new Regex("^~/$",RegexOptions.Compiled)
                ),
                new RlRegex(
                    paramsRq, new Regex("^~/params/.*$",RegexOptions.Compiled)
                ),
                new RlRegex(
                    fileRq, new Regex("^~/text/.*$",RegexOptions.Compiled | RegexOptions.IgnoreCase)
                ),
                new RlRegex(
                    htmlRq, new Regex("^~/html.*$",RegexOptions.Compiled)
                ),
                new RlRegex(
                    sess, new Regex("^~/sess.*$",RegexOptions.Compiled)
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