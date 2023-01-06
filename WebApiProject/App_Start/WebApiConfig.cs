using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace WebApiProject
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //json formatında gösterme 
            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(
            //   new MediaTypeHeaderValue("text/html") 
            //);
            //xml formatını silmek, bu kodu yazmadan da üstteki kod ile de json formatın da verileri görebiliriz
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
