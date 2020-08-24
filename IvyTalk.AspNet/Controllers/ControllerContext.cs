using System;
using System.Web;

namespace IvyTalk.AspNet.Controllers
{
    public class ControllerContext
    {
        /// <summary>
        /// 控制器
        /// </summary>
        public ControllerBase Controller { get; }

        /// <summary>
        /// 描述器
        /// </summary>
        public ControllerDescriptor Descriptor { get; }
        
        /// <summary>
        /// Http 上下文
        /// </summary>
        public HttpContext Context { get; }
        
        /// <summary>
        /// 路由信息
        /// </summary>
        public RouteData RouteData { get; }
        
        /// <summary>
        /// Request 上下文
        /// </summary>
        public HttpRequest Request => Context?.Request;
        
        /// <summary>
        /// Response 上下文
        /// </summary>
        public HttpResponse Response => Context?.Response;

        /// <summary>
        /// 配置项
        /// </summary>
        public HttpConfiguration Configuration { get; }

        public ControllerContext(ControllerBase controller, ControllerDescriptor descriptor, HttpContext context,
            RouteData routeData)
        {
            Controller = controller ?? throw new ArgumentNullException(nameof(controller));
            Descriptor = descriptor ?? throw new ArgumentNullException(nameof(descriptor));
            Context = context ?? throw new ArgumentNullException(nameof(context));
            RouteData = routeData ?? throw new ArgumentNullException(nameof(routeData));
        }
    }
}