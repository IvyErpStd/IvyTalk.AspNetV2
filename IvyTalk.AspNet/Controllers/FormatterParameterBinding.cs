using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Web;
using IvyTalk.AspNet.Formatting;
using IvyTalk.AspNet.Utilities;

namespace IvyTalk.AspNet.Controllers
{
    public class FormatterParameterBinding : ParameterBinding
    {
        public FormatterParameterBinding(ParameterDescriptor parameterDescriptor,
            IEnumerable<MediaTypeFormatter> formatters)
            : base(parameterDescriptor)
        {
            Formatters = formatters;
        }

        /// <summary>
        /// 格式化
        /// </summary>
        public IEnumerable<MediaTypeFormatter> Formatters { get; }

        /// <summary>
        /// 是否需要读取 Body
        /// </summary>
        public override bool WillReadBody => true;

        /// <summary>
        /// 执行绑定
        /// </summary>
        public override void ExecuteBinding(ActionContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            HttpRequest request = context.ControllerContext.Request;
            object value = BindingCore(request);

            SetValue(context, value);
        }

        /// <summary>
        /// 绑定核心
        /// </summary>
        private object BindingCore(HttpRequest request)
        {
            // 空的 Body 或没有 Content-Type 直接设置默认值
            if (request.ContentLength == 0 || string.IsNullOrWhiteSpace(request.ContentType))
            {
                return ParameterDescriptor.DefaultValue;
            }

            // 未知 Media-Type
            MediaTypeHeaderValue value = request.ContentTypeToMediaType();
            if (value is null)
            {
                return ParameterDescriptor.DefaultValue;
            }
            //
            // MediaTypeFormatter formatter =
            //     ParameterDescriptor.Configuration.MediaTypeFormatters
            //         .FindFormatter(ParameterDescriptor.ParameterType, value);
        }
    }
}