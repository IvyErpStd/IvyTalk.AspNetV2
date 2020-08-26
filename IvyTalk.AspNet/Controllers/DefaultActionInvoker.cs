using System.Web;
using IvyTalk.AspNet.Interfaces;

namespace IvyTalk.AspNet.Controllers
{
    public class DefaultActionInvoker : ActionInvoker
    {
        public DefaultActionInvoker(ActionContext actionContext)
            : base(actionContext)
        {
        }

        public override bool Execute()
        {
            ActionDescriptor descriptor = ActionContext.Descriptor;
            ActionConverter converter = descriptor.ActionConverter;
            HttpResponse response = ActionContext.ControllerContext.Response;
            
            descriptor.ActionBinding.ExecuteBinding(ActionContext);
            object actionResult = descriptor.Execute(ActionContext, ActionContext.ActionParameters);
            return converter.Execute(ActionContext, actionResult);
        }
    }
}