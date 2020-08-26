using System;
using System.Web;

namespace IvyTalk.AspNet.Controllers
{
    public abstract class ActionConverter
    {
        public ActionDescriptor ActionDescriptor { get; }

        public ActionConverter(ActionDescriptor descriptor)
        {
            ActionDescriptor = descriptor ?? throw new ArgumentNullException(nameof(descriptor));
        }

        public abstract bool Execute(HttpResponse response, object result);
    }
}