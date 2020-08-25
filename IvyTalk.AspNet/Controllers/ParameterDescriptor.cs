using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IvyTalk.AspNet.Attributes;
using IvyTalk.AspNet.Utilities;

namespace IvyTalk.AspNet.Controllers
{
    public sealed class ParameterDescriptor
    {
        public ParameterDescriptor(ActionDescriptor descriptor, ParameterInfo parameterInfo)
        {
            ActionDescriptor = descriptor ?? throw new ArgumentNullException(nameof(descriptor));
            ParameterInfo = parameterInfo ?? throw new ArgumentNullException(nameof(parameterInfo));
            Configuration = descriptor.Configuration;
        }
        
        /// <summary>
        /// 配置
        /// </summary>
        public HttpConfiguration Configuration { get; }

        /// <summary>
        /// Action 解释器
        /// </summary>
        public ActionDescriptor ActionDescriptor { get; }

        /// <summary>
        /// 参数信息
        /// </summary>
        public ParameterInfo ParameterInfo { get; }

        /// <summary>
        /// 参数目标类型
        /// </summary>
        public Type ParameterType => ParameterInfo?.ParameterType;

        /// <summary>
        /// 默认值
        /// </summary>
        public object DefaultValue => TypeHelper.GetDefaultValueForType(ParameterType);

        /// <summary>
        /// 参数名称
        /// </summary>
        public string Name => ParameterInfo?.Name;

        /// <summary>
        /// 是否可选
        /// </summary>
        public bool IsOptional => false;

        /// <summary>
        /// 绑定器
        /// </summary>
        public ParameterBindingAttribute ParameterBindingAttribute
        {
            get
            {
                if (_searchedAttribute)
                {
                    return _parameterBindingAttribute;
                }
                _parameterBindingAttribute = FindAttribute();
                _searchedAttribute = true;
                return _parameterBindingAttribute;
            }
        }

        private bool _searchedAttribute;
        private ParameterBindingAttribute _parameterBindingAttribute;

        private ParameterBindingAttribute FindAttribute()
        {
            /*
             *  1.参数本身
             *  2.参数目标类型
             */
            return ChooseAttribute((ParameterBindingAttribute[]) ParameterInfo.GetCustomAttributes()) ??
                   ChooseAttribute((ParameterBindingAttribute[]) ParameterType.GetCustomAttributes());
        }

        private ParameterBindingAttribute ChooseAttribute(IList<ParameterBindingAttribute> attributes)
        {
            if (attributes.Count == 0)
            {
                return null;
            }

            /*
             *  TODO: 多个绑定值返回错误信息;
             */

            return attributes[0];
        }
    }
}