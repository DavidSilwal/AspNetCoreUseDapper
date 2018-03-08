using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;

namespace Portal.Infrastructure
{
    public class RouteConfig
    {
        public static void RegisterRoutes(IRouteBuilder routes)
        {
            routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
