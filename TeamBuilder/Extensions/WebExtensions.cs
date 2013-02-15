using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace TeamBuilder
{
    public static class WebExtensions
    {
        public static T Throw404IfNull<T>(this T instance) where T : class
        {
            if (instance == null)
            {
                throw new HttpException(404, "HTTP/1.1 404 Not Found");
            }
            return instance;
        }

        // Simple helper to get a css class when a controller is active
        public static MvcHtmlString MenuActiveLink(
            this HtmlHelper htmlHelper,
            string @class,
            string controllerName)
        {
            string currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");
            
            if (controllerName == currentController)
            {
                return new MvcHtmlString(@class);
            }
            return null;
        }
    }
}