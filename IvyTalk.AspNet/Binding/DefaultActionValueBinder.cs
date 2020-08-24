using System;
using IvyTalk.AspNet.Attributes;
using IvyTalk.AspNet.Controllers;
using IvyTalk.AspNet.Interfaces;
using IvyTalk.AspNet.Utilities;

namespace IvyTalk.AspNet.Binding
{
    public class DefaultActionValueBinder : IActionValueBinder
    {
        public ActionBinding GetBinding(ActionContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            ParameterDescriptor[] descriptors = context.Descriptor.GetParameterDescriptors();
            ParameterBinding[] bindings = Array.ConvertAll(descriptors, GetParameterBinding);
            
            return new ActionBinding(context, descriptors);
        }

        private ParameterBinding GetParameterBinding(ParameterDescriptor descriptor)
        {
            ParameterBindingAttribute attribute = descriptor.ParameterBindingAttribute;
            if (attribute != null)
            {
                return attribute.GetBinding(descriptor);
            }

            /*
             *  TODO: Configure 自定义配置项绑定器
             */

            Type type = descriptor.ParameterType;
            if (TypeHelper.CanConvertFromString(type))
            {
                return descriptor.BindWithAttribute(new FormUriAttribute());
            }
            
            return descriptor.BindWithAttribute(new FormBodyAttribute());
        }
    }
}