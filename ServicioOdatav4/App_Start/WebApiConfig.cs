using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ServicioOdatav4
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<Employees>("Employees");

            config.MapODataServiceRoute("ODataRoute", "odata", builder.GetEdmModel());
        }
        //public static void Register(HttpConfiguration config)
        //{
        //    // Configuración y servicios de API web

        //    // Rutas de API web
        //    config.MapHttpAttributeRoutes();

        //    config.Routes.MapHttpRoute(
        //        name: "DefaultApi",
        //        routeTemplate: "api/{controller}/{id}",
        //        defaults: new { id = RouteParameter.Optional }
        //    );
        //}

        //public static void Register(HttpConfiguration config)
        //{
        //    // New code:
        //    ODataModelBuilder builder = new ODataConventionModelBuilder();
        //    builder.EntitySet<Product>("Products");
        //    config.MapODataServiceRoute(
        //        routeName: "ODataRoute",
        //        routePrefix: null,
        //        model: builder.GetEdmModel());
        //}
    }
}
