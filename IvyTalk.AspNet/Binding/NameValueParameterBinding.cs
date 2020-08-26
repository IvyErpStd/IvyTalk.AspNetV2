using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web;
using IvyTalk.AspNet.Controllers;
using IvyTalk.AspNet.Utilities;

namespace IvyTalk.AspNet.Binding
{
    public class NameValueParameterBinding : ParameterBinding
    {
        public NameValueParameterBinding(ParameterDescriptor parameterDescriptor) :
            base(parameterDescriptor)
        {
        }

        public override void ExecuteBinding(ActionContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            HttpRequest request = context.ControllerContext.Request;
            object value = ExecuteBindingCore(request);
            SetValue(context, value);
        }

        private object ExecuteBindingCore(HttpRequest request)
        {
            Type type = ParameterDescriptor.ParameterType;
            string value = request[ParameterDescriptor.Name];
            if (string.IsNullOrWhiteSpace(value))
            {
                return ParameterDescriptor.DefaultValue;
            }

            if (TypeHelper.CanConvertFromString(type))
            {
                TypeConverter converter = TypeDescriptor.GetConverter(type);
                return converter.ConvertFromString(value);
            }

            return ParameterDescriptor.DefaultValue;
        }
    }
}