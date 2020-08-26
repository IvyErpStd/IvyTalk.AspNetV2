using System;
using System.Collections.Generic;
using System.Linq;
using IvyTalk.AspNet.Attributes;
using IvyTalk.AspNet.Controllers;
using IvyTalk.AspNet.Interfaces;
using IvyTalk.AspNet.Utilities;

namespace IvyTalk.AspNet.Binding
{
    public class DefaultActionValueBinder : IActionValueBinder
    {
        public ActionBinding GetBinding(ActionDescriptor descriptor)
        {
            if (descriptor is null)
            {
                throw new ArgumentNullException(nameof(descriptor));
            }

            ParameterDescriptor[] descriptors = descriptor.GetParameterDescriptors();
            ParameterBinding[] bindings = Array.ConvertAll(descriptors, GetParameterBinding);
            ActionBinding binding = new ActionBinding(descriptor, bindings);
            
            EnsureOneBodyParameter(binding);
            return binding;
        }

        private static ParameterBinding GetParameterBinding(ParameterDescriptor descriptor)
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
                return descriptor.BindWithAttribute(new FromUriAttribute());
            }

            return descriptor.BindWithAttribute(new FromBodyAttribute());
        }

        /// <summary>
        /// 确保只有一个 <see cref="FromBodyAttribute"/>
        /// </summary>
        private static void EnsureOneBodyParameter(ActionBinding actionBinding)
        {
            int willReadBodyCount = actionBinding.Parameters.Count(c => c.WillReadBody);
            if (willReadBodyCount > 1)
            {
                Array.ConvertAll(actionBinding.Parameters,
                    input => 
                        new ErrorParameterBinding(input.ParameterDescriptor, "无法将多个参数绑定到请求的内容"));
            }
        }
    }
}