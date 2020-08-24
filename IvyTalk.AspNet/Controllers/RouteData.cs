using System;
using System.Web;

namespace IvyTalk.AspNet.Controllers
{
    public class RouteData
    {
        public HttpContext Context { get; }

        /// <summary>
        /// Action 名称
        /// </summary>
        public string RouteName
            => GetRouteNameOrThrow();

        private string GetRouteNameOrThrow()
        {
            string target = Context?.Request.QueryString["t"];
            if (string.IsNullOrWhiteSpace(target))
            {
                throw new HttpException(404, "目标路由不存在.");
            }

            return target;
        }

        public RouteData(HttpContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}