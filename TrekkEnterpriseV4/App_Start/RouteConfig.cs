using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TrekkEnterpriseV4
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // new AccessCode button (Enterprise/Edit)
            routes.MapRoute(
                name: "RemoteEntryCode",
                url: "downloads/remoteentrycode",
                defaults: new { controller = "Downloads", action = "RemoteEntryCode" }
            );

            // email
            routes.MapRoute(
                name: "Validate",
                url: "validate/{email}/",
                defaults: new { controller = "Validate", action = "Index" }
            );

            // record download
            routes.MapRoute(
              name: "RecordDownload",
              url: "download/recorddownload/{id}",
              defaults: new { controller = "Download", action = "RecordDownload" }
           );
            // download
            routes.MapRoute(
             name: "Download",
             url: "download/{id}",
             defaults: new { controller = "Download", action = "Download" }
         );



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
