using IvyTalk.AspNet.Controllers;

namespace IvyTalk.AspNet.Attributes
{
    public class FormBodyAttribute: ParameterBindingAttribute
    {
        public override ParameterBinding GetBinding(ParameterDescriptor descriptor)
        {
            // TODO
            throw new System.NotImplementedException();
        }
    }
}