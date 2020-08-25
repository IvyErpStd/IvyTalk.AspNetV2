using System;
using IvyTalk.AspNet.Controllers;

namespace IvyTalk.AspNet.Binding
{
    public class ErrorParameterBinding : ParameterBinding
    {
        public ErrorParameterBinding(ParameterDescriptor parameterDescriptor, string message) 
            : base(parameterDescriptor)
        {
            ErrorMessage = message ?? throw new ArgumentNullException(nameof(message));
        }

        public override string ErrorMessage { get; }

        public override void ExecuteBinding(ActionContext context)
        {
            // TODO: 需要验证 IsValid
            throw new InvalidOperationException();
        }
    }
}