using System;
using System.Web;

namespace IvyTalk.AspNet.Controllers
{
    public abstract class ParameterBinding
    {
        public ParameterBinding(ParameterDescriptor parameterDescriptor)
        {
            ParameterDescriptor = parameterDescriptor;
        }
    
        /// <summary>
        /// 参数解释器
        /// </summary>
        public ParameterDescriptor ParameterDescriptor { get; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid => ErrorMessage is null;
        
        /// <summary>
        /// 是否需要读取 Body
        /// </summary>
        public virtual bool WillReadBody => false;

        /// <summary>
        /// 错误信息
        /// </summary>
        public virtual string ErrorMessage { get; }

        public abstract void ExecuteBinding(ActionContext context);
        
        protected object GetValue(ActionContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            context.ActionParameters.TryGetValue(ParameterDescriptor.Name, out object value);
            return value;
        }

        protected void SetValue(ActionContext context, object value)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            context.ActionParameters[ParameterDescriptor.Name] = value;
        }
    }
}