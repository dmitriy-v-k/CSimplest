using CSimplest.App;
using CSimplest.Common;
using CSimplest.CSRequest;
using CSimplest.CSResponse;
using CSimplest.Documents;
using SimpleSite.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace SimpleSite
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
            var mainContent = new DcWithHtml(
                new DcFile(
                    new FilePath("~/App_Data/Content/Html/MainContent.html").Unwrap()
                )
            );

            var mainPage =
                new RqWithResponse(
                    new RqIIS(Request),
                    new RsHtml(
                        new RsIIS(Response),
                        new MainPage(mainContent)
                    )
                );

            new Application(new List<AppRule>() {
                new RlRegex(
                    mainPage, new Regex("^~/$",RegexOptions.Compiled)
                ),
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