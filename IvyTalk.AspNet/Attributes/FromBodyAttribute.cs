using System;
using System.Collections.Generic;
using IvyTalk.AspNet.Controllers;
using IvyTalk.AspNet.Formatting;

namespace IvyTalk.AspNet.Attributes
{
    public class FromBodyAttribute: ParameterBindingAttribute
    {
        public override ParameterBinding GetBinding(ParameterDescriptor descriptor)
        {
            if (descriptor is null)
            {
                throw new ArgumentNullException(nameof(descriptor));
            }

            IEnumerable<MediaTypeFormatter> formatters = descriptor.Configuration.MediaTypeFormatters;
            return descriptor.BindWithFormatter(formatters);
        }
    }
}