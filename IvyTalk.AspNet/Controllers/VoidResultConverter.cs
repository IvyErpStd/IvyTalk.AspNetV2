using System.Web;
using IvyTalk.AspNet.Interfaces;

namespace IvyTalk.AspNet.Controllers
{
    public class VoidResultConverter : ActionConverter
    {
        public VoidResultConverter(ActionDescriptor descriptor) : base(descriptor)
        {
        }
     
        public override bool Execute(HttpResponse response, object result)
        {
            response.OutputStream.Flush();
            return true;
        }
    }
}