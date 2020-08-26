using System;

namespace IvyTalk.AspNet.Controllers
{
    public abstract class ActionInvoker
    {
        public ActionContext ActionContext { get; }

        public ActionInvoker(ActionContext actionContext)
        {
            ActionContext = actionContext ?? throw new ArgumentNullException(nameof(actionContext));
        }

        public abstract bool Execute();
    }
}