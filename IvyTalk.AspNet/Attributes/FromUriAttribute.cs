using IvyTalk.AspNet.Binding;
using IvyTalk.AspNet.Controllers;

namespace IvyTalk.AspNet.Attributes
{
    public class FromUriAttribute : ParameterBindingAttribute
    {
        public override ParameterBinding GetBinding(ParameterDescriptor descriptor)
        {
            return new NameValueParameterBinding(descriptor);
        }
    }
}