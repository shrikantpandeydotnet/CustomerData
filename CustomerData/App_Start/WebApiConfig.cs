using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.WebHost;
using System.Web.Routing;
using System.Web.SessionState;

namespace CustomerData
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //var httpControllerRouteHandler = typeof(HttpControllerRouteHandler).GetField("_instance",
            //    System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            //if (httpControllerRouteHandler != null)
            //{
            //    httpControllerRouteHandler.SetValue(null
            //        , new Lazy<HttpControllerRouteHandler>(() => new SessionHttpControllerRouteHandler(), true));
            //}
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(
                config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml"));
        }
    }

    

    //public class SessionControllerHandler:HttpControllerHandler, IRequiresSessionState
    //{
    //    public SessionControllerHandler(RouteData routeData): base(routeData)
    //    {

    //    }
    //}

    //public class SessionHttpControllerRouteHandler : HttpControllerRouteHandler
    //{
    //    protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
    //    {
    //        return new SessionControllerHandler(requestContext.RouteData);
    //    }
    //}
}
