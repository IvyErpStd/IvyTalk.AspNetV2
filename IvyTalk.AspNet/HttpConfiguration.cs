using System.Collections;
using System.Collections.Generic;
using IvyTalk.AspNet.Formatting;
using Newtonsoft.Json;

namespace IvyTalk.AspNet
{
    /// <summary>
    /// 暂时没用
    /// </summary>
    public class HttpConfiguration
    {
        public HttpConfiguration()
        {
            MediaTypeFormatters = new MediaTypeFormatterCollection();
        }

        /// <summary>
        /// 格式化器
        /// </summary>
        public MediaTypeFormatterCollection MediaTypeFormatters { get; }

        /// <summary>
        /// 序列化/反序列化设置
        /// </summary>
        public JsonSerializerSettings JsonSerializerSettings
            => MediaTypeFormatters?.JsonFormatter?.JsonSerializerSettings;
    }
}