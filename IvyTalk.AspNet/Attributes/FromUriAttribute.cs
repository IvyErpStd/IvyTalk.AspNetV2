using IvyTalk.AspNet.Controllers;

namespace IvyTalk.AspNet.Attributes
{
    public class FromUriAttribute : ParameterBindingAttribute
    {
        public override ParameterBinding GetBinding(ParameterDescriptor descriptor)
        {
            throw new System.NotImplementedException();
        }
    }
}