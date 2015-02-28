using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Mvc;

namespace GreatSavings
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}"
            );

            config.Routes.MapHttpRoute(
                 name: "DefaultActionApi",
                 routeTemplate: "api/{controller}/{id}",
                 defaults: new { id = RouteParameter.Optional }
             );


            config.Routes.MapHttpRoute(
                  name: "DefaultApiWithAction",
                  routeTemplate: "api/{controller}/{action}/{id}",
                  defaults: new { id = RouteParameter.Optional }
             );

           config.Routes.MapHttpRoute(
               name: "DefaultApiWithActionTest",
               routeTemplate: "api/{controller}/{action}/{email}",
               defaults: new { email = RouteParameter.Optional }
            );

           config.Routes.MapHttpRoute(
               name: "ApiLoadAction",
               routeTemplate: "api/{controller}/{action}/{totalReturn}",
               defaults: null,
               constraints: new { totalReturn = @"^\d+$" } // id must be all digits
            );

           //config.Routes.MapHttpRoute(
           //    name: "MerchantLogin",
           //    routeTemplate: "api/Account/MerchantLogin/{login}",
           //    defaults: new { login = RouteParameter.Optional, controller = "Account", action = "MerchantLogin" }
           // );
 
            //config.Routes.MapHttpRoute(
            //    name: "ApiByName",
            //    routeTemplate: "api/{controller}/{action}/{name}",
            //    defaults: null,
            //    constraints: new { name = @"^[a-z]+$" }
            //);

            //config.Routes.MapHttpRoute(
            //         name: "ApiByAction",
            //         routeTemplate: "api/{controller}/{action}",
            //         defaults: new { action = "Get" }
            //     );
      
         
        }
    }
}
