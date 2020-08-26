using System.Web;
using IvyTalk.AspNet.Interfaces;

namespace IvyTalk.AspNet.Controllers
{
    public class VoidResultConverter : ActionConverter
    {
        public VoidResultConverter(ActionDescriptor descriptor) : base(descriptor)
        {
        }
     
        public override bool Execute(ActionContext context, object result)
        {
            context.ControllerContext.Response.OutputStream.Flush();
            return true;
        }
    }
}