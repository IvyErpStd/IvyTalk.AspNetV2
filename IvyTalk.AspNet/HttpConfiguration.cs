using System.Collections;
using System.Collections.Generic;
using IvyTalk.AspNet.Formatting;

namespace IvyTalk.AspNet
{
    /// <summary>
    /// 暂时没用
    /// </summary>
    public class HttpConfiguration
    {
        public HttpConfiguration()
            : this(CreateDefaultFormatters())
        {
        }

        public HttpConfiguration(ICollection<MediaTypeFormatter> formatters)
        {
            MediaTypeFormatters = formatters;
        }
        
        /// <summary>
        /// 格式化器
        /// </summary>
        public ICollection<MediaTypeFormatter> MediaTypeFormatters { get; }
        
        private static ICollection<MediaTypeFormatter> CreateDefaultFormatters()
        {
            return new MediaTypeFormatter[]
            {
                /* JSON 序列化 */
                new JsonMediaTypeFormatter()
            };
        }

    }
}