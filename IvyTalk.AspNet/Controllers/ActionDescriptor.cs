using System;
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
                return binding;
            }
        }

        /// <summary>
        /// 生成 Action 的 Parameter 解释器
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
    }
}