using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Web.UI.JavaScript;
using System.Web.Routing;
using System.Web.Mvc;
using Umbraco.Web;
using ListViewForCustomSection.Controllers;

namespace ListViewForCustomSection
{
    public class ServerVariableParserEvent : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            ServerVariablesParser.Parsing += ServerVariablesParser_Parsing;
        }

        void ServerVariablesParser_Parsing(object sender, Dictionary<string, object> e)
        {
            if (HttpContext.Current == null) return;
            var urlHelper = new UrlHelper(new RequestContext(new HttpContextWrapper(HttpContext.Current), new RouteData()));

            var mainDictionary = new Dictionary<string, object>();
            mainDictionary.Add("demoBaseUrl", urlHelper.GetUmbracoApiServiceBaseUrl<PeopleApiController>(controller => controller.GetAll()));

            if (!e.Keys.Contains("demoSection"))
            {
                e.Add("demoSection", mainDictionary);
            }
        }


    }
}