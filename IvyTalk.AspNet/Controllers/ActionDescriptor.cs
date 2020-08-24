using System;
using System.Reflection;

namespace IvyTalk.AspNet.Controllers
{
    public class ActionDescriptor
    {
        public ActionDescriptor(MethodInfo methodInfo, ControllerDescriptor controllerDescriptor)
        {
            MethodInfo = methodInfo ?? throw new ArgumentNullException(nameof(methodInfo));
            ControllerDescriptor =
                controllerDescriptor ?? throw new ArgumentNullException(nameof(controllerDescriptor));
        }

        private Type _returnType;
        private ParameterInfo[] _parameterInfos;

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
    }
}