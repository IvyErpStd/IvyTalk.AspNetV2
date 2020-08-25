using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Web;
using IvyTalk.AspNet.Controllers;
using IvyTalk.AspNet.Formatting;
using IvyTalk.AspNet.Utilities;

namespace IvyTalk.AspNet.Binding
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
            object value;

            try
            {
                value = BindingCore(request);
            }
            catch (UnsupportedMediaTypeException exception)
            {
                throw new HttpWrapperException(HttpStatusCode.UnsupportedMediaType, "不被支持的媒体类型", exception);
            }

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
            MediaTypeHeaderValue mediaType = request.ContentTypeToMediaType();
            if (mediaType is null)
            {
                return ParameterDescriptor.DefaultValue;
            }

            MediaTypeFormatter formatter =
                new MediaTypeFormatterCollection(Formatters)
                    .FindFormatter(ParameterDescriptor.ParameterType, mediaType);

            if (formatter is null)
            {
                if (request.ContentLength == 0)
                {
                    return ParameterDescriptor.DefaultValue;
                }

                throw new UnsupportedMediaTypeException("未找到相应的序列化对象", mediaType);
            }

            Stream stream = request.InputStream;
            object value = formatter.ReadFromStream(ParameterDescriptor.ParameterType, stream, request);
            return value;
        }
    }
}