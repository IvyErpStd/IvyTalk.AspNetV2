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

        /// <summary>
        /// 执行绑定
        /// </summary>
        public virtual void ExecuteBinding(ActionContext context)
        {
            if (Parameters is null)
            {
                return;
            }

            foreach (var parameter in Parameters)
            {
                if (!parameter.IsValid)
                {
                    throw new ArgumentException(parameter.ErrorMessage);
                }

                parameter.ExecuteBinding(context);
            }
        }
    }
}