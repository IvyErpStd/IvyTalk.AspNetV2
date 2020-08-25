using System;
using IvyTalk.AspNet.Controllers;

namespace IvyTalk.AspNet.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Parameter, Inherited = true, AllowMultiple = false)]
    public abstract class ParameterBindingAttribute : Attribute
    {
        public abstract ParameterBinding GetBinding(ParameterDescriptor descriptor);
    }
}