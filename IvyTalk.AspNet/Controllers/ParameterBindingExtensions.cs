using System;
using System.Collections.Generic;
using IvyTalk.AspNet.Attributes;
using IvyTalk.AspNet.Formatting;

namespace IvyTalk.AspNet.Controllers
{
    public static class ParameterBindingExtensions
    {
        /// <summary>
        /// <see cref="ParameterBindingAttribute"/> 获取绑定 <see cref="ParameterBinding"/>
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public static ParameterBinding BindWithAttribute(this ParameterDescriptor parameter,
            ParameterBindingAttribute attribute)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }

            return attribute.GetBinding(parameter);
        }

        public static ParameterBinding BindWithFormatter(this ParameterDescriptor parameter,
            IEnumerable<MediaTypeFormatter> formatters)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }

            return new FormatterParameterBinding(parameter, formatters);
        }
    }
}