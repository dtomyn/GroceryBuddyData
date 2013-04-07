﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MyDataServices
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            RegisterApiRoutes(GlobalConfiguration.Configuration);

            //Debugger.Break();

            // WebApi Configuration to hook up formatters and message handlers
            // optional
           // RegisterApis(GlobalConfiguration.Configuration);
        }

        private void RegisterApiRoutes(HttpConfiguration configuration)
        {
            RouteTable.Routes.MapHttpRoute(
                            name: "ProductsVerbs",
                            routeTemplate: "Products/{sku}",
                            defaults: new
                            {
                                title = RouteParameter.Optional,
                                controller = "ProductsController"
                            }
                        );
        }

        public static void RegisterApis(HttpConfiguration config)
        {
            // Display errors in response locally
            GlobalConfiguration
                   .Configuration
                   .IncludeErrorDetailPolicy =
                    IncludeErrorDetailPolicy.Always;


            // Add a custom JsonP converter which effectively replaces the default JSON formatter     
            // you can configue the custom formatter in it's creation code
            config.Formatters.Insert(0, new JsonpFormatter());


            // Add the exception filter
            config.Filters.Add(new UnhandledExceptionFilter());
        }

    }
}