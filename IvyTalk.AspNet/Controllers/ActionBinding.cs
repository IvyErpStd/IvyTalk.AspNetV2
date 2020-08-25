using System;

namespace IvyTalk.AspNet.Controllers
{
    public class ActionBinding
    {
        public ActionDescriptor ActionDescriptor { get; }
        public ParameterBinding[] Parameters { get; }

        public ActionBinding(ActionDescriptor actionDescriptor, ParameterBinding[] parameter)
        {
            ActionDescriptor = actionDescriptor ?? throw new ArgumentNullException(nameof(actionDescriptor));
            Parameters = parameter ?? throw new ArgumentNullException(nameof(parameter));
        }

        public virtual void InvokeAction(ActionContext context)
        {
            // TODO: Test
            foreach (var parameterBinding in Parameters)
            {
                // parameterBinding.IsValid
                parameterBinding.ExecuteBinding(context);
            }
            //ActionDescriptor.MethodInfo.Invoke()
        }
    }
}