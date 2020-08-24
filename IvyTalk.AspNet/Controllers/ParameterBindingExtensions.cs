using IvyTalk.AspNet.Attributes;

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
        public static ParameterBinding BindWithAttribute(this ParameterDescriptor parameter, ParameterBindingAttribute attribute)
        {
            return attribute.GetBinding(parameter);
        }
    }
}