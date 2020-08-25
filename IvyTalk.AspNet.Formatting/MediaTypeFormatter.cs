using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace IvyTalk.AspNet.Formatting
{
    public abstract class MediaTypeFormatter
    {
        protected MediaTypeFormatter()
        {
            SupportEncodings = new Collection<Encoding>();
            SupportedMediaTypes = new Collection<MediaTypeHeaderValue>();
        }

        protected MediaTypeFormatter(MediaTypeFormatter mediaTypeFormatter)
        {
            SupportEncodings = mediaTypeFormatter.SupportEncodings;
            SupportedMediaTypes = mediaTypeFormatter.SupportedMediaTypes;
        }

        /// <summary>
        /// 支持的编码
        /// </summary>
        public Collection<Encoding> SupportEncodings { get; }

        /// <summary>
        /// 支持的媒体类型
        /// </summary>
        public Collection<MediaTypeHeaderValue> SupportedMediaTypes { get; set; }

        /// <summary>
        /// 支持写任何类型
        /// </summary>
        internal virtual bool CanWriteAnyTypes => true;

        /// <summary>
        /// 从 Stream 转目标类型
        /// </summary>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public virtual object ReadFromStream(Type type, Stream stream, HttpRequest request)
        {
            throw new NotSupportedException($"{GetType().Name} 不支持此方法");
        }

        /// <summary>
        /// 类型是否可以被格式化
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual bool CanFormatterType(Type type) => true;

        /// <summary>
        /// Gets the default value for the specified type.
        /// </summary>
        public static object GetDefaultValueForType(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }

            return null;
        }
    }
}