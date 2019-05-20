using BoardGames.Web.Helpers;
using System.Web.Http;

namespace BoardGames.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "ActionApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
             name: "CountedActionApi",
             routeTemplate: "api/{controller}/{action}/{pageSize}",
             defaults: new { pageSize = RouteParameter.Optional }
         );
            var contain = new UnityConfiguration();
            var container = contain.Config();
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
