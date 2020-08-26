using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IvyTalk.AspNet.Binding;
using IvyTalk.AspNet.Interfaces;

namespace IvyTalk.AspNet.Controllers
{
    public class ActionDescriptor
    {
        public ActionDescriptor(MethodInfo methodInfo, ControllerDescriptor controllerDescriptor)
        {
            MethodInfo = methodInfo ?? throw new ArgumentNullException(nameof(methodInfo));
            ControllerDescriptor =
                controllerDescriptor ?? throw new ArgumentNullException(nameof(controllerDescriptor));
            Configuration = controllerDescriptor.Configuration;
        }

        private Type _returnType;
        private ParameterInfo[] _parameterInfos;
        private ParameterDescriptor[] _parameterDescriptors;
        private ActionBinding _actionBinding;
        private static readonly IActionValueBinder ActionValueBinder = new DefaultActionValueBinder();
        private ActionConverter _actionConverter;

        /// <summary>
        /// 转换器
        /// </summary>
        public ActionConverter ActionConverter
            => _actionConverter ?? (_actionConverter = ActionConverterFactory(ReturnType));

        /// <summary>
        /// 配置
        /// </summary>
        public HttpConfiguration Configuration { get; }

        /// <summary>
        /// 控制器描述器
        /// </summary>
        public ControllerDescriptor ControllerDescriptor { get; }

        /// <summary>
        /// Method 的反射信息
        /// </summary>
        public MethodInfo MethodInfo { get; }

        /// <summary>
        /// 返回类型
        /// </summary>
        public Type ReturnType => _returnType ?? (_returnType = MethodInfo.ReturnType);

        /// <summary>
        /// Method 的参数信息
        /// </summary>
        public ParameterInfo[] ParameterInfos => _parameterInfos ?? (_parameterInfos = MethodInfo.GetParameters());

        /// <summary>
        /// 目标 Action 的名称, 也就是 Method 的名称
        /// </summary>
        public string Name => MethodInfo.Name;

        /// <summary>
        /// Action 绑定
        /// </summary>
        public ActionBinding ActionBinding
        {
            get
            {
                if (_actionBinding != null)
                {
                    return _actionBinding;
                }

                ActionBinding binding = ActionValueBinder.GetBinding(this);
                _actionBinding = binding;
                return _actionBinding;
            }
        }

        /// <summary>
        /// 生成 Action 的 Parameters 解释器
        /// </summary>
        public ParameterDescriptor[] GetParameterDescriptors()
        {
            return _parameterDescriptors ?? (_parameterDescriptors = InnerGetParameterDescriptors());
        }

        private ParameterDescriptor[] InnerGetParameterDescriptors()
        {
            ParameterDescriptor[] descriptors = new ParameterDescriptor[ParameterInfos.Length];
            for (int i = 0; i < ParameterInfos.Length; i++)
            {
                ParameterInfo parameter = ParameterInfos[i];
                descriptors[i] = new ParameterDescriptor(this, parameter);
            }

            return descriptors;
        }

        /// <summary>
        /// 执行 Action
        /// </summary>
        /// <returns>返回 Action 的 return 结果</returns>
        public object Execute(ActionContext context, IDictionary<string, object> arguments)
        {
            ParameterDescriptor[] descriptors = GetParameterDescriptors();
            object[] args = new object[descriptors.Length];
            for (var i = 0; i < descriptors.Length; i++)
            {
                ParameterDescriptor descriptor = descriptors[i];
                args[i] = GetArguments(descriptor, arguments);
            }

            return MethodInfo.Invoke(ControllerDescriptor.Controller, args);
        }

        private static object GetArguments(ParameterDescriptor descriptor, IDictionary<string, object> arguments)
        {
            return arguments.TryGetValue(descriptor.Name, out object value) ? value : descriptor.DefaultValue;
        }
        
        /// <summary>
        /// 转换器工厂
        /// </summary>
        private ActionConverter ActionConverterFactory(Type returnType)
        {
            if (returnType == typeof(IActionResult))
            {
                return new ActionResultConverter(this);
            }

            if (returnType == typeof(void))
            {
                return new VoidResultConverter(this);
            }

            return new GenericResultConverter(this);
        }
    }
}