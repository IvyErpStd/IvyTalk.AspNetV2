using System;
using System.Collections.Generic;

namespace IvyTalk.AspNet.Controllers
{
    public class ActionContext
    {
        private ActionDescriptor _actionDescriptor;
        private ControllerContext _controllerContext;

        /// <summary>
        /// 解释器
        /// </summary>
        public ActionDescriptor Descriptor
        {
            get => _actionDescriptor;
            set
            {
                // 更换了 Action 解释器, 参数清空
                _actionDescriptor = value ?? throw new ArgumentNullException(nameof(value));
                Parameters = new Dictionary<string, object>(_actionDescriptor.ParameterInfos.Length);
            }
        }

        /// <summary>
        /// 控制器上下文
        /// </summary>
        public ControllerContext ControllerContext
        {
            get => _controllerContext;
            set => _controllerContext = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Method 参数
        /// </summary>
        public IDictionary<string, object> Parameters { get; protected set; }
    }
}