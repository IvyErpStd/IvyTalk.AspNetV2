using System;
using IvyTalk.AspNet.Controllers;

namespace IvyTalk.AspNet.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Parameter, Inherited = true,
        AllowMultiple = false)]
    public class ModelBinderAttribute : ParameterBindingAttribute
    {
        public ModelBinderAttribute()
        {
        }

        public ModelBinderAttribute(Type type)
        {
            BinderType = type ?? throw new ArgumentNullException(nameof(type));
        }

        /// <summary>
        /// 自定义绑定，暂时不做
        /// </summary>
        public Type BinderType { get; set; }

        public override ParameterBinding GetBinding(ParameterDescriptor descriptor)
        {
            throw new NotImplementedException();
        }
        
        // public virtual IValueProvider 
    }
}