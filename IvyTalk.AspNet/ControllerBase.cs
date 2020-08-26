using System.Net;
using System.Web;
using System.Web.SessionState;
using IvyTalk.AspNet.Controllers;
using IvyTalk.AspNet.Interfaces;

namespace IvyTalk.AspNet
{
    public abstract class ControllerBase : IController, IHttpHandler, IRequiresSessionState
    {
        protected virtual bool IsReusable => true;

        protected HttpContext HttpContext { get; private set; }

        private void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequestUpgrading)
            {
                // 不支持 Websocket
                throw new HttpWrapperException(HttpStatusCode.OK, "Unsupported Websocket!");
            }

            HttpContext = context;
            RouteData routeData = new RouteData(context);
            ControllerDescriptor descriptor = new ControllerDescriptor(this, GlobalConfiguration.Configuration);
            ControllerContext controllerContext = new ControllerContext(this, descriptor, context, routeData);
            Execute(descriptor, controllerContext);
        }

        protected abstract void Execute(ControllerDescriptor descriptor, ControllerContext context);

        #region IHttpHandler Impl

        void IHttpHandler.ProcessRequest(HttpContext context)
        {
            ProcessRequest(context);
        }

        bool IHttpHandler.IsReusable => IsReusable;

        #endregion
    }
}